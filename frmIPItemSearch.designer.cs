namespace LOB
{
    partial class frmIPItemSearch
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
            this.dgvItem = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblCode = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItem)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvItem
            // 
            this.dgvItem.AllowUserToAddRows = false;
            this.dgvItem.AllowUserToDeleteRows = false;
            this.dgvItem.BackgroundColor = System.Drawing.Color.White;
            this.dgvItem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvItem.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvItem.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvItem.Location = new System.Drawing.Point(12, 75);
            this.dgvItem.Name = "dgvItem";
            this.dgvItem.ReadOnly = true;
            this.dgvItem.RowHeadersVisible = false;
            this.dgvItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItem.Size = new System.Drawing.Size(814, 432);
            this.dgvItem.TabIndex = 20;
            this.dgvItem.SelectionChanged += new System.EventHandler(this.dgvItem_SelectionChanged);
            this.dgvItem.DoubleClick += new System.EventHandler(this.dgvItem_DoubleClick);
            this.dgvItem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvItem_KeyDown);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.RoyalBlue;
            this.label4.Location = new System.Drawing.Point(124, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(2, 25);
            this.label4.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.RoyalBlue;
            this.label3.Location = new System.Drawing.Point(354, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(2, 25);
            this.label3.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.RoyalBlue;
            this.label2.Location = new System.Drawing.Point(124, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(232, 2);
            this.label2.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.RoyalBlue;
            this.label1.Location = new System.Drawing.Point(124, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 2);
            this.label1.TabIndex = 21;
            // 
            // txtCode
            // 
            this.txtCode.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCode.Location = new System.Drawing.Point(126, 9);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(228, 27);
            this.txtCode.TabIndex = 22;
            this.txtCode.TextChanged += new System.EventHandler(this.txtCode_TextChanged);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.RoyalBlue;
            this.label5.Location = new System.Drawing.Point(125, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(2, 25);
            this.label5.TabIndex = 31;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.RoyalBlue;
            this.label6.Location = new System.Drawing.Point(355, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(2, 25);
            this.label6.TabIndex = 30;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.RoyalBlue;
            this.label7.Location = new System.Drawing.Point(125, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(232, 2);
            this.label7.TabIndex = 29;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.RoyalBlue;
            this.label8.Location = new System.Drawing.Point(125, 67);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(232, 2);
            this.label8.TabIndex = 27;
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(127, 41);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(228, 27);
            this.txtName.TabIndex = 28;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.RoyalBlue;
            this.label9.Location = new System.Drawing.Point(369, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(2, 25);
            this.label9.TabIndex = 37;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.RoyalBlue;
            this.label10.Location = new System.Drawing.Point(825, 12);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(2, 25);
            this.label10.TabIndex = 36;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.RoyalBlue;
            this.label11.Location = new System.Drawing.Point(369, 10);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(458, 2);
            this.label11.TabIndex = 35;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.RoyalBlue;
            this.label12.Location = new System.Drawing.Point(369, 36);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(458, 2);
            this.label12.TabIndex = 33;
            // 
            // lblCode
            // 
            this.lblCode.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCode.Location = new System.Drawing.Point(371, 10);
            this.lblCode.Name = "lblCode";
            this.lblCode.ReadOnly = true;
            this.lblCode.Size = new System.Drawing.Size(455, 27);
            this.lblCode.TabIndex = 34;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.RoyalBlue;
            this.label13.Location = new System.Drawing.Point(369, 43);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(2, 25);
            this.label13.TabIndex = 42;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.RoyalBlue;
            this.label14.Location = new System.Drawing.Point(825, 43);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(2, 25);
            this.label14.TabIndex = 41;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.RoyalBlue;
            this.label15.Location = new System.Drawing.Point(369, 41);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(458, 2);
            this.label15.TabIndex = 40;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.RoyalBlue;
            this.label16.Location = new System.Drawing.Point(369, 67);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(458, 2);
            this.label16.TabIndex = 38;
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(371, 41);
            this.lblName.Name = "lblName";
            this.lblName.ReadOnly = true;
            this.lblName.Size = new System.Drawing.Size(455, 27);
            this.lblName.TabIndex = 39;
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.Gainsboro;
            this.label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label17.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(12, 9);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(106, 27);
            this.label17.TabIndex = 43;
            this.label17.Text = "Code";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.Gainsboro;
            this.label18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label18.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(12, 41);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(106, 27);
            this.label18.TabIndex = 44;
            this.label18.Text = "Name";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmIPItemSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(831, 520);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.dgvItem);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmIPItemSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmIPSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX dgvItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox lblCode;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox lblName;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
    }
}