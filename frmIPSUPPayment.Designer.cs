namespace LOB
{
    partial class frmIPSUPPayment
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button1 = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.btnNew = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.btnFSupp = new System.Windows.Forms.Button();
            this.btnSupplier = new System.Windows.Forms.Button();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.txtSuppCode = new System.Windows.Forms.TextBox();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.dgvSelectedBill = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn();
            this.dgvOutstanding = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.lblSelectedAmount = new DevComponents.DotNetBar.LabelX();
            this.dgvBills = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.labelX11 = new DevComponents.DotNetBar.LabelX();
            this.lblSelectedAmt = new DevComponents.DotNetBar.PanelEx();
            this.labelX12 = new DevComponents.DotNetBar.LabelX();
            this.pnlPay = new System.Windows.Forms.Panel();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblPayable = new DevComponents.DotNetBar.PanelEx();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.btnCash = new System.Windows.Forms.Button();
            this.btnChq = new System.Windows.Forms.Button();
            this.btnCard = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectedBill)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOutstanding)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBills)).BeginInit();
            this.pnlPay.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(113)))), ((int)(((byte)(198)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(5, 455);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 34);
            this.button1.TabIndex = 555;
            this.button1.Text = "Enquiry";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(113)))), ((int)(((byte)(198)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(637, 455);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(91, 34);
            this.btnSave.TabIndex = 552;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(113)))), ((int)(((byte)(198)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(735, 455);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(91, 34);
            this.btnClose.TabIndex = 554;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.GrayText;
            this.label1.Font = new System.Drawing.Font("Calibri", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(5, 420);
            this.label1.TabIndex = 558;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.SystemColors.GrayText;
            this.label15.Font = new System.Drawing.Font("Calibri", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(825, 34);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(5, 420);
            this.label15.TabIndex = 557;
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(113)))), ((int)(((byte)(198)))));
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.btnNew.ForeColor = System.Drawing.Color.White;
            this.btnNew.Location = new System.Drawing.Point(540, 455);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(91, 34);
            this.btnNew.TabIndex = 553;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = false;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.SystemColors.GrayText;
            this.label14.Font = new System.Drawing.Font("Calibri", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(0, -1);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(830, 35);
            this.label14.TabIndex = 556;
            this.label14.Text = "SUPPLIER PAYMENT";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.SystemColors.GrayText;
            this.label16.Font = new System.Drawing.Font("Calibri", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(0, 446);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(830, 52);
            this.label16.TabIndex = 559;
            this.label16.Tag = "*****";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnFSupp
            // 
            this.btnFSupp.BackgroundImage = global::LOB.Properties.Resources.if_free_01_463023__1_;
            this.btnFSupp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFSupp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFSupp.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnFSupp.Location = new System.Drawing.Point(180, 49);
            this.btnFSupp.Name = "btnFSupp";
            this.btnFSupp.Size = new System.Drawing.Size(25, 22);
            this.btnFSupp.TabIndex = 563;
            this.btnFSupp.UseVisualStyleBackColor = true;
            this.btnFSupp.Click += new System.EventHandler(this.btnFSupp_Click);
            // 
            // btnSupplier
            // 
            this.btnSupplier.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSupplier.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSupplier.Location = new System.Drawing.Point(11, 47);
            this.btnSupplier.Name = "btnSupplier";
            this.btnSupplier.Size = new System.Drawing.Size(75, 25);
            this.btnSupplier.TabIndex = 562;
            this.btnSupplier.Text = "Supplier";
            this.btnSupplier.UseVisualStyleBackColor = true;
            this.btnSupplier.Click += new System.EventHandler(this.btnSupplier_Click);
            // 
            // lblSupplier
            // 
            this.lblSupplier.BackColor = System.Drawing.Color.Gainsboro;
            this.lblSupplier.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSupplier.Location = new System.Drawing.Point(211, 50);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(317, 21);
            this.lblSupplier.TabIndex = 561;
            this.lblSupplier.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSuppCode
            // 
            this.txtSuppCode.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSuppCode.Location = new System.Drawing.Point(92, 50);
            this.txtSuppCode.Name = "txtSuppCode";
            this.txtSuppCode.Size = new System.Drawing.Size(82, 21);
            this.txtSuppCode.TabIndex = 560;
            this.txtSuppCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSuppCode_KeyDown);
            this.txtSuppCode.Validating += new System.ComponentModel.CancelEventHandler(this.txtSuppCode_Validating);
            // 
            // labelX7
            // 
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX7.Location = new System.Drawing.Point(27, 349);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(320, 26);
            this.labelX7.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.labelX7.TabIndex = 569;
            this.labelX7.Text = "2. SELECTED BILLS INFORMATION";
            // 
            // dgvSelectedBill
            // 
            this.dgvSelectedBill.AllowUserToAddRows = false;
            this.dgvSelectedBill.AllowUserToDeleteRows = false;
            this.dgvSelectedBill.AllowUserToResizeColumns = false;
            this.dgvSelectedBill.AllowUserToResizeRows = false;
            this.dgvSelectedBill.BackgroundColor = System.Drawing.Color.White;
            this.dgvSelectedBill.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSelectedBill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSelectedBill.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column4,
            this.Column2,
            this.Column3,
            this.Column5});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSelectedBill.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgvSelectedBill.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvSelectedBill.Location = new System.Drawing.Point(440, 335);
            this.dgvSelectedBill.Name = "dgvSelectedBill";
            this.dgvSelectedBill.ReadOnly = true;
            this.dgvSelectedBill.RowHeadersVisible = false;
            this.dgvSelectedBill.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvSelectedBill.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSelectedBill.Size = new System.Drawing.Size(367, 103);
            this.dgvSelectedBill.TabIndex = 568;
            this.dgvSelectedBill.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSelectedBill_CellClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "BillID";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Date";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 120;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "BillNo";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N2";
            dataGridViewCellStyle9.NullValue = null;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle9;
            this.Column3.HeaderText = "Payable";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "#";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column5.Text = null;
            this.Column5.Width = 40;
            // 
            // dgvOutstanding
            // 
            this.dgvOutstanding.AllowUserToAddRows = false;
            this.dgvOutstanding.AllowUserToDeleteRows = false;
            this.dgvOutstanding.AllowUserToResizeColumns = false;
            this.dgvOutstanding.AllowUserToResizeRows = false;
            this.dgvOutstanding.BackgroundColor = System.Drawing.Color.White;
            this.dgvOutstanding.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvOutstanding.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOutstanding.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgvOutstanding.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvOutstanding.Location = new System.Drawing.Point(22, 125);
            this.dgvOutstanding.Name = "dgvOutstanding";
            this.dgvOutstanding.ReadOnly = true;
            this.dgvOutstanding.RowHeadersVisible = false;
            this.dgvOutstanding.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvOutstanding.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOutstanding.Size = new System.Drawing.Size(785, 187);
            this.dgvOutstanding.TabIndex = 567;
            this.dgvOutstanding.DoubleClick += new System.EventHandler(this.dgvOutstanding_DoubleClick);
            // 
            // labelX6
            // 
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX6.Location = new System.Drawing.Point(27, 93);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(320, 26);
            this.labelX6.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.labelX6.TabIndex = 566;
            this.labelX6.Text = "1. OUTSTANDING BILLS INFORMATION";
            // 
            // lblSelectedAmount
            // 
            // 
            // 
            // 
            this.lblSelectedAmount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblSelectedAmount.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedAmount.Location = new System.Drawing.Point(58, 381);
            this.lblSelectedAmount.Name = "lblSelectedAmount";
            this.lblSelectedAmount.Size = new System.Drawing.Size(173, 53);
            this.lblSelectedAmount.TabIndex = 570;
            this.lblSelectedAmount.Text = "0.00";
            this.lblSelectedAmount.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // dgvBills
            // 
            this.dgvBills.AllowUserToAddRows = false;
            this.dgvBills.AllowUserToDeleteRows = false;
            this.dgvBills.AllowUserToResizeColumns = false;
            this.dgvBills.AllowUserToResizeRows = false;
            this.dgvBills.BackgroundColor = System.Drawing.Color.White;
            this.dgvBills.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvBills.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBills.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgvBills.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvBills.Location = new System.Drawing.Point(14, 49);
            this.dgvBills.Name = "dgvBills";
            this.dgvBills.ReadOnly = true;
            this.dgvBills.RowHeadersVisible = false;
            this.dgvBills.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvBills.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBills.Size = new System.Drawing.Size(785, 233);
            this.dgvBills.TabIndex = 90;
            // 
            // labelX11
            // 
            // 
            // 
            // 
            this.labelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX11.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX11.Location = new System.Drawing.Point(494, 298);
            this.labelX11.Name = "labelX11";
            this.labelX11.Size = new System.Drawing.Size(171, 34);
            this.labelX11.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.labelX11.TabIndex = 111;
            this.labelX11.Text = "Selected Bill(s) Amount";
            // 
            // lblSelectedAmt
            // 
            this.lblSelectedAmt.CanvasColor = System.Drawing.SystemColors.Control;
            this.lblSelectedAmt.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.lblSelectedAmt.DisabledBackColor = System.Drawing.Color.Empty;
            this.lblSelectedAmt.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedAmt.Location = new System.Drawing.Point(671, 298);
            this.lblSelectedAmt.Name = "lblSelectedAmt";
            this.lblSelectedAmt.Size = new System.Drawing.Size(128, 34);
            this.lblSelectedAmt.Style.Alignment = System.Drawing.StringAlignment.Far;
            this.lblSelectedAmt.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.lblSelectedAmt.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.lblSelectedAmt.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.lblSelectedAmt.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.lblSelectedAmt.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.lblSelectedAmt.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.lblSelectedAmt.Style.GradientAngle = 90;
            this.lblSelectedAmt.Style.MarginRight = 5;
            this.lblSelectedAmt.TabIndex = 112;
            this.lblSelectedAmt.Text = "0.00";
            // 
            // labelX12
            // 
            // 
            // 
            // 
            this.labelX12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX12.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX12.Location = new System.Drawing.Point(12, 15);
            this.labelX12.Name = "labelX12";
            this.labelX12.Size = new System.Drawing.Size(320, 26);
            this.labelX12.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.labelX12.TabIndex = 113;
            this.labelX12.Text = "3. PAYMENT METHODS (CASH/CHQ/CARD)";
            // 
            // pnlPay
            // 
            this.pnlPay.Controls.Add(this.labelX12);
            this.pnlPay.Controls.Add(this.lblSelectedAmt);
            this.pnlPay.Controls.Add(this.labelX11);
            this.pnlPay.Controls.Add(this.dgvBills);
            this.pnlPay.Location = new System.Drawing.Point(11, 93);
            this.pnlPay.Name = "pnlPay";
            this.pnlPay.Size = new System.Drawing.Size(810, 343);
            this.pnlPay.TabIndex = 571;
            this.pnlPay.Visible = false;
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(113)))), ((int)(((byte)(198)))));
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.btnNext.ForeColor = System.Drawing.Color.White;
            this.btnNext.Location = new System.Drawing.Point(637, 455);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(91, 34);
            this.btnNext.TabIndex = 572;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(113)))), ((int)(((byte)(198)))));
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(346, 455);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(91, 34);
            this.btnBack.TabIndex = 573;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Visible = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lblPayable
            // 
            this.lblPayable.CanvasColor = System.Drawing.SystemColors.Control;
            this.lblPayable.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.lblPayable.DisabledBackColor = System.Drawing.Color.Empty;
            this.lblPayable.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPayable.Location = new System.Drawing.Point(691, 43);
            this.lblPayable.Name = "lblPayable";
            this.lblPayable.Size = new System.Drawing.Size(128, 34);
            this.lblPayable.Style.Alignment = System.Drawing.StringAlignment.Far;
            this.lblPayable.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.lblPayable.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.lblPayable.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.lblPayable.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.lblPayable.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.lblPayable.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.lblPayable.Style.GradientAngle = 90;
            this.lblPayable.Style.MarginRight = 5;
            this.lblPayable.TabIndex = 578;
            this.lblPayable.Text = "0.00";
            // 
            // labelX8
            // 
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX8.Location = new System.Drawing.Point(585, 44);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(100, 34);
            this.labelX8.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.labelX8.TabIndex = 577;
            this.labelX8.Text = "Outstanding";
            // 
            // btnCash
            // 
            this.btnCash.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(113)))), ((int)(((byte)(198)))));
            this.btnCash.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCash.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.btnCash.ForeColor = System.Drawing.Color.White;
            this.btnCash.Location = new System.Drawing.Point(638, 455);
            this.btnCash.Name = "btnCash";
            this.btnCash.Size = new System.Drawing.Size(91, 34);
            this.btnCash.TabIndex = 579;
            this.btnCash.Text = "Cash";
            this.btnCash.UseVisualStyleBackColor = false;
            this.btnCash.Visible = false;
            this.btnCash.Click += new System.EventHandler(this.btnCash_Click);
            // 
            // btnChq
            // 
            this.btnChq.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(113)))), ((int)(((byte)(198)))));
            this.btnChq.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChq.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.btnChq.ForeColor = System.Drawing.Color.White;
            this.btnChq.Location = new System.Drawing.Point(540, 455);
            this.btnChq.Name = "btnChq";
            this.btnChq.Size = new System.Drawing.Size(91, 34);
            this.btnChq.TabIndex = 580;
            this.btnChq.Text = "Cheque";
            this.btnChq.UseVisualStyleBackColor = false;
            this.btnChq.Visible = false;
            this.btnChq.Click += new System.EventHandler(this.btnChq_Click);
            // 
            // btnCard
            // 
            this.btnCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(113)))), ((int)(((byte)(198)))));
            this.btnCard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCard.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.btnCard.ForeColor = System.Drawing.Color.White;
            this.btnCard.Location = new System.Drawing.Point(443, 455);
            this.btnCard.Name = "btnCard";
            this.btnCard.Size = new System.Drawing.Size(91, 34);
            this.btnCard.TabIndex = 581;
            this.btnCard.Text = "Credit Card";
            this.btnCard.UseVisualStyleBackColor = false;
            this.btnCard.Visible = false;
            this.btnCard.Click += new System.EventHandler(this.btnCard_Click);
            // 
            // frmIPSUPPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(830, 496);
            this.Controls.Add(this.btnCard);
            this.Controls.Add(this.btnCash);
            this.Controls.Add(this.btnChq);
            this.Controls.Add(this.lblPayable);
            this.Controls.Add(this.labelX8);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.pnlPay);
            this.Controls.Add(this.labelX7);
            this.Controls.Add(this.dgvSelectedBill);
            this.Controls.Add(this.dgvOutstanding);
            this.Controls.Add(this.labelX6);
            this.Controls.Add(this.lblSelectedAmount);
            this.Controls.Add(this.btnFSupp);
            this.Controls.Add(this.btnSupplier);
            this.Controls.Add(this.lblSupplier);
            this.Controls.Add(this.txtSuppCode);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label16);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmIPSUPPayment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SUPPLIER PAYMENT...";
            this.Load += new System.EventHandler(this.frmIPSUPPayment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectedBill)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOutstanding)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBills)).EndInit();
            this.pnlPay.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnFSupp;
        private System.Windows.Forms.Button btnSupplier;
        private System.Windows.Forms.Label lblSupplier;
        public System.Windows.Forms.TextBox txtSuppCode;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvSelectedBill;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn Column5;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvOutstanding;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.LabelX lblSelectedAmount;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvBills;
        private DevComponents.DotNetBar.LabelX labelX11;
        private DevComponents.DotNetBar.PanelEx lblSelectedAmt;
        private DevComponents.DotNetBar.LabelX labelX12;
        private System.Windows.Forms.Panel pnlPay;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnBack;
        private DevComponents.DotNetBar.PanelEx lblPayable;
        private DevComponents.DotNetBar.LabelX labelX8;
        private System.Windows.Forms.Button btnCash;
        private System.Windows.Forms.Button btnChq;
        private System.Windows.Forms.Button btnCard;
    }
}