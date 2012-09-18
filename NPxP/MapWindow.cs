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
using System.Xml;
using System.Xml.XPath;

//using DevExpress.XtraCharts;

namespace NPxP
{
    public partial class MapWindow : UserControl
    {
        #region Local Objects

        private List<FlawLegend> _legend;
        private DataTable _dtbFlaws, _dtbFlawLegends;
        private List<double> _cuts;
        #endregion

        public MapWindow(ref DataTable dtbFlaws)
        {
            WriteHelper.Log("MapWindow()");
            InitializeComponent();
            _dtbFlaws = dtbFlaws;
        }
        // Just for Initialize once not use at other.
        public void InitFlawLegendValue(List<FlawLegend> legned)
        {
            _legend = new List<FlawLegend>();
            _legend.AddRange(legned);
        }
        // Just for Initialize once 
        public void InitCutList(ref List<double> cuts)
        {
            _cuts = new List<double>();
            _cuts.AddRange(cuts);
        }
        public void InitFlawLegendGrid()
        {
            _dtbFlawLegends.Rows.Clear();
            // Add jobloaded records
            foreach (FlawLegend f in _legend)
            {
                DataRow dr = _dtbFlawLegends.NewRow();
                dr["Display"] = f.VisibleFlags;
                dr["FlawType"] = f.ClassID;
                dr["Name"] = f.Name;
                dr["Shape"] = "Cone";
                dr["Color"] = String.Format("#{0:X2}{1:X2}{2:X2}", ColorTranslator.FromWin32((int)f.Color).R,
                                                        ColorTranslator.FromWin32((int)f.Color).G,
                                                        ColorTranslator.FromWin32((int)f.Color).B);
                dr["PieceDoffNum"] = 0;
                dr["JobDoffNum"] = 0;
                _dtbFlawLegends.Rows.Add(dr);
            }

            // Deal Flaw Legends datasoure
            ConfigHelper ch = new ConfigHelper();

            string mapConfig = ch.GetDefaultMapConfigName().Trim();
            DataTable dtbLegendFromConfig = ch.GetDataTablePrevFlawLegend(mapConfig);

            foreach (DataRow d in dtbLegendFromConfig.Rows)
            {
                string expr = String.Format("FlawType={0} AND Name='{1}'", d["FlawType"].ToString().Trim(), d["Name"].ToString().Trim());
                DataRow[] drs = _dtbFlawLegends.Select(expr);
                if (drs.Length > 0)
                {
                    drs[0]["Shape"] = d["Shape"].ToString().Trim();
                    drs[0]["Color"] = d["Color"].ToString().Trim();
                }
            }

            // Save new record to xml
            string map_path = PathHelper.MapConfigFolder + mapConfig + ".xml";
            XmlDocument document = new XmlDocument();
            document.Load(map_path);
            XPathNavigator navigator = document.CreateNavigator();
            XPathNodeIterator node = navigator.Select("//map_window/flaw_legend");
            // remove old flawlegend for add records
            if (navigator.Select("//map_window/flaw_legend").Count > 0 && _dtbFlawLegends.Rows.Count > 0)
            {
                XPathNavigator first = navigator.SelectSingleNode("//map_window/flaw_legend[1]");
                XPathNavigator last = navigator.SelectSingleNode("//map_window/flaw_legend[last()]");
                navigator.MoveTo(first);
                navigator.DeleteRange(last);
            }
            // save _dtbFlawLegends to xml
            for (int i = 0; i < _dtbFlawLegends.Rows.Count; i++)
            {
                string flawType = _dtbFlawLegends.Rows[i]["FlawType"].ToString();
                string flawName = _dtbFlawLegends.Rows[i]["Name"].ToString();
                string shape = _dtbFlawLegends.Rows[i]["Shape"].ToString();
                string color = _dtbFlawLegends.Rows[i]["Color"].ToString();
                navigator.SelectSingleNode("//config/map_window").AppendChildElement(string.Empty, "flaw_legend", string.Empty, null);
                // Move to last column element and add name, start, end value.
                navigator.SelectSingleNode("//config/map_window/flaw_legend[last()]").AppendChildElement(string.Empty, "flaw_type", string.Empty, flawType);
                navigator.SelectSingleNode("//config/map_window/flaw_legend[last()]").AppendChildElement(string.Empty, "name", string.Empty, flawName);
                navigator.SelectSingleNode("//config/map_window/flaw_legend[last()]").AppendChildElement(string.Empty, "color", string.Empty, color);
                navigator.SelectSingleNode("//config/map_window/flaw_legend[last()]").AppendChildElement(string.Empty, "shape", string.Empty, shape);
            }
            try
            {
                document.Save(map_path);
            }
            catch
            {
                MessageBox.Show("Fail.");
            }
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
            if (_legend != null && _legend.Count > 0)
            {
                // Reload flawlegend
                _dtbFlawLegends.Rows.Clear();
                // Add jobloaded records
                foreach (FlawLegend f in _legend)
                {
                    DataRow dr = _dtbFlawLegends.NewRow();
                    dr["Display"] = f.VisibleFlags;
                    dr["FlawType"] = f.ClassID;
                    dr["Name"] = f.Name;
                    dr["Shape"] = "Cone";
                    dr["Color"] = String.Format("#{0:X2}{1:X2}{2:X2}", ColorTranslator.FromWin32((int)f.Color).R,
                                                            ColorTranslator.FromWin32((int)f.Color).G,
                                                            ColorTranslator.FromWin32((int)f.Color).B);
                    dr["PieceDoffNum"] = 0;
                    dr["JobDoffNum"] = 0;
                    _dtbFlawLegends.Rows.Add(dr);
                }
                // Deal Flaw Legends datasoure
                ConfigHelper ch = new ConfigHelper();

                string mapConfig = ch.GetDefaultMapConfigName().Trim();
                DataTable dtbLegendFromConfig = ch.GetDataTablePrevFlawLegend(mapConfig);

                foreach (DataRow d in dtbLegendFromConfig.Rows)
                {
                    string expr = String.Format("FlawType={0} AND Name='{1}'", d["FlawType"].ToString().Trim(), d["Name"].ToString().Trim());
                    DataRow[] drs = _dtbFlawLegends.Select(expr);
                    if (drs.Length > 0)
                    {
                        drs[0]["Shape"] = d["Shape"].ToString().Trim();
                        drs[0]["Color"] = d["Color"].ToString().Trim();
                    }
                }

                dgvFlawLegend.ClearSelection();
                dgvFlawLegendDetial.ClearSelection();
            }
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
           
            //
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
            Column shape = new Column(2, "Shape", 60);
            columns.Add(display);
            columns.Add(shape);
            foreach (Column c in columns)
            {
                if (c.Name == "Display")
                {
                    DataGridViewCell cell = new DataGridViewCheckBoxCell();
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
                else
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
                    column.ReadOnly = true;
                    dgvFlawLegend.Columns.Add(column);
                }
            }
            dgvFlawLegend.MultiSelect = false;
            dgvFlawLegend.AutoGenerateColumns = false;


            columns = new List<Column>();
            Column flawType = new Column(1, "FlawType", 60);
            Column name = new Column(1, "Name", 60);
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

            // set datasource to dgvdgvFlawLegend 
            // Initialize merge FlawLegend
            _dtbFlawLegends = new DataTable();
            _dtbFlawLegends.Columns.Add("Display", typeof(bool));
            _dtbFlawLegends.Columns.Add("FlawType", typeof(int));
            _dtbFlawLegends.Columns.Add("Name", typeof(string));
            _dtbFlawLegends.Columns.Add("Shape", typeof(string));
            _dtbFlawLegends.Columns.Add("Color", typeof(string));
            _dtbFlawLegends.Columns.Add("PieceDoffNum", typeof(int));
            _dtbFlawLegends.Columns.Add("JobDoffNum", typeof(string));
            
            dgvFlawLegend.DataSource = _dtbFlawLegends;
            dgvFlawLegendDetial.DataSource = _dtbFlawLegends;
           


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

        private void dgvFlawLegend_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                DataGridViewCell dgvc = sender as DataGridViewCell;

                string color = _dtbFlawLegends.Rows[e.RowIndex]["Color"].ToString();
                e.CellStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml(color);
                switch (e.Value.ToString())
                {
                    case "Triangle":
                        e.Value = "▲";
                        break;
                    case "Ellipse":
                        e.Value = "▼";
                        break;
                    case "Square":
                        e.Value = "■";
                        break;
                    case "Cone":
                        e.Value = "●";
                        break;
                    case "Cross":
                        e.Value = "✚";
                        break;
                    case "LineDiagonalCross":
                        e.Value = "✖";
                        break;
                    case "Star":
                        e.Value = "★";
                        break;
                }
            }
        }

        private void dgvFlawLegendDetial_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                DataGridViewCell dgvc = sender as DataGridViewCell;
                string color = _dtbFlawLegends.Rows[e.RowIndex]["Color"].ToString();
                e.CellStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml(color);
                switch (e.Value.ToString())
                {
                    case "Triangle":
                        e.Value = "▲";
                        break;
                    case "Ellipse":
                        e.Value = "▼";
                        break;
                    case "Square":
                        e.Value = "■";
                        break;
                    case "Cone":
                        e.Value = "●";
                        break;
                    case "Cross":
                        e.Value = "✚";
                        break;
                    case "LineDiagonalCross":
                        e.Value = "✖";
                        break;
                    case "Star":
                        e.Value = "★";
                        break;
                }
            }
        }

    }
}
