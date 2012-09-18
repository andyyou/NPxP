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
using DevExpress.XtraCharts;

namespace NPxP
{
    public partial class MapWindow : UserControl
    {
        #region Local Objects

        private DataTable _dtbFlaws, _dtbFlawLegends;
        private DataRow[] _drFlaw;
        private List<FlawLegend> _legend;
        private Dictionary<string, MarkerKind> _dicSeriesShape;
        private Dictionary<string, string> _dicLegendShape;

        #endregion

        public MapWindow(ref DataTable dtbFlaws)
        {
            WriteHelper.Log("MapWindow()");
            InitializeComponent();
            this._dtbFlaws = dtbFlaws;
            createShapeRefDic();
        }

        // Just for Initialize once not use at other.
        public void InitFlawLegendValue(List<FlawLegend> legned)
        {
            _legend = new List<FlawLegend>();
            _legend.AddRange(legned);
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
                dr["Shape"] = "Circle";
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
                    dr["Shape"] = "Circle";
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

        public void InitChart(double width,double height)
        {
            ConfigHelper ch = new ConfigHelper();
            string mapConfigFile = ch.GetDefaultMapConfigName();
            bool isDisplayGrid = ch.GetIsDisplayMapGrid(mapConfigFile);
            bool isCdInvert = ch.IsCdInver_X(mapConfigFile);
            bool isMdInvert = ch.IsMdInver_Y(mapConfigFile);
            bool isFixCellSize = ch.GetIsFixCellSizeMode(mapConfigFile);
            double fixCdSize = ch.GetFixCellSizeCD(mapConfigFile);
            double fixMdSize = ch.GetFixCellSizeMD(mapConfigFile);
            double countCdSize = ch.GetCountSizeCD(mapConfigFile);
            double countMdSize = ch.GetCountSizeMD(mapConfigFile);
            string bottomAxes = ch.GetBottomAxes(mapConfigFile);

            Series series = new Series();
            chartControl.RuntimeHitTesting = true;
            chartControl.Legend.Visible = false;
            chartControl.Series.Add(series);

            XYDiagram diagram = (XYDiagram)chartControl.Diagram;
            // Setting AxisX format
            diagram.EnableAxisXZooming = true;
            diagram.AxisX.Range.MinValue = 0;
            diagram.AxisX.Range.MaxValue = width;
            diagram.AxisX.Range.ScrollingRange.SetMinMaxValues(0, width);
            diagram.AxisX.NumericOptions.Format = NumericFormat.Number;
            diagram.AxisX.NumericOptions.Precision = 6;
            diagram.AxisX.Reverse = isCdInvert;
            diagram.AxisX.GridLines.Visible = isDisplayGrid;
            diagram.AxisX.GridLines.LineStyle.DashStyle = DashStyle.Dash;
            diagram.AxisX.GridSpacingAuto = false;

            // Setting AxisY format
            diagram.EnableAxisYZooming = true;
            diagram.AxisY.Range.MinValue = 0;
            diagram.AxisY.Range.MaxValue = height;
            diagram.AxisY.Range.ScrollingRange.SetMinMaxValues(0, height);
            diagram.AxisY.NumericOptions.Format = NumericFormat.Number;
            diagram.AxisY.NumericOptions.Precision = 6;
            diagram.AxisY.Reverse = isMdInvert;
            diagram.AxisY.GridLines.Visible = isDisplayGrid;
            diagram.AxisY.GridLines.LineStyle.DashStyle = DashStyle.Dash;
            diagram.AxisY.GridSpacingAuto = false;

            // Setting chart cell size
            if (isFixCellSize) // Specify cell size
            {
                diagram.AxisX.GridSpacing = fixCdSize;
                diagram.AxisY.GridSpacing = fixMdSize;
            }
            else // Equal cell count
            {
                diagram.AxisX.GridSpacing = width / countCdSize;
                diagram.AxisY.GridSpacing = height / countMdSize;
            }

            // Setting Axes position
            if (isCdInvert)
            {
                if (isMdInvert)
                {
                    diagram.AxisX.Alignment = AxisAlignment.Far;
                    diagram.AxisY.Alignment = AxisAlignment.Far;
                }
                else
                {
                    diagram.AxisX.Alignment = AxisAlignment.Near;
                    diagram.AxisY.Alignment = AxisAlignment.Far;
                }
            }
            else
            {
                if (isMdInvert)
                {
                    diagram.AxisX.Alignment = AxisAlignment.Far;
                    diagram.AxisY.Alignment = AxisAlignment.Near;
                }
                else
                {
                    diagram.AxisX.Alignment = AxisAlignment.Near;
                    diagram.AxisY.Alignment = AxisAlignment.Near;
                }
            }

            // Rotate chart when bottom axes is MD
            if (bottomAxes == "CD")
            {
                diagram.Rotated = false;
            }
            else
            {
                diagram.Rotated = true;
            }
            DrawSubPiece();
        }

        private void DrawSubPiece()
        {
            ConfigHelper ch = new ConfigHelper();
            string gradeConfigFile = ch.GetDefaultGradeConfigName();
            DataTable gradeColumn = ch.GetDataTableOfdgvColumns(gradeConfigFile);
            DataTable gradeRow = ch.GetDataTableOfdgvRows(gradeConfigFile);

            foreach (DataRow drCol in gradeColumn.Rows)
            {
                foreach (DataRow drRow in gradeRow.Rows)
                {
                    // Add rangearea
                    string rangeName = String.Format("{0}{1}", drCol["Name"], drRow["Name"]);
                    Series range = new Series(rangeName, ViewType.RangeArea);
                    range.ShowInLegend = false;
                    range.CrosshairEnabled = DevExpress.Utils.DefaultBoolean.False;
                    range.ArgumentScaleType = ScaleType.Numerical;

                    range.Points.Add(new SeriesPoint(drCol["Start"], drRow["Start"], drRow["End"]));
                    range.Points.Add(new SeriesPoint(drCol["End"], drRow["Start"], drRow["End"]));

                    RangeAreaSeriesView view = (RangeAreaSeriesView)range.View;
                    view.Color = Color.Red;
                    view.Transparency = 230;
                    view.Marker1.Visible = false;
                    view.Marker2.Visible = false;
                    view.Border1.Color = Color.Transparent;
                    view.Border2.Color = Color.Transparent;

                    chartControl.Series.Add(range);

                    // Add annotation
                    TextAnnotation annotation = new TextAnnotation();
                    PaneAnchorPoint paPoint = new PaneAnchorPoint();
                    RelativePosition relPosition = new RelativePosition();

                    annotation.LabelMode = true;
                    annotation.BackColor = System.Drawing.Color.Transparent;
                    annotation.Border.Visible = false;
                    annotation.ConnectorStyle = AnnotationConnectorStyle.None;
                    annotation.Font = new System.Drawing.Font("Tahoma", 8F, FontStyle.Bold);
                    annotation.TextColor = Color.Blue;
                    annotation.Name = rangeName;
                    annotation.Text = rangeName;
                    string annotationX = Convert.ToString(Convert.ToDouble(drCol["Start"]) + (Convert.ToDouble(drCol["End"]) - Convert.ToDouble(drCol["Start"])) * 0.1);
                    string annotationY = Convert.ToString(Convert.ToDouble(drRow["End"]) - (Convert.ToDouble(drRow["End"]) - Convert.ToDouble(drRow["Start"])) * 0.1);
                    paPoint.AxisXCoordinate.AxisValueSerializable = annotationX;
                    paPoint.AxisYCoordinate.AxisValueSerializable = annotationY;
                    annotation.AnchorPoint = paPoint;
                    relPosition.Angle = 0;
                    relPosition.ConnectorLength = 0;
                    annotation.ShapePosition = relPosition;
                    chartControl.AnnotationRepository.AddRange(new Annotation[] { annotation });
                }
            }
        }

        public void DrawChartPoint(DataRow[] flawRows, double cutMD)
        {
            this._drFlaw = flawRows;
            chartControl.Series.Clear();
            DrawSubPiece();

            double topOfPart = cutMD - JobHelper.PxPInfo.Height;
            Series flawPoint;
            foreach (DataRow dr in _drFlaw)
            {
                flawPoint = new Series(dr["FlawID"].ToString(), ViewType.Point);
                double cd = Convert.ToDouble(dr["CD"]);
                double md = Convert.ToDouble(dr["MD"]) - topOfPart;
                string flawClass = dr["FlawClass"].ToString();

                string filterExp = String.Format("Name = '{0}'", flawClass);
                DataRow[] rows = _dtbFlawLegends.Select(filterExp);

                flawPoint.LegendText = flawClass;
                flawPoint.Points.Add(new SeriesPoint(cd, md));
                flawPoint.ArgumentScaleType = ScaleType.Numerical;
                flawPoint.ValueScaleType = ScaleType.Numerical;
                flawPoint.CrosshairEnabled = DevExpress.Utils.DefaultBoolean.False;
                flawPoint.Label.PointOptions.PointView = PointView.SeriesName;
                flawPoint.Visible = Convert.ToBoolean(rows.First()["Display"]);

                // Access the view-type-specific options of the series.
                PointSeriesView flawPointView = (PointSeriesView)flawPoint.View;
                flawPointView.PointMarkerOptions.Kind = _dicSeriesShape[rows.First()["Shape"].ToString()];
                flawPointView.Color = System.Drawing.ColorTranslator.FromHtml(rows.First()["Color"].ToString());
                
                chartControl.Series.Add(flawPoint);
            }
        }

        #endregion

        private void chartControl_BoundDataChanged(object sender, EventArgs e)
        {
            foreach (Series series in this.chartControl.Series)
            {
                series.PointOptions.ValueNumericOptions.Format = NumericFormat.Number;
                series.PointOptions.ValueNumericOptions.Precision = 6;
            }
        }

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

        private void chartControl_MouseMove(object sender, MouseEventArgs e)
        {
            ChartHitInfo hi = chartControl.CalcHitInfo(e.X, e.Y);

            if (hi.SeriesPoint != null && hi.Series != null)
            {
                //MessageBox.Show(hi.Series.LegendText.ToString());
                hi.Series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                hi.Series.View.Color = System.Drawing.ColorTranslator.FromHtml("#fff698");
            }
            else
            {
                foreach (Series s in chartControl.Series)
                {
                    if (!(s.View is RangeAreaSeriesView))
                    {
                        s.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
                        
                        string filterExp = String.Format("Name = '{0}'", s.LegendText);
                        DataRow[] rows = _dtbFlawLegends.Select(filterExp);
                        s.View.Color = System.Drawing.ColorTranslator.FromHtml(rows.First()["Color"].ToString());
                    }
                }
            }
        }

        private void chartControl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ChartHitInfo hi = chartControl.CalcHitInfo(e.X, e.Y);

                if (hi.SeriesPoint != null)
                {
                    Series seriesPoint = (Series)hi.Series;
                    IEnumerable<DataRow> result = _drFlaw.Where(row => row["FlawID"].ToString().Equals(seriesPoint.Name));
                    
                    JobHelper.Job.SetOffline();
                    FlawForm ff = new FlawForm(result.First());
                    ff.ShowDialog();
                }
            }
        }

