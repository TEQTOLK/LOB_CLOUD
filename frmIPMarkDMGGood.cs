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
    public partial class frmIPMarkDMGGood : Form
    {
        public int gCustID = 0;
        private DateTime gServerDate = DateTime.Now;
        private string gTranCode = "STO002";
        private string gStockRoomName = "";
        private long gBriefID = 0;
        private double gCostPrice = 0;
        private string gTranName = "DAMAGE GOODS";

        GlobalData GlbData = new GlobalData();
        DataSet dSet = new DataSet();
        StringBuilder gSB = new StringBuilder();
        MasterFiles masterFiles = new MasterFiles();
        Transactions tran = new Transactions();
        frmConfirmMessage fConfirm = new frmConfirmMessage();

        public frmIPMarkDMGGood()
        {
            InitializeComponent();
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
            gCustID = masterFiles.CustID;
            lblProduct.Text = masterFiles.NameOF;
            txtPrice.Text = string.Format("{0:N}", masterFiles.SellingPrice);
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void AddingGrid(int cItemID, string cCode, string cItemName, double cUnitPrice, double cQty, double cTotalAmount, double cCost)
        {
            DataGridViewRow newRow = (DataGridViewRow)dgvOpenStock.RowTemplate.Clone();
            newRow.CreateCells(dgvOpenStock);

            newRow.Cells[0].Value = cItemID.ToString();
            newRow.Cells[1].Value = cCode.ToString();
            newRow.Cells[2].Value = cItemName.ToString();
            newRow.Cells[3].Value = string.Format("{0:N}", cUnitPrice);
            newRow.Cells[4].Value = cQty.ToString();
            newRow.Cells[5].Value = string.Format("{0:N}", cTotalAmount);
            newRow.Cells[6].Value = string.Format("{0:N}", cCost);

            dgvOpenStock.Rows.Add(newRow);
        }

        private double CalcTotalAmount()
        {
            double myTotalAmount = 0;
            for (int i = 0; i < dgvOpenStock.Rows.Count; i++)
            {
                myTotalAmount = myTotalAmount + Convert.ToDouble(dgvOpenStock.Rows[i].Cells[5].Value);
            }
            return myTotalAmount;
        }

        private void txtQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (IsRequiredGrid())
                {
                    AddingGrid(gCustID, txtCode.Text.Trim(), lblProduct.Text, Convert.ToDouble(txtPrice.Text), Convert.ToDouble(txtQty.Text), Convert.ToDouble(txtTotalAmount.Text), gCostPrice);
                    lblNetTotal.Text = string.Format("{0:N}", CalcTotalAmount());
                    ClearGrid();
                    lblTotItems.Text = dgvOpenStock.Rows.Count.ToString();
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
            txtCode.Focus();
        }

        private void dgvOpenStock_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == dgvOpenStock.NewRowIndex || e.RowIndex < 0)
                return;

            if (e.ColumnIndex == dgvOpenStock.Columns["Column7"].Index)
            {
                dgvOpenStock.Rows.RemoveAt(e.RowIndex);
                lblNetTotal.Text = string.Format("{0:N}", CalcTotalAmount());
                lblTotItems.Text = dgvOpenStock.Rows.Count.ToString();
            }
        }

        private long SaveBrief()
        {
            long tmpID = 0;

            tran.DateOn = gServerDate;
            tran.BillNo = txtRefNo.Text;
            tran.MOP = "CRE";
            tran.CustID = GlobalData.GStockRoomID;
            tran.Add1 = "";
            tran.Add2 = "";
            tran.City = "";
            tran.Tp1 = "";
            tran.Tp2 = "";
            tran.Tp3 = "";
            tran.DescriptionOf = "";
            tran.GrossTotal = Convert.ToDouble(lblNetTotal.Text);
            tran.CNAmount = 0;
            tran.NetTotal = Convert.ToDouble(lblNetTotal.Text);
            tran.TotalPaid = 0;
            tran.NetAmount = Convert.ToDouble(lblNetTotal.Text);
            tran.ManAmount = Convert.ToDouble(lblNetTotal.Text);
            tran.Balance = 0;
            tran.DisRate = 0;
            tran.DisAmount = 0;
            tran.VatRate = 0;
            tran.VatAmount = 0;
            tran.StockRoomID = GlobalData.GStockRoomID;
            tran.SystemRefNo = "";
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
            tran.NameOf = gStockRoomName;

            tmpID = tran.SaveMarkDAMBrief();

            return tmpID;
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

            tran.SaveSTOCKFlow(gBriefID, dgvOpenStock, "D");
        }

        private void UpdateItemStock()
        {
            for (int i = 0; i < dgvOpenStock.Rows.Count; i++)
            {

                tran.SaveOrUpdateStock(Convert.ToInt32(dgvOpenStock.Rows[i].Cells[0].Value), "D", Convert.ToDouble(dgvOpenStock.Rows[i].Cells[4].Value));

            }
        }

        private long RoadToSave()
        {
            gBriefID = SaveBrief();

            if (gBriefID > 0)
            {
                tran.SaveMarkDAMDetail(gBriefID, dgvOpenStock);
                SaveStockFlow();
                UpdateItemStock();
            }
            return gBriefID;
        }

        private bool IsRequired()
        {
            if (txtRefNo.Text == "")
            {
                MessageBox.Show("Empty Ref no", "INVALID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRefNo.Focus();
                return false;
            }
            if (txtReason.Text == "")
            {
                MessageBox.Show("Empty Reason", "INVALID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtReason.Focus();
                return false;
            }
            if (dgvOpenStock.Rows.Count == 0)
            {
                MessageBox.Show("Empty Grid", "INVALID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCode.Focus();
                return false;
            }
            gSB.Clear();
            gSB.Append("SELECT * FROM tblMarkDAMBrief WHERE BillNo = '" + txtRefNo.Text.Trim() + "' ");
            if (GlbData.AlreadyExist(gSB.ToString()))
            {
                MessageBox.Show("Sorry.. This ref no alredy exist", "INVALID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRefNo.Focus();
                return false;
            }
            return true;
        }

        private void ClearLocal()
        {
            ClearGrid();
            txtRefNo.Clear();
            dtpDate.Text = DateTime.Now.ToShortDateString();
            dgvOpenStock.Rows.Clear();
            lblNetTotal.Text = "0.00";
            lblTotItems.Text = "0";
            txtReason.Clear();
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

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearLocal();
            txtRefNo.Focus();
        }

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                btnIFind.PerformClick();
        }
    }
}
