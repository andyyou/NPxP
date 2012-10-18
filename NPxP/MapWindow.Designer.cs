namespace NPxP
{
    partial class MapWindow
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
            DevExpress.XtraCharts.SideBySideBarSeriesLabel sideBySideBarSeriesLabel2 = new DevExpress.XtraCharts.SideBySideBarSeriesLabel();
            this.tlpMapInfo = new System.Windows.Forms.TableLayoutPanel();
            this.lblOperatorValue = new System.Windows.Forms.Label();
            this.lblOperator = new System.Windows.Forms.Label();
            this.lblMeterialType = new System.Windows.Forms.Label();
            this.lblMeterialTypeValue = new System.Windows.Forms.Label();
            this.lblOrderNumber = new System.Windows.Forms.Label();
            this.lblJobId = new System.Windows.Forms.Label();
            this.lblOrderNumberValue = new System.Windows.Forms.Label();
            this.lblJobIdValue = new System.Windows.Forms.Label();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.lblDateTimeValue = new System.Windows.Forms.Label();
            this.lblDoff = new System.Windows.Forms.Label();
            this.lblDoffValue = new System.Windows.Forms.Label();
            this.lblFilterType = new System.Windows.Forms.Label();
            this.cmbFilterType = new System.Windows.Forms.ComboBox();
            this.btnMapSetting = new System.Windows.Forms.Button();
            this.btnFailPieceList = new System.Windows.Forms.Button();
            this.btnGradeSetting = new System.Windows.Forms.Button();
            this.lblFail = new System.Windows.Forms.Label();
            this.lblFailValue = new System.Windows.Forms.Label();
            this.lblPass = new System.Windows.Forms.Label();
            this.lblPassValue = new System.Windows.Forms.Label();
            this.lblYield = new System.Windows.Forms.Label();
            this.lblYieldValue = new System.Windows.Forms.Label();
            this.lblGradeConfigFiles = new System.Windows.Forms.Label();
            this.cmbGradeConfigFiles = new System.Windows.Forms.ComboBox();
            this.dgvFlawLegend = new System.Windows.Forms.DataGridView();
            this.btnPrevPiece = new System.Windows.Forms.Button();
            this.btnNextPiece = new System.Windows.Forms.Button();
            this.lblN1 = new System.Windows.Forms.Label();
            this.lblTotalPiece = new System.Windows.Forms.Label();
            this.lblNowPiece = new System.Windows.Forms.Label();
            this.dgvFlawLegendDetial = new System.Windows.Forms.DataGridView();
            this.chartControl = new DevExpress.XtraCharts.ChartControl();
            this.lblScore = new System.Windows.Forms.Label();
            this.lblScoreValue = new System.Windows.Forms.Label();
            this.btnShowGoPage = new System.Windows.Forms.Button();
            this.btnGo = new System.Windows.Forms.Button();
            this.txtGoPage = new System.Windows.Forms.TextBox();
            this.tlpMapInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFlawLegend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFlawLegendDetial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel2)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpMapInfo
            // 
            this.tlpMapInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpMapInfo.AutoSize = true;
            this.tlpMapInfo.BackColor = System.Drawing.Color.Transparent;
            this.tlpMapInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tlpMapInfo.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpMapInfo.ColumnCount = 6;
            this.tlpMapInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.887F));
            this.tlpMapInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.113F));
            this.tlpMapInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 97F));
            this.tlpMapInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 119F));
            this.tlpMapInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 73F));
            this.tlpMapInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 162F));
            this.tlpMapInfo.Controls.Add(this.lblOperatorValue, 3, 1);
            this.tlpMapInfo.Controls.Add(this.lblOperator, 2, 1);
            this.tlpMapInfo.Controls.Add(this.lblMeterialType, 2, 0);
            this.tlpMapInfo.Controls.Add(this.lblMeterialTypeValue, 3, 0);
            this.tlpMapInfo.Controls.Add(this.lblOrderNumber, 0, 0);
            this.tlpMapInfo.Controls.Add(this.lblJobId, 0, 1);
            this.tlpMapInfo.Controls.Add(this.lblOrderNumberValue, 1, 0);
            this.tlpMapInfo.Controls.Add(this.lblJobIdValue, 1, 1);
            this.tlpMapInfo.Controls.Add(this.lblDateTime, 4, 0);
            this.tlpMapInfo.Controls.Add(this.lblDateTimeValue, 5, 0);
            this.tlpMapInfo.Controls.Add(this.lblDoff, 4, 1);
            this.tlpMapInfo.Controls.Add(this.lblDoffValue, 5, 1);
            this.tlpMapInfo.Font = new System.Drawing.Font("新細明體-ExtB", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tlpMapInfo.Location = new System.Drawing.Point(7, 604);
            this.tlpMapInfo.Name = "tlpMapInfo";
            this.tlpMapInfo.Padding = new System.Windows.Forms.Padding(2);
            this.tlpMapInfo.RowCount = 2;
            this.tlpMapInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMapInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMapInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMapInfo.Size = new System.Drawing.Size(636, 59);
            this.tlpMapInfo.TabIndex = 22;
            // 
            // lblOperatorValue
            // 
            this.lblOperatorValue.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOperatorValue.Location = new System.Drawing.Point(279, 30);
            this.lblOperatorValue.Name = "lblOperatorValue";
            this.lblOperatorValue.Size = new System.Drawing.Size(113, 14);
            this.lblOperatorValue.TabIndex = 9;
            this.lblOperatorValue.Text = "--";
            // 
            // lblOperator
            // 
            this.lblOperator.AutoSize = true;
            this.lblOperator.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOperator.Location = new System.Drawing.Point(181, 30);
            this.lblOperator.Name = "lblOperator";
            this.lblOperator.Size = new System.Drawing.Size(64, 14);
            this.lblOperator.TabIndex = 8;
            this.lblOperator.Text = "Operator";
            // 
            // lblMeterialType
            // 
            this.lblMeterialType.AutoSize = true;
            this.lblMeterialType.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMeterialType.Location = new System.Drawing.Point(181, 3);
            this.lblMeterialType.Name = "lblMeterialType";
            this.lblMeterialType.Size = new System.Drawing.Size(91, 14);
            this.lblMeterialType.TabIndex = 2;
            this.lblMeterialType.Text = "Meterial Type";
            // 
            // lblMeterialTypeValue
            // 
            this.lblMeterialTypeValue.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMeterialTypeValue.Location = new System.Drawing.Point(279, 3);
            this.lblMeterialTypeValue.Name = "lblMeterialTypeValue";
            this.lblMeterialTypeValue.Size = new System.Drawing.Size(113, 14);
            this.lblMeterialTypeValue.TabIndex = 3;
            this.lblMeterialTypeValue.Text = "--";
            // 
            // lblOrderNumber
            // 
            this.lblOrderNumber.AutoSize = true;
            this.lblOrderNumber.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderNumber.Location = new System.Drawing.Point(6, 3);
            this.lblOrderNumber.Name = "lblOrderNumber";
            this.lblOrderNumber.Size = new System.Drawing.Size(96, 14);
            this.lblOrderNumber.TabIndex = 0;
            this.lblOrderNumber.Text = "Order Number";
            // 
            // lblJobId
            // 
            this.lblJobId.AutoSize = true;
            this.lblJobId.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJobId.Location = new System.Drawing.Point(6, 30);
            this.lblJobId.Name = "lblJobId";
            this.lblJobId.Size = new System.Drawing.Size(46, 14);
            this.lblJobId.TabIndex = 6;
            this.lblJobId.Text = "Job ID";
            // 
            // lblOrderNumberValue
            // 
            this.lblOrderNumberValue.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderNumberValue.Location = new System.Drawing.Point(111, 3);
            this.lblOrderNumberValue.Name = "lblOrderNumberValue";
            this.lblOrderNumberValue.Size = new System.Drawing.Size(63, 14);
            this.lblOrderNumberValue.TabIndex = 1;
            this.lblOrderNumberValue.Text = "--";
            // 
            // lblJobIdValue
            // 
            this.lblJobIdValue.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJobIdValue.Location = new System.Drawing.Point(111, 30);
            this.lblJobIdValue.Name = "lblJobIdValue";
            this.lblJobIdValue.Size = new System.Drawing.Size(63, 14);
            this.lblJobIdValue.TabIndex = 7;
            this.lblJobIdValue.Text = "--";
            // 
            // lblDateTime
            // 
            this.lblDateTime.AutoSize = true;
            this.lblDateTime.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateTime.Location = new System.Drawing.Point(399, 3);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(66, 14);
            this.lblDateTime.TabIndex = 4;
            this.lblDateTime.Text = "DateTime";
            // 
            // lblDateTimeValue
            // 
            this.lblDateTimeValue.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateTimeValue.Location = new System.Drawing.Point(473, 3);
            this.lblDateTimeValue.Name = "lblDateTimeValue";
            this.lblDateTimeValue.Size = new System.Drawing.Size(157, 14);
            this.lblDateTimeValue.TabIndex = 5;
            this.lblDateTimeValue.Text = "--";
            // 
            // lblDoff
            // 
            this.lblDoff.AutoSize = true;
            this.lblDoff.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDoff.Location = new System.Drawing.Point(399, 30);
            this.lblDoff.Name = "lblDoff";
            this.lblDoff.Size = new System.Drawing.Size(32, 14);
            this.lblDoff.TabIndex = 10;
            this.lblDoff.Text = "Doff";
            // 
            // lblDoffValue
            // 
            this.lblDoffValue.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDoffValue.Location = new System.Drawing.Point(473, 30);
            this.lblDoffValue.Name = "lblDoffValue";
            this.lblDoffValue.Size = new System.Drawing.Size(157, 14);
            this.lblDoffValue.TabIndex = 11;
            this.lblDoffValue.Text = "--";
            // 
            // lblFilterType
            // 
            this.lblFilterType.AutoSize = true;
            this.lblFilterType.BackColor = System.Drawing.Color.Transparent;
            this.lblFilterType.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilterType.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblFilterType.Location = new System.Drawing.Point(4, 48);
            this.lblFilterType.Name = "lblFilterType";
            this.lblFilterType.Size = new System.Drawing.Size(79, 16);
            this.lblFilterType.TabIndex = 8;
            this.lblFilterType.Text = "Filter Type";
            // 
            // cmbFilterType
            // 
            this.cmbFilterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterType.FormattingEnabled = true;
            this.cmbFilterType.Items.AddRange(new object[] {
            "All",
            "Pass",
            "Fail"});
            this.cmbFilterType.Location = new System.Drawing.Point(82, 46);
            this.cmbFilterType.Name = "cmbFilterType";
            this.cmbFilterType.Size = new System.Drawing.Size(97, 20);
            this.cmbFilterType.TabIndex = 9;
            this.cmbFilterType.SelectedIndexChanged += new System.EventHandler(this.cmbFilterType_SelectedIndexChanged);
            // 
            // btnMapSetting
            // 
            this.btnMapSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMapSetting.Location = new System.Drawing.Point(504, 320);
            this.btnMapSetting.Name = "btnMapSetting";
            this.btnMapSetting.Size = new System.Drawing.Size(137, 32);
            this.btnMapSetting.TabIndex = 14;
            this.btnMapSetting.Text = "Map Setting";
            this.btnMapSetting.UseVisualStyleBackColor = true;
            this.btnMapSetting.Click += new System.EventHandler(this.btnMapSetting_Click);
            // 
            // btnFailPieceList
            // 
            this.btnFailPieceList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFailPieceList.Location = new System.Drawing.Point(504, 395);
            this.btnFailPieceList.Name = "btnFailPieceList";
            this.btnFailPieceList.Size = new System.Drawing.Size(137, 29);
            this.btnFailPieceList.TabIndex = 16;
            this.btnFailPieceList.Text = "Fail Piece List";
            this.btnFailPieceList.UseVisualStyleBackColor = true;
            this.btnFailPieceList.Click += new System.EventHandler(this.btnFailPieceList_Click);
            // 
            // btnGradeSetting
            // 
            this.btnGradeSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGradeSetting.Location = new System.Drawing.Point(504, 358);
            this.btnGradeSetting.Name = "btnGradeSetting";
            this.btnGradeSetting.Size = new System.Drawing.Size(137, 31);
            this.btnGradeSetting.TabIndex = 15;
            this.btnGradeSetting.Text = "Grade Setting";
            this.btnGradeSetting.UseVisualStyleBackColor = true;
            this.btnGradeSetting.Click += new System.EventHandler(this.btnGradeSetting_Click);
            // 
            // lblFail
            // 
            this.lblFail.AutoSize = true;
            this.lblFail.BackColor = System.Drawing.Color.Transparent;
            this.lblFail.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFail.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblFail.Location = new System.Drawing.Point(15, 9);
            this.lblFail.Name = "lblFail";
            this.lblFail.Size = new System.Drawing.Size(47, 26);
            this.lblFail.TabIndex = 0;
            this.lblFail.Text = "Fail";
            // 
            // lblFailValue
            // 
            this.lblFailValue.AutoSize = true;
            this.lblFailValue.BackColor = System.Drawing.Color.Transparent;
            this.lblFailValue.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFailValue.ForeColor = System.Drawing.Color.Red;
            this.lblFailValue.Location = new System.Drawing.Point(68, 9);
            this.lblFailValue.Name = "lblFailValue";
            this.lblFailValue.Size = new System.Drawing.Size(25, 26);
            this.lblFailValue.TabIndex = 1;
            this.lblFailValue.Text = "0";
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.BackColor = System.Drawing.Color.Transparent;
            this.lblPass.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPass.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblPass.Location = new System.Drawing.Point(143, 9);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(57, 26);
            this.lblPass.TabIndex = 2;
            this.lblPass.Text = "Pass";
            // 
            // lblPassValue
            // 
            this.lblPassValue.AutoSize = true;
            this.lblPassValue.BackColor = System.Drawing.Color.Transparent;
            this.lblPassValue.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassValue.ForeColor = System.Drawing.Color.Lime;
            this.lblPassValue.Location = new System.Drawing.Point(205, 9);
            this.lblPassValue.Name = "lblPassValue";
            this.lblPassValue.Size = new System.Drawing.Size(25, 26);
            this.lblPassValue.TabIndex = 3;
            this.lblPassValue.Text = "0";
            // 
            // lblYield
            // 
            this.lblYield.AutoSize = true;
            this.lblYield.BackColor = System.Drawing.Color.Transparent;
            this.lblYield.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYield.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblYield.Location = new System.Drawing.Point(296, 9);
            this.lblYield.Name = "lblYield";
            this.lblYield.Size = new System.Drawing.Size(63, 26);
            this.lblYield.TabIndex = 4;
            this.lblYield.Text = "Yield";
            // 
            // lblYieldValue
            // 
            this.lblYieldValue.AutoSize = true;
            this.lblYieldValue.BackColor = System.Drawing.Color.Transparent;
            this.lblYieldValue.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYieldValue.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblYieldValue.Location = new System.Drawing.Point(364, 9);
            this.lblYieldValue.Name = "lblYieldValue";
            this.lblYieldValue.Size = new System.Drawing.Size(44, 26);
            this.lblYieldValue.TabIndex = 5;
            this.lblYieldValue.Text = "0%";
            // 
            // lblGradeConfigFiles
            // 
            this.lblGradeConfigFiles.AutoSize = true;
            this.lblGradeConfigFiles.BackColor = System.Drawing.Color.Transparent;
            this.lblGradeConfigFiles.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGradeConfigFiles.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblGradeConfigFiles.Location = new System.Drawing.Point(207, 48);
            this.lblGradeConfigFiles.Name = "lblGradeConfigFiles";
            this.lblGradeConfigFiles.Size = new System.Drawing.Size(92, 16);
            this.lblGradeConfigFiles.TabIndex = 10;
            this.lblGradeConfigFiles.Text = "Grade Config";
            // 
            // cmbGradeConfigFiles
            // 
            this.cmbGradeConfigFiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGradeConfigFiles.FormattingEnabled = true;
            this.cmbGradeConfigFiles.Location = new System.Drawing.Point(301, 47);
            this.cmbGradeConfigFiles.Name = "cmbGradeConfigFiles";
            this.cmbGradeConfigFiles.Size = new System.Drawing.Size(198, 20);
            this.cmbGradeConfigFiles.TabIndex = 11;
            this.cmbGradeConfigFiles.DropDownClosed += new System.EventHandler(this.cmbGradeConfigFiles_DropDownClosed);
            // 
            // dgvFlawLegend
            // 
            this.dgvFlawLegend.AllowUserToAddRows = false;
            this.dgvFlawLegend.AllowUserToDeleteRows = false;
            this.dgvFlawLegend.AllowUserToResizeColumns = false;
            this.dgvFlawLegend.AllowUserToResizeRows = false;
            this.dgvFlawLegend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFlawLegend.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFlawLegend.Location = new System.Drawing.Point(504, 70);
            this.dgvFlawLegend.Name = "dgvFlawLegend";
            this.dgvFlawLegend.RowHeadersVisible = false;
            this.dgvFlawLegend.RowTemplate.Height = 24;
            this.dgvFlawLegend.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFlawLegend.Size = new System.Drawing.Size(137, 244);
            this.dgvFlawLegend.TabIndex = 13;
            this.dgvFlawLegend.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFlawLegend_CellContentClick);
            this.dgvFlawLegend.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvFlawLegend_CellFormatting);
            this.dgvFlawLegend.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFlawLegend_CellContentClick);
            // 
            // btnPrevPiece
            // 
            this.btnPrevPiece.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrevPiece.Enabled = false;
            this.btnPrevPiece.Location = new System.Drawing.Point(7, 556);
            this.btnPrevPiece.Name = "btnPrevPiece";
            this.btnPrevPiece.Size = new System.Drawing.Size(36, 32);
            this.btnPrevPiece.TabIndex = 17;
            this.btnPrevPiece.Text = "<";
            this.btnPrevPiece.UseVisualStyleBackColor = true;
            this.btnPrevPiece.Click += new System.EventHandler(this.btnPrevPiece_Click);
            // 
            // btnNextPiece
            // 
            this.btnNextPiece.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNextPiece.Enabled = false;
            this.btnNextPiece.Location = new System.Drawing.Point(464, 556);
            this.btnNextPiece.Name = "btnNextPiece";
            this.btnNextPiece.Size = new System.Drawing.Size(36, 32);
            this.btnNextPiece.TabIndex = 21;
            this.btnNextPiece.Text = ">";
            this.btnNextPiece.UseVisualStyleBackColor = true;
            this.btnNextPiece.Click += new System.EventHandler(this.btnNextPiece_Click);
            // 
            // lblN1
            // 
            this.lblN1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblN1.AutoSize = true;
            this.lblN1.BackColor = System.Drawing.Color.Transparent;
            this.lblN1.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblN1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblN1.Location = new System.Drawing.Point(243, 562);
            this.lblN1.Name = "lblN1";
            this.lblN1.Size = new System.Drawing.Size(21, 26);
            this.lblN1.TabIndex = 19;
            this.lblN1.Text = "/";
            // 
            // lblTotalPiece
            // 
            this.lblTotalPiece.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalPiece.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalPiece.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPiece.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblTotalPiece.Location = new System.Drawing.Point(269, 562);
            this.lblTotalPiece.Name = "lblTotalPiece";
            this.lblTotalPiece.Size = new System.Drawing.Size(80, 26);
            this.lblTotalPiece.TabIndex = 20;
            this.lblTotalPiece.Text = "---";
            // 
            // lblNowPiece
            // 
            this.lblNowPiece.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNowPiece.BackColor = System.Drawing.Color.Transparent;
            this.lblNowPiece.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNowPiece.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblNowPiece.Location = new System.Drawing.Point(158, 562);
            this.lblNowPiece.Name = "lblNowPiece";
            this.lblNowPiece.Size = new System.Drawing.Size(80, 26);
            this.lblNowPiece.TabIndex = 18;
            this.lblNowPiece.Text = "---";
            this.lblNowPiece.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // dgvFlawLegendDetial
            // 
            this.dgvFlawLegendDetial.AllowUserToAddRows = false;
            this.dgvFlawLegendDetial.AllowUserToDeleteRows = false;
            this.dgvFlawLegendDetial.AllowUserToResizeColumns = false;
            this.dgvFlawLegendDetial.AllowUserToResizeRows = false;
            this.dgvFlawLegendDetial.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFlawLegendDetial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFlawLegendDetial.Location = new System.Drawing.Point(6, 670);
            this.dgvFlawLegendDetial.Name = "dgvFlawLegendDetial";
            this.dgvFlawLegendDetial.ReadOnly = true;
            this.dgvFlawLegendDetial.RowHeadersVisible = false;
            this.dgvFlawLegendDetial.RowTemplate.Height = 24;
            this.dgvFlawLegendDetial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFlawLegendDetial.Size = new System.Drawing.Size(635, 150);
            this.dgvFlawLegendDetial.TabIndex = 23;
            this.dgvFlawLegendDetial.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvFlawLegendDetial_CellFormatting);
            // 
            // chartControl
            // 
            this.chartControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chartControl.Location = new System.Drawing.Point(6, 70);
            this.chartControl.Name = "chartControl";
            this.chartControl.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            sideBySideBarSeriesLabel2.LineVisible = true;
            this.chartControl.SeriesTemplate.Label = sideBySideBarSeriesLabel2;
            this.chartControl.Size = new System.Drawing.Size(493, 480);
            this.chartControl.TabIndex = 12;
            this.chartControl.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.chartControl_MouseDoubleClick);
            this.chartControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chartControl_MouseMove);
            this.chartControl.Click += new System.EventHandler(this.chartControl_Click);
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.BackColor = System.Drawing.Color.Transparent;
            this.lblScore.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblScore.Location = new System.Drawing.Point(474, 9);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(69, 26);
            this.lblScore.TabIndex = 6;
            this.lblScore.Text = "Score";
            // 
            // lblScoreValue
            // 
            this.lblScoreValue.AutoSize = true;
            this.lblScoreValue.BackColor = System.Drawing.Color.Transparent;
            this.lblScoreValue.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScoreValue.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblScoreValue.Location = new System.Drawing.Point(548, 9);
            this.lblScoreValue.Name = "lblScoreValue";
            this.lblScoreValue.Size = new System.Drawing.Size(25, 26);
            this.lblScoreValue.TabIndex = 7;
            this.lblScoreValue.Text = "0";
            // 
            // btnShowGoPage
            // 
            this.btnShowGoPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnShowGoPage.Enabled = false;
            this.btnShowGoPage.Location = new System.Drawing.Point(504, 556);
            this.btnShowGoPage.Name = "btnShowGoPage";
            this.btnShowGoPage.Size = new System.Drawing.Size(137, 32);
            this.btnShowGoPage.TabIndex = 24;
            this.btnShowGoPage.TabStop = false;
            this.btnShowGoPage.Text = "Goto...";
            this.btnShowGoPage.UseVisualStyleBackColor = true;
            this.btnShowGoPage.Click += new System.EventHandler(this.btnShowGoPage_Click);
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGo.Location = new System.Drawing.Point(576, 560);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(54, 26);
            this.btnGo.TabIndex = 26;
            this.btnGo.TabStop = false;
            this.btnGo.Text = "OK";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // txtGoPage
            // 
            this.txtGoPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtGoPage.Location = new System.Drawing.Point(516, 562);
            this.txtGoPage.Name = "txtGoPage";
            this.txtGoPage.Size = new System.Drawing.Size(57, 22);
            this.txtGoPage.TabIndex = 25;
            this.txtGoPage.TabStop = false;
            // 
            // MapWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::NPxP.Properties.Resources.BackgroundLeft;
            this.Controls.Add(this.btnShowGoPage);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtGoPage);
            this.Controls.Add(this.lblScoreValue);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.chartControl);
            this.Controls.Add(this.dgvFlawLegendDetial);
            this.Controls.Add(this.lblNowPiece);
            this.Controls.Add(this.lblTotalPiece);
            this.Controls.Add(this.lblN1);
            this.Controls.Add(this.btnNextPiece);
            this.Controls.Add(this.btnPrevPiece);
            this.Controls.Add(this.dgvFlawLegend);
            this.Controls.Add(this.cmbGradeConfigFiles);
            this.Controls.Add(this.lblGradeConfigFiles);
            this.Controls.Add(this.lblYieldValue);
            this.Controls.Add(this.lblYield);
            this.Controls.Add(this.lblPassValue);
            this.Controls.Add(this.lblPass);
            this.Controls.Add(this.lblFailValue);
            this.Controls.Add(this.lblFail);
            this.Controls.Add(this.btnGradeSetting);
            this.Controls.Add(this.btnFailPieceList);
            this.Controls.Add(this.btnMapSetting);
            this.Controls.Add(this.cmbFilterType);
            this.Controls.Add(this.lblFilterType);
            this.Controls.Add(this.tlpMapInfo);
            this.Name = "MapWindow";
            this.Size = new System.Drawing.Size(650, 848);
            this.Load += new System.EventHandler(this.MapWindow_Load);
            this.tlpMapInfo.ResumeLayout(false);
            this.tlpMapInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFlawLegend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFlawLegendDetial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMapInfo;
        private System.Windows.Forms.Label lblOrderNumber;
        private System.Windows.Forms.Label lblDateTimeValue;
        private System.Windows.Forms.Label lblDateTime;
        private System.Windows.Forms.Label lblOperatorValue;
        private System.Windows.Forms.Label lblOperator;
        private System.Windows.Forms.Label lblMeterialType;
        private System.Windows.Forms.Label lblMeterialTypeValue;
        private System.Windows.Forms.Label lblDoff;
        private System.Windows.Forms.Label lblJobId;
        private System.Windows.Forms.Label lblOrderNumberValue;
        private System.Windows.Forms.Label lblJobIdValue;
        private System.Windows.Forms.Label lblDoffValue;
        private System.Windows.Forms.Label lblFilterType;
        private System.Windows.Forms.ComboBox cmbFilterType;
        private System.Windows.Forms.Button btnMapSetting;
        private System.Windows.Forms.Button btnFailPieceList;
        private System.Windows.Forms.Button btnGradeSetting;
        private System.Windows.Forms.Label lblFail;
        private System.Windows.Forms.Label lblFailValue;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.Label lblPassValue;
        private System.Windows.Forms.Label lblYield;
        private System.Windows.Forms.Label lblYieldValue;
        private System.Windows.Forms.Label lblGradeConfigFiles;
        public System.Windows.Forms.ComboBox cmbGradeConfigFiles;
        private System.Windows.Forms.DataGridView dgvFlawLegend;
        private System.Windows.Forms.Label lblN1;
        private System.Windows.Forms.Label lblTotalPiece;
        private System.Windows.Forms.Label lblNowPiece;
        private System.Windows.Forms.DataGridView dgvFlawLegendDetial;
        private DevExpress.XtraCharts.ChartControl chartControl;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblScoreValue;
        public System.Windows.Forms.Button btnPrevPiece;
        public System.Windows.Forms.Button btnNextPiece;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.TextBox txtGoPage;
        public System.Windows.Forms.Button btnShowGoPage;
    }
}
