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
    public partial class frmIPRcptView : Form
    {
        StringBuilder gSB = new StringBuilder();
        GlobalData GlbData = new GlobalData();
        PrintReport print = new PrintReport();
        DataTable dataTable = new DataTable();
        MySqlDataAdapter sqlAdapter = new MySqlDataAdapter();
        DataSet dSet = new DataSet();

        public string TRAN_CODE { get; set; }
        public int BILLID { get; set; }
        public string BILLNO { get; set; }
        public bool gOkCancel = false;
        public string DEALER_TABLE { get; set; }


        public frmIPRcptView()
        {
            InitializeComponent();
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void frmIPBillView_Load(object sender, EventArgs e)
        {
            cboDateRange.SelectedIndex = 1;
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

        private string correctQuery()
        {
           string tmpHolder = " SELECT CP.BillID, CAST(CP.DateOn AS Date) AS DateOn, CP.BillNo , CU.NameOF + ' - ' + CU.City AS NameOF, " +
               " BR.CashTendered AS ManAmount, BR.PerformedOn " +
               " FROM tblMOP AS BR INNER JOIN " +
               " tblCustPayBrief AS CP ON BR.MopID = CP.MopId RIGHT OUTER JOIN " +
               " " + DEALER_TABLE + " AS CU ON BR.OwnerID = CU.CustID " +
               " WHERE TranCode = '" + TRAN_CODE + "' ";
            return tmpHolder;
        }

        private string getDateRange()
        {
            return " AND CP.DateOn BETWEEN CONVERT(date, '" + dtpFrom.Text + "') AND CONVERT(date, '" + dtpTo.Text + "')";
        }

        private void fillBillView()
        {
            string strQuery = correctQuery() + getDateRange() + "ORDER BY CP.DateOn, CP.BillNo";
            dSet = GlbData.getDataSet(strQuery, "tblCustPayBrief");
            DataView dView = new DataView(dSet.Tables[0]);
            dgvBill.DataSource = dView;
            SettingGrid();
        }

        public void SettingGrid()
        {
            dgvBill.Columns[0].Visible = false;

            dgvBill.Columns[1].HeaderText = "Date";
            dgvBill.Columns[1].Width = 100;
            dgvBill.Columns[2].HeaderText = "BillNo";
            dgvBill.Columns[2].Width = 100;
            dgvBill.Columns[3].HeaderText = "Owner Name";
            dgvBill.Columns[3].Width = 290;
            dgvBill.Columns[4].HeaderText = "Net Amount";
            dgvBill.Columns[4].Width = 130;
            dgvBill.Columns[5].HeaderText = "PerformedOn";
            dgvBill.Columns[5].Width = 180;

            dgvBill.Columns[4].DefaultCellStyle.Format = "N2";
            dgvBill.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvBill.ClearSelection();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            fillBillView();
        }

        private void txtBillNo_TextChanged(object sender, EventArgs e)
        {
            if (txtBillNo.Text.Trim() != "")
            {
                dSet.Tables[0].DefaultView.RowFilter = "BillNo like '%" + txtBillNo.Text.Trim() + "%'";
                dgvBill.DataSource = dSet.Tables[0].DefaultView;
            }
            else
            {
                dSet.Tables[0].DefaultView.RowFilter = "";
                dgvBill.DataSource = dSet.Tables[0].DefaultView;
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() != "")
            {
                dSet.Tables[0].DefaultView.RowFilter = "NameOF like '%" + txtName.Text.Trim() + "%'";
                dgvBill.DataSource = dSet.Tables[0].DefaultView;
            }
            else
            {
                dSet.Tables[0].DefaultView.RowFilter = "";
                dgvBill.DataSource = dSet.Tables[0].DefaultView;
            }
        }

        private void dgvBill_DoubleClick(object sender, EventArgs e)
        {
            if (dgvBill.SelectedRows.Count == 0)
                return;
            
            BILLNO = dgvBill.Rows[dgvBill.CurrentRow.Index].Cells[2].Value.ToString();
            BILLID = Convert.ToInt32(dgvBill.Rows[dgvBill.CurrentRow.Index].Cells[0].Value.ToString());

            gOkCancel = true;
            this.Hide();
        }

        private void dgvBill_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                if (dgvBill.SelectedRows.Count == 0)
                    return;

                BILLNO = dgvBill.Rows[dgvBill.CurrentRow.Index].Cells[2].Value.ToString();
                BILLID = Convert.ToInt32(dgvBill.Rows[dgvBill.CurrentRow.Index].Cells[0].Value.ToString());

                gOkCancel = true;
                this.Hide();
            }
        }
    }
}
