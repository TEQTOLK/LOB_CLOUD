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
    public partial class frmRptNetSales : Form
    {
        private int gCustID = 0;
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

        public frmRptNetSales()
        {
            InitializeComponent();
        }

        private void frmRptSales_Load(object sender, EventArgs e)
        {
            ClearLocal();
            FillBranch();
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

        private void ClearLocal()
        {
            cboBasedOn.SelectedIndex = 0;
            cboMOP.SelectedIndex = 0;
            cboDateRange.SelectedIndex = 1;
        }

        private void cboBasedOn_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboBasedOn.SelectedIndex)
            {
                case 0:
                    pnlAllCustomer.Visible = true;
                    pnlPartiCus.Visible = false;
                    pnlInvoice.Visible = false;
                    pnlOther.Visible = true;
                    break;
                case 1:
                    pnlAllCustomer.Visible = false;
                    pnlPartiCus.Visible = true;
                    pnlInvoice.Visible = false;
                    pnlOther.Visible = true;
                    break;
                case 2:
                    pnlAllCustomer.Visible = false;
                    pnlPartiCus.Visible = false;
                    pnlInvoice.Visible = true;
                    pnlOther.Visible = false;
                    break;
                default:
                    break;
            }
        }

        private void btnFCus_Click(object sender, EventArgs e)
        {
            frmIPSearchDealer f = new frmIPSearchDealer();
            f.TABLE_NAME = "tblCustomer";
            f.ShowDialog();
            if (f.gOkCancel == true)
            {
                txtCusCode.Text = f.CODE;
                gCustID = f.CUSTID;
                lblCustomer.Text = f.NAME;
                txtCusCode.Focus();
            }
        }

        private void txtCusCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                btnFCus.PerformClick();
        }

        private void txtCusCode_Validating(object sender, CancelEventArgs e)
        {
            if (txtCusCode.Text == "")
            {
                lblCustomer.Text = "";
                return;
            }

            gSB.Clear();
            gSB.Append("SELECT Code FROM tblCustomer WHERE Code = '" + txtCusCode.Text.Trim() + "' ");
            if (!GlbData.AlreadyExist(gSB.ToString()))
            {
                MessageBox.Show("Sorry.. This Customer does not exist", "INVALID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCusCode.Focus();
                return;
            }
        }

        
        private string GetQuery()
        {
            return "SELECT BR.DateOn AS BRDateOn, BR.BillNo AS BRBillNo, CU.Code AS CUCode, BR.CustID AS Qty, " +
                " CU.NameOF AS CUName, MO.MopType AS MOP, BR.GrossTotal AS BRPaidAmount, MO.CHQNo AS MOChqNo, CONVERT( VARCHAR(10), MO.CHQDate, 105) AS CUDueOn, " +
                " MO.Bank AS CUDateOn, MO.CardCompany AS MOCard, CU.Tp1 AS E1Relationship, BR.CompID AS Discount, CM.Add1 + ' - ' + CM.City AS E1NIC, " +
                " BR.DisAmount AS UnitPrice, BR.CNAmount AS TotalAmount  " +
                " FROM tblSaleBrief AS BR INNER JOIN " +
                " tblCustomer AS CU ON BR.CustID = CU.CustID INNER JOIN " +
                " tblMOP AS MO ON BR.BillId = MO.BillID INNER JOIN " +
                " tblCompany AS CM ON CM.CustID = BR.CompID " +
                " WHERE BR.IsActive = 'Y' ";
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

        private void btnShow_Click(object sender, EventArgs e)
        {
            btnShow.Enabled = false;
            string tmpQuery = "";
            //getAmount();
            if (cboBasedOn.SelectedIndex == 2)
            {
                tmpQuery = getPaticularInvoice() ;
                gCSHTotal = Convert.ToDouble(GlbData.GetValue("SELECT DisAmount FROM tblSaleBrief WHERE BillNo = '" + txtInvoice.Text.Trim() + "'", "DisAmount"));
                print.RoadToPrintReport(tmpQuery, @"C:\LOB\Bin\Debug\Rep\Invoice.rpt", rptView, "P", gCSHTotal, gCHQTotal, gCCSTotal, gCRETotal);
            }
               
            else
            {
                tmpQuery = GetQuery() + getDateRange() + getCustomerID() + getMOP() ;
                print.RoadToPrintReport(tmpQuery, @"C:\LOB\Bin\Debug\Rep\NetSale.rpt", rptView, "P", gCSHTotal, gCHQTotal, gCCSTotal, gCRETotal);
            }
                

           
            btnShow.Enabled = true;
        }

        private void cboMOP_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private string getMOP()
        {
            string tmpQuery = "";

            switch (cboMOP.SelectedIndex)
            {
                case 0:
                    tmpQuery = " ";
                    break;
                case 1:
                    tmpQuery = " AND MO.MOPType = 'CSH'";
                    break;
                case 2:
                    tmpQuery = " AND MO.MOPType = 'CHQ'";
                    break;
                case 3:
                    tmpQuery = " AND MO.MOPType = 'CCS'";
                    break;
                case 4:
                    tmpQuery = " AND MO.MOPType = 'CRE' OR MO.MOPType = 'CREI' ";
                    break;
                default:
                    break;
            }

            return tmpQuery;
        }

        private void getAmount()
        {
            string tmpHolder = "";
            string tmpAmount = "";

            switch (cboMOP.SelectedIndex)
            {
                case 0:
                    tmpHolder = "SELECT SUM(BR.ManAmount) AS Amount " +
                        " FROM tblSaleBrief AS BR INNER JOIN " +
                        " tblCustomer AS CU ON BR.CustID = CU.CustID INNER JOIN " +
                        " tblMOP AS MO ON BR.BillId = MO.BillID " +
                        " WHERE MO.MOPType = 'CSH' AND BR.IsActive = 'Y' " + getDateRange() + getCustomerID();
                    tmpAmount = GlbData.GetValue(tmpHolder, "Amount");
                    gCSHTotal = string.IsNullOrEmpty(tmpAmount) ? 0 : Convert.ToDouble(tmpAmount);

                    tmpHolder = "SELECT SUM(BR.ManAmount) AS Amount " +
                                           " FROM tblSaleBrief AS BR INNER JOIN " +
                                           " tblCustomer AS CU ON BR.CustID = CU.CustID INNER JOIN " +
                                           " tblMOP AS MO ON BR.BillId = MO.BillID " +
                                           " WHERE MO.MOPType = 'CHQ' AND BR.IsActive = 'Y' " + getDateRange() + getCustomerID();
                    tmpAmount = GlbData.GetValue(tmpHolder, "Amount");
                    gCHQTotal = string.IsNullOrEmpty(tmpAmount) ? 0 : Convert.ToDouble(tmpAmount);

                    tmpHolder = "SELECT SUM(BR.ManAmount) AS Amount " +
                                          " FROM tblSaleBrief AS BR INNER JOIN " +
                                          " tblCustomer AS CU ON BR.CustID = CU.CustID INNER JOIN " +
                                          " tblMOP AS MO ON BR.BillId = MO.BillID " +
                                          " WHERE MO.MOPType = 'CCS' AND BR.IsActive = 'Y' " + getDateRange() + getCustomerID();
                    tmpAmount = GlbData.GetValue(tmpHolder, "Amount");
                    gCCSTotal = string.IsNullOrEmpty(tmpAmount) ? 0 : Convert.ToDouble(tmpAmount);

                    tmpHolder = "SELECT SUM(BR.ManAmount) AS Amount " +
                                        " FROM tblSaleBrief AS BR INNER JOIN " +
                                        " tblCustomer AS CU ON BR.CustID = CU.CustID INNER JOIN " +
                                        " tblMOP AS MO ON BR.BillId = MO.BillID " +
                                        " WHERE (MO.MOPType = 'CRE' OR MO.MOPType = 'CREI') AND BR.IsActive = 'Y' " + getDateRange() + getCustomerID();
                    tmpAmount = GlbData.GetValue(tmpHolder, "Amount");
                    gCRETotal = string.IsNullOrEmpty(tmpAmount) ?  0 : Convert.ToDouble(tmpAmount);
                    break;
                case 1:
                    tmpHolder = "SELECT SUM(BR.ManAmount) AS Amount " +
                                          " FROM tblSaleBrief AS BR INNER JOIN " +
                                          " tblCustomer AS CU ON BR.CustID = CU.CustID INNER JOIN " +
                                          " tblMOP AS MO ON BR.BillId = MO.BillID " +
                                          " WHERE MO.MOPType = 'CSH' AND BR.IsActive = 'Y' " + getDateRange() + getCustomerID();
                    tmpAmount = GlbData.GetValue(tmpHolder, "Amount");
                    gCSHTotal = string.IsNullOrEmpty(tmpAmount) ? 0 :  Convert.ToDouble(tmpAmount);
                    gCHQTotal = 0;
                    gCCSTotal = 0;
                    gCRETotal = 0;
                    break;
                case 2:
                    gCSHTotal = 0;
                    tmpHolder = "SELECT SUM(BR.ManAmount) AS Amount " +
                                          " FROM tblSaleBrief AS BR INNER JOIN " +
                                          " tblCustomer AS CU ON BR.CustID = CU.CustID INNER JOIN " +
                                          " tblMOP AS MO ON BR.BillId = MO.BillID " +
                                          " WHERE MO.MOPType = 'CHQ' AND BR.IsActive = 'Y' " + getDateRange() + getCustomerID();
                    tmpAmount = GlbData.GetValue(tmpHolder, "Amount");
                    gCHQTotal = string.IsNullOrEmpty(tmpAmount) ? 0 : Convert.ToDouble(tmpAmount);
                    gCCSTotal = 0;
                    gCRETotal = 0;
                    break;
                case 3:
                    gCSHTotal = 0;
                    gCHQTotal = 0;
                    tmpHolder = "SELECT SUM(BR.ManAmount) AS Amount " +
                                          " FROM tblSaleBrief AS BR INNER JOIN " +
                                          " tblCustomer AS CU ON BR.CustID = CU.CustID INNER JOIN " +
                                          " tblMOP AS MO ON BR.BillId = MO.BillID " +
                                          " WHERE MO.MOPType = 'CCS' AND BR.IsActive = 'Y' " + getDateRange() + getCustomerID();
                    tmpAmount = GlbData.GetValue(tmpHolder, "Amount");
                    gCCSTotal = string.IsNullOrEmpty(tmpAmount) ? 0 : Convert.ToDouble(tmpAmount);
                    gCRETotal = 0;
                    break;
                case 4:
                    gCSHTotal = 0;
                    gCHQTotal = 0;
                    gCCSTotal = 0;
                    tmpHolder = "SELECT SUM(BR.ManAmount) AS Amount " +
                                          " FROM tblSaleBrief AS BR INNER JOIN " +
                                          " tblCustomer AS CU ON BR.CustID = CU.CustID INNER JOIN " +
                                          " tblMOP AS MO ON BR.BillId = MO.BillID " +
                                          " WHERE (MO.MOPType = 'CRE' OR MO.MOPType = 'CREI) AND BR.IsActive = 'Y' " + getDateRange() + getCustomerID();
                    tmpAmount = GlbData.GetValue(tmpHolder, "Amount");
                    gCRETotal = string.IsNullOrEmpty(tmpAmount) ? 0 : Convert.ToDouble(tmpAmount);
                    break;
                default:
                    break;
            }
        }

        private string getCustomerID()
        {
            if (txtCusCode.Text.Trim() == "")
                return " ";
            else
                return " AND BR.CustID = " + gCustID + " ";
        }

        private string getDateRange()
        {
            return " AND BR.DateOn BETWEEN CONVERT(date, '" + dtpFrom.Text + "') AND CONVERT(date, '" + dtpTo.Text + "')";
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

        private void btnFInvoice_Click(object sender, EventArgs e)
        {
            frmIPBillView f = new frmIPBillView();
            f.TABLE_NAME = "tblSaleBrief";
            f.ShowDialog();
            txtInvoice.Text = f.BILLNO;
            txtInvoice.Focus();
        }

        private void txtInvoice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down) btnFInvoice.PerformClick();
        }

        private string getPaticularInvoice()
        {
            return " SELECT BR.BillNo AS BRBillNo, BR.DateOn AS BRDateOn, BR.UserName AS E1Name, " +
                " CU.Code AS Code, CU.NameOF AS Name, CU.Add1 AS E1Add1, CU.Add2 AS E1Add2, CU.City AS E1City, " +
                " CU.Tp1 AS CUTp1, CU.Tp2 AS CUTp2, CU.Tp3 AS CUTp3, IT.Code AS CUCode, IT.NameOf AS CUName, " +
                " DT.UnitPrice AS UnitPrice, DT.SQty AS Qty, ISNULL(DT.FreeQty,0) AS BRPaidAmount, DT.LineDisAmount AS Discount, " +
                " DT.TotalAmount AS TotalAmount " +
                " FROM tblSaleBrief AS BR INNER JOIN " +
                " tblSaleDetail AS DT ON BR.BillID = DT.BriefID INNER JOIN " +
                " tblItem AS IT ON IT.CustID = DT.ItemID INNER JOIN  " +
                " tblCustomer AS CU ON CU.CustID = BR.CustID " +
                " WHERE BR.BillNo = '" + txtInvoice.Text.Trim() + "'";
        }

        private void txtInvoice_Validating(object sender, CancelEventArgs e)
        {
            gSB.Clear();
            gSB.Append("SELECT * FROM tblSaleBrief WHERE BillNo = '" + txtInvoice.Text.Trim() + "' ");
            if(GlbData.AlreadyExist(gSB.ToString()))
            {
                return;
            }
            else
            {
                MessageBox.Show("Sorry.. This Invoice No does not exist", "INVALID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtInvoice.Focus();
                return;
            }
        }
    }
}
