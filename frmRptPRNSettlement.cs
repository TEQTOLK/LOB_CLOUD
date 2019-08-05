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
    public partial class frmRptPRNSettlement : Form
    {
        private int gCustID = 0;
        StringBuilder gSB = new StringBuilder();
        GlobalData GlbData = new GlobalData();
        PrintReport print = new PrintReport();
        
        private double gCSHTotal = 0;
        private double gCHQTotal = 0;
        private double gCCSTotal = 0;
        private double gCRETotal = 0;
        private int gAreaID = 0;
        private int gBranchID = 0;

        public frmRptPRNSettlement()
        {
            InitializeComponent();
        }

        private void frmRptSales_Load(object sender, EventArgs e)
        {
            ClearLocal();
            FillBranch();
        }

        private void ClearLocal()
        {
            cboBasedOn.SelectedIndex = 0;
            cboDateRange.SelectedIndex = 1;
        }

        public void FillBranch()
        {
            DataTable dataTable = new DataTable();
            try
            {
                string strQuery = " SELECT CustID, ADD1 + ' - ' + CITY AS NameOf FROM tblCompany ORDER BY NameOF";
                dataTable = GlbData.getDataTable(strQuery);

                cboBranch.Items.Clear();
                DataRow row = dataTable.NewRow();
                row["NameOF"] = "ALL";
                dataTable.Rows.InsertAt(row, 0);

                cboBranch.DataSource = dataTable;
                cboBranch.ValueMember = "CustID";
                cboBranch.DisplayMember = "NameOF";

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                dataTable = null;
            }
        }

        private void cboBasedOn_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboBasedOn.SelectedIndex)
            {
                case 0:
                    pnlAllCustomer.Visible = true;
                    pnlPartiCus.Visible = false;
                    groupBox3.Enabled = true;
                    txtCusCode.Clear();
                    break;
                case 1:
                    pnlAllCustomer.Visible = false;
                    pnlPartiCus.Visible = true;
                    groupBox3.Enabled = false;
                    break;
                default:
                    break;
            }
        }

        private void btnFCus_Click(object sender, EventArgs e)
        {
            frmIPBillView f = new frmIPBillView();
            f.TABLE_NAME = "tblSaleBrief";
            f.ShowDialog();
            txtCusCode.Text = f.BILLNO;
            txtCusCode.Focus();
        }

        private void txtCusCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                btnFCus.PerformClick();
        }

        private void txtCusCode_Validating(object sender, CancelEventArgs e)
        {
            if (txtCusCode.Text == "") return;

            gSB.Clear();
            gSB.Append("SELECT * FROM tblSaleBrief WHERE BillNo = '" + txtCusCode.Text.Trim() + "' ");
            if (GlbData.AlreadyExist(gSB.ToString()))
            {
                return;
            }
            else
            {
                MessageBox.Show("Sorry.. This Invoice No does not exist", "INVALID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCusCode.Focus();
                return;
            }
        }

        
        private string GetQuery()
        {
            return "SELECT  BR.BillID AS Qty, BR.DateOn AS BRDateOn, BR.BillNo AS BRBillNo, BR.NameOf AS CUName, BM.Outstanding AS TotalAmount, BM.PRNBillNo AS CUCode, " +
                " BM.PRNAmount AS Discount, BM.SettleAmount AS BRPaidAmount, BM.UserName AS CUCity, BM.PerformedOn AS E1IssuedDate, " +
                " BR.CompID AS UnitPrice, CO.Add1 + ' - ' + CO.City  AS Name " +
                " FROM tblBillMatchSUP AS BM INNER JOIN " +
                " tblPurchaseBrief AS BR ON BM.PURBillID = BR.BillId INNER JOIN " +
                " tblCompany AS CO ON CO.CustID = BR.CompID " +
                " WHERE ";
        }

        private string getBranchID()
        {
            if (cboBranch.Text.Trim() == "")
                return " ";

            if (cboBranch.SelectedIndex == 0)
                return " ";
            else
                return "  AND BR.CompID = " + gBranchID + " ";


        }

        private string getInvoiceNo()
        {
            if (txtCusCode.Text == "")
                return " ";
            else
                return " AND BR.BillNo = '" + txtCusCode.Text.Trim() + "' ";
        }

        private string getInvoiceNo2()
        {
            if (txtCusCode.Text == "")
                return " ";
            else
                return " BR.BillNo = '" + txtCusCode.Text.Trim() + "' ";
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            btnShow.Enabled = false;
            string tmpQuery = "";

            switch (cboBasedOn.SelectedIndex)
            {
                case 0:
                    tmpQuery = GetQuery() + getDateRange() + getBranchID() + getInvoiceNo();
                    break;
                case 1:
                    tmpQuery = GetQuery() + getInvoiceNo2();
                    break;
                default:
                    break;
            }
            print.RoadToPrintReport(tmpQuery, @"C:\LOB\Bin\Debug\Rep\PRNSettlement.rpt", rptView, "P", gCSHTotal, gCHQTotal, gCCSTotal, gCRETotal);
            btnShow.Enabled = true;
        }

        private string getDateRange()
        {
            return " BR.DateOn BETWEEN CONVERT(date, '" + dtpFrom.Text + "') AND CONVERT(date, '" + dtpTo.Text + "')";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtpFrom.Text = Convert.ToDateTime(GlbData.getFirstDate(cboDateRange)).ToShortDateString();
            dtpTo.Text = Convert.ToDateTime(GlbData.getLastDate(cboDateRange, Convert.ToDateTime(dtpFrom.Text))).ToShortDateString();
        }

        private void cboDateRange_Validating(object sender, CancelEventArgs e)
        {
            dtpFrom.Text = Convert.ToDateTime(GlbData.getFirstDate(cboDateRange)).ToShortDateString();
            dtpTo.Text = Convert.ToDateTime(GlbData.getLastDate(cboDateRange, Convert.ToDateTime(dtpFrom.Text))).ToShortDateString();
        }

        private void cboBranch_Validating(object sender, CancelEventArgs e)
        {
            if (cboBranch.Text == "")
                return;

            if (cboBranch.SelectedIndex == 0)
                gBranchID = 0;
            else
                gBranchID = Convert.ToInt32(cboBranch.SelectedValue);
        }
    }
}
