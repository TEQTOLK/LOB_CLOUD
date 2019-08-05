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
    public partial class frmOutstandingPOP : Form
    {
        public int gCustID = 0;
        StringBuilder gSB = new StringBuilder();
        GlobalData GlbData = new GlobalData();
        PrintReport print = new PrintReport();
        DataSet dSet = new DataSet();

        public frmOutstandingPOP()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PatchPaidAmount()
        {
            for (int i = 0; i < dgvBills.Rows.Count; i++)
            {
                gSB.Clear();
                gSB.Append("SELECT SUM(TotalPaid) AS PaidAmount " +
                    " FROM tblSaleBrief " +
                    " WHERE IsActive = 'N' AND MOP = 'CRE' AND CustID = " + gCustID + " ");
                dgvBills.Rows[i].Cells[3].Value = Convert.ToDouble(GlbData.GetValue(gSB.ToString(), "PaidAmount"));
                dgvBills.Rows[i].Cells[4].Value = Convert.ToDouble(dgvBills.Rows[i].Cells[2].Value) - Convert.ToDouble(dgvBills.Rows[i].Cells[3].Value);
            }

        }
        private void LoadBills()
        {
            gSB.Clear();
            gSB.Append("SELECT DateOn, BillNo, ManAmount, TotalPaid, (ManAmount - TotalPaid- CNAmount) AS Payable, BillID " +
                " FROM tblSaleBrief " +
                " WHERE IsActive = 'Y' AND (ManAmount - TotalPaid- CNAmount) > 0 AND " +
                " CustID = " + gCustID + " ");
            dSet = GlbData.getDataSet(gSB.ToString(), "tblSaleBrief");
            DataView dView = new DataView(dSet.Tables[0]);
            dgvBills.DataSource = dView;
            SettingGridBills();
            PatchPaidAmount();
        }

        private void SettingGridBills()
        {
            dgvBills.Columns[5].Visible = false;

            dgvBills.Columns[0].HeaderText = "Date";
            dgvBills.Columns[0].Width = 100;
            dgvBills.Columns[1].HeaderText = "Bill No";
            dgvBills.Columns[1].Width = 100;
            dgvBills.Columns[2].HeaderText = "Net Total ";
            dgvBills.Columns[2].Width = 100;
            dgvBills.Columns[3].HeaderText = "Total Paid";
            dgvBills.Columns[3].Width = 100;
            dgvBills.Columns[4].HeaderText = "Payable ";
            dgvBills.Columns[4].Width = 100;

            dgvBills.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvBills.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvBills.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvBills.Columns[2].DefaultCellStyle.Format = "N2";
            dgvBills.Columns[3].DefaultCellStyle.Format = "N2";
            dgvBills.Columns[4].DefaultCellStyle.Format = "N2";
        }

        private void frmOutstandingPOP_Load(object sender, EventArgs e)
        {
            LoadBills();
        }

        private void LoadSaleInfo(int cBillID)
        {
            gSB.Clear();
            gSB.Append(" SELECT IT.Code, IT.NameOF, DE.SQty, DE.FreeQty " +
                       " FROM tblSaleBrief AS BR INNER JOIN " +
                       " tblSaleDetail AS DE ON BR.BillId = DE.BriefID INNER JOIN " +
                       " tblItem AS IT ON DE.ItemId = IT.CustID " +
                       "  WHERE BillID = " + cBillID + " ");
            dSet = GlbData.getDataSet(gSB.ToString(), "tblSaleBrief");
            DataView dView = new DataView(dSet.Tables[0]);
            dgvSale.DataSource = dView;
            SettingGridSale();
        }

        private void SettingGridSale()
        {
            dgvSale.Columns[0].HeaderText = "Code";
            dgvSale.Columns[0].Width = 100;
            dgvSale.Columns[1].HeaderText = "Item Name";
            dgvSale.Columns[1].Width = 250;
            dgvSale.Columns[2].HeaderText = "Qty ";
            dgvSale.Columns[2].Width = 60;
            dgvSale.Columns[3].HeaderText = "Free";
            dgvSale.Columns[3].Width = 60;

            dgvSale.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvSale.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void dgvBills_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvBills.Rows.Count == 0)
                return;

            int tmpBillID = Convert.ToInt32(dgvBills.Rows[dgvBills.CurrentRow.Index].Cells[5].Value);
            LoadSaleInfo(tmpBillID);
            LoadPaidBills();
            LoadOutstanding();
        }

        private void LoadPaidBills()
        {
            gSB.Clear();
            gSB.Append("SELECT DateOn, BillNo, ManAmount, TotalPaid, BillID " +
                " FROM tblSaleBrief " +
                " WHERE IsActive = 'N' AND TotalPaid > 0 AND " +
                " CustID = " + gCustID + " ");
            dSet = GlbData.getDataSet(gSB.ToString(), "tblSaleBrief");
            DataView dView = new DataView(dSet.Tables[0]);
            dgvPaidBills.DataSource = dView;
            SettingGridPaidBills();
        }

        private void SettingGridPaidBills()
        {
            dgvPaidBills.Columns[4].Visible = false;

            dgvPaidBills.Columns[0].HeaderText = "Date";
            dgvPaidBills.Columns[0].Width = 100;
            dgvPaidBills.Columns[1].HeaderText = "Bill No";
            dgvPaidBills.Columns[1].Width = 100;
            dgvPaidBills.Columns[2].HeaderText = "Net Total ";
            dgvPaidBills.Columns[2].Width = 100;
            dgvPaidBills.Columns[3].HeaderText = "Total Paid";
            dgvPaidBills.Columns[3].Width = 100;

            dgvPaidBills.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPaidBills.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvPaidBills.Columns[2].DefaultCellStyle.Format = "N2";
            dgvPaidBills.Columns[3].DefaultCellStyle.Format = "N2";
        }

        private void LoadOutstanding()
        {
            gSB.Clear();
            gSB.Append("SELECT DateOn, BillNo, NetTotal, TotalPaid, NetTotal - CNAmount - TotalPaid AS Payable, " +
                " PerformedOn, UserName, BillID " +
                " FROM  tblSaleBrief " +
                " WHERE MOP = 'CRE' AND (NetTotal- TotalPaid) > 0  " +
                " AND CustID = " + gCustID + " ORDER BY BillID ");
            dSet = GlbData.getDataSet(gSB.ToString(), "tblSaleBrief");
            DataView dView = new DataView(dSet.Tables[0]);
            dgvOutstanding.DataSource = dView;
            SettingGrid(dgvOutstanding);
        }

        private void SettingGrid(DataGridView dataGridView)
        {
            dataGridView.Columns[7].Visible = false;
            dataGridView.Columns[5].Visible = false;
            dataGridView.Columns[6].Visible = false;

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
            //dataGridView.Columns[5].HeaderText = "PerformedOn";
            //dataGridView.Columns[5].Width = 170;
            //dataGridView.Columns[6].HeaderText = "Bill User";
            //dataGridView.Columns[6].Width = 80;

            dataGridView.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dataGridView.Columns[2].DefaultCellStyle.Format = "N2";
            dataGridView.Columns[3].DefaultCellStyle.Format = "N2";
            dataGridView.Columns[4].DefaultCellStyle.Format = "N2";
        }
    }
}
