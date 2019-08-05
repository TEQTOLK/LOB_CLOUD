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
    public partial class frmIPSetCustomer : Form
    {
        private int gCustID = 0;
        private bool gEditFlag = false;

        GlobalData GlbData = new GlobalData();
        DataSet dSet = new DataSet();
        StringBuilder gSB = new StringBuilder();
        MasterFiles masterFiles = new MasterFiles();
        Transactions tran = new Transactions();
        frmConfirmMessage fConfirm = new frmConfirmMessage();

        public frmIPSetCustomer()
        {
            InitializeComponent();
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            frmIPCustomer f = new frmIPCustomer();
            f.ShowDialog();
        }

        private void btnFSupp_Click(object sender, EventArgs e)
        {
            frmIPSearchDealer f = new frmIPSearchDealer();
            f.TABLE_NAME = "tblCustomer";
            f.ShowDialog();
            if (f.gOkCancel == true)
            {
                txtSuppCode.Text = f.CODE;
                gCustID = f.CUSTID;
                txtSuppCode.Focus();
            }
        }

        private void txtSuppCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down) btnFSupp.PerformClick();
        }

        private void txtSuppCode_Validating(object sender, CancelEventArgs e)
        {
            if (txtSuppCode.Text == "")
            {
                lblSupplier.Text = "";
                return;
            }

            gSB.Clear();
            gSB.Append("SELECT Code FROM tblCustomer WHERE Code = '" + txtSuppCode.Text.Trim() + "' ");
            if (GlbData.AlreadyExist(gSB.ToString()))
            {
                fillCustomer();
            }
            else
            {
                MessageBox.Show("Sorry.. This Customer does not exist", "INVALID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSuppCode.Focus();
                return;
            }
        }

        private void fillCustomer()
        {
            masterFiles.FillCustomer(txtSuppCode.Text.Trim());
            lblSupplier.Text = masterFiles.NameOF;
            gCustID = masterFiles.CustID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool IsRequired()
        {
            if (txtSuppCode.Text.Trim() == "")
            {
                MessageBox.Show("Empty Customer", "INVALID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSuppCode.Focus();
                return false;
            }
            return true;
        }

        private long SaveCustomer()
        {
            if (gEditFlag == true)
            {
                MySqlCommand cmd = new MySqlCommand("UPDATE tblDefSetting SET ID = " + gCustID + " WHERE TranCode = 'DEFCUS' ", GlobalData.GCon);
                cmd.ExecuteNonQuery();
                return 1;
            }
            else
            {
                MySqlCommand cmd = new MySqlCommand("INSERT INTO tblDefSetting(ID, TranCode) VALUES(" + gCustID + ", 'DEFCUS') ", GlobalData.GCon);
                cmd.ExecuteNonQuery();
                return 1;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsRequired())
            {
                if (fConfirm.SayMessage("SV") == true)
                {
                    long tmpKeyHolder = 0;
                    tmpKeyHolder = SaveCustomer();

                    if (tmpKeyHolder == 0)
                    {
                        GlbData.SayMessage("Save Failed!!!", 0, "");
                    }
                    else
                    {
                        GlbData.SayMessage("Save Success!!!", 1, "");
                    }
                }
            }
        }

        private void FillCustomer()
        {
            gSB.Clear();
            gSB.Append("SELECT CU.Code, CU.NameOf, SE.ID FROM tblDefSetting AS SE INNER JOIN tblCustomer AS CU ON SE.ID = CU.CustID WHERE SE.TranCode = 'DEFCUS'");
            DataTable dataTable = new DataTable();
            dataTable = GlbData.getDataTable(gSB.ToString());

            foreach (DataRow dRow in dataTable.Rows)
            {
                txtSuppCode.Text = dRow["Code"].ToString();
                lblSupplier.Text = dRow["NameOf"].ToString();
                gCustID = Convert.ToInt32(dRow["ID"]);
            }

            dataTable = null;
        }

        private void frmIPSetCustomer_Load(object sender, EventArgs e)
        {
            gSB.Clear();
            gSB.Append("SELECT * FROM tblDefSetting WHERE TranCode = 'DEFCUS'");
            if (GlbData.AlreadyExist(gSB.ToString()))
            {
                gEditFlag = true;
                FillCustomer();
            }             
            else
                gEditFlag = false;
        }
    }
}
