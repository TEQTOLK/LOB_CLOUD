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
    public partial class frmIPEarlierSale : Form
    {
        private double gCostPrice = 0;
        private int gItemID = 0;
        private string gTranCode = "CUS007";
        private string gStockRoomName = "";
        private long gBriefID = 0;
        private string gTranName = "EARLIER SALE";
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

        public frmIPEarlierSale()
        {
            InitializeComponent();
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            frmIPCustomer f = new frmIPCustomer();
            f.ShowDialog();
        }

        private void btnFSupp_Click(object sender, EventArgs e)
        {
            frmIPSearchDealer f = new frmIPSearchDealer();
            f.TABLE_NAME = "tblCustomer";
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
            masterFiles.FillProduct("ES");
            txtCode.Text = "ES";
            gItemID = masterFiles.CustID;
            lblProduct.Text = masterFiles.NameOF;
        }

        private void txtSuppCode_Validating(object sender, CancelEventArgs e)
        {
            if (txtSuppCode.Text == "")
            {
                lblSupplier.Text = "";
                return;
            }

            gSB.Clear();
            gSB.Append("SELECT Code FROM tblCustomer WHERE Code = '" + txtSuppCode.Text.Trim() + "' ");
            if (GlbData.AlreadyExist(gSB.ToString()))
            {
                fillSupplier();
            }
            else
            {
                MessageBox.Show("Sorry.. This Customer does not exist", "INVALID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSuppCode.Focus();
                return;
            }
        }

        private void fillSupplier()
        {
            masterFiles.FillCustomer(txtSuppCode.Text.Trim());
            lblSupplier.Text = masterFiles.NameOF;
            gCustID = masterFiles.CustID;
            gAdd1 = masterFiles.Add1;
            gAdd2 = masterFiles.Add2;
            gCity = masterFiles.City;
            gTp1 = masterFiles.Tp1;
            gTp2 = masterFiles.Tp2;
            gTp3 = masterFiles.Tp3;
        }

        private void txtSuppCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                btnFSupp.PerformClick();
        }

        private void ClearGrid()
        {
            //txtCode.Clear();
            //lblProduct.Text = "";
            dtpInvoiceDate.Text = DateTime.Now.ToShortDateString();
            txtINVNo.Clear();
            txtOutstanding.Text = "0.00";
            dtpInvoiceDate.Focus();
        }

        private void ClearLocal()
        {
            ClearGrid();
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

        private void dgvGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == dgvGrid.NewRowIndex || e.RowIndex < 0)
                return;

            if (e.ColumnIndex == dgvGrid.Columns["Column7"].Index)
            {
                dgvGrid.Rows.RemoveAt(e.RowIndex);
                lblNetTotal.Text = string.Format("{0:N}", CalcTotalAmount());
                lblSubTotal.Text = string.Format("{0:N}", CalcTotalAmount());
                lblTotItems.Text = dgvGrid.Rows.Count.ToString();
            }
        }

        private double CalcTotalAmount()
        {
            double myTotalAmount = 0;
            for (int i = 0; i < dgvGrid.Rows.Count; i++)
            {
                myTotalAmount = myTotalAmount + Convert.ToDouble(dgvGrid.Rows[i].Cells[5].Value);
            }
            return myTotalAmount;
        }

        private Boolean IsRequiredGrid()
        {
            if (txtCode.Text == "")
            {
                MessageBox.Show("Empty Product Code", "INVALID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCode.Focus();
                return false;
            }
            if (txtINVNo.Text == "")
            {
                MessageBox.Show("Empty Invoice No", "INVALID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtINVNo.Focus();
                return false;
            }
            if (txtOutstanding.Text == "" || Convert.ToDouble(txtOutstanding.Text) == 0)
            {
                MessageBox.Show("Invalid Oustanding Amount", "INVALID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtOutstanding.Focus();
                return false;
            }
            return true;
        }

        private void AddingGrid(int cItemID, string cCode, string cItemName, DateTime cInvDate, string cInvNo, double cOutstanding)
        {
            DataGridViewRow newRow = (DataGridViewRow)dgvGrid.RowTemplate.Clone();
            newRow.CreateCells(dgvGrid);

            newRow.Cells[0].Value = cItemID.ToString();
            newRow.Cells[1].Value = cCode.ToString();
            newRow.Cells[2].Value = cItemName.ToString();
            newRow.Cells[3].Value = cInvDate.ToShortDateString();
            newRow.Cells[4].Value = cInvNo.ToString();
            newRow.Cells[5].Value = string.Format("{0:N}", cOutstanding);

            dgvGrid.Rows.Add(newRow);
        }

        private void txtOutstanding_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (IsRequiredGrid())
                {
                    AddingGrid(gItemID, txtCode.Text.Trim(), lblProduct.Text, Convert.ToDateTime(dtpInvoiceDate.Text), txtINVNo.Text.Trim(), Convert.ToDouble(txtOutstanding.Text));
                    lblSubTotal.Text = string.Format("{0:N}", CalcTotalAmount());
                    lblNetTotal.Text = string.Format("{0:N}", CalcTotalAmount());
                    ClearGrid();
                    lblTotItems.Text = dgvGrid.Rows.Count.ToString();
                }
            }
        }

        private bool IsRequired()
        {
            if (txtSuppCode.Text == "")
            {
                MessageBox.Show("Empty Customer", "INVALID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSuppCode.Focus();
                return false;
            }
            if (dgvGrid.Rows.Count == 0)
            {
                MessageBox.Show("Empty Grid", "INVALID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCode.Focus();
                return false;
            }
            gSB.Clear();
            gSB.Append("SELECT * FROM tblSaleBrief WHERE BillNo = 'ES-' + '" + txtINVNo.Text.Trim() + "' ");
            if (GlbData.AlreadyExist(gSB.ToString()))
            {
                MessageBox.Show("Sorry.. This Invoice no alredy exist", "INVALID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtINVNo.Focus();
                return false;
            }
            return true;
        }

        private long RoadToSave()
        {
            gBriefID = SaveBrief();

            //if (gBriefID > 0)
            //{
            //    tran.SaveSaleDetail(gBriefID, dgvGrid);
            //}
            return gBriefID;
        }

        private long SaveBrief()
        {
            long tmpID = 0;
            for (int i = 0; i < dgvGrid.Rows.Count; i++)
            {
                tran.DateOn = Convert.ToDateTime(dgvGrid.Rows[i].Cells[3].Value);
                tran.BillNo = "ES-" + dgvGrid.Rows[i].Cells[4].Value.ToString();
                tran.MOP = "CRE";
                tran.CustID = gCustID;
                tran.Add1 = gAdd1;
                tran.Add2 = gAdd2;
                tran.City = gCity;
                tran.Tp1 = gTp1;
                tran.Tp2 = gTp2;
                tran.Tp3 = gTp3;
                tran.DescriptionOf = "";
                tran.GrossTotal = Convert.ToDouble(dgvGrid.Rows[i].Cells[5].Value);
                tran.CNAmount = 0;
                tran.NetTotal = Convert.ToDouble(dgvGrid.Rows[i].Cells[5].Value);
                tran.TotalPaid = 0;
                tran.NetAmount = Convert.ToDouble(dgvGrid.Rows[i].Cells[5].Value);
                tran.ManAmount = Convert.ToDouble(dgvGrid.Rows[i].Cells[5].Value);
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
                tran.NameOf = lblSupplier.Text;
                tran.CSHPaidOn = 0;
                tran.CCSPaidOn = 0;
                tran.CHQPaidOn = 0;
                tran.CREPaidOn = 0;

                tmpID = tran.SaveSALEBrief();
            }

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
                        dtpDate.Focus();
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmIPEarlierSale_Load(object sender, EventArgs e)
        {
            SaveOrUpdateProduct();
        }

        private void SaveOrUpdateProduct()
        {
            gSB.Clear();
            gSB.Append("SELECT * FROM tblItem WHERE Code = 'ES'");

            if(!GlbData.AlreadyExist(gSB.ToString()))
            {
                masterFiles.Code = "ES";
                masterFiles.NameOF = "EARLIER SALE";
                masterFiles.SupplierID = 0;
                masterFiles.ModelNo = "";
                masterFiles.SerialNo = "";
                masterFiles.BrandName = "";
                masterFiles.Cost = 0;
                masterFiles.WholeSalePrice = 0;
                masterFiles.SellingPrice = 0;
                masterFiles.Discount = 0;
                masterFiles.ProfitMargin = 0;
                masterFiles.CategoryID = 0;
                masterFiles.BinID = 0;
                masterFiles.ScaleID = 0;
                masterFiles.IsActive = "Y";

                masterFiles.SaveProduct();
            }
            else
            {
                fillProduct();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmIPProduct f = new frmIPProduct();
            f.ShowDialog();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearLocal();
            dtpInvoiceDate.Focus();
        }
    }
}
