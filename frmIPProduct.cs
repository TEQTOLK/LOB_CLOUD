using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LOB
{
    public partial class frmIPProduct : Form
    {
        private Boolean gEditFlag = false;
        private int gCustID = 0;
        private int gSupplierID = 0;
        private int gMajorCatID = 0;
        private int gBinID = 0;
        private int gScaleID = 0;

        DataSet dSet = new DataSet();
        frmConfirmMessage fConfirm = new frmConfirmMessage();
        StringBuilder gSB = new StringBuilder();
        GlobalData GlbData = new GlobalData();
        DataTable dataTable = new DataTable();
        MySqlDataAdapter sqlAdapter = new MySqlDataAdapter();
        MasterFiles masterFiles = new MasterFiles();
        frmIPSearchDealer f = new frmIPSearchDealer();
        frmIPCommon fCommon = new frmIPCommon();
        frmIPSearchCommon f1 = new frmIPSearchCommon();

        public frmIPProduct()
        {
            InitializeComponent();
        }

        private void frmIPProduct_Load(object sender, EventArgs e)
        {
            FillScale();
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            frmIPSupplier f = new frmIPSupplier();
            f.ShowDialog();
        }

        private void btnMajorCat_Click(object sender, EventArgs e)
        {
            fCommon.gTableName = "tblMajorCategory";
            fCommon.gHeaderName = "Major Category".ToUpper();
            fCommon.ShowDialog();
        }

        private void btnBinLoc_Click(object sender, EventArgs e)
        {
            fCommon.gTableName = "tblBinLocation";
            fCommon.gHeaderName = "Bin Location".ToUpper();
            fCommon.ShowDialog();
        }

        private void btnFSupplier_Click(object sender, EventArgs e)
        {
            f.TABLE_NAME = "tblSupplier";
            f.ShowDialog();
            if (f.gOkCancel == true)
            {
                txtSuppCode.Text = f.CODE;
                //gSupplierID = f.CUSTID;
                //lblSupplier.Text = f.NAME;
                txtSuppCode.Focus();
            }
        }

        private void txtSuppCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                btnFSupplier.PerformClick();

            if (e.KeyCode == Keys.Enter)
                txtCategory.Focus();
        }

        private void txtSuppCode_Validating(object sender, CancelEventArgs e)
        {
            if (txtSuppCode.Text == "")
            {
                txtSuppCode.Clear();
                lblSupplier.Text = "";
                return;
            }

            gSB.Clear();
            gSB.Append("SELECT * FROM tblSupplier WHERE Code = '" + txtSuppCode.Text.Trim() + "' AND IsActive = 'Y' ");
            if (GlbData.AlreadyExist(gSB.ToString()) == false)
            {
                MessageBox.Show("Sorry.. This Supplier does not exist", "INVALID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSuppCode.Focus();
                return;
            }
            else
            {
                gSupplierID = Convert.ToInt32(GlbData.GetValue(gSB.ToString(), "CustID"));
                lblSupplier.Text = GlbData.GetValue(gSB.ToString(), "NameOF");
            }
        }

        private void btnFMajorCat_Click(object sender, EventArgs e)
        {
            f1.gTableName = "tblMajorCategory";
            f1.ShowDialog();
            if (f1.gOkCancel == true)
            {
                txtCategory.Text = f1.CODE;
                //gMajorCatID = f1.CUSTID;
                //lblCategory.Text = f1.NAME;
                txtCategory.Focus();
            }
        }

        private void txtCategory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                btnFMajorCat.PerformClick();

            if (e.KeyCode == Keys.Enter)
                txtModelNo.Focus();

        }

        private void txtCategory_Validating(object sender, CancelEventArgs e)
        {
            if (txtCategory.Text == "")
            {
                txtCategory.Clear();
                lblCategory.Text = "";
                return;
            }

            gSB.Clear();
            gSB.Append("SELECT * FROM tblMajorCategory WHERE Code = '" + txtCategory.Text.Trim() + "' AND IsActive = 'Y' ");
            if (GlbData.AlreadyExist(gSB.ToString()) == false)
            {
                MessageBox.Show("Sorry.. This Major Category does not exist", "INVALID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCategory.Focus();
                return;
            }
            else
            {
                gMajorCatID = Convert.ToInt32(GlbData.GetValue(gSB.ToString(), "CustID"));
                lblCategory.Text = GlbData.GetValue(gSB.ToString(), "NameOF");
            }
        }

        private void btnFBinLoc_Click(object sender, EventArgs e)
        {
            f1.gTableName = "tblBinLocation";
            f1.ShowDialog();
            if (f.gOkCancel == true)
            {
                txtBinLoc.Text = f1.CODE;
                //gBinID = f1.CUSTID;
                //lblBinLocation.Text = f1.NAME;
                txtBinLoc.Focus();
            }
        }

        private void txtBinLoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                btnFBinLoc.PerformClick();

            if (e.KeyCode == Keys.Enter)
                txtCost.Focus();
        }

        private void txtBinLoc_Validating(object sender, CancelEventArgs e)
        {
            if (txtBinLoc.Text == "")
            {
                txtBinLoc.Clear();
                lblBinLocation.Text = "";
                return;
            }

            gSB.Clear();
            gSB.Append("SELECT * FROM tblBinLocation WHERE Code = '" + txtBinLoc.Text.Trim() + "' AND IsActive = 'Y' ");
            if (GlbData.AlreadyExist(gSB.ToString()) == false)
            {
                MessageBox.Show("Sorry.. This Bin Location does not exist", "INVALID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBinLoc.Focus();
                return;
            }
            else
            {
                gBinID = Convert.ToInt32(GlbData.GetValue(gSB.ToString(), "CustID"));
                lblBinLocation.Text = GlbData.GetValue(gSB.ToString(), "NameOF");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private long SaveOrUpdateProduct()
        {
            long tmpID = 0;

            masterFiles.Code = txtCode.Text.Trim();
            masterFiles.NameOF = txtName.Text.Trim();
            masterFiles.SupplierID = gSupplierID;
            masterFiles.ModelNo = txtModelNo.Text.Trim();
            masterFiles.SerialNo = txtSerialNo.Text.Trim();
            masterFiles.BrandName = txtBrandName.Text.Trim();
            masterFiles.Cost = Convert.ToDouble(txtCost.Text);
            masterFiles.WholeSalePrice = Convert.ToDouble(txtWholesale.Text);
            masterFiles.SellingPrice = Convert.ToDouble(txtSelling.Text);
            masterFiles.Discount = Convert.ToDouble(txtDiscount.Text);
            masterFiles.ProfitMargin = Convert.ToDouble(txtMargin.Text);
            masterFiles.CategoryID = gMajorCatID;
            masterFiles.BinID = gBinID;
            masterFiles.ScaleID = gScaleID;

            if (chkActive.Checked == true)
                masterFiles.IsActive = "Y";
            else
                masterFiles.IsActive = "N";

            if (gEditFlag == true)
            {
                masterFiles.UpdateProduct();
                tmpID = 1;
            }
            else
                tmpID = masterFiles.SaveProduct();

            return tmpID;
        }

        private void fillProduct()
        {
            masterFiles.FillProduct(txtCode.Text);
            txtName.Text = masterFiles.NameOF;
            txtModelNo.Text = masterFiles.ModelNo;
            txtSerialNo.Text = masterFiles.SerialNo;
            txtBrandName.Text = masterFiles.BrandName;
            txtCost.Text = string.Format("{0:N}", masterFiles.Cost);
            txtWholesale.Text = string.Format("{0:N}", masterFiles.WholeSalePrice);
            txtSelling.Text = string.Format("{0:N}", masterFiles.SellingPrice);
            txtDiscount.Text = string.Format("{0:N}", masterFiles.Discount);
            lblCost.Text = string.Format("{0:N}", masterFiles.Cost);
            lblWholeSale.Text = string.Format("{0:N}", masterFiles.WholeSalePrice);
            lblSelling.Text = string.Format("{0:N}", masterFiles.SellingPrice);
            lblDiscount.Text = string.Format("{0:N}", masterFiles.Discount);
            txtMargin.Text = string.Format("{0:N}", masterFiles.ProfitMargin);
            gSupplierID = masterFiles.SupplierID;
            gMajorCatID = masterFiles.CategoryID;
            gBinID = masterFiles.BinID;
            gCustID = masterFiles.CustID;
            gScaleID = masterFiles.ScaleID;
            cboScale.SelectedValue = gScaleID;
            txtSuppCode.Text = GlbData.GetValue("SELECT Code FROM tblSupplier WHERE CustID = " + gSupplierID + "", "Code");
            lblSupplier.Text = GlbData.GetValue("SELECT NameOF FROM tblSupplier WHERE CustID = " + gSupplierID + "", "NameOf");
            txtCategory.Text = GlbData.GetValue("SELECT Code FROM tblMajorCategory WHERE CustID = " + gMajorCatID + "", "Code");
            lblCategory.Text = GlbData.GetValue("SELECT NameOF FROM tblMajorCategory WHERE CustID = " + gMajorCatID + "", "NameOF");
            txtBinLoc.Text = GlbData.GetValue("SELECT Code FROM tblBinLocation WHERE CustID = " + gBinID + "", "Code");
            lblBinLocation.Text = GlbData.GetValue("SELECT NameOF FROM tblBinLocation WHERE CustID = " + gBinID + "", "NameOf");
        }

        private void ClearLocal()
        {
            txtName.Clear();
            txtSuppCode.Clear();
            lblSupplier.Text = "";
            txtCategory.Clear();
            lblCategory.Text = "";
            txtModelNo.Clear();
            txtSelling.Clear();
            txtBrandName.Clear();
            txtCost.Text = "0.00";
            txtWholesale.Text = "0.00";
            txtSelling.Text = "0.00";
            txtDiscount.Text = "0.00";
            txtMargin.Text = "0.00";
            lblCost.Text = "0.00";
            lblWholeSale.Text = "0.00";
            lblSelling.Text = "0.00";
            lblDiscount.Text = "0.00";
            txtBrandName.Text = "";
            txtBinLoc.Clear();
            lblBinLocation.Text = "";
            txtSerialNo.Text = "";
            btnDelete.Enabled = false;
        }

        private void txtCode_Validating(object sender, CancelEventArgs e)
        {
            if (txtCode.Text == "")
            {
                ClearLocal();
                txtCode.Clear();
                return;
            }

            gSB.Clear();
            gSB.Append("SELECT * FROM tblItem WHERE Code = '" + txtCode.Text.Trim() + "' ");
            if (GlbData.AlreadyExist(gSB.ToString()))
            {
                gEditFlag = true;
                btnDelete.Enabled = true;
                fillProduct();
            }
            else
            {
                gEditFlag = false;
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearLocal();
            txtCode.Clear();
            txtCode.Focus();
        }

        private void txtCost_Validating(object sender, CancelEventArgs e)
        {
            lblCost.Text = string.Format("{0:N}", Convert.ToDouble(txtCost.Text));
        }

        private void txtWholesale_Validating(object sender, CancelEventArgs e)
        {
            lblWholeSale.Text = string.Format("{0:N}", Convert.ToDouble(txtWholesale.Text));
        }

        private void txtSelling_Validating(object sender, CancelEventArgs e)
        {
            lblSelling.Text = string.Format("{0:N}", Convert.ToDouble(txtSelling.Text));
        }

        private void txtDiscount_Validating(object sender, CancelEventArgs e)
        {
            lblDiscount.Text = string.Format("{0:N}", Convert.ToDouble(txtDiscount.Text));
        }

        public bool IsRequired()
        {
            if (txtCode.Text == "")
            {
                MessageBox.Show("Please Enter Item Code", "Empty Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCode.Focus();
                return false;
            }

            if (txtName.Text == "")
            {
                MessageBox.Show("Please Enter Item Name", "Empty Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtName.Focus();
                return false;
            }

            if (txtSuppCode.Text == "")
            {
                MessageBox.Show("Please Enter Supplier", "Empty Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSuppCode.Focus();
                return false;
            }

            if (txtCategory.Text == "")
            {
                MessageBox.Show("Please Enter Category", "Empty Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCategory.Focus();
                return false;
            }

            if (txtCost.Text == "")
            {
                MessageBox.Show("Please Enter Cost Price", "Empty Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCost.Focus();
                return false;
            }

            if (txtWholesale.Text == "")
            {
                MessageBox.Show("Please Enter WholeSale Price", "Empty Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtWholesale.Focus();
                return false;
            }

            if (txtSelling.Text == "")
            {
                MessageBox.Show("Please Enter Selling Price", "Empty Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSelling.Focus();
                return false;
            }

            if (txtDiscount.Text == "")
            {
                MessageBox.Show("Please Enter Discount Price", "Empty Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiscount.Focus();
                return false;
            }

            if (txtMargin.Text == "")
            {
                MessageBox.Show("Please Enter Profit Margin", "Empty Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMargin.Focus();
                return false;
            }
            
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsRequired())
            {
                if (fConfirm.SayMessage("SV") == true)
                {
                    long tmpKeyHolder = 0;
                    tmpKeyHolder = SaveOrUpdateProduct();

                    if (tmpKeyHolder == 0)
                    {
                        GlbData.SayMessage("Save Failed!!!", 0, "");
                    }
                    else
                    {
                        GlbData.SayMessage("Save Success!!!", 1, "");
                        ClearLocal();
                        txtCode.Clear();
                        txtCode.Focus();
                    }
                }
            }
        }

        private long DeleteRecord()
        {
            MySqlCommand cmd = new MySqlCommand("DELETE FROM tblItem WHERE Code= '" + txtCode.Text + "' ", GlobalData.GCon);
            cmd.ExecuteNonQuery();
            return 1;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (IsRequired())
            {
                if (fConfirm.SayMessage("DL") == true)
                {
                    long tmpKeyHolder = 0;
                    tmpKeyHolder = DeleteRecord();

                    if (tmpKeyHolder == 0)
                    {
                        GlbData.SayMessage("Delete Failed!!!", 0, "");
                    }
                    else
                    {
                        GlbData.SayMessage("Delete Success!!!", 1, "");
                        ClearLocal();
                        txtCode.Clear();
                        txtCode.Focus();
                    }
                }
            }
        }

        private void btnIFind_Click(object sender, EventArgs e)
        {
            frmIPItemSearch f1 = new frmIPItemSearch();
            f1.ShowDialog();
            if (f1.gOkCancel == true)
            {
                txtCode.Text = f1.CODE;
                txtCode.Focus();
            }
        }

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                btnIFind.PerformClick();

            if (e.KeyCode == Keys.Enter)
                txtName.Focus();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtSuppCode.Focus();
        }

        private void txtModelNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtSerialNo.Focus();
        }

        private void txtSerialNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtBrandName.Focus();
        }

        private void txtBrandName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtBinLoc.Focus();
        }

        private void txtCost_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtWholesale.Focus();
        }

        private void txtWholesale_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtSelling.Focus();
        }

        private void txtSelling_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtDiscount.Focus();
        }

        private void txtDiscount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtMargin.Focus();
        }

        private void txtMargin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSave.Focus();
        }

        private void btnScale_Click(object sender, EventArgs e)
        {
            fCommon.gTableName = "tblScale";
            fCommon.gHeaderName = " Scale".ToUpper();
            fCommon.ShowDialog();
            FillScale();
        }

        private void FillScale()
        {
            string cQuery = "SELECT * FROM tblScale WHERE IsActive = 'Y' ORDER BY NameOF";
            cboScale.DataSource = GlbData.getDataSet(cQuery, "tblScale").Tables[0];
            cboScale.ValueMember = "CustID";
            cboScale.DisplayMember = "NameOF";
        }

        private void cboScale_Validating(object sender, CancelEventArgs e)
        {
            if (cboScale.Text == "")
                return;
            else
                gScaleID = Convert.ToInt32(cboScale.SelectedValue);
        }
    }
}
