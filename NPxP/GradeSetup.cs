using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NPxP.Helper;
using System.IO;
using NPxP.Model;
using System.Xml;
using System.Xml.XPath;

namespace NPxP
{
    public partial class GradeSetup : Form
    {
        private DataTable _dtbColumns, _dtbRows, _dtbPoints, _dtbGrades;
        public GradeSetup()
        {
            InitializeComponent();
        }
        private void GradeSetup_Load(object sender, EventArgs e)
        {
            // Prepare cmbConfig datasource
            List<string> gradeConfigs = new List<string>();
            DirectoryInfo dirInfo = new DirectoryInfo(PathHelper.GradeConfigFolder);
            FileInfo[] files = dirInfo.GetFiles("*.xml");
            foreach (FileInfo file in files)
            {
                gradeConfigs.Add(file.Name.ToString().Substring(0, file.Name.ToString().LastIndexOf(".")));
            }
            // Binding cmbConfig
            cmbConfig.DataSource = gradeConfigs;
            ConfigHelper ch = new ConfigHelper();
            cmbConfig.SelectedItem = ch.GetDefaultGradeConfigName().Trim();


            //ROI Settings
            //----------------------------------------------------------------------------------------//

            // Initialize Roi Mode
            RadioButton[] rdos = { rdoNoRoi, rdoSymmetrical };
            foreach (RadioButton rdo in rdos)
            {
                string roiMode = ch.GetGradeNoRoiMode(cmbConfig.SelectedItem.ToString());
                if (rdo.Text == roiMode)
                {
                    rdo.Checked = true;
                }
                else
                {
                    rdo.Checked = false;
                }
            }

            // Initialize TextBox of Columns, Rows
            txtColumns.Text = ch.GetGradeColumns(cmbConfig.SelectedItem.ToString()).ToString();
            txtRows.Text = ch.GetGradeRows(cmbConfig.SelectedItem.ToString()).ToString();

            // Initialize dgvColumns without data.
            Column name = new Column(0, "Name", 75);
            Column start = new Column(1, "Start", 60);
            Column end = new Column(2, "End", 60);
            List<Column> columns = new List<Column>();
            columns.Add(name);
            columns.Add(start);
            columns.Add(end);
            foreach (Column c in columns)
            {
                DataGridViewCell cell = new DataGridViewTextBoxCell();
                DataGridViewColumn column = new DataGridViewColumn();
                column.CellTemplate = cell;
                column.Name = c.Name;
                column.HeaderText = c.Name;
                column.Width = c.Width;
                column.DataPropertyName = c.Name;
                column.SortMode = DataGridViewColumnSortMode.Automatic;
                dgvColumns.Columns.Add(column);
            }
            dgvColumns.MultiSelect = false;
            dgvColumns.AutoGenerateColumns = false;

            // Initialize dgvRows without data.
            foreach (Column c in columns)
            {
                DataGridViewCell cell = new DataGridViewTextBoxCell();
                DataGridViewColumn column = new DataGridViewColumn();
                column.CellTemplate = cell;
                column.Name = c.Name;
                column.HeaderText = c.Name;
                column.Width = c.Width;
                column.DataPropertyName = c.Name;
                column.SortMode = DataGridViewColumnSortMode.Automatic;
                dgvRows.Columns.Add(column);
            }
            dgvRows.MultiSelect = false;
            dgvRows.AutoGenerateColumns = false;

            // Initialize DataTable of dgvColumns and dgvRows
            _dtbColumns = ch.GetDataTableOfdgvColumns(cmbConfig.SelectedItem.ToString().Trim());
            dgvColumns.DataSource = _dtbColumns;
            _dtbRows = ch.GetDataTableOfdgvRows(cmbConfig.SelectedItem.ToString().Trim());
            dgvRows.DataSource = _dtbRows;


            // Grade Settings
            //----------------------------------------------------------------------------------------//

            // Initialize Point is enable. 
            chkEnablePonit.Checked = ch.IsGradePointEnable(cmbConfig.SelectedItem.ToString().Trim());

            // Initialize SubPiece (cmbSubPoints)
            cmbSubPoints.DataSource = ch.GetSubPointsNameList(cmbConfig.SelectedItem.ToString().Trim());

            // Initialize dgvPoint without data
            Column className = new Column(0, "ClassName", 200);
            Column score = new Column(1, "Score", 200);
            columns = new List<Column>();
            columns.Add(className);
            columns.Add(score);
            foreach (Column c in columns)
            {
                DataGridViewCell cell = new DataGridViewTextBoxCell();
                DataGridViewColumn column = new DataGridViewColumn();
                column.CellTemplate = cell;
                column.Name = c.Name;
                column.HeaderText = c.Name;
                column.Width = c.Width;
                column.DataPropertyName = c.Name;
                column.SortMode = DataGridViewColumnSortMode.Automatic;
                dgvPoint.Columns.Add(column);
            }
            dgvPoint.MultiSelect = false;
            dgvPoint.AutoGenerateColumns = false;

            // Initialize dgvGrade without data
            foreach (Column c in columns)
            {
                DataGridViewCell cell = new DataGridViewTextBoxCell();
                DataGridViewColumn column = new DataGridViewColumn();
                column.CellTemplate = cell;
                column.Name = c.Name;
                column.HeaderText = c.Name;
                column.Width = c.Width;
                column.DataPropertyName = c.Name;
                column.SortMode = DataGridViewColumnSortMode.Automatic;
                dgvGrade.Columns.Add(column);
            }
            dgvGrade.MultiSelect = false;
            dgvGrade.AutoGenerateColumns = false;

            // Set dgvPoint datasource
            _dtbPoints = ch.GetDataTabledgvPoints(cmbConfig.SelectedItem.ToString().Trim());
            dgvPoint.DataSource = _dtbPoints;
            DataView dvPoints = _dtbPoints.DefaultView;
            dvPoints.RowFilter = String.Format("SubpieceName='{0}'", cmbSubPoints.SelectedItem.ToString().Trim());

            // Initialize grade is enable (marks)
            chkEnableGrade.Checked = ch.IsGradeMarksEnable(cmbConfig.SelectedItem.ToString().Trim());

            // Initialize SubPiece (cmbSubPoints)
            cmbSubMarks.DataSource = ch.GetSubMarksNameList(cmbConfig.SelectedItem.ToString().Trim());

            // Set dgvGrade datasource
            _dtbGrades = ch.GetDataTabledgvGrade(cmbConfig.SelectedItem.ToString().Trim());
            dgvGrade.DataSource = _dtbGrades;
            DataView dvGrade = _dtbGrades.DefaultView;
            dvGrade.RowFilter = String.Format("SubpieceName='{0}'", cmbSubMarks.SelectedItem.ToString().Trim());

            // Initialize Tab of grade/pass or fail
            chkEnablePFS.Checked = ch.IsGradePassFailEnable(cmbConfig.SelectedItem.ToString().Trim());
            txtFilterScore.Text = ch.GetPassFailScore(cmbConfig.SelectedItem.ToString().Trim()).ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCreateGrid_Click(object sender, EventArgs e)
        {
            int x = int.TryParse(txtColumns.Text, out x) ? x : 1;
            int y = int.TryParse(txtRows.Text, out y) ? y : 1;
            _dtbColumns.Clear();
            for (int i = 0; i < x; i++)
            {
                DataRow dr = _dtbColumns.NewRow();
                dr["Name"] = i + 1;
                _dtbColumns.Rows.Add(dr);
            }
            _dtbRows.Clear();
            for (int i = 0; i < y; i++)
            {
                DataRow dr = _dtbRows.NewRow();
                dr["Name"] = i + 1;
                _dtbRows.Rows.Add(dr);
            }
            
        }

        private void txtColumns_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtRows_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void Double_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            double newValue;
            DataGridView dgv = sender as DataGridView;
            if (dgv.Rows[e.RowIndex].IsNewRow) { return; }
            if (e.ColumnIndex != 0)
            {
                if (!double.TryParse(e.FormattedValue.ToString(),
                    out newValue) || newValue < 0)
                {
                    e.Cancel = true;
                }
            }
        }

        private void cmbSubPoints_DropDownClosed(object sender, EventArgs e)
        {
            DataView dvPoints = _dtbPoints.DefaultView;
            dvPoints.RowFilter = String.Format("SubpieceName='{0}'", cmbSubPoints.SelectedItem.ToString().Trim());
        }

        private void cmbSubMarks_DropDownClosed(object sender, EventArgs e)
        {
            DataView dvGrade = _dtbGrades.DefaultView;
            dvGrade.RowFilter = String.Format("SubpieceName='{0}'", cmbSubMarks.SelectedItem.ToString().Trim());
        }
        // Save xml
        private void btnSaveGradeConfigFile_Click(object sender, EventArgs e)
        {

            // if some data wrong will tip.
            if (_dtbColumns.Rows.Count < 1 || _dtbRows.Rows.Count < 1 || _dtbPoints.Rows.Count < 1 || _dtbGrades.Rows.Count < 1)
            {
                MessageBox.Show("Input has null value.");
                return;
            }

            DataHelper dh = new DataHelper();
            if (dh.HasNull(_dtbColumns) || dh.HasNull(_dtbRows) || dh.HasNull(_dtbPoints) || dh.HasNull(_dtbGrades))
            {
                MessageBox.Show("Input has null value.");
                return;
            }

            // Save default config file to system config
            ConfigHelper ch = new ConfigHelper();
            if (String.IsNullOrEmpty(cmbConfig.Text))
            {
                cmbConfig.Text = DateTime.Now.ToShortDateString();
            }
            // if save error break;
            if (!ch.SaveGradeSetupConfigFile(cmbConfig.Text.Trim()))
            {
                return;
            }

            // initialize grade xml sechma
            string sechma_path = PathHelper.SystemConfigFolder + "grade_sechma.xml";
            XmlDocument document = new XmlDocument();
            document.Load(sechma_path);
            XPathNavigator navigator = document.CreateNavigator();

            // save roi mode
            RadioButton[] rdos = { rdoNoRoi, rdoSymmetrical };
            foreach (RadioButton rdo in rdos)
            {
                if (rdo.Checked)
                {
                    navigator.SelectSingleNode("//roi/mode").SetValue(rdo.Text.Trim());
                }
            }

            // Save roi columns , rows size
            navigator.SelectSingleNode("//roi/columns/size").SetValue(_dtbColumns.Rows.Count.ToString());
            navigator.SelectSingleNode("//roi/rows/size").SetValue(_dtbRows.Rows.Count.ToString());

            // save roi data (start, end) of columns , rows.
            // Remove old relative_table for add new record
            if (navigator.Select("//roi/columns/column").Count > 0)
            {
                XPathNavigator first = navigator.SelectSingleNode("//roi/columns/column[1]");
                XPathNavigator last = navigator.SelectSingleNode("//roi/columns/column[last()]");
                navigator.MoveTo(first);
                navigator.DeleteRange(last);
            }
            // save _dgvColumns data to xml
            for (int i = 0; i < _dtbColumns.Rows.Count - 1; i++)
            {

                string name = _dtbColumns.Rows[i]["Name"].ToString();
                string start = _dtbColumns.Rows[i]["Start"].ToString();
                string end = _dtbColumns.Rows[i]["End"].ToString();
                navigator.SelectSingleNode("//roi/columns").AppendChildElement(string.Empty, "column", string.Empty, null);
                // Move to last column element and add name, start, end value.
                navigator.SelectSingleNode("//roi/columns/column[last()]").AppendChildElement(string.Empty, "name", string.Empty, name);
                navigator.SelectSingleNode("//roi/columns/column[last()]").AppendChildElement(string.Empty, "start", string.Empty, start);
                navigator.SelectSingleNode("//roi/columns/column[last()]").AppendChildElement(string.Empty, "end", string.Empty, end);
            }
            

             

            // save
            string grade_path = PathHelper.GradeConfigFolder + cmbConfig.Text.Trim() + ".xml";
            try
            {
                document.Save(grade_path);
                // Re binding cmbMapConfigName datasource
                List<string> graeConfigs = new List<string>();
                DirectoryInfo dirInfo = new DirectoryInfo(PathHelper.GradeConfigFolder);
                FileInfo[] files = dirInfo.GetFiles("*.xml");
                foreach (FileInfo file in files)
                {
                    graeConfigs.Add(file.Name.ToString().Substring(0, file.Name.ToString().LastIndexOf(".")));
                }
                // Binding datasource for cmbMapConfigName and set default value.
                cmbConfig.DataSource = graeConfigs;
                cmbConfig.SelectedItem = ch.GetDefaultGradeConfigName().Trim();
                MessageBox.Show("Success.");
            }
            catch
            {
                MessageBox.Show("Fail.");
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            // Prepare cmbConfig datasource
            List<string> gradeConfigs = new List<string>();
            DirectoryInfo dirInfo = new DirectoryInfo(PathHelper.GradeConfigFolder);
            FileInfo[] files = dirInfo.GetFiles("*.xml");
            foreach (FileInfo file in files)
            {
                gradeConfigs.Add(file.Name.ToString().Substring(0, file.Name.ToString().LastIndexOf(".")));
            }
            // Binding cmbConfig
            cmbConfig.DataSource = gradeConfigs;
            ConfigHelper ch = new ConfigHelper();
            cmbConfig.SelectedItem = ch.GetDefaultGradeConfigName().Trim();


            //ROI Settings
            //----------------------------------------------------------------------------------------//

            // Initialize Roi Mode
            RadioButton[] rdos = { rdoNoRoi, rdoSymmetrical };
            foreach (RadioButton rdo in rdos)
            {
                string roiMode = ch.GetGradeNoRoiMode(cmbConfig.SelectedItem.ToString());
                if (rdo.Text == roiMode)
                {
                    rdo.Checked = true;
                }
                else
                {
                    rdo.Checked = false;
                }
            }

            // Initialize TextBox of Columns, Rows
            txtColumns.Text = ch.GetGradeColumns(cmbConfig.SelectedItem.ToString()).ToString();
            txtRows.Text = ch.GetGradeRows(cmbConfig.SelectedItem.ToString()).ToString();


            // Initialize DataTable of dgvColumns and dgvRows
            _dtbColumns = ch.GetDataTableOfdgvColumns(cmbConfig.SelectedItem.ToString().Trim());
            dgvColumns.DataSource = _dtbColumns;
            _dtbRows = ch.GetDataTableOfdgvRows(cmbConfig.SelectedItem.ToString().Trim());
            dgvRows.DataSource = _dtbRows;


            // Grade Settings
            //----------------------------------------------------------------------------------------//

            // Initialize Point is enable. 
            chkEnablePonit.Checked = ch.IsGradePointEnable(cmbConfig.SelectedItem.ToString().Trim());

            // Initialize SubPiece (cmbSubPoints)
            cmbSubPoints.DataSource = ch.GetSubPointsNameList(cmbConfig.SelectedItem.ToString().Trim());

            // Set dgvPoint datasource
            _dtbPoints = ch.GetDataTabledgvPoints(cmbConfig.SelectedItem.ToString().Trim());
            dgvPoint.DataSource = _dtbPoints;
            DataView dvPoints = _dtbPoints.DefaultView;
            dvPoints.RowFilter = String.Format("SubpieceName='{0}'", cmbSubPoints.SelectedItem.ToString().Trim());

            // Initialize grade is enable (marks)
            chkEnableGrade.Checked = ch.IsGradeMarksEnable(cmbConfig.SelectedItem.ToString().Trim());

            // Initialize SubPiece (cmbSubPoints)
            cmbSubMarks.DataSource = ch.GetSubMarksNameList(cmbConfig.SelectedItem.ToString().Trim());

            // Set dgvGrade datasource
            _dtbGrades = ch.GetDataTabledgvGrade(cmbConfig.SelectedItem.ToString().Trim());
            dgvGrade.DataSource = _dtbGrades;
            DataView dvGrade = _dtbGrades.DefaultView;
            dvGrade.RowFilter = String.Format("SubpieceName='{0}'", cmbSubMarks.SelectedItem.ToString().Trim());

            // Initialize Tab of grade/pass or fail
            chkEnablePFS.Checked = ch.IsGradePassFailEnable(cmbConfig.SelectedItem.ToString().Trim());
            txtFilterScore.Text = ch.GetPassFailScore(cmbConfig.SelectedItem.ToString().Trim()).ToString();
        }

        


    }
}
