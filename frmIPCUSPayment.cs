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
    public partial class frmIPCUSPayment : Form
    {
        private long gMOPID = 0;
        private int gCustID = 0;
        private string gAdd1 = "";
        private string gAdd2 = "";
        private string gCity = "";
        private string gTp1 = "";
        private string gTp2 = "";
        private string gTp3 = "";
        private double gSelectedAmount = 0;
        List<string> gMyList = new List<string>();
        private string gTranCode = "CUS004";
        private string gTranName = "CUSTOMER PAYMENT";
        private long gPaidID = 0;
        private long gBriefID = 0;
        private string gIsDeposited = "N";
        private string gISRealized = "N";
        private string gIsActive = "Y";
        private string gIsReturned = "N";
        private int gBankId = 0;
        private string gCHQNo = "";
        private DateTime gCHQDate = DateTime.Now;
        private string gComments = "";
        private int gCardID = 0;
        private DateTime gExpairDate = DateTime.Now;
        private string gBillIDs = "";
        private string gBillNo = "";

        GlobalData GlbData = new GlobalData();
        DataSet dSet = new DataSet();
        StringBuilder gSB = new StringBuilder();
        MasterFiles masterFiles = new MasterFiles();
        Transactions tran = new Transactions();
        frmConfirmMessage fConfirm = new frmConfirmMessage();
        PrintReport print = new PrintReport();

        public frmIPCUSPayment()
        {
            InitializeComponent();
        }

        private void frmIPSUPPayment_Load(object sender, EventArgs e)
        {

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

        private void txtSuppCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down) btnFSupp.PerformClick();
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
                LoadOutstanding();
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

        private void getTotalReceivable()
        {
            double totalAmount = 0;
            double totalPaid = 0;

            for (int i = 0; i < dgvOutstanding.Rows.Count; i++)
            {
                totalAmount += Convert.ToDouble(dgvOutstanding.Rows[i].Cells[2].Value);
                totalPaid += Convert.ToDouble(dgvOutstanding.Rows[i].Cells[3].Value);
            }

            //lblTotal.Text = string.Format("{0:N}", totalAmount);
            //lblTotalPaid.Text = string.Format("{0:N}", totalPaid);
            lblPayable.Text = string.Format("{0:N}", totalAmount - totalPaid);
        }

        private void LoadOutstanding()
        {
            gSB.Clear();
            gSB.Append("SELECT DateOn, BillNo, NetTotal, TotalPaid, NetTotal - CNAmount - TotalPaid AS Payable, " +
                " PerformedOn, UserName, BillID " +
                " FROM  tblSaleBrief " +
                " WHERE MOP = 'CRE' AND (NetTotal- TotalPaid) > 0 AND CompID = " + GlobalData.GCompID + " " +
                " AND CustID = " + gCustID + " ORDER BY BillID ");
            dSet = GlbData.getDataSet(gSB.ToString(), "tblSaleBrief");
            DataView dView = new DataView(dSet.Tables[0]);
            dgvOutstanding.DataSource = dView;
            SettingGrid(dgvOutstanding);
            getTotalReceivable();
        }

        private void SettingGrid(DataGridView dataGridView)
        {
            dataGridView.Columns[7].Visible = false;

            dataGridView.Columns[0].HeaderText = "Date";
            dataGridView.Columns[0].Width = 100;
            dataGridView.Columns[1].HeaderText = "BillNo";
            dataGridView.Columns[1].Width = 100;
            dataGridView.Columns[2].HeaderText = "Net Total";
            dataGridView.Columns[2].Width = 100;
            dataGridView.Columns[3].HeaderText = "Total Paid";
            dataGridView.Columns[3].Width = 100;
            dataGridView.Columns[4].HeaderText = "Payable";
            dataGridView.Columns[4].Width = 100;
            dataGridView.Columns[5].HeaderText = "PerformedOn";
            dataGridView.Columns[5].Width = 170;
            dataGridView.Columns[6].HeaderText = "Bill User";
            dataGridView.Columns[6].Width = 80;

            dataGridView.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dataGridView.Columns[2].DefaultCellStyle.Format = "N2";
            dataGridView.Columns[3].DefaultCellStyle.Format = "N2";
            dataGridView.Columns[4].DefaultCellStyle.Format = "N2";
        }

        private void dgvOutstanding_DoubleClick(object sender, EventArgs e)
        {
            int gBillID = Convert.ToInt32(dgvOutstanding.Rows[dgvOutstanding.CurrentRow.Index].Cells[7].Value);
            string gBillNO = dgvOutstanding.Rows[dgvOutstanding.CurrentRow.Index].Cells[1].Value.ToString();
            double gNetTotal = Convert.ToDouble(dgvOutstanding.Rows[dgvOutstanding.CurrentRow.Index].Cells[4].Value);
            string gDateOn = dgvOutstanding.Rows[dgvOutstanding.CurrentRow.Index].Cells[0].Value.ToString();

            if (CheckSameItem(gBillID))
            {
                AddingGrid(gBillID, gDateOn, gBillNO, gNetTotal);
            }
        }

        private void AddingGrid(int cBillID, string cDateOn, string cBillNo, double cNetTotal)
        {
            DataGridViewRow newRow = (DataGridViewRow)dgvSelectedBill.RowTemplate.Clone();
            newRow.CreateCells(dgvSelectedBill);

            newRow.Cells[0].Value = cBillID.ToString();
            newRow.Cells[1].Value = Convert.ToDateTime(cDateOn).ToShortDateString();
            newRow.Cells[2].Value = cBillNo.ToString();
            newRow.Cells[3].Value = string.Format("{0:N}", cNetTotal);

            dgvSelectedBill.Rows.Add(newRow);

            gSelectedAmount = Convert.ToDouble(lblSelectedAmount.Text) + cNetTotal;
            lblSelectedAmount.Text = string.Format("{0:N}", gSelectedAmount);
            lblSelectedAmt.Text = string.Format("{0:N}", gSelectedAmount);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (IsRequiredNext())
            {
                gMyList.Clear();
                for (int i = 0; i < dgvSelectedBill.Rows.Count; i++)
                {
                    gMyList.Add(dgvSelectedBill.Rows[i].Cells[0].Value.ToString());
                }
                string[] myArray = gMyList.ToArray();
                string gMyCode = string.Join(",", myArray);
                LoadOutstandingSelected(gMyCode);
                pnlPay.Visible = true;
                btnBack.Visible = true;
                btnNew.Visible = false;
                btnCash.Visible = true;
                btnChq.Visible = true;
                btnCard.Visible = true;
                btnNew.Visible = false;
            }
        }

        private void LoadOutstandingSelected(string cBillIDs)
        {
            gSB.Clear();
            gSB.Append("SELECT DateOn, BillNo, NetTotal, TotalPaid, NetTotal - TotalPaid AS Payable, " +
                " PerformedOn, UserName, BillID " +
                " FROM  tblSaleBrief " +
                " WHERE MOP = 'CRE' AND (NetTotal- TotalPaid) > 0 AND CompID = " + GlobalData.GCompID + " " +
                " AND  BillID IN (" + cBillIDs + ") ");
            dSet = GlbData.getDataSet(gSB.ToString(), "tblSaleBrief");
            DataView dView = new DataView(dSet.Tables[0]);
            dgvBills.DataSource = dView;
            SettingGrid(dgvBills);
        }

        private Boolean IsRequiredNext()
        {
            if (dgvSelectedBill.Rows.Count == 0)
            {
                MessageBox.Show("Empty Grid.. Select Atleast One Bill(s)", "INVALID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            pnlPay.Visible = false;
            btnNew.Visible = true;
            btnCash.Visible = false;
            btnChq.Visible = false;
            btnCard.Visible = false;
            btnNext.Visible = true;
            btnBack.Visible = false;
        }

        private Boolean CheckSameItem(int cValue)
        {
            for (int i = 0; i < dgvSelectedBill.Rows.Count; i++)
            {
                if (Convert.ToInt32(dgvSelectedBill.Rows[i].Cells[0].Value) == cValue)
                {
                    MessageBox.Show("Sorry... This Bill Already Added in the List", "INVALID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            return true;
        }

        private double CalcTotalAmount()
        {
            double myTotalAmount = 0;
            for (int i = 0; i < dgvSelectedBill.Rows.Count; i++)
            {
                myTotalAmount = myTotalAmount + Convert.ToDouble(dgvSelectedBill.Rows[i].Cells[3].Value);
            }
            return myTotalAmount;
        }

        private void dgvSelectedBill_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == dgvSelectedBill.NewRowIndex || e.RowIndex < 0)
                return;

            if (e.ColumnIndex == dgvSelectedBill.Columns["Column5"].Index)
            {
                dgvSelectedBill.Rows.RemoveAt(e.RowIndex);
                lblSelectedAmount.Text = string.Format("{0:N}", CalcTotalAmount());
                lblSelectedAmt.Text = string.Format("{0:N}", CalcTotalAmount());
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private Boolean IsRequiredTran()
        {
            if (Convert.ToDouble(lblSelectedAmt.Text) == 0)
            {
                MessageBox.Show("Sorry... Net Total Cannot be Zero!!!", "INVALID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (dgvBills.Rows.Count == 0)
            {
                MessageBox.Show("Sorry... Please Select Bill(s)!!!", "INVALID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return true;
        }

        private void CashPayment()
        {
            frmIPCash f = new frmIPCash();
            f.txtGrossTotal.Text = string.Format("{0:N}", Convert.ToDouble(lblSelectedAmt.Text));
            f.txtDiscount.Text = string.Format("{0:N}", Convert.ToDouble(0));
            f.txtCash.Text = string.Format("{0:N}", Convert.ToDouble(lblSelectedAmt.Text));
            f.txtCash.SelectAll();
            f.txtCash.Focus();
            f.ShowDialog();

            if (f.gOkCancel == true)
            {
                if (fConfirm.SayMessage("SV") == true)
                {
                    long tmpKeyHolder = 0;
                    tmpKeyHolder = RoadToSave("CSH", 0, Convert.ToDouble(lblSelectedAmt.Text), Convert.ToDecimal(f.txtCash.Text));

                    if (tmpKeyHolder == 0)
                    {
                        GlbData.SayMessage("Save Failed!!!", 0, "");
                    }
                    else
                    {
                        GlbData.SayMessage("Save Success!!!", 1, "");
                        if (fConfirm.SayMessage("PR") == true)
                        {
                            print.RoadToPrintReport(getCorrectQuery(), @"C:\LOB\Bin\Debug\Rep\CUSReceipt.rpt");
                        }
                        ClearLocal();
                        btnBack.PerformClick();
                        txtSuppCode.Focus();
                    }
                }
            }
        }
        private void btnCash_Click(object sender, EventArgs e)
        {
            if (IsRequiredTran())
            {
                CashPayment();
            }
        }

        private void btnCard_Click(object sender, EventArgs e)
        {
            if (IsRequiredTran())
            {
                CardPayment();
            }
        }

        private void CardPayment()
        {
            frmIPCard f = new frmIPCard();
            f.txtCash.Text = string.Format("{0:N}", Convert.ToDouble(lblSelectedAmt.Text));
            f.gTotalAmount = Convert.ToDouble(lblSelectedAmt.Text);
            f.txtCash.SelectAll();
            f.txtCash.Focus();
            f.ShowDialog();

            if (f.gOkCancel == true)
            {
                if (fConfirm.SayMessage("SV") == true)
                {
                    long tmpKeyHolder = 0;
                    tmpKeyHolder = RoadToSave("CCS", 0, 0, 0, f.dgvCCard);

                    if (tmpKeyHolder == 0)
                    {
                        GlbData.SayMessage("Save Failed!!!", 0, "");
                    }
                    else
                    {
                        GlbData.SayMessage("Save Success!!!", 1, "");
                        if (fConfirm.SayMessage("PR") == true)
                        {
                            print.RoadToPrintReport(getCorrectQuery(), @"C:\LOB\Bin\Debug\Rep\CUSReceipt.rpt");
                        }
                        ClearLocal();
                        btnBack.PerformClick();
                        txtSuppCode.Focus();
                    }
                }
            }
        }

        private void CHQPayment()
        {
            frmIPCHQ f = new frmIPCHQ();
            f.ShowDialog();

            if (f.gOkCancel == true)
            {
                if (fConfirm.SayMessage("SV") == true)
                {
                    long tmpKeyHolder = 0;
                    tmpKeyHolder = RoadToSave("CHQ", 0, 0, 0, f.dgvCHQ);

                    if (tmpKeyHolder == 0)
                    {
                        GlbData.SayMessage("Save Failed!!!", 0, "");
                    }
                    else
                    {
                        GlbData.SayMessage("Save Success!!!", 1, "");
                        if (fConfirm.SayMessage("PR") == true)
                        {
                            print.RoadToPrintReport(getCorrectQuery(), @"C:\LOB\Bin\Debug\Rep\CUSReceipt.rpt");
                        }
                        ClearLocal();
                        btnBack.PerformClick();
                        txtSuppCode.Focus();
                    }
                }
            }
        }

        private string getCorrectQuery()
        {
            string tmpHolder = "";
            tmpHolder = " SELECT CP.BillNo AS BRBillNo, CU.Code AS CUCode, CU.NameOF AS CUName, CU.Add1 AS CUAdd1, CU.Add2 AS CUAdd2, " +
                " CU.City AS CUCity, CU.Tp1 AS CUTp1, CU.Tp2 AS CUTp2, CU.Tp3 AS CUTp3, " +
                " BR.CashTendered AS BRPaidAmount, BR.MopType AS MOP, BR.CHQNo AS MOChqNo, BR.Bank AS MOBank, " +
                " BR.Branch AS MOBranch, BR.CardCompany AS MOCard, BR.DateOn AS BRDateOn " +
                " FROM tblMOP AS BR INNER JOIN " +
                " tblCustPayBrief AS CP ON BR.MopID = CP.MopId RIGHT OUTER JOIN " +
                " tblCustomer AS CU ON BR.OwnerID = CU.CustID " +
                " WHERE CP.BillNo =  '" + gBillNo + "'";
            return tmpHolder;
        }

        private void btnChq_Click(object sender, EventArgs e)
        {
            if (IsRequiredTran())
            {
                CHQPayment();
            }
        }

        private void ClearLocal()
        {
            lblSupplier.Text = "";
            lblPayable.Text = "0.00";
            lblSelectedAmount.Text = "0.00";
            lblSelectedAmt.Text = "0.00";
            dgvBills.DataSource = null;
            dgvOutstanding.DataSource = null;
            dgvSelectedBill.Rows.Clear();
            
        }

        private long RoadToSave(string cMOP, double cCNAmount, double cTotalPaid, decimal cCashTendered, DataGridView cDataGridView = null)
        {
            long tmpID = 0;
            getBills();
            if (cMOP == "CSH" || cMOP == "CRE")
                SaveMOP(cMOP, 0, "", DateTime.Now, "-", 0, DateTime.Now, cTotalPaid, cCashTendered);

            if (cMOP == "CCS")
                SaveMOP(cDataGridView, cMOP);

            if (cMOP == "CHQ")
                SaveMOP(cDataGridView, cMOP);

            gBriefID = SaveCustPayBrief();
            //tran.SaveCustPayDetail(Convert.ToInt32(gPaidID), Convert.ToInt32(gMOPID));
            UpdateDealerOutstanding(cCashTendered, Convert.ToInt32(gPaidID), Convert.ToInt32(gMOPID));

            return gBriefID;
        }

        public void UpdateDealerOutstanding(decimal cTrenderedAmt, int cPaidId, int cMOPId)
        {
            double tmpCounter = 0;
            double tmpLineAmount = 0;
            int tmpBillID = 0;

            tmpCounter = Convert.ToDouble(cTrenderedAmt);
            for (int i = 0; i < dgvBills.Rows.Count; i++)
            {
                tmpLineAmount = Convert.ToDouble(dgvBills.Rows[i].Cells[2].Value);
                tmpBillID = Convert.ToInt32(dgvBills.Rows[i].Cells[7].Value);

                if (tmpCounter > 0)
                {
                    if (tmpLineAmount < tmpCounter)
                    {
                        MySqlCommand cmd = new MySqlCommand("UPDATE tblSaleBrief SET TotalPaid = TotalPaid + " + tmpLineAmount + " WHERE BillID = " + tmpBillID + " AND CompID = " + GlobalData.GCompID + " ", GlobalData.GCon);
                        cmd.ExecuteNonQuery();

                        tran.SaveCustPayDetail(cPaidId, cMOPId, tmpBillID, tmpLineAmount);

                        tmpCounter -= tmpLineAmount;
                    }
                    else
                    {
                        MySqlCommand cmd = new MySqlCommand("UPDATE tblSaleBrief SET TotalPaid = TotalPaid + " + tmpCounter + " WHERE BillID = " + tmpBillID + " AND CompID = " + GlobalData.GCompID + " ", GlobalData.GCon);
                        cmd.ExecuteNonQuery();

                        tran.SaveCustPayDetail(cPaidId, cMOPId, tmpBillID, tmpCounter);

                        tmpCounter = 0;
                    }
                }
            }
        }

        private void getBills()
        {
            List<string> gList2 = new List<string>();
            gList2.Clear();
            for (int i = 0; i < dgvBills.Rows.Count; i++)
            {
                gList2.Add(dgvBills.Rows[i].Cells[7].Value.ToString());
            }
            string[] myArray = gList2.ToArray();
            gBillIDs = string.Join(",", myArray);
        }

        private long SaveMOP(string cMOP, int cBankId, string cCHQNo, DateTime cCHQDate, string cComments, int cCardID, DateTime cExpairDate, double cTotalPaid, decimal cCashTendered)
        {
            string tmpBillNo = GlbData.getUniqueNumber("MOP", GlobalData.GCompID).ToString();

            tran.MOPType = cMOP;
            tran.NetAmount = Convert.ToDouble(lblSelectedAmt.Text);
            tran.BankID = cBankId;
            tran.CHQNo = gCHQNo;
            tran.CHQDate = cCHQDate;
            tran.Comments = cComments;
            tran.CardID = gCardID;
            tran.ExpairDate = cExpairDate;
            tran.IsDeposited = gIsDeposited;
            tran.IsRealized = gISRealized;
            tran.IsActive = gIsActive;
            tran.RefNo = tmpBillNo;
            tran.TotalPaid = cTotalPaid;
            tran.IsReturned = gIsReturned;
            tran.OwnerID = gCustID;
            tran.OwnerName = lblSupplier.Text;
            tran.CashTendered = cCashTendered;
            tran.Balance = 0;
            tran.UserID = GlobalData.GUserID;
            tran.UserName = GlobalData.GUsername;
            tran.CompID = GlobalData.GCompID;
            tran.ComputerName = GlobalData.GCompName;
            tran.DelUserID = 0;
            tran.DelUserName = "";
            tran.DelCompID = 0;
            tran.DelComputerName = "";
            tran.BillID = 0;
            tran.BillsFor = gBillIDs;
            tran.Bank = "-";
            tran.Branch = "-";
            tran.CardCompany = "-";
            tran.DateOn = DateTime.Now;
            gMOPID = tran.SaveMOP_NEW(0);

            return gMOPID;
        }

        private long SaveMOP(DataGridView cGridView, string cMOP)
        {
            string tmpBillNo = GlbData.getUniqueNumber("MOP", GlobalData.GCompID).ToString();

            if (cMOP == "CCS")
            {
                for (int i = 0; i < cGridView.Rows.Count; i++)
                {
                    tran.MOPType = cMOP;
                    tran.NetAmount = Convert.ToDouble(lblSelectedAmt.Text);
                    tran.BankID = Convert.ToInt32(cGridView.Rows[i].Cells[2].Value);
                    tran.CHQNo = "";
                    tran.CHQDate = DateTime.Now;
                    tran.Comments = "";
                    tran.CardID = Convert.ToInt32(cGridView.Rows[i].Cells[0].Value);
                    tran.ExpairDate = DateTime.Now;
                    tran.IsDeposited = gIsDeposited;
                    tran.IsRealized = gISRealized;
                    tran.IsActive = gIsActive;
                    tran.RefNo = tmpBillNo;
                    tran.TotalPaid = Convert.ToDouble(cGridView.Rows[i].Cells[4].Value);
                    tran.IsReturned = gIsReturned;
                    tran.OwnerID = gCustID;
                    tran.OwnerName = lblSupplier.Text;
                    tran.CashTendered = Convert.ToDecimal(cGridView.Rows[i].Cells[4].Value);
                    tran.Balance = 0;
                    tran.UserID = GlobalData.GUserID;
                    tran.UserName = GlobalData.GUsername;
                    tran.CompID = GlobalData.GCompID;
                    tran.ComputerName = GlobalData.GCompName;
                    tran.DelUserID = 0;
                    tran.DelUserName = "";
                    tran.DelCompID = 0;
                    tran.DelComputerName = "";
                    tran.BillID = 0;
                    tran.BillsFor = gBillIDs;
                    tran.Bank = "-";
                    tran.Branch = "-";
                    tran.CardCompany = cGridView.Rows[i].Cells[1].Value.ToString();
                    tran.DateOn = DateTime.Now;
                    gMOPID = tran.SaveMOP_NEW(0);

                }

            }

            if (cMOP == "CHQ")
            {
                for (int i = 0; i < cGridView.Rows.Count; i++)
                {
                    tran.MOPType = cMOP;
                    tran.NetAmount = Convert.ToDouble(cGridView.Rows[i].Cells[6].Value);
                    tran.BankID = Convert.ToInt32(cGridView.Rows[i].Cells[0].Value);
                    tran.BranchID = Convert.ToInt32(cGridView.Rows[i].Cells[2].Value);
                    tran.CHQNo = cGridView.Rows[i].Cells[5].Value.ToString();
                    tran.CHQDate = Convert.ToDateTime(cGridView.Rows[i].Cells[4].Value);
                    tran.Comments = "";
                    tran.CardID = 0;
                    tran.ExpairDate = DateTime.Now;
                    tran.IsDeposited = gIsDeposited;
                    tran.IsRealized = gISRealized;
                    tran.IsActive = gIsActive;
                    tran.RefNo = tmpBillNo;
                    tran.TotalPaid = Convert.ToDouble(cGridView.Rows[i].Cells[6].Value);
                    tran.IsReturned = gIsReturned;
                    tran.OwnerID = gCustID;
                    tran.OwnerName = lblSupplier.Text;
                    tran.CashTendered = Convert.ToDecimal(cGridView.Rows[i].Cells[6].Value);
                    tran.Balance = 0;
                    tran.UserID = GlobalData.GUserID;
                    tran.UserName = GlobalData.GUsername;
                    tran.CompID = GlobalData.GCompID;
                    tran.ComputerName = GlobalData.GCompName;
                    tran.DelUserID = 0;
                    tran.DelUserName = "";
                    tran.DelCompID = 0;
                    tran.DelComputerName = "";
                    tran.BillID = 0;
                    tran.BillsFor = gBillIDs;
                    tran.Bank = cGridView.Rows[i].Cells[1].Value.ToString();
                    tran.Branch = cGridView.Rows[i].Cells[3].Value.ToString();
                    tran.CardCompany = "-";
                    tran.DateOn = DateTime.Now;
                    gMOPID = tran.SaveMOP_NEW(0);

                }

            }

            return gMOPID;
        }

        private long SaveCustPayBrief()
        {
            gBillNo = GlbData.getUniqueNumber("CUSTPAY", GlobalData.GCompID).ToString();

            tran.DateOn = DateTime.Now;
            tran.BillNo = gBillNo;
            tran.CustID = gCustID;
            tran.Add1 = gAdd1;
            tran.Add2 = gAdd2;
            tran.City = gCity;
            tran.Tp1 = gTp1;
            tran.Tp2 = gTp2;
            tran.Tp3 = gTp3;
            tran.DescriptionOf = "";
            tran.NetTotal = Convert.ToDouble(lblSelectedAmt.Text);
            tran.PerformedOn = DateTime.Now;
            tran.UserID = GlobalData.GUserID;
            tran.UserName = GlobalData.GUsername;
            tran.CompID = GlobalData.GCompID;
            tran.ComputerName = GlobalData.GCompName;
            tran.IsDeleted = "N";
            tran.DelUserID = 0;
            tran.DelUserName = "";
            tran.DelCompID = 0;
            tran.DelComputerName = "";
            tran.IsActive = "Y";
            tran.TranCode = gTranCode;
            tran.MopID = Convert.ToInt32(gMOPID);
            tran.GrandOutStanding = 0;
            tran.NameOf = lblSupplier.Text;

            gPaidID = tran.SaveCustPayBrief();

            return gPaidID;
        }
    }
}
