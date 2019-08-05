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
    public partial class frmCHQDepositPOP : Form
    {
        public string gNotes = "";
        public DateTime gDepositedOn = new DateTime();
        public string gDepositedBy = "";
        public int gBankID = 0;
        public bool gOkCancel = false;

        GlobalData GlbData = new GlobalData();

        public frmCHQDepositPOP()
        {
            InitializeComponent();
        }


        private void FillBank()
        {
            cmbBank.DataSource = GlbData.getDataSet("SELECT CustID, Code + ' - ' + NameOF AS NameOF FROM tblBankAccount ", "tblBankAccount").Tables[0];
            cmbBank.ValueMember = "CustID";
            cmbBank.DisplayMember = "NameOF";
        }


        private void frmCHQDepositPOP_Load(object sender, EventArgs e)
        {
            FillBank();
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cmbBank_Validating(object sender, CancelEventArgs e)
        {
            if (cmbBank.Text == "")
                return;
            else
                gBankID = Convert.ToInt32(cmbBank.SelectedValue);

            lblAccNo.Text = cmbBank.Text;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(IsRequired())
            {
                if (cmbBank.Text == "")
                    return;
                else
                    gBankID = Convert.ToInt32(cmbBank.SelectedValue);

                gOkCancel = true;
                this.Hide();
            }
        }


        private bool IsRequired()
        {
            if (cmbBank.Text == "")
            {
                MessageBox.Show("Empty Bank", "Empty Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbBank.Focus();
                return false;
            }
            if (txtName.Text == "")
            {
                MessageBox.Show("Empty Depositor Name", "Empty Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtName.Focus();
                return false;
            }

            return true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            gOkCancel = false ;
            this.Hide();
        }
    }
}
