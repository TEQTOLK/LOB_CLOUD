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
    public partial class frmIPGRNCancel : Form
    {
        StringBuilder gSB = new StringBuilder();
        frmConfirmMessage fConfirm = new frmConfirmMessage();
        Transactions tran = new Transactions();
        GlobalData GlbData = new GlobalData();
        DataSet dSet = new DataSet();
        DataTable dataTable = new DataTable();

        public frmIPGRNCancel()
        {
            InitializeComponent();
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void DisplayMOP()
        {
            gSB.Clear();
            gSB.Append(" SELECT MO.MOPType, MO.NetAmount, MO.CHQNo, MO.Bank, MO.Branch, MO.CardCompany, MO.MOPID, BR.BillID AS SaleBillID " +
                " FROM tblMOP AS MO INNER JOIN " +
                " tblPurchaseBrief AS BR ON BR.BillID = MO.BillID " +
                " WHERE BR.BillNo =  '" + txtRefNo.Text.Trim() + "' ");
            dataTable = GlbData.getDataTable(gSB.ToString());
            dgvMOP.DataSource = dataTable;
            SettingGridMOP();
        }

        private void SettingGridMOP()
        {
            dgvMOP.Columns["MOPID"].Visible = false;
            dgvMOP.Columns["SaleBillID"].Visible = false;

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

            dgvMOP.Columns["NetAmount"].HeaderText = "Net Total";
            dgvMOP.Columns["NetAmount"].Width = 100;

            dgvMOP.Columns["NetAmount"].DefaultCellStyle.Format = "N2";
        }

        private void DisplayBills()
        {
            gSB.Clear();
            gSB.Append(" SELECT BR.DateOn, BR.BillNo, BR.NameOF, BR.City, BR.ManAmount " +
                " FROM tblMOP AS MO INNER JOIN " +
                " tblPurchaseBrief AS BR ON BR.BillID = MO.BillID " +
                " WHERE BR.BillNo =  '" + txtRefNo.Text.Trim() + "' ");
            dataTable = GlbData.getDataTable(gSB.ToString());
            dgvBills.DataSource = dataTable;
            SettingGridBills();
        }

        private void SettingGridBills()
        {
            dgvBills.Columns["DateOn"].HeaderText = "Date";
            dgvBills.Columns["DateOn"].Width = 100;
            dgvBills.Columns["BillNo"].HeaderText = "Bill No";
            dgvBills.Columns["BillNo"].Width = 100;
            dgvBills.Columns["NameOF"].HeaderText = "Customer";
            dgvBills.Columns["NameOF"].Width = 240;
            dgvBills.Columns["City"].HeaderText = "City";
            dgvBills.Columns["City"].Width = 200;
            dgvBills.Columns["ManAmount"].HeaderText = "Net Total";
            dgvBills.Columns["ManAmount"].Width = 100;

            dgvBills.Columns["ManAmount"].DefaultCellStyle.Format = "N2";
        }

        private void txtRefNo_Validating(object sender, CancelEventArgs e)
        {
            if (txtRefNo.Text == "")
            {
                dgvBills.DataSource = null;
                return;
            }
                
            gSB.Clear();
            gSB.Append(" SELECT * FROM tblPurchaseBrief " +
                " WHERE BillNo =  '" + txtRefNo.Text.Trim() + "' AND IsActive = 'Y' AND CompId = " + GlobalData.GCompID + " ");
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

            for (int i = 0; i < dgvMOP.Rows.Count; i++)
            {
                //MySqlCommand cmd4 = new MySqlCommand("INSERT INTO tblDELCustPayBrief ( " +
                //    " BillId, DateOn, BillNo, CustId, Add1, Add2, City, Tp1, Tp2, Tp3, DescriptionOf, NetTotal, " +
                //    " PerformedOn, UserId, UserName, CompId, CompName, isDeleted, DelUserId, DelUserName, DelCompId, " +
                //    " DelCompName, isActive, TranCode, MopId, GrandOutStanding, NameOf ) " +
                //    " SELECT BillId, DateOn, BillNo, CustId, Add1, Add2, City, Tp1, Tp2, Tp3, DescriptionOf, NetTotal, " +
                //    " PerformedOn, UserId, UserName, CompId, CompName, isDeleted, " + GlobalData.GUserID + " AS DelUserId, '" + GlobalData.GUsername + "' AS DelUserName, " + GlobalData.GCompID + " AS DelCompId, " +
                //    " '" + GlobalData.GCompName + "' AS DelCompName, isActive, TranCode, MopId, GrandOutStanding, NameOf " +
                //    " FRom tblCustPayBrief WHERE BillID = " + dgvMOP.Rows[i].Cells[8].Value + " ", GlobalData.GCon);
                //cmd4.ExecuteNonQuery();

                //MySqlCommand cmd1 = new MySqlCommand("DELETE FROM tblCustPayBrief WHERE BillID = " + dgvMOP.Rows[i].Cells[8].Value + " ", GlobalData.GCon);
                //cmd1.ExecuteNonQuery();

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

                MySqlCommand cmd6 = new MySqlCommand("INSERT INTO tblDelPurchaseBrief ( " +
                    " BillId, DateOn, BillNo, CustID, Add1, Add2, City, Tp1, Tp2, Tp3, DescriptionOf, GrossTotal, NetTotal, " +
                    " CNAmount, TotalPaid, ManAmount, NetAmount, CashTendered, Balance, PerformedOn, UserID, UserName, CompID, " +
                    " CompName, IsDeleted, DelUserID, DelUserName, DelCompID, DelCompName, IsActive, DisRate, DisAmount, VatRate, " +
                    " VatAmount, StockRoomID, SystemRefNo, DueDate, CSHPaidOn, CHQPaidOn, CCSPaidOn, CREPaidOn, MOP, " +
                    " TranCode, NameOf, PurchaseOrderNo ) " +
                    " SELECT BillId, DateOn, BillNo, CustID, Add1, Add2, City, Tp1, Tp2, Tp3, DescriptionOf, GrossTotal, NetTotal, " +
                    " CNAmount, TotalPaid, ManAmount, NetAmount, CashTendered, Balance, PerformedOn, UserID, UserName, CompID, " +
                    " CompName, IsDeleted, " + GlobalData.GUserID + " AS DelUserID, '" + GlobalData.GUsername + "' AS DelUserName, " + GlobalData.GCompID + " AS DelCompID, '" + GlobalData.GCompName + "' AS DelCompName, IsActive, DisRate, DisAmount, VatRate, " +
                    " VatAmount, StockRoomID, SystemRefNo, DueDate, CSHPaidOn, CHQPaidOn, CCSPaidOn, CREPaidOn, MOP, " +
                    " TranCode, NameOf, PurchaseOrderNo " +
                    " FROM tblPurchaseBrief WHERE BillID = " + dgvMOP.Rows[i].Cells[7].Value + " ", GlobalData.GCon);                 
                cmd6.ExecuteNonQuery();

                MySqlCommand cmd3 = new MySqlCommand("DELETE FROM tblPurchaseBrief WHERE BillID = " + dgvMOP.Rows[i].Cells[7].Value + " ", GlobalData.GCon);
                cmd3.ExecuteNonQuery();
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
            frmIPBillView f = new frmIPBillView();
            f.TABLE_NAME = "tblPurchaseBrief";
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
