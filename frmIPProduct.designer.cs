namespace LOB
{
    partial class frmIPProduct
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
            this.lblSelling = new System.Windows.Forms.Label();
            this.lblWholeSale = new System.Windows.Forms.Label();
            this.lblCost = new System.Windows.Forms.Label();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtSelling = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtWholesale = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCost = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtMargin = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnFBinLoc = new System.Windows.Forms.Button();
            this.btnFMajorCat = new System.Windows.Forms.Button();
            this.btnFSupplier = new System.Windows.Forms.Button();
            this.btnIFind = new System.Windows.Forms.Button();
            this.btnBinLoc = new System.Windows.Forms.Button();
            this.lblBinLocation = new System.Windows.Forms.Label();
            this.txtBinLoc = new System.Windows.Forms.TextBox();
            this.txtBrandName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnMajorCat = new System.Windows.Forms.Button();
            this.btnSupplier = new System.Windows.Forms.Button();
            this.txtSerialNo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtModelNo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.txtSuppCode = new System.Windows.Forms.TextBox();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblHeader = new System.Windows.Forms.Label();
            this.btnScale = new System.Windows.Forms.Button();
            this.cboScale = new System.Windows.Forms.ComboBox();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSelling
            // 
            this.lblSelling.BackColor = System.Drawing.Color.Gainsboro;
            this.lblSelling.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelling.Location = new System.Drawing.Point(250, 59);
            this.lblSelling.Name = "lblSelling";
            this.lblSelling.Size = new System.Drawing.Size(100, 21);
            this.lblSelling.TabIndex = 154;
            this.lblSelling.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWholeSale
            // 
            this.lblWholeSale.BackColor = System.Drawing.Color.Gainsboro;
            this.lblWholeSale.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWholeSale.Location = new System.Drawing.Point(133, 59);
            this.lblWholeSale.Name = "lblWholeSale";
            this.lblWholeSale.Size = new System.Drawing.Size(100, 21);
            this.lblWholeSale.TabIndex = 153;
            this.lblWholeSale.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCost
            // 
            this.lblCost.BackColor = System.Drawing.Color.Gainsboro;
            this.lblCost.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCost.Location = new System.Drawing.Point(12, 59);
            this.lblCost.Name = "lblCost";
            this.lblCost.Size = new System.Drawing.Size(100, 21);
            this.lblCost.TabIndex = 118;
            this.lblCost.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDiscount
            // 
            this.txtDiscount.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiscount.Location = new System.Drawing.Point(370, 34);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(98, 22);
            this.txtDiscount.TabIndex = 3;
            this.txtDiscount.Text = "0.00";
            this.txtDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDiscount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDiscount_KeyDown);
            this.txtDiscount.Validating += new System.ComponentModel.CancelEventHandler(this.txtDiscount_Validating);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(374, 17);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(87, 14);
            this.label18.TabIndex = 151;
            this.label18.Text = "Fixed Discount";
            // 
            // txtSelling
            // 
            this.txtSelling.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSelling.Location = new System.Drawing.Point(252, 34);
            this.txtSelling.Name = "txtSelling";
            this.txtSelling.Size = new System.Drawing.Size(98, 22);
            this.txtSelling.TabIndex = 2;
            this.txtSelling.Text = "0.00";
            this.txtSelling.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSelling.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSelling_KeyDown);
            this.txtSelling.Validating += new System.ComponentModel.CancelEventHandler(this.txtSelling_Validating);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(261, 17);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(96, 14);
            this.label12.TabIndex = 97;
            this.label12.Text = "New Retail Price";
            // 
            // txtWholesale
            // 
            this.txtWholesale.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWholesale.Location = new System.Drawing.Point(134, 34);
            this.txtWholesale.Name = "txtWholesale";
            this.txtWholesale.Size = new System.Drawing.Size(98, 22);
            this.txtWholesale.TabIndex = 1;
            this.txtWholesale.Text = "0.00";
            this.txtWholesale.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtWholesale.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtWholesale_KeyDown);
            this.txtWholesale.Validating += new System.ComponentModel.CancelEventHandler(this.txtWholesale_Validating);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(133, 17);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(97, 14);
            this.label11.TabIndex = 95;
            this.label11.Text = "New  WholeSale";
            // 
            // txtCost
            // 
            this.txtCost.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCost.Location = new System.Drawing.Point(14, 34);
            this.txtCost.Name = "txtCost";
            this.txtCost.Size = new System.Drawing.Size(98, 22);
            this.txtCost.TabIndex = 0;
            this.txtCost.Text = "0.00";
            this.txtCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCost.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCost_KeyDown);
            this.txtCost.Validating += new System.ComponentModel.CancelEventHandler(this.txtCost_Validating);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(11, 17);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(86, 14);
            this.label13.TabIndex = 93;
            this.label13.Text = "New Cost Price";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Blue;
            this.label14.Location = new System.Drawing.Point(16, 521);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(204, 15);
            this.label14.TabIndex = 202;
            this.label14.Text = ">> Press DOWN Arrow KEY to Search";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(15, 453);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(187, 19);
            this.label24.TabIndex = 199;
            this.label24.Text = "03.  Profit Margin and Scale";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cboScale);
            this.groupBox3.Controls.Add(this.btnScale);
            this.groupBox3.Controls.Add(this.txtMargin);
            this.groupBox3.Controls.Add(this.label23);
            this.groupBox3.Location = new System.Drawing.Point(17, 475);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(480, 40);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // txtMargin
            // 
            this.txtMargin.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMargin.Location = new System.Drawing.Point(128, 12);
            this.txtMargin.Name = "txtMargin";
            this.txtMargin.Size = new System.Drawing.Size(57, 22);
            this.txtMargin.TabIndex = 0;
            this.txtMargin.Text = "0.00";
            this.txtMargin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMargin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMargin_KeyDown);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(5, 17);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(95, 14);
            this.label23.TabIndex = 93;
            this.label23.Text = "Profit Margin (%)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(15, 335);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(119, 19);
            this.label10.TabIndex = 198;
            this.label10.Text = "02.  Price Details";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(13, 44);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(161, 19);
            this.label17.TabIndex = 197;
            this.label17.Text = "01. Product Information";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnFBinLoc);
            this.groupBox1.Controls.Add(this.btnFMajorCat);
            this.groupBox1.Controls.Add(this.btnFSupplier);
            this.groupBox1.Controls.Add(this.btnIFind);
            this.groupBox1.Controls.Add(this.btnBinLoc);
            this.groupBox1.Controls.Add(this.lblBinLocation);
            this.groupBox1.Controls.Add(this.txtBinLoc);
            this.groupBox1.Controls.Add(this.txtBrandName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnMajorCat);
            this.groupBox1.Controls.Add(this.btnSupplier);
            this.groupBox1.Controls.Add(this.txtSerialNo);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtModelNo);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.lblCategory);
            this.groupBox1.Controls.Add(this.txtCategory);
            this.groupBox1.Controls.Add(this.lblSupplier);
            this.groupBox1.Controls.Add(this.txtSuppCode);
            this.groupBox1.Controls.Add(this.chkActive);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.txtCode);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(16, 62);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(482, 259);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnFBinLoc
            // 
            this.btnFBinLoc.BackgroundImage = global::LOB.Properties.Resources.if_free_01_463023__1_;
            this.btnFBinLoc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFBinLoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFBinLoc.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnFBinLoc.Location = new System.Drawing.Point(214, 226);
            this.btnFBinLoc.Name = "btnFBinLoc";
            this.btnFBinLoc.Size = new System.Drawing.Size(25, 22);
            this.btnFBinLoc.TabIndex = 198;
            this.btnFBinLoc.TabStop = false;
            this.btnFBinLoc.UseVisualStyleBackColor = true;
            this.btnFBinLoc.Click += new System.EventHandler(this.btnFBinLoc_Click);
            // 
            // btnFMajorCat
            // 
            this.btnFMajorCat.BackgroundImage = global::LOB.Properties.Resources.if_free_01_463023__1_;
            this.btnFMajorCat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFMajorCat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFMajorCat.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnFMajorCat.Location = new System.Drawing.Point(215, 110);
            this.btnFMajorCat.Name = "btnFMajorCat";
            this.btnFMajorCat.Size = new System.Drawing.Size(25, 22);
            this.btnFMajorCat.TabIndex = 197;
            this.btnFMajorCat.TabStop = false;
            this.btnFMajorCat.UseVisualStyleBackColor = true;
            this.btnFMajorCat.Click += new System.EventHandler(this.btnFMajorCat_Click);
            // 
            // btnFSupplier
            // 
            this.btnFSupplier.BackgroundImage = global::LOB.Properties.Resources.if_free_01_463023__1_;
            this.btnFSupplier.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFSupplier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFSupplier.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnFSupplier.Location = new System.Drawing.Point(215, 79);
            this.btnFSupplier.Name = "btnFSupplier";
            this.btnFSupplier.Size = new System.Drawing.Size(25, 22);
            this.btnFSupplier.TabIndex = 196;
            this.btnFSupplier.TabStop = false;
            this.btnFSupplier.UseVisualStyleBackColor = true;
            this.btnFSupplier.Click += new System.EventHandler(this.btnFSupplier_Click);
            // 
            // btnIFind
            // 
            this.btnIFind.BackgroundImage = global::LOB.Properties.Resources.if_free_01_463023__1_;
            this.btnIFind.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnIFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIFind.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnIFind.Location = new System.Drawing.Point(214, 16);
            this.btnIFind.Name = "btnIFind";
            this.btnIFind.Size = new System.Drawing.Size(25, 22);
            this.btnIFind.TabIndex = 195;
            this.btnIFind.TabStop = false;
            this.btnIFind.UseVisualStyleBackColor = true;
            this.btnIFind.Click += new System.EventHandler(this.btnIFind_Click);
            // 
            // btnBinLoc
            // 
            this.btnBinLoc.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnBinLoc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnBinLoc.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBinLoc.Location = new System.Drawing.Point(9, 223);
            this.btnBinLoc.Name = "btnBinLoc";
            this.btnBinLoc.Size = new System.Drawing.Size(109, 25);
            this.btnBinLoc.TabIndex = 194;
            this.btnBinLoc.TabStop = false;
            this.btnBinLoc.Text = "Bin Location";
            this.btnBinLoc.UseVisualStyleBackColor = true;
            this.btnBinLoc.Click += new System.EventHandler(this.btnBinLoc_Click);
            // 
            // lblBinLocation
            // 
            this.lblBinLocation.BackColor = System.Drawing.Color.Gainsboro;
            this.lblBinLocation.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBinLocation.Location = new System.Drawing.Point(246, 227);
            this.lblBinLocation.Name = "lblBinLocation";
            this.lblBinLocation.Size = new System.Drawing.Size(230, 21);
            this.lblBinLocation.TabIndex = 192;
            this.lblBinLocation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtBinLoc
            // 
            this.txtBinLoc.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBinLoc.Location = new System.Drawing.Point(127, 227);
            this.txtBinLoc.Name = "txtBinLoc";
            this.txtBinLoc.Size = new System.Drawing.Size(82, 21);
            this.txtBinLoc.TabIndex = 7;
            this.txtBinLoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBinLoc_KeyDown);
            this.txtBinLoc.Validating += new System.ComponentModel.CancelEventHandler(this.txtBinLoc_Validating);
            // 
            // txtBrandName
            // 
            this.txtBrandName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBrandName.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBrandName.Location = new System.Drawing.Point(127, 198);
            this.txtBrandName.Name = "txtBrandName";
            this.txtBrandName.Size = new System.Drawing.Size(349, 21);
            this.txtBrandName.TabIndex = 6;
            this.txtBrandName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBrandName_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(11, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 14);
            this.label4.TabIndex = 190;
            this.label4.Text = "Brand Name";
            // 
            // btnMajorCat
            // 
            this.btnMajorCat.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnMajorCat.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMajorCat.Location = new System.Drawing.Point(9, 107);
            this.btnMajorCat.Name = "btnMajorCat";
            this.btnMajorCat.Size = new System.Drawing.Size(109, 25);
            this.btnMajorCat.TabIndex = 188;
            this.btnMajorCat.TabStop = false;
            this.btnMajorCat.Text = "Major Category";
            this.btnMajorCat.UseVisualStyleBackColor = true;
            this.btnMajorCat.Click += new System.EventHandler(this.btnMajorCat_Click);
            // 
            // btnSupplier
            // 
            this.btnSupplier.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSupplier.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSupplier.Location = new System.Drawing.Point(9, 78);
            this.btnSupplier.Name = "btnSupplier";
            this.btnSupplier.Size = new System.Drawing.Size(109, 25);
            this.btnSupplier.TabIndex = 187;
            this.btnSupplier.TabStop = false;
            this.btnSupplier.Text = "Supplier";
            this.btnSupplier.UseVisualStyleBackColor = true;
            this.btnSupplier.Click += new System.EventHandler(this.btnSupplier_Click);
            // 
            // txtSerialNo
            // 
            this.txtSerialNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSerialNo.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSerialNo.Location = new System.Drawing.Point(127, 171);
            this.txtSerialNo.Name = "txtSerialNo";
            this.txtSerialNo.Size = new System.Drawing.Size(349, 21);
            this.txtSerialNo.TabIndex = 5;
            this.txtSerialNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSerialNo_KeyDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(11, 173);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 14);
            this.label9.TabIndex = 117;
            this.label9.Text = "Serial No";
            // 
            // txtModelNo
            // 
            this.txtModelNo.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtModelNo.Location = new System.Drawing.Point(127, 141);
            this.txtModelNo.Name = "txtModelNo";
            this.txtModelNo.Size = new System.Drawing.Size(349, 21);
            this.txtModelNo.TabIndex = 4;
            this.txtModelNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtModelNo_KeyDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(11, 143);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 14);
            this.label8.TabIndex = 115;
            this.label8.Text = "Model No";
            // 
            // lblCategory
            // 
            this.lblCategory.BackColor = System.Drawing.Color.Gainsboro;
            this.lblCategory.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategory.Location = new System.Drawing.Point(246, 111);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(230, 21);
            this.lblCategory.TabIndex = 113;
            this.lblCategory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCategory
            // 
            this.txtCategory.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCategory.Location = new System.Drawing.Point(127, 111);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(82, 21);
            this.txtCategory.TabIndex = 3;
            this.txtCategory.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCategory_KeyDown);
            this.txtCategory.Validating += new System.ComponentModel.CancelEventHandler(this.txtCategory_Validating);
            // 
            // lblSupplier
            // 
            this.lblSupplier.BackColor = System.Drawing.Color.Gainsboro;
            this.lblSupplier.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSupplier.Location = new System.Drawing.Point(246, 80);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(230, 21);
            this.lblSupplier.TabIndex = 109;
            this.lblSupplier.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSuppCode
            // 
            this.txtSuppCode.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSuppCode.Location = new System.Drawing.Point(127, 80);
            this.txtSuppCode.Name = "txtSuppCode";
            this.txtSuppCode.Size = new System.Drawing.Size(82, 21);
            this.txtSuppCode.TabIndex = 2;
            this.txtSuppCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSuppCode_KeyDown);
            this.txtSuppCode.Validating += new System.ComponentModel.CancelEventHandler(this.txtSuppCode_Validating);
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Checked = true;
            this.chkActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActive.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkActive.Location = new System.Drawing.Point(245, 19);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(58, 19);
            this.chkActive.TabIndex = 105;
            this.chkActive.TabStop = false;
            this.chkActive.Text = "Active";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // txtName
            // 
            this.txtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(128, 47);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(348, 22);
            this.txtName.TabIndex = 1;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            this.txtName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtName_KeyDown);
            // 
            // txtCode
            // 
            this.txtCode.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCode.Location = new System.Drawing.Point(128, 16);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(81, 22);
            this.txtCode.TabIndex = 0;
            this.txtCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCode_KeyDown);
            this.txtCode.Validating += new System.ComponentModel.CancelEventHandler(this.txtCode_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 14);
            this.label3.TabIndex = 71;
            this.label3.Text = "Item Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 14);
            this.label2.TabIndex = 68;
            this.label2.Text = "Item Code";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblDiscount);
            this.groupBox2.Controls.Add(this.lblSelling);
            this.groupBox2.Controls.Add(this.lblWholeSale);
            this.groupBox2.Controls.Add(this.lblCost);
            this.groupBox2.Controls.Add(this.txtDiscount);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.txtSelling);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtWholesale);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txtCost);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Location = new System.Drawing.Point(17, 357);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(480, 93);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // lblDiscount
            // 
            this.lblDiscount.BackColor = System.Drawing.Color.Gainsboro;
            this.lblDiscount.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscount.Location = new System.Drawing.Point(368, 59);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(100, 21);
            this.lblDiscount.TabIndex = 155;
            this.lblDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(113)))), ((int)(((byte)(198)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(261, 561);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(91, 34);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(113)))), ((int)(((byte)(198)))));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(358, 561);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(91, 34);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(113)))), ((int)(((byte)(198)))));
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.ForeColor = System.Drawing.Color.White;
            this.btnNew.Location = new System.Drawing.Point(67, 561);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(91, 34);
            this.btnNew.TabIndex = 5;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(113)))), ((int)(((byte)(198)))));
            this.btnDelete.Enabled = false;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(164, 561);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(91, 34);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.SystemColors.GrayText;
            this.label15.Font = new System.Drawing.Font("Calibri", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(508, 35);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(4, 525);
            this.label15.TabIndex = 195;
            this.label15.Tag = "*****";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.SystemColors.GrayText;
            this.label16.Font = new System.Drawing.Font("Calibri", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(-5, 553);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(517, 52);
            this.label16.TabIndex = 196;
            this.label16.Tag = "*****";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.GrayText;
            this.label1.Font = new System.Drawing.Font("Calibri", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(4, 525);
            this.label1.TabIndex = 194;
            this.label1.Tag = "*****";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHeader
            // 
            this.lblHeader.BackColor = System.Drawing.SystemColors.GrayText;
            this.lblHeader.Font = new System.Drawing.Font("Calibri", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(-1, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(513, 35);
            this.lblHeader.TabIndex = 193;
            this.lblHeader.Tag = "*****";
            this.lblHeader.Text = "Product  Information";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnScale
            // 
            this.btnScale.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnScale.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnScale.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScale.Location = new System.Drawing.Point(281, 11);
            this.btnScale.Name = "btnScale";
            this.btnScale.Size = new System.Drawing.Size(76, 25);
            this.btnScale.TabIndex = 195;
            this.btnScale.TabStop = false;
            this.btnScale.Text = "Scale";
            this.btnScale.UseVisualStyleBackColor = true;
            this.btnScale.Click += new System.EventHandler(this.btnScale_Click);
            // 
            // cboScale
            // 
            this.cboScale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboScale.FormattingEnabled = true;
            this.cboScale.Location = new System.Drawing.Point(363, 12);
            this.cboScale.Name = "cboScale";
            this.cboScale.Size = new System.Drawing.Size(105, 21);
            this.cboScale.TabIndex = 602;
            this.cboScale.Validating += new System.ComponentModel.CancelEventHandler(this.cboScale_Validating);
            // 
            // frmIPProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(512, 607);
            this.ControlBox = false;
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblHeader);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmIPProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product Information...";
            this.Load += new System.EventHandler(this.frmIPProduct_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSelling;
        private System.Windows.Forms.Label lblWholeSale;
        private System.Windows.Forms.Label lblCost;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtSelling;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtWholesale;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtCost;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtMargin;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnMajorCat;
        private System.Windows.Forms.Button btnSupplier;
        public System.Windows.Forms.TextBox txtSerialNo;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.TextBox txtModelNo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblCategory;
        public System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.Label lblSupplier;
        public System.Windows.Forms.TextBox txtSuppCode;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.TextBox txtName;
        public System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblHeader;
        public System.Windows.Forms.TextBox txtBrandName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnBinLoc;
        private System.Windows.Forms.Label lblBinLocation;
        public System.Windows.Forms.TextBox txtBinLoc;
        private System.Windows.Forms.Button btnIFind;
        private System.Windows.Forms.Button btnFBinLoc;
        private System.Windows.Forms.Button btnFMajorCat;
        private System.Windows.Forms.Button btnFSupplier;
        private System.Windows.Forms.Button btnScale;
        private System.Windows.Forms.ComboBox cboScale;
    }
}