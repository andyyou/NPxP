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
        MapWindow mp = new MapWindow();
	
        #endregion

        #region Import Objects
        [Import(typeof(IWRMessageLog))]
        IWRMessageLog MsgLog; // Log 物件

        [Import(typeof(IWRJob))]
        IWRJob Job;           // Job 物件: 啟動,停止,回復工單,Margin ROI 等... 
        
        [Import(typeof(IWRFireEvent))]
        IWRFireEvent Fire;    // Fire 物件: 回傳 Event 給 CCD

        #endregion

        // (1)
        public PxPTab()
        {
            InitializeComponent();
        }
        // (End)
        ~PxPTab()
        {

        }
        // (2)
        public void OnLanguageChanged(e_Language language)
        {
            
        }
        // (3)(8)
        public void Initialize(string unitsXMLPath)
        {
            
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
            hndl = mp.Handle;
        }
        // (10)
        public void SetMapPosition(int w, int h)
        {
            mp.SetBounds(0, 0, w, h);
        }
        // (11)
        public void OnWebDBConnected(IWebDBConnectionInfo info)
        {

        }
        // (12)
        public void OnUserTermsChanged(IUserTerms terms)
        {

        }
        // (13)
        public void OnSetFlawLegend(List<FlawLegend> legend)
        {
           
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
            
        }
        // (D)
        public void OnCut(double md)
        {
           
        }
        // (D) :處理缺陷判斷
        public void OnDoffResult(double md, int doffNumber, bool pass)
        {
            
        }
        // (D)
        public void OnGlassEdges(double md, double leftGlassEdge, double leftGearEdge, double leftGearRigthEdge, double leftROI, double rightROI, double rightGearLeftEdge, double rightGearRightEdge, double rigthGlassEdge)
        {

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
      
    }
}
