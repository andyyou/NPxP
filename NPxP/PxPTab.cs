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

namespace NPxP
{
    [Export(typeof(IWRPlugIn))]
    public partial class PxPTab : UserControl, IWRPlugIn, IWRMapWindow, IOnFlaws, IOnEvents, IOnCut, IOnJobLoaded,
                                  IOnJobStarted, IOnLanguageChanged, IOnJobStopped, IOnWebDBConnected, 
                                  IOnOnline, IOnUserTermsChanged, IOnDoffResult, IOnPxPConfig,
                                  IOnRollResult, IOnOpenHistory, 
                                  IOnUnitsChanged
    {
        #region Variable
		 
	
        #endregion

        #region Local Objects
        private MapWindow _mp;
        private DataTable _dtbFlaws;
        private Dictionary<string, double> _units;
        private string _xmlUnitsPath;
        private string _dbConnectString;
        private IPxPInfo _pxpInfo;
        private IList<ISeverityInfo> _serverityInfo;
        private IList<IFlawTypeName> _flawTypes;
        private IList<ILaneInfo> _lanes;
        #endregion

        #region Import Objects
        [Import(typeof(IWRMessageLog))]
        IWRMessageLog MsgLog; // Log 物件

        [Import(typeof(IWRJob))]
        IWRJob Job;           // Job 物件: 啟動,停止,回復工單,Margin ROI 等... 
        
        [Import(typeof(IWRFireEvent))]
        IWRFireEvent Fire;    // Fire 物件: 回傳 Event 給 CCD

        #endregion

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
                dgvFlaw.Columns.Add(column);
            }
            dgvFlaw.AutoGenerateColumns = false; 
            

            // initialize tlpFlawImages layout without pictures.
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
        }
        // (2)
        public void OnLanguageChanged(e_Language language)
        {
            WriteHelper.Log("OnLanguageChanged()");
        }
        // (3)(8)
        public void Initialize(string unitsXMLPath)
        {
            _xmlUnitsPath = unitsXMLPath;
            LoadXmlToUnitsObject(unitsXMLPath);
            WriteHelper.Log("Initialize()");
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
            hndl = Handle;
            WriteHelper.Log("GetControlHandle()");
        }
        // (6)
        public void SetPosition(int w, int h)
        {
            SetBounds(0, 0, w, h);
            WriteHelper.Log("SetPosition()");
        }
        // (9) :回傳外掛設計的 MapWindow 給主程式
        public void GetMapControlHandle(out IntPtr hndl)
        {
            _mp = new MapWindow(); // 確保執行順序正確,所以在這邊在 new 物件.
            hndl = _mp.Handle;
            WriteHelper.Log("GetMapControlHandle()");
        }
        // (10)
        public void SetMapPosition(int w, int h)
        {
            _mp.SetBounds(0, 0, w, h);
            WriteHelper.Log("SetMapPosition()");
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
            if (!String.IsNullOrEmpty(_xmlUnitsPath))
            {
                LoadXmlToUnitsObject(_xmlUnitsPath);
            }
        }
        // (13)
        public void OnSetFlawLegend(List<FlawLegend> legend)
        {
            _mp.SetFlawLegend(legend);  // 把 MapWindow 需要的資料傳過去. 
            WriteHelper.Log("OnSetFlawLegend()");
        }
        // (14)
        public void OnInitializeGlassEdges(int glassLeftMarginToROI, int glassRightMarginToROI)
        {
            WriteHelper.Log("OnInitializeGlassEdges()");
        }
        // (15)
        public void OnPxPConfig(IPxPInfo info)
        {
            _pxpInfo = info;
            WriteHelper.Log("OnPxPConfig()");
        }
        // (16)
        public void OnJobLoaded(IList<IFlawTypeName> flawTypes, IList<ILaneInfo> lanes, IList<ISeverityInfo> severityInfo, IJobInfo jobInfo)
        {
            WriteHelper.Log("OnJobLoaded()");
            // get data to objects
            _serverityInfo = severityInfo ;
            _flawTypes = flawTypes;
            _lanes = lanes;
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
           

            // set dgvFlaws datasource 
            dgvFlaw.DataSource = _dtbFlaws;
           

        }
        // (18) :執行每一個步驟都會檢查
        public void OnOnline(bool isOnline)
        {
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

        }
        // (D) :資料流入
        public void OnFlaws(IList<IFlawInfo> flaws)
        {

            foreach (IFlawInfo flaw in flaws)
            {
                DataRow dr = _dtbFlaws.NewRow();
                dr["FlawID"] = flaw.FlawID;
                dr["CD"] = flaw.CD;
                dr["MD"] = flaw.MD;
                dr["Area"] = flaw.Area;
                dr["DateTime"] = flaw.DateTime;
                dr["FlawClass"] = flaw.FlawClass;
                dr["FlawType"] = flaw.FlawType;
                dr["Images"] = flaw.Images;
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
                if (_serverityInfo.Count > 0)
                    dr["Priority"] = _serverityInfo[0].Flaws.TryGetValue(flaw.FlawType, out opv) ? opv : 0;
                else
                    dr["Priority"] = 0;

                // add record to datatable
                _dtbFlaws.Rows.Add(dr); 

 
            }
            
            WriteHelper.Log("OnFlaws()");
        }
        // (D)
        public void OnCut(double md)
        {
            WriteHelper.Log("OnCut()");
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

        #region R Method
        public void LoadXmlToUnitsObject(string xml)
        {
            // initialize units dictionary.
            _units = new Dictionary<string, double>(); // ex: <Flaw Map CD, 1.00000000000000000>

            // load xml data to dictionary.
            XmlDocument document = new XmlDocument();
            document.Load(xml);
            XPathNavigator navigator = document.CreateNavigator();
            XPathNodeIterator node = navigator.Select("//Components/Component");

            while (node.MoveNext())
            {
                int unitIndex = Convert.ToInt32(node.Current.SelectSingleNode("@unit").Value) + 1; // Xpath's index start from 1.
                string expr = String.Format("//Units/Unit[{0}]/@conversion", unitIndex);
                double convertion = Convert.ToDouble(navigator.SelectSingleNode(expr).Value);
                string componentName = node.Current.SelectSingleNode("@name").Value;
                _units.Add(componentName, convertion);
            }
        }
        #endregion

        #region Action Method
        #endregion
    }
}
