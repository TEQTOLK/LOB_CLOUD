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
    public partial class frmIPCHQ : Form
    {
        GlobalData GlbData = new GlobalData();
        DataSet dSet = new DataSet();
        StringBuilder gSB = new StringBuilder();
        public int gBankID = 0;
        public int gBranchID = 0;
        public double gTotalAmount = 0;

        public Boolean gOkCancel = false;

        public frmIPCHQ()
        {
            InitializeComponent();
        }

        private void frmIPCHQ_Load(object sender, EventArgs e)
        {
            GlbData.FillComboBox(cmbBranch, "tblBranch", "ORDER BY NameOF");
            GlbData.FillComboBox(cmbBank, "tblBank", "ORDER BY NameOF");
        }

        private void cmbBank_Validating(object sender, CancelEventArgs e)
        {
            if (cmbBank.Items.Count == 0)
                return;

            gBankID = Convert.ToInt32(cmbBank.SelectedValue);
        }

        private void cmbBranch_Validating(object sender, CancelEventArgs e)
        {
            if (cmbBranch.Items.Count == 0)
                return;

            gBranchID = Convert.ToInt32(cmbBranch.SelectedValue);
        }

        private void AddingGrid(int cBankID, string cBankName, int cBranchId, string cBranchName, string cCHQDate, string cCHQNo, double cAmount)
        {
            DataGridViewRow newRow = (DataGridViewRow)dgvCHQ.RowTemplate.Clone();
            newRow.CreateCells(dgvCHQ);

            newRow.Cells[0].Value = cBankID.ToString();
            newRow.Cells[1].Value = cBankName.ToString();
            newRow.Cells[2].Value = cBranchId.ToString();
            newRow.Cells[3].Value = cBranchName.ToString();
            newRow.Cells[4].Value = cCHQDate.ToString();
            newRow.Cells[5].Value = cCHQNo.ToString();
            newRow.Cells[6].Value = string.Format("{0:N}", cAmount);

            dgvCHQ.Rows.Add(newRow);
        }

        private Boolean IsRequiredGrid()
        {
            if (txtCash.Text == "" || txtCash.Text == "0" || txtCash.Text == "0.00")
            {
                MessageBox.Show("Please Enter Amount Here...", "INVALID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCash.Focus();
                return false;
            }
            if (gBranchID == 0)
            {
                MessageBox.Show("Please Select Your Branch", "INVALID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbBranch.Focus();
                return false;
            }
            if (gBankID == 0)
            {
                MessageBox.Show("Please Select Your Bank", "INVALID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbBank.Focus();
                return false;
            }
            if(txtCHQNo.Text == "")
            {
                MessageBox.Show("Please Enter CHQ No Here...", "INVALID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCHQNo.Focus();
                return false;
            }
            if(Convert.ToDateTime(dtpCHQDate.Text) < Convert.ToDateTime(DateTime.Now.ToShortDateString()))
            {
                MessageBox.Show("Sorry.. You Cannot Be Add Past Date", "INVALID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCHQNo.Focus();
                return false;
            }
            return true;
        }

        private void txtCash_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                if(IsRequiredGrid())
                {
                    AddingGrid(gBankID, cmbBank.Text, gBranchID, cmbBranch.Text, Convert.ToDateTime(dtpCHQDate.Text).ToShortDateString(), txtCHQNo.Text.Trim(), Convert.ToDouble(txtCash.Text));
                    lblGossTotal.Text = string.Format("{0:N}", CalcAmount());
                    txtCHQNo.Clear();
                    txtCash.Text = "0.00";
                    dtpCHQDate.Text = DateTime.Now.ToShortDateString();
                    cmbBank.Focus();
                }
            }
        }

        private void cmbBank_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbBranch.Focus();
        }

        private void cmbBranch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                dtpCHQDate.Focus();
        }

        private void dtpCHQDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtCHQNo.Focus();
        }

        private void txtCHQNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtCash.Focus();
        }

        private double CalcAmount()
        {
            double tmpAmount = 0;
            for (int i = 0; i < dgvCHQ.Rows.Count; i++)
            {
                tmpAmount += Convert.ToDouble(dgvCHQ.Rows[i].Cells[6].Value);
            }
            return tmpAmount;
        }

        private void dgvCCard_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                int rowIndex = dgvCHQ.CurrentRow.Index;

                if (rowIndex == dgvCHQ.NewRowIndex || rowIndex < 0)
                    return;

                dgvCHQ.Rows.RemoveAt(rowIndex);
                lblGossTotal.Text = string.Format("{0:N}", CalcAmount());
            }
        }

        private void dgvCCard_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == dgvCHQ.NewRowIndex || e.RowIndex < 0)
                return;

            if (e.ColumnIndex == dgvCHQ.Columns["Column4"].Index)
            {
                dgvCHQ.Rows.RemoveAt(e.RowIndex);
                lblGossTotal.Text = string.Format("{0:N}", CalcAmount());
            }
        }

        private Boolean IsRequired()
        {
            if (dgvCHQ.Rows.Count == 0)
            {
                MessageBox.Show("Please Add Atleast one Payment.", "INVALID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(IsRequired())
            {
                gOkCancel = true;
                this.Hide();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            gOkCancel = false;
            this.Hide();
        }
    }
}
