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
    public partial class PxPTab : UserControl, IWRPlugIn, IWRMapWindow
    {
        #region Variable
		 
	
        #endregion

        #region Local Objects
        MapWindow mp = new MapWindow();
	
        #endregion
        

        public PxPTab()
        {
            InitializeComponent();
           
        }


        #region IWRPlugIn 成員
        public void GetControlHandle(out IntPtr hndl)
        {
            hndl = Handle;
        }

        public void SetPosition(int w, int h)
        {
            SetBounds(0, 0, w, h); 
        }

        public void GetName(e_Language lang, out string name)
        {
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

        public void Initialize(string unitsXMLPath)
        {
           
        }
       
        public void Unplug()
        {
        }

        #endregion

        #region IWRMapWindow 成員

        public void GetMapControlHandle(out IntPtr hndl)
        {
            hndl = mp.Handle;
        }

        public void SetMapPosition(int w, int h)
        {
            mp.SetBounds(0, 0, w, h);
        }

        #endregion
    }
}
