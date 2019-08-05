namespace LOB
{
    partial class frmRptMinusStk
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboStockroom = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnShow = new System.Windows.Forms.Button();
            this.rptView = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.label14.Text = "MINUS STOCK REPORT";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.btnShow);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(758, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 694);
            this.panel1.TabIndex = 573;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cboStockroom);
            this.groupBox2.Location = new System.Drawing.Point(8, 38);
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
            this.label5.Location = new System.Drawing.Point(9, 10);
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
            // frmRptMinusStk
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
            this.Name = "frmRptMinusStk";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MINIUS STOCK REPORT";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRptSales_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panel1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer rptView;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cboStockroom;
        private System.Windows.Forms.Label label5;
    }
}