namespace LOB
{
    partial class frmRptSUPList
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
            this.btnFCus = new System.Windows.Forms.Button();
            this.rptView = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.txtCusCode = new System.Windows.Forms.TextBox();
            this.pnlPartiCus = new System.Windows.Forms.Panel();
            this.pnlAllCustomer = new System.Windows.Forms.Panel();
            this.cboBasedOn = new System.Windows.Forms.ComboBox();
            this.btnShow = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlArea = new System.Windows.Forms.Panel();
            this.btnAFind = new System.Windows.Forms.Button();
            this.txtAreaCode = new System.Windows.Forms.TextBox();
            this.lblAreaName = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.pnlPartiCus.SuspendLayout();
            this.pnlAllCustomer.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlArea.SuspendLayout();
            this.SuspendLayout();
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
            // rptView
            // 
            this.rptView.ActiveViewIndex = -1;
            this.rptView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rptView.Cursor = System.Windows.Forms.Cursors.Default;
            this.rptView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptView.Location = new System.Drawing.Point(0, 35);
            this.rptView.Name = "rptView";
            this.rptView.Size = new System.Drawing.Size(758, 694);
            this.rptView.TabIndex = 577;
            this.rptView.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
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
            // pnlPartiCus
            // 
            this.pnlPartiCus.Controls.Add(this.btnFCus);
            this.pnlPartiCus.Controls.Add(this.txtCusCode);
            this.pnlPartiCus.Controls.Add(this.lblCustomer);
            this.pnlPartiCus.Location = new System.Drawing.Point(5, 42);
            this.pnlPartiCus.Name = "pnlPartiCus";
            this.pnlPartiCus.Size = new System.Drawing.Size(224, 117);
            this.pnlPartiCus.TabIndex = 575;
            this.pnlPartiCus.Visible = false;
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
            // cboBasedOn
            // 
            this.cboBasedOn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBasedOn.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBasedOn.FormattingEnabled = true;
            this.cboBasedOn.Items.AddRange(new object[] {
            "ALL SUPPLIER",
            "PARTICULAR SUPPLIER",
            "AREA WISE"});
            this.cboBasedOn.Location = new System.Drawing.Point(6, 15);
            this.cboBasedOn.Name = "cboBasedOn";
            this.cboBasedOn.Size = new System.Drawing.Size(223, 24);
            this.cboBasedOn.TabIndex = 0;
            this.cboBasedOn.SelectedIndexChanged += new System.EventHandler(this.cboBasedOn_SelectedIndexChanged);
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
            this.groupBox1.Location = new System.Drawing.Point(8, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(235, 168);
            this.groupBox1.TabIndex = 573;
            this.groupBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pnlArea);
            this.panel1.Controls.Add(this.btnShow);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(758, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 694);
            this.panel1.TabIndex = 576;
            // 
            // pnlArea
            // 
            this.pnlArea.Controls.Add(this.btnAFind);
            this.pnlArea.Controls.Add(this.txtAreaCode);
            this.pnlArea.Controls.Add(this.lblAreaName);
            this.pnlArea.Location = new System.Drawing.Point(13, 77);
            this.pnlArea.Name = "pnlArea";
            this.pnlArea.Size = new System.Drawing.Size(224, 117);
            this.pnlArea.TabIndex = 576;
            // 
            // btnAFind
            // 
            this.btnAFind.BackgroundImage = global::LOB.Properties.Resources.if_free_01_463023__1_;
            this.btnAFind.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAFind.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnAFind.Location = new System.Drawing.Point(192, 3);
            this.btnAFind.Name = "btnAFind";
            this.btnAFind.Size = new System.Drawing.Size(25, 22);
            this.btnAFind.TabIndex = 561;
            this.btnAFind.UseVisualStyleBackColor = true;
            this.btnAFind.Click += new System.EventHandler(this.btnAFind_Click);
            // 
            // txtAreaCode
            // 
            this.txtAreaCode.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAreaCode.Location = new System.Drawing.Point(4, 5);
            this.txtAreaCode.Name = "txtAreaCode";
            this.txtAreaCode.Size = new System.Drawing.Size(182, 21);
            this.txtAreaCode.TabIndex = 560;
            this.txtAreaCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAreaCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAreaCode_KeyDown);
            this.txtAreaCode.Validating += new System.ComponentModel.CancelEventHandler(this.txtAreaCode_Validating);
            // 
            // lblAreaName
            // 
            this.lblAreaName.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblAreaName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAreaName.Location = new System.Drawing.Point(0, 37);
            this.lblAreaName.Name = "lblAreaName";
            this.lblAreaName.Size = new System.Drawing.Size(224, 80);
            this.lblAreaName.TabIndex = 0;
            this.lblAreaName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.label14.TabIndex = 575;
            this.label14.Text = "SUPPLIER LIST";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmRptSUPList
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
            this.Name = "frmRptSUPList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SUPPLIER LIST...";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRptCUSList_Load);
            this.pnlPartiCus.ResumeLayout(false);
            this.pnlPartiCus.PerformLayout();
            this.pnlAllCustomer.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.pnlArea.ResumeLayout(false);
            this.pnlArea.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFCus;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer rptView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCustomer;
        public System.Windows.Forms.TextBox txtCusCode;
        private System.Windows.Forms.Panel pnlPartiCus;
        private System.Windows.Forms.Panel pnlAllCustomer;
        private System.Windows.Forms.ComboBox cboBasedOn;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel pnlArea;
        private System.Windows.Forms.Button btnAFind;
        public System.Windows.Forms.TextBox txtAreaCode;
        private System.Windows.Forms.Label lblAreaName;
    }
}