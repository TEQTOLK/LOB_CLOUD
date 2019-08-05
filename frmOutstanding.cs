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
    public partial class frmOutstanding : Form
    {
        private int gCustID = 0;
        StringBuilder gSB = new StringBuilder();
        GlobalData GlbData = new GlobalData();
        PrintReport print = new PrintReport();
        DataSet dSet = new DataSet();

        private double gCSHTotal = 0;
        private double gCHQTotal = 0;
        private double gCCSTotal = 0;
        private double gCRETotal = 0;
        private int gAreaID = 0;

        public frmOutstanding()
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


        private void LoadOutstanding()
        {
            gSB.Clear();
            gSB.Append(GetQuery() + getDateRange() + getCustomerID() + " GROUP BY BR.DateOn, CU.Tp1, CU.Code, CU.CustID, CU.NameOF ORDER BY BR.DateOn");
            dSet = GlbData.getDataSet(gSB.ToString(), "tblSaleBrief");
            DataView dView = new DataView(dSet.Tables[0]);
            dgvGrid.DataSource = dView;
            SettingGrid();
            PatchPaidAmount();
        }

        private void PatchPaidAmount()
        {
            for (int i = 0; i < dgvGrid.Rows.Count; i++)
            {
                gSB.Clear();
                gSB.Append("SELECT SUM(TotalPaid) AS PaidAmount " +
                    " FROM tblSaleBrief " +
                    " WHERE IsActive = 'N' AND MOP = 'CRE' AND CustID = " + dgvGrid.Rows[i].Cells[3].Value + " ");
                dgvGrid.Rows[i].Cells[6].Value = Convert.ToDouble(GlbData.GetValue(gSB.ToString(), "PaidAmount"));
                dgvGrid.Rows[i].Cells[7].Value = Convert.ToDouble(dgvGrid.Rows[i].Cells[5].Value) - Convert.ToDouble(dgvGrid.Rows[i].Cells[6].Value);
            }
        }

        private string GetQuery()
        {
            return "SELECT BR.DateOn, CU.Tp1, CU.Code, CU.CustID, CU.NameOF, SUM(BR.ManAmount) AS ManAmount, SUM(BR.TotalPaid) AS TotalPaid, SUM(BR.NetTotal - BR.CNAmount - BR.TotalPaid) AS BRPaidAmount " +
                " FROM tblSaleBrief AS BR INNER JOIN " +
                " tblCustomer AS CU ON BR.CustID = CU.CustID INNER JOIN " +
                " tblCUSProfile AS CP ON CP.CustID = CU.ProfileID  " +
                " WHERE(BR.IsActive = 'Y') AND(BR.NetTotal - BR.CNAmount - BR.TotalPaid > 0) AND BR.MOP = 'CREI' ";
        }

        private void SettingGrid()
        {
            dgvGrid.Columns[3].Visible = false;
            dgvGrid.Columns[2].Visible = false;
            dgvGrid.Columns[1].Visible = false;

            dgvGrid.Columns[0].HeaderText = "Date";
            dgvGrid.Columns[0].Width = 100;
            dgvGrid.Columns[4].HeaderText = "Customer Name";
            dgvGrid.Columns[4].Width = 350;
            dgvGrid.Columns[5].HeaderText = "Net Total ";
            dgvGrid.Columns[5].Width = 100;
            dgvGrid.Columns[6].HeaderText = "Total Paid";
            dgvGrid.Columns[6].Width = 100;
            dgvGrid.Columns[7].HeaderText = "Payable ";
            dgvGrid.Columns[7].Width = 100;

            dgvGrid.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvGrid.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvGrid.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvGrid.Columns[5].DefaultCellStyle.Format = "N2";
            dgvGrid.Columns[6].DefaultCellStyle.Format = "N2";
            dgvGrid.Columns[7].DefaultCellStyle.Format = "N2";
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
            LoadOutstanding();
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
        
        private string getAreaID()
        {
            if (txtAreaCode.Text.Trim() == "")
                return " ";
            else
                return " AND AR.CustID = " + gAreaID + " ";
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

        private void dgvGrid_DoubleClick(object sender, EventArgs e)
        {
            string tmpCode = dgvGrid.Rows[dgvGrid.CurrentRow.Index].Cells[2].Value.ToString();
            string tmpName = dgvGrid.Rows[dgvGrid.CurrentRow.Index].Cells[4].Value.ToString();
            string tmpTp = dgvGrid.Rows[dgvGrid.CurrentRow.Index].Cells[1].Value.ToString();

            frmOutstandingPOP f = new frmOutstandingPOP();
            f.lblCustomer.Text = "  " + tmpCode + " - " + tmpName + " [ " + tmpTp + " ] ";
            f.gCustID = Convert.ToInt32(dgvGrid.Rows[dgvGrid.CurrentRow.Index].Cells[3].Value);
            f.ShowDialog();
        }
    }
}
