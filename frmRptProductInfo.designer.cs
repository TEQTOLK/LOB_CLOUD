namespace LOB
{
    partial class frmRptProductInfo
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
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pnlSupplier.SuspendLayout();
            this.pnlCategoy.SuspendLayout();
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
            this.label14.Text = "PRODUCT INFORMATION";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
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
            this.groupBox1.Location = new System.Drawing.Point(8, 37);
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
            this.label1.Location = new System.Drawing.Point(9, 9);
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
            // frmRptProductInfo
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
            this.Name = "frmRptProductInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PRODUCT INFORMATION...";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRptSales_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.pnlSupplier.ResumeLayout(false);
            this.pnlSupplier.PerformLayout();
            this.pnlCategoy.ResumeLayout(false);
            this.pnlCategoy.PerformLayout();
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
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Panel pnlCategoy;
        private System.Windows.Forms.Button btnCFind;
        public System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Panel pnlSupplier;
        private System.Windows.Forms.Button btnSFind;
        public System.Windows.Forms.TextBox txtSupCode;
        private System.Windows.Forms.Label lblSupplier;
    }
}