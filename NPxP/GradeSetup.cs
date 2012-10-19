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
using WRPlugIn;

namespace NPxP
{
    public partial class GradeSetup : Form
    {
        #region Local Variables

        private DataTable _dtbColumns, _dtbRows, _dtbPoints, _dtbGrades;
        private List<string> _pointsSubpieceNames, _marksSubpieceNames;

        #endregion

        #region Constructor

        public GradeSetup()
        {
            InitializeComponent();

        }

        #endregion

        #region R Methods

        // Convert ASCII to Char
        public static char Chr(int Num)
        {
            char C = Convert.ToChar(Num);
            return C;
        }

        // Convert Char to ASCII
        public static int ASC(string S)
        {
            int N = Convert.ToInt32(S[0]);
            return N;
        }

        #endregion

        #region Action Methods

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
                column.FillWeight = c.Width;
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (column.Name == "Name")
                {
                    column.ReadOnly = true;
                }
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
                column.FillWeight = c.Width;
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (column.Name == "Name")
                {
                    column.ReadOnly = true;
                }
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
            _pointsSubpieceNames = new List<string>();
            _pointsSubpieceNames = ch.GetSubPointsNameList(cmbConfig.SelectedItem.ToString().Trim());
            cmbSubPoints.DataSource = _pointsSubpieceNames;

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
                column.FillWeight = c.Width;
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (c.Name == "ClassName")
                {
                    //column.ReadOnly = true;
                }
                dgvPoint.Columns.Add(column);
            }
            dgvPoint.MultiSelect = false;
            dgvPoint.AutoGenerateColumns = false;

            // Initialize dgvGrade without data
            Column gradeName = new Column(0, "GradeName", 200);
            score = new Column(1, "Score", 200);
            columns = new List<Column>();
            columns.Add(gradeName);
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
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (c.Name == "GradeName")
                {
                    //column.ReadOnly = true;
                }
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
            _marksSubpieceNames = ch.GetSubMarksNameList(cmbConfig.SelectedItem.ToString().Trim());
            cmbSubMarks.DataSource = _marksSubpieceNames;

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
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to create new subpiece setting?", "Create Setting", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
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

                // SubpieceName Reset

                _pointsSubpieceNames = new List<string>();
                _marksSubpieceNames = new List<string>();
                _pointsSubpieceNames.Add("All");
                _marksSubpieceNames.Add("All");
                for (int i = 0; i < x; i++)
                {
                    for (int j = 0; j < y; j++)
                    {
                        string name = String.Format("ROI-{0}{1}", i + 1, j + 1);
                        _pointsSubpieceNames.Add(name);
                        _marksSubpieceNames.Add(name);
                    }
                }
                cmbSubMarks.DataSource = null;
                cmbSubMarks.DataSource = _marksSubpieceNames;
                cmbSubPoints.DataSource = null;
                cmbSubPoints.DataSource = _pointsSubpieceNames;

                // Add Points set
                ConfigHelper ch = new ConfigHelper();
                string map_path = ch.GetDefaultMapConfigName();
                Dictionary<int, string> legends = ch.GetPrevFlawLegendDictionary(map_path);
                _dtbPoints.Rows.Clear();
                foreach (string subpiece in _pointsSubpieceNames)
                {
                    foreach (KeyValuePair<int, string> l in legends)
                    {
                        // SubpieceName, ClassName, Score
                        DataRow dr = _dtbPoints.NewRow();
                        dr["SubpieceName"] = subpiece;
                        dr["ClassName"] = l.Value;
                        dr["Score"] = 0;
                        _dtbPoints.Rows.Add(dr);
                    }
                }

                // Refresh Mark
                foreach (string subpiece in _marksSubpieceNames)
                {
                    string expr = String.Format("SubpieceName='{0}'", subpiece);
                    DataRow[] drs = _dtbGrades.Select(expr);
                    if (drs.Length < 1)
                    {
                        DataRow dr = _dtbGrades.NewRow();
                        dr["SubpieceName"] = subpiece;
                        dr["GradeName"] = "A";
                        dr["Score"] = 0;
                        _dtbGrades.Rows.Add(dr);
                    }
                }
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
                MessageBox.Show("File name is empty.");
                return;
            }

            // ROI-Setting
            //----------------------------------------------------------------------------------//

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
            // Remove old  columns for add new record
            if (navigator.Select("//roi/columns/column").Count > 0)
            {
                XPathNavigator first = navigator.SelectSingleNode("//roi/columns/column[1]");
                XPathNavigator last = navigator.SelectSingleNode("//roi/columns/column[last()]");
                navigator.MoveTo(first);
                navigator.DeleteRange(last);
            }
            // save _dgvColumns data to xml
            for (int i = 0; i < _dtbColumns.Rows.Count; i++)
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

            // Remove old rows for add new record.
            if (navigator.Select("//roi/rows/row").Count > 0)
            {
                XPathNavigator first = navigator.SelectSingleNode("//roi/rows/row[1]");
                XPathNavigator last = navigator.SelectSingleNode("//roi/rows/row[last()]");
                navigator.MoveTo(first);
                navigator.DeleteRange(last);
            }
            // save _dtbRows data to xml
            for (int i = 0; i < _dtbRows.Rows.Count; i++)
            {
                string name = _dtbRows.Rows[i]["Name"].ToString();
                string start = _dtbRows.Rows[i]["Start"].ToString();
                string end = _dtbRows.Rows[i]["End"].ToString();
                navigator.SelectSingleNode("//roi/rows").AppendChildElement(string.Empty, "row", string.Empty, null);
                // Move to last column element and add name, start, end value.
                navigator.SelectSingleNode("//roi/rows/row[last()]").AppendChildElement(string.Empty, "name", string.Empty, name);
                navigator.SelectSingleNode("//roi/rows/row[last()]").AppendChildElement(string.Empty, "start", string.Empty, start);
                navigator.SelectSingleNode("//roi/rows/row[last()]").AppendChildElement(string.Empty, "end", string.Empty, end);
            }

            // Grade - Setting
            //----------------------------------------------------------------------------------//

            // Points
            // Save is points enable?
            navigator.SelectSingleNode("//grade/points/enable").SetValue(chkEnablePonit.Checked.ToString());

            // Remove old points/sub_piece for add new record. (_dtbPoints)
            if (navigator.Select("//grade/points/sub_piece").Count > 0)
            {
                XPathNavigator first = navigator.SelectSingleNode("//grade/points/sub_piece[1]");
                XPathNavigator last = navigator.SelectSingleNode("//grade/points/sub_piece[last()]");
                navigator.MoveTo(first);
                navigator.DeleteRange(last);
            }
            // save _dtbPoints
            List<string> pointsSubpieces = _pointsSubpieceNames;
            // prepare flawtype convert dictionary
            string map_config_path = ch.GetDefaultMapConfigName();
            Dictionary<string, int> flawlegends = ch.GetPrevFlawLegendDictionaryID(map_config_path);
            foreach (string subpieceName in pointsSubpieces)
            {
                navigator.SelectSingleNode("//grade/points").AppendChildElement(string.Empty, "sub_piece", string.Empty, null);
                // Move to last column element and add name value.
                navigator.SelectSingleNode("//grade/points/sub_piece[last()]").AppendChildElement(string.Empty, "name", string.Empty, subpieceName);
                string expr = String.Format("SubpieceName='{0}'", subpieceName);
                // check all same
                if (chkAllSameOfPoint.Checked)
                {
                    expr = String.Format("SubpieceName='{0}'", "All");
                }

                DataRow[] drs = _dtbPoints.Select(expr);
                foreach (DataRow dr in drs)
                {
                    string className = dr["ClassName"].ToString();
                    int classID = flawlegends[className];
                    string score = dr["Score"].ToString();
                    navigator.SelectSingleNode("//grade/points/sub_piece[last()]").AppendChildElement(string.Empty, "flawtype_score", string.Empty, score);
                    navigator.SelectSingleNode("//grade/points/sub_piece[last()]/flawtype_score[last()]").CreateAttribute(string.Empty, "id", string.Empty, classID.ToString());
                }
            }

            // Remove old grade(marks)/subpiece for add new record . (_dtbGrades)
            if (navigator.Select("//grade/marks/sub_piece").Count > 0)
            {
                XPathNavigator first = navigator.SelectSingleNode("//grade/marks/sub_piece[1]");
                XPathNavigator last = navigator.SelectSingleNode("//grade/marks/sub_piece[last()]");
                navigator.MoveTo(first);
                navigator.DeleteRange(last);
            }

            // Marks
            // Save is grade(marks) enable?
            navigator.SelectSingleNode("//grade/marks/enable").SetValue(chkEnableGrade.Checked.ToString());

            // save _dtbGrades
            List<string> marksSubpieces = _marksSubpieceNames;
            foreach (string subpieceName in marksSubpieces)
            {
                navigator.SelectSingleNode("//grade/marks").AppendChildElement(string.Empty, "sub_piece", string.Empty, null);
                //Move to last column element and add name value.
                navigator.SelectSingleNode("//grade/marks/sub_piece[last()]").AppendChildElement(string.Empty, "name", string.Empty, subpieceName);
                string expr = String.Format("SubpieceName='{0}'", subpieceName);
                // check all same
                if (chkAllSameOfGrade.Checked)
                {
                    expr = String.Format("SubpieceName='{0}'", "All");
                }
                DataRow[] drs = _dtbGrades.Select(expr);
                foreach (DataRow dr in drs)
                {
                    string className = dr["GradeName"].ToString();
                    string score = dr["Score"].ToString();
                    navigator.SelectSingleNode("//grade/marks/sub_piece[last()]").AppendChildElement(string.Empty, "mark", string.Empty, score);
                    navigator.SelectSingleNode("//grade/marks/sub_piece[last()]/mark[last()]").CreateAttribute(string.Empty, "id", string.Empty, className);
                }
            }

            // Pass or Fail
            // Save filter score is enable?
            navigator.SelectSingleNode("//grade/pass_fail/enable").SetValue(chkEnablePFS.Checked.ToString());
            int filterScore = int.TryParse(txtFilterScore.Text, out filterScore) ? filterScore : 0;
            navigator.SelectSingleNode("//grade/pass_fail/score").SetValue(filterScore.ToString());


            // Finish Save
            //----------------------------------------------------------------------------------//

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

            // Refresh datas
            // Refresh dgvPoint datasource
            _dtbPoints.Clear();
            DataTable tmpPoints = ch.GetDataTabledgvPoints(cmbConfig.SelectedItem.ToString().Trim());
            foreach (DataRow dr in tmpPoints.Rows)
            {
                DataRow d = _dtbPoints.NewRow();
                d["SubpieceName"] = dr["SubpieceName"];
                d["ClassName"] = dr["ClassName"];
                d["Score"] = dr["Score"];
                _dtbPoints.Rows.Add(d);
            }
            DataView dvPoints = _dtbPoints.DefaultView;
            dvPoints.RowFilter = String.Format("SubpieceName='{0}'", cmbSubPoints.SelectedItem.ToString().Trim());
            tmpPoints.Dispose();

            // Refresh dgvGrade datasource
            _dtbGrades.Clear();
            DataTable tmpGrades = ch.GetDataTabledgvGrade(cmbConfig.SelectedItem.ToString().Trim());
            foreach (DataRow dr in tmpGrades.Rows)
            {
                DataRow d = _dtbGrades.NewRow();
                d["SubpieceName"] = dr["SubpieceName"];
                d["GradeName"] = dr["GradeName"];
                d["Score"] = dr["Score"];
                _dtbGrades.Rows.Add(d);
            }
            DataView dvGrade = _dtbGrades.DefaultView;
            dvGrade.RowFilter = String.Format("SubpieceName='{0}'", cmbSubMarks.SelectedItem.ToString().Trim());
            tmpGrades.Dispose();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to reset subpiece setting?", "Reset Setting", MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
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
                _pointsSubpieceNames = ch.GetSubPointsNameList(cmbConfig.SelectedItem.ToString().Trim());

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

        private void txtFilterScore_KeyPress(object sender, KeyPressEventArgs e)
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

        private void dgvPoint_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = false;
            MessageBox.Show("Input value format error.");
        }

        private void dgvPoint_KeyPress(object sender, KeyPressEventArgs e)
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

        private void dgvPoint_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (String.IsNullOrEmpty(e.FormattedValue.ToString()))
            {
                e.Cancel = true;
            }
        }

        private void dgvGrade_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = false;
            MessageBox.Show("Input value format error.");
        }

        private void dgvGrade_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (String.IsNullOrEmpty(e.FormattedValue.ToString()))
            {
                e.Cancel = true;
            }
        }

        private void dgvGrade_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (dgvGrade.Rows.Count <= 1)
            {
                e.Cancel = true;
            }
        }

        private void dgvGrade_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == dgvGrade.Rows.Count - 1 && dgvGrade.Rows.Count < 5)
            {
                string subpieceName = cmbSubMarks.SelectedItem.ToString().Trim();
                string expr = String.Format("SubpieceName='{0}'", subpieceName);
                DataRow dr = _dtbGrades.NewRow();
                dr["SubpieceName"] = subpieceName;
                dr["GradeName"] = "A";
                dr["Score"] = 0;
                _dtbGrades.Rows.Add(dr);
                DataRow[] drs = _dtbGrades.Select(expr);
                int chrNo = 65;

                foreach (DataRow d in drs)
                {
                    d["GradeName"] = Chr(chrNo).ToString();
                    chrNo++;
                }
            }
            else
            {
                if(e.RowIndex == 4)
                    MessageBox.Show("Other score belone grade \"F\" ");
            }
        }

        private void dgvGrade_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            string subpieceName = cmbSubMarks.SelectedItem.ToString().Trim();
            string expr = String.Format("SubpieceName='{0}'", subpieceName);
            DataRow[] drs = _dtbGrades.Select(expr);
            int chrNo = 65;

            foreach (DataRow d in drs)
            {
                d["GradeName"] = Chr(chrNo).ToString();
                chrNo++;
            }
        }

        private void cmbConfig_DropDownClosed(object sender, EventArgs e)
        {
            ConfigHelper ch = new ConfigHelper();

            //ROI Settings
            //----------------------------------------------------------------------------------------//

            // Set Roi Mode
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

            // Set TextBox of Columns, Rows
            txtColumns.Text = ch.GetGradeColumns(cmbConfig.SelectedItem.ToString()).ToString();
            txtRows.Text = ch.GetGradeRows(cmbConfig.SelectedItem.ToString()).ToString();

            // Reload DataTable of dgvColumns and dgvRows
            _dtbColumns.Clear();
            DataTable tmpColumns = ch.GetDataTableOfdgvColumns(cmbConfig.SelectedItem.ToString().Trim());
            foreach (DataRow dr in tmpColumns.Rows)
            {
                DataRow d = _dtbColumns.NewRow();
                d["Name"] = dr["Name"];
                d["Start"] = dr["Start"];
                d["End"] = dr["End"];
                _dtbColumns.Rows.Add(d);
            }
            tmpColumns.Dispose();
            _dtbRows.Clear();
            DataTable tmpRows = ch.GetDataTableOfdgvRows(cmbConfig.SelectedItem.ToString().Trim());
            foreach (DataRow dr in tmpRows.Rows)
            {
                DataRow d = _dtbRows.NewRow();
                d["Name"] = dr["Name"];
                d["Start"] = dr["Start"];
                d["End"] = dr["End"];
                _dtbRows.Rows.Add(d);
            }
            tmpRows.Dispose();

            // Grade Settings
            //----------------------------------------------------------------------------------------//

            // Initialize Point is enable. 
            chkEnablePonit.Checked = ch.IsGradePointEnable(cmbConfig.SelectedItem.ToString().Trim());

            // Initialize SubPiece (cmbSubPoints)
            _pointsSubpieceNames = ch.GetSubPointsNameList(cmbConfig.SelectedItem.ToString().Trim());
            cmbSubPoints.DataSource = _pointsSubpieceNames;

            // Set dgvPoint datasource
            _dtbPoints.Clear();
            DataTable tmpPoints = ch.GetDataTabledgvPoints(cmbConfig.SelectedItem.ToString().Trim());
            foreach (DataRow dr in tmpPoints.Rows)
            {
                DataRow d = _dtbPoints.NewRow();
                d["SubpieceName"] = dr["SubpieceName"];
                d["ClassName"] = dr["ClassName"];
                d["Score"] = dr["Score"];
                _dtbPoints.Rows.Add(d);
            }
            DataView dvPoints = _dtbPoints.DefaultView;
            dvPoints.RowFilter = String.Format("SubpieceName='{0}'", cmbSubPoints.SelectedItem.ToString().Trim());
            tmpPoints.Dispose();

            // Initialize grade is enable (marks)
            chkEnableGrade.Checked = ch.IsGradeMarksEnable(cmbConfig.SelectedItem.ToString().Trim());

            // Initialize SubPiece (cmbSubPoints)
            cmbSubMarks.DataSource = ch.GetSubMarksNameList(cmbConfig.SelectedItem.ToString().Trim());

            // Set dgvGrade datasource
            _dtbGrades.Clear();
            DataTable tmpGrades = ch.GetDataTabledgvGrade(cmbConfig.SelectedItem.ToString().Trim());
            foreach (DataRow dr in tmpGrades.Rows)
            {
                DataRow d = _dtbGrades.NewRow();
                d["SubpieceName"] = dr["SubpieceName"];
                d["GradeName"] = dr["GradeName"];
                d["Score"] = dr["Score"];
                _dtbGrades.Rows.Add(d);
            }
            DataView dvGrade = _dtbGrades.DefaultView;
            dvGrade.RowFilter = String.Format("SubpieceName='{0}'", cmbSubMarks.SelectedItem.ToString().Trim());
            tmpGrades.Dispose();

            // Initialize Tab of grade/pass or fail
            chkEnablePFS.Checked = ch.IsGradePassFailEnable(cmbConfig.SelectedItem.ToString().Trim());
            txtFilterScore.Text = ch.GetPassFailScore(cmbConfig.SelectedItem.ToString().Trim()).ToString();
        }

        private void chkEnablePonit_CheckedChanged(object sender, EventArgs e)
        {
            grbPointSetting.Enabled = chkEnablePonit.Checked;
            if (!chkEnablePonit.Checked)
            {
                chkEnableGrade.Checked = false;
                chkEnableGrade.Enabled = false;
                chkEnablePFS.Checked = false;
                chkEnablePFS.Enabled = false;
            }
            else
            {
                chkEnableGrade.Enabled = true;
                chkEnablePFS.Enabled = true;
            }
        }

        private void chkEnableGrade_CheckedChanged(object sender, EventArgs e)
        {
            grbGradeSetting.Enabled = chkEnableGrade.Checked;
            if (!chkEnableGrade.Checked)
            {
                chkEnablePonit.Enabled = true;
            }
            else
            {
                chkEnablePFS.Enabled = true;
                chkEnablePonit.Checked = true;
                chkEnablePonit.Enabled = false;
            }
        }

        private void chkEnablePFS_CheckedChanged(object sender, EventArgs e)
        {
            txtFilterScore.Enabled = chkEnablePFS.Checked;
            if (chkEnablePFS.Checked)
            {
                chkEnablePonit.Checked = true;
                chkEnablePonit.Enabled = false;
            }
            else
            {
                chkEnableGrade.Enabled = true;
            }
        }

        private void RoiMode_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdo = sender as RadioButton;
            if (rdo.Text == "No ROI" && rdo.Checked)
            {
                pnlRoiGrid.Visible = false;
                tabGradeSetting.Visible = false;
            }
            else
            {
                pnlRoiGrid.Visible = true;
                tabGradeSetting.Visible = true;
            }
        }

        #endregion       
    }
}
