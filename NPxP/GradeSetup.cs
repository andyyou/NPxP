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

namespace NPxP
{
    public partial class GradeSetup : Form
    {
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
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

       

    }
}
