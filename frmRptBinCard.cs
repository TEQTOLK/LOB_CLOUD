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
    public partial class frmRptBinCard : Form
    {
        private int gItemID = 0;
        private int gBranchID = 0;
        private int gStockRoomID = 0;
        StringBuilder gSB = new StringBuilder();
        GlobalData GlbData = new GlobalData();
        PrintReport print = new PrintReport();
        DataTable dataTable = new DataTable();

        private double gCSHTotal = 0;
        private double gCHQTotal = 0;
        private double gCCSTotal = 0;
        private double gCRETotal = 0;

        public frmRptBinCard()
        {
            InitializeComponent();
        }

        private void frmRptBinCard_Load(object sender, EventArgs e)
        {
            GlbData.FillComboBoxALL(cboStockroom, "tblStockRoom", " ORDER BY NameOf");
            FillBranch();
            cboDateRange.SelectedIndex = 1;
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

        public void FillBranch()
        {
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

        private void cboBranch_Validating(object sender, CancelEventArgs e)
        {
            if (cboBranch.Text == "")
                return;

            if (cboBranch.SelectedIndex == 0)
                gBranchID = 0;
            else
                gBranchID = Convert.ToInt32(cboBranch.SelectedValue);
        }

        private void cboStockroom_Validating(object sender, CancelEventArgs e)
        {
            if (cboStockroom.Text == "")
                return;

            if (cboStockroom.SelectedIndex == 0)
                gStockRoomID = 0;
            else
                gStockRoomID = Convert.ToInt32(cboStockroom.SelectedValue);
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

        private string getCorrectQuery()
        {
            return " SELECT BC.CompID, CO.NameOF, CO.Add1 + ' - ' + CO.City AS Name, BC.StockRoomID, SR.NameOF AS Code, " +
                " SUM(BC.QtyIn) AS Qty, SUM(BC.QtyOut) AS UnitPrice, SUM(BC.FreeIn) AS Discount, SUM(BC.FreeOut) AS TotalAmount, BC.HeaderName AS CUName, BC.PerformedOn AS E1IssuedDate, " +
                " BC.UserName AS CUAdd1, SUM(BC.TotalAmount), BC.DateOn AS BRDateOn " +
                " FROM tblBinCard AS BC INNER JOIN " +
                " tblItem AS IT ON BC.ItemID = IT.CustID INNER JOIN " +
                " tblStockRoom AS SR ON BC.StockRoomID = SR.CustID INNER JOIN " +
                " tblCompany AS CO ON BC.CompID = CO.CustID ";
        }

        private double getOpenSTK()
        {
            string tmpVal = "";
            double openSTK = 0;

            string tmpHolder= " SELECT BC.CompID, BC.StockRoomID, BC.ItemID, " +
                " (SUM(BC.QtyIn) + SUM(BC.FreeIn) - SUM(BC.QtyOut) - SUM(BC.FreeOut)) AS OpenStk " +
                " FROM tblBinCard AS BC INNER JOIN " +
                " tblItem AS IT ON BC.ItemID = IT.CustID INNER JOIN " +
                " tblStockRoom AS SR ON BC.StockRoomID = SR.CustID INNER JOIN " +
                " tblCompany AS CO ON BC.CompID = CO.CustID " +
                " WHERE BC.DateOn < CONVERT(date, '" + dtpTo.Text + "') AND BC.ItemID = " + gItemID + " " +
                " GROUP BY BC.CompID, BC.StockRoomID, BC.ItemID ";
            tmpVal = GlbData.GetValue(tmpHolder, "OpenStk");

            if (string.IsNullOrEmpty(tmpVal))
                openSTK = 0;
            else
                openSTK = Convert.ToDouble(tmpVal);

            return openSTK;
        }

        private double getCloseSTK()
        {
            string tmpVal = "";
            double closeSTK = 0;

            string tmpHolder = " SELECT BC.CompID, BC.StockRoomID, BC.ItemID, " +
                " (SUM(BC.QtyIn) + SUM(BC.FreeIn) - SUM(BC.QtyOut) - SUM(BC.FreeOut)) AS OpenStk " +
                " FROM tblBinCard AS BC INNER JOIN " +
                " tblItem AS IT ON BC.ItemID = IT.CustID INNER JOIN " +
                " tblStockRoom AS SR ON BC.StockRoomID = SR.CustID INNER JOIN " +
                " tblCompany AS CO ON BC.CompID = CO.CustID " +
                " WHERE BC.DateOn <= CONVERT(date, '" + dtpFrom.Text + "') AND BC.ItemID = " + gItemID + " " +
                " GROUP BY BC.CompID, BC.StockRoomID, BC.ItemID ";
            tmpVal = GlbData.GetValue(tmpHolder, "OpenStk");

            if (string.IsNullOrEmpty(tmpVal))
                closeSTK = 0;
            else
                closeSTK = Convert.ToDouble(tmpVal);

            return closeSTK;
        }

        private string getDateRange()
        {
            return " WHERE BC.DateOn BETWEEN CONVERT(date, '" + dtpFrom.Text + "') AND CONVERT(date, '" + dtpTo.Text + "')";
        }

        private string getItemID()
        {
            if (txtCusCode.Text.Trim() == "")
                return " ";
            else
                return " AND BC.ItemID = " + gItemID + " ";
        }

        private string getBranchID()
        {
            if (cboBranch.Text.Trim() == "")
                return " ";

            if (cboBranch.SelectedIndex == 0)
                return " ";
            else
                return "  AND BC.CompID = " + gBranchID + " ";
        }

        private string getStockroomID()
        {
            if (cboStockroom.Text.Trim() == "")
                return " ";

            if (cboStockroom.SelectedIndex == 0)
                return " ";
            else
                return " AND SR.CustID = " + gStockRoomID + "";

        }

        private string groupBy()
        {
            return " GROUP BY BC.CompID, CO.NameOF, CO.Add1, CO.City, BC.StockRoomID, SR.NameOF, BC.HeaderName, BC.PerformedOn, BC.UserName, BC.DateOn ";
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            btnShow.Enabled = false;

            string tmpQuery = getCorrectQuery() + getDateRange() + getItemID() + getBranchID() + getStockroomID() + groupBy();
            gCSHTotal = getOpenSTK();
            gCHQTotal = getCloseSTK();
            print.RoadToPrintReport(tmpQuery, @"C:\LOB\Bin\Debug\Rep\BinCard.rpt", rptView, "P", gCSHTotal, gCHQTotal, gCCSTotal, gCRETotal);

            btnShow.Enabled = true;
        }
    }
}
