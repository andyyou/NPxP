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

namespace NPxP
{
    [Export(typeof(IWRPlugIn))]
    public partial class PxPTab : UserControl, IWRPlugIn, IWRMapWindow, IOnFlaws, IOnEvents, IOnCut, IOnJobLoaded,
                                  IOnJobStarted, IOnLanguageChanged, IOnJobStopped, IOnWebDBConnected, 
                                  IOnGlassEdges, IOnOnline, IOnUserTermsChanged, IOnDoffResult, IOnPxPConfig,
                                  IOnRollResult, IOnOpenHistory, 
                                  IOnUnitsChanged
    {
        #region Variable
		 
	
        #endregion

        #region Local Objects
        private MapWindow mp;
        private DataSet dsPxP;
        private DataTable dtbFlaws; 
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
        // (1-1)
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
                dgvFlaw.Columns.Add(column);
            }
            
        }
        // (End)
        ~PxPTab()
        {

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
            mp = new MapWindow(); // 確保執行順序正確,所以在這邊在 new 物件.
            hndl = mp.Handle;
            WriteHelper.Log("GetMapControlHandle()");
        }
        // (10)
        public void SetMapPosition(int w, int h)
        {
            mp.SetBounds(0, 0, w, h);
            WriteHelper.Log("SetMapPosition()");
        }
        // (11)
        public void OnWebDBConnected(IWebDBConnectionInfo info)
        {
            WriteHelper.Log("OnWebDBConnected()");
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
        }
        // (16)
        public void OnJobLoaded(IList<IFlawTypeName> flawTypes, IList<ILaneInfo> lanes, IList<ISeverityInfo> severityInfo, IJobInfo jobInfo)
        {
            WriteHelper.Log("OnJobLoaded()");
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
        // (D)
        public void OnGlassEdges(double md, double leftGlassEdge, double leftGearEdge, double leftGearRigthEdge, double leftROI, double rightROI, double rightGearLeftEdge, double rightGearRightEdge, double rigthGlassEdge)
        {
            WriteHelper.Log("OnGlassEdges()");
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
        #endregion

        #region Action Method
        #endregion
    }
}
