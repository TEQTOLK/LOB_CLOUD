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
    public partial class frmIPSearch : Form
    {
        GlobalData GlbData = new GlobalData();
        DataSet dSet = new DataSet();
        StringBuilder gSB = new StringBuilder();

        public string CODE { get; set; }
        public string NAME { get; set; }
        public int ITEMID { get; set; }
        public double QTY { get; set; }
        public double PRICE { get; set; }
        public double COST { get; set; }
        public Boolean gOkCancel = false;

        public frmIPSearch()
        {
            InitializeComponent();
        }

        private void fillItem()
        {
            gSB.Clear();
            gSB.Append("SELECT IT.Code, IT.NameOF, CT.NameOF AS Category, IT.SellingPrice AS Price, ISNULL(ST.Qty,0) AS Qty, IT.CustId, IT.Cost " +
                       " FROM tblMajorCategory AS CT RIGHT OUTER JOIN " +
                       "  tblItem AS IT ON CT.CustID = IT.CategoryID LEFT OUTER JOIN " +
                       "  tblComSTKStore AS ST ON IT.CustID = ST.ItemID WHERE ST.CompID = " + GlobalData.GCompID + " AND ST.StockroomID = " + GlobalData.GStockRoomID + " ");
            dSet = GlbData.getDataSet(gSB.ToString(), "tblItem");
            DataView dView = new DataView(dSet.Tables[0]);
            dgvItem.DataSource = dView;
            SettingGrid();
        }

        public void SettingGrid()
        {
            dgvItem.Columns[5].Visible = false;
            dgvItem.Columns[6].Visible = false;

            dgvItem.Columns[0].HeaderText = "Code";
            dgvItem.Columns[0].Width = 120;
            dgvItem.Columns[1].HeaderText = "Item Name";
            dgvItem.Columns[1].Width = 300;
            dgvItem.Columns[2].HeaderText = "Category";
            dgvItem.Columns[2].Width = 200;
            dgvItem.Columns[3].HeaderText = "Price";
            dgvItem.Columns[3].Width = 80;
            dgvItem.Columns[4].HeaderText = "Qty";
            dgvItem.Columns[4].Width = 80;
            dgvItem.Columns[3].DefaultCellStyle.Format = "N2";
            dgvItem.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvItem.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvItem.ClearSelection();
        }

        private void frmIPSearch_Load(object sender, EventArgs e)
        {
            fillItem();
        }

        private void txtCode_TextChanged(object sender, EventArgs e)
        {
            if(txtCode.Text.Trim() != "")
            {
                dSet.Tables[0].DefaultView.RowFilter = "Code like '%" + txtCode.Text + "%'";
                dgvItem.DataSource = dSet.Tables[0].DefaultView;
            }
            else
            {
                dSet.Tables[0].DefaultView.RowFilter = "";
                dgvItem.DataSource = dSet.Tables[0].DefaultView;
            }
            
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() != "")
            {
                dSet.Tables[0].DefaultView.RowFilter = "NameOF like '%" + txtName.Text + "%'";
                dgvItem.DataSource = dSet.Tables[0].DefaultView;
            }
            else
            {
                dSet.Tables[0].DefaultView.RowFilter = "";
                dgvItem.DataSource = dSet.Tables[0].DefaultView;
            }
        }

        private void dgvItem_SelectionChanged(object sender, EventArgs e)
        {
            lblCode.Text = dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[0].Value.ToString();
            lblName.Text = dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[1].Value.ToString();
        }
        
        private void dgvItem_DoubleClick(object sender, EventArgs e)
        {
            if (dgvItem.SelectedRows.Count == 0)
                return;

            CODE = dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[0].Value.ToString();
            NAME = dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[1].Value.ToString();
            ITEMID = Convert.ToInt32(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[5].Value.ToString());
            QTY = Convert.ToDouble(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[4].Value.ToString());
            PRICE = Convert.ToDouble(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[3].Value.ToString());
            COST = Convert.ToDouble(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[6].Value.ToString());

            gOkCancel = true;
            this.Hide();
        }

        private void dgvItem_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if (dgvItem.SelectedRows.Count == 0)
                    return;

                CODE = dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[0].Value.ToString();
                NAME = dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[1].Value.ToString();
                ITEMID = Convert.ToInt32(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[5].Value.ToString());
                QTY = Convert.ToDouble(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[4].Value.ToString());
                PRICE = Convert.ToDouble(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[3].Value.ToString());
                COST = Convert.ToDouble(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[6].Value.ToString());

                gOkCancel = true;
                this.Hide();
            }
        }
    }
}
