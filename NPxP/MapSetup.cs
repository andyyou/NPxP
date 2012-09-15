using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using NPxP.Helper;
using System.Xml;
using System.Xml.XPath;
using System.Text.RegularExpressions;
namespace NPxP
{
    public partial class MapSetup : Form
    {
        public MapSetup()
        {
            InitializeComponent();
        }

        //----------------------------------------------------------------------------------//

        private void MapSetup_Load(object sender, EventArgs e)
        {
            // Prepare cmbMapConfigName datasource
            List<string> mapConfigs = new List<string>();
            DirectoryInfo dirInfo = new DirectoryInfo(PathHelper.MapConfigFolder);
            FileInfo[] files = dirInfo.GetFiles("*.xml");
            foreach (FileInfo file in files)
            {
                mapConfigs.Add(file.Name.ToString().Substring(0, file.Name.ToString().LastIndexOf(".")));
            }
            // Binding datasource for cmbMapConfigName and set default value.
            cmbMapConfigName.DataSource = mapConfigs;
            ConfigHelper ch = new ConfigHelper();
            cmbMapConfigName.SelectedItem = ch.GetDefaultMapConfigName().Trim();

            // Initialize nudImageColumns, nudImageRows value.
            nudImageColumns.Value = ch.GettlpFlawImagesColumns(cmbMapConfigName.SelectedItem.ToString());
            nudImageRows.Value = ch.GettlpFlawImagesRows(cmbMapConfigName.SelectedItem.ToString());

            // Initialize rdoMapGridOn,rdoMapGridOff
            rdoMapGridOn.Checked = ch.GetIsDisplayMapGrid(cmbMapConfigName.SelectedItem.ToString());
            rdoMapGridOff.Checked = !ch.GetIsDisplayMapGrid(cmbMapConfigName.SelectedItem.ToString());

            // Initialize rdoFixCellSize, rdoCountSize
            rdoFixCellSize.Checked = ch.GetIsFixCellSizeMode(cmbMapConfigName.SelectedItem.ToString());
            rdoCountSize.Checked = !ch.GetIsFixCellSizeMode(cmbMapConfigName.SelectedItem.ToString());

            if (rdoFixCellSize.Checked)
            {
                txtFixSizeCD.Text = ch.GetFixCellSizeCD(cmbMapConfigName.SelectedItem.ToString()).ToString();
                txtFixSizeCD.Enabled = true;
                txtFixSizeMD.Text = ch.GetFixCellSizeMD(cmbMapConfigName.SelectedItem.ToString()).ToString();
                txtFixSizeMD.Enabled = true;
                txtCountSizeCD.Text = "";
                txtCountSizeCD.Enabled = false;
                txtCountSizeMD.Text = "";
                txtCountSizeMD.Enabled = false;
                lblSCMD.Text = ch.GetFixCellSizeSmybol(cmbMapConfigName.SelectedItem.ToString());
                lblSCCD.Text = ch.GetFixCellSizeSmybol(cmbMapConfigName.SelectedItem.ToString());
            }
            else if (rdoCountSize.Checked)
            {
                txtCountSizeCD.Text = ch.GetCountSizeCD(cmbMapConfigName.SelectedItem.ToString()).ToString();
                txtCountSizeCD.Enabled = true;
                txtCountSizeMD.Text = ch.GetCountSizeMD(cmbMapConfigName.SelectedItem.ToString()).ToString();
                txtCountSizeMD.Enabled = true;
                txtFixSizeCD.Text = "";
                txtFixSizeCD.Enabled = false;
                txtFixSizeMD.Text = "";
                txtFixSizeMD.Enabled = false;
            }
            else
            {
                TextBox[] txts = { txtFixSizeCD, txtFixSizeMD, txtCountSizeCD, txtCountSizeMD };
                foreach (TextBox txt in txts)
                {
                    txt.Enabled = false;
                    txt.Text = "";
                }
            }

            // Initialize cmbBottomAxes default selected
            cmbBottomAxes.SelectedItem = ch.GetBottomAxes(cmbMapConfigName.SelectedItem.ToString());

            // Initialize chkCDInverse, chkMDInverse
            chkCDInverse.Checked = ch.IsCdInver_X(cmbMapConfigName.SelectedItem.ToString());
            chkMDInverse.Checked = ch.IsMdInver_Y(cmbMapConfigName.SelectedItem.ToString());

            // Initialize cmbMapSize default. (x:y)
            int x = ch.GetMapProportion_X(cmbMapConfigName.SelectedItem.ToString());
            int y = ch.GetMapProportion_Y(cmbMapConfigName.SelectedItem.ToString());
            cmbMapSize.SelectedItem = String.Format("{0}:{1}", x, y);

        }

        private void rdoFixCellSize_CheckedChanged(object sender, EventArgs e)
        {
            ConfigHelper ch = new ConfigHelper();
            txtFixSizeCD.Text = ch.GetFixCellSizeCD(cmbMapConfigName.SelectedItem.ToString()).ToString();
            txtFixSizeCD.Enabled = true;
            txtFixSizeMD.Text = ch.GetFixCellSizeMD(cmbMapConfigName.SelectedItem.ToString()).ToString();
            txtFixSizeMD.Enabled = true;
            txtCountSizeCD.Text = "";
            txtCountSizeCD.Enabled = false;
            txtCountSizeMD.Text = "";
            txtCountSizeMD.Enabled = false;
            lblSCMD.Text = ch.GetFixCellSizeSmybol(cmbMapConfigName.SelectedItem.ToString());
            lblSCCD.Text = ch.GetFixCellSizeSmybol(cmbMapConfigName.SelectedItem.ToString());
        }

        private void rdoCountSize_CheckedChanged(object sender, EventArgs e)
        {
            ConfigHelper ch = new ConfigHelper();
            txtCountSizeCD.Text = ch.GetCountSizeCD(cmbMapConfigName.SelectedItem.ToString()).ToString();
            txtCountSizeCD.Enabled = true;
            txtCountSizeMD.Text = ch.GetCountSizeMD(cmbMapConfigName.SelectedItem.ToString()).ToString();
            txtCountSizeMD.Enabled = true;
            txtFixSizeCD.Text = "";
            txtFixSizeCD.Enabled = false;
            txtFixSizeMD.Text = "";
            txtFixSizeMD.Enabled = false;
        }

        private void cmbMapConfigName_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConfigHelper ch = new ConfigHelper();
            // Set nudImageColumns, nudImageRows value.
            nudImageColumns.Value = ch.GettlpFlawImagesColumns(cmbMapConfigName.SelectedItem.ToString());
            nudImageRows.Value = ch.GettlpFlawImagesRows(cmbMapConfigName.SelectedItem.ToString());

            // Set rdoMapGridOn,rdoMapGridOff
            rdoMapGridOn.Checked = ch.GetIsDisplayMapGrid(cmbMapConfigName.SelectedItem.ToString());
            rdoMapGridOff.Checked = !ch.GetIsDisplayMapGrid(cmbMapConfigName.SelectedItem.ToString());

            // Set rdoFixCellSize, rdoCountSize
            rdoFixCellSize.Checked = ch.GetIsFixCellSizeMode(cmbMapConfigName.SelectedItem.ToString());
            rdoCountSize.Checked = !ch.GetIsFixCellSizeMode(cmbMapConfigName.SelectedItem.ToString());

