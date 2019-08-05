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
    public partial class frmIPChngPincode : Form
    {
        private int gUserID = 0;
        private string gPinCode = "";

        DataSet dSet = new DataSet();
        frmConfirmMessage fConfirm = new frmConfirmMessage();
        StringBuilder gSB = new StringBuilder();
        GlobalData GlbData = new GlobalData();
        DataTable dataTable = new DataTable();
        MySqlDataAdapter sqlAdapter = new MySqlDataAdapter();
        MasterFiles masterFiles = new MasterFiles();
        frmIPSearchDealer f = new frmIPSearchDealer();
        frmIPCommon fCommon = new frmIPCommon();
        frmIPSearchCommon f1 = new frmIPSearchCommon();

        public frmIPChngPincode()
        {
            InitializeComponent();
        }

        private void btnIFind_Click(object sender, EventArgs e)
        {
            frmIPSearchCommon f1 = new frmIPSearchCommon();
            f1.gTableName = "tblSysUsers";
            f1.isCustom = true;
            f1.gQuery = "SELECT SY.CustID, SY.Code, SY.Username AS NameOf, CM.NameOf AS DescriptionOf FROM tblSysUsers AS SY INNER JOIN tblCompany AS CM ON SY.CompID = CM.CustID";
            f1.ShowDialog();
            if (f1.gOkCancel == true)
            {
                txtCode.Text = f1.CODE;
                txtCode.Focus();
            }
        }

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                btnIFind.PerformClick();
        }

        private void ClearLocal()
        {
            txtUserName.Text = "";
            txtPassword.Text = "";
            txtRetypePassword.Text = "";
            txtOldPassword.Text = "";
        }

        public static string HashCode(string str)
        {
            string rethash = "";
            try
            {
                System.Security.Cryptography.SHA1 hash = System.Security.Cryptography.SHA1.Create();
                System.Text.ASCIIEncoding encorder = new ASCIIEncoding();
                byte[] combined = encorder.GetBytes(str);
                hash.ComputeHash(combined);
                rethash = Convert.ToBase64String(hash.Hash);
            }
            catch (Exception ex)
            { string msg = "Error in hash code"; }
            return rethash;

        }

        private void FillSysUsers()
        {
            masterFiles.FillSysUsers(txtCode.Text.Trim());
            txtUserName.Text = masterFiles.UserName;
            gUserID = masterFiles.CustID;
            gPinCode = HashCode(masterFiles.BackupCode);
        }

        private void txtCode_Validating(object sender, CancelEventArgs e)
        {
            if (txtCode.Text == "")
            {
                ClearLocal();
                txtCode.Clear();
                return;
            }

            gSB.Clear();
            gSB.Append("SELECT * FROM tblSysUsers WHERE Code = '" + txtCode.Text.Trim() + "' ");
            if (GlbData.AlreadyExist(gSB.ToString()))
            {
                FillSysUsers();
            }
            else
            {
                MessageBox.Show("Sorry.. This user does not exist", "Empty Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCode.Focus();
                return;
            }
        }

        private bool IsRequired()
        {
            if (txtPassword.Text == "")
            {
                MessageBox.Show("Empty Pin Code", "Empty Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPassword.Focus();
                return false;
            }
            if (txtPassword.Text != txtRetypePassword.Text)
            {
                MessageBox.Show("Pin Codes are mismatch", "Empty Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtRetypePassword.Clear();
                txtPassword.Focus();
                return false;
            }
            if (txtCode.Text == "")
            {
                MessageBox.Show("Empty Code", "Empty Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCode.Focus();
                return false;
            }
            if (txtUserName.Text == "")
            {
                MessageBox.Show("Empty UserName", "Empty Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUserName.Focus();
                return false;
            }
            if (txtOldPassword.Text != gPinCode)
            {
                MessageBox.Show("Old Pin Code is wrong..", "Empty Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtOldPassword.Focus();
                return false;
            }
            gSB.Clear();
            gSB.Append("SELECT PinCode FROM tblSysUsers WHERE PinCode = '" + HashCode(txtPassword.Text.Trim()) + "' ");
            if (GlbData.AlreadyExist(gSB.ToString()))
            {
                MessageBox.Show("Sorry... This PinCode Aleady Exist", "Empty Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPassword.Focus();
                return false;
            }

            return true;
        }

        private long UpdatePinCode()
        {
            MySqlCommand command = new MySqlCommand("UPDATE tblSysUsers SET BackupCode = '" + HashCode(txtPassword.Text.Trim()) + "' WHERE Code = '" + txtCode.Text.Trim() + "' ", GlobalData.GCon);
            command.ExecuteNonQuery();
            return 1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsRequired())
            {
                if (fConfirm.SayMessage("SV") == true)
                {
                    long tmpKeyHolder = 0;
                    tmpKeyHolder = UpdatePinCode();

                    if (tmpKeyHolder == 0)
                    {
                        GlbData.SayMessage("Save Failed!!!", 0, "");
                    }
                    else
                    {
                        GlbData.SayMessage("Save Success!!!", 1, "");
                        ClearLocal();
                        txtCode.Clear();
                        txtCode.Focus();
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearLocal();
            txtCode.Text = "";
            txtCode.Focus();
        }
    }
}
