namespace LOB
{
    partial class frmRptTotalStockFlow
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cboBranch = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cboReportType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboStockroom = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnShow = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pnlSupplier = new System.Windows.Forms.Panel();
            this.btnSFind = new System.Windows.Forms.Button();
            this.txtSupCode = new System.Windows.Forms.TextBox();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.pnlCategoy = new System.Windows.Forms.Panel();
            this.btnCFind = new System.Windows.Forms.Button();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.pnlPartiCus = new System.Windows.Forms.Panel();
            this.btnFCus = new System.Windows.Forms.Button();
            this.txtCusCode = new System.Windows.Forms.TextBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.pnlAllCustomer = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.cboBasedOn = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rptView = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cboDateRange = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.panel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pnlSupplier.SuspendLayout();
            this.pnlCategoy.SuspendLayout();
            this.pnlPartiCus.SuspendLayout();
            this.pnlAllCustomer.SuspendLayout();
            this.groupBox5.SuspendLayout();
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
            this.label14.Text = "TOTAL STOCK FLOW";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.groupBox5);
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.btnShow);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(758, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 694);
            this.panel1.TabIndex = 573;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cboBranch);
            this.groupBox4.Location = new System.Drawing.Point(6, 38);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(235, 57);
            this.groupBox4.TabIndex = 585;
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
            this.label7.Location = new System.Drawing.Point(7, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(232, 25);
            this.label7.TabIndex = 584;
            this.label7.Text = "BRANCH";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cboReportType);
            this.groupBox3.Location = new System.Drawing.Point(7, 441);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(235, 57);
            this.groupBox3.TabIndex = 579;
            this.groupBox3.TabStop = false;
            // 
            // cboReportType
            // 
            this.cboReportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboReportType.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboReportType.FormattingEnabled = true;
            this.cboReportType.Items.AddRange(new object[] {
            "STOCK AUDIT",
            "STOCK VALUE - Cost Price",
            "STOCK VALUE - Selling Price",
            "STOCK VALUE - WholeSale Price"});
            this.cboReportType.Location = new System.Drawing.Point(6, 15);
            this.cboReportType.Name = "cboReportType";
            this.cboReportType.Size = new System.Drawing.Size(223, 24);
            this.cboReportType.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.GrayText;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(8, 413);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(232, 25);
            this.label3.TabIndex = 578;
            this.label3.Text = "REPORT TYPE";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cboStockroom);
            this.groupBox2.Location = new System.Drawing.Point(8, 133);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(235, 57);
            this.groupBox2.TabIndex = 577;
            this.groupBox2.TabStop = false;
            // 
            // cboStockroom
            // 
            this.cboStockroom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStockroom.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboStockroom.FormattingEnabled = true;
            this.cboStockroom.Location = new System.Drawing.Point(6, 15);
            this.cboStockroom.Name = "cboStockroom";
            this.cboStockroom.Size = new System.Drawing.Size(223, 24);
            this.cboStockroom.TabIndex = 0;
            this.cboStockroom.Validating += new System.ComponentModel.CancelEventHandler(this.cboStockroom_Validating);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.GrayText;
            this.label5.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(9, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(232, 25);
            this.label5.TabIndex = 576;
            this.label5.Text = "STOCKROOM";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.groupBox1.Controls.Add(this.pnlSupplier);
            this.groupBox1.Controls.Add(this.pnlCategoy);
            this.groupBox1.Controls.Add(this.pnlPartiCus);
            this.groupBox1.Controls.Add(this.pnlAllCustomer);
            this.groupBox1.Controls.Add(this.cboBasedOn);
            this.groupBox1.Location = new System.Drawing.Point(8, 232);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(235, 168);
            this.groupBox1.TabIndex = 573;
            this.groupBox1.TabStop = false;
            // 
            // pnlSupplier
            // 
            this.pnlSupplier.Controls.Add(this.btnSFind);
            this.pnlSupplier.Controls.Add(this.txtSupCode);
            this.pnlSupplier.Controls.Add(this.lblSupplier);
            this.pnlSupplier.Location = new System.Drawing.Point(7, 45);
            this.pnlSupplier.Name = "pnlSupplier";
            this.pnlSupplier.Size = new System.Drawing.Size(224, 117);
            this.pnlSupplier.TabIndex = 577;
            // 
            // btnSFind
            // 
            this.btnSFind.BackgroundImage = global::LOB.Properties.Resources.if_free_01_463023__1_;
            this.btnSFind.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSFind.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnSFind.Location = new System.Drawing.Point(192, 3);
            this.btnSFind.Name = "btnSFind";
            this.btnSFind.Size = new System.Drawing.Size(25, 22);
            this.btnSFind.TabIndex = 561;
            this.btnSFind.UseVisualStyleBackColor = true;
            this.btnSFind.Click += new System.EventHandler(this.btnSFind_Click);
            // 
            // txtSupCode
            // 
            this.txtSupCode.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSupCode.Location = new System.Drawing.Point(4, 5);
            this.txtSupCode.Name = "txtSupCode";
            this.txtSupCode.Size = new System.Drawing.Size(182, 21);
            this.txtSupCode.TabIndex = 560;
            this.txtSupCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSupCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSupCode_KeyDown);
            this.txtSupCode.Validating += new System.ComponentModel.CancelEventHandler(this.txtSupCode_Validating);
            // 
            // lblSupplier
            // 
            this.lblSupplier.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblSupplier.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSupplier.Location = new System.Drawing.Point(0, 37);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(224, 80);
            this.lblSupplier.TabIndex = 0;
            this.lblSupplier.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlCategoy
            // 
            this.pnlCategoy.Controls.Add(this.btnCFind);
            this.pnlCategoy.Controls.Add(this.txtCategory);
            this.pnlCategoy.Controls.Add(this.lblCategory);
            this.pnlCategoy.Location = new System.Drawing.Point(7, 45);
            this.pnlCategoy.Name = "pnlCategoy";
            this.pnlCategoy.Size = new System.Drawing.Size(224, 117);
            this.pnlCategoy.TabIndex = 576;
            // 
            // btnCFind
            // 
            this.btnCFind.BackgroundImage = global::LOB.Properties.Resources.if_free_01_463023__1_;
            this.btnCFind.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCFind.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnCFind.Location = new System.Drawing.Point(192, 3);
            this.btnCFind.Name = "btnCFind";
            this.btnCFind.Size = new System.Drawing.Size(25, 22);
            this.btnCFind.TabIndex = 561;
            this.btnCFind.UseVisualStyleBackColor = true;
            this.btnCFind.Click += new System.EventHandler(this.btnCFind_Click);
            // 
            // txtCategory
            // 
            this.txtCategory.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCategory.Location = new System.Drawing.Point(4, 5);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(182, 21);
            this.txtCategory.TabIndex = 560;
            this.txtCategory.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCategory.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCategory_KeyDown);
            this.txtCategory.Validating += new System.ComponentModel.CancelEventHandler(this.txtCategory_Validating);
            // 
            // lblCategory
            // 
            this.lblCategory.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblCategory.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategory.Location = new System.Drawing.Point(0, 37);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(224, 80);
            this.lblCategory.TabIndex = 0;
            this.lblCategory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.label2.Text = "ALL PRODUCT";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboBasedOn
            // 
            this.cboBasedOn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBasedOn.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBasedOn.FormattingEnabled = true;
            this.cboBasedOn.Items.AddRange(new object[] {
            "ALL PRODUCT",
            "PARTICULAR PRODUCT",
            "CATEGORY WISE",
            "SUPPLIER WISE"});
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
            this.label1.Location = new System.Drawing.Point(9, 204);
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
            this.rptView.Load += new System.EventHandler(this.rptView_Load);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.GrayText;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(8, 536);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(232, 25);
            this.label4.TabIndex = 588;
            this.label4.Text = "DATE RANGE";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cboDateRange);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.dtpTo);
            this.groupBox5.Controls.Add(this.dtpFrom);
            this.groupBox5.Location = new System.Drawing.Point(7, 564);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(235, 85);
            this.groupBox5.TabIndex = 589;
            this.groupBox5.TabStop = false;
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
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(126, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 14);
            this.label6.TabIndex = 580;
            this.label6.Text = "TO";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(3, 39);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 14);
            this.label8.TabIndex = 578;
            this.label8.Text = "FROM";
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
            // frmRptTotalStockFlow
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
            this.Name = "frmRptTotalStockFlow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TOTAL STOCK FLOW...";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRptSales_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.pnlSupplier.ResumeLayout(false);
            this.pnlSupplier.PerformLayout();
            this.pnlCategoy.ResumeLayout(false);
            this.pnlCategoy.PerformLayout();
            this.pnlPartiCus.ResumeLayout(false);
            this.pnlPartiCus.PerformLayout();
            this.pnlAllCustomer.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
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
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Panel pnlCategoy;
        private System.Windows.Forms.Button btnCFind;
        public System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Panel pnlSupplier;
        private System.Windows.Forms.Button btnSFind;
        public System.Windows.Forms.TextBox txtSupCode;
        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cboStockroom;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cboReportType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cboBranch;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox cboDateRange;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.DateTimePicker dtpFrom;
    }
}