            if (rdoFixCellSize.Checked)
            {
                txtFixSizeCD.Text = ch.GetFixCellSizeCD(cmbMapConfigName.SelectedItem.ToString()).ToString();
                txtFixSizeCD.Enabled = true;
                txtFixSizeMD.Text = ch.GetFixCellSizeMD(cmbMapConfigName.SelectedItem.ToString()).ToString();
                txtFixSizeMD.Enabled = true;
                txtCountSizeCD.Text = "";
                txtCountSizeCD.Enabled = false;
                txtCountSizeMD.Text = "";
                txtCountSizeMD.Enabled = false;
                lblSCMD.Text = ch.GetFixCellSizeSmybol(cmbMapConfigName.SelectedItem.ToString());
                lblSCCD.Text = ch.GetFixCellSizeSmybol(cmbMapConfigName.SelectedItem.ToString());
            }
            else if (rdoCountSize.Checked)
            {
                txtCountSizeCD.Text = ch.GetCountSizeCD(cmbMapConfigName.SelectedItem.ToString()).ToString();
                txtCountSizeCD.Enabled = true;
                txtCountSizeMD.Text = ch.GetCountSizeMD(cmbMapConfigName.SelectedItem.ToString()).ToString();
                txtCountSizeMD.Enabled = true;
                txtFixSizeCD.Text = "";
                txtFixSizeCD.Enabled = false;
                txtFixSizeMD.Text = "";
                txtFixSizeMD.Enabled = false;
            }
            else
            {
                TextBox[] txts = { txtFixSizeCD, txtFixSizeMD, txtCountSizeCD, txtCountSizeMD };
                foreach (TextBox txt in txts)
                {
                    txt.Enabled = false;
                    txt.Text = "";
                }
            }

            // Set cmbBottomAxes default selected
            cmbBottomAxes.SelectedItem = ch.GetBottomAxes(cmbMapConfigName.SelectedItem.ToString());

            // Set chkCDInverse, chkMDInverse
            chkCDInverse.Checked = ch.IsCdInver_X(cmbMapConfigName.SelectedItem.ToString());
            chkMDInverse.Checked = ch.IsMdInver_Y(cmbMapConfigName.SelectedItem.ToString());

            // Set cmbMapSize default. (x:y)
            int x = ch.GetMapProportion_X(cmbMapConfigName.SelectedItem.ToString());
            int y = ch.GetMapProportion_Y(cmbMapConfigName.SelectedItem.ToString());
            cmbMapSize.SelectedItem = String.Format("{0}:{1}", x, y);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Save default config file to system config
            ConfigHelper ch = new ConfigHelper();
            if (String.IsNullOrEmpty(cmbMapConfigName.Text))
            {
                cmbMapConfigName.Text = DateTime.Now.ToShortDateString();
            }
            if (!ch.SaveMapSetupConfigFile(cmbMapConfigName.Text.Trim()))
            {
                return;
            }
            

            // initialize map xml sechma
            string sechma_path = PathHelper.SystemConfigFolder + "map_sechma.xml";
            XmlDocument document = new XmlDocument();
            document.Load(sechma_path);
            XPathNavigator navigator = document.CreateNavigator();

            // save image_grid_rows , image_grid_columns
            navigator.SelectSingleNode("//pxptab/image_grid_rows").SetValue(nudImageRows.Value.ToString());
            navigator.SelectSingleNode("//pxptab/image_grid_columns").SetValue(nudImageColumns.Value.ToString());

            // save map_proportion
            string[] proportion = cmbMapSize.SelectedItem.ToString().Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
            navigator.SelectSingleNode("//map_window/map_chart/map_proportion[@name='x']").SetValue(proportion[0]);
            navigator.SelectSingleNode("//map_window/map_chart/map_proportion[@name='y']").SetValue(proportion[1]);

            // save grid line display
            if (rdoMapGridOn.Checked)
            {
                navigator.SelectSingleNode("//map_window/map_chart/grid_line_display").SetValue("true");
            }
            else
            {
                navigator.SelectSingleNode("//map_window/map_chart/grid_line_display").SetValue("false");
            }

