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
    public partial class frmIPCard : Form
    {
        GlobalData GlbData = new GlobalData();
        DataSet dSet = new DataSet();
        StringBuilder gSB = new StringBuilder();
        public int gBankID = 0;
        public int gCardID = 0;
        public double gTotalAmount = 0;

        public Boolean gOkCancel = false;

        public frmIPCard()
        {
            InitializeComponent();
        }

        private void frmIPCard_Load(object sender, EventArgs e)
        {
            GlbData.FillComboBox(cmbType, "tblCardCompany", "ORDER BY NameOF");
            GlbData.FillComboBox(cmbBank, "tblBank", "ORDER BY NameOF");
        }

        private void AddingGrid(int cCardID, string cCardName, int cBankID, string cBankName, double cAmount)
        {
            DataGridViewRow newRow = (DataGridViewRow)dgvCCard.RowTemplate.Clone();
            newRow.CreateCells(dgvCCard);

            newRow.Cells[0].Value = cCardID.ToString();
            newRow.Cells[1].Value = cCardName.ToString();
            newRow.Cells[2].Value = cBankID.ToString();
            newRow.Cells[3].Value = cBankName.ToString();
            newRow.Cells[4].Value = string.Format("{0:N}", cAmount);

            dgvCCard.Rows.Add(newRow);
        }

        private Boolean IsRequiredGrid()
        {
            if(txtCash.Text == "" || txtCash.Text == "0" || txtCash.Text == "0.00" )
            {
                MessageBox.Show("Please Enter Amount Here...", "INVALID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCash.Focus();
                return false;
            }
            if(gCardID == 0)
            {
                MessageBox.Show("Please Select Your Card Type", "INVALID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbType.Focus();
                return false;
            }
            if(gBankID == 0)
            {
                MessageBox.Show("Please Select Your Bank", "INVALID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbBank.Focus();
                return false;
            }
            return true;
        }

        private void txtCash_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if (IsRequiredGrid())
                {
                    AddingGrid(gCardID, cmbType.Text, gBankID, cmbBank.Text, Convert.ToDouble(txtCash.Text.Trim()));
                    lblGossTotal.Text = string.Format("{0:N}", CalcAmount());
                    txtCash.Text = "0.00";
                    cmbType.Focus();
                }
            }
        }

        private double CalcAmount()
        {
            double tmpAmount = 0;
            for (int i = 0; i < dgvCCard.Rows.Count; i++)
            {
                tmpAmount += Convert.ToDouble(dgvCCard.Rows[i].Cells[4].Value);
            }
            return tmpAmount;
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cmbBank_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cmbType_Validating(object sender, CancelEventArgs e)
        {
            if (cmbType.Items.Count == 0)
                return;

            gCardID = Convert.ToInt32(cmbType.SelectedValue);
        }

        private void cmbBank_Validating(object sender, CancelEventArgs e)
        {
            if (cmbBank.Items.Count == 0)
                return;

            gBankID = Convert.ToInt32(cmbBank.SelectedValue);
        }

        private void dgvCCard_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                int rowIndex = dgvCCard.CurrentRow.Index;

                if (rowIndex == dgvCCard.NewRowIndex || rowIndex < 0)
                    return;

                dgvCCard.Rows.RemoveAt(rowIndex);
                lblGossTotal.Text = string.Format("{0:N}", CalcAmount());
            }
        }

        private void dgvCCard_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == dgvCCard.NewRowIndex || e.RowIndex < 0)
                return;

            if (e.ColumnIndex == dgvCCard.Columns["Column4"].Index)
            {
                dgvCCard.Rows.RemoveAt(e.RowIndex);
                lblGossTotal.Text = string.Format("{0:N}", CalcAmount());
            }
        }

        private Boolean IsRequired()
        {
            //if (Convert.ToDouble(lblGossTotal.Text) != gTotalAmount)
            //{
            //    MessageBox.Show("Sorry.. Card Amount Should be Equal to Nettotal.", "INVALID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return false;
            //}
            if(dgvCCard.Rows.Count == 0)
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

        private void cmbType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbBank.Focus();
        }

        private void cmbBank_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtCash.Focus();
        }
    }
}
