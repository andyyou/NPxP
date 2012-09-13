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
using DevExpress.XtraCharts;

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
            MapSetup ms = new MapSetup();
            ms.ShowDialog();
        }

        #region IOnLanguageChanged 成員

        public void OnLanguageChanged(e_Language language)
        {
            
        }

        #endregion

        #region R Method

        public void DrawChartPoint(DataRow[] flawRows, double cutMD)
        {
            double topOfMaterial = cutMD - JobHelper.PxPInfo.Height;
            Series flawPoint;
            foreach (DataRow dr in flawRows)
            {
                flawPoint = new Series(dr["FlawID"].ToString(), ViewType.Point);
                double cd = Convert.ToInt32(dr["CD"]);
                double md = Convert.ToInt32(dr["MD"]) - topOfMaterial;
                flawPoint.Points.Add(new SeriesPoint(cd, md));
                flawPoint.ArgumentScaleType = ScaleType.Numerical;
                flawPoint.ValueScaleType = ScaleType.Numerical;

                // Access the view-type-specific options of the series.
                PointSeriesView flawPointView = (PointSeriesView)flawPoint.View;
                flawPointView.PointMarkerOptions.Kind = MarkerKind.Circle;
                //chartControl.Series.Add(flawPoint);
            }
        }

        #endregion
    }
}
