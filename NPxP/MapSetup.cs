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
            nudImageColumns.Value = ch.GettlpFlawImagesColumns();
            nudImageRows.Value = ch.GettlpFlawImagesRows();

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
            nudImageColumns.Value = ch.GettlpFlawImagesColumns();
            nudImageRows.Value = ch.GettlpFlawImagesRows();

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
    }
}
