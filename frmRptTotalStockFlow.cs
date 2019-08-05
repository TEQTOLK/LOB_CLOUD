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
    public partial class frmRptTotalStockFlow : Form
    {
        private int gItemID = 0;
        StringBuilder gSB = new StringBuilder();
        GlobalData GlbData = new GlobalData();
        PrintReport print = new PrintReport();
        private int gCatID = 0;
        private int gSupplierID = 0;
        private int gStockroomID = 0;
        private int gBranchID = 0;
        DataTable dataTable = new DataTable();

        public frmRptTotalStockFlow()
        {
            InitializeComponent();
        }

        private void frmRptSales_Load(object sender, EventArgs e)
        {
            ClearLocal();
            GlbData.FillComboBoxALL(cboStockroom, "tblStockRoom", " ORDER BY NameOf");
            FillBranch();
            cboDateRange.SelectedIndex = 1;
        }

        public void FillBranch()
        {
            try
            {
                string strQuery = " SELECT CustID, ADD1 + ' - ' + CITY AS NameOf FROM tblCompany ORDER BY NameOF";
                dataTable = GlbData.getDataTable(strQuery);

                cboBranch.Items.Clear();
                DataRow row = dataTable.NewRow();
                row["NameOF"] = "ALL";
                dataTable.Rows.InsertAt(row, 0);

                cboBranch.DataSource = dataTable;
                cboBranch.ValueMember = "CustID";
                cboBranch.DisplayMember = "NameOF";

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                dataTable = null;
            }
        }

        private string getBranchID()
        {
            if (cboBranch.Text.Trim() == "")
                return " ";

            if (cboBranch.SelectedIndex == 0)
                return " ";
            else
                return "  AND BC.CompID = " + gBranchID + " ";
        }

        private void ClearLocal()
        {
            cboBasedOn.SelectedIndex = 0;
            cboReportType.SelectedIndex = 0;
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

            InsertRecord();

            //switch (cboReportType.SelectedIndex)
            //{
            //    case 0:
            //        switch (cboBasedOn.SelectedIndex)
            //        {
            //            case 0:
            //                tmpQuery = getQuery() + getStockroomID(); ;
            //                print.RoadToPrintReport(tmpQuery, @"C:\LOB\Bin\Debug\Rep\StockAudit.rpt", rptView);
            //                break;
            //            case 1:
            //                tmpQuery = getQuery() + getProductID() + getStockroomID();
            //                print.RoadToPrintReport(tmpQuery, @"C:\LOB\Bin\Debug\Rep\StockAudit.rpt", rptView);
            //                break;
            //            case 2:
            //                tmpQuery = getQuery() + getCatID() + getStockroomID();
            //                print.RoadToPrintReport(tmpQuery, @"C:\LOB\Bin\Debug\Rep\STKAuditCAT.rpt", rptView);
            //                break;
            //            case 3:
            //                tmpQuery = getQuery() + getSupplierID() + getStockroomID();
            //                print.RoadToPrintReport(tmpQuery, @"C:\LOB\Bin\Debug\Rep\STKAuditSUP.rpt", rptView);
            //                break;
            //            default:
            //                break;
            //        }
            //        break;
            //    case 1:
            //        switch (cboBasedOn.SelectedIndex)
            //        {
            //            case 0:
            //                tmpQuery = getQuery() + getStockroomID(); ;
            //                print.RoadToPrintReport(tmpQuery, @"C:\LOB\Bin\Debug\Rep\STKCostPrice.rpt", rptView);
            //                break;
            //            case 1:
            //                tmpQuery = getQuery() + getProductID() + getStockroomID();
            //                print.RoadToPrintReport(tmpQuery, @"C:\LOB\Bin\Debug\Rep\STKCostPrice.rpt", rptView);
            //                break;
            //            case 2:
            //                tmpQuery = getQuery() + getCatID() + getStockroomID();
            //                print.RoadToPrintReport(tmpQuery, @"C:\LOB\Bin\Debug\Rep\STKCostPriceCAT.rpt", rptView);
            //                break;
            //            case 3:
            //                tmpQuery = getQuery() + getSupplierID() + getStockroomID();
            //                print.RoadToPrintReport(tmpQuery, @"C:\LOB\Bin\Debug\Rep\STKCostPriceSUP.rpt", rptView);
            //                break;
            //            default:
            //                break;
            //        }
            //        break;
            //    case 2:
            //        switch (cboBasedOn.SelectedIndex)
            //        {
            //            case 0:
            //                tmpQuery = getQuery() + getStockroomID(); ;
            //                print.RoadToPrintReport(tmpQuery, @"C:\LOB\Bin\Debug\Rep\STKSellingPrice.rpt", rptView);
            //                break;
            //            case 1:
            //                tmpQuery = getQuery() + getProductID() + getStockroomID();
            //                print.RoadToPrintReport(tmpQuery, @"C:\LOB\Bin\Debug\Rep\STKSellingPrice.rpt", rptView);
            //                break;
            //            case 2:
            //                tmpQuery = getQuery() + getCatID() + getStockroomID();
            //                print.RoadToPrintReport(tmpQuery, @"C:\LOB\Bin\Debug\Rep\STKSellingPriceCAT.rpt", rptView);
            //                break;
            //            case 3:
            //                tmpQuery = getQuery() + getSupplierID() + getStockroomID();
            //                print.RoadToPrintReport(tmpQuery, @"C:\LOB\Bin\Debug\Rep\STKSellingPriceSUP.rpt", rptView);
            //                break;
            //            default:
            //                break;
            //        }
            //        break;
            //    case 3:
            //        switch (cboBasedOn.SelectedIndex)
            //        {
            //            case 0:
            //                tmpQuery = getQuery() + getStockroomID(); ;
            //                print.RoadToPrintReport(tmpQuery, @"C:\LOB\Bin\Debug\Rep\STKWholeSalePrice.rpt", rptView);
            //                break;
            //            case 1:
            //                tmpQuery = getQuery() + getProductID() + getStockroomID();
            //                print.RoadToPrintReport(tmpQuery, @"C:\LOB\Bin\Debug\Rep\STKWholeSalePrice.rpt", rptView);
            //                break;
            //            case 2:
            //                tmpQuery = getQuery() + getCatID() + getStockroomID();
            //                print.RoadToPrintReport(tmpQuery, @"C:\LOB\Bin\Debug\Rep\STKWholeSalePriceCAT.rpt", rptView);
            //                break;
            //            case 3:
            //                tmpQuery = getQuery() + getSupplierID() + getStockroomID();
            //                print.RoadToPrintReport(tmpQuery, @"C:\LOB\Bin\Debug\Rep\STKWholeSalePriceSUP.rpt", rptView);
            //                break;
            //            default:
            //                break;
            //        }
            //        break;
            //    default:
            //        break;
            //}
            

            btnShow.Enabled = true;
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

        private string getStockroomID()
        {
            if (cboStockroom.Text.Trim() == "")
                return " ";

            if (cboStockroom.SelectedIndex == 0)
                return " ";
            
        
            if(cboBasedOn.SelectedIndex==0)
                return "  WHERE ST.CustID = " + gStockroomID + " ";
            else
                return "  AND ST.CustID = " + gStockroomID + " ";

        }

        private string getQuery()
        {
            return " SELECT IT.Code AS CUCode, IT.NameOF AS CUName, MC.NameOF AS CUAdd1,  " +
                " SU.NameOF AS CUAdd2, ISNULL(STK.Qty,0) AS UnitPrice, ST.CustID AS Discount, ST.NameOF AS Name, " +
                " IT.WholeSalePrice AS TotalAmount, MC.CustID AS Qty, SU.CustID AS BRPaidAmount, IT.Cost AS Cost, " +
                " IT.SellingPrice AS Selling, IT.WholeSalePrice AS WholeSale " +
                " FROM tblItem AS IT LEFT OUTER JOIN " +
                " tblComSTKStore AS STK ON IT.CustID = STK.ItemID INNER JOIN " +
                " tblStockRoom AS ST ON ST.CustID = STK.StockRoomID INNER JOIN " +
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

        private void cboStockroom_Validating(object sender, CancelEventArgs e)
        {
            if (cboStockroom.Text == "")
                return;

            if (cboStockroom.SelectedIndex == 0)
                gStockroomID = 0;
            else
                gStockroomID = Convert.ToInt32(cboStockroom.SelectedValue);

        }

        private void rptView_Load(object sender, EventArgs e)
        {

        }

        private void cboBranch_Validating(object sender, CancelEventArgs e)
        {
            if (cboBranch.Text == "")
                return;

            if (cboBranch.SelectedIndex == 0)
                gBranchID = 0;
            else
                gBranchID = Convert.ToInt32(cboBranch.SelectedValue);
        }

        private void InsertRecord()
        {
            gSB.Clear();
            gSB.Append("TRUNCATE TABLE tblTEMPStockFlow ");
            MySqlCommand com1 = new MySqlCommand(gSB.ToString(), GlobalData.GCon);
            com1.ExecuteNonQuery();

            gSB.Clear();
            gSB.Append("INSERT INTO tblTEMPStockFlow (ItemID, CompID, StockRoomID) " +
                " SELECT ItemID, CompID, StockRoomID FROM tblComSTKStore ");
            MySqlCommand com2 = new MySqlCommand(gSB.ToString(), GlobalData.GCon);
            com2.ExecuteNonQuery();


        }
    }
}
