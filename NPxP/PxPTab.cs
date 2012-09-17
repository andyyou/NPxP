using System;
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

namespace NPxP
{
    [Export(typeof(IWRPlugIn))]
    public partial class PxPTab : UserControl, IWRPlugIn, IWRMapWindow, IOnFlaws, IOnEvents, IOnCut, IOnJobLoaded,
                                  IOnJobStarted, IOnLanguageChanged, IOnJobStopped, IOnWebDBConnected, 
                                  IOnOnline, IOnUserTermsChanged, IOnDoffResult, IOnPxPConfig,
                                  IOnRollResult, IOnOpenHistory, 
                                  IOnUnitsChanged
    {
        #region Local Objects

        private MapWindow _mp;
        private DataTable _dtbFlaws;
        private List<NowUnit> _units;
        private List<double> _cuts;
        private string _xmlUnitsPath;
        private string _dbConnectString;

        private int _nowPage, _totalPage; // For TableLayout pages , start from 1.
        private bool _isOpenHistory;
       

        #endregion
        //-------------------------------------------------------------------------------------------//
        #region Import Objects
        [Import(typeof(IWRMessageLog))]
        IWRMessageLog MsgLog; // Log 物件

        [Import(typeof(IWRJob))]
        public IWRJob Job;           // Job 物件: 啟動,停止,回復工單,Margin ROI 等... 
        
        [Import(typeof(IWRFireEvent))]
        IWRFireEvent Fire;    // Fire 物件: 回傳 Event 給 CCD

        #endregion

        //-------------------------------------------------------------------------------------------//

        #region Interface Method
        // (1)
        public PxPTab()
        {
            WriteHelper.Log("PxPTab()");
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
                column.HeaderText = c.Name;
                column.Width = c.Width;
                column.DataPropertyName = c.Name;
                column.SortMode = DataGridViewColumnSortMode.Automatic;
                dgvFlaw.Columns.Add(column);
            }
            dgvFlaw.MultiSelect = false;
            dgvFlaw.AutoGenerateColumns = false;
           
            // initialize tlpFlawImages layout without pictures.
            SetDoubleBuffered(tlpFlawImages); // start double buffer.
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
            WriteHelper.Log("OnLanguageChanged()");
        }
        // (3)(8)
        public void Initialize(string unitsXMLPath)
        {
            WriteHelper.Log("Initialize()");
            _xmlUnitsPath = unitsXMLPath;
            LoadXmlToUnitsObject(unitsXMLPath);
            JobHelper.Job = Job;  // 設定 Helper 協助各頁面停止工單等操作.
           
        }
        // (4)(7)(17)
        public void GetName(e_Language lang, out string name)
        {
            WriteHelper.Log("GetName()");
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
            WriteHelper.Log("GetControlHandle()");
            hndl = Handle;
        }
        // (6)
        public void SetPosition(int w, int h)
        {
            WriteHelper.Log("SetPosition()");
            SetBounds(0, 0, w, h);
          
        }
        // (9) :回傳外掛設計的 MapWindow 給主程式
        public void GetMapControlHandle(out IntPtr hndl)
        {
            WriteHelper.Log("GetMapControlHandle()");
            _mp = new MapWindow(); // 確保執行順序正確,所以在這邊在 new 物件.
            hndl = _mp.Handle;
        }
        // (10) :設定 MapWindow Position with Job object.
        public void SetMapPosition(int w, int h)
        {
            WriteHelper.Log("SetMapPosition()");
            _mp.SetBounds(0, 0, w, h);
        }
        // (11)
        public void OnWebDBConnected(IWebDBConnectionInfo info)
        {
            WriteHelper.Log("OnWebDBConnected()");
            _dbConnectString = String.Format("Data Source={0};Initial Catalog={1};User Id={2};Password={3};", info.ServerName, info.DatabaseName, info.UserName, info.Password);
        }
        // (12)
        public void OnUserTermsChanged(IUserTerms terms)
        {
            WriteHelper.Log("OnUserTermsChanged()");
            
        }
        // (13)
        public void OnSetFlawLegend(List<FlawLegend> legend)
        {
            WriteHelper.Log("OnSetFlawLegend()");
            _mp.SetFlawLegend(legend);  // 把 MapWindow 需要的資料傳過去. 
            
        }
        // (14)
        public void OnInitializeGlassEdges(int glassLeftMarginToROI, int glassRightMarginToROI)
        {
            WriteHelper.Log("OnInitializeGlassEdges()");
        }
        // (15)
        public void OnPxPConfig(IPxPInfo info)
        {
            WriteHelper.Log("OnPxPConfig()");
            JobHelper.PxPInfo = info;
            // keep pxpinfo height and width's units is meter.
            //NowUnit unitFlawMaCD = _units.Find(x => x.ComponentName == "Flaw Map CD");
            //JobHelper.PxPInfo.Height = JobHelper.PxPInfo.Height / unitFlawMaCD.Conversion;
            //JobHelper.PxPInfo.Width = JobHelper.PxPInfo.Width / unitFlawMaCD.Conversion;
        }
        // (16)
        public void OnJobLoaded(IList<IFlawTypeName> flawTypes, IList<ILaneInfo> lanes, IList<ISeverityInfo> severityInfo, IJobInfo jobInfo)
        {
            WriteHelper.Log("OnJobLoaded()");
            // Reset to default.
            _cuts = new List<double>();
            lblNowPage.Text = "---";
            lblTotalPage.Text = "---";
            btnNextFlawImages.Enabled = false;
            btnProvFlawImages.Enabled = false;

            // save datas in global helper.
            JobHelper.FlawTypes = flawTypes;
            JobHelper.JobInfo = jobInfo;
            JobHelper.Lanes = lanes;
            JobHelper.SeverityInfo = severityInfo;

            // update MapWindow JobInfo
            _mp.InitJobInfo(jobInfo);

            //update dgvFlaw HeaderText + (Unit)
            NowUnit unitFlawListCD = _units.Find(x => x.ComponentName == "Flaw List CD");
            dgvFlaw.Columns["CD"].HeaderText = dgvFlaw.Columns["CD"].Name + String.Format("({0})", unitFlawListCD.Symbol);
            NowUnit unitFlawListMD = _units.Find(x => x.ComponentName == "Flaw List MD");
            dgvFlaw.Columns["MD"].HeaderText = dgvFlaw.Columns["MD"].Name + String.Format("({0})", unitFlawListMD.Symbol);
            NowUnit unitFlawListWidth = _units.Find(x => x.ComponentName == "Flaw List Width");
            dgvFlaw.Columns["Width"].HeaderText = dgvFlaw.Columns["Width"].Name + String.Format("({0})", unitFlawListWidth.Symbol);
            NowUnit unitFlawListLength = _units.Find(x => x.ComponentName == "Flaw List Height");
            dgvFlaw.Columns["Length"].HeaderText =  dgvFlaw.Columns["Length"].Name + String.Format("({0})", unitFlawListLength.Symbol);
            NowUnit unitFlawListArea = _units.Find(x => x.ComponentName == "Flaw List Area");
            dgvFlaw.Columns["Area"].HeaderText = dgvFlaw.Columns["Area"].Name + String.Format("({0})", unitFlawListArea.Symbol);
            
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
            _dtbFlaws.Columns.Add("PointScore", typeof(double));
            _dtbFlaws.Columns.Add("SubPieceName", typeof(string));
            
            // sort by default column
            ConfigHelper ch = new ConfigHelper();
            _dtbFlaws.DefaultView.Sort = String.Format("{0} ASC", ch.GetSortByColumnName().Trim());
            
            // set dgvFlaws datasource 
            dgvFlaw.DataSource = _dtbFlaws;

            //// Initial Flaw Chart
            //NowUnit unitFlawMapCD = _units.Find(x => x.ComponentName == "Flaw Map CD");
            //double mapWidth = JobHelper.PxPInfo.Width * unitFlawMapCD.Conversion;
            //double mapHeight = JobHelper.PxPInfo.Height * unitFlawMapCD.Conversion;
            //_mp.InitChart(mapWidth, mapHeight);
           

        }
        // (18) :執行每一個步驟都會檢查
        public void OnOnline(bool isOnline)
        {
            JobHelper.IsOnline = isOnline;
            _isOpenHistory = false;
            WriteHelper.Log("OnOnline()");
        }
        // (19)
        public void OnJobStarted(int jobKey)
        {
            WriteHelper.Log("OnJobStarted()");
            
        }
        // (20) :設定幾個 Events 就會觸發幾次
        public void OnEvents(IList<IEventInfo> events)
        {
            WriteHelper.Log("OnEvents()");
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
                        _cuts.Add(eventInfo.MD);
                        
                        if (JobHelper.IsOnline || _isOpenHistory)  // 如果 Cut Online 才更新 GridView 和 DataTable Range.
                        {
                            // Filter DataGridView
                            double prevMD = eventInfo.MD - JobHelper.PxPInfo.Height;
                            string filterExp = String.Format("MD > {0} AND MD < {1}", prevMD, eventInfo.MD);
                            DataView dv = _dtbFlaws.DefaultView;
                            dv.RowFilter = filterExp;
                            // Clear tableLyout controls and search data.  
                            tlpFlawImages.Controls.Clear();
                            int holderWidth = tlpFlawImages.Width / tlpFlawImages.ColumnCount;
                            int holderHeight = tlpFlawImages.Height / tlpFlawImages.RowCount;
                            DataRow[] rows = _dtbFlaws.Select(filterExp);

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
                            }
                            lblNowPage.Text = _nowPage.ToString();
                            lblTotalPage.Text = _totalPage.ToString();
                            int startFicIndex = (_nowPage - 1) * pageSize;
                            int endFicIndex = ((startFicIndex + pageSize) > rows.Length) ? rows.Length : (startFicIndex + pageSize);
                            // Add FlawImageControl in tableLayout.
                            for (int i = startFicIndex; i < endFicIndex; i++)
                            {
                                FlawImageControl fi = new FlawImageControl(rows[i]);
                                SetDoubleBuffered(fi);
                                fi.Width = holderWidth;
                                fi.Height = holderHeight;
                                fi.Dock = DockStyle.Fill;
                                tlpFlawImages.Controls.Add(fi);
                            }
                            //_mp.DrawChartPoint(rows, eventInfo.MD);
                            // Set can using buttons when oncut all button reset.
                            if (_totalPage > 1)
                            {
                                btnNextFlawImages.Enabled = true;
                                btnProvFlawImages.Enabled = false;
                            }
                            else
                            {
                                btnNextFlawImages.Enabled = false;
                                btnProvFlawImages.Enabled = false;
                            }
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
            foreach (IFlawInfo flaw in flaws)
            {
                DataRow dr = _dtbFlaws.NewRow();
                dr["FlawID"] = flaw.FlawID;
                dr["CD"] = flaw.CD; // Notice: DataTable 和 PxPInfo.Width, Height 資料保持單位 公尺
                dr["MD"] = flaw.MD;
                dr["Area"] = flaw.Area;
                dr["DateTime"] = flaw.DateTime;
                dr["FlawClass"] = flaw.FlawClass;
                dr["FlawType"] = flaw.FlawType;
                dr["LeftEdge"] = flaw.LeftEdge;
                dr["LeftRollCD"] = flaw.LeftRollCD;
                dr["Length"] = flaw.Length;
                dr["RightEdge"] = flaw.RightEdge;
                dr["RightRollCD"] = flaw.RightRollCD;
                dr["Roll"] = flaw.Roll;
                dr["RollMD"] = flaw.RollMD;
                dr["Width"] = flaw.Width;
                // deal plug properties
                int opv;
                if (JobHelper.SeverityInfo.Count > 0)
                    dr["Priority"] = JobHelper.SeverityInfo[0].Flaws.TryGetValue(flaw.FlawType, out opv) ? opv : 0;
                else
                    dr["Priority"] = 0;
                // UNDONE: 因讀取歷史資料, 特別處理 Image
                if (_isOpenHistory)
                {
                    bool blnShowImg = false;
                    int intW = 0;
                    int intH = 0;
                    using (SqlConnection cn = new SqlConnection(_dbConnectString))
                    {
                        cn.Open();
                        string QueryStr = "Select iImage From dbo.Jobs T1, dbo.Flaw T2, dbo.Image T3 Where T1.klKey = T2.klJobKey AND T2.pklFlawKey = T3.klFlawKey AND T1.JobID = @JobID AND T2.lFlawId = @FlawID";
                        SqlCommand cmd = new SqlCommand(QueryStr, cn);
                        cmd.Parameters.AddWithValue("@JobID", JobHelper.JobInfo.JobID);
                        cmd.Parameters.AddWithValue("@FlawID", flaw.FlawID);
                        SqlDataReader sd = cmd.ExecuteReader();
                        sd.Read();
                        byte[] images = (Byte[])sd["iImage"];

                        intW = images[0] + images[1] * 256;
                        intH = images[4] + images[5] * 256;

                        if (intW == 0 & intH == 0)
                        {
                            intW = 1;
                            intH = 1;
                            blnShowImg = false;
                        }
                        else
                        {
                            blnShowImg = true;
                        }
                        Bitmap bmpShowImg = new Bitmap(intW, intH);

                        if (blnShowImg)
                        {
                            bmpShowImg = ToGrayBitmap(images, intW, intH);
                        }

                        IImageInfo tmpImg = new ImageInfo(bmpShowImg, 0);
                        IList<IImageInfo> m = flaw.Images;
                        m.Add(tmpImg);
                        dr["Images"] = m;
                    }
                }
                else
                {
                    dr["Images"] = flaw.Images;
                }

                // add record to datatable
                _dtbFlaws.Rows.Add(dr);
            }
            
            WriteHelper.Log("OnFlaws()");
        }
        // (D)
        public void OnCut(double md)
        {
            WriteHelper.Log("OnCut()");
            dgvFlaw.ClearSelection();
           
        }
        // (D) :處理缺陷判斷
        public void OnDoffResult(double md, int doffNumber, bool pass)
        {
            WriteHelper.Log("OnDoffResult()");
        }
        // (D) :單位變更
        public void OnUnitsChanged()
        {
            WriteHelper.Log("OnUnitsChanged()");
            if (!String.IsNullOrEmpty(_xmlUnitsPath))
            {
                LoadXmlToUnitsObject(_xmlUnitsPath);
            }
            // update dgvFlaw HeaderText + (Unit)
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
        // (D) 
        public void OnRollResult(double cd, double md, int doffNumber, int laneNumber, bool pass)
        {
            WriteHelper.Log("OnRollResult()");
        }
        // (D) :開啟歷史資料
        public void OnOpenHistory(double startMD, double stopMD)
        {
            WriteHelper.Log("OnOpenHistory()");
            _isOpenHistory = true;
        }
        // (25) :停止工單
        public void OnJobStopped(double md)
        {
            WriteHelper.Log("OnJobStopped()");
        }
        // (End -1 )
        public void Unplug()
        {
            WriteHelper.Log("Unplug()");
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
            // Clear  TableLayout of FlawImages's controls
            tlpFlawImages.Controls.Clear();
            // Calculate about init.
            int holderWidth = tlpFlawImages.Width / tlpFlawImages.ColumnCount;
            int holderHeight = tlpFlawImages.Height / tlpFlawImages.RowCount;
            int pageSize = tlpFlawImages.ColumnCount * tlpFlawImages.RowCount;
            lblNowPage.Text = nowPage.ToString();
            // Get now filter rows
            DataRow[] rows = _dtbFlaws.Select(_dtbFlaws.DefaultView.RowFilter); 
            int startFicIndex = (nowPage - 1) * pageSize;
            int endFicIndex = ((startFicIndex + pageSize) > _dtbFlaws.DefaultView.Count) ? _dtbFlaws.DefaultView.Count : (startFicIndex + pageSize);
            // Add FlawImageControl in tableLayout.
            for (int i = startFicIndex; i < endFicIndex; i++)
            {
                FlawImageControl fi = new FlawImageControl(rows[i]);
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
            // Clear  TableLayout of FlawImages's controls
            tlpFlawImages.Controls.Clear();
            // Calculate about init.
            int holderWidth = tlpFlawImages.Width / tlpFlawImages.ColumnCount;
            int holderHeight = tlpFlawImages.Height / tlpFlawImages.RowCount;
            int pageSize = tlpFlawImages.ColumnCount * tlpFlawImages.RowCount;
            lblNowPage.Text = nowPage.ToString();
            // Get now filter rows
            DataRow[] rows = _dtbFlaws.Select(_dtbFlaws.DefaultView.RowFilter); 
            int startFicIndex = (nowPage - 1) * pageSize;
            int endFicIndex = ((startFicIndex + pageSize) > _dtbFlaws.DefaultView.Count) ? _dtbFlaws.DefaultView.Count : (startFicIndex + pageSize);
            // Add FlawImageControl in tableLayout.
            for (int i = startFicIndex; i < endFicIndex; i++)
            {
                
                FlawImageControl fi = new FlawImageControl(rows[i]);
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
        // Function of Image
        public static Bitmap ToGrayBitmap(byte[] rawValues, int width, int height)
        {
            // Declare bitmap variable and lock memory
            Bitmap bmp = new Bitmap(width, height, PixelFormat.Format8bppIndexed);
            BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, width, height),
                ImageLockMode.WriteOnly, PixelFormat.Format8bppIndexed);

            // Get image parameter
            int stride = bmpData.Stride;  // Width of scan line
            int offset = stride - width;  // Display width and the scan line width of the gap
            IntPtr iptr = bmpData.Scan0;  // Get bmpData start position in memory
            int scanBytes = stride * height;  // Size of the memory area

            // Convert the original display size of the byte array into an array of bytes actually stored in the memory
            int posScan = 0, posReal = 0;  // Declare two pointer, point to source and destination arrays
            byte[] pixelValues = new byte[scanBytes];  // Declare array size
            for (int x = 0; x < height; x++)
            {
                // Emulate line scanning
                for (int y = 0; y < width; y++)
                {
                    pixelValues[posScan++] = rawValues[posReal++];
                }
                posScan += offset;  //Line scan finished
            }

            // Using Marshal.Copy function copy pixelValues to BitmapData
            Marshal.Copy(pixelValues, 0, iptr, scanBytes);
            bmp.UnlockBits(bmpData);  // Unlock memory

            // Change 8 bit bitmap index table to Grayscale
            ColorPalette tempPalette;
            using (Bitmap tempBmp = new Bitmap(1, 1, PixelFormat.Format8bppIndexed))
            {
                tempPalette = tempBmp.Palette;
            }
            for (int i = 0; i < 256; i++)
            {
                tempPalette.Entries[i] = Color.FromArgb(i, i, i);
            }

            bmp.Palette = tempPalette;
            return bmp;
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
            if (_totalPage == 1)
            {
                btnNextFlawImages.Enabled = false;
                btnProvFlawImages.Enabled = false;
            }
            else if (_nowPage == _totalPage)
            {
                btnNextFlawImages.Enabled = false;
                btnProvFlawImages.Enabled = true;
            }
            else
            {
                btnNextFlawImages.Enabled = true;
                btnProvFlawImages.Enabled = true;
            }

        }
        private void btnProvFlawImages_Click(object sender, EventArgs e)
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
            if (_totalPage == 1)
            {
                btnNextFlawImages.Enabled = false;
                btnProvFlawImages.Enabled = false;
            }
            else if (_nowPage == _totalPage)
            {
                btnNextFlawImages.Enabled = false;
                btnProvFlawImages.Enabled = true;
            }
            else
            {
                btnNextFlawImages.Enabled = true;
                btnProvFlawImages.Enabled = true;
            }
        }

        private void dgvFlaw_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Job.SetOffline();
            int pageSize = tlpFlawImages.ColumnCount * tlpFlawImages.RowCount;
            int toPage = e.RowIndex / pageSize + 1;
            // re add need controls to tlpImages and update lblNowPage
            RefreshtlpImagesControls(toPage, e.RowIndex);
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
        #endregion

        

        
    }

    // Extend class 
    public class ImageInfo : IImageInfo
    {
        #region IImageInfo 成員

        public System.Drawing.Bitmap Image { set; get; }
        public int Station { set; get; }

        public ImageInfo(System.Drawing.Bitmap image, int station)
        {
            this.Image = image;
            this.Station = station;
        }

        #endregion
    }
}
