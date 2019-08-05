namespace LOB
{
    partial class frmIPCHQ
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblInformation = new DevComponents.DotNetBar.PanelEx();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.cmbBranch = new System.Windows.Forms.ComboBox();
            this.cmbBank = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpCHQDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtCHQNo = new System.Windows.Forms.TextBox();
            this.lblGossTotal = new DevComponents.DotNetBar.PanelEx();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnOk = new DevComponents.DotNetBar.ButtonX();
            this.dgvCHQ = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCash = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lblInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCHQ)).BeginInit();
            this.SuspendLayout();
            // 
            // lblInformation
            // 
            this.lblInformation.CanvasColor = System.Drawing.SystemColors.Control;
            this.lblInformation.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.lblInformation.Controls.Add(this.labelX2);
            this.lblInformation.DisabledBackColor = System.Drawing.Color.Empty;
            this.lblInformation.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblInformation.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInformation.Location = new System.Drawing.Point(0, 0);
            this.lblInformation.Name = "lblInformation";
            this.lblInformation.Size = new System.Drawing.Size(731, 33);
            this.lblInformation.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.lblInformation.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.lblInformation.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.lblInformation.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.lblInformation.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.lblInformation.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.lblInformation.Style.GradientAngle = 90;
            this.lblInformation.TabIndex = 45;
            this.lblInformation.Text = "CHEQUE PAYMENT";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelX2.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX2.Location = new System.Drawing.Point(0, 0);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(13, 33);
            this.labelX2.TabIndex = 2;
            this.labelX2.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // cmbBranch
            // 
            this.cmbBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBranch.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBranch.FormattingEnabled = true;
            this.cmbBranch.Location = new System.Drawing.Point(190, 91);
            this.cmbBranch.Name = "cmbBranch";
            this.cmbBranch.Size = new System.Drawing.Size(322, 33);
            this.cmbBranch.TabIndex = 1;
            this.cmbBranch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbBranch_KeyDown);
            this.cmbBranch.Validating += new System.ComponentModel.CancelEventHandler(this.cmbBranch_Validating);
            // 
            // cmbBank
            // 
            this.cmbBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBank.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBank.FormattingEnabled = true;
            this.cmbBank.Location = new System.Drawing.Point(190, 52);
            this.cmbBank.Name = "cmbBank";
            this.cmbBank.Size = new System.Drawing.Size(322, 33);
            this.cmbBank.TabIndex = 0;
            this.cmbBank.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbBank_KeyDown);
            this.cmbBank.Validating += new System.ComponentModel.CancelEventHandler(this.cmbBank_Validating);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Gainsboro;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(171, 33);
            this.label5.TabIndex = 77;
            this.label5.Text = "Branch";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.Gainsboro;
            this.label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label17.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(13, 52);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(171, 33);
            this.label17.TabIndex = 76;
            this.label17.Text = "Bank";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Gainsboro;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 33);
            this.label1.TabIndex = 79;
            this.label1.Text = "CHQ Date";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpCHQDate
            // 
            this.dtpCHQDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpCHQDate.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpCHQDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCHQDate.Location = new System.Drawing.Point(190, 130);
            this.dtpCHQDate.Name = "dtpCHQDate";
            this.dtpCHQDate.Size = new System.Drawing.Size(228, 33);
            this.dtpCHQDate.TabIndex = 2;
            this.dtpCHQDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpCHQDate_KeyDown);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Gainsboro;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 33);
            this.label2.TabIndex = 81;
            this.label2.Text = "CHQ No";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.RoyalBlue;
            this.label11.Location = new System.Drawing.Point(188, 171);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(2, 30);
            this.label11.TabIndex = 86;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.RoyalBlue;
            this.label12.Location = new System.Drawing.Point(418, 171);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(2, 30);
            this.label12.TabIndex = 85;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.RoyalBlue;
            this.label13.Location = new System.Drawing.Point(188, 169);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(232, 2);
            this.label13.TabIndex = 84;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.RoyalBlue;
            this.label14.Location = new System.Drawing.Point(188, 200);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(232, 2);
            this.label14.TabIndex = 83;
            // 
            // txtCHQNo
            // 
            this.txtCHQNo.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCHQNo.Location = new System.Drawing.Point(190, 169);
            this.txtCHQNo.Name = "txtCHQNo";
            this.txtCHQNo.Size = new System.Drawing.Size(228, 33);
            this.txtCHQNo.TabIndex = 3;
            this.txtCHQNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCHQNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCHQNo_KeyDown);
            // 
            // lblGossTotal
            // 
            this.lblGossTotal.CanvasColor = System.Drawing.SystemColors.Control;
            this.lblGossTotal.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.lblGossTotal.DisabledBackColor = System.Drawing.Color.Empty;
            this.lblGossTotal.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGossTotal.Location = new System.Drawing.Point(591, 409);
            this.lblGossTotal.Name = "lblGossTotal";
            this.lblGossTotal.Size = new System.Drawing.Size(128, 34);
            this.lblGossTotal.Style.Alignment = System.Drawing.StringAlignment.Far;
            this.lblGossTotal.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.lblGossTotal.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.lblGossTotal.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.lblGossTotal.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.lblGossTotal.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.lblGossTotal.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.lblGossTotal.Style.GradientAngle = 90;
            this.lblGossTotal.Style.MarginRight = 5;
            this.lblGossTotal.TabIndex = 94;
            this.lblGossTotal.Text = "0.00";
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.Location = new System.Drawing.Point(485, 409);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(100, 34);
            this.labelX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.labelX1.TabIndex = 93;
            this.labelX1.Text = "Total Amount";
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(358, 453);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(4);
            this.btnCancel.Size = new System.Drawing.Size(140, 53);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOk.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.Location = new System.Drawing.Point(212, 453);
            this.btnOk.Name = "btnOk";
            this.btnOk.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(4);
            this.btnOk.Size = new System.Drawing.Size(140, 53);
            this.btnOk.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "OK";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // dgvCHQ
            // 
            this.dgvCHQ.AllowUserToAddRows = false;
            this.dgvCHQ.AllowUserToDeleteRows = false;
            this.dgvCHQ.BackgroundColor = System.Drawing.Color.White;
            this.dgvCHQ.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCHQ.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCHQ.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column5,
            this.Column7,
            this.Column8,
            this.Column6,
            this.Column4});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCHQ.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCHQ.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvCHQ.Location = new System.Drawing.Point(12, 255);
            this.dgvCHQ.Name = "dgvCHQ";
            this.dgvCHQ.ReadOnly = true;
            this.dgvCHQ.RowHeadersVisible = false;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvCHQ.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCHQ.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCHQ.Size = new System.Drawing.Size(707, 148);
            this.dgvCHQ.TabIndex = 92;
            this.dgvCHQ.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCCard_CellClick);
            this.dgvCHQ.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvCCard_KeyDown);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "BankId";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Bank Name";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 160;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Branch ID";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Visible = false;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Branch Name";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 170;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "CHQ Date";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 130;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "CHQ No";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column6
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column6.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column6.HeaderText = "Amount";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "#";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column4.Text = null;
            this.Column4.Width = 40;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.RoyalBlue;
            this.label3.Location = new System.Drawing.Point(188, 210);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(2, 30);
            this.label3.TabIndex = 100;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.RoyalBlue;
            this.label4.Location = new System.Drawing.Point(418, 210);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(2, 30);
            this.label4.TabIndex = 99;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.RoyalBlue;
            this.label6.Location = new System.Drawing.Point(188, 208);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(232, 2);
            this.label6.TabIndex = 98;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.RoyalBlue;
            this.label7.Location = new System.Drawing.Point(188, 239);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(232, 2);
            this.label7.TabIndex = 97;
            // 
            // txtCash
            // 
            this.txtCash.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCash.Location = new System.Drawing.Point(190, 208);
            this.txtCash.Name = "txtCash";
            this.txtCash.Size = new System.Drawing.Size(228, 33);
            this.txtCash.TabIndex = 4;
            this.txtCash.Text = "0.00";
            this.txtCash.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCash.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCash_KeyDown);
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Gainsboro;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(13, 208);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(171, 33);
            this.label8.TabIndex = 96;
            this.label8.Text = "Amount";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmIPCHQ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(731, 512);
            this.ControlBox = false;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtCash);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblGossTotal);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.dgvCHQ);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtCHQNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpCHQDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbBranch);
            this.Controls.Add(this.cmbBank);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.lblInformation);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmIPCHQ";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmIPCHQ_Load);
            this.lblInformation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCHQ)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx lblInformation;
        private DevComponents.DotNetBar.LabelX labelX2;
        private System.Windows.Forms.ComboBox cmbBranch;
        private System.Windows.Forms.ComboBox cmbBank;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpCHQDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        public System.Windows.Forms.TextBox txtCHQNo;
        private DevComponents.DotNetBar.PanelEx lblGossTotal;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnOk;
        public DevComponents.DotNetBar.Controls.DataGridViewX dgvCHQ;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox txtCash;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn Column4;
    }
}