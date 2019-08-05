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
    public partial class frmIPSearchDealer : Form
    {
        GlobalData GlbData = new GlobalData();
        DataSet dSet = new DataSet();
        StringBuilder gSB = new StringBuilder();

        public string CODE { get; set; }
        public string NAME { get; set; }
        public int CUSTID { get; set; }
        public Boolean gOkCancel = false;
        public string TABLE_NAME { get; set; }

        public frmIPSearchDealer()
        {
            InitializeComponent();
        }

        private void fillSupplier()
        {
            gSB.Clear();
            gSB.Append("SELECT CustID, Code, NameOF, City, Tp1 " +
                       " FROM "+ TABLE_NAME + " " +
                       " WHERE IsActive = 'Y' ");
            dSet = GlbData.getDataSet(gSB.ToString(), TABLE_NAME);
            DataView dView = new DataView(dSet.Tables[0]);
            dgvItem.DataSource = dView;
            SettingGrid();
        }

        public void SettingGrid()
        {
            dgvItem.Columns[0].Visible = false;
            
            dgvItem.Columns[1].HeaderText = "Code";
            dgvItem.Columns[1].Width = 100;
            dgvItem.Columns[2].HeaderText = "Name";
            dgvItem.Columns[2].Width = 400;
            dgvItem.Columns[3].HeaderText = "City";
            dgvItem.Columns[3].Width = 200;
            dgvItem.Columns[4].HeaderText = "Contact No";
            dgvItem.Columns[4].Width = 100;
            dgvItem.ClearSelection();
        }

        private void frmIPSearch_Load(object sender, EventArgs e)
        {
            fillSupplier();
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
            if (dgvItem.SelectedRows.Count == 0)
                return;

            lblCode.Text = dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[1].Value.ToString();
            lblName.Text = dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[2].Value.ToString();
        }
        
        private void dgvItem_DoubleClick(object sender, EventArgs e)
        {
            if (dgvItem.SelectedRows.Count == 0)
                return;

            CODE = dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[1].Value.ToString();
            NAME = dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[2].Value.ToString();
            CUSTID = Convert.ToInt32(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[0].Value.ToString());

            gOkCancel = true;
            this.Hide();
        }

        private void dgvItem_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if (dgvItem.SelectedRows.Count == 0)
                    return;

                CODE = dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[1].Value.ToString();
                NAME = dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[2].Value.ToString();
                CUSTID = Convert.ToInt32(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[0].Value.ToString());

                gOkCancel = true;
                this.Hide();
            }
        }
    }
}
