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
    public partial class frmIPLogin : Form
    {
        GlobalData globalData = new GlobalData();
        private int LoginAttempts = 0;
        private int gUserGroupID = 0;
        DataTable dataTable = new DataTable();
        MySqlDataAdapter sqlAdapter = new MySqlDataAdapter();

        public frmIPLogin()
        {
            InitializeComponent();
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

        private void Login()
        {
            string tmpHolder = "SELECT Username, Password FROM tblSysUsers WHERE Username = '" + txtUsername.Text.Trim() + "' AND Password ='" + HashCode(txtPassword.Text.Trim()) + "'";
            if (globalData.AlreadyExist(tmpHolder) == true)
            {
                string tmpHolderAuth = "SELECT * FROM tblServerAuth WHERE MacAddress='" + GlobalData.GetMACAddress() + "'";
                if (globalData.AlreadyExist(tmpHolderAuth) == true)
                {
                    DateTime tmpSDate = Convert.ToDateTime(globalData.GetValue(tmpHolderAuth, "StartDate"));
                    DateTime tmpEDate = Convert.ToDateTime(globalData.GetValue(tmpHolderAuth, "EndDate"));

                    var Different = tmpEDate - DateTime.Now;
                    double tmpDays = Different.TotalDays;
                    if (tmpDays == 0 || tmpDays < 0)
                    {
                        MessageBox.Show("Your Software License is Upto Date, Please Purchase License ", "Authendication Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        getUserInfo();
                        getCompanyInfo();
                        GlobalData.GCompName = globalData.GetValue("SELECT * FROM tblCompany WHERE CustID=" + GlobalData.GCompID + "", "NameOF");
                        GlobalData.GUserGroup = globalData.GetValue("SELECT * FROM tblUserGroup WHERE CustID=" + gUserGroupID + "", "NameOF");

                        string stockRommID = globalData.GetValue("SELECT * FROM tblSetCompStockRoom WHERE CompID = " + GlobalData.GCompID + "", "StockRoomID");
                        if (string.IsNullOrEmpty(stockRommID))
                            GlobalData.GStockRoomID = 0;
                        else
                            GlobalData.GStockRoomID = Convert.ToInt32(stockRommID);

                        this.Hide();

                        frmIPMain f = new frmIPMain();
                        f.ShowDialog();
                    }

                }
                else
                {
                    MessageBox.Show("Sorry.. This PC don't have license ", "Authendication Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else
            {
                LoginAttempts += 1;
                MessageBox.Show("Sorry.. Username/ Password is incorrect", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (LoginAttempts == 3)
                {
                    Environment.Exit(0);
                }
                return;
            }
        }

        public void getUserInfo()
        {
            string tmpHolder = "SELECT * FROM tblSysUsers WHERE Username = '" + txtUsername.Text.Trim() + "' AND Password ='" + HashCode(txtPassword.Text.Trim()) + "'";
            MySqlCommand MySqlCommand = new MySqlCommand();
            {
                MySqlCommand.Connection = GlobalData.GCon;
                MySqlCommand.CommandType = CommandType.Text;
                MySqlCommand.CommandText = tmpHolder;
            }

            sqlAdapter = new MySqlDataAdapter();
            dataTable = new DataTable();
            {
                sqlAdapter.SelectCommand = MySqlCommand;
                sqlAdapter.Fill(dataTable);
            }

            foreach (DataRow dROW in dataTable.Rows)
            {
                GlobalData.GUserID = Convert.ToInt32(dROW["CustID"]);
                GlobalData.GUsername = dROW["Username"].ToString();
                GlobalData.GMacAddress = dROW["MacAddress"].ToString();
                GlobalData.GServerName = dROW["ServerName"].ToString();
                GlobalData.GCompID = Convert.ToInt32(dROW["CompID"]);
                gUserGroupID = Convert.ToInt32(dROW["UserGroupID"]);
            }

            dataTable = null;
        }

        public void getCompanyInfo()
        {
            string tmpHolder = "SELECT * FROM tblCompany WHERE CustID=" + GlobalData.GCompID + "";
            MySqlCommand MySqlCommand = new MySqlCommand();
            {
                MySqlCommand.Connection = GlobalData.GCon;
                MySqlCommand.CommandType = CommandType.Text;
                MySqlCommand.CommandText = tmpHolder;
            }

            sqlAdapter = new MySqlDataAdapter();
            dataTable = new DataTable();
            {
                sqlAdapter.SelectCommand = MySqlCommand;
                sqlAdapter.Fill(dataTable);
            }

            foreach (DataRow dROW in dataTable.Rows)
            {
                GlobalData.GUserID = Convert.ToInt32(dROW["CustID"]);
                GlobalData.GCompName = dROW["NameOF"].ToString();
                GlobalData.GAddress = dROW["Add1"].ToString() + " " + dROW["Add2"].ToString() + " " + dROW["City"].ToString();
                GlobalData.GTps = "TP(s) : " + dROW["Tp1"].ToString() + "," + dROW["Tp2"].ToString() + "," + dROW["Tp3"].ToString();
            }

            dataTable = null;
        }

        public Boolean IsRequired()
        {
            if(txtUsername.Text.Trim() == "")
            {
                MessageBox.Show("Sorry.. Empty Username", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return false;
            }
            if(txtPassword.Text.Trim() == "")
            {
                MessageBox.Show("Sorry.. Empty Password", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return false;
            }
            return true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(IsRequired())
            {
                Login();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnLogin.PerformClick();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnLogin.PerformClick();
        }

        private void frmIPLogin_Load(object sender, EventArgs e)
        {
            GlobalData.GCon = globalData.ConnectSQL();
        }
    }
}
