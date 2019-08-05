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
    public partial class frmRptGrossProfit : Form
    {
        private int gItemID = 0;
        StringBuilder gSB = new StringBuilder();
        GlobalData GlbData = new GlobalData();
        PrintReport print = new PrintReport();
        DataTable dataTable = new DataTable();
        MySqlDataAdapter sqlAdapter = new MySqlDataAdapter();

        private double gCSHTotal = 0;
        private double gCHQTotal = 0;
        private double gCCSTotal = 0;
        private double gCRETotal = 0;
        private int gBranchID = 0;

        public frmRptGrossProfit()
        {
            InitializeComponent();
        }

        public void FillBranch()
        {
            try
            {
                string strQuery = " SELECT CustID, ADD1 + ' - ' + CITY AS NameOf FROM tblCompany ORDER BY NameOF";
                MySqlCommand MySqlCommand = new MySqlCommand();
                {
                    MySqlCommand.Connection = GlobalData.GCon;
                    MySqlCommand.CommandType = CommandType.Text;
                    MySqlCommand.CommandText = strQuery;
                }

                sqlAdapter = new MySqlDataAdapter();
                dataTable = new DataTable();
                {
                    sqlAdapter.SelectCommand = MySqlCommand;
                    sqlAdapter.Fill(dataTable);
                }

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

        private void frmRptGrossProfit_Load(object sender, EventArgs e)
        {
            FillBranch();
            cboBasedOn.SelectedIndex = 0;
            cboDateRange.SelectedIndex = 1;
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

        private void cboBranch_Validating(object sender, CancelEventArgs e)
        {
            if (cboBranch.Text == "")
                return;

            if (cboBranch.SelectedIndex == 0)
                gBranchID = 0;
            else
                gBranchID = Convert.ToInt32(cboBranch.SelectedValue);
        }

        private void btnFCus_Click(object sender, EventArgs e)
        {
            frmIPSearch f = new frmIPSearch();
            f.ShowDialog();

            if (f.gOkCancel == true)
            {
                txtCusCode.Text = f.CODE;
                txtCusCode.Focus();
            }
        }

        private void txtCusCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down) btnFCus.PerformClick();
        }

        private void txtCusCode_Validating(object sender, CancelEventArgs e)
        {
            if (txtCusCode.Text == "")
                return;

            gSB.Clear();
            gSB.Append("SELECT * FROM tblItem WHERE Code = '" + txtCusCode.Text.Trim() + "' AND IsActive = 'Y'");
            if (GlbData.AlreadyExist(gSB.ToString()))
            {
                gItemID = Convert.ToInt32(GlbData.GetValue(gSB.ToString(), "CustID"));
                lblCustomer.Text = GlbData.GetValue(gSB.ToString(), "NameOF");
            }
            else
            {
                MessageBox.Show("Sorry.. This Product does not Exist", "INVALID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCusCode.Focus();
                return;
            }
        }

        private void cboDateRange_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtpFrom.Text = Convert.ToDateTime(GlbData.getFirstDate(cboDateRange)).ToShortDateString();
            dtpTo.Text = Convert.ToDateTime(GlbData.getLastDate(cboDateRange, Convert.ToDateTime(dtpFrom.Text))).ToShortDateString();
        }

        private void cboDateRange_Validating(object sender, CancelEventArgs e)
        {
            dtpFrom.Text = Convert.ToDateTime(GlbData.getFirstDate(cboDateRange)).ToShortDateString();
            dtpTo.Text = Convert.ToDateTime(GlbData.getLastDate(cboDateRange, Convert.ToDateTime(dtpFrom.Text))).ToShortDateString();
        }

        private string getDateRange()
        {
            return " WHERE BR.DateOn BETWEEN CONVERT(date, '" + dtpFrom.Text + "') AND CONVERT(date, '" + dtpTo.Text + "')";
        }

        private string getItemID()
        {
            if (txtCusCode.Text.Trim() == "")
                return " ";
            else
                return " AND DT.ItemID = " + gItemID + " ";
        }

        private string getCorrectQuery()
        {
            return " SELECT  IT.Code AS CUCode, IT.NameOF AS CUName, SUM(DE.TotalAmount) AS UnitPrice, SUM(DE.CostOfSale) AS TotalAmount, " +
                " BR.CompID AS Discount, CO.Add1 + ' - ' + CO.City AS E1NIC " +
                " FROM tblItem AS IT RIGHT OUTER JOIN " +
                " tblSaleDetail AS DE ON IT.CustID = DE.ItemId INNER JOIN " +
                " tblSaleBrief AS BR ON DE.BriefID = BR.BillId INNER JOIN " +
                " tblCompany AS CO ON BR.CompID = CO.CustID ";
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            btnShow.Enabled = false;
            string tmpQuery = "";

            tmpQuery = getCorrectQuery() + getDateRange() + getItemID() + " GROUP BY IT.Code, IT.NameOF, BR.CompID, CO.Add1, CO.City" ;
            print.RoadToPrintReport(tmpQuery, @"C:\LOB\Bin\Debug\Rep\GrossProfit.rpt", rptView, "P", gCSHTotal, gCHQTotal, gCCSTotal, gCRETotal);

            btnShow.Enabled = true;
        }
    }
}
