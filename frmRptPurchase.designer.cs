namespace LOB
{
    partial class frmRptPurchase
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
            this.label14 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlOther = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cboDateRange = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.pnlInvoice = new System.Windows.Forms.Panel();
            this.btnFInvoice = new System.Windows.Forms.Button();
            this.txtInvoice = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cboBranch = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnShow = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pnlPartiCus = new System.Windows.Forms.Panel();
            this.btnFCus = new System.Windows.Forms.Button();
            this.txtCusCode = new System.Windows.Forms.TextBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.pnlAllCustomer = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.cboBasedOn = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rptView = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.panel1.SuspendLayout();
            this.pnlOther.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.pnlInvoice.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pnlPartiCus.SuspendLayout();
            this.pnlAllCustomer.SuspendLayout();
            this.SuspendLayout();
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.SystemColors.GrayText;
            this.label14.Dock = System.Windows.Forms.DockStyle.Top;
            this.label14.Font = new System.Drawing.Font("Calibri", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(0, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(1008, 35);
            this.label14.TabIndex = 572;
            this.label14.Text = "PURCHASE/GRN REPORT";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pnlOther);
            this.panel1.Controls.Add(this.pnlInvoice);
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.btnShow);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(758, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 694);
            this.panel1.TabIndex = 573;
            // 
            // pnlOther
            // 
            this.pnlOther.Controls.Add(this.label3);
            this.pnlOther.Controls.Add(this.groupBox3);
            this.pnlOther.Location = new System.Drawing.Point(6, 436);
            this.pnlOther.Name = "pnlOther";
            this.pnlOther.Size = new System.Drawing.Size(241, 224);
            this.pnlOther.TabIndex = 583;
            this.pnlOther.TabStop = false;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.GrayText;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(1, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(232, 25);
            this.label3.TabIndex = 578;
            this.label3.Text = "DATE RANGE";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cboDateRange);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.dtpTo);
            this.groupBox3.Controls.Add(this.dtpFrom);
            this.groupBox3.Location = new System.Drawing.Point(0, 133);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(235, 85);
            this.groupBox3.TabIndex = 579;
            this.groupBox3.TabStop = false;
            // 
            // cboDateRange
            // 
            this.cboDateRange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDateRange.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDateRange.FormattingEnabled = true;
            this.cboDateRange.Items.AddRange(new object[] {
            "ALL",
            "TODAY",
            "THIS MONTH TO DATE",
            "LAST MONTH",
            "THIS YEAR TO DATE"});
            this.cboDateRange.Location = new System.Drawing.Point(7, 12);
            this.cboDateRange.Name = "cboDateRange";
            this.cboDateRange.Size = new System.Drawing.Size(223, 24);
            this.cboDateRange.TabIndex = 1;
            this.cboDateRange.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.cboDateRange.Validating += new System.ComponentModel.CancelEventHandler(this.cboDateRange_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(126, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 14);
            this.label4.TabIndex = 580;
            this.label4.Text = "TO";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 14);
            this.label6.TabIndex = 578;
            this.label6.Text = "FROM";
            // 
            // dtpTo
            // 
            this.dtpTo.CustomFormat = "dd-MMM-yyyy";
            this.dtpTo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(129, 56);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(104, 21);
            this.dtpTo.TabIndex = 577;
            // 
            // dtpFrom
            // 
            this.dtpFrom.CustomFormat = "dd-MMM-yyyy";
            this.dtpFrom.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(5, 56);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(105, 21);
            this.dtpFrom.TabIndex = 576;
            // 
            // pnlInvoice
            // 
            this.pnlInvoice.Controls.Add(this.btnFInvoice);
            this.pnlInvoice.Controls.Add(this.txtInvoice);
            this.pnlInvoice.Location = new System.Drawing.Point(14, 178);
            this.pnlInvoice.Name = "pnlInvoice";
            this.pnlInvoice.Size = new System.Drawing.Size(224, 117);
            this.pnlInvoice.TabIndex = 582;
            this.pnlInvoice.Visible = false;
            // 
            // btnFInvoice
            // 
            this.btnFInvoice.BackgroundImage = global::LOB.Properties.Resources.if_free_01_463023__1_;
            this.btnFInvoice.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFInvoice.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnFInvoice.Location = new System.Drawing.Point(192, 3);
            this.btnFInvoice.Name = "btnFInvoice";
            this.btnFInvoice.Size = new System.Drawing.Size(25, 22);
            this.btnFInvoice.TabIndex = 561;
            this.btnFInvoice.UseVisualStyleBackColor = true;
            this.btnFInvoice.Click += new System.EventHandler(this.btnFInvoice_Click);
            // 
            // txtInvoice
            // 
            this.txtInvoice.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInvoice.Location = new System.Drawing.Point(4, 5);
            this.txtInvoice.Name = "txtInvoice";
            this.txtInvoice.Size = new System.Drawing.Size(182, 21);
            this.txtInvoice.TabIndex = 560;
            this.txtInvoice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtInvoice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInvoice_KeyDown);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cboBranch);
            this.groupBox4.Location = new System.Drawing.Point(8, 37);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(235, 57);
            this.groupBox4.TabIndex = 581;
            this.groupBox4.TabStop = false;
            // 
            // cboBranch
            // 
            this.cboBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBranch.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBranch.FormattingEnabled = true;
            this.cboBranch.Location = new System.Drawing.Point(6, 15);
            this.cboBranch.Name = "cboBranch";
            this.cboBranch.Size = new System.Drawing.Size(223, 24);
            this.cboBranch.TabIndex = 0;
            this.cboBranch.Validating += new System.ComponentModel.CancelEventHandler(this.cboBranch_Validating);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.GrayText;
            this.label7.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(9, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(232, 25);
            this.label7.TabIndex = 580;
            this.label7.Text = "BRANCH";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnShow
            // 
            this.btnShow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(113)))), ((int)(((byte)(198)))));
            this.btnShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShow.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShow.ForeColor = System.Drawing.Color.White;
            this.btnShow.Location = new System.Drawing.Point(8, 657);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(237, 34);
            this.btnShow.TabIndex = 575;
            this.btnShow.Text = "SHOW";
            this.btnShow.UseVisualStyleBackColor = false;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pnlPartiCus);
            this.groupBox1.Controls.Add(this.pnlAllCustomer);
            this.groupBox1.Controls.Add(this.cboBasedOn);
            this.groupBox1.Location = new System.Drawing.Point(8, 135);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(235, 168);
            this.groupBox1.TabIndex = 573;
            this.groupBox1.TabStop = false;
            // 
            // pnlPartiCus
            // 
            this.pnlPartiCus.Controls.Add(this.btnFCus);
            this.pnlPartiCus.Controls.Add(this.txtCusCode);
            this.pnlPartiCus.Controls.Add(this.lblCustomer);
            this.pnlPartiCus.Location = new System.Drawing.Point(7, 45);
            this.pnlPartiCus.Name = "pnlPartiCus";
            this.pnlPartiCus.Size = new System.Drawing.Size(224, 117);
            this.pnlPartiCus.TabIndex = 575;
            this.pnlPartiCus.Visible = false;
            // 
            // btnFCus
            // 
            this.btnFCus.BackgroundImage = global::LOB.Properties.Resources.if_free_01_463023__1_;
            this.btnFCus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFCus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFCus.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnFCus.Location = new System.Drawing.Point(192, 3);
            this.btnFCus.Name = "btnFCus";
            this.btnFCus.Size = new System.Drawing.Size(25, 22);
            this.btnFCus.TabIndex = 561;
            this.btnFCus.UseVisualStyleBackColor = true;
            this.btnFCus.Click += new System.EventHandler(this.btnFCus_Click);
            // 
            // txtCusCode
            // 
            this.txtCusCode.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCusCode.Location = new System.Drawing.Point(4, 5);
            this.txtCusCode.Name = "txtCusCode";
            this.txtCusCode.Size = new System.Drawing.Size(182, 21);
            this.txtCusCode.TabIndex = 560;
            this.txtCusCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCusCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCusCode_KeyDown);
            this.txtCusCode.Validating += new System.ComponentModel.CancelEventHandler(this.txtCusCode_Validating);
            // 
            // lblCustomer
            // 
            this.lblCustomer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblCustomer.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomer.Location = new System.Drawing.Point(0, 37);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(224, 80);
            this.lblCustomer.TabIndex = 0;
            this.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlAllCustomer
            // 
            this.pnlAllCustomer.Controls.Add(this.label2);
            this.pnlAllCustomer.Location = new System.Drawing.Point(6, 45);
            this.pnlAllCustomer.Name = "pnlAllCustomer";
            this.pnlAllCustomer.Size = new System.Drawing.Size(224, 117);
            this.pnlAllCustomer.TabIndex = 574;
            this.pnlAllCustomer.Visible = false;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(224, 117);
            this.label2.TabIndex = 0;
            this.label2.Text = "ALL SUPPLIER";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboBasedOn
            // 
            this.cboBasedOn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBasedOn.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBasedOn.FormattingEnabled = true;
            this.cboBasedOn.Items.AddRange(new object[] {
            "ALL SUPPLIERS",
            "PARTICULAR SUPPLIER",
            "PARTICULAR GRN"});
            this.cboBasedOn.Location = new System.Drawing.Point(6, 15);
            this.cboBasedOn.Name = "cboBasedOn";
            this.cboBasedOn.Size = new System.Drawing.Size(223, 24);
            this.cboBasedOn.TabIndex = 0;
            this.cboBasedOn.SelectedIndexChanged += new System.EventHandler(this.cboBasedOn_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.GrayText;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(9, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 25);
            this.label1.TabIndex = 572;
            this.label1.Text = "BASED ON";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rptView
            // 
            this.rptView.ActiveViewIndex = -1;
            this.rptView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rptView.Cursor = System.Windows.Forms.Cursors.Default;
            this.rptView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptView.Location = new System.Drawing.Point(0, 35);
            this.rptView.Name = "rptView";
            this.rptView.Size = new System.Drawing.Size(758, 694);
            this.rptView.TabIndex = 574;
            this.rptView.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // frmRptPurchase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.rptView);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label14);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRptPurchase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PURCHASE/GRN REPORT...";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRptSales_Load);
            this.panel1.ResumeLayout(false);
            this.pnlOther.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.pnlInvoice.ResumeLayout(false);
            this.pnlInvoice.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.pnlPartiCus.ResumeLayout(false);
            this.pnlPartiCus.PerformLayout();
            this.pnlAllCustomer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panel1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer rptView;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboBasedOn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlPartiCus;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Panel pnlAllCustomer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnFCus;
        public System.Windows.Forms.TextBox txtCusCode;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboDateRange;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cboBranch;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel pnlInvoice;
        private System.Windows.Forms.Button btnFInvoice;
        public System.Windows.Forms.TextBox txtInvoice;
        private System.Windows.Forms.GroupBox pnlOther;
    }
}