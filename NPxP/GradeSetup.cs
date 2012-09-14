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

namespace NPxP
{
    public partial class GradeSetup : Form
    {
        private DataTable _dtbColumns, _dtbRows;
        public GradeSetup()
        {
            InitializeComponent();
        }

        private void GradeSetup_Load(object sender, EventArgs e)
        {
            // Prepare cmbGradeConfigFiles datasource
            List<string> gradeConfigs = new List<string>();
            DirectoryInfo dirInfo = new DirectoryInfo(PathHelper.GradeConfigFolder);
            FileInfo[] files = dirInfo.GetFiles("*.xml");
            foreach (FileInfo file in files)
            {
                gradeConfigs.Add(file.Name.ToString().Substring(0, file.Name.ToString().LastIndexOf(".")));
            }
            // Binding cmbGradeConfigFiles
            cmbGradeConfigFiles.DataSource = gradeConfigs;
            ConfigHelper ch = new ConfigHelper();
            cmbGradeConfigFiles.SelectedItem = ch.GetDefaultGradeConfigName().Trim();

            //-Tab of ROI Settings---------------------------------------------------------------------------------------//

            // Initialize Roi Mode
            RadioButton[] rdos = { rdoNoRoi, rdoSymmetrical };
            foreach (RadioButton rdo in rdos)
            { 
                string roiMode = ch.GetGradeNoRoiMode(cmbGradeConfigFiles.SelectedItem.ToString());
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
            txtColumns.Text = ch.GetGradeColumns(cmbGradeConfigFiles.SelectedItem.ToString()).ToString();
            txtRows.Text = ch.GetGradeRows(cmbGradeConfigFiles.SelectedItem.ToString()).ToString();

            // Initialize dgvColumns and dgvRows without data.
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
            dgvColumns.MultiSelect = false;
            dgvColumns.AutoGenerateColumns = false;
            dgvRows.MultiSelect = false;
            dgvRows.AutoGenerateColumns = false;

            // Initialize DataTable of dgvColumns and dgvRows
            _dtbColumns = ch.GetDataTableOfdgvColumns(cmbGradeConfigFiles.SelectedItem.ToString().Trim());
            dgvColumns.DataSource = _dtbColumns;
            _dtbRows = ch.GetDataTableOfdgvRows(cmbGradeConfigFiles.SelectedItem.ToString().Trim());
            dgvRows.DataSource = _dtbRows;


            //- Tab of Grade Settings---------------------------------------------------------------------------------------//
            
            // Initialize Tab of grade/point
            chkEnablePonit.Checked = ch.IsGradePointEnable(cmbGradeConfigFiles.SelectedItem.ToString().Trim());


            // Initialize Tab of grade/grade
            chkEnableGrade.Checked = ch.IsGradeMarksEnable(cmbGradeConfigFiles.SelectedItem.ToString().Trim());

            // Initialize Tab of grade/pass or fail
            chkEnablePFS.Checked = ch.IsGradePassFailEnable(cmbGradeConfigFiles.SelectedItem.ToString().Trim());
            txtFilterScore.Text = ch.GetPassFailScore(cmbGradeConfigFiles.SelectedItem.ToString().Trim()).ToString();
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

       

       

    }
}
