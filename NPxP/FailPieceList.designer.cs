﻿namespace NPxP
{
    partial class FailPieceList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvFailPieceList = new System.Windows.Forms.DataGridView();
            this.colPieceNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFlawQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbHint = new System.Windows.Forms.Label();
            this.lbDescriptionContent1 = new System.Windows.Forms.Label();
            this.lbDescriptionContent2 = new System.Windows.Forms.Label();
            this.lbDescriptionTitle2 = new System.Windows.Forms.Label();
            this.lbDescriptionTitle1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFailPieceList)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvFailPieceList
            // 
            this.dgvFailPieceList.AllowUserToAddRows = false;
            this.dgvFailPieceList.AllowUserToDeleteRows = false;
            this.dgvFailPieceList.AllowUserToResizeColumns = false;
            this.dgvFailPieceList.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFailPieceList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvFailPieceList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFailPieceList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPieceNum,
            this.colFlawQuantity});
            this.dgvFailPieceList.Location = new System.Drawing.Point(14, 13);
            this.dgvFailPieceList.MultiSelect = false;
            this.dgvFailPieceList.Name = "dgvFailPieceList";
            this.dgvFailPieceList.ReadOnly = true;
            this.dgvFailPieceList.RowHeadersVisible = false;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvFailPieceList.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvFailPieceList.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvFailPieceList.RowTemplate.Height = 24;
            this.dgvFailPieceList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFailPieceList.Size = new System.Drawing.Size(292, 406);
            this.dgvFailPieceList.TabIndex = 0;
            this.dgvFailPieceList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvFailList_CellDoubleClick);
            // 
            // colPieceNum
            // 
            this.colPieceNum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colPieceNum.DefaultCellStyle = dataGridViewCellStyle6;
            this.colPieceNum.HeaderText = "Piece No.";
            this.colPieceNum.Name = "colPieceNum";
            this.colPieceNum.ReadOnly = true;
            // 
            // colFlawQuantity
            // 
            this.colFlawQuantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colFlawQuantity.DefaultCellStyle = dataGridViewCellStyle7;
            this.colFlawQuantity.HeaderText = "Flaw Quantity";
            this.colFlawQuantity.Name = "colFlawQuantity";
            this.colFlawQuantity.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbHint);
            this.groupBox1.Controls.Add(this.lbDescriptionContent1);
            this.groupBox1.Controls.Add(this.lbDescriptionContent2);
            this.groupBox1.Controls.Add(this.lbDescriptionTitle2);
            this.groupBox1.Controls.Add(this.lbDescriptionTitle1);
            this.groupBox1.Location = new System.Drawing.Point(14, 427);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(292, 84);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // lbHint
            // 
            this.lbHint.AutoSize = true;
            this.lbHint.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHint.Location = new System.Drawing.Point(7, 58);
            this.lbHint.Name = "lbHint";
            this.lbHint.Size = new System.Drawing.Size(277, 14);
            this.lbHint.TabIndex = 0;
            this.lbHint.Text = "※ Double-click on row to view the piece.";
            // 
            // lbDescriptionContent1
            // 
            this.lbDescriptionContent1.AutoSize = true;
            this.lbDescriptionContent1.Font = new System.Drawing.Font("Verdana", 9F);
            this.lbDescriptionContent1.Location = new System.Drawing.Point(74, 12);
            this.lbDescriptionContent1.Name = "lbDescriptionContent1";
            this.lbDescriptionContent1.Size = new System.Drawing.Size(189, 14);
            this.lbDescriptionContent1.TabIndex = 0;
            this.lbDescriptionContent1.Text = "Serial number of failed piece.";
            // 
            // lbDescriptionContent2
            // 
            this.lbDescriptionContent2.AutoSize = true;
            this.lbDescriptionContent2.Font = new System.Drawing.Font("Verdana", 9F);
            this.lbDescriptionContent2.Location = new System.Drawing.Point(104, 34);
            this.lbDescriptionContent2.Name = "lbDescriptionContent2";
            this.lbDescriptionContent2.Size = new System.Drawing.Size(187, 14);
            this.lbDescriptionContent2.TabIndex = 0;
            this.lbDescriptionContent2.Text = "Flaw quantity of failed piece.";
            // 
            // lbDescriptionTitle2
            // 
            this.lbDescriptionTitle2.AutoSize = true;
            this.lbDescriptionTitle2.Font = new System.Drawing.Font("Verdana", 9F);
            this.lbDescriptionTitle2.Location = new System.Drawing.Point(7, 34);
            this.lbDescriptionTitle2.Name = "lbDescriptionTitle2";
            this.lbDescriptionTitle2.Size = new System.Drawing.Size(99, 14);
            this.lbDescriptionTitle2.TabIndex = 0;
            this.lbDescriptionTitle2.Text = "Flaw Quantity:";
            // 
            // lbDescriptionTitle1
            // 
            this.lbDescriptionTitle1.AutoSize = true;
            this.lbDescriptionTitle1.Font = new System.Drawing.Font("Verdana", 9F);
            this.lbDescriptionTitle1.Location = new System.Drawing.Point(6, 12);
            this.lbDescriptionTitle1.Name = "lbDescriptionTitle1";
            this.lbDescriptionTitle1.Size = new System.Drawing.Size(70, 14);
            this.lbDescriptionTitle1.TabIndex = 0;
            this.lbDescriptionTitle1.Text = "Piece No.:";
            // 
            // FailPieceList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 519);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvFailPieceList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FailPieceList";
            this.Text = "Fail Piece List";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FailList_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FailList_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFailPieceList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvFailPieceList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbDescriptionTitle1;
        private System.Windows.Forms.Label lbHint;
        private System.Windows.Forms.Label lbDescriptionTitle2;
        private System.Windows.Forms.Label lbDescriptionContent2;
        private System.Windows.Forms.Label lbDescriptionContent1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPieceNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFlawQuantity;
    }
}