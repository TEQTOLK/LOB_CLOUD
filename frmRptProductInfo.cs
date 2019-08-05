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
    public partial class frmRptProductInfo : Form
    {
        private int gItemID = 0;
        StringBuilder gSB = new StringBuilder();
        GlobalData GlbData = new GlobalData();
        PrintReport print = new PrintReport();
        private int gCatID = 0;
        private int gSupplierID = 0;

        public frmRptProductInfo()
        {
            InitializeComponent();
        }

        private void frmRptSales_Load(object sender, EventArgs e)
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
                    pnlCategoy.Visible = false;
                    pnlSupplier.Visible = false;
                    break;
                case 1:
                    pnlAllCustomer.Visible = false;
                    pnlPartiCus.Visible = true;
                    pnlCategoy.Visible = false;
                    pnlSupplier.Visible = false;
                    break;
                case 2:
                    pnlAllCustomer.Visible = false;
                    pnlPartiCus.Visible = false;
                    pnlCategoy.Visible = true;
                    pnlSupplier.Visible = false;
                    break;
                case 3:
                    pnlAllCustomer.Visible = false;
                    pnlPartiCus.Visible = false;
                    pnlCategoy.Visible = false;
                    pnlSupplier.Visible = true;
                    break;
                default:
                    break;
            }
        }

        private void btnFCus_Click(object sender, EventArgs e)
        {
            frmIPSearch f = new frmIPSearch();
            f.ShowDialog();

            if (f.gOkCancel == true)
            {
                txtCusCode.Text = f.CODE;
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
                return;

            gSB.Clear();
            gSB.Append("SELECT * FROM tblItem WHERE Code = '" + txtCusCode.Text.Trim() + "' AND IsActive = 'Y'");
            if (GlbData.AlreadyExist(gSB.ToString()))
            {
                gItemID = Convert.ToInt32(GlbData.GetValue(gSB.ToString(), "CustID"));
                lblCustomer.Text = GlbData.GetValue(gSB.ToString(), "NameOF");
            }
            else
            {
                MessageBox.Show("Sorry.. This Product does not Exist", "INVALID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCusCode.Focus();
                return;
            }
        }
        

        private void btnShow_Click(object sender, EventArgs e)
        {
            btnShow.Enabled = false;
            string tmpQuery = "";

            switch (cboBasedOn.SelectedIndex)
            {
                case 0:
                    tmpQuery = getQuery();
                    print.RoadToPrintReport(tmpQuery, @"C:\LOB\Bin\Debug\Rep\ProductInfo.rpt", rptView);
                    break;
                case 1:
                    tmpQuery = getQuery() + getProductID();
                    print.RoadToPrintReport(tmpQuery, @"C:\LOB\Bin\Debug\Rep\ProductInfo.rpt", rptView);
                    break;
                case 2:
                    tmpQuery = getQuery() + getCatID();
                    print.RoadToPrintReport(tmpQuery, @"C:\LOB\Bin\Debug\Rep\ProductInfoCAT.rpt", rptView);
                    break;
                case 3:
                    tmpQuery = getQuery() + getSupplierID();
                    print.RoadToPrintReport(tmpQuery, @"C:\LOB\Bin\Debug\Rep\ProductInfoSUP.rpt", rptView);
                    break;
                default:
                    break;
            }

            btnShow.Enabled = true;
        }

        private void cboMOP_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        
        private string getProductID()
        {
            if (txtCusCode.Text.Trim() == "")
                return " ";
            else
                return " WHERE IT.CustID = " + gItemID + " ";
        }

        private string getCatID()
        {
            if (txtCategory.Text.Trim() == "")
                return " ";
            else
                return " WHERE IT.CategoryID = " + gCatID + " ";
        }

        private string getSupplierID()
        {
            if (txtSupCode.Text.Trim() == "")
                return " ";
            else
                return " WHERE IT.SupplierID = " + gSupplierID + " ";
        }

        private string getQuery()
        {
            return " SELECT IT.Code AS CUCode, IT.NameOF AS CUName, MC.NameOF AS CUAdd1,  " +
                " SU.NameOF AS CUAdd2, IT.Cost AS UnitPrice, IT.SellingPrice AS Discount, " +
                " IT.WholeSalePrice AS TotalAmount, MC.CustID AS Qty, SU.CustID AS BRPaidAmount " +
                " FROM tblItem AS IT LEFT OUTER JOIN " +
                " tblSupplier AS SU ON IT.SupplierID = SU.CustID LEFT OUTER JOIN " +
                " tblMajorCategory AS MC ON IT.CategoryID = MC.CustID ";
        }

        private void btnCFind_Click(object sender, EventArgs e)
        {
            frmIPSearchCommon f = new frmIPSearchCommon();
            f.gTableName = "tblMajorCategory";
            f.ShowDialog();
            if (f.gOkCancel == true)
            {
                txtCategory.Text = f.CODE;
                //gMajorCatID = f1.CUSTID;
                //lblCategory.Text = f1.NAME;
                txtCategory.Focus();
            }
        }

        private void txtCategory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                btnCFind.PerformClick();
        }

        private void txtCategory_Validating(object sender, CancelEventArgs e)
        {
            if (txtCategory.Text == "")
            {
                txtCategory.Clear();
                lblCategory.Text = "";
                return;
            }

            gSB.Clear();
            gSB.Append("SELECT * FROM tblMajorCategory WHERE Code = '" + txtCategory.Text.Trim() + "' AND IsActive = 'Y' ");
            if (GlbData.AlreadyExist(gSB.ToString()) == false)
            {
                MessageBox.Show("Sorry.. This Category does not exist", "INVALID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lblCategory.Focus();
                return;
            }
            else
            {
                gCatID = Convert.ToInt32(GlbData.GetValue(gSB.ToString(), "CustID"));
                lblCategory.Text = GlbData.GetValue(gSB.ToString(), "NameOF");
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSFind_Click(object sender, EventArgs e)
        {
            frmIPSearchDealer f = new frmIPSearchDealer();
            f.TABLE_NAME = "tblSupplier";
            f.ShowDialog();
            if (f.gOkCancel == true)
            {
                txtSupCode.Text = f.CODE;
                gSupplierID = f.CUSTID;
                lblSupplier.Text = f.NAME;
                txtSupCode.Focus();
            }
        }

        private void txtSupCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                btnSFind.PerformClick();
        }

        private void txtSupCode_Validating(object sender, CancelEventArgs e)
        {
            if (txtSupCode.Text == "")
            {
                lblSupplier.Text = "";
                return;
            }

            gSB.Clear();
            gSB.Append("SELECT Code FROM tblSupplier WHERE Code = '" + txtSupCode.Text.Trim() + "' ");
            if (!GlbData.AlreadyExist(gSB.ToString()))
            {
                MessageBox.Show("Sorry.. This Supplier does not exist", "INVALID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSupCode.Focus();
                return;
            }
        }
    }
}
