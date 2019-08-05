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
    public partial class frmRptCUSList : Form
    {
        private int gCustID = 0;
        private int gAreaID = 0;

        StringBuilder gSB = new StringBuilder();
        GlobalData GlbData = new GlobalData();
        PrintReport print = new PrintReport();
        DataTable dataTable = new DataTable();
        MySqlDataAdapter sqlAdapter = new MySqlDataAdapter();

        public frmRptCUSList()
        {
            InitializeComponent();
        }

        private void frmRptCUSList_Load(object sender, EventArgs e)
        {
            ClearLocal();
        }

        private void ClearLocal()
        {
            cboBasedOn.SelectedIndex = 0;
        }

        private void cboBasedOn_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboBasedOn.SelectedIndex)
            {
                case 0:
                    pnlAllCustomer.Visible = true;
                    pnlPartiCus.Visible = false;
                    pnlArea.Visible = false;
                    txtAreaCode.Clear();
                    txtCusCode.Clear();
                    break;
                case 1:
                    pnlAllCustomer.Visible = false;
                    pnlPartiCus.Visible = true;
                    pnlArea.Visible = false;
                    txtAreaCode.Clear();
                    txtCusCode.Clear();
                    break;
                case 2:
                    pnlAllCustomer.Visible = false;
                    pnlPartiCus.Visible = false;
                    pnlArea.Visible = true;
                    txtAreaCode.Clear();
                    txtCusCode.Clear();
                    break;
                default:
                    break;
            }
        }

        private void btnFCus_Click(object sender, EventArgs e)
        {
            frmIPSearchDealer f = new frmIPSearchDealer();
            f.TABLE_NAME = "tblCustomer";
            f.ShowDialog();
            if (f.gOkCancel == true)
            {
                txtCusCode.Text = f.CODE;
                gCustID = f.CUSTID;
                lblCustomer.Text = f.NAME;
                txtCusCode.Focus();
            }
        }

        private void txtCusCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                btnFCus.PerformClick();
        }

        private void txtCusCode_Validating(object sender, CancelEventArgs e)
        {
            if (txtCusCode.Text == "")
            {
                lblCustomer.Text = "";
                return;
            }

            gSB.Clear();
            gSB.Append("SELECT Code FROM tblCustomer WHERE Code = '" + txtCusCode.Text.Trim() + "' ");
            if (!GlbData.AlreadyExist(gSB.ToString()))
            {
                MessageBox.Show("Sorry.. This Customer does not exist", "INVALID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCusCode.Focus();
                return;
            }
        }

        private void btnAFind_Click(object sender, EventArgs e)
        {
            frmIPSearchCommon f = new frmIPSearchCommon();
            f.gTableName = "tblArea";
            f.ShowDialog();
            if (f.gOkCancel == true)
            {
                txtAreaCode.Text = f.CODE;
                //gMajorCatID = f1.CUSTID;
                //lblCategory.Text = f1.NAME;
                txtAreaCode.Focus();
            }
        }

        private void txtAreaCode_Validating(object sender, CancelEventArgs e)
        {
            if (txtAreaCode.Text == "")
            {
                txtAreaCode.Clear();
                lblAreaName.Text = "";
                return;
            }

            gSB.Clear();
            gSB.Append("SELECT * FROM tblArea WHERE Code = '" + txtAreaCode.Text.Trim() + "' AND IsActive = 'Y' ");
            if (GlbData.AlreadyExist(gSB.ToString()) == false)
            {
                MessageBox.Show("Sorry.. This Area does not exist", "INVALID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAreaCode.Focus();
                return;
            }
            else
            {
                gAreaID = Convert.ToInt32(GlbData.GetValue(gSB.ToString(), "CustID"));
                lblAreaName.Text = GlbData.GetValue(gSB.ToString(), "NameOF");
            }
        }

        private void txtAreaCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                btnAFind.PerformClick();
        }

        private string getCorrectQuery()
        {
            return "SELECT  CU.Add1 + ', ' + CU.Add2 + ', ' + CU.City AS CUAdd1,  " +
                " CU.Tp1 + ', ' + CU.Tp2 + ', ' + CU.Tp3 AS CUTp1,  " +
                " CU.Code + ' - ' + CU.NameOF AS CUName, AR.NameOF AS BRBillNo, CU.AreaID AS Qty " +
                " FROM tblArea AS AR INNER JOIN " +
                " tblCustomer AS CU ON AR.CustID = CU.AreaID ";
        }

        private string getCustomerID()
        {
            if (txtCusCode.Text.Trim() == "")
                return " ";
            else
               return " WHERE CU.CustID = " + gCustID + " ";
        }

        private string getAreaID()
        {
            if (txtAreaCode.Text.Trim() == "")
                return " ";
            else
                return " WHERE CU.AreaID = " + gAreaID + " ";
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            btnShow.Enabled = false;

            string tmpQuery = getCorrectQuery() + getCustomerID() + getAreaID();
            print.RoadToPrintReport(tmpQuery, @"C:\LOB\Bin\Debug\Rep\CustomerList.rpt", rptView);

            btnShow.Enabled = true;
        }
    }
}
