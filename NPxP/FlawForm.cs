using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NPxP.Helper;
using NPxP.Toolkit;
using WRPlugIn;
using NPxP.Properties;

namespace NPxP
{
    public partial class FlawForm : Form
    {
        #region Loacal Variables

        private DataRow _drFlaw;
        private PictureBox[] _pb;
        private double[] _pbRatio;
        private Image[] _srcImages;

        #endregion

        public FlawForm(DataRow drFlaw)
        {
            InitializeComponent();
            this._drFlaw = drFlaw;
            this.Text = "Flaw ID : " + _drFlaw["FlawID"].ToString();
            
            _pb = new PictureBox[JobHelper.JobInfo.NumberOfStations];
            _pbRatio = new double[JobHelper.JobInfo.NumberOfStations];
            _srcImages = new Image[JobHelper.JobInfo.NumberOfStations];
        }
        //-------------------------------------------------------------------------------------------//

        #region R Methods
        // 計算圖片比例和置放圖片.
        public double Init_Image(Bitmap bmp, TabPage tp, PictureBox pb)
        {
            double Width_d = (double)bmp.Width / (double)tp.ClientSize.Width * 1.1;
            double Height_d = (double)bmp.Height / (double)tp.ClientSize.Height * 1.1;
            double ratio = 1.0;
            if (Width_d > 1 || Height_d > 1)
            {
                if (Width_d > Height_d)
                {
                    ratio = Width_d;
                }
                else
                {
                    ratio = Height_d;
                }
            }
            else if (Width_d < 1 && Height_d < 1)
            {
                if (Width_d > Height_d)
                    ratio = Width_d;
                else
                    ratio = Height_d;
            }
            pb.Width = (int)Math.Round(bmp.Width / ratio);
            pb.Height = (int)Math.Round(bmp.Height / ratio);

            Image src = bmp;
            Bitmap dest = new Bitmap(pb.Width, pb.Height);

            Graphics g = Graphics.FromImage(dest);
            g.DrawImage(src, new Rectangle(0, 0, dest.Width, dest.Height));
            pb.Height = dest.Height;
            pb.Width = dest.Width;
            pb.Image = dest;
            return ratio;
        }
        // Zoom In, Zoom Out
        public void PicZoomByPercent(int ZoomPercent)
        {
            PictureBox pb = null;
            foreach (Control control in tabImages.SelectedTab.Controls)
            {
                if (control.GetType().Name == "PictureBox")
                {
                    pb = (PictureBox)control;
                    break;
                }
            }

            if (pb != null)
            {
                Image src = pb.Image;
                Bitmap dest = null;

                int newWidth = (int)(((double)_srcImages[tabImages.SelectedIndex].Width / _pbRatio[tabImages.SelectedIndex]) * ((double)ZoomPercent / 100));
                int newHeight = (int)(((double)_srcImages[tabImages.SelectedIndex].Height / _pbRatio[tabImages.SelectedIndex]) * ((double)ZoomPercent / 100));
                dest = new Bitmap(newWidth, newHeight);

                Graphics g = Graphics.FromImage(dest);
                g.DrawImage(_srcImages[tabImages.SelectedIndex], new Rectangle(0, 0, dest.Width, dest.Height));
                pb.Height = dest.Height;
                pb.Width = dest.Width;
                pb.Image = dest;
            }
        }
        #endregion

        //-------------------------------------------------------------------------------------------//

        #region Action Methods
        private void FlawForm_Load(object sender, EventArgs e)
        {
            // initialize all labels
            lblFlawIDVal.Text = _drFlaw["FlawID"].ToString();
            lblFlawClassVal.Text = _drFlaw["FlawClass"].ToString();
            lblFlawTypeVal.Text = _drFlaw["FlawType"].ToString();
            lblCDVal.Text = _drFlaw["CD"].ToString();
            lblMDVal.Text = _drFlaw["MD"].ToString();
            lblLengthVal.Text = _drFlaw["Length"].ToString();
            lblWidthVal.Text = _drFlaw["Width"].ToString();
            lblAreaVal.Text = _drFlaw["Area"].ToString();
            // set about images
            for (int i = 0; i < JobHelper.JobInfo.NumberOfStations; i++)
            {
                tabImages.TabPages.Add("S" + ((i + 1).ToString()));
                _pb[i] = new PictureBox();
                _pb[i].SizeMode = PictureBoxSizeMode.Zoom;
                _pb[i].Location = new Point(0, 0);
                _pb[i].BackColor = Color.Transparent;
                _pb[i].MouseClick += new MouseEventHandler(pb_Click);
                tabImages.TabPages[i].AutoScroll = true;
                tabImages.TabPages[i].Controls.Add(_pb[i]);
                tabImages.TabPages[i].BackColor = Color.Transparent;
                tabImages.TabPages[i].Tag = 100;  // Zoom Multiplier value.
            }
            // deal if images return null show no-image.
            if (!_drFlaw.IsNull("Images"))
            {
                IList<IImageInfo> images = _drFlaw["Images"] as IList<IImageInfo>;
                foreach (IImageInfo image in images)
                {
                    _srcImages[image.Station] = image.Image;
                    _pbRatio[image.Station] = Init_Image(image.Image, tabImages.TabPages[image.Station], _pb[image.Station]);
                }
            }
            else
            {
                for (int i = 0; i < JobHelper.JobInfo.NumberOfStations; i++)
                {
                    _srcImages[i] = Resources.NoImage;
                    _pbRatio[i] = Init_Image(Resources.NoImage, tabImages.TabPages[i], _pb[i]);
                }
            }
        }
        public void pb_Click(object sender, MouseEventArgs e)
        {
            ftbImage.Focus();
        }
        private void ftbImage_Scroll(object sender, EventArgs e)
        {
            PicZoomByPercent(ftbImage.Value);
        }
        #endregion

       

    }
}
