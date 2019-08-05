using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LOB
{
    public partial class frmIPSRN : Form
    {
        private double gCostPrice = 0;
        private int gItemID = 0;
        private string gTranCode = "SUP003";
        private string gStockRoomName = "";
        private long gBriefID = 0;
        private string gTranName = "PURCHASE RETURN";
        private int gCustID = 0;
        private DateTime gServerDate = DateTime.Now;
        private string gAdd1 = "";
        private string gAdd2 = "";
        private string gCity = "";
        private string gTp1 = "";
        private string gTp2 = "";
        private string gTp3 = "";

        GlobalData GlbData = new GlobalData();
        DataSet dSet = new DataSet();
        StringBuilder gSB = new StringBuilder();
        MasterFiles masterFiles = new MasterFiles();
        Transactions tran = new Transactions();
        frmConfirmMessage fConfirm = new frmConfirmMessage();

        public frmIPSRN()
        {
            InitializeComponent();
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            frmIPSupplier f = new frmIPSupplier();
            f.ShowDialog();
        }

        private void btnFSupp_Click(object sender, EventArgs e)
        {
            frmIPSearchDealer f = new frmIPSearchDealer();
            f.TABLE_NAME = "tblSupplier";
            f.ShowDialog();
            if (f.gOkCancel == true)
            {
                txtSuppCode.Text = f.CODE;
                gCustID = f.CUSTID;
                txtSuppCode.Focus();
            }
        }

        private void btnIFind_Click(object sender, EventArgs e)
        {
            frmIPSearch f = new frmIPSearch();
            f.ShowDialog();

            if (f.gOkCancel == true)
            {
                txtCode.Text = f.CODE;
                txtCode.Focus();
            }
        }

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                btnIFind.PerformClick();
        }

        private void txtCode_Validating(object sender, CancelEventArgs e)
        {
            if (txtCode.Text == "")
                return;

            gSB.Clear();
            gSB.Append("SELECT * FROM tblItem WHERE Code = '" + txtCode.Text.Trim() + "' AND IsActive = 'Y'");
            if (GlbData.AlreadyExist(gSB.ToString()))
            {
                fillProduct();
            }
            else
            {
                MessageBox.Show("Sorry.. This Product does not Exist", "INVALID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCode.Focus();
                return;
            }
        }

        private void fillProduct()
        {
            masterFiles.FillProduct(txtCode.Text.Trim());
            gItemID = masterFiles.CustID;
            lblProduct.Text = masterFiles.NameOF;
            txtPrice.Text = string.Format("{0:N}", masterFiles.Cost);
            gCostPrice = masterFiles.Cost;
        }

        private void txtQty_TextChanged(object sender, EventArgs e)
        {
            if (txtQty.Text == "")
                return;

            decimal tmpQty, tmpPrice = 0;
            decimal.TryParse(txtQty.Text, out tmpQty);
            decimal.TryParse(txtPrice.Text, out tmpPrice);
            decimal TotAmount = tmpPrice * tmpQty;
            txtTotalAmount.Text = string.Format("{0:N}", Math.Round(TotAmount, 2));
        }

        private Boolean IsRequiredGrid()
        {
            if (txtCode.Text == "")
            {
                MessageBox.Show("Empty Product Code", "INVALID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCode.Focus();
                return false;
            }
            if (txtQty.Text == "" || Convert.ToDouble(txtQty.Text) == 0)
            {
                MessageBox.Show("Invalid Product Qty", "INVALID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQty.Focus();
                return false;
            }
            return true;
        }

        private void AddingGrid(int cItemID, string cCode, string cItemName, double cUnitPrice, double cFree, double cQty, double cTotalAmount, double cCost)
        {
            DataGridViewRow newRow = (DataGridViewRow)dgvGrid.RowTemplate.Clone();
            newRow.CreateCells(dgvGrid);

            newRow.Cells[0].Value = cItemID.ToString();
            newRow.Cells[1].Value = cCode.ToString();
            newRow.Cells[2].Value = cItemName.ToString();
            newRow.Cells[3].Value = string.Format("{0:N}", cUnitPrice);
            newRow.Cells[4].Value = cFree.ToString();
            newRow.Cells[5].Value = cQty.ToString();
            newRow.Cells[6].Value = string.Format("{0:N}", cTotalAmount);
            newRow.Cells[7].Value = string.Format("{0:N}", cCost);

            dgvGrid.Rows.Add(newRow);
        }

        private double CalcTotalAmount()
        {
            double myTotalAmount = 0;
            for (int i = 0; i < dgvGrid.Rows.Count; i++)
            {
                myTotalAmount = myTotalAmount + Convert.ToDouble(dgvGrid.Rows[i].Cells[6].Value);
            }
            return myTotalAmount;
        }

        private void txtQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (IsRequiredGrid())
                {
                    AddingGrid(gItemID, txtCode.Text.Trim(), lblProduct.Text, Convert.ToDouble(txtPrice.Text), Convert.ToDouble(txtFree.Text), Convert.ToDouble(txtQty.Text), Convert.ToDouble(txtTotalAmount.Text), gCostPrice);
                    lblSubTotal.Text = string.Format("{0:N}", CalcTotalAmount());
                    lblNetTotal.Text = string.Format("{0:N}", CalcTotalAmount());
                    ClearGrid();
                    lblTotItems.Text = dgvGrid.Rows.Count.ToString();
                }
            }
        }

        private void ClearGrid()
        {
            txtCode.Clear();
            lblProduct.Text = "";
            txtPrice.Text = "0.00";
            txtQty.Text = "0";
            txtTotalAmount.Text = "0.00";
            txtFree.Text = "0";
            txtCode.Focus();
        }

        private void dgvGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == dgvGrid.NewRowIndex || e.RowIndex < 0)
                return;

            if (e.ColumnIndex == dgvGrid.Columns["Column7"].Index)
            {
                dgvGrid.Rows.RemoveAt(e.RowIndex);
                lblNetTotal.Text = string.Format("{0:N}", CalcTotalAmount());
                lblTotItems.Text = dgvGrid.Rows.Count.ToString();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClearLocal()
        {
            ClearGrid();
            txtRefNo.Clear();
            dtpDate.Text = DateTime.Now.ToShortDateString();
            dgvGrid.Rows.Clear();
            lblNetTotal.Text = "0.00";
            lblTotItems.Text = "0";
            txtSuppCode.Text = "";
            lblSupplier.Text = "";
            lblSubTotal.Text = "0.00";
            txtDisAmt.Text = "0.00";
            txtDisPer.Text = "0.00";
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearLocal();
            txtRefNo.Text = "";
            txtRefNo.Focus();
        }

        private void txtSuppCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                btnFSupp.PerformClick();
        }

        private void txtSuppCode_Validating(object sender, CancelEventArgs e)
        {
            if (txtSuppCode.Text == "")
            {
                lblSupplier.Text = "";
                return;
            }

            gSB.Clear();
            gSB.Append("SELECT Code FROM tblSupplier WHERE Code = '" + txtSuppCode.Text.Trim() + "' ");
            if (GlbData.AlreadyExist(gSB.ToString()))
            {
                fillSupplier();
            }
            else
            {
                MessageBox.Show("Sorry.. This Supplier does not exist", "INVALID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSuppCode.Focus();
                return;
            }
        }

        private void fillSupplier()
        {
            masterFiles.FillSupplier(txtSuppCode.Text.Trim());
            lblSupplier.Text = masterFiles.NameOF;
            gCustID = masterFiles.CustID;
            gAdd1 = masterFiles.Add1;
            gAdd2 = masterFiles.Add2;
            gCity = masterFiles.City;
            gTp1 = masterFiles.Tp1;
            gTp2 = masterFiles.Tp2;
            gTp3 = masterFiles.Tp3;
        }

        private bool IsRequired()
        {
            if (txtRefNo.Text == "")
            {
                MessageBox.Show("Empty Ref no", "INVALID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRefNo.Focus();
                return false;
            }
            if (dgvGrid.Rows.Count == 0)
            {
                MessageBox.Show("Empty Grid", "INVALID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCode.Focus();
                return false;
            }
            gSB.Clear();
            gSB.Append("SELECT * FROM tblPRNBrief WHERE BillNo = '" + txtRefNo.Text.Trim() + "' ");
            if (GlbData.AlreadyExist(gSB.ToString()))
            {
                MessageBox.Show("Sorry.. This ref no alredy exist", "INVALID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRefNo.Focus();
                return false;
            }
            return true;
        }

        private long RoadToSave()
        {
            gBriefID = SaveBrief();

            if (gBriefID > 0)
            {
                tran.SavePRNDetail(gBriefID, dgvGrid);
                SaveStockFlow();
                UpdateItemStock();
            }
            return gBriefID;
        }

        private void SaveStockFlow()
        {
            tran.DateOn = gServerDate;
            tran.HeaderName = gTranName;
            tran.UserID = GlobalData.GUserID;
            tran.UserName = GlobalData.GUsername;
            tran.CompID = GlobalData.GCompID;
            tran.ComputerName = GlobalData.GCompName;
            tran.DelUserID = 0;
            tran.DelUserName = "";
            tran.DelCompID = 0;
            tran.DelComputerName = "";
            tran.IsActive = "Y";
            tran.SaleBillID = Convert.ToInt32(gBriefID);
            tran.TranCode = gTranCode;
            tran.StockRoomID = GlobalData.GStockRoomID;

            tran.SaveSTOCKFlow(gBriefID, dgvGrid, "D");
        }

        private void UpdateItemStock()
        {
            for (int i = 0; i < dgvGrid.Rows.Count; i++)
            {

                tran.SaveOrUpdateStock(Convert.ToInt32(dgvGrid.Rows[i].Cells[0].Value), "D", Convert.ToDouble(dgvGrid.Rows[i].Cells[5].Value));

                if (Convert.ToDouble(dgvGrid.Rows[i].Cells[4].Value) > 0)
                    tran.SaveOrUpdateStock(Convert.ToInt32(dgvGrid.Rows[i].Cells[0].Value), "D", Convert.ToDouble(dgvGrid.Rows[i].Cells[4].Value));

            }
        }

        private long SaveBrief()
        {
            string tmpBillNo = GlbData.getUniqueNumber("PURRETURN", GlobalData.GCompID).ToString();
            long tmpID = 0;

            tran.DateOn = gServerDate;
            tran.BillNo = txtRefNo.Text;
            tran.MOP = "CRE";
            tran.CustID = gCustID;
            tran.Add1 = gAdd1;
            tran.Add2 = gAdd2;
            tran.City = gCity;
            tran.Tp1 = gTp1;
            tran.Tp2 = gTp2;
            tran.Tp3 = gTp3;
            tran.DescriptionOf = "";
            tran.GrossTotal = Convert.ToDouble(lblSubTotal.Text);
            tran.CNAmount = 0;
            tran.NetTotal = Convert.ToDouble(lblNetTotal.Text);
            tran.TotalPaid = 0;
            tran.NetAmount = Convert.ToDouble(lblNetTotal.Text);
            tran.ManAmount = Convert.ToDouble(lblNetTotal.Text);
            tran.Balance = 0;
            tran.DisRate = Convert.ToDouble(txtDisPer.Text);
            tran.DisAmount = Convert.ToDouble(txtDisAmt.Text);
            tran.VatRate = 0;
            tran.VatAmount = 0;
            tran.StockRoomID = GlobalData.GStockRoomID;
            tran.SystemRefNo = tmpBillNo;
            tran.DueDate = DateTime.Now;
            tran.UserID = GlobalData.GUserID;
            tran.UserName = GlobalData.GUsername;
            tran.CompID = GlobalData.GCompID;
            tran.ComputerName = GlobalData.GCompName;
            tran.DelUserID = 0;
            tran.DelUserName = "";
            tran.DelCompID = 0;
            tran.DelComputerName = "";
            tran.IsActive = "Y";
            tran.TranCode = gTranCode;
            tran.NameOf = lblSupplier.Text;
            tran.PurchaseOrderNo = "";
            tran.CSHPaidOn = 0;
            tran.CCSPaidOn = 0;
            tran.CHQPaidOn = 0;
            tran.CREPaidOn = 0;

            tmpID = tran.SavePRNBrief();

            return tmpID;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsRequired())
            {
                if (fConfirm.SayMessage("SV") == true)
                {
                    long tmpKeyHolder = 0;
                    tmpKeyHolder = RoadToSave();

                    if (tmpKeyHolder == 0)
                    {
                        GlbData.SayMessage("Save Failed!!!", 0, "");
                    }
                    else
                    {
                        GlbData.SayMessage("Save Success!!!", 1, "");
                        ClearLocal();
                        txtRefNo.Focus();
                    }
                }
            }
        }
    }
}
