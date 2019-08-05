namespace LOB
{
    partial class frmIPSetCustomer
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnFSupp = new System.Windows.Forms.Button();
            this.btnSupplier = new System.Windows.Forms.Button();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.txtSuppCode = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.SystemColors.GrayText;
            this.label14.Font = new System.Drawing.Font("Calibri", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(0, -3);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(553, 35);
            this.label14.TabIndex = 543;
            this.label14.Text = "SET DEFAULT CUSTOMER";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.GrayText;
            this.label1.Font = new System.Drawing.Font("Calibri", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, -85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(5, 420);
            this.label1.TabIndex = 551;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.GrayText;
            this.label2.Font = new System.Drawing.Font("Calibri", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(545, -131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(5, 420);
            this.label2.TabIndex = 552;
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnFSupp
            // 
            this.btnFSupp.BackgroundImage = global::LOB.Properties.Resources.if_free_01_463023__1_;
            this.btnFSupp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFSupp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFSupp.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnFSupp.Location = new System.Drawing.Point(188, 55);
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
            this.btnSupplier.Location = new System.Drawing.Point(19, 53);
            this.btnSupplier.Name = "btnSupplier";
            this.btnSupplier.Size = new System.Drawing.Size(75, 25);
            this.btnSupplier.TabIndex = 562;
            this.btnSupplier.Text = "Customer";
            this.btnSupplier.UseVisualStyleBackColor = true;
            this.btnSupplier.Click += new System.EventHandler(this.btnSupplier_Click);
            // 
            // lblSupplier
            // 
            this.lblSupplier.BackColor = System.Drawing.Color.Gainsboro;
            this.lblSupplier.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSupplier.Location = new System.Drawing.Point(219, 56);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(319, 21);
            this.lblSupplier.TabIndex = 561;
            this.lblSupplier.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSuppCode
            // 
            this.txtSuppCode.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSuppCode.Location = new System.Drawing.Point(100, 56);
            this.txtSuppCode.Name = "txtSuppCode";
            this.txtSuppCode.Size = new System.Drawing.Size(82, 21);
            this.txtSuppCode.TabIndex = 560;
            this.txtSuppCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSuppCode_KeyDown);
            this.txtSuppCode.Validating += new System.ComponentModel.CancelEventHandler(this.txtSuppCode_Validating);
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.SystemColors.GrayText;
            this.label16.Font = new System.Drawing.Font("Calibri", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(-125, 109);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(830, 52);
            this.label16.TabIndex = 564;
            this.label16.Tag = "*****";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(113)))), ((int)(((byte)(198)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(355, 119);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(91, 34);
            this.btnSave.TabIndex = 565;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(113)))), ((int)(((byte)(198)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(453, 119);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(91, 34);
            this.btnClose.TabIndex = 566;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmIPSetCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(550, 156);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.btnFSupp);
            this.Controls.Add(this.btnSupplier);
            this.Controls.Add(this.lblSupplier);
            this.Controls.Add(this.txtSuppCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label14);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmIPSetCustomer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SET DEFAULT CUSTOMER...";
            this.Load += new System.EventHandler(this.frmIPSetCustomer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnFSupp;
        private System.Windows.Forms.Button btnSupplier;
        private System.Windows.Forms.Label lblSupplier;
        public System.Windows.Forms.TextBox txtSuppCode;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
    }
}