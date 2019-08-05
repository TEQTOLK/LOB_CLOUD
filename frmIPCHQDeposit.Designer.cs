namespace LOB
{
    partial class frmIPCHQDeposit
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
            this.label21 = new System.Windows.Forms.Label();
            this.btnDeselect = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnShow = new System.Windows.Forms.Button();
            this.pnlDate = new System.Windows.Forms.Panel();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnRange = new System.Windows.Forms.Button();
            this.btnALLChq = new System.Windows.Forms.Button();
            this.btnTodayCHQ = new System.Windows.Forms.Button();
            this.btnEarlierCHQ = new System.Windows.Forms.Button();
            this.lstGrid = new System.Windows.Forms.ListView();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTotChq = new System.Windows.Forms.Label();
            this.lblTotalChqVal = new System.Windows.Forms.Label();
            this.lblSelectedChqVal = new System.Windows.Forms.Label();
            this.lblSelectedChq = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.pnlDate.SuspendLayout();
            this.SuspendLayout();
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.White;
            this.label21.Font = new System.Drawing.Font("Calibri", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.Blue;
            this.label21.Location = new System.Drawing.Point(492, 326);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(239, 18);
            this.label21.TabIndex = 534;
            this.label21.Text = "Enter Cheque Numbers Here to Search";
            // 
            // btnDeselect
            // 
            this.btnDeselect.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDeselect.Font = new System.Drawing.Font("Calibri", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeselect.Location = new System.Drawing.Point(111, 325);
            this.btnDeselect.Name = "btnDeselect";
            this.btnDeselect.Size = new System.Drawing.Size(89, 25);
            this.btnDeselect.TabIndex = 524;
            this.btnDeselect.Text = "Deselect All";
            this.btnDeselect.UseVisualStyleBackColor = true;
            this.btnDeselect.Click += new System.EventHandler(this.btnDeselect_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSelect.Font = new System.Drawing.Font("Calibri", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelect.Location = new System.Drawing.Point(16, 325);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(89, 25);
            this.btnSelect.TabIndex = 523;
            this.btnSelect.Text = "Select All";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnShow
            // 
            this.btnShow.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnShow.Font = new System.Drawing.Font("Calibri", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShow.Location = new System.Drawing.Point(232, 2);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(71, 25);
            this.btnShow.TabIndex = 2;
            this.btnShow.Text = "Show";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // pnlDate
            // 
            this.pnlDate.Controls.Add(this.btnShow);
            this.pnlDate.Controls.Add(this.dtpFrom);
            this.pnlDate.Controls.Add(this.dtpTo);
            this.pnlDate.Location = new System.Drawing.Point(491, 38);
            this.pnlDate.Name = "pnlDate";
            this.pnlDate.Size = new System.Drawing.Size(334, 30);
            this.pnlDate.TabIndex = 522;
            this.pnlDate.Visible = false;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(3, 4);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(108, 23);
            this.dtpFrom.TabIndex = 0;
            // 
            // dtpTo
            // 
            this.dtpTo.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(118, 4);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(108, 23);
            this.dtpTo.TabIndex = 1;
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(737, 325);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(108, 22);
            this.txtSearch.TabIndex = 525;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // btnRange
            // 
            this.btnRange.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnRange.Font = new System.Drawing.Font("Calibri", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRange.Location = new System.Drawing.Point(364, 41);
            this.btnRange.Name = "btnRange";
            this.btnRange.Size = new System.Drawing.Size(115, 25);
            this.btnRange.TabIndex = 521;
            this.btnRange.Text = "During Date Range";
            this.btnRange.UseVisualStyleBackColor = true;
            this.btnRange.Click += new System.EventHandler(this.btnRange_Click);
            // 
            // btnALLChq
            // 
            this.btnALLChq.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnALLChq.Font = new System.Drawing.Font("Calibri", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnALLChq.Location = new System.Drawing.Point(248, 41);
            this.btnALLChq.Name = "btnALLChq";
            this.btnALLChq.Size = new System.Drawing.Size(110, 25);
            this.btnALLChq.TabIndex = 520;
            this.btnALLChq.Text = "All Cheques";
            this.btnALLChq.UseVisualStyleBackColor = true;
            this.btnALLChq.Click += new System.EventHandler(this.btnALLChq_Click);
            // 
            // btnTodayCHQ
            // 
            this.btnTodayCHQ.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnTodayCHQ.Font = new System.Drawing.Font("Calibri", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTodayCHQ.Location = new System.Drawing.Point(132, 41);
            this.btnTodayCHQ.Name = "btnTodayCHQ";
            this.btnTodayCHQ.Size = new System.Drawing.Size(110, 25);
            this.btnTodayCHQ.TabIndex = 519;
            this.btnTodayCHQ.Text = "Today Cheques";
            this.btnTodayCHQ.UseVisualStyleBackColor = true;
            this.btnTodayCHQ.Click += new System.EventHandler(this.btnTodayCHQ_Click);
            // 
            // btnEarlierCHQ
            // 
            this.btnEarlierCHQ.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnEarlierCHQ.Font = new System.Drawing.Font("Calibri", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEarlierCHQ.Location = new System.Drawing.Point(16, 41);
            this.btnEarlierCHQ.Name = "btnEarlierCHQ";
            this.btnEarlierCHQ.Size = new System.Drawing.Size(110, 25);
            this.btnEarlierCHQ.TabIndex = 518;
            this.btnEarlierCHQ.Text = "Earlier Cheques";
            this.btnEarlierCHQ.UseVisualStyleBackColor = true;
            this.btnEarlierCHQ.Click += new System.EventHandler(this.btnEarlierCHQ_Click);
            // 
            // lstGrid
            // 
            this.lstGrid.CheckBoxes = true;
            this.lstGrid.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstGrid.FullRowSelect = true;
            this.lstGrid.GridLines = true;
            this.lstGrid.Location = new System.Drawing.Point(16, 74);
            this.lstGrid.Name = "lstGrid";
            this.lstGrid.Size = new System.Drawing.Size(829, 245);
            this.lstGrid.TabIndex = 532;
            this.lstGrid.UseCompatibleStateImageBehavior = false;
            this.lstGrid.View = System.Windows.Forms.View.Details;
            this.lstGrid.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lstGrid_ItemChecked);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(113)))), ((int)(((byte)(198)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(754, 397);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(91, 34);
            this.btnClose.TabIndex = 527;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(113)))), ((int)(((byte)(198)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(657, 397);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(91, 34);
            this.btnSave.TabIndex = 526;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.GrayText;
            this.label5.Font = new System.Drawing.Font("Calibri", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(5, 389);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(856, 49);
            this.label5.TabIndex = 531;
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.GrayText;
            this.label2.Font = new System.Drawing.Font("Calibri", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(856, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(5, 374);
            this.label2.TabIndex = 530;
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.GrayText;
            this.label1.Font = new System.Drawing.Font("Calibri", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(-5, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 403);
            this.label1.TabIndex = 529;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.SystemColors.GrayText;
            this.label14.Font = new System.Drawing.Font("Calibri", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(0, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(861, 35);
            this.label14.TabIndex = 528;
            this.label14.Text = "CHEQUE DEPOSITE";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(13, 362);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 20);
            this.label6.TabIndex = 535;
            this.label6.Text = "Total No of CHQ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(362, 362);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 20);
            this.label3.TabIndex = 536;
            this.label3.Text = "Total CHQ Value";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(598, 362);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 20);
            this.label4.TabIndex = 537;
            this.label4.Text = "Selected CHQ Value";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotChq
            // 
            this.lblTotChq.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotChq.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblTotChq.Location = new System.Drawing.Point(121, 362);
            this.lblTotChq.Name = "lblTotChq";
            this.lblTotChq.Size = new System.Drawing.Size(67, 20);
            this.lblTotChq.TabIndex = 538;
            this.lblTotChq.Text = "0";
            this.lblTotChq.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalChqVal
            // 
            this.lblTotalChqVal.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalChqVal.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblTotalChqVal.Location = new System.Drawing.Point(472, 362);
            this.lblTotalChqVal.Name = "lblTotalChqVal";
            this.lblTotalChqVal.Size = new System.Drawing.Size(109, 20);
            this.lblTotalChqVal.TabIndex = 539;
            this.lblTotalChqVal.Text = "0.00";
            this.lblTotalChqVal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSelectedChqVal
            // 
            this.lblSelectedChqVal.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedChqVal.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblSelectedChqVal.Location = new System.Drawing.Point(726, 362);
            this.lblSelectedChqVal.Name = "lblSelectedChqVal";
            this.lblSelectedChqVal.Size = new System.Drawing.Size(109, 20);
            this.lblSelectedChqVal.TabIndex = 540;
            this.lblSelectedChqVal.Text = "0.00";
            this.lblSelectedChqVal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSelectedChq
            // 
            this.lblSelectedChq.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedChq.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblSelectedChq.Location = new System.Drawing.Point(288, 362);
            this.lblSelectedChq.Name = "lblSelectedChq";
            this.lblSelectedChq.Size = new System.Drawing.Size(67, 20);
            this.lblSelectedChq.TabIndex = 542;
            this.lblSelectedChq.Text = "0";
            this.lblSelectedChq.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(180, 362);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(102, 20);
            this.label11.TabIndex = 541;
            this.label11.Text = "Selected CHQ";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(113)))), ((int)(((byte)(198)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(5, 397);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 34);
            this.button1.TabIndex = 585;
            this.button1.Text = "Enquiry";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // frmIPCHQDeposit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(861, 438);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblSelectedChq);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lblSelectedChqVal);
            this.Controls.Add(this.lblTotalChqVal);
            this.Controls.Add(this.lblTotChq);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.btnDeselect);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.pnlDate);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnRange);
            this.Controls.Add(this.btnALLChq);
            this.Controls.Add(this.btnTodayCHQ);
            this.Controls.Add(this.btnEarlierCHQ);
            this.Controls.Add(this.lstGrid);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label14);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmIPCHQDeposit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CHQ DEPOSITE";
            this.Load += new System.EventHandler(this.frmIPCHQDeposit_Load);
            this.pnlDate.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button btnDeselect;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Panel pnlDate;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.DateTimePicker dtpTo;
        public System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnRange;
        private System.Windows.Forms.Button btnALLChq;
        private System.Windows.Forms.Button btnTodayCHQ;
        private System.Windows.Forms.Button btnEarlierCHQ;
        public System.Windows.Forms.ListView lstGrid;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTotChq;
        private System.Windows.Forms.Label lblTotalChqVal;
        private System.Windows.Forms.Label lblSelectedChqVal;
        private System.Windows.Forms.Label lblSelectedChq;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button1;
    }
}