namespace LOB
{
    partial class frmOutstandingPOP
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.dgvBills = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvSale = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvPaidBills = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvOutstanding = new DevComponents.DotNetBar.Controls.DataGridViewX();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBills)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaidBills)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOutstanding)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCustomer
            // 
            this.lblCustomer.BackColor = System.Drawing.SystemColors.GrayText;
            this.lblCustomer.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCustomer.Font = new System.Drawing.Font("Calibri", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomer.ForeColor = System.Drawing.Color.White;
            this.lblCustomer.Location = new System.Drawing.Point(0, 0);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(1008, 35);
            this.lblCustomer.TabIndex = 573;
            this.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBills.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBills.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvBills.Location = new System.Drawing.Point(12, 82);
            this.dgvBills.Name = "dgvBills";
            this.dgvBills.ReadOnly = true;
            this.dgvBills.RowHeadersVisible = false;
            this.dgvBills.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvBills.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBills.Size = new System.Drawing.Size(499, 184);
            this.dgvBills.TabIndex = 575;
            this.dgvBills.SelectionChanged += new System.EventHandler(this.dgvBills_SelectionChanged);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.GrayText;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(499, 25);
            this.label1.TabIndex = 576;
            this.label1.Text = "OUTSTANDING BILLS";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(113)))), ((int)(((byte)(198)))));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(905, 622);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(91, 34);
            this.btnClose.TabIndex = 577;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.GrayText;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(529, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(471, 25);
            this.label2.TabIndex = 579;
            this.label2.Text = "SALE INFORMATION";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvSale
            // 
            this.dgvSale.AllowUserToAddRows = false;
            this.dgvSale.AllowUserToDeleteRows = false;
            this.dgvSale.AllowUserToResizeColumns = false;
            this.dgvSale.AllowUserToResizeRows = false;
            this.dgvSale.BackgroundColor = System.Drawing.Color.White;
            this.dgvSale.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSale.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSale.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSale.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvSale.Location = new System.Drawing.Point(529, 82);
            this.dgvSale.Name = "dgvSale";
            this.dgvSale.ReadOnly = true;
            this.dgvSale.RowHeadersVisible = false;
            this.dgvSale.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvSale.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSale.Size = new System.Drawing.Size(471, 184);
            this.dgvSale.TabIndex = 578;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.GrayText;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(16, 293);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(402, 25);
            this.label3.TabIndex = 581;
            this.label3.Text = "PAID BILLS INFO";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvPaidBills
            // 
            this.dgvPaidBills.AllowUserToAddRows = false;
            this.dgvPaidBills.AllowUserToDeleteRows = false;
            this.dgvPaidBills.AllowUserToResizeColumns = false;
            this.dgvPaidBills.AllowUserToResizeRows = false;
            this.dgvPaidBills.BackgroundColor = System.Drawing.Color.White;
            this.dgvPaidBills.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPaidBills.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPaidBills.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPaidBills.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvPaidBills.Location = new System.Drawing.Point(16, 329);
            this.dgvPaidBills.Name = "dgvPaidBills";
            this.dgvPaidBills.ReadOnly = true;
            this.dgvPaidBills.RowHeadersVisible = false;
            this.dgvPaidBills.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvPaidBills.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPaidBills.Size = new System.Drawing.Size(402, 255);
            this.dgvPaidBills.TabIndex = 580;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.GrayText;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(434, 293);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(515, 25);
            this.label4.TabIndex = 583;
            this.label4.Text = "PAYABLE BILLS INFO";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOutstanding.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvOutstanding.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvOutstanding.Location = new System.Drawing.Point(434, 329);
            this.dgvOutstanding.Name = "dgvOutstanding";
            this.dgvOutstanding.ReadOnly = true;
            this.dgvOutstanding.RowHeadersVisible = false;
            this.dgvOutstanding.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvOutstanding.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOutstanding.Size = new System.Drawing.Size(515, 255);
            this.dgvOutstanding.TabIndex = 582;
            // 
            // frmOutstandingPOP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1008, 658);
            this.ControlBox = false;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvOutstanding);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvPaidBills);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvSale);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvBills);
            this.Controls.Add(this.lblCustomer);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmOutstandingPOP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OUTSTANDING INFO";
            this.Load += new System.EventHandler(this.frmOutstandingPOP_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBills)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaidBills)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOutstanding)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label lblCustomer;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvBills;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label2;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvSale;
        private System.Windows.Forms.Label label3;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvPaidBills;
        private System.Windows.Forms.Label label4;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvOutstanding;
    }
}