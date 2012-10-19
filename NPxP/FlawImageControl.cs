﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel.Composition;
using WRPlugIn;
using NPxP.Helper;
using NPxP.Properties;
using NPxP.Model;

namespace NPxP
{
    public partial class FlawImageControl : UserControl
    {
        #region Local Variables

        private DataRow _drFlaw;
        private PictureBox[] _pb;
        private double[] _pbRatio;
        private Image[] _srcImages;
        private List<NowUnit> _units;

        #endregion

        #region Properties

        public bool IsDrawBorder { set; get; }

        #endregion

        #region Constructor

        public FlawImageControl(DataRow drFlaw, ref List<NowUnit> units)
        {
            InitializeComponent();
            Boolean isSelectedTab = false;
            this._drFlaw = drFlaw;
            this._units = units;
            IsDrawBorder = false;
            lblFlawID.Text += drFlaw["FlawID"].ToString();
            _pb = new PictureBox[JobHelper.JobInfo.NumberOfStations];
            _pbRatio = new double[JobHelper.JobInfo.NumberOfStations];
            _srcImages = new Image[JobHelper.JobInfo.NumberOfStations];

            for (int i = 0; i < JobHelper.JobInfo.NumberOfStations; i++)
            {
                tabImages.TabPages.Add("S" + ((i + 1).ToString()));
                _pb[i] = new PictureBox();
                _pb[i].SizeMode = PictureBoxSizeMode.Zoom;
                _pb[i].Location = new Point(0, 0);
                _pb[i].BackColor = Color.Transparent;
                _pb[i].MouseClick += new MouseEventHandler(pb_Click);
                _pb[i].MouseDoubleClick += new MouseEventHandler(pb_MouseDoubleClick);
                tabImages.TabPages[i].AutoScroll = true;
                tabImages.TabPages[i].Controls.Add(_pb[i]);
                tabImages.TabPages[i].BackColor = Color.Transparent;
                tabImages.TabPages[i].Tag = 100;  // Zoom Multiplier value.
            }
            if (!drFlaw.IsNull("Images"))
            {
                IList<IImageInfo> images = drFlaw["Images"] as IList<IImageInfo>;
                foreach (IImageInfo image in images)
                {
                    _srcImages[image.Station] = image.Image;
                    _pbRatio[image.Station] = Init_Image(image.Image, tabImages.TabPages[image.Station], _pb[image.Station]);
                    if (!isSelectedTab)
                    {
                        tabImages.SelectedTab = tabImages.TabPages[image.Station];
                        isSelectedTab = true;
                    }
                }
                for (int i = 0; i < JobHelper.JobInfo.NumberOfStations; i++)
                {
                    if (_srcImages[i] == null)
                    {
                        _srcImages[i] = Resources.NoImage;
                        _pbRatio[i] = Init_Image(Resources.NoImage, tabImages.TabPages[i], _pb[i]);
                    }
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

        #endregion

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

        #region Action Methods

        private void tabImages_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (((TabControl)sender).IsHandleCreated)
                {
                    IList<IImageInfo> images = _drFlaw["Images"] as IList<IImageInfo>;
                    foreach (IImageInfo image in images)
                    {
                        Init_Image(image.Image, tabImages.TabPages[image.Station], _pb[image.Station]);
                    }
                }
            }
            catch
            {
                WriteHelper.ErrorLog("tabImages_SelectedIndexChanged()"); 
            }
        }

        public void pb_Click(object sender, MouseEventArgs e)
        {
            JobHelper.Job.SetOffline();
            if (e.Button == MouseButtons.Right)
            {
                int multiliper = (int)tabImages.SelectedTab.Tag;
                if (multiliper < 100)
                {
                    multiliper = 50;
                    PicZoomByPercent(multiliper);
                }
                else
                {
                    multiliper = multiliper - 50;
                    PicZoomByPercent(multiliper);
                }
                tabImages.SelectedTab.Tag = multiliper;
            }
            else if (e.Button == MouseButtons.Left)
            {
                int multiliper = (int)tabImages.SelectedTab.Tag;
                if (multiliper < 200)
                {
                    multiliper = multiliper + 50;
                    PicZoomByPercent(multiliper);
                }
                else
                {
                    multiliper = 200;
                    PicZoomByPercent(multiliper);
                }
                tabImages.SelectedTab.Tag = multiliper;
            }
        }

        public void pb_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                JobHelper.Job.SetOffline();
                FlawForm ff = new FlawForm(_drFlaw, _units);
                ff.ShowDialog();
            }
        }

        private void FlawImageControl_Paint(object sender, PaintEventArgs e)
        {
            if (IsDrawBorder)
            {
                var borderColor = Color.FromArgb(255, 0, 0);
                var borderStyle = ButtonBorderStyle.Solid;
                var borderWidth = 3;

                ControlPaint.DrawBorder(
                                    e.Graphics,
                                    this.ClientRectangle,
                                    borderColor,
                                    borderWidth,
                                    borderStyle,
                                    borderColor,
                                    borderWidth,
                                    borderStyle,
                                    borderColor,
                                    borderWidth,
                                    borderStyle,
                                    borderColor,
                                    borderWidth,
                                    borderStyle);
            }
        }

        private void tabImages_Click(object sender, EventArgs e)
        {
            var c = from controls in this.Parent.Controls.OfType<FlawImageControl>()
                    select controls;
            foreach (Control control in c)
            {
                if (control.GetType().Name == "FlawImageControl")
                {
                    FlawImageControl fi = (FlawImageControl)control;
                    fi.IsDrawBorder = false;
                    fi.Invalidate();
                }
            }

            IsDrawBorder = true;
            this.Invalidate();
            DataGridView dgv = (DataGridView)this.Parent.Parent.Controls.Find("dgvFlaw", true)[0];
            DataGridViewRow row = dgv.Rows
            .Cast<DataGridViewRow>()
            .Where(r => r.Cells["FlawID"].Value.ToString().Equals(_drFlaw["FlawID"].ToString()))
            .First();
            row.Selected = true;
            dgv.FirstDisplayedScrollingRowIndex = row.Index;

        }

        #endregion    
    }
}
