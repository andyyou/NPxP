namespace NPxP
{
    partial class GradeSetup
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
            this.tabGradeSetup = new System.Windows.Forms.TabControl();
            this.tpROI = new System.Windows.Forms.TabPage();
            this.pnlRoiGrid = new System.Windows.Forms.Panel();
            this.lbShowGvRow = new System.Windows.Forms.Label();
            this.lbShowGvColumn = new System.Windows.Forms.Label();
            this.gvRows = new System.Windows.Forms.DataGridView();
            this.gvColumns = new System.Windows.Forms.DataGridView();
            this.btnCreateGrid = new System.Windows.Forms.Button();
            this.lblX = new System.Windows.Forms.Label();
            this.lbRows = new System.Windows.Forms.Label();
            this.lbColumns = new System.Windows.Forms.Label();
            this.txtColumns = new System.Windows.Forms.TextBox();
            this.txtRows = new System.Windows.Forms.TextBox();
            this.grbRoiMode = new System.Windows.Forms.GroupBox();
            this.rdoSymmetrical = new System.Windows.Forms.RadioButton();
            this.rdoNoRoi = new System.Windows.Forms.RadioButton();
            this.tpGradeGroup = new System.Windows.Forms.TabPage();
            this.tabGradeSetting = new System.Windows.Forms.TabControl();
            this.tpPoint = new System.Windows.Forms.TabPage();
            this.gbPointSetting = new System.Windows.Forms.GroupBox();
            this.cboxAllSameOfPoint = new System.Windows.Forms.CheckBox();
            this.gvPoint = new System.Windows.Forms.DataGridView();
            this.lbSubPieceOfPoint = new System.Windows.Forms.Label();
            this.cboxSubPieceOfPoint = new System.Windows.Forms.ComboBox();
            this.cboxEnablePTS = new System.Windows.Forms.CheckBox();
            this.tpGradeLevel = new System.Windows.Forms.TabPage();
            this.cboxEnableGrade = new System.Windows.Forms.CheckBox();
            this.gbGradeSetting = new System.Windows.Forms.GroupBox();
            this.cboxAllSameOfGrade = new System.Windows.Forms.CheckBox();
            this.gvGrade = new System.Windows.Forms.DataGridView();
            this.lbSubPieceOfGrade = new System.Windows.Forms.Label();
            this.cboxSubPieceOfGrade = new System.Windows.Forms.ComboBox();
            this.tpPassOrFail = new System.Windows.Forms.TabPage();
            this.lbScore = new System.Windows.Forms.Label();
            this.txtFilterScore = new System.Windows.Forms.TextBox();
            this.cboxEnablePFS = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSaveGradeConfigFile = new System.Windows.Forms.Button();
            this.lblGradeConfig = new System.Windows.Forms.Label();
            this.cmbGradeConfigFiles = new System.Windows.Forms.ComboBox();
            this.tabGradeSetup.SuspendLayout();
            this.tpROI.SuspendLayout();
            this.pnlRoiGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvColumns)).BeginInit();
            this.grbRoiMode.SuspendLayout();
            this.tpGradeGroup.SuspendLayout();
            this.tabGradeSetting.SuspendLayout();
            this.tpPoint.SuspendLayout();
            this.gbPointSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvPoint)).BeginInit();
            this.tpGradeLevel.SuspendLayout();
            this.gbGradeSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvGrade)).BeginInit();
            this.tpPassOrFail.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabGradeSetup
            // 
            this.tabGradeSetup.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabGradeSetup.Controls.Add(this.tpROI);
            this.tabGradeSetup.Controls.Add(this.tpGradeGroup);
            this.tabGradeSetup.Location = new System.Drawing.Point(9, 9);
            this.tabGradeSetup.Margin = new System.Windows.Forms.Padding(0);
            this.tabGradeSetup.Name = "tabGradeSetup";
            this.tabGradeSetup.Padding = new System.Drawing.Point(0, 0);
            this.tabGradeSetup.SelectedIndex = 0;
            this.tabGradeSetup.Size = new System.Drawing.Size(527, 451);
            this.tabGradeSetup.TabIndex = 1;
            // 
            // tpROI
            // 
            this.tpROI.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tpROI.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tpROI.Controls.Add(this.pnlRoiGrid);
            this.tpROI.Controls.Add(this.grbRoiMode);
            this.tpROI.Location = new System.Drawing.Point(4, 25);
            this.tpROI.Margin = new System.Windows.Forms.Padding(0);
            this.tpROI.Name = "tpROI";
            this.tpROI.Size = new System.Drawing.Size(519, 422);
            this.tpROI.TabIndex = 0;
            this.tpROI.Text = "ROI Setting";
            // 
            // pnlRoiGrid
            // 
            this.pnlRoiGrid.Controls.Add(this.lbShowGvRow);
            this.pnlRoiGrid.Controls.Add(this.lbShowGvColumn);
            this.pnlRoiGrid.Controls.Add(this.gvRows);
            this.pnlRoiGrid.Controls.Add(this.gvColumns);
            this.pnlRoiGrid.Controls.Add(this.btnCreateGrid);
            this.pnlRoiGrid.Controls.Add(this.lblX);
            this.pnlRoiGrid.Controls.Add(this.lbRows);
            this.pnlRoiGrid.Controls.Add(this.lbColumns);
            this.pnlRoiGrid.Controls.Add(this.txtColumns);
            this.pnlRoiGrid.Controls.Add(this.txtRows);
            this.pnlRoiGrid.Location = new System.Drawing.Point(8, 113);
            this.pnlRoiGrid.Name = "pnlRoiGrid";
            this.pnlRoiGrid.Size = new System.Drawing.Size(504, 305);
            this.pnlRoiGrid.TabIndex = 1;
            // 
            // lbShowGvRow
            // 
            this.lbShowGvRow.AutoSize = true;
            this.lbShowGvRow.Location = new System.Drawing.Point(256, 61);
            this.lbShowGvRow.Name = "lbShowGvRow";
            this.lbShowGvRow.Size = new System.Drawing.Size(31, 12);
            this.lbShowGvRow.TabIndex = 9;
            this.lbShowGvRow.Text = "Rows";
            // 
            // lbShowGvColumn
            // 
            this.lbShowGvColumn.AutoSize = true;
            this.lbShowGvColumn.Location = new System.Drawing.Point(6, 61);
            this.lbShowGvColumn.Name = "lbShowGvColumn";
            this.lbShowGvColumn.Size = new System.Drawing.Size(47, 12);
            this.lbShowGvColumn.TabIndex = 8;
            this.lbShowGvColumn.Text = "Columns";
            // 
            // gvRows
            // 
            this.gvRows.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvRows.Location = new System.Drawing.Point(256, 79);
            this.gvRows.Name = "gvRows";
            this.gvRows.RowTemplate.Height = 24;
            this.gvRows.Size = new System.Drawing.Size(240, 200);
            this.gvRows.TabIndex = 7;
            // 
            // gvColumns
            // 
            this.gvColumns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvColumns.Location = new System.Drawing.Point(6, 79);
            this.gvColumns.Name = "gvColumns";
            this.gvColumns.RowTemplate.Height = 24;
            this.gvColumns.Size = new System.Drawing.Size(240, 200);
            this.gvColumns.TabIndex = 6;
            // 
            // btnCreateGrid
            // 
            this.btnCreateGrid.Location = new System.Drawing.Point(245, 26);
            this.btnCreateGrid.Name = "btnCreateGrid";
            this.btnCreateGrid.Size = new System.Drawing.Size(75, 23);
            this.btnCreateGrid.TabIndex = 5;
            this.btnCreateGrid.Text = "Create";
            this.btnCreateGrid.UseVisualStyleBackColor = true;
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Location = new System.Drawing.Point(112, 32);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(13, 12);
            this.lblX.TabIndex = 4;
            this.lblX.Text = "X";
            // 
            // lbRows
            // 
            this.lbRows.AutoSize = true;
            this.lbRows.Location = new System.Drawing.Point(130, 8);
            this.lbRows.Name = "lbRows";
            this.lbRows.Size = new System.Drawing.Size(31, 12);
            this.lbRows.TabIndex = 3;
            this.lbRows.Text = "Rows";
            // 
            // lbColumns
            // 
            this.lbColumns.AutoSize = true;
            this.lbColumns.Location = new System.Drawing.Point(5, 8);
            this.lbColumns.Name = "lbColumns";
            this.lbColumns.Size = new System.Drawing.Size(47, 12);
            this.lbColumns.TabIndex = 2;
            this.lbColumns.Text = "Columns";
            // 
            // txtColumns
            // 
            this.txtColumns.Location = new System.Drawing.Point(5, 27);
            this.txtColumns.Name = "txtColumns";
            this.txtColumns.Size = new System.Drawing.Size(100, 22);
            this.txtColumns.TabIndex = 1;
            // 
            // txtRows
            // 
            this.txtRows.Location = new System.Drawing.Point(130, 27);
            this.txtRows.Name = "txtRows";
            this.txtRows.Size = new System.Drawing.Size(100, 22);
            this.txtRows.TabIndex = 0;
            // 
            // grbRoiMode
            // 
            this.grbRoiMode.Controls.Add(this.rdoSymmetrical);
            this.grbRoiMode.Controls.Add(this.rdoNoRoi);
            this.grbRoiMode.Location = new System.Drawing.Point(6, 7);
            this.grbRoiMode.Name = "grbRoiMode";
            this.grbRoiMode.Size = new System.Drawing.Size(506, 100);
            this.grbRoiMode.TabIndex = 0;
            this.grbRoiMode.TabStop = false;
            this.grbRoiMode.Text = "ROI Settings";
            // 
            // rdoSymmetrical
            // 
            this.rdoSymmetrical.AutoSize = true;
            this.rdoSymmetrical.Location = new System.Drawing.Point(7, 45);
            this.rdoSymmetrical.Name = "rdoSymmetrical";
            this.rdoSymmetrical.Size = new System.Drawing.Size(81, 16);
            this.rdoSymmetrical.TabIndex = 1;
            this.rdoSymmetrical.TabStop = true;
            this.rdoSymmetrical.Text = "Symmetrical";
            this.rdoSymmetrical.UseVisualStyleBackColor = true;
            // 
            // rdoNoRoi
            // 
            this.rdoNoRoi.AutoSize = true;
            this.rdoNoRoi.Location = new System.Drawing.Point(7, 22);
            this.rdoNoRoi.Name = "rdoNoRoi";
            this.rdoNoRoi.Size = new System.Drawing.Size(60, 16);
            this.rdoNoRoi.TabIndex = 0;
            this.rdoNoRoi.TabStop = true;
            this.rdoNoRoi.Text = "No ROI";
            this.rdoNoRoi.UseVisualStyleBackColor = true;
            // 
            // tpGradeGroup
            // 
            this.tpGradeGroup.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tpGradeGroup.Controls.Add(this.tabGradeSetting);
            this.tpGradeGroup.Location = new System.Drawing.Point(4, 25);
            this.tpGradeGroup.Name = "tpGradeGroup";
            this.tpGradeGroup.Padding = new System.Windows.Forms.Padding(3);
            this.tpGradeGroup.Size = new System.Drawing.Size(519, 422);
            this.tpGradeGroup.TabIndex = 1;
            this.tpGradeGroup.Text = "Grade Setting";
            // 
            // tabGradeSetting
            // 
            this.tabGradeSetting.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabGradeSetting.Controls.Add(this.tpPoint);
            this.tabGradeSetting.Controls.Add(this.tpGradeLevel);
            this.tabGradeSetting.Controls.Add(this.tpPassOrFail);
            this.tabGradeSetting.Location = new System.Drawing.Point(8, 9);
            this.tabGradeSetting.Name = "tabGradeSetting";
            this.tabGradeSetting.SelectedIndex = 0;
            this.tabGradeSetting.Size = new System.Drawing.Size(505, 410);
            this.tabGradeSetting.TabIndex = 0;
            // 
            // tpPoint
            // 
            this.tpPoint.Controls.Add(this.gbPointSetting);
            this.tpPoint.Controls.Add(this.cboxEnablePTS);
            this.tpPoint.Location = new System.Drawing.Point(4, 25);
            this.tpPoint.Name = "tpPoint";
            this.tpPoint.Padding = new System.Windows.Forms.Padding(3);
            this.tpPoint.Size = new System.Drawing.Size(497, 381);
            this.tpPoint.TabIndex = 0;
            this.tpPoint.Text = "Point";
            this.tpPoint.UseVisualStyleBackColor = true;
            // 
            // gbPointSetting
            // 
            this.gbPointSetting.Controls.Add(this.cboxAllSameOfPoint);
            this.gbPointSetting.Controls.Add(this.gvPoint);
            this.gbPointSetting.Controls.Add(this.lbSubPieceOfPoint);
            this.gbPointSetting.Controls.Add(this.cboxSubPieceOfPoint);
            this.gbPointSetting.Location = new System.Drawing.Point(13, 36);
            this.gbPointSetting.Name = "gbPointSetting";
            this.gbPointSetting.Size = new System.Drawing.Size(472, 340);
            this.gbPointSetting.TabIndex = 1;
            this.gbPointSetting.TabStop = false;
            this.gbPointSetting.Text = "Point setting";
            // 
            // cboxAllSameOfPoint
            // 
            this.cboxAllSameOfPoint.AutoSize = true;
            this.cboxAllSameOfPoint.Location = new System.Drawing.Point(204, 23);
            this.cboxAllSameOfPoint.Name = "cboxAllSameOfPoint";
            this.cboxAllSameOfPoint.Size = new System.Drawing.Size(153, 16);
            this.cboxAllSameOfPoint.TabIndex = 3;
            this.cboxAllSameOfPoint.Text = "Same value from [ALL] tag";
            this.cboxAllSameOfPoint.UseVisualStyleBackColor = true;
            // 
            // gvPoint
            // 
            this.gvPoint.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvPoint.Location = new System.Drawing.Point(23, 51);
            this.gvPoint.Name = "gvPoint";
            this.gvPoint.RowTemplate.Height = 24;
            this.gvPoint.Size = new System.Drawing.Size(425, 268);
            this.gvPoint.TabIndex = 2;
            // 
            // lbSubPieceOfPoint
            // 
            this.lbSubPieceOfPoint.AutoSize = true;
            this.lbSubPieceOfPoint.Location = new System.Drawing.Point(22, 24);
            this.lbSubPieceOfPoint.Name = "lbSubPieceOfPoint";
            this.lbSubPieceOfPoint.Size = new System.Drawing.Size(47, 12);
            this.lbSubPieceOfPoint.TabIndex = 1;
            this.lbSubPieceOfPoint.Text = "SubPiece";
            // 
            // cboxSubPieceOfPoint
            // 
            this.cboxSubPieceOfPoint.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxSubPieceOfPoint.FormattingEnabled = true;
            this.cboxSubPieceOfPoint.Location = new System.Drawing.Point(76, 21);
            this.cboxSubPieceOfPoint.Name = "cboxSubPieceOfPoint";
            this.cboxSubPieceOfPoint.Size = new System.Drawing.Size(121, 20);
            this.cboxSubPieceOfPoint.TabIndex = 0;
            // 
            // cboxEnablePTS
            // 
            this.cboxEnablePTS.AutoSize = true;
            this.cboxEnablePTS.Location = new System.Drawing.Point(13, 15);
            this.cboxEnablePTS.Name = "cboxEnablePTS";
            this.cboxEnablePTS.Size = new System.Drawing.Size(87, 16);
            this.cboxEnablePTS.TabIndex = 0;
            this.cboxEnablePTS.Text = "Enable Points";
            this.cboxEnablePTS.UseVisualStyleBackColor = true;
            // 
            // tpGradeLevel
            // 
            this.tpGradeLevel.Controls.Add(this.cboxEnableGrade);
            this.tpGradeLevel.Controls.Add(this.gbGradeSetting);
            this.tpGradeLevel.Location = new System.Drawing.Point(4, 25);
            this.tpGradeLevel.Name = "tpGradeLevel";
            this.tpGradeLevel.Padding = new System.Windows.Forms.Padding(3);
            this.tpGradeLevel.Size = new System.Drawing.Size(497, 381);
            this.tpGradeLevel.TabIndex = 1;
            this.tpGradeLevel.Text = "Grade";
            this.tpGradeLevel.UseVisualStyleBackColor = true;
            // 
            // cboxEnableGrade
            // 
            this.cboxEnableGrade.AutoSize = true;
            this.cboxEnableGrade.Location = new System.Drawing.Point(13, 15);
            this.cboxEnableGrade.Name = "cboxEnableGrade";
            this.cboxEnableGrade.Size = new System.Drawing.Size(87, 16);
            this.cboxEnableGrade.TabIndex = 2;
            this.cboxEnableGrade.Text = "Enable Grade";
            this.cboxEnableGrade.UseVisualStyleBackColor = true;
            // 
            // gbGradeSetting
            // 
            this.gbGradeSetting.Controls.Add(this.cboxAllSameOfGrade);
            this.gbGradeSetting.Controls.Add(this.gvGrade);
            this.gbGradeSetting.Controls.Add(this.lbSubPieceOfGrade);
            this.gbGradeSetting.Controls.Add(this.cboxSubPieceOfGrade);
            this.gbGradeSetting.Location = new System.Drawing.Point(13, 36);
            this.gbGradeSetting.Name = "gbGradeSetting";
            this.gbGradeSetting.Size = new System.Drawing.Size(472, 340);
            this.gbGradeSetting.TabIndex = 3;
            this.gbGradeSetting.TabStop = false;
            this.gbGradeSetting.Text = "Grade setting";
            // 
            // cboxAllSameOfGrade
            // 
            this.cboxAllSameOfGrade.AutoSize = true;
            this.cboxAllSameOfGrade.Location = new System.Drawing.Point(204, 24);
            this.cboxAllSameOfGrade.Name = "cboxAllSameOfGrade";
            this.cboxAllSameOfGrade.Size = new System.Drawing.Size(153, 16);
            this.cboxAllSameOfGrade.TabIndex = 3;
            this.cboxAllSameOfGrade.Text = "Same value from [ALL] tag";
            this.cboxAllSameOfGrade.UseVisualStyleBackColor = true;
            // 
            // gvGrade
            // 
            this.gvGrade.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvGrade.Location = new System.Drawing.Point(23, 51);
            this.gvGrade.Name = "gvGrade";
            this.gvGrade.RowTemplate.Height = 24;
            this.gvGrade.Size = new System.Drawing.Size(425, 268);
            this.gvGrade.TabIndex = 2;
            // 
            // lbSubPieceOfGrade
            // 
            this.lbSubPieceOfGrade.AutoSize = true;
            this.lbSubPieceOfGrade.Location = new System.Drawing.Point(22, 24);
            this.lbSubPieceOfGrade.Name = "lbSubPieceOfGrade";
            this.lbSubPieceOfGrade.Size = new System.Drawing.Size(47, 12);
            this.lbSubPieceOfGrade.TabIndex = 1;
            this.lbSubPieceOfGrade.Text = "SubPiece";
            // 
            // cboxSubPieceOfGrade
            // 
            this.cboxSubPieceOfGrade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxSubPieceOfGrade.FormattingEnabled = true;
            this.cboxSubPieceOfGrade.Location = new System.Drawing.Point(76, 21);
            this.cboxSubPieceOfGrade.Name = "cboxSubPieceOfGrade";
            this.cboxSubPieceOfGrade.Size = new System.Drawing.Size(121, 20);
            this.cboxSubPieceOfGrade.TabIndex = 0;
            // 
            // tpPassOrFail
            // 
            this.tpPassOrFail.Controls.Add(this.lbScore);
            this.tpPassOrFail.Controls.Add(this.txtFilterScore);
            this.tpPassOrFail.Controls.Add(this.cboxEnablePFS);
            this.tpPassOrFail.Location = new System.Drawing.Point(4, 25);
            this.tpPassOrFail.Name = "tpPassOrFail";
            this.tpPassOrFail.Padding = new System.Windows.Forms.Padding(3);
            this.tpPassOrFail.Size = new System.Drawing.Size(497, 381);
            this.tpPassOrFail.TabIndex = 2;
            this.tpPassOrFail.Text = "Pass / Fail";
            this.tpPassOrFail.UseVisualStyleBackColor = true;
            // 
            // lbScore
            // 
            this.lbScore.AutoSize = true;
            this.lbScore.Location = new System.Drawing.Point(13, 46);
            this.lbScore.Name = "lbScore";
            this.lbScore.Size = new System.Drawing.Size(31, 12);
            this.lbScore.TabIndex = 2;
            this.lbScore.Text = "Score";
            // 
            // txtFilterScore
            // 
            this.txtFilterScore.Location = new System.Drawing.Point(50, 41);
            this.txtFilterScore.Name = "txtFilterScore";
            this.txtFilterScore.Size = new System.Drawing.Size(100, 22);
            this.txtFilterScore.TabIndex = 1;
            // 
            // cboxEnablePFS
            // 
            this.cboxEnablePFS.AutoSize = true;
            this.cboxEnablePFS.Location = new System.Drawing.Point(13, 15);
            this.cboxEnablePFS.Name = "cboxEnablePFS";
            this.cboxEnablePFS.Size = new System.Drawing.Size(169, 16);
            this.cboxEnablePFS.TabIndex = 0;
            this.cboxEnablePFS.Text = "Enable Pass Or Fail Filter Score";
            this.cboxEnablePFS.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(442, 463);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Close";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSaveGradeConfigFile
            // 
            this.btnSaveGradeConfigFile.Location = new System.Drawing.Point(361, 464);
            this.btnSaveGradeConfigFile.Name = "btnSaveGradeConfigFile";
            this.btnSaveGradeConfigFile.Size = new System.Drawing.Size(75, 23);
            this.btnSaveGradeConfigFile.TabIndex = 7;
            this.btnSaveGradeConfigFile.Text = "Save";
            this.btnSaveGradeConfigFile.UseVisualStyleBackColor = true;
            // 
            // lblGradeConfig
            // 
            this.lblGradeConfig.AutoSize = true;
            this.lblGradeConfig.Location = new System.Drawing.Point(26, 468);
            this.lblGradeConfig.Name = "lblGradeConfig";
            this.lblGradeConfig.Size = new System.Drawing.Size(89, 12);
            this.lblGradeConfig.TabIndex = 6;
            this.lblGradeConfig.Text = "Grade Config File";
            // 
            // cmbGradeConfigFiles
            // 
            this.cmbGradeConfigFiles.FormattingEnabled = true;
            this.cmbGradeConfigFiles.Location = new System.Drawing.Point(121, 465);
            this.cmbGradeConfigFiles.Name = "cmbGradeConfigFiles";
            this.cmbGradeConfigFiles.Size = new System.Drawing.Size(234, 20);
            this.cmbGradeConfigFiles.TabIndex = 5;
            // 
            // GradeSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 501);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSaveGradeConfigFile);
            this.Controls.Add(this.lblGradeConfig);
            this.Controls.Add(this.cmbGradeConfigFiles);
            this.Controls.Add(this.tabGradeSetup);
            this.Name = "GradeSetup";
            this.Text = "GradeSetup";
            this.Load += new System.EventHandler(this.GradeSetup_Load);
            this.tabGradeSetup.ResumeLayout(false);
            this.tpROI.ResumeLayout(false);
            this.pnlRoiGrid.ResumeLayout(false);
            this.pnlRoiGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvColumns)).EndInit();
            this.grbRoiMode.ResumeLayout(false);
            this.grbRoiMode.PerformLayout();
            this.tpGradeGroup.ResumeLayout(false);
            this.tabGradeSetting.ResumeLayout(false);
            this.tpPoint.ResumeLayout(false);
            this.tpPoint.PerformLayout();
            this.gbPointSetting.ResumeLayout(false);
            this.gbPointSetting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvPoint)).EndInit();
            this.tpGradeLevel.ResumeLayout(false);
            this.tpGradeLevel.PerformLayout();
            this.gbGradeSetting.ResumeLayout(false);
            this.gbGradeSetting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvGrade)).EndInit();
            this.tpPassOrFail.ResumeLayout(false);
            this.tpPassOrFail.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabGradeSetup;
        private System.Windows.Forms.TabPage tpROI;
        private System.Windows.Forms.Panel pnlRoiGrid;
        private System.Windows.Forms.Label lbShowGvRow;
        private System.Windows.Forms.Label lbShowGvColumn;
        private System.Windows.Forms.DataGridView gvRows;
        private System.Windows.Forms.DataGridView gvColumns;
        private System.Windows.Forms.Button btnCreateGrid;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.Label lbRows;
        private System.Windows.Forms.Label lbColumns;
        private System.Windows.Forms.TextBox txtColumns;
        private System.Windows.Forms.TextBox txtRows;
        private System.Windows.Forms.GroupBox grbRoiMode;
        private System.Windows.Forms.RadioButton rdoSymmetrical;
        private System.Windows.Forms.RadioButton rdoNoRoi;
        private System.Windows.Forms.TabPage tpGradeGroup;
        private System.Windows.Forms.TabControl tabGradeSetting;
        private System.Windows.Forms.TabPage tpPoint;
        private System.Windows.Forms.GroupBox gbPointSetting;
        private System.Windows.Forms.CheckBox cboxAllSameOfPoint;
        private System.Windows.Forms.DataGridView gvPoint;
        private System.Windows.Forms.Label lbSubPieceOfPoint;
        private System.Windows.Forms.ComboBox cboxSubPieceOfPoint;
        private System.Windows.Forms.CheckBox cboxEnablePTS;
        private System.Windows.Forms.TabPage tpGradeLevel;
        private System.Windows.Forms.CheckBox cboxEnableGrade;
        private System.Windows.Forms.GroupBox gbGradeSetting;
        private System.Windows.Forms.CheckBox cboxAllSameOfGrade;
        private System.Windows.Forms.DataGridView gvGrade;
        private System.Windows.Forms.Label lbSubPieceOfGrade;
        private System.Windows.Forms.ComboBox cboxSubPieceOfGrade;
        private System.Windows.Forms.TabPage tpPassOrFail;
        private System.Windows.Forms.Label lbScore;
        private System.Windows.Forms.TextBox txtFilterScore;
        private System.Windows.Forms.CheckBox cboxEnablePFS;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSaveGradeConfigFile;
        private System.Windows.Forms.Label lblGradeConfig;
        private System.Windows.Forms.ComboBox cmbGradeConfigFiles;

    }
}