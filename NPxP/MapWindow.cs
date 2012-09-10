using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NPxP.Helper;
using WRPlugIn;

namespace NPxP
{
    public partial class MapWindow : UserControl
    {
        #region Local Objects
        public List<FlawLegend> _legend;
        #endregion
        public MapWindow()
        {
            WriteHelper.Log("MapWindow()");
            InitializeComponent();
        }


        public void SetFlawLegend(List<FlawLegend> legned)
        {
            _legend = legned;
        }
       
    }
}
