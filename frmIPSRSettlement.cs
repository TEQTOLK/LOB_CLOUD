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
    public partial class frmIPSRSettlement : Form
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
        private double gSelectedCCNAmount = 0;
        List<Tuple<int, string, string, double>> gCCNList = new List<Tuple<int, string, string, double>>();
        List<Tuple<int, string, string, double>> gSaleList = new List<Tuple<int, string, string, double>>();
        private string gTranCode = "CUS005";
        private string gTranName = "CUSTOMER RETURN NOTE SETTLEMENT";
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

        public frmIPSRSettlement()
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
                ClearLocal();
                return;
            }

            gSB.Clear();
            gSB.Append("SELECT Code FROM tblCustomer WHERE Code = '" + txtSuppCode.Text.Trim() + "' ");
            if (GlbData.AlreadyExist(gSB.ToString()))
            {
                fillSupplier();
                LoadOutstanding();
                LoadCCNBills();
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

        private void LoadCCNBills()
        {
            gSB.Clear();
            gSB.Append("SELECT DateOn, BillNo, NetTotal, TotalPaid, NetTotal - CNAmount - TotalPaid AS Payable, " +
                " PerformedOn, UserName, BillID " +
                " FROM  tblCCNBrief " +
                " WHERE (NetTotal- TotalPaid) > 0 AND CompID = " + GlobalData.GCompID + " " +
                " AND CustID = " + gCustID + " ORDER BY BillID ");
            dSet = GlbData.getDataSet(gSB.ToString(), "tblCCNBrief");
            DataView dView = new DataView(dSet.Tables[0]);
            dgvCCNBills.DataSource = dView;
            SettingGrid(dgvCCNBills);
            //getTotalReceivable();
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

        private void AddingGridCCN(int cBillID, string cDateOn, string cBillNo, double cNetTotal)
        {
            DataGridViewRow newRow = (DataGridViewRow)dgvSelectedCCN.RowTemplate.Clone();
            newRow.CreateCells(dgvSelectedBill);

            newRow.Cells[0].Value = cBillID.ToString();
            newRow.Cells[1].Value = Convert.ToDateTime(cDateOn).ToShortDateString();
            newRow.Cells[2].Value = cBillNo.ToString();
            newRow.Cells[3].Value = string.Format("{0:N}", cNetTotal);

            dgvSelectedCCN.Rows.Add(newRow);

            gSelectedCCNAmount = Convert.ToDouble(lblSelectedCCN.Text) + cNetTotal;
            lblSelectedCCN.Text = string.Format("{0:N}", gSelectedCCNAmount);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (IsRequiredNext())
            {
                //gMyList.Clear();
                //for (int i = 0; i < dgvSelectedBill.Rows.Count; i++)
                //{
                //    gMyList.Add(dgvSelectedBill.Rows[i].Cells[0].Value.ToString());
                //}
                //string[] myArray = gMyList.ToArray();
                //string gMyCode = string.Join(",", myArray);
                //LoadOutstandingSelected(gMyCode);
                pnlPay.Visible = false;
                btnBack.Visible = true;
                btnNew.Visible = false;
                btnCash.Visible = false;
                btnNew.Visible = false;
                btnSettlement.Visible = true;
                pnlSettleBills.Visible = true;
                btnBack2.Visible = false;
                //this.btnBack.Location = new System.Drawing.Point(540, 455);//540, 455
            }
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
            btnNext.Visible = true;
            btnBack.Visible = false;
            btnSettlement.Visible = false;
            pnlSettleBills.Visible = false;
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

        private Boolean CheckSameItemCCN(int cValue)
        {
            for (int i = 0; i < dgvSelectedCCN.Rows.Count; i++)
            {
                if (Convert.ToInt32(dgvSelectedCCN.Rows[i].Cells[0].Value) == cValue)
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

        private double CalcTotalAmountCCN()
        {
            double myTotalAmount = 0;
            for (int i = 0; i < dgvSelectedCCN.Rows.Count; i++)
            {
                myTotalAmount = myTotalAmount + Convert.ToDouble(dgvSelectedCCN.Rows[i].Cells[3].Value);
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
            if (dgvSettlement.Rows.Count == 0)
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
                    tmpKeyHolder = RoadToSave();

                    if (tmpKeyHolder == 0)
                    {
                        GlbData.SayMessage("Save Failed!!!", 0, "");
                    }
                    else
                    {
                        GlbData.SayMessage("Save Success!!!", 1, "");
                        //if (fConfirm.SayMessage("PR") == true)
                        //{
                        //    print.RoadToPrintReport(getCorrectQuery(), @"C:\POS\Bin\Debug\Rep\SUPReceipt.rpt");
                        //}
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

    
        private void ClearLocal()
        {
            lblSupplier.Text = "";
            lblPayable.Text = "0.00";
            lblSelectedAmount.Text = "0.00";
            lblSelectedAmt.Text = "0.00";
            dgvSettlement.DataSource = null;
            dgvOutstanding.DataSource = null;
            dgvSelectedBill.Rows.Clear();
            dgvCCNBills.DataSource = null;
            dgvSelectedCCN.Rows.Clear();
            lblSelectedCCN.Text = "0.00";
        }

        private long UpdateOutstanding()
        {
            long tmpID = 0;
            try
            {
                for (int i = 0; i < dgvSettlement.Rows.Count; i++)
                {
                    MySqlCommand cmd1 = new MySqlCommand("UPDATE tblSaleBrief SET TotalPaid = TotalPaid + " + Convert.ToDouble(dgvSettlement.Rows[i].Cells[7].Value) + " " +
                        " WHERE BillID = " + dgvSettlement.Rows[i].Cells[0].Value + "", GlobalData.GCon);
                    cmd1.ExecuteNonQuery();

                    MySqlCommand cmd2 = new MySqlCommand("UPDATE tblCCNBrief SET TotalPaid = TotalPaid + " + Convert.ToDouble(dgvSettlement.Rows[i].Cells[7].Value) + " " +
                        " WHERE BillID = " + dgvSettlement.Rows[i].Cells[4].Value + "", GlobalData.GCon);
                    cmd2.ExecuteNonQuery();
                    tmpID = 1;
                }
                return tmpID;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        private void SaveBillMatch()
        {
            for (int i = 0; i < dgvSettlement.Rows.Count; i++)
            {
                gSB.Clear();
                gSB.Append("INSERT INTO tblBillMatchCUS ( " +
                    " DateOn, SaleBillID, SaleBillNo, Outstanding, CCNBillID, CCNBillNo, CCNAmount, SettleAmount, " +
                    " UserID, UserName, CompID, CompName) " +
                    " VALUES ( " +
                    " NOW(), " + dgvSettlement.Rows[i].Cells[0].Value + ", '" + dgvSettlement.Rows[i].Cells[2].Value + "', " + Convert.ToDouble(dgvSettlement.Rows[i].Cells[3].Value) + ", " +
                    " " + dgvSettlement.Rows[i].Cells[4].Value + ", '" + dgvSettlement.Rows[i].Cells[5].Value + "', " + Convert.ToDouble(dgvSettlement.Rows[i].Cells[6].Value) + ", " +
                    " " + Convert.ToDouble(dgvSettlement.Rows[i].Cells[7].Value) + ", " +
                    " " + GlobalData.GUserID + ", '" + GlobalData.GUsername + "', " + GlobalData.GCompID + ", '" + GlobalData.GCompName + "') ");
                MySqlCommand cmd = new MySqlCommand(gSB.ToString(), GlobalData.GCon);
                cmd.ExecuteNonQuery();
            }
        }

        private long RoadToSave()
        {
            gBriefID = UpdateOutstanding();
            SaveBillMatch();

            return gBriefID;
        }


        private void dgvSelectedCCN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == dgvSelectedCCN.NewRowIndex || e.RowIndex < 0)
                return;

            if (e.ColumnIndex == dgvSelectedCCN.Columns["Column10"].Index)
            {
                dgvSelectedCCN.Rows.RemoveAt(e.RowIndex);
                lblSelectedCCN.Text = string.Format("{0:N}", CalcTotalAmountCCN());
            }
        }

        private void dgvCCNBills_DoubleClick(object sender, EventArgs e)
        {
            int gBillID = Convert.ToInt32(dgvCCNBills.Rows[dgvCCNBills.CurrentRow.Index].Cells[7].Value);
            string gBillNO = dgvCCNBills.Rows[dgvCCNBills.CurrentRow.Index].Cells[1].Value.ToString();
            double gNetTotal = Convert.ToDouble(dgvCCNBills.Rows[dgvCCNBills.CurrentRow.Index].Cells[4].Value);
            string gDateOn = dgvCCNBills.Rows[dgvCCNBills.CurrentRow.Index].Cells[0].Value.ToString();

            if (CheckSameItemCCN(gBillID))
            {
                AddingGridCCN(gBillID, gDateOn, gBillNO, gNetTotal);
            }
        }

        private Boolean IsRequiredNextCCN()
        {
            if (dgvSelectedCCN.Rows.Count == 0)
            {
                MessageBox.Show("Empty Grid.. Select Atleast One Bill(s)", "INVALID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void MatchBill()
        {
            try
            {
                double gBalAmount = 0;

                gSaleList.Clear();
                for (int i = 0; i < dgvSelectedBill.Rows.Count; i++)
                {
                    gSaleList.Add(Tuple.Create(Convert.ToInt32(dgvSelectedBill.Rows[i].Cells[0].Value.ToString()),
                        dgvSelectedBill.Rows[i].Cells[1].Value.ToString(),
                        dgvSelectedBill.Rows[i].Cells[2].Value.ToString(),
                        Convert.ToDouble(dgvSelectedBill.Rows[i].Cells[3].Value.ToString())));
                }

                gCCNList.Clear();
                for (int j = 0; j < dgvSelectedCCN.Rows.Count; j++)
                {
                    gCCNList.Add(Tuple.Create(Convert.ToInt32(dgvSelectedCCN.Rows[j].Cells[0].Value.ToString()),
                        dgvSelectedCCN.Rows[j].Cells[1].Value.ToString(),
                        dgvSelectedCCN.Rows[j].Cells[2].Value.ToString(),
                        Convert.ToDouble(dgvSelectedCCN.Rows[j].Cells[3].Value.ToString())));
                }

                dgvSettlement.Rows.Clear();
                for (int i = 0; i < dgvSelectedBill.Rows.Count; i++)
                {
                    if (dgvSettlement.Rows.Count == 0)
                    {
                        if (gSaleList[i].Item4 > gCCNList[i].Item4)
                        {
                            int k = 0;
                            gBalAmount = Convert.ToDouble(lblSelectedAmount.Text);
                            do
                            {
                                if (k != dgvSelectedCCN.Rows.Count)
                                {
                                    if (gBalAmount > gCCNList[k].Item4)
                                    {
                                        AddingGrid(gSaleList[i].Item1, gSaleList[i].Item2, gSaleList[i].Item3, gSaleList[i].Item4,
                                            gCCNList[k].Item1, gCCNList[k].Item3, gCCNList[k].Item4, gCCNList[k].Item4, 0);
                                        gBalAmount = gBalAmount - gCCNList[k].Item4;
                                        k++;
                                    }
                                    else
                                    {
                                        AddingGrid(gSaleList[i].Item1, gSaleList[i].Item2, gSaleList[i].Item3, gSaleList[i].Item4,
                                           gCCNList[k].Item1, gCCNList[k].Item3, gCCNList[k].Item4, gBalAmount, 0);
                                        gBalAmount = gBalAmount - gCCNList[k].Item4;
                                        k++;
                                        gBalAmount = 0;
                                    }
                                }
                                else
                                {
                                    gBalAmount = 0;
                                }

                            } while (gBalAmount != 0);
                        }
                        else
                        {
                            int k = 0;
                            gBalAmount = Convert.ToDouble(gCCNList[i].Item4);
                            do
                            {
                                if (k != dgvSelectedCCN.Rows.Count)
                                {
                                    if (gBalAmount > gSaleList[k].Item4)
                                    {
                                        AddingGrid(gSaleList[i].Item1, gSaleList[i].Item2, gSaleList[i].Item3, gSaleList[i].Item4,
                                            gCCNList[k].Item1, gCCNList[k].Item3, gCCNList[k].Item4, gSaleList[k].Item4, 0);
                                        gBalAmount = gBalAmount - gSaleList[k].Item4;
                                        k++;
                                    }
                                    else
                                    {
                                        AddingGrid(gSaleList[i].Item1, gSaleList[i].Item2, gSaleList[i].Item3, gSaleList[i].Item4,
                                           gCCNList[k].Item1, gCCNList[k].Item3, gCCNList[k].Item4, gBalAmount, 0);
                                        gBalAmount = gBalAmount - gSaleList[k].Item4;
                                        k++;
                                        gBalAmount = 0;
                                    }
                                }
                                else
                                {
                                    gBalAmount = 0;
                                }

                            } while (gBalAmount != 0);

                            //AddingGrid(gSaleList[i].Item1, gSaleList[i].Item2, gSaleList[i].Item3, gSaleList[i].Item4,
                            //   gCCNList[i].Item1, gCCNList[i].Item3, gCCNList[i].Item4, gSaleList[i].Item4, 0);
                            //gBalAmount = 0;
                        }
                    }
                    else
                    {
                        //gBalAmount = 0;
                        if (gSaleList[i].Item4 > gCCNList[i].Item4)
                        {
                            int k = 0;
                            //gBalAmount = Convert.ToDouble(lblSelectedAmount.Text);
                            do
                            {
                                if (k != dgvSelectedCCN.Rows.Count)
                                {
                                    if (gBalAmount > gCCNList[k].Item4)
                                    {
                                        AddingGrid(gSaleList[i].Item1, gSaleList[i].Item2, gSaleList[i].Item3, gSaleList[i].Item4,
                                            gCCNList[k].Item1, gCCNList[k].Item3, gCCNList[k].Item4, gCCNList[k].Item4, 0);
                                        gBalAmount = gBalAmount - gCCNList[k].Item4;
                                        k++;
                                    }
                                    else
                                    {
                                        AddingGrid(gSaleList[i].Item1, gSaleList[i].Item2, gSaleList[i].Item3, gSaleList[i].Item4,
                                           gCCNList[k].Item1, gCCNList[k].Item3, gCCNList[k].Item4, gBalAmount, 0);
                                        gBalAmount = gBalAmount - gCCNList[k].Item4;
                                        k++;
                                        gBalAmount = 0;
                                    }
                                }
                                else
                                {
                                    gBalAmount = 0;
                                }

                            } while (gBalAmount != 0);
                        }
                        else
                        {
                            AddingGrid(gSaleList[i].Item1, gSaleList[i].Item2, gSaleList[i].Item3, gSaleList[i].Item4,
                               gCCNList[i].Item1, gCCNList[i].Item3, gCCNList[i].Item4, gSaleList[i].Item4, 0);
                            gBalAmount = 0;
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Sorry.. Settlement Error");
            }
        }

        private void AddingGrid(int cBillID, string cDateOn, string cBillNo, double cCCNAmount, int cSaleBillID, string cSaleNBillNo, double cOutstanding, double cSettleAmount, double cBalance)
        {
            DataGridViewRow newRow = (DataGridViewRow)dgvSettlement.RowTemplate.Clone();
            newRow.CreateCells(dgvSettlement);

            newRow.Cells[0].Value = cBillID.ToString();
            newRow.Cells[1].Value = cDateOn.ToString();
            newRow.Cells[2].Value = cBillNo.ToString();
            newRow.Cells[3].Value = string.Format("{0:N}", cCCNAmount);
            newRow.Cells[4].Value = cSaleBillID.ToString();
            newRow.Cells[5].Value = cSaleNBillNo.ToString();
            newRow.Cells[6].Value = string.Format("{0:N}", cOutstanding);
            newRow.Cells[7].Value = string.Format("{0:N}", cSettleAmount);
            newRow.Cells[8].Value = string.Format("{0:N}", cBalance);

            dgvSettlement.Rows.Add(newRow);
        }

        private void btnSettlement_Click(object sender, EventArgs e)
        {
            if (IsRequiredNextCCN())
            {
                MatchBill();

                pnlPay.Visible = true;
                btnBack.Visible = true;
                btnNew.Visible = false;
                btnCash.Visible = true;
                btnNew.Visible = false;
                btnSettlement.Visible = false;
                pnlSettleBills.Visible = false;
                btnBack2.Visible = true;
            }
        }

        private void btnBack2_Click(object sender, EventArgs e)
        {
            pnlPay.Visible = false;
            btnBack.Visible = true;
            btnNew.Visible = false;
            btnCash.Visible = false;
            btnNew.Visible = false;
            btnSettlement.Visible = true;
            pnlSettleBills.Visible = true;
            btnBack2.Visible = false;
            //this.btnBack.Location = new System.Drawing.Point(540, 455);//540, 455
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearLocal();
            txtSuppCode.Clear();
            txtSuppCode.Focus();
        }
    }
}
