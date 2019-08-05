﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LOB
{
    public partial class frmRptCUSOutstanding : Form
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

        public frmRptCUSOutstanding()
        {
            InitializeComponent();
        }

        private void frmRptSales_Load(object sender, EventArgs e)
        {
            ClearLocal();
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
                    break;
                case 1:
                    pnlAllCustomer.Visible = false;
                    pnlPartiCus.Visible = true;
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
            return "SELECT BR.DateOn AS BRDateOn, BR.BillNo AS BRBillNo, CU.Code AS CUCode, CU.CustID AS Qty, " +
                " CU.NameOF AS CUName, BR.NetTotal - BR.CNAmount - BR.TotalPaid AS BRPaidAmount, BR.TotalPaid AS UnitPrice, BR.ManAmount AS TotalAmount, " +
                " CP.AreaID AS Discount, AR.NameOF AS CUNIC, CU.Tp1 AS E1Relationship, BR.DueDate AS E1IssuedDate, BR.MOP AS MOP " +
                " FROM tblSaleBrief AS BR INNER JOIN " +
                " tblCustomer AS CU ON BR.CustID = CU.CustID INNER JOIN " +
                " tblCUsProfile AS CP ON CP.CustID = CU.ProfileID INNER JOIN " +
                " tblArea AS AR ON CP.AreaID = AR.CustID " +
                " WHERE ";
        }

        private string getCustomerID()
        {
            if (txtCusCode.Text.Trim() == "")
                return " ";
            else
                return " AND BR.CustID = " + gCustID + " ";
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            btnShow.Enabled = false;
            //getAmount();
            string tmpQuery = GetQuery() + getDateRange() + getAreaID() + getCustomerID() + " AND MOP = 'CRE' AND (NetTotal- TotalPaid) > 0 ";
            print.RoadToPrintReport(tmpQuery, @"C:\LOB\Bin\Debug\Rep\CUSOutstanding.rpt", rptView, "P", gCSHTotal, gCHQTotal, gCCSTotal, gCRETotal);
            btnShow.Enabled = true;//C:\LOB\Bin\Debug\Rep
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
                        " tblMOP AS MO ON BR.BillId = MO.BillID INNER JOIN " +
                        " tblCUsProfile AS CP ON CP.CustID = CU.ProfileID INNER JOIN " +
                        " tblArea AS AR ON CP.AreaID = AR.CustID " +
                        " WHERE MO.MOPType = 'CSH' AND BR.IsActive = 'Y' AND " + getDateRange() + getAreaID();
                    tmpAmount = GlbData.GetValue(tmpHolder, "Amount");
                    gCSHTotal = string.IsNullOrEmpty(tmpAmount) ? 0 : Convert.ToDouble(tmpAmount);

                    tmpHolder = "SELECT SUM(BR.ManAmount) AS Amount " +
                                           " FROM tblSaleBrief AS BR INNER JOIN " +
                                           " tblCustomer AS CU ON BR.CustID = CU.CustID INNER JOIN " +
                                           " tblMOP AS MO ON BR.BillId = MO.BillID INNER JOIN " +
                                            " tblCUsProfile AS CP ON CP.CustID = CU.ProfileID INNER JOIN " +
                                            " tblArea AS AR ON CP.AreaID = AR.CustID " +
                                           " WHERE MO.MOPType = 'CHQ' AND BR.IsActive = 'Y' AND " + getDateRange() + getAreaID();
                    tmpAmount = GlbData.GetValue(tmpHolder, "Amount");
                    gCHQTotal = string.IsNullOrEmpty(tmpAmount) ? 0 : Convert.ToDouble(tmpAmount);

                    tmpHolder = "SELECT SUM(BR.ManAmount) AS Amount " +
                                          " FROM tblSaleBrief AS BR INNER JOIN " +
                                          " tblCustomer AS CU ON BR.CustID = CU.CustID INNER JOIN " +
                                          " tblMOP AS MO ON BR.BillId = MO.BillID INNER JOIN " +
                                           " tblCUsProfile AS CP ON CP.CustID = CU.ProfileID INNER JOIN " +
                        " tblArea AS AR ON CP.AreaID = AR.CustID " +
                                          " WHERE MO.MOPType = 'CCS' AND BR.IsActive = 'Y' AND " + getDateRange() + getAreaID();
                    tmpAmount = GlbData.GetValue(tmpHolder, "Amount");
                    gCCSTotal = string.IsNullOrEmpty(tmpAmount) ? 0 : Convert.ToDouble(tmpAmount);

                    tmpHolder = "SELECT SUM(BR.ManAmount) AS Amount " +
                                        " FROM tblSaleBrief AS BR INNER JOIN " +
                                        " tblCustomer AS CU ON BR.CustID = CU.CustID INNER JOIN " +
                                        " tblMOP AS MO ON BR.BillId = MO.BillID INNER JOIN " +
                                         " tblCUsProfile AS CP ON CP.CustID = CU.ProfileID INNER JOIN " +
                        " tblArea AS AR ON CP.AreaID = AR.CustID " +
                                        " WHERE MO.MOPType = 'CRE' AND BR.IsActive = 'Y' AND " + getDateRange() + getAreaID();
                    tmpAmount = GlbData.GetValue(tmpHolder, "Amount");
                    gCRETotal = string.IsNullOrEmpty(tmpAmount) ?  0 : Convert.ToDouble(tmpAmount);
                    break;
                case 1:
                    tmpHolder = "SELECT SUM(BR.ManAmount) AS Amount " +
                                          " FROM tblSaleBrief AS BR INNER JOIN " +
                                          " tblCustomer AS CU ON BR.CustID = CU.CustID INNER JOIN " +
                                          " tblMOP AS MO ON BR.BillId = MO.BillID INNER JOIN " +
                                           " tblCUsProfile AS CP ON CP.CustID = CU.ProfileID INNER JOIN " +
                        " tblArea AS AR ON CP.AreaID = AR.CustID " +
                                          " WHERE MO.MOPType = 'CSH' AND BR.IsActive = 'Y' AND " + getDateRange() + getAreaID();
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
                                          " tblMOP AS MO ON BR.BillId = MO.BillID INNER JOIN " +
                                          " tblCUsProfile AS CP ON CP.CustID = CU.ProfileID INNER JOIN " +
                        " tblArea AS AR ON CP.AreaID = AR.CustID " +
                                          " WHERE MO.MOPType = 'CHQ' AND BR.IsActive = 'Y' AND " + getDateRange() + getAreaID();
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
                                          " tblMOP AS MO ON BR.BillId = MO.BillID INNER JOIN " +
                                           " tblCUsProfile AS CP ON CP.CustID = CU.ProfileID INNER JOIN " +
                        " tblArea AS AR ON CP.AreaID = AR.CustID " +
                                          " WHERE MO.MOPType = 'CCS' AND BR.IsActive = 'Y' AND " + getDateRange() + getAreaID();
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
                                          " tblMOP AS MO ON BR.BillId = MO.BillID INNER JOIN " +
                                          " tblCUsProfile AS CP ON CP.CustID = CU.ProfileID INNER JOIN " +
                        " tblArea AS AR ON CP.AreaID = AR.CustID " +
                                          " WHERE MO.MOPType = 'CRE' AND BR.IsActive = 'Y' AND " + getDateRange() + getAreaID();
                    tmpAmount = GlbData.GetValue(tmpHolder, "Amount");
                    gCRETotal = string.IsNullOrEmpty(tmpAmount) ? 0 : Convert.ToDouble(tmpAmount);
                    break;
                default:
                    break;
            }
        }

        private string getAreaID()
        {
            if (txtAreaCode.Text.Trim() == "")
                return " ";
            else
                return " AND AR.CustID = " + gAreaID + " ";
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

        private void btnAFind_Click(object sender, EventArgs e)
        {
            frmIPSearchCommon f = new frmIPSearchCommon();
            f.gTableName = "tblArea";
            f.ShowDialog();
            if (f.gOkCancel == true)
            {
                txtAreaCode.Text = f.CODE;
                //gMajorCatID = f1.CUSTID;
                //lblCategory.Text = f1.NAME;
                txtAreaCode.Focus();
            }
        }

        private void txtAreaCode_Validating(object sender, CancelEventArgs e)
        {
            if (txtAreaCode.Text == "")
            {
                txtAreaCode.Clear();
                lblAreaName.Text = "";
                return;
            }

            gSB.Clear();
            gSB.Append("SELECT * FROM tblArea WHERE Code = '" + txtAreaCode.Text.Trim() + "' AND IsActive = 'Y' ");
            if (GlbData.AlreadyExist(gSB.ToString()) == false)
            {
                MessageBox.Show("Sorry.. This Area does not exist", "INVALID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAreaCode.Focus();
                return;
            }
            else
            {
                gAreaID = Convert.ToInt32(GlbData.GetValue(gSB.ToString(), "CustID"));
                lblAreaName.Text = GlbData.GetValue(gSB.ToString(), "NameOF");
            }
        }

        private void txtAreaCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                btnAFind.PerformClick();
        }

    }
}
