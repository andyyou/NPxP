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
            this.btnReset = new System.Windows.Forms.Button();
            this.lbShowGvRow = new System.Windows.Forms.Label();
            this.lbShowGvColumn = new System.Windows.Forms.Label();
            this.dgvRows = new System.Windows.Forms.DataGridView();
            this.dgvColumns = new System.Windows.Forms.DataGridView();
            this.btnCreateGrid = new System.Windows.Forms.Button();
            this.lblX = new System.Windows.Forms.Label();
            this.lblRows = new System.Windows.Forms.Label();
            this.lblColumns = new System.Windows.Forms.Label();
            this.txtColumns = new System.Windows.Forms.TextBox();
            this.txtRows = new System.Windows.Forms.TextBox();
            this.grbRoiMode = new System.Windows.Forms.GroupBox();
            this.rdoSymmetrical = new System.Windows.Forms.RadioButton();
            this.rdoNoRoi = new System.Windows.Forms.RadioButton();
            this.tpGradeGroup = new System.Windows.Forms.TabPage();
            this.tabGradeSetting = new System.Windows.Forms.TabControl();
            this.tpPoint = new System.Windows.Forms.TabPage();
            this.grbPointSetting = new System.Windows.Forms.GroupBox();
            this.chkAllSameOfPoint = new System.Windows.Forms.CheckBox();
            this.dgvPoint = new System.Windows.Forms.DataGridView();
            this.lbSubPieceOfPoint = new System.Windows.Forms.Label();
            this.cmbSubPoints = new System.Windows.Forms.ComboBox();
            this.chkEnablePonit = new System.Windows.Forms.CheckBox();
            this.tpGradeLevel = new System.Windows.Forms.TabPage();
            this.chkEnableGrade = new System.Windows.Forms.CheckBox();
            this.grbGradeSetting = new System.Windows.Forms.GroupBox();
            this.chkAllSameOfGrade = new System.Windows.Forms.CheckBox();
            this.dgvGrade = new System.Windows.Forms.DataGridView();
            this.lbSubPieceOfGrade = new System.Windows.Forms.Label();
            this.cmbSubMarks = new System.Windows.Forms.ComboBox();
            this.tpPassOrFail = new System.Windows.Forms.TabPage();
            this.lblScore = new System.Windows.Forms.Label();
            this.txtFilterScore = new System.Windows.Forms.TextBox();
            this.chkEnablePFS = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSaveGradeConfigFile = new System.Windows.Forms.Button();
            this.lblGradeConfig = new System.Windows.Forms.Label();
            this.cmbConfig = new System.Windows.Forms.ComboBox();
            this.tabGradeSetup.SuspendLayout();
            this.tpROI.SuspendLayout();
            this.pnlRoiGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColumns)).BeginInit();
            this.grbRoiMode.SuspendLayout();
            this.tpGradeGroup.SuspendLayout();
            this.tabGradeSetting.SuspendLayout();
            this.tpPoint.SuspendLayout();
            this.grbPointSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPoint)).BeginInit();
            this.tpGradeLevel.SuspendLayout();
            this.grbGradeSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrade)).BeginInit();
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
            this.tabGradeSetup.SelectedIndexChanged += new System.EventHandler(this.tabGradeSetup_SelectedIndexChanged);
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
            this.pnlRoiGrid.Controls.Add(this.btnReset);
            this.pnlRoiGrid.Controls.Add(this.lbShowGvRow);
            this.pnlRoiGrid.Controls.Add(this.lbShowGvColumn);
            this.pnlRoiGrid.Controls.Add(this.dgvRows);
            this.pnlRoiGrid.Controls.Add(this.dgvColumns);
            this.pnlRoiGrid.Controls.Add(this.btnCreateGrid);
            this.pnlRoiGrid.Controls.Add(this.lblX);
            this.pnlRoiGrid.Controls.Add(this.lblRows);
            this.pnlRoiGrid.Controls.Add(this.lblColumns);
            this.pnlRoiGrid.Controls.Add(this.txtColumns);
            this.pnlRoiGrid.Controls.Add(this.txtRows);
            this.pnlRoiGrid.Location = new System.Drawing.Point(8, 113);
            this.pnlRoiGrid.Name = "pnlRoiGrid";
            this.pnlRoiGrid.Size = new System.Drawing.Size(504, 305);
            this.pnlRoiGrid.TabIndex = 1;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(326, 26);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 10;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
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
            // dgvRows
            // 
            this.dgvRows.AllowUserToAddRows = false;
            this.dgvRows.AllowUserToDeleteRows = false;
            this.dgvRows.AllowUserToResizeColumns = false;
            this.dgvRows.AllowUserToResizeRows = false;
            this.dgvRows.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRows.Location = new System.Drawing.Point(256, 79);
            this.dgvRows.Name = "dgvRows";
            this.dgvRows.RowTemplate.Height = 24;
            this.dgvRows.Size = new System.Drawing.Size(240, 200);
            this.dgvRows.TabIndex = 7;
            this.dgvRows.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.Double_CellValidating);
            // 
            // dgvColumns
            // 
            this.dgvColumns.AllowUserToAddRows = false;
            this.dgvColumns.AllowUserToDeleteRows = false;
            this.dgvColumns.AllowUserToResizeColumns = false;
            this.dgvColumns.AllowUserToResizeRows = false;
            this.dgvColumns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvColumns.Location = new System.Drawing.Point(6, 79);
            this.dgvColumns.Name = "dgvColumns";
            this.dgvColumns.RowTemplate.Height = 24;
            this.dgvColumns.Size = new System.Drawing.Size(240, 200);
            this.dgvColumns.TabIndex = 6;
            this.dgvColumns.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.Double_CellValidating);
            // 
            // btnCreateGrid
            // 
            this.btnCreateGrid.Location = new System.Drawing.Point(245, 26);
            this.btnCreateGrid.Name = "btnCreateGrid";
            this.btnCreateGrid.Size = new System.Drawing.Size(75, 23);
            this.btnCreateGrid.TabIndex = 5;
            this.btnCreateGrid.Text = "Create";
            this.btnCreateGrid.UseVisualStyleBackColor = true;
            this.btnCreateGrid.Click += new System.EventHandler(this.btnCreateGrid_Click);
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
            // lblRows
            // 
            this.lblRows.AutoSize = true;
            this.lblRows.Location = new System.Drawing.Point(130, 8);
            this.lblRows.Name = "lblRows";
            this.lblRows.Size = new System.Drawing.Size(31, 12);
            this.lblRows.TabIndex = 3;
            this.lblRows.Text = "Rows";
            // 
            // lblColumns
            // 
            this.lblColumns.AutoSize = true;
            this.lblColumns.Location = new System.Drawing.Point(5, 8);
            this.lblColumns.Name = "lblColumns";
            this.lblColumns.Size = new System.Drawing.Size(47, 12);
            this.lblColumns.TabIndex = 2;
            this.lblColumns.Text = "Columns";
            // 
            // txtColumns
            // 
            this.txtColumns.Location = new System.Drawing.Point(5, 27);
            this.txtColumns.Name = "txtColumns";
            this.txtColumns.Size = new System.Drawing.Size(100, 22);
            this.txtColumns.TabIndex = 1;
            this.txtColumns.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtColumns_KeyPress);
            // 
            // txtRows
            // 
            this.txtRows.Location = new System.Drawing.Point(130, 27);
            this.txtRows.Name = "txtRows";
            this.txtRows.Size = new System.Drawing.Size(100, 22);
            this.txtRows.TabIndex = 0;
            this.txtRows.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRows_KeyPress);
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
            this.rdoSymmetrical.CheckedChanged += new System.EventHandler(this.RoiMode_CheckedChanged);
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
            this.rdoNoRoi.CheckedChanged += new System.EventHandler(this.RoiMode_CheckedChanged);
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
            this.tpPoint.Controls.Add(this.grbPointSetting);
            this.tpPoint.Controls.Add(this.chkEnablePonit);
            this.tpPoint.Location = new System.Drawing.Point(4, 25);
            this.tpPoint.Name = "tpPoint";
            this.tpPoint.Padding = new System.Windows.Forms.Padding(3);
            this.tpPoint.Size = new System.Drawing.Size(497, 381);
            this.tpPoint.TabIndex = 0;
            this.tpPoint.Text = "Point";
            this.tpPoint.UseVisualStyleBackColor = true;
            // 
            // grbPointSetting
            // 
            this.grbPointSetting.Controls.Add(this.chkAllSameOfPoint);
            this.grbPointSetting.Controls.Add(this.dgvPoint);
            this.grbPointSetting.Controls.Add(this.lbSubPieceOfPoint);
            this.grbPointSetting.Controls.Add(this.cmbSubPoints);
            this.grbPointSetting.Location = new System.Drawing.Point(13, 36);
            this.grbPointSetting.Name = "grbPointSetting";
            this.grbPointSetting.Size = new System.Drawing.Size(472, 340);
            this.grbPointSetting.TabIndex = 1;
            this.grbPointSetting.TabStop = false;
            this.grbPointSetting.Text = "Point setting";
            // 
            // chkAllSameOfPoint
            // 
            this.chkAllSameOfPoint.AutoSize = true;
            this.chkAllSameOfPoint.Location = new System.Drawing.Point(204, 23);
            this.chkAllSameOfPoint.Name = "chkAllSameOfPoint";
            this.chkAllSameOfPoint.Size = new System.Drawing.Size(153, 16);
            this.chkAllSameOfPoint.TabIndex = 3;
            this.chkAllSameOfPoint.Text = "Same value from [ALL] tag";
            this.chkAllSameOfPoint.UseVisualStyleBackColor = true;
            // 
            // dgvPoint
            // 
            this.dgvPoint.AllowUserToAddRows = false;
            this.dgvPoint.AllowUserToDeleteRows = false;
            this.dgvPoint.AllowUserToResizeColumns = false;
            this.dgvPoint.AllowUserToResizeRows = false;
            this.dgvPoint.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPoint.Location = new System.Drawing.Point(23, 51);
            this.dgvPoint.MultiSelect = false;
            this.dgvPoint.Name = "dgvPoint";
            this.dgvPoint.RowTemplate.Height = 24;
            this.dgvPoint.Size = new System.Drawing.Size(425, 268);
            this.dgvPoint.TabIndex = 2;
            this.dgvPoint.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvPoint_CellValidating);
            this.dgvPoint.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvPoint_DataError);
            this.dgvPoint.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvPoint_KeyPress);
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
            // cmbSubPoints
            // 
            this.cmbSubPoints.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSubPoints.FormattingEnabled = true;
            this.cmbSubPoints.Location = new System.Drawing.Point(76, 21);
            this.cmbSubPoints.Name = "cmbSubPoints";
            this.cmbSubPoints.Size = new System.Drawing.Size(121, 20);
            this.cmbSubPoints.TabIndex = 0;
            this.cmbSubPoints.DropDownClosed += new System.EventHandler(this.cmbSubPoints_DropDownClosed);
            // 
            // chkEnablePonit
            // 
            this.chkEnablePonit.AutoSize = true;
            this.chkEnablePonit.Location = new System.Drawing.Point(13, 15);
            this.chkEnablePonit.Name = "chkEnablePonit";
            this.chkEnablePonit.Size = new System.Drawing.Size(87, 16);
            this.chkEnablePonit.TabIndex = 0;
            this.chkEnablePonit.Text = "Enable Points";
            this.chkEnablePonit.UseVisualStyleBackColor = true;
            this.chkEnablePonit.CheckedChanged += new System.EventHandler(this.chkEnablePonit_CheckedChanged);
            // 
            // tpGradeLevel
            // 
            this.tpGradeLevel.Controls.Add(this.chkEnableGrade);
            this.tpGradeLevel.Controls.Add(this.grbGradeSetting);
            this.tpGradeLevel.Location = new System.Drawing.Point(4, 25);
            this.tpGradeLevel.Name = "tpGradeLevel";
            this.tpGradeLevel.Padding = new System.Windows.Forms.Padding(3);
            this.tpGradeLevel.Size = new System.Drawing.Size(497, 381);
            this.tpGradeLevel.TabIndex = 1;
            this.tpGradeLevel.Text = "Grade";
            this.tpGradeLevel.UseVisualStyleBackColor = true;
            // 
            // chkEnableGrade
            // 
            this.chkEnableGrade.AutoSize = true;
            this.chkEnableGrade.Location = new System.Drawing.Point(13, 15);
            this.chkEnableGrade.Name = "chkEnableGrade";
            this.chkEnableGrade.Size = new System.Drawing.Size(87, 16);
            this.chkEnableGrade.TabIndex = 2;
            this.chkEnableGrade.Text = "Enable Grade";
            this.chkEnableGrade.UseVisualStyleBackColor = true;
            this.chkEnableGrade.CheckedChanged += new System.EventHandler(this.chkEnableGrade_CheckedChanged);
            // 
            // grbGradeSetting
            // 
            this.grbGradeSetting.Controls.Add(this.chkAllSameOfGrade);
            this.grbGradeSetting.Controls.Add(this.dgvGrade);
            this.grbGradeSetting.Controls.Add(this.lbSubPieceOfGrade);
            this.grbGradeSetting.Controls.Add(this.cmbSubMarks);
            this.grbGradeSetting.Location = new System.Drawing.Point(13, 36);
            this.grbGradeSetting.Name = "grbGradeSetting";
            this.grbGradeSetting.Size = new System.Drawing.Size(472, 340);
            this.grbGradeSetting.TabIndex = 3;
            this.grbGradeSetting.TabStop = false;
            this.grbGradeSetting.Text = "Grade setting";
            // 
            // chkAllSameOfGrade
            // 
            this.chkAllSameOfGrade.AutoSize = true;
            this.chkAllSameOfGrade.Location = new System.Drawing.Point(204, 23);
            this.chkAllSameOfGrade.Name = "chkAllSameOfGrade";
            this.chkAllSameOfGrade.Size = new System.Drawing.Size(153, 16);
            this.chkAllSameOfGrade.TabIndex = 3;
            this.chkAllSameOfGrade.Text = "Same value from [ALL] tag";
            this.chkAllSameOfGrade.UseVisualStyleBackColor = true;
            // 
            // dgvGrade
            // 
            this.dgvGrade.AllowUserToAddRows = false;
            this.dgvGrade.AllowUserToResizeColumns = false;
            this.dgvGrade.AllowUserToResizeRows = false;
            this.dgvGrade.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrade.Location = new System.Drawing.Point(23, 51);
            this.dgvGrade.Name = "dgvGrade";
            this.dgvGrade.RowTemplate.Height = 24;
            this.dgvGrade.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGrade.Size = new System.Drawing.Size(425, 268);
            this.dgvGrade.TabIndex = 2;
            this.dgvGrade.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvGrade_UserDeletingRow);
            this.dgvGrade.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvGrade_CellValidating);
            this.dgvGrade.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGrade_CellEndEdit);
            this.dgvGrade.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvGrade_DataError);
            this.dgvGrade.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvGrade_RowsRemoved);
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
            // cmbSubMarks
            // 
            this.cmbSubMarks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSubMarks.FormattingEnabled = true;
            this.cmbSubMarks.Location = new System.Drawing.Point(76, 21);
            this.cmbSubMarks.Name = "cmbSubMarks";
            this.cmbSubMarks.Size = new System.Drawing.Size(121, 20);
            this.cmbSubMarks.TabIndex = 0;
            this.cmbSubMarks.DropDownClosed += new System.EventHandler(this.cmbSubMarks_DropDownClosed);
            // 
            // tpPassOrFail
            // 
            this.tpPassOrFail.Controls.Add(this.lblScore);
            this.tpPassOrFail.Controls.Add(this.txtFilterScore);
            this.tpPassOrFail.Controls.Add(this.chkEnablePFS);
            this.tpPassOrFail.Location = new System.Drawing.Point(4, 25);
            this.tpPassOrFail.Name = "tpPassOrFail";
            this.tpPassOrFail.Padding = new System.Windows.Forms.Padding(3);
            this.tpPassOrFail.Size = new System.Drawing.Size(497, 381);
            this.tpPassOrFail.TabIndex = 2;
            this.tpPassOrFail.Text = "Pass / Fail";
            this.tpPassOrFail.UseVisualStyleBackColor = true;
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Location = new System.Drawing.Point(13, 46);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(31, 12);
            this.lblScore.TabIndex = 2;
            this.lblScore.Text = "Score";
            // 
            // txtFilterScore
            // 
            this.txtFilterScore.Location = new System.Drawing.Point(50, 41);
            this.txtFilterScore.Name = "txtFilterScore";
            this.txtFilterScore.Size = new System.Drawing.Size(100, 22);
            this.txtFilterScore.TabIndex = 1;
            this.txtFilterScore.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterScore_KeyPress);
            // 
            // chkEnablePFS
            // 
            this.chkEnablePFS.AutoSize = true;
            this.chkEnablePFS.Location = new System.Drawing.Point(13, 15);
            this.chkEnablePFS.Name = "chkEnablePFS";
            this.chkEnablePFS.Size = new System.Drawing.Size(169, 16);
            this.chkEnablePFS.TabIndex = 0;
            this.chkEnablePFS.Text = "Enable Pass Or Fail Filter Score";
            this.chkEnablePFS.UseVisualStyleBackColor = true;
            this.chkEnablePFS.CheckedChanged += new System.EventHandler(this.chkEnablePFS_CheckedChanged);
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
            this.btnSaveGradeConfigFile.Click += new System.EventHandler(this.btnSaveGradeConfigFile_Click);
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
            // cmbConfig
            // 
            this.cmbConfig.FormattingEnabled = true;
            this.cmbConfig.Location = new System.Drawing.Point(121, 465);
            this.cmbConfig.Name = "cmbConfig";
            this.cmbConfig.Size = new System.Drawing.Size(234, 20);
            this.cmbConfig.TabIndex = 5;
            this.cmbConfig.DropDownClosed += new System.EventHandler(this.cmbConfig_DropDownClosed);
            // 
            // GradeSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 501);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSaveGradeConfigFile);
            this.Controls.Add(this.lblGradeConfig);
            this.Controls.Add(this.cmbConfig);
            this.Controls.Add(this.tabGradeSetup);
            this.Name = "GradeSetup";
            this.Text = "GradeSetup";
            this.Load += new System.EventHandler(this.GradeSetup_Load);
            this.tabGradeSetup.ResumeLayout(false);
            this.tpROI.ResumeLayout(false);
            this.pnlRoiGrid.ResumeLayout(false);
            this.pnlRoiGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColumns)).EndInit();
            this.grbRoiMode.ResumeLayout(false);
            this.grbRoiMode.PerformLayout();
            this.tpGradeGroup.ResumeLayout(false);
            this.tabGradeSetting.ResumeLayout(false);
            this.tpPoint.ResumeLayout(false);
            this.tpPoint.PerformLayout();
            this.grbPointSetting.ResumeLayout(false);
            this.grbPointSetting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPoint)).EndInit();
            this.tpGradeLevel.ResumeLayout(false);
            this.tpGradeLevel.PerformLayout();
            this.grbGradeSetting.ResumeLayout(false);
            this.grbGradeSetting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrade)).EndInit();
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
        private System.Windows.Forms.DataGridView dgvRows;
        private System.Windows.Forms.DataGridView dgvColumns;
        private System.Windows.Forms.Button btnCreateGrid;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.Label lblRows;
        private System.Windows.Forms.Label lblColumns;
        private System.Windows.Forms.TextBox txtColumns;
        private System.Windows.Forms.TextBox txtRows;
        private System.Windows.Forms.GroupBox grbRoiMode;
        private System.Windows.Forms.RadioButton rdoSymmetrical;
        private System.Windows.Forms.RadioButton rdoNoRoi;
        private System.Windows.Forms.TabPage tpGradeGroup;
        private System.Windows.Forms.TabControl tabGradeSetting;
        private System.Windows.Forms.TabPage tpPoint;
        private System.Windows.Forms.GroupBox grbPointSetting;
        private System.Windows.Forms.CheckBox chkAllSameOfPoint;
        private System.Windows.Forms.DataGridView dgvPoint;
        private System.Windows.Forms.Label lbSubPieceOfPoint;
        private System.Windows.Forms.ComboBox cmbSubPoints;
        private System.Windows.Forms.CheckBox chkEnablePonit;
        private System.Windows.Forms.TabPage tpGradeLevel;
        private System.Windows.Forms.CheckBox chkEnableGrade;
        private System.Windows.Forms.GroupBox grbGradeSetting;
        private System.Windows.Forms.CheckBox chkAllSameOfGrade;
        private System.Windows.Forms.DataGridView dgvGrade;
        private System.Windows.Forms.Label lbSubPieceOfGrade;
        private System.Windows.Forms.ComboBox cmbSubMarks;
        private System.Windows.Forms.TabPage tpPassOrFail;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.TextBox txtFilterScore;
        private System.Windows.Forms.CheckBox chkEnablePFS;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSaveGradeConfigFile;
        private System.Windows.Forms.Label lblGradeConfig;
        private System.Windows.Forms.ComboBox cmbConfig;
        private System.Windows.Forms.Button btnReset;

    }
}