        private void dgvFlawLegend_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                DataGridViewCell dgvc = sender as DataGridViewCell;

                string color = _dtbFlawLegends.Rows[e.RowIndex]["Color"].ToString();
                e.CellStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml(color);
                e.Value = _dicLegendShape[e.Value.ToString()]; // e.g. Triangle -> ▲
            }
        }

        private void dgvFlawLegendDetial_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                DataGridViewCell dgvc = sender as DataGridViewCell;
                string color = _dtbFlawLegends.Rows[e.RowIndex]["Color"].ToString();
                e.CellStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml(color);
                e.Value = _dicLegendShape[e.Value.ToString()]; // e.g. Triangle -> ▲
            }
        }

        private void btnPrevPiece_Click(object sender, EventArgs e)
        {
            JobHelper.Job.SetOffline();
        }

        private void btnNextPiece_Click(object sender, EventArgs e)
        {
            JobHelper.Job.SetOffline();
        }

        private void createShapeRefDic()
        {
            _dicSeriesShape = new Dictionary<string, MarkerKind>();
            this._dicSeriesShape.Add("Triangle", MarkerKind.Triangle);
            this._dicSeriesShape.Add("InvertedTriangle", MarkerKind.InvertedTriangle);
            this._dicSeriesShape.Add("Square", MarkerKind.Square);
            this._dicSeriesShape.Add("Circle", MarkerKind.Circle);
            this._dicSeriesShape.Add("Plus", MarkerKind.Plus);
            this._dicSeriesShape.Add("Cross", MarkerKind.Cross);
            this._dicSeriesShape.Add("Star", MarkerKind.Star);

            _dicLegendShape = new Dictionary<string, string>();
            this._dicLegendShape.Add("Triangle", "▲");
            this._dicLegendShape.Add("InvertedTriangle", "▼");
            this._dicLegendShape.Add("Square", "■");
            this._dicLegendShape.Add("Circle", "●");
            this._dicLegendShape.Add("Plus", "✚");
            this._dicLegendShape.Add("Cross", "✖");
            this._dicLegendShape.Add("Star", "★");
        }
    }
}
