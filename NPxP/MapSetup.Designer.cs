namespace NPxP
{
    partial class MapSetup
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblMapConfig = new System.Windows.Forms.Label();
            this.cmbMapConfigName = new System.Windows.Forms.ComboBox();
            this.grbImageSettings = new System.Windows.Forms.GroupBox();
            this.lblImgX = new System.Windows.Forms.Label();
            this.lblImgColumn = new System.Windows.Forms.Label();
            this.lblImgRow = new System.Windows.Forms.Label();
            this.nudImageRows = new System.Windows.Forms.NumericUpDown();
            this.nudImageColumns = new System.Windows.Forms.NumericUpDown();
            this.grbMapSettings = new System.Windows.Forms.GroupBox();
            this.chkCDInverse = new System.Windows.Forms.CheckBox();
            this.chkMDInverse = new System.Windows.Forms.CheckBox();
            this.cmbBottomAxes = new System.Windows.Forms.ComboBox();
            this.lblBottomAxie = new System.Windows.Forms.Label();
            this.pnlGridSizeSettings = new System.Windows.Forms.Panel();
            this.lblSCCD = new System.Windows.Forms.Label();
            this.lblSCMD = new System.Windows.Forms.Label();
            this.lbSCellCDUnit = new System.Windows.Forms.Label();
            this.lbSCellMDUnit = new System.Windows.Forms.Label();
            this.lblCountSizeCD = new System.Windows.Forms.Label();
            this.lblCountSizeMD = new System.Windows.Forms.Label();
            this.txtCountSizeCD = new System.Windows.Forms.TextBox();
            this.txtCountSizeMD = new System.Windows.Forms.TextBox();
            this.txtFixSizeCD = new System.Windows.Forms.TextBox();
            this.txtFixSizeMD = new System.Windows.Forms.TextBox();
            this.lblFixSizeCD = new System.Windows.Forms.Label();
            this.lblFixSizeMD = new System.Windows.Forms.Label();
            this.rdoCountSize = new System.Windows.Forms.RadioButton();
            this.rdoFixCellSize = new System.Windows.Forms.RadioButton();
            this.rdoMapGridOff = new System.Windows.Forms.RadioButton();
            this.rdoMapGridOn = new System.Windows.Forms.RadioButton();
            this.lblMapGridShow = new System.Windows.Forms.Label();
            this.cmbMapSize = new System.Windows.Forms.ComboBox();
            this.lblMapSize = new System.Windows.Forms.Label();
            this.gbSeriesSetting = new System.Windows.Forms.GroupBox();
            this.dgvFlawLegends = new System.Windows.Forms.DataGridView();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.grbImageSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudImageRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudImageColumns)).BeginInit();
            this.grbMapSettings.SuspendLayout();
            this.pnlGridSizeSettings.SuspendLayout();
            this.gbSeriesSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFlawLegends)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMapConfig
            // 
            this.lblMapConfig.AutoSize = true;
            this.lblMapConfig.Location = new System.Drawing.Point(269, 456);
            this.lblMapConfig.Name = "lblMapConfig";
            this.lblMapConfig.Size = new System.Drawing.Size(82, 12);
            this.lblMapConfig.TabIndex = 0;
            this.lblMapConfig.Text = "Map Config File";
            // 
            // cmbMapConfigName
            // 
            this.cmbMapConfigName.FormattingEnabled = true;
            this.cmbMapConfigName.Location = new System.Drawing.Point(354, 453);
            this.cmbMapConfigName.Name = "cmbMapConfigName";
            this.cmbMapConfigName.Size = new System.Drawing.Size(150, 20);
            this.cmbMapConfigName.TabIndex = 1;
            this.cmbMapConfigName.SelectedIndexChanged += new System.EventHandler(this.cmbMapConfigName_SelectedIndexChanged);
            // 
            // grbImageSettings
            // 
            this.grbImageSettings.Controls.Add(this.lblImgX);
            this.grbImageSettings.Controls.Add(this.lblImgColumn);
            this.grbImageSettings.Controls.Add(this.lblImgRow);
            this.grbImageSettings.Controls.Add(this.nudImageRows);
            this.grbImageSettings.Controls.Add(this.nudImageColumns);
            this.grbImageSettings.Location = new System.Drawing.Point(15, 36);
            this.grbImageSettings.Name = "grbImageSettings";
            this.grbImageSettings.Size = new System.Drawing.Size(251, 100);
            this.grbImageSettings.TabIndex = 3;
            this.grbImageSettings.TabStop = false;
            this.grbImageSettings.Text = "Image Grid Settings";
            // 
            // lblImgX
            // 
            this.lblImgX.AutoSize = true;
            this.lblImgX.Location = new System.Drawing.Point(63, 55);
            this.lblImgX.Name = "lblImgX";
            this.lblImgX.Size = new System.Drawing.Size(13, 12);
            this.lblImgX.TabIndex = 4;
            this.lblImgX.Text = "X";
            // 
            // lblImgColumn
            // 
            this.lblImgColumn.AutoSize = true;
            this.lblImgColumn.Location = new System.Drawing.Point(10, 25);
            this.lblImgColumn.Name = "lblImgColumn";
            this.lblImgColumn.Size = new System.Drawing.Size(47, 12);
            this.lblImgColumn.TabIndex = 3;
            this.lblImgColumn.Text = "Columns";
            // 
            // lblImgRow
            // 
            this.lblImgRow.AutoSize = true;
            this.lblImgRow.Location = new System.Drawing.Point(80, 25);
            this.lblImgRow.Name = "lblImgRow";
            this.lblImgRow.Size = new System.Drawing.Size(31, 12);
            this.lblImgRow.TabIndex = 2;
            this.lblImgRow.Text = "Rows";
            // 
            // nudImageRows
            // 
            this.nudImageRows.Location = new System.Drawing.Point(80, 50);
            this.nudImageRows.Name = "nudImageRows";
            this.nudImageRows.Size = new System.Drawing.Size(50, 22);
            this.nudImageRows.TabIndex = 1;
            // 
            // nudImageColumns
            // 
            this.nudImageColumns.Location = new System.Drawing.Point(10, 50);
            this.nudImageColumns.Name = "nudImageColumns";
            this.nudImageColumns.Size = new System.Drawing.Size(50, 22);
            this.nudImageColumns.TabIndex = 0;
            // 
            // grbMapSettings
            // 
            this.grbMapSettings.Controls.Add(this.chkCDInverse);
            this.grbMapSettings.Controls.Add(this.chkMDInverse);
            this.grbMapSettings.Controls.Add(this.cmbBottomAxes);
            this.grbMapSettings.Controls.Add(this.lblBottomAxie);
            this.grbMapSettings.Controls.Add(this.pnlGridSizeSettings);
            this.grbMapSettings.Controls.Add(this.rdoMapGridOff);
            this.grbMapSettings.Controls.Add(this.rdoMapGridOn);
            this.grbMapSettings.Controls.Add(this.lblMapGridShow);
            this.grbMapSettings.Controls.Add(this.cmbMapSize);
            this.grbMapSettings.Controls.Add(this.lblMapSize);
            this.grbMapSettings.Location = new System.Drawing.Point(15, 142);
            this.grbMapSettings.Name = "grbMapSettings";
            this.grbMapSettings.Size = new System.Drawing.Size(251, 302);
            this.grbMapSettings.TabIndex = 4;
            this.grbMapSettings.TabStop = false;
            this.grbMapSettings.Text = "Map Settings";
            // 
            // chkCDInverse
            // 
            this.chkCDInverse.AutoSize = true;
            this.chkCDInverse.Location = new System.Drawing.Point(113, 272);
            this.chkCDInverse.Name = "chkCDInverse";
            this.chkCDInverse.Size = new System.Drawing.Size(77, 16);
            this.chkCDInverse.TabIndex = 9;
            this.chkCDInverse.Text = "CD Inverse";
            this.chkCDInverse.UseVisualStyleBackColor = true;
            // 
            // chkMDInverse
            // 
            this.chkMDInverse.AutoSize = true;
            this.chkMDInverse.Location = new System.Drawing.Point(12, 273);
            this.chkMDInverse.Name = "chkMDInverse";
            this.chkMDInverse.Size = new System.Drawing.Size(79, 16);
            this.chkMDInverse.TabIndex = 8;
            this.chkMDInverse.Text = "MD Inverse";
            this.chkMDInverse.UseVisualStyleBackColor = true;
            // 
            // cmbBottomAxes
            // 
            this.cmbBottomAxes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBottomAxes.FormattingEnabled = true;
            this.cmbBottomAxes.Items.AddRange(new object[] {
            "CD",
            "MD"});
            this.cmbBottomAxes.Location = new System.Drawing.Point(113, 228);
            this.cmbBottomAxes.Name = "cmbBottomAxes";
            this.cmbBottomAxes.Size = new System.Drawing.Size(121, 20);
            this.cmbBottomAxes.TabIndex = 7;
            // 
            // lblBottomAxie
            // 
            this.lblBottomAxie.AutoSize = true;
            this.lblBottomAxie.Location = new System.Drawing.Point(10, 232);
            this.lblBottomAxie.Name = "lblBottomAxie";
            this.lblBottomAxie.Size = new System.Drawing.Size(66, 12);
            this.lblBottomAxie.TabIndex = 6;
            this.lblBottomAxie.Text = "Bottom Axes";
            // 
            // pnlGridSizeSettings
            // 
            this.pnlGridSizeSettings.Controls.Add(this.lblSCCD);
            this.pnlGridSizeSettings.Controls.Add(this.lblSCMD);
            this.pnlGridSizeSettings.Controls.Add(this.lbSCellCDUnit);
            this.pnlGridSizeSettings.Controls.Add(this.lbSCellMDUnit);
            this.pnlGridSizeSettings.Controls.Add(this.lblCountSizeCD);
            this.pnlGridSizeSettings.Controls.Add(this.lblCountSizeMD);
            this.pnlGridSizeSettings.Controls.Add(this.txtCountSizeCD);
            this.pnlGridSizeSettings.Controls.Add(this.txtCountSizeMD);
            this.pnlGridSizeSettings.Controls.Add(this.txtFixSizeCD);
            this.pnlGridSizeSettings.Controls.Add(this.txtFixSizeMD);
            this.pnlGridSizeSettings.Controls.Add(this.lblFixSizeCD);
            this.pnlGridSizeSettings.Controls.Add(this.lblFixSizeMD);
            this.pnlGridSizeSettings.Controls.Add(this.rdoCountSize);
            this.pnlGridSizeSettings.Controls.Add(this.rdoFixCellSize);
            this.pnlGridSizeSettings.Location = new System.Drawing.Point(12, 76);
            this.pnlGridSizeSettings.Name = "pnlGridSizeSettings";
            this.pnlGridSizeSettings.Size = new System.Drawing.Size(222, 144);
            this.pnlGridSizeSettings.TabIndex = 5;
            // 
            // lblSCCD
            // 
            this.lblSCCD.AutoSize = true;
            this.lblSCCD.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblSCCD.Location = new System.Drawing.Point(179, 49);
            this.lblSCCD.Name = "lblSCCD";
            this.lblSCCD.Size = new System.Drawing.Size(23, 12);
            this.lblSCCD.TabIndex = 13;
            this.lblSCCD.Text = "mm";
            // 
            // lblSCMD
            // 
            this.lblSCMD.AutoSize = true;
            this.lblSCMD.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblSCMD.Location = new System.Drawing.Point(179, 22);
            this.lblSCMD.Name = "lblSCMD";
            this.lblSCMD.Size = new System.Drawing.Size(23, 12);
            this.lblSCMD.TabIndex = 12;
            this.lblSCMD.Text = "mm";
            // 
            // lbSCellCDUnit
            // 
            this.lbSCellCDUnit.AutoSize = true;
            this.lbSCellCDUnit.Location = new System.Drawing.Point(178, 45);
            this.lbSCellCDUnit.Name = "lbSCellCDUnit";
            this.lbSCellCDUnit.Size = new System.Drawing.Size(0, 12);
            this.lbSCellCDUnit.TabIndex = 11;
            // 
            // lbSCellMDUnit
            // 
            this.lbSCellMDUnit.AutoSize = true;
            this.lbSCellMDUnit.Location = new System.Drawing.Point(184, 17);
            this.lbSCellMDUnit.Name = "lbSCellMDUnit";
            this.lbSCellMDUnit.Size = new System.Drawing.Size(0, 12);
            this.lbSCellMDUnit.TabIndex = 10;
            // 
            // lblCountSizeCD
            // 
            this.lblCountSizeCD.AutoSize = true;
            this.lblCountSizeCD.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblCountSizeCD.Location = new System.Drawing.Point(120, 108);
            this.lblCountSizeCD.Name = "lblCountSizeCD";
            this.lblCountSizeCD.Size = new System.Drawing.Size(21, 12);
            this.lblCountSizeCD.TabIndex = 9;
            this.lblCountSizeCD.Text = "CD";
            // 
            // lblCountSizeMD
            // 
            this.lblCountSizeMD.AutoSize = true;
            this.lblCountSizeMD.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblCountSizeMD.Location = new System.Drawing.Point(118, 80);
            this.lblCountSizeMD.Name = "lblCountSizeMD";
            this.lblCountSizeMD.Size = new System.Drawing.Size(23, 12);
            this.lblCountSizeMD.TabIndex = 8;
            this.lblCountSizeMD.Text = "MD";
            // 
            // txtCountSizeCD
            // 
            this.txtCountSizeCD.Location = new System.Drawing.Point(144, 103);
            this.txtCountSizeCD.Name = "txtCountSizeCD";
            this.txtCountSizeCD.Size = new System.Drawing.Size(34, 22);
            this.txtCountSizeCD.TabIndex = 7;
            this.txtCountSizeCD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCountSizeCD_KeyPress);
            // 
            // txtCountSizeMD
            // 
            this.txtCountSizeMD.Location = new System.Drawing.Point(144, 75);
            this.txtCountSizeMD.Name = "txtCountSizeMD";
            this.txtCountSizeMD.Size = new System.Drawing.Size(34, 22);
            this.txtCountSizeMD.TabIndex = 6;
            this.txtCountSizeMD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCountSizeMD_KeyPress);
            // 
            // txtFixSizeCD
            // 
            this.txtFixSizeCD.Location = new System.Drawing.Point(144, 40);
            this.txtFixSizeCD.Name = "txtFixSizeCD";
            this.txtFixSizeCD.Size = new System.Drawing.Size(34, 22);
            this.txtFixSizeCD.TabIndex = 5;
            this.txtFixSizeCD.TextChanged += new System.EventHandler(this.Double_Validation);
            this.txtFixSizeCD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFixSizeCD_KeyPress);
            // 
            // txtFixSizeMD
            // 
            this.txtFixSizeMD.Location = new System.Drawing.Point(144, 12);
            this.txtFixSizeMD.Name = "txtFixSizeMD";
            this.txtFixSizeMD.Size = new System.Drawing.Size(34, 22);
            this.txtFixSizeMD.TabIndex = 4;
            this.txtFixSizeMD.TextChanged += new System.EventHandler(this.Double_Validation);
            this.txtFixSizeMD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFixSizeMD_KeyPress);
            // 
            // lblFixSizeCD
            // 
            this.lblFixSizeCD.AutoSize = true;
            this.lblFixSizeCD.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblFixSizeCD.Location = new System.Drawing.Point(120, 45);
            this.lblFixSizeCD.Name = "lblFixSizeCD";
            this.lblFixSizeCD.Size = new System.Drawing.Size(21, 12);
            this.lblFixSizeCD.TabIndex = 3;
            this.lblFixSizeCD.Text = "CD";
            // 
            // lblFixSizeMD
            // 
            this.lblFixSizeMD.AutoSize = true;
            this.lblFixSizeMD.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblFixSizeMD.Location = new System.Drawing.Point(118, 17);
            this.lblFixSizeMD.Name = "lblFixSizeMD";
            this.lblFixSizeMD.Size = new System.Drawing.Size(23, 12);
            this.lblFixSizeMD.TabIndex = 2;
            this.lblFixSizeMD.Text = "MD";
            // 
            // rdoCountSize
            // 
            this.rdoCountSize.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.rdoCountSize.Location = new System.Drawing.Point(11, 72);
            this.rdoCountSize.Name = "rdoCountSize";
            this.rdoCountSize.Size = new System.Drawing.Size(200, 60);
            this.rdoCountSize.TabIndex = 1;
            this.rdoCountSize.TabStop = true;
            this.rdoCountSize.Text = "Equal Cell Count";
            this.rdoCountSize.UseVisualStyleBackColor = false;
            this.rdoCountSize.CheckedChanged += new System.EventHandler(this.rdoCountSize_CheckedChanged);
            // 
            // rdoFixCellSize
            // 
            this.rdoFixCellSize.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.rdoFixCellSize.Location = new System.Drawing.Point(11, 7);
            this.rdoFixCellSize.Name = "rdoFixCellSize";
            this.rdoFixCellSize.Size = new System.Drawing.Size(200, 60);
            this.rdoFixCellSize.TabIndex = 0;
            this.rdoFixCellSize.TabStop = true;
            this.rdoFixCellSize.Text = "Specify Cell Size";
            this.rdoFixCellSize.UseVisualStyleBackColor = false;
            this.rdoFixCellSize.CheckedChanged += new System.EventHandler(this.rdoFixCellSize_CheckedChanged);
            // 
            // rdoMapGridOff
            // 
            this.rdoMapGridOff.AutoSize = true;
            this.rdoMapGridOff.Location = new System.Drawing.Point(156, 45);
            this.rdoMapGridOff.Name = "rdoMapGridOff";
            this.rdoMapGridOff.Size = new System.Drawing.Size(39, 16);
            this.rdoMapGridOff.TabIndex = 4;
            this.rdoMapGridOff.TabStop = true;
            this.rdoMapGridOff.Text = "Off";
            this.rdoMapGridOff.UseVisualStyleBackColor = true;
            // 
            // rdoMapGridOn
            // 
            this.rdoMapGridOn.AutoSize = true;
            this.rdoMapGridOn.Location = new System.Drawing.Point(113, 44);
            this.rdoMapGridOn.Name = "rdoMapGridOn";
            this.rdoMapGridOn.Size = new System.Drawing.Size(37, 16);
            this.rdoMapGridOn.TabIndex = 3;
            this.rdoMapGridOn.TabStop = true;
            this.rdoMapGridOn.Text = "On";
            this.rdoMapGridOn.UseVisualStyleBackColor = true;
            // 
            // lblMapGridShow
            // 
            this.lblMapGridShow.AutoSize = true;
            this.lblMapGridShow.Location = new System.Drawing.Point(10, 48);
            this.lblMapGridShow.Name = "lblMapGridShow";
            this.lblMapGridShow.Size = new System.Drawing.Size(79, 12);
            this.lblMapGridShow.TabIndex = 2;
            this.lblMapGridShow.Text = "Map Grid Show";
            // 
            // cmbMapSize
            // 
            this.cmbMapSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMapSize.FormattingEnabled = true;
            this.cmbMapSize.Items.AddRange(new object[] {
            "1:1",
            "2:1",
            "4:3",
            "3:4",
            "16:9"});
            this.cmbMapSize.Location = new System.Drawing.Point(113, 21);
            this.cmbMapSize.Name = "cmbMapSize";
            this.cmbMapSize.Size = new System.Drawing.Size(121, 20);
            this.cmbMapSize.TabIndex = 1;
            // 
            // lblMapSize
            // 
            this.lblMapSize.AutoSize = true;
            this.lblMapSize.Location = new System.Drawing.Point(10, 22);
            this.lblMapSize.Name = "lblMapSize";
            this.lblMapSize.Size = new System.Drawing.Size(48, 12);
            this.lblMapSize.TabIndex = 0;
            this.lblMapSize.Text = "Map Size";
            // 
            // gbSeriesSetting
            // 
            this.gbSeriesSetting.Controls.Add(this.dgvFlawLegends);
            this.gbSeriesSetting.Location = new System.Drawing.Point(278, 36);
            this.gbSeriesSetting.Name = "gbSeriesSetting";
            this.gbSeriesSetting.Size = new System.Drawing.Size(394, 409);
            this.gbSeriesSetting.TabIndex = 5;
            this.gbSeriesSetting.TabStop = false;
            this.gbSeriesSetting.Text = "Series Settings";
            // 
            // dgvFlawLegends
            // 
            this.dgvFlawLegends.AllowUserToAddRows = false;
            this.dgvFlawLegends.AllowUserToDeleteRows = false;
            this.dgvFlawLegends.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFlawLegends.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFlawLegends.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvFlawLegends.Location = new System.Drawing.Point(6, 25);
            this.dgvFlawLegends.Name = "dgvFlawLegends";
            this.dgvFlawLegends.RowHeadersVisible = false;
            this.dgvFlawLegends.RowTemplate.Height = 24;
            this.dgvFlawLegends.Size = new System.Drawing.Size(382, 326);
            this.dgvFlawLegends.TabIndex = 2;
            this.dgvFlawLegends.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvFlawLegends_CellFormatting);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(591, 451);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 9;
            this.btnConfirm.Text = "Close";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(510, 451);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // MapSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 512);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gbSeriesSetting);
            this.Controls.Add(this.grbMapSettings);
            this.Controls.Add(this.grbImageSettings);
            this.Controls.Add(this.cmbMapConfigName);
            this.Controls.Add(this.lblMapConfig);
            this.Name = "MapSetup";
            this.Text = "MapSetup";
            this.Load += new System.EventHandler(this.MapSetup_Load);
            this.grbImageSettings.ResumeLayout(false);
            this.grbImageSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudImageRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudImageColumns)).EndInit();
            this.grbMapSettings.ResumeLayout(false);
            this.grbMapSettings.PerformLayout();
            this.pnlGridSizeSettings.ResumeLayout(false);
            this.pnlGridSizeSettings.PerformLayout();
            this.gbSeriesSetting.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFlawLegends)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMapConfig;
        private System.Windows.Forms.ComboBox cmbMapConfigName;
        private System.Windows.Forms.GroupBox grbImageSettings;
        private System.Windows.Forms.Label lblImgX;
        private System.Windows.Forms.Label lblImgColumn;
        private System.Windows.Forms.Label lblImgRow;
        public System.Windows.Forms.NumericUpDown nudImageRows;
        public System.Windows.Forms.NumericUpDown nudImageColumns;
        private System.Windows.Forms.GroupBox grbMapSettings;
        private System.Windows.Forms.CheckBox chkCDInverse;
        private System.Windows.Forms.CheckBox chkMDInverse;
        private System.Windows.Forms.ComboBox cmbBottomAxes;
        private System.Windows.Forms.Label lblBottomAxie;
        private System.Windows.Forms.Panel pnlGridSizeSettings;
        private System.Windows.Forms.Label lblSCCD;
        private System.Windows.Forms.Label lblSCMD;
        private System.Windows.Forms.Label lbSCellCDUnit;
        private System.Windows.Forms.Label lbSCellMDUnit;
        private System.Windows.Forms.Label lblCountSizeCD;
        private System.Windows.Forms.Label lblCountSizeMD;
        private System.Windows.Forms.TextBox txtCountSizeCD;
        private System.Windows.Forms.TextBox txtCountSizeMD;
        private System.Windows.Forms.TextBox txtFixSizeCD;
        private System.Windows.Forms.TextBox txtFixSizeMD;
        private System.Windows.Forms.Label lblFixSizeCD;
        private System.Windows.Forms.Label lblFixSizeMD;
        private System.Windows.Forms.RadioButton rdoCountSize;
        private System.Windows.Forms.RadioButton rdoFixCellSize;
        private System.Windows.Forms.RadioButton rdoMapGridOff;
        private System.Windows.Forms.RadioButton rdoMapGridOn;
        private System.Windows.Forms.Label lblMapGridShow;
        private System.Windows.Forms.ComboBox cmbMapSize;
        private System.Windows.Forms.Label lblMapSize;
        private System.Windows.Forms.GroupBox gbSeriesSetting;
        private System.Windows.Forms.DataGridView dgvFlawLegends;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnSave;
    }
}