            // save grid line mode :Map 底格線間隔模式 0: FixSize , 1: EachCellCount
            if (rdoFixCellSize.Checked)
            {
                navigator.SelectSingleNode("//map_window/map_chart/grid_line_mode").SetValue("0");
                // save grid line value of mode
                double md = Double.TryParse(txtFixSizeMD.Text, out md) ? md : 1;
                double cd = Double.TryParse(txtFixSizeCD.Text, out cd) ? cd : 1;
                navigator.SelectSingleNode("//map_window/map_chart/grid_line_set/fix/md").SetValue(md.ToString());
                navigator.SelectSingleNode("//map_window/map_chart/grid_line_set/fix/cd").SetValue(cd.ToString());


            }
            else if (rdoCountSize.Checked)
            {
                navigator.SelectSingleNode("//map_window/map_chart/grid_line_mode").SetValue("1");
                // save grid line value of mode
                int md = Int32.TryParse(txtCountSizeMD.Text, out md) ? md : 2;
                int cd = Int32.TryParse(txtCountSizeCD.Text, out cd) ? cd : 2;
                navigator.SelectSingleNode("//map_window/map_chart/grid_line_set/count/md").SetValue(md.ToString());
                navigator.SelectSingleNode("//map_window/map_chart/grid_line_set/count/cd").SetValue(cd.ToString());
            }
            else
            {
                navigator.SelectSingleNode("//map_window/map_chart/grid_line_mode").SetValue("1");
                // save grid line value of mode
                int md = Int32.TryParse(txtCountSizeMD.Text, out md) ? md : 2;
                int cd = Int32.TryParse(txtCountSizeCD.Text, out cd) ? cd : 2;
                navigator.SelectSingleNode("//map_window/map_chart/grid_line_set/count/md").SetValue(md.ToString());
                navigator.SelectSingleNode("//map_window/map_chart/grid_line_set/count/cd").SetValue(cd.ToString());
            }
            
            // save bottom axes
            string bottom = cmbBottomAxes.SelectedItem.ToString().Trim();
            navigator.SelectSingleNode("//map_window/map_chart/bottom_axes").SetValue(bottom);

            // save md_inver
            if (chkMDInverse.Checked)
            {
                navigator.SelectSingleNode("//map_window/map_chart/md_inver").SetValue("true");
            }
            else
            {
                navigator.SelectSingleNode("//map_window/map_chart/md_inver").SetValue("false");
            }
            // save cd_inver
            if (chkCDInverse.Checked)
            {
                navigator.SelectSingleNode("//map_window/map_chart/cd_inver").SetValue("true");
            }
            else
            {
                navigator.SelectSingleNode("//map_window/map_chart/cd_inver").SetValue("false");
            }
            
            // save
            string map_path = PathHelper.MapConfigFolder + cmbMapConfigName.Text.Trim() + ".xml";
            try
            {
                document.Save(map_path);
                // Re binding cmbMapConfigName datasource
                List<string> mapConfigs = new List<string>();
                DirectoryInfo dirInfo = new DirectoryInfo(PathHelper.MapConfigFolder);
                FileInfo[] files = dirInfo.GetFiles("*.xml");
                foreach (FileInfo file in files)
                {
                    mapConfigs.Add(file.Name.ToString().Substring(0, file.Name.ToString().LastIndexOf(".")));
                }
                // Binding datasource for cmbMapConfigName and set default value.
                cmbMapConfigName.DataSource = mapConfigs;
                cmbMapConfigName.SelectedItem = ch.GetDefaultMapConfigName().Trim();
                MessageBox.Show("Success.");
            }
            catch
            {
                MessageBox.Show("Fail.");
            }
            
        }

        private void txtFixSizeMD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)46 || Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar)) 
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }

        }

        private void txtFixSizeCD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)46 || Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtCountSizeMD_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtCountSizeCD_KeyPress(object sender, KeyPressEventArgs e)
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

        private void Double_Validation(object sender, EventArgs e)
        {
            string pattern = @"[0-9]+(?:\.[0-9]*)?";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            TextBox txt = (TextBox)sender;
            if (!regex.IsMatch(txt.Text))
            {
                txt.Text = "";

            }
        }
       

    }
}
