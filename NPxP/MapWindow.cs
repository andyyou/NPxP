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
using System.ComponentModel.Composition;

namespace NPxP
{
    public partial class MapWindow : UserControl, IOnLanguageChanged
    {
        #region Local Objects
        private List<FlawLegend> _legend;
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

       

        private void btnMapSetting_Click(object sender, EventArgs e)
        {
            JobHelper.Job.SetOffline();
        }




        #region IOnLanguageChanged 成員

        public void OnLanguageChanged(e_Language language)
        {
            
        }

        #endregion
    }
}
