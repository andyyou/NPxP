namespace NPxP
{
    partial class PxPTab
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
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvFlaw = new System.Windows.Forms.DataGridView();
            this.tlpFlawImages = new System.Windows.Forms.TableLayoutPanel();
            this.btnProvFlawImages = new System.Windows.Forms.Button();
            this.btnNextFlawImages = new System.Windows.Forms.Button();
            this.lblSlash = new System.Windows.Forms.Label();
            this.lblTotalPage = new System.Windows.Forms.Label();
            this.lblNowPage = new System.Windows.Forms.Label();
            this.btnShowGoPage = new System.Windows.Forms.Button();
            this.txtGoPage = new System.Windows.Forms.TextBox();
            this.btnGo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFlaw)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvFlaw
            // 
            this.dgvFlaw.AllowUserToAddRows = false;
            this.dgvFlaw.AllowUserToDeleteRows = false;
            this.dgvFlaw.AllowUserToOrderColumns = true;
            this.dgvFlaw.AllowUserToResizeRows = false;
            this.dgvFlaw.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFlaw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFlaw.Location = new System.Drawing.Point(12, 12);
            this.dgvFlaw.Name = "dgvFlaw";
            this.dgvFlaw.ReadOnly = true;
            this.dgvFlaw.RowHeadersVisible = false;
            this.dgvFlaw.RowTemplate.Height = 24;
            this.dgvFlaw.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFlaw.Size = new System.Drawing.Size(735, 140);
            this.dgvFlaw.TabIndex = 0;
            this.dgvFlaw.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFlaw_CellDoubleClick);
            this.dgvFlaw.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvFlaw_ColumnHeaderMouseClick);
            this.dgvFlaw.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvFlaw_CellFormatting);
            // 
            // tlpFlawImages
            // 
            this.tlpFlawImages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpFlawImages.BackColor = System.Drawing.Color.Transparent;
            this.tlpFlawImages.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpFlawImages.ColumnCount = 2;
            this.tlpFlawImages.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpFlawImages.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpFlawImages.Location = new System.Drawing.Point(12, 158);
            this.tlpFlawImages.Name = "tlpFlawImages";
            this.tlpFlawImages.RowCount = 2;
            this.tlpFlawImages.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpFlawImages.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpFlawImages.Size = new System.Drawing.Size(735, 524);
            this.tlpFlawImages.TabIndex = 1;
            // 
            // btnProvFlawImages
            // 
            this.btnProvFlawImages.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnProvFlawImages.Enabled = false;
            this.btnProvFlawImages.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnProvFlawImages.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnProvFlawImages.Location = new System.Drawing.Point(177, 688);
            this.btnProvFlawImages.Name = "btnProvFlawImages";
            this.btnProvFlawImages.Size = new System.Drawing.Size(52, 41);
            this.btnProvFlawImages.TabIndex = 2;
            this.btnProvFlawImages.Text = "<";
            this.btnProvFlawImages.UseVisualStyleBackColor = true;
            this.btnProvFlawImages.Click += new System.EventHandler(this.btnProvFlawImages_Click);
            // 
            // btnNextFlawImages
            // 
            this.btnNextFlawImages.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNextFlawImages.Enabled = false;
            this.btnNextFlawImages.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnNextFlawImages.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnNextFlawImages.Location = new System.Drawing.Point(502, 688);
            this.btnNextFlawImages.Name = "btnNextFlawImages";
            this.btnNextFlawImages.Size = new System.Drawing.Size(52, 41);
            this.btnNextFlawImages.TabIndex = 3;
            this.btnNextFlawImages.Text = ">";
            this.btnNextFlawImages.UseVisualStyleBackColor = true;
            this.btnNextFlawImages.Click += new System.EventHandler(this.btnNextFlawImages_Click);
            // 
            // lblSlash
            // 
            this.lblSlash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSlash.AutoSize = true;
            this.lblSlash.BackColor = System.Drawing.Color.Transparent;
            this.lblSlash.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblSlash.Location = new System.Drawing.Point(367, 700);
            this.lblSlash.Name = "lblSlash";
            this.lblSlash.Size = new System.Drawing.Size(14, 19);
            this.lblSlash.TabIndex = 4;
            this.lblSlash.Text = "/";
            // 
            // lblTotalPage
            // 
            this.lblTotalPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotalPage.AutoSize = true;
            this.lblTotalPage.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalPage.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblTotalPage.Location = new System.Drawing.Point(396, 700);
            this.lblTotalPage.Name = "lblTotalPage";
            this.lblTotalPage.Size = new System.Drawing.Size(27, 19);
            this.lblTotalPage.TabIndex = 5;
            this.lblTotalPage.Text = "---";
            // 
            // lblNowPage
            // 
            this.lblNowPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNowPage.AutoSize = true;
            this.lblNowPage.BackColor = System.Drawing.Color.Transparent;
            this.lblNowPage.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblNowPage.Location = new System.Drawing.Point(321, 700);
            this.lblNowPage.Name = "lblNowPage";
            this.lblNowPage.Size = new System.Drawing.Size(27, 19);
            this.lblNowPage.TabIndex = 6;
            this.lblNowPage.Text = "---";
            // 
            // btnShowGoPage
            // 
            this.btnShowGoPage.Location = new System.Drawing.Point(599, 688);
            this.btnShowGoPage.Name = "btnShowGoPage";
            this.btnShowGoPage.Size = new System.Drawing.Size(130, 41);
            this.btnShowGoPage.TabIndex = 7;
            this.btnShowGoPage.TabStop = false;
            this.btnShowGoPage.Text = "切換頁面";
            this.btnShowGoPage.UseVisualStyleBackColor = true;
            this.btnShowGoPage.Click += new System.EventHandler(this.btnShowGoPage_Click);
            // 
            // txtGoPage
            // 
            this.txtGoPage.Location = new System.Drawing.Point(607, 699);
            this.txtGoPage.Name = "txtGoPage";
            this.txtGoPage.Size = new System.Drawing.Size(57, 22);
            this.txtGoPage.TabIndex = 8;
            this.txtGoPage.TabStop = false;
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(667, 697);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(54, 26);
            this.btnGo.TabIndex = 9;
            this.btnGo.TabStop = false;
            this.btnGo.Text = "OK";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // PxPTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::NPxP.Properties.Resources.BackgroundRight;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.btnShowGoPage);
            this.Controls.Add(this.lblNowPage);
            this.Controls.Add(this.lblTotalPage);
            this.Controls.Add(this.lblSlash);
            this.Controls.Add(this.btnNextFlawImages);
            this.Controls.Add(this.btnProvFlawImages);
            this.Controls.Add(this.tlpFlawImages);
            this.Controls.Add(this.dgvFlaw);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtGoPage);
            this.Name = "PxPTab";
            this.Size = new System.Drawing.Size(760, 747);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFlaw)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvFlaw;
        public System.Windows.Forms.TableLayoutPanel tlpFlawImages;
        private System.Windows.Forms.Button btnProvFlawImages;
        private System.Windows.Forms.Button btnNextFlawImages;
        private System.Windows.Forms.Label lblSlash;
        private System.Windows.Forms.Label lblTotalPage;
        private System.Windows.Forms.Label lblNowPage;
        private System.Windows.Forms.Button btnShowGoPage;
        private System.Windows.Forms.TextBox txtGoPage;
        private System.Windows.Forms.Button btnGo;
    }
}
