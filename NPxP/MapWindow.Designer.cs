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

            //DevExpress.XtraCharts.SideBySideBarSeriesLabel sideBySideBarSeriesLabel2 = new DevExpress.XtraCharts.SideBySideBarSeriesLabel();
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbGradeConfigFiles = new System.Windows.Forms.ComboBox();
            this.dgvFlawLegend = new System.Windows.Forms.DataGridView();
            this.btnPrevPiece = new System.Windows.Forms.Button();
            this.btnNextPiece = new System.Windows.Forms.Button();
            this.lblN1 = new System.Windows.Forms.Label();
            this.lblTotalPiece = new System.Windows.Forms.Label();
            this.lblNowPiece = new System.Windows.Forms.Label();
            this.dgvFlawLegendDetial = new System.Windows.Forms.DataGridView();
            this.tlpMapInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFlawLegend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFlawLegendDetial)).BeginInit();

            //((System.ComponentModel.ISupportInitialize)(this.chartControl)).BeginInit();
            //((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel2)).BeginInit();
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

            this.tlpMapInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
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
            this.tlpMapInfo.Location = new System.Drawing.Point(7, 594);
            this.tlpMapInfo.Name = "tlpMapInfo";
            this.tlpMapInfo.Padding = new System.Windows.Forms.Padding(2);
            this.tlpMapInfo.RowCount = 2;
            this.tlpMapInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMapInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMapInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMapInfo.Size = new System.Drawing.Size(636, 59);
            this.tlpMapInfo.TabIndex = 0;
            // 
            // lblOperatorValue
            // 
            this.lblOperatorValue.AutoSize = true;
            this.lblOperatorValue.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOperatorValue.Location = new System.Drawing.Point(291, 30);
            this.lblOperatorValue.Name = "lblOperatorValue";
            this.lblOperatorValue.Size = new System.Drawing.Size(19, 14);
            this.lblOperatorValue.TabIndex = 8;
            this.lblOperatorValue.Text = "--";
            // 
            // lblOperator
            // 
            this.lblOperator.AutoSize = true;
            this.lblOperator.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOperator.Location = new System.Drawing.Point(193, 30);
            this.lblOperator.Name = "lblOperator";
            this.lblOperator.Size = new System.Drawing.Size(64, 14);
            this.lblOperator.TabIndex = 7;
            this.lblOperator.Text = "Operator";
            // 
            // lblMeterialType
            // 
            this.lblMeterialType.AutoSize = true;
            this.lblMeterialType.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMeterialType.Location = new System.Drawing.Point(193, 3);
            this.lblMeterialType.Name = "lblMeterialType";
            this.lblMeterialType.Size = new System.Drawing.Size(91, 14);
            this.lblMeterialType.TabIndex = 6;
            this.lblMeterialType.Text = "Meterial Type";
            // 
            // lblMeterialTypeValue
            // 
            this.lblMeterialTypeValue.AutoSize = true;
            this.lblMeterialTypeValue.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMeterialTypeValue.Location = new System.Drawing.Point(291, 3);
            this.lblMeterialTypeValue.Name = "lblMeterialTypeValue";
            this.lblMeterialTypeValue.Size = new System.Drawing.Size(19, 14);
            this.lblMeterialTypeValue.TabIndex = 4;
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
            this.lblJobId.TabIndex = 1;
            this.lblJobId.Text = "Job ID";
            // 
            // lblOrderNumberValue
            // 
            this.lblOrderNumberValue.AutoSize = true;
            this.lblOrderNumberValue.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderNumberValue.Location = new System.Drawing.Point(120, 3);
            this.lblOrderNumberValue.Name = "lblOrderNumberValue";
            this.lblOrderNumberValue.Size = new System.Drawing.Size(19, 14);
            this.lblOrderNumberValue.TabIndex = 3;
            this.lblOrderNumberValue.Text = "--";
            // 
            // lblJobIdValue
            // 
            this.lblJobIdValue.AutoSize = true;
            this.lblJobIdValue.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJobIdValue.Location = new System.Drawing.Point(120, 30);
            this.lblJobIdValue.Name = "lblJobIdValue";
            this.lblJobIdValue.Size = new System.Drawing.Size(19, 14);
            this.lblJobIdValue.TabIndex = 4;
            this.lblJobIdValue.Text = "--";
            // 
            // lblDateTime
            // 
            this.lblDateTime.AutoSize = true;
            this.lblDateTime.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateTime.Location = new System.Drawing.Point(415, 3);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(66, 14);
            this.lblDateTime.TabIndex = 9;
            this.lblDateTime.Text = "DateTime";
            // 
            // lblDateTimeValue
            // 
            this.lblDateTimeValue.AutoSize = true;
            this.lblDateTimeValue.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateTimeValue.Location = new System.Drawing.Point(489, 3);
            this.lblDateTimeValue.Name = "lblDateTimeValue";
            this.lblDateTimeValue.Size = new System.Drawing.Size(19, 14);
            this.lblDateTimeValue.TabIndex = 10;
            this.lblDateTimeValue.Text = "--";
            // 
            // lblDoff
            // 
            this.lblDoff.AutoSize = true;
            this.lblDoff.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDoff.Location = new System.Drawing.Point(415, 30);
            this.lblDoff.Name = "lblDoff";
            this.lblDoff.Size = new System.Drawing.Size(32, 14);
            this.lblDoff.TabIndex = 2;
            this.lblDoff.Text = "Doff";
            // 
            // lblDoffValue
            // 
            this.lblDoffValue.AutoSize = true;
            this.lblDoffValue.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDoffValue.Location = new System.Drawing.Point(485, 30);
            this.lblDoffValue.Name = "lblDoffValue";
            this.lblDoffValue.Size = new System.Drawing.Size(19, 14);
            this.lblDoffValue.TabIndex = 5;
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
            this.lblFilterType.TabIndex = 1;
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
            this.cmbFilterType.TabIndex = 2;
            this.cmbFilterType.SelectedIndexChanged += new System.EventHandler(this.cmbFilterType_SelectedIndexChanged);
            // 
            // btnMapSetting
            // 
            this.btnMapSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMapSetting.Location = new System.Drawing.Point(504, 320);
            this.btnMapSetting.Name = "btnMapSetting";
            this.btnMapSetting.Size = new System.Drawing.Size(137, 32);
            this.btnMapSetting.TabIndex = 3;
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
            this.btnFailPieceList.TabIndex = 4;
            this.btnFailPieceList.Text = "Fail Piece List";
            this.btnFailPieceList.UseVisualStyleBackColor = true;
            // 
            // btnGradeSetting
            // 
            this.btnGradeSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGradeSetting.Location = new System.Drawing.Point(504, 358);
            this.btnGradeSetting.Name = "btnGradeSetting";
            this.btnGradeSetting.Size = new System.Drawing.Size(137, 31);
            this.btnGradeSetting.TabIndex = 5;
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
            this.lblFail.Location = new System.Drawing.Point(77, 12);
            this.lblFail.Name = "lblFail";
            this.lblFail.Size = new System.Drawing.Size(47, 26);
            this.lblFail.TabIndex = 6;
            this.lblFail.Text = "Fail";
            // 
            // lblFailValue
            // 
            this.lblFailValue.AutoSize = true;
            this.lblFailValue.BackColor = System.Drawing.Color.Transparent;
            this.lblFailValue.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFailValue.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblFailValue.Location = new System.Drawing.Point(130, 12);
            this.lblFailValue.Name = "lblFailValue";
            this.lblFailValue.Size = new System.Drawing.Size(25, 26);
            this.lblFailValue.TabIndex = 7;
            this.lblFailValue.Text = "0";
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.BackColor = System.Drawing.Color.Transparent;
            this.lblPass.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPass.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblPass.Location = new System.Drawing.Point(205, 12);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(57, 26);
            this.lblPass.TabIndex = 8;
            this.lblPass.Text = "Pass";
            // 
            // lblPassValue
            // 
            this.lblPassValue.AutoSize = true;
            this.lblPassValue.BackColor = System.Drawing.Color.Transparent;
            this.lblPassValue.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassValue.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblPassValue.Location = new System.Drawing.Point(270, 12);
            this.lblPassValue.Name = "lblPassValue";
            this.lblPassValue.Size = new System.Drawing.Size(25, 26);
            this.lblPassValue.TabIndex = 9;
            this.lblPassValue.Text = "0";
            // 
            // lblYield
            // 
            this.lblYield.AutoSize = true;
            this.lblYield.BackColor = System.Drawing.Color.Transparent;
            this.lblYield.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYield.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblYield.Location = new System.Drawing.Point(372, 12);
            this.lblYield.Name = "lblYield";
            this.lblYield.Size = new System.Drawing.Size(63, 26);
            this.lblYield.TabIndex = 10;
            this.lblYield.Text = "Yield";
            // 
            // lblYieldValue
            // 
            this.lblYieldValue.AutoSize = true;
            this.lblYieldValue.BackColor = System.Drawing.Color.Transparent;
            this.lblYieldValue.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYieldValue.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblYieldValue.Location = new System.Drawing.Point(428, 12);
            this.lblYieldValue.Name = "lblYieldValue";
            this.lblYieldValue.Size = new System.Drawing.Size(70, 26);
            this.lblYieldValue.TabIndex = 11;
            this.lblYieldValue.Text = "999%";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(207, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 16);
            this.label1.TabIndex = 12;
            this.label1.Text = "Grade Config";
            // 
            // cmbGradeConfigFiles
            // 
            this.cmbGradeConfigFiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGradeConfigFiles.FormattingEnabled = true;
            this.cmbGradeConfigFiles.Location = new System.Drawing.Point(301, 47);
            this.cmbGradeConfigFiles.Name = "cmbGradeConfigFiles";
            this.cmbGradeConfigFiles.Size = new System.Drawing.Size(198, 20);
            this.cmbGradeConfigFiles.TabIndex = 13;
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
            this.dgvFlawLegend.TabIndex = 15;
            this.dgvFlawLegend.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvFlawLegend_CellFormatting);
            this.dgvFlawLegend.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFlawLegend_CellContentClick);
            // 
            // btnPrevPiece
            // 
            this.btnPrevPiece.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrevPiece.Location = new System.Drawing.Point(7, 556);
            this.btnPrevPiece.Name = "btnPrevPiece";
            this.btnPrevPiece.Size = new System.Drawing.Size(36, 32);
            this.btnPrevPiece.TabIndex = 16;
            this.btnPrevPiece.Text = "<";
            this.btnPrevPiece.UseVisualStyleBackColor = true;
            this.btnPrevPiece.Click += new System.EventHandler(this.btnPrevPiece_Click);
            // 
            // btnNextPiece
            // 
            this.btnNextPiece.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNextPiece.Location = new System.Drawing.Point(464, 556);
            this.btnNextPiece.Name = "btnNextPiece";
            this.btnNextPiece.Size = new System.Drawing.Size(36, 32);
            this.btnNextPiece.TabIndex = 17;
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
            this.lblTotalPiece.Size = new System.Drawing.Size(39, 26);
            this.lblTotalPiece.TabIndex = 20;
            this.lblTotalPiece.Text = "---";
            // 
            // lblNowPiece
            // 
            this.lblNowPiece.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNowPiece.BackColor = System.Drawing.Color.Transparent;
            this.lblNowPiece.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNowPiece.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblNowPiece.Location = new System.Drawing.Point(199, 562);
            this.lblNowPiece.Name = "lblNowPiece";
            this.lblNowPiece.Size = new System.Drawing.Size(39, 26);
            this.lblNowPiece.TabIndex = 21;
            this.lblNowPiece.Text = "---";
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
            this.dgvFlawLegendDetial.Location = new System.Drawing.Point(6, 660);
            this.dgvFlawLegendDetial.Name = "dgvFlawLegendDetial";
            this.dgvFlawLegendDetial.ReadOnly = true;
            this.dgvFlawLegendDetial.RowHeadersVisible = false;
            this.dgvFlawLegendDetial.RowTemplate.Height = 24;
            this.dgvFlawLegendDetial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFlawLegendDetial.Size = new System.Drawing.Size(635, 150);
            this.dgvFlawLegendDetial.TabIndex = 22;
            this.dgvFlawLegendDetial.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvFlawLegendDetial_CellFormatting);
            // 
            // chartControl
            ////------ 
            //this.chartControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            //            | System.Windows.Forms.AnchorStyles.Left)
            //            | System.Windows.Forms.AnchorStyles.Right)));
            //this.chartControl.Location = new System.Drawing.Point(6, 70);
            //this.chartControl.Name = "chartControl";
            //this.chartControl.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            //sideBySideBarSeriesLabel2.LineVisible = true;
            //this.chartControl.SeriesTemplate.Label = sideBySideBarSeriesLabel2;
            //this.chartControl.Size = new System.Drawing.Size(493, 480);
            //this.chartControl.TabIndex = 24;
            //this.chartControl.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.chartControl_MouseDoubleClick);
            //this.chartControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chartControl_MouseMove);
            // 
            // MapWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::NPxP.Properties.Resources.BackgroundLeft;
            this.Controls.Add(this.dgvFlawLegendDetial);
            this.Controls.Add(this.lblNowPiece);
            this.Controls.Add(this.lblTotalPiece);
            this.Controls.Add(this.lblN1);
            this.Controls.Add(this.btnNextPiece);
            this.Controls.Add(this.btnPrevPiece);
            this.Controls.Add(this.dgvFlawLegend);
            this.Controls.Add(this.cmbGradeConfigFiles);
            this.Controls.Add(this.label1);
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
            //((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel2)).EndInit();
            //((System.ComponentModel.ISupportInitialize)(this.chartControl)).EndInit();
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
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox cmbGradeConfigFiles;
        private System.Windows.Forms.DataGridView dgvFlawLegend;
        private System.Windows.Forms.Button btnPrevPiece;
        private System.Windows.Forms.Button btnNextPiece;
        private System.Windows.Forms.Label lblN1;
        private System.Windows.Forms.Label lblTotalPiece;
        private System.Windows.Forms.Label lblNowPiece;
        private System.Windows.Forms.DataGridView dgvFlawLegendDetial;
    }
}
