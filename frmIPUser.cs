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
    public partial class frmIPUser : Form
    {
        private int gUserGroupID = 0;
        private int gCompID = 0;
        private Boolean gEditTag = false;
        private int gUserID = 0;

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

        public frmIPUser()
        {
            InitializeComponent();
        }

        private void ClearLocal()
        {
            txtBackCode.Clear();
            txtEmail.Clear();
            txtPassword.Clear();
            txtRetypePassword.Clear();
            txtUserName.Clear();
            FillCompany();
            FillUserGroup();
        }

        private void FillCompany()
        {
            string cQuery = "SELECT CustID, NameOf + ' - ' + City AS Name  FROM tblCompany WHERE IsActive = 'Y' ORDER BY NameOF";
            cmbCompany.DataSource = GlbData.getDataSet(cQuery, "tblCompany").Tables[0];
            cmbCompany.ValueMember = "CustID";
            cmbCompany.DisplayMember = "Name";
        }

        private void FillUserGroup()
        {
            string cQuery = "SELECT * FROM tblUserGroup ORDER BY NameOF";
            cmbUserGroup.DataSource = GlbData.getDataSet(cQuery, "tblUserGroup").Tables[0];
            cmbUserGroup.ValueMember = "CustID";
            cmbUserGroup.DisplayMember = "NameOF";
        }

        private void cmbUserGroup_Validating(object sender, CancelEventArgs e)
        {
            if (cmbUserGroup.Text == "")
                return;
            else
                gUserGroupID = Convert.ToInt32(cmbUserGroup.SelectedValue);
        }

        private void cmbCompany_Validating(object sender, CancelEventArgs e)
        {
            if (cmbUserGroup.Text == "")
                return;
            else
                gCompID = Convert.ToInt32(cmbCompany.SelectedValue);
        }

        private bool IsRequired()
        {
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
            if (cmbUserGroup.Text == "")
            {
                MessageBox.Show("Empty User Group", "Empty Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbUserGroup.Focus();
                return false;
            }
            if (cmbCompany.Text == "")
            {
                MessageBox.Show("Empty Company Name", "Empty Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbCompany.Focus();
                return false;
            }
            if (txtPassword.Text == "")
            {
                MessageBox.Show("Empty Password", "Empty Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPassword.Focus();
                return false;
            }
            if (txtEmail.Text == "")
            {
                MessageBox.Show("Empty Email", "Empty Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmail.Focus();
                return false;
            }
            if (txtBackCode.Text == "")
            {
                MessageBox.Show("Empty Backup Code", "Empty Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBackCode.Focus();
                return false;
            }
            if (txtPassword.Text != txtRetypePassword.Text)
            {
                MessageBox.Show("Passwords are mismatch", "Empty Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtRetypePassword.Clear();
                txtPassword.Focus();
                return false;
            }
            gSB.Clear();
            gSB.Append("SELECT UserName FROM tblSysUsers WHERE UserName = '" + txtUserName.Text.Trim() + "' ");
            if(GlbData.AlreadyExist(gSB.ToString()))
            {
                MessageBox.Show("Sorry... This Username Aleady Exist", "Empty Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUserName.Focus();
                return false;
            }

            gSB.Clear();
            gSB.Append("SELECT Password FROM tblSysUsers WHERE Password = '" + HashCode(txtPassword.Text.Trim()) + "' ");
            if (GlbData.AlreadyExist(gSB.ToString()))
            {
                MessageBox.Show("Sorry... This Password Aleady Exist", "Empty Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPassword.Focus();
                return false;
            }

            gSB.Clear();
            gSB.Append("SELECT PinCode FROM tblSysUsers WHERE PinCode = '" + HashCode(txtBackCode.Text.Trim()) + "' ");
            if (GlbData.AlreadyExist(gSB.ToString()))
            {
                MessageBox.Show("Sorry... This PinCode Aleady Exist", "Empty Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBackCode.Focus();
                return false;
            }

            return true;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearLocal();
            txtCode.Text = "";
            txtCode.Focus();
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

        private long SaveOrUpdateUser()
        {
            long tmpID = 0;
            masterFiles.Code = txtCode.Text.Trim();
            masterFiles.UserName = txtUserName.Text.Trim();
            masterFiles.Password = HashCode(txtPassword.Text.Trim());
            masterFiles.EmailID = txtEmail.Text.Trim();
            masterFiles.CompID = gCompID;
            masterFiles.CompName = cmbCompany.Text.Trim();
            masterFiles.IsActive = "Y";
            masterFiles.Mobile = "";
            masterFiles.PerformedBy = GlobalData.GUsername;
            masterFiles.UserGroupID = gUserGroupID;
            masterFiles.BackupCode = HashCode(txtBackCode.Text.Trim());
            masterFiles.CompName = GlobalData.GCompName;

            if (gEditTag == true)
            {
                masterFiles.UpdateSysUser(txtCode.Text.Trim());
                tmpID = 1;
            }
            else
                tmpID = masterFiles.SaveSysUser();

            return tmpID;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsRequired())
            {
                if (fConfirm.SayMessage("SV") == true)
                {
                    long tmpKeyHolder = 0;
                    tmpKeyHolder = SaveOrUpdateUser();

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
                gEditTag = true;
                btnDelete.Enabled = true;
                FillSysUsers();
            }
            else
            {
                gEditTag = false;
            }
        }

        private void FillSysUsers()
        {
            masterFiles.FillSysUsers(txtCode.Text.Trim());
            gUserID = masterFiles.CustID;
            txtUserName.Text = masterFiles.UserName;
            gUserGroupID = masterFiles.UserGroupID;
            cmbUserGroup.SelectedValue = gUserGroupID;
            gCompID = masterFiles.CompID;
            cmbCompany.SelectedValue = gCompID;
            txtEmail.Text = masterFiles.EmailID;
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

        private void frmIPUser_Load(object sender, EventArgs e)
        {
            ClearLocal();
        }

        private bool IsRequiredDel()
        {
            if(IsRequired())
            {
                gSB.Clear();
                gSB.Append("SELECT * FROM tblSaleBrief WHERE UserID = " + gUserID + " ");
                if(GlbData.AlreadyExist(gSB.ToString()))
                {
                    MessageBox.Show("Unable to delete user.. This user is used for another process", "Empty Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                return true;
            }
            return false;
        }

        private long DeleteUser()
        {
            MySqlCommand command = new MySqlCommand("DELETE FROM tblSysUsers WHERE Code = '" + txtCode.Text.Trim() + "' ", GlobalData.GCon);
            command.ExecuteNonQuery();
            return 1;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (fConfirm.SayMessage("DL") == true)
            {
                long tmpKeyHolder = 0;
                tmpKeyHolder = DeleteUser();

                if (tmpKeyHolder == 0)
                {
                    GlbData.SayMessage("Delete Failed!!!", 0, "");
                }
                else
                {
                    GlbData.SayMessage("Delete Success!!!", 1, "");
                    ClearLocal();
                    txtCode.Clear();
                    txtCode.Focus();
                }
            }
        }
    }
}
