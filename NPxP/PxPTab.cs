﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WRPlugIn;
using System.ComponentModel.Composition;
using NPxP.Helper;
using NPxP.Model;
using System.Xml;
using System.Xml.XPath;
using System.Reflection;
using System.Data.SqlClient;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.IO;

namespace NPxP
{
    [Export(typeof(IWRPlugIn))]
    public partial class PxPTab : UserControl, IWRPlugIn, IWRMapWindow, IOnFlaws, IOnEvents, IOnCut, IOnJobLoaded,
                                  IOnJobStarted, IOnLanguageChanged, IOnJobStopped, IOnWebDBConnected, 
                                  IOnOnline, IOnUserTermsChanged, IOnDoffResult, IOnPxPConfig,IOnClassifyFlaw,
                                  IOnRollResult, IOnOpenHistory, 
                                  IOnUnitsChanged
    {
        #region Local Variables

        private MapWindow _mp;
        private DataTable _dtbFlaws;
        private List<NowUnit> _units;
        private List<double> _cuts;
        private string _xmlUnitsPath;

        private int _nowPage, _totalPage; // For TableLayout pages , start from 1.

        #endregion

        //-------------------------------------------------------------------------------------------//
        
        #region Import Objects

        [Import(typeof(IWRMessageLog))]
        IWRMessageLog MsgLog; // Log 物件

        [Import(typeof(IWRJob))]
        public IWRJob Job; // Job 物件: 啟動, 停止, 回復工單, Margin ROI 等... 
        
        [Import(typeof(IWRFireEvent))]
        IWRFireEvent Fire; // Fire 物件: 回傳 Event 給 CCD

        #endregion

        //-------------------------------------------------------------------------------------------//

        #region Interface Method

        // (1)
        public PxPTab()
        {
            // WriteHelper.Log("PxPTab()");
            InitializeComponent();
            // initialize dgvFlaw without datasource.
            ConfigHelper ch = new ConfigHelper();
            List<Column> lstColumns = ch.GetdgvFlawColumns();
            foreach (Column c in lstColumns)
            {
                DataGridViewCell cell = new DataGridViewTextBoxCell();
                DataGridViewColumn column = new DataGridViewColumn();
                column.CellTemplate = cell;
                column.Name = c.Name;
                column.HeaderText = c.Name;  // if want to use switch lang edit here.
                column.Width = c.Width;
                column.DataPropertyName = c.Name;
                column.SortMode = DataGridViewColumnSortMode.Automatic;
                dgvFlaw.Columns.Add(column);
            }
            dgvFlaw.MultiSelect = false;
            dgvFlaw.AutoGenerateColumns = false;
           
            // initialize tlpFlawImages layout without pictures.
            SetDoubleBuffered(tlpFlawImages); // start double buffer for impore effect.
            tlpFlawImages.ColumnStyles.Clear();
            tlpFlawImages.ColumnCount = ch.GettlpFlawImagesColumns();
            tlpFlawImages.RowCount = ch.GettlpFlawImagesRows();
            int phdHeight = tlpFlawImages.Height / tlpFlawImages.RowCount;
            int phdrWidth = tlpFlawImages.Width / tlpFlawImages.ColumnCount;
            for (int i = 0; i < tlpFlawImages.RowCount; i++)
            {
                tlpFlawImages.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
            }

            for (int i = 0; i < tlpFlawImages.ColumnCount; i++)
            {
                tlpFlawImages.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            }
        }

        // (End)
        ~PxPTab()
        {
            ConfigHelper ch = new ConfigHelper();
            ch.SavedgvFlawColumns(dgvFlaw);
            if (dgvFlaw.SortedColumn != null && !String.IsNullOrEmpty(dgvFlaw.SortedColumn.Name))
            {
                ch.SavedgvFlawOrderByColumn(dgvFlaw.SortedColumn.Name);
            }
        }
        
        // (2)
        public void OnLanguageChanged(e_Language language)
        {
            // WriteHelper.Log("OnLanguageChanged()");
        }

        // (3)(8)
        public void Initialize(string unitsXMLPath)
        {
            // WriteHelper.Log("Initialize()");
            _xmlUnitsPath = unitsXMLPath;
            LoadXmlToUnitsObject(unitsXMLPath); // Save units value to "_units"
            JobHelper.Job = Job;  // 設定 Helper 協助各頁面停止工單等操作
        }

        // (4)(7)(17)
        public void GetName(e_Language lang, out string name)
        {
            // WriteHelper.Log("GetName()");
            switch (lang)
            {
                case e_Language.Chinese:
                    name = "片狀檢查";
                    break;
                default:
                    name = "PxP";
                    break;
            }
        }

        // (5)
        public void GetControlHandle(out IntPtr hndl)
        {
            // WriteHelper.Log("GetControlHandle()");
            hndl = Handle;
        }

        // (6)
        public void SetPosition(int w, int h)
        {
            // WriteHelper.Log("SetPosition()");
            SetBounds(0, 0, w, h);
        }

        // (9) :回傳外掛設計的 MapWindow 給主程式
        public void GetMapControlHandle(out IntPtr hndl)
        {
            // WriteHelper.Log("GetMapControlHandle()");
            _mp = new MapWindow(this); // 確保執行順序正確,所以在這邊在 new 物件, this 把 PxPTab 傳過去給 MapWindow
            hndl = _mp.Handle;
            _mp.InitTableLayout(ref tlpFlawImages); // 為了讓右邊可以即時更新左邊圖片.把參考加給右邊.
        }

        // (10) :設定 MapWindow Position with Job object.
        public void SetMapPosition(int w, int h)
        {
            // WriteHelper.Log("SetMapPosition()");
            _mp.SetBounds(0, 0, w, h);
        }

        // (11)
        public void OnWebDBConnected(IWebDBConnectionInfo info)
        {
            // WriteHelper.Log("OnWebDBConnected()");
            JobHelper.DbConnectString = String.Format("Data Source={0};Initial Catalog={1};User Id={2};Password={3};", info.ServerName, info.DatabaseName, info.UserName, info.Password);
        }

        // (12)
        public void OnUserTermsChanged(IUserTerms terms)
        {
            // WriteHelper.Log("OnUserTermsChanged()");
        }

        // (13)
        public void OnSetFlawLegend(List<FlawLegend> legend)
        {
            // WriteHelper.Log("OnSetFlawLegend()");
            _mp.InitFlawLegendValue(legend);  // 把 MapWindow 需要的"圖例"資料傳過去
        }

        // (14)
        public void OnInitializeGlassEdges(int glassLeftMarginToROI, int glassRightMarginToROI)
        {
            // WriteHelper.Log("OnInitializeGlassEdges()");
        }

        // (15)
        public void OnPxPConfig(IPxPInfo info)
        {
            // WriteHelper.Log("OnPxPConfig()");
            JobHelper.PxPInfo = info;
            
        }

        // (16)
        public void OnJobLoaded(IList<IFlawTypeName> flawTypes, IList<ILaneInfo> lanes, IList<ISeverityInfo> severityInfo, IJobInfo jobInfo)
        {
            // WriteHelper.Log("OnJobLoaded()");
            // Reset to default.
            _cuts = new List<double>();
            lblNowPage.Text = "---";
            lblTotalPage.Text = "---";
            btnNextFlawImages.Enabled = false;
            btnPrevFlawImages.Enabled = false;
            btnShowGoPage.Enabled = false;
            _nowPage = 0;
            _totalPage = 0;

            // save datas in global helper.
            JobHelper.FlawTypes = flawTypes;
            JobHelper.JobInfo = jobInfo;
            JobHelper.Lanes = lanes;
            JobHelper.SeverityInfo = severityInfo;

            //update dgvFlaw HeaderText + (Unit)  ** 2012/11/05 if want to use switch lang edit here.
            RefreshdtbFlawsUnit();
            
            // initialize datatable  flaw format without data.
            _dtbFlaws = new DataTable("Flaws");
           
            _dtbFlaws.Columns.Add("FlawID", typeof(int));
            _dtbFlaws.Columns.Add("CD", typeof(double));
            _dtbFlaws.Columns.Add("MD", typeof(double));
            _dtbFlaws.Columns.Add("Area", typeof(string));
            _dtbFlaws.Columns.Add("FlawClass", typeof(string));
            _dtbFlaws.Columns.Add("FlawType", typeof(int));
            _dtbFlaws.Columns.Add("Images", typeof(IList<IImageInfo>));
            _dtbFlaws.Columns.Add("LeftEdge", typeof(double));
            _dtbFlaws.Columns.Add("RightEdge", typeof(double));
            _dtbFlaws.Columns.Add("Length", typeof(double));
            _dtbFlaws.Columns.Add("Width", typeof(double));
            _dtbFlaws.Columns.Add("Roll", typeof(int));
            _dtbFlaws.Columns.Add("RollMD", typeof(double));
            _dtbFlaws.Columns.Add("RightRollCD", typeof(double));
            _dtbFlaws.Columns.Add("LeftRollCD", typeof(double));
            _dtbFlaws.Columns.Add("DateTime", typeof(DateTime));
           
            // other columns for deal grade and score.
            _dtbFlaws.Columns.Add("Priority", typeof(int));
            
            // sort by default column
            ConfigHelper ch = new ConfigHelper();
            _dtbFlaws.DefaultView.Sort = String.Format("{0} ASC", ch.GetSortByColumnName().Trim());
            
            // set dgvFlaws datasource 
            dgvFlaw.DataSource = _dtbFlaws;

            // Refresh TableLayoutPanel
            tlpFlawImages.Controls.Clear();
            tlpFlawImages.ColumnStyles.Clear();
            tlpFlawImages.ColumnCount = ch.GettlpFlawImagesColumns();
            tlpFlawImages.RowCount = ch.GettlpFlawImagesRows();
            int phdHeight = tlpFlawImages.Height / tlpFlawImages.RowCount;
            int phdrWidth = tlpFlawImages.Width / tlpFlawImages.ColumnCount;
            for (int i = 0; i < tlpFlawImages.RowCount; i++)
            {
                tlpFlawImages.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
            }

            for (int i = 0; i < tlpFlawImages.ColumnCount; i++)
            {
                tlpFlawImages.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            }

            // For MapWindow.cs
            //---------------------------------------------------------------------------

            // Setting MapWindow
            _mp.InitJobInfo(jobInfo);
            _mp.InitFlawLegendGrid();
            _mp.InitDatatableFlaws(ref _dtbFlaws);
            _mp.InitUnits(ref _units);
            _mp.InitCutList(ref _cuts);

            // ref Fire object
            _mp.InitFire(ref Fire);

            // Initial Flaw Chart FlawLegend
            _mp.InitChart();
        }

        // (18) :執行每一個步驟都會檢查
        public void OnOnline(bool isOnline)
        {
            // WriteHelper.Log("OnOnline()");
            JobHelper.IsOnline = isOnline;
            JobHelper.IsOpenHistory = false;
        }

        // (19)
        public void OnJobStarted(int jobKey)
        {
            JobHelper.JobKey = jobKey;
            // WriteHelper.Log("OnJobStarted()");
            JobHelper.JobKey = jobKey;
            _mp.SettingUIControlStatus(false);
            _mp.ReloadDataTables();
            if (JobHelper.IsOpenHistory)
            {
                #region 說明
                /*
                 * 讀取history時要讀取database中的dbo.Jobs.PxPInfo欄位
                 * 流程:  透過DataHelper.ReadDatabaseToObject() 先把資料庫中的xml轉存為各目錄下的 default.database
                 *        再用ConfigHelper去讀取default.database 
                 */
                #endregion
                // Prepare database dbo.Jobs.PxPInfo => local *.database files
                DataHelper dh = new DataHelper();
                dh.ReadDatabaseToObject();
            }
            
            

        }

        // (20) :設定幾個 Events 就會觸發幾次
        public void OnEvents(IList<IEventInfo> events)
        {
            // WriteHelper.Log("OnEvents()");
            foreach (IEventInfo eventInfo in events)
            {
                switch ((e_EventID)eventInfo.EventType)
                {
                    case e_EventID.STOP_JOB:
                        break;

                    case e_EventID.STOP_INSPECTION:
                        break;

                    case e_EventID.START_INSPECTION:
                        break;

                    case e_EventID.CUT_SIGNAL:
                        //WriteHelper.Log("CutEvent(): " + eventInfo.MD);

                        NowUnit unitFlawMapCD = _units.Find(x => x.ComponentName == "Flaw Map CD");
                        double cdOffset = JobHelper.PxPInfo.LeftOffset / unitFlawMapCD.Conversion;
                      
                        _cuts.Add(eventInfo.MD);

                        double topOfPart = eventInfo.MD - JobHelper.PxPInfo.Height;
                        DataHelper dh = new DataHelper();               
                        //if (JobHelper.IsOnline || (JobHelper.IsOpenHistory && _cuts.Count == 1))
                        if (JobHelper.IsOnline || JobHelper.IsOpenHistory)
                        {
                            dh.GetFlawDataFromDb(ref _dtbFlaws, cdOffset, topOfPart, eventInfo.MD);
                            _mp.CalcEntirePieceResult();
                        }
                        if (!JobHelper.IsOnline && !JobHelper.IsOpenHistory)
                        {
                            DataTable dtbFlaws = _dtbFlaws;
                            dtbFlaws.Clear();
                            dh.GetFlawDataFromDb(ref dtbFlaws, cdOffset, topOfPart, eventInfo.MD);
                            _mp.CalcEntirePieceResult(dtbFlaws);
                        }
                        if (JobHelper.IsOnline || (JobHelper.IsOpenHistory && _cuts.Count == 1))
                        {
                            // Create flaw image controls
                            CreateFlawImageControl();
                            // Update MapWindow
                            _mp.DrawChartPoint();
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        // (D) :資料流入
        public void OnFlaws(IList<IFlawInfo> flaws)
        {
            //WriteHelper.Log("OnFlaws()");
        }

        // (D)
        public void OnCut(double md)
        {
            // WriteHelper.Log("Ture OnCut()");
            GC.Collect();
        }

        // (D) :處理缺陷判斷
        public void OnDoffResult(double md, int doffNumber, bool pass)
        {
            // WriteHelper.Log("OnDoffResult()");
        }

        // (D) :單位變更
        public void OnUnitsChanged()
        {
            // WriteHelper.Log("OnUnitsChanged()");
            if (!String.IsNullOrEmpty(_xmlUnitsPath))
            {
                LoadXmlToUnitsObject(_xmlUnitsPath);
            }
            // update dgvFlaw HeaderText + (Unit)
            RefreshdtbFlawsUnit();
        }

        // (D) 
        public void OnRollResult(double cd, double md, int doffNumber, int laneNumber, bool pass)
        {
            // WriteHelper.Log("OnRollResult()");
        }

        // (D) :開啟歷史資料
        public void OnOpenHistory(double startMD, double stopMD)
        {
            

            // WriteHelper.Log("OnOpenHistory()");
            JobHelper.IsOpenHistory = true;
            
            
        }

        // (25) :停止工單
        public void OnJobStopped(double md)
        {
            // WriteHelper.Log("OnJobStopped()");
            if (JobHelper.IsOpenHistory)
            {
                string mdRange = "(";

                if (_cuts.Count != 0)
                {
                    foreach (double bottomOfPart in _cuts)
                    {
                        double topOfPart = bottomOfPart - JobHelper.PxPInfo.Height;
                        mdRange = string.Format("{0}(T2.dMD > {1} AND T2.dMD < {2})", mdRange, topOfPart, bottomOfPart);

                        if (bottomOfPart != _cuts.Last())
                        {
                            mdRange += " OR ";
                        }
                    }
                }
                else
                {
                    MessageBox.Show("This job is not Piece by Piece, Can't use this plugin!");
                    return;
                   
                }

                mdRange += ")";

                var jobDoffNum = _mp._jobDoffNum;
                DataHelper dh = new DataHelper();
                dh.GetEachFlawQuantity(ref jobDoffNum, mdRange);
                _mp.UpdatePagesCount();
                _mp.JumpToSpecificPiece(1);
            }
            else
            {
                // apend xml to database
                DataHelper dh = new DataHelper();
                if (dh.AppendXmlToJobsPxPInfo())
                {
                    //
                }
                else
                {
                    MessageBox.Show("Notice : config not saved in database");
                }

            }
            JobHelper.IsOpenHistory = false;
            _mp.SettingUIControlStatus(true);
        }

        // (End -1)
        public void Unplug()
        {
            // WriteHelper.Log("Unplug()");
        }

        // (?) :
        public void OnClassifyFlaw(ref IFlawInfo flaw, ref bool deleteFlaw)
        {
            // WriteHelper.Log("OnClassifyFlaw()");
        }
        
        #endregion

        //-------------------------------------------------------------------------------------------//

        #region R Method

        // 將xml單位換算值儲存至 _units 物件
        public void LoadXmlToUnitsObject(string xml)
        {
            _units = new List<NowUnit>();
            // load xml data to dictionary.
            XmlDocument document = new XmlDocument();
            document.Load(xml);
            XPathNavigator navigator = document.CreateNavigator();
            XPathNodeIterator node = navigator.Select("//Components/Component");

            while (node.MoveNext())
            {
                int unitIndex = Convert.ToInt32(node.Current.SelectSingleNode("@unit").Value) + 1; // Xpath's index start from 1.
                string expr_conversion = String.Format("//Units/Unit[{0}]/@conversion", unitIndex);
                string expr_symbol = String.Format("//Units/Unit[{0}]/@symbol", unitIndex);
                double convertion = Convert.ToDouble(navigator.SelectSingleNode(expr_conversion).Value);
                string symbol = navigator.SelectSingleNode(expr_symbol).Value;
                string componentName = node.Current.SelectSingleNode("@name").Value;
                NowUnit unit = new NowUnit(componentName, symbol, convertion);
                _units.Add(unit);
            }
        }

        // 啟動次要緩衝
        public static void SetDoubleBuffered(Control control)
        {
            // set instance non-public property with name "DoubleBuffered" to true
            typeof(Control).InvokeMember("DoubleBuffered",
                BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                null, control, new object[] { true });
        }

        // 設定 TableLayoutPanel without data just initialize.  
        public void LoadXmlTotlpImages()
        {
            ConfigHelper ch = new ConfigHelper();
            tlpFlawImages.ColumnStyles.Clear();
            tlpFlawImages.ColumnCount = ch.GettlpFlawImagesColumns();
            tlpFlawImages.RowCount = ch.GettlpFlawImagesRows();
            int phdHeight = tlpFlawImages.Height / tlpFlawImages.RowCount;
            int phdrWidth = tlpFlawImages.Width / tlpFlawImages.ColumnCount;
            for (int i = 0; i < tlpFlawImages.RowCount; i++)
            {
                tlpFlawImages.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
            }

            for (int i = 0; i < tlpFlawImages.ColumnCount; i++)
            {
                tlpFlawImages.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            }
        }

        // 更新 tlpImages 內部 Controls , 更新 lblNowPage
        public void RefreshtlpImagesControls(int nowPage)
        {
            _nowPage = nowPage;
            // Clear  TableLayout of FlawImages's controls
            tlpFlawImages.Controls.Clear();
            // Calculate about init.
            int holderWidth = tlpFlawImages.Width / tlpFlawImages.ColumnCount;
            int holderHeight = tlpFlawImages.Height / tlpFlawImages.RowCount;
            int pageSize = tlpFlawImages.ColumnCount * tlpFlawImages.RowCount;
            lblNowPage.Text = nowPage.ToString();
            // Get flaw rows
            DataRow[] rows = _dtbFlaws.Select();

            int startFicIndex = (nowPage - 1) * pageSize;
            int endFicIndex = ((startFicIndex + pageSize) > _dtbFlaws.DefaultView.Count) ? _dtbFlaws.DefaultView.Count : (startFicIndex + pageSize);
            // Add FlawImageControl in tableLayout.
            for (int i = startFicIndex; i < endFicIndex; i++)
            {
                FlawImageControl fi = new FlawImageControl(rows[i], ref _units, ref _mp);
                SetDoubleBuffered(fi);
                fi.Width = holderWidth;
                fi.Height = holderHeight;
                fi.Dock = DockStyle.Fill;
                tlpFlawImages.Controls.Add(fi);
            }
        }

        // 更新 tlpImages 內部 Controls , 更新 lblNowPage , 指定畫邊框 ID
        public void RefreshtlpImagesControls(int nowPage, int paintRowID)
        {
            _nowPage = nowPage;
            // Clear  TableLayout of FlawImages's controls
            tlpFlawImages.Controls.Clear();
            // Calculate about init.
            int holderWidth = tlpFlawImages.Width / tlpFlawImages.ColumnCount;
            int holderHeight = tlpFlawImages.Height / tlpFlawImages.RowCount;
            int pageSize = tlpFlawImages.ColumnCount * tlpFlawImages.RowCount;
            lblNowPage.Text = nowPage.ToString();
            // Get flaw rows
            DataRow[] rows = _dtbFlaws.Select();

            int startFicIndex = (nowPage - 1) * pageSize;
            int endFicIndex = ((startFicIndex + pageSize) > _dtbFlaws.DefaultView.Count) ? _dtbFlaws.DefaultView.Count : (startFicIndex + pageSize);
            // Add FlawImageControl in tableLayout.
            for (int i = startFicIndex; i < endFicIndex; i++)
            {

                FlawImageControl fi = new FlawImageControl(rows[i], ref _units, ref _mp);
                SetDoubleBuffered(fi);
                // set draw border
                if(i == paintRowID)
                    fi.IsDrawBorder = true;
                else
                    fi.IsDrawBorder = false;
                fi.Width = holderWidth;
                fi.Height = holderHeight;
                fi.Dock = DockStyle.Fill;
                tlpFlawImages.Controls.Add(fi);

            }
        }

        // 更新 重新載入單位
        public void RefreshdtbFlawsUnit()
        {
            NowUnit unitFlawListCD = _units.Find(x => x.ComponentName == "Flaw List CD");
            dgvFlaw.Columns["CD"].HeaderText = dgvFlaw.Columns["CD"].Name + String.Format("({0})", unitFlawListCD.Symbol);
            NowUnit unitFlawListMD = _units.Find(x => x.ComponentName == "Flaw List MD");
            dgvFlaw.Columns["MD"].HeaderText = dgvFlaw.Columns["MD"].Name + String.Format("({0})", unitFlawListMD.Symbol);
            NowUnit unitFlawListWidth = _units.Find(x => x.ComponentName == "Flaw List Width");
            dgvFlaw.Columns["Width"].HeaderText = dgvFlaw.Columns["Width"].Name + String.Format("({0})", unitFlawListWidth.Symbol);
            NowUnit unitFlawListLength = _units.Find(x => x.ComponentName == "Flaw List Height");
            dgvFlaw.Columns["Length"].HeaderText = dgvFlaw.Columns["Length"].Name + String.Format("({0})", unitFlawListLength.Symbol);
            NowUnit unitFlawListArea = _units.Find(x => x.ComponentName == "Flaw List Area");
            dgvFlaw.Columns["Area"].HeaderText = dgvFlaw.Columns["Area"].Name + String.Format("({0})", unitFlawListArea.Symbol);
        }

        // Check UI Buttons can using?
        public void CheckPageUIState()
        {
            // for go to page
            if (_totalPage > 1)
            {
                btnShowGoPage.Enabled = true;
            }
            else
            {
                btnShowGoPage.Enabled = false;
            }

            // for navigator page
            if (_totalPage == 1)
            {
                btnNextFlawImages.Enabled = false;
                btnPrevFlawImages.Enabled = false;
            }
            else if (_nowPage == _totalPage)
            {
                btnNextFlawImages.Enabled = false;
                btnPrevFlawImages.Enabled = true;
            }
            else if (_nowPage == 1)
            {
                btnNextFlawImages.Enabled = true;
                btnPrevFlawImages.Enabled = false;
            }
            else
            {
                btnNextFlawImages.Enabled = true;
                btnPrevFlawImages.Enabled = true;
            }
        }

        #endregion

        //-------------------------------------------------------------------------------------------//

        #region Action Method

        private void btnNextFlawImages_Click(object sender, EventArgs e)
        {
            Job.SetOffline();
            // change page to next and check limit.
            if (_nowPage + 1 > _totalPage)
            {
                _nowPage = _totalPage;
            }
            else
            {
                _nowPage++;
            }
            // re add need controls to tlpImages and update lblNowPage
            RefreshtlpImagesControls(_nowPage);
            // check now page and set can using buttons
            CheckPageUIState();
        }

        private void btnPrevFlawImages_Click(object sender, EventArgs e)
        {
            Job.SetOffline();
            // change page to next and check limit.
            if (_nowPage - 1 < 1 )
            {
                _nowPage = 1;
            }
            else
            {
                _nowPage--;
            }
            // re add need controls to tlpImages and update lblNowPage.
            RefreshtlpImagesControls(_nowPage);
            // check now page and set can using buttons
            CheckPageUIState();
        }

        private void dgvFlaw_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Job.SetOffline();
            int pageSize = tlpFlawImages.ColumnCount * tlpFlawImages.RowCount;
            int toPage = e.RowIndex / pageSize + 1;
            // re add need controls to tlpImages and update lblNowPage
            RefreshtlpImagesControls(toPage, e.RowIndex);
            CheckPageUIState();

            // Show flaw annotation
            _mp.ShowFlawAnnotation(dgvFlaw.Rows[e.RowIndex].Cells["FlawID"].Value.ToString());
        }

        private void dgvFlaw_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            switch (dgvFlaw.Columns[e.ColumnIndex].Name)
            {
                case "CD":
                    NowUnit ucd = _units.Find(x => x.ComponentName == "Flaw List CD");
                    double cd = Convert.ToDouble(e.Value);
                    e.Value = cd * ucd.Conversion;
                    //e.Value += ucd.Symbol;
                    break;
                case "MD":
                    NowUnit umd = _units.Find(x => x.ComponentName == "Flaw List MD");
                    double md = Convert.ToDouble(e.Value);
                    e.Value = md * umd.Conversion;
                    //e.Value += umd.Symbol;
                    break;
                case "Width":
                    NowUnit uWidth = _units.Find(x => x.ComponentName == "Flaw List Width");
                    double width = Convert.ToDouble(e.Value);
                    e.Value = width * uWidth.Conversion;
                    //e.Value += uWidth.Symbol;
                    break;
                case "Length":
                    NowUnit uLength = _units.Find(x => x.ComponentName == "Flaw List Height");
                    double length = Convert.ToDouble(e.Value);
                    e.Value = length * uLength.Conversion;
                    //e.Value += uLength.Symbol;
                    break;
                case "Area":
                    NowUnit uArea = _units.Find(x => x.ComponentName == "Flaw List Area");
                    double area = Convert.ToDouble(e.Value);
                    e.Value = area * uArea.Conversion;
                    //e.Value += uArea.Symbol;
                    break;
            }

        }

        public void CreateFlawImageControl()
        {
            tlpFlawImages.Controls.Clear();
            int holderWidth = tlpFlawImages.Width / tlpFlawImages.ColumnCount;
            int holderHeight = tlpFlawImages.Height / tlpFlawImages.RowCount;

            DataRow[] rows = _dtbFlaws.Select();

            // Calculate pages & set label and buttons
            int pageSize = tlpFlawImages.ColumnCount * tlpFlawImages.RowCount;
            _nowPage = 1;
            if (rows.Length <= pageSize)
                _totalPage = 1;
            else
            {
                _totalPage = rows.Length % pageSize == 0 ?
                             rows.Length / pageSize :
                             rows.Length / pageSize + 1;
                if (_totalPage == 0)
                {
                    _totalPage = 1;
                }
            }
            lblNowPage.Text = _nowPage.ToString();
            lblTotalPage.Text = _totalPage.ToString();
            int startFicIndex = (_nowPage - 1) * pageSize;
            int endFicIndex = ((startFicIndex + pageSize) > rows.Length) ? rows.Length : (startFicIndex + pageSize);
           
            // Add FlawImageControl in tableLayout.
            for (int i = startFicIndex; i < endFicIndex; i++)
            {
                FlawImageControl fi = new FlawImageControl(rows[i], ref _units, ref _mp);
                SetDoubleBuffered(fi);
                fi.Width = holderWidth;
                fi.Height = holderHeight;
                fi.Dock = DockStyle.Fill;
                tlpFlawImages.Controls.Add(fi);
            }

            // Set can using buttons when oncut all button reset.
            CheckPageUIState();
            dgvFlaw.ClearSelection();
        }

        private void dgvFlaw_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            _nowPage = 1;
            RefreshtlpImagesControls(_nowPage);
            CheckPageUIState();
        }

        private void btnShowGoPage_Click(object sender, EventArgs e)
        {
            btnShowGoPage.Visible = false;
            txtGoPage.Focus();
            txtGoPage.SelectAll();
           
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            int gotoPage = int.TryParse(txtGoPage.Text, out gotoPage) ? gotoPage : 1;
            if (gotoPage <= _totalPage && gotoPage > 0)
            {
                Job.SetOffline();
                // change page to next and check limit.
                if (_nowPage > _totalPage)
                {
                    _nowPage = _totalPage;
                }
                else
                {
                    _nowPage = gotoPage;
                }
                // re add need controls to tlpImages and update lblNowPage
                RefreshtlpImagesControls(_nowPage);
                // check now page and set can using buttons
                CheckPageUIState();
            }

            btnShowGoPage.Visible = true;
        }

        #endregion
    }
}
