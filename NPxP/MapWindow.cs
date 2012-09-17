using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NPxP.Helper;
using NPxP.Model;
using WRPlugIn;
using System.ComponentModel.Composition;
using System.IO;

//using DevExpress.XtraCharts;

namespace NPxP
{
    public partial class MapWindow : UserControl
    {
        #region Local Objects

        private List<FlawLegend> _legend;
        private DataTable _dtbFlaws;
        #endregion

        public MapWindow(ref DataTable dtbFlaws)
        {
            WriteHelper.Log("MapWindow()");
            InitializeComponent();
            _dtbFlaws = dtbFlaws;
        }

        public void SetFlawLegend(List<FlawLegend> legned)
        {
            _legend = legned;

        }
        public void InitJobInfo(IJobInfo jobInfo)
        {
            lblDateTimeValue.Text = DateTime.Now.ToShortDateString();
            lblOrderNumberValue.Text = jobInfo.OrderNumber;
            lblOperatorValue.Text = jobInfo.OperatorName;
            lblJobIdValue.Text = jobInfo.JobID;
            lblMeterialTypeValue.Text = jobInfo.MaterialType;
            // update on cut
            lblDoffValue.Text = "0"; // Job 段號 初始為0
            lblPassValue.Text = "0";
            lblFailValue.Text = "0";
            lblYieldValue.Text = "0%";
            
        }
        private void btnMapSetting_Click(object sender, EventArgs e)
        {
            MapSetup ms = new MapSetup();
            ms.ShowDialog();
        }

      

        #region R Method

        public void DrawChartPoint(DataRow[] flawRows, double cutMD)
        {
            //double topOfMaterial = cutMD - JobHelper.PxPInfo.Height;
            //Series flawPoint;
            //foreach (DataRow dr in flawRows)
            //{
            //    flawPoint = new Series(dr["FlawID"].ToString(), ViewType.Point);
            //    double cd = Convert.ToInt32(dr["CD"]);
            //    double md = Convert.ToInt32(dr["MD"]) - topOfMaterial;
            //    flawPoint.Points.Add(new SeriesPoint(cd, md));
            //    flawPoint.ArgumentScaleType = ScaleType.Numerical;
            //    flawPoint.ValueScaleType = ScaleType.Numerical;

            //    // Access the view-type-specific options of the series.
            //    PointSeriesView flawPointView = (PointSeriesView)flawPoint.View;
            //    flawPointView.PointMarkerOptions.Kind = MarkerKind.Circle;
            //    chartControl.Series.Add(flawPoint);
            //}
        }

        #endregion

        private void btnGradeSetting_Click(object sender, EventArgs e)
        {
            ConfigHelper ch = new ConfigHelper();
            GradeSetup gs = new GradeSetup();
            gs.ShowDialog();
            cmbGradeConfigFiles.SelectedItem = ch.GetDefaultGradeConfigName().Trim();
        }

        private void MapWindow_Load(object sender, EventArgs e)
        {
            ConfigHelper ch = new ConfigHelper();
            cmbFilterType.SelectedItem = ch.GetFilterType().Trim();
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
            cmbGradeConfigFiles.SelectedItem = ch.GetDefaultGradeConfigName().Trim();

            // Initialize dgvFlawLegend without data.
            List<Column> columns = new List<Column>();
            Column display = new Column(0, "Display", 60);
            Column name = new Column(1, "Name", 60);
            Column shape = new Column(2, "Shape", 60);
            columns.Add(display);
            columns.Add(name);
            columns.Add(shape);
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
                dgvFlawLegend.Columns.Add(column);
            }
            dgvFlawLegend.MultiSelect = false;
            dgvFlawLegend.AutoGenerateColumns = false;


            columns = new List<Column>();
            Column flawType = new Column(1, "FlawType", 60);
            name = new Column(1, "Name", 60);
            shape = new Column(2, "Shape", 60);
            Column pieceDoff = new Column(1, "PieceDoffNum", 60);
            Column jobDoff = new Column(1, "JobDoffNum", 60);
            columns.Add(flawType);
            columns.Add(name);
            columns.Add(shape);
            columns.Add(pieceDoff);
            columns.Add(jobDoff);
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
                dgvFlawLegendDetial.Columns.Add(column);
            }
            dgvFlawLegendDetial.MultiSelect = false;
            dgvFlawLegendDetial.AutoGenerateColumns = false;


        }

        private void cmbFilterType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // write data into xml right now.
            ConfigHelper ch = new ConfigHelper();
            ch.SaveFilterType(cmbFilterType.SelectedItem.ToString());


        }

        private void cmbGradeConfigFiles_DropDownClosed(object sender, EventArgs e)
        {
            ConfigHelper ch = new ConfigHelper();
            ch.SaveGradeSetupConfigFile(cmbGradeConfigFiles.Text.Trim());
        }
    }
}
