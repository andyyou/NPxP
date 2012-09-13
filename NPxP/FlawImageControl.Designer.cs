namespace NPxP
{
    partial class FlawImageControl
    {
        /// <summary> 
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改這個方法的內容。
        ///
        /// </summary>
        private void InitializeComponent()
        {
            this.tabImages = new System.Windows.Forms.TabControl();
            this.lblFlawID = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tabImages
            // 
            this.tabImages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabImages.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabImages.Location = new System.Drawing.Point(4, 24);
            this.tabImages.Name = "tabImages";
            this.tabImages.SelectedIndex = 0;
            this.tabImages.Size = new System.Drawing.Size(202, 119);
            this.tabImages.TabIndex = 2;
            this.tabImages.Click += new System.EventHandler(this.tabImages_Click);
            this.tabImages.SelectedIndexChanged += new System.EventHandler(this.tabImages_SelectedIndexChanged);
            // 
            // lblFlawID
            // 
            this.lblFlawID.AutoSize = true;
            this.lblFlawID.BackColor = System.Drawing.Color.Transparent;
            this.lblFlawID.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblFlawID.Location = new System.Drawing.Point(3, 4);
            this.lblFlawID.Name = "lblFlawID";
            this.lblFlawID.Size = new System.Drawing.Size(54, 16);
            this.lblFlawID.TabIndex = 3;
            this.lblFlawID.Text = "FlawID : ";
            // 
            // FlawImageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.tabImages);
            this.Controls.Add(this.lblFlawID);
            this.Name = "FlawImageControl";
            this.Size = new System.Drawing.Size(210, 150);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FlawImageControl_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabImages;
        private System.Windows.Forms.Label lblFlawID;
    }
}
