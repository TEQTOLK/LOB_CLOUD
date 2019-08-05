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
    public partial class frmIPCUSPAYCancel : Form
    {
        StringBuilder gSB = new StringBuilder();
        frmConfirmMessage fConfirm = new frmConfirmMessage();
        Transactions tran = new Transactions();
        GlobalData GlbData = new GlobalData();
        DataSet dSet = new DataSet();
        DataTable dataTable = new DataTable();

        public frmIPCUSPAYCancel()
        {
            InitializeComponent();
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void DisplayMOP()
        {
            gSB.Clear();
            gSB.Append(" SELECT MO.MOPType, MO.CashTendered, MO.CHQNo, MO.Bank, MO.Branch, MO.CardCompany, MO.MOPID, CP.BillID " +
                " FROM tblMOP AS MO INNER JOIN " +
                " tblCustPayBrief AS CP ON MO.MopID = CP.MopId " +
                " WHERE CP.BillNo =  '" + txtRefNo.Text.Trim() + "' ");
            dataTable = GlbData.getDataTable(gSB.ToString());
            dgvMOP.DataSource = dataTable;
            SettingGridMOP();
        }

        private void SettingGridMOP()
        {
            dgvMOP.Columns["MOPID"].Visible = false;
            dgvMOP.Columns["BillID"].Visible = false;

            dgvMOP.Columns["MOPType"].HeaderText = "MOP Type";
            dgvMOP.Columns["MOPType"].Width = 100;
            dgvMOP.Columns["CHQNo"].HeaderText = "CHQ No";
            dgvMOP.Columns["CHQNo"].Width = 150;
            dgvMOP.Columns["Bank"].HeaderText = "Bank";
            dgvMOP.Columns["Bank"].Width = 100;
            dgvMOP.Columns["Branch"].HeaderText = "Branch";
            dgvMOP.Columns["Branch"].Width = 100;
            dgvMOP.Columns["CardCompany"].HeaderText = "Card Company";
            dgvMOP.Columns["CardCompany"].Width = 100;

            dgvMOP.Columns["CashTendered"].HeaderText = "Net Total";
            dgvMOP.Columns["CashTendered"].Width = 100;

            dgvMOP.Columns["CashTendered"].DefaultCellStyle.Format = "N2";
            dgvMOP.Columns["CashTendered"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void DisplayBills()
        {
            gSB.Clear();
            gSB.Append(" SELECT BR.DateOn, BR.BillNo, BR.NameOF, BR.City, CD.Amount AS CashTendered, BR.BillID " +
                " FROM tblMOP AS MO INNER JOIN " +
                " tblCustPayBrief AS CP ON MO.MopID = CP.MopId INNER JOIN " +
                " tblCustPayDetail AS CD ON CD.PaidId = CP.BillId INNER JOIN " +
                " tblSaleBrief AS BR ON BR.BillId = CD.SaleBillId " +
                " WHERE CP.BillNo =  '" + txtRefNo.Text.Trim() + "' ");
            dataTable = GlbData.getDataTable(gSB.ToString());
            dgvBills.DataSource = dataTable;
            SettingGridBills();
        }

        private void SettingGridBills()
        {
            dgvBills.Columns["BillID"].Visible = false;

            dgvBills.Columns["DateOn"].HeaderText = "Date";
            dgvBills.Columns["DateOn"].Width = 100;
            dgvBills.Columns["BillNo"].HeaderText = "Bill No";
            dgvBills.Columns["BillNo"].Width = 100;
            dgvBills.Columns["NameOF"].HeaderText = "Customer";
            dgvBills.Columns["NameOF"].Width = 240;
            dgvBills.Columns["City"].HeaderText = "City";
            dgvBills.Columns["City"].Width = 200;
            dgvBills.Columns["CashTendered"].HeaderText = "Net Total";
            dgvBills.Columns["CashTendered"].Width = 100;

            dgvBills.Columns["CashTendered"].DefaultCellStyle.Format = "N2";
            dgvBills.Columns["CashTendered"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void txtRefNo_Validating(object sender, CancelEventArgs e)
        {
            if (txtRefNo.Text == "")
            {
                dgvBills.DataSource = null;
                return;
            }
                
            gSB.Clear();
            gSB.Append(" SELECT * FROM tblCustPayBrief " +
                " WHERE BillNo =  '" + txtRefNo.Text.Trim() + "' AND CompId = " + GlobalData.GCompID + " AND TranCode = 'CUS004' ");
            if(!GlbData.AlreadyExist(gSB.ToString()))
            {
                MessageBox.Show("Sorry... This Receipt No Does not Exist", "INVALID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRefNo.Focus();
                return;
            }
            else
            {
                DisplayBills();
                DisplayMOP();
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private Boolean IsRequired()
        {
            if (dgvBills.Rows.Count == 0)
            {
                MessageBox.Show("Empty Bills.", "INVALID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (dgvMOP.Rows.Count == 0)
            {
                MessageBox.Show("Empty MOP Informtion.", "INVALID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private long RoadToSave()
        {
            long tmpID = 0;

            for (int k = 0; k < dgvBills.Rows.Count; k++)
            {
                MySqlCommand cmd = new MySqlCommand("UPDATE tblSaleBrief SET TotalPaid = TotalPaid - " + Convert.ToDouble(dgvBills.Rows[k].Cells[4].Value) + ", " +
                    " DelUserID = " + GlobalData.GUserID + ", DelUserName = '" + GlobalData.GUsername + "', " +
                    " DelCompId = " + GlobalData.GCompID + ", DelCompName = '" + GlobalData.GCompName + "' " +
                    " WHERE BillID = " + dgvBills.Rows[k].Cells[5].Value + " ", GlobalData.GCon);
                cmd.ExecuteNonQuery();
            }

            for (int i = 0; i < dgvMOP.Rows.Count; i++)
            {
                MySqlCommand cmd4 = new MySqlCommand("INSERT INTO tblDELCustPayBrief ( " +
                    " BillId, DateOn, BillNo, CustId, Add1, Add2, City, Tp1, Tp2, Tp3, DescriptionOf, NetTotal, " +
                    " PerformedOn, UserId, UserName, CompId, CompName, isDeleted, DelUserId, DelUserName, DelCompId, " +
                    " DelCompName, isActive, TranCode, MopId, GrandOutStanding, NameOf ) " +
                    " SELECT BillId, DateOn, BillNo, CustId, Add1, Add2, City, Tp1, Tp2, Tp3, DescriptionOf, NetTotal, " +
                    " PerformedOn, UserId, UserName, CompId, CompName, isDeleted, " + GlobalData.GUserID + " AS DelUserId, '" + GlobalData.GUsername + "' AS DelUserName, " + GlobalData.GCompID + " AS DelCompId, " +
                    " '" + GlobalData.GCompName + "' AS DelCompName, isActive, TranCode, MopId, GrandOutStanding, NameOf " +
                    " FRom tblCustPayBrief WHERE BillID = " + dgvMOP.Rows[i].Cells[7].Value + " ", GlobalData.GCon);
                cmd4.ExecuteNonQuery();

                MySqlCommand cmd1 = new MySqlCommand("DELETE FROM tblCustPayBrief WHERE BillID = " + dgvMOP.Rows[i].Cells[7].Value + " ", GlobalData.GCon);
                cmd1.ExecuteNonQuery();

                MySqlCommand cmd5 = new MySqlCommand("INSERT INTO tblDelMOP ( " +
                    " MopID, RefNo, BillID, MopType, NetAmount, BankID, CHQNo, CHQDate, Comments, CardID, ExpairDate, " +
                    " IsDeposited, IsRealized, PerformedOn, IsActive, TotalPaid, IsReturned, DepositedOn, DepositeBy, RealizedOn, " +
                    " RealizedBy, OwnerID, OwnerName, CashTendered, Balance, UserID, UserName, CompID, CompName, DelUserID, " +
                    " DelUserName, DelCompID, DelCompName, BranchId, Billsfor, Bank, Branch, Cardcompany, DateOn ) " +
                    " SELECT MopID, RefNo, BillID, MopType, NetAmount, BankID, CHQNo, CHQDate, Comments, CardID, ExpairDate, " +
                    " IsDeposited, IsRealized, PerformedOn, IsActive, TotalPaid, IsReturned, DepositedOn, DepositeBy, RealizedOn, " +
                    " RealizedBy, OwnerID, OwnerName, CashTendered, Balance, UserID, UserName, CompID, CompName, " + GlobalData.GUserID + " AS DelUserID, " +
                    " '" + GlobalData.GUsername + "' AS DelUserName, " + GlobalData.GCompID + " AS DelCompID, '" + GlobalData.GCompName + "' AS DelCompName, BranchId, Billsfor, Bank, Branch, Cardcompany, DateOn " +
                    " FROM tblMOP WHERE MOPID = " + dgvMOP.Rows[i].Cells[6].Value + " ", GlobalData.GCon);
                cmd5.ExecuteNonQuery();

                MySqlCommand cmd2 = new MySqlCommand("DELETE FROM tblMOP WHERE MOPID = " + dgvMOP.Rows[i].Cells[6].Value + " ", GlobalData.GCon);
                cmd2.ExecuteNonQuery();
            }

            return tmpID = 1;
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
                        dgvMOP.DataSource = null;
                        dgvBills.DataSource = null;
                        txtRefNo.Text = "";
                        txtRefNo.Focus();
                    }
                }
            }
        }

        private void btnFInvoice_Click(object sender, EventArgs e)
        {
            frmIPRcptView f = new frmIPRcptView();
            f.TRAN_CODE = "CUS004";
            f.DEALER_TABLE = "tblCustomer";
            f.ShowDialog();
            txtRefNo.Text = f.BILLNO;
            txtRefNo.Focus();
        }

        private void txtRefNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                btnFInvoice.PerformClick();
        }
    }
}
