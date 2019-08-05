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
    public partial class frmIPPOAnalizer : Form
    {
        GlobalData GlbData = new GlobalData();
        DataSet dSet = new DataSet();
        StringBuilder gSB = new StringBuilder();
        MasterFiles masterFiles = new MasterFiles();
        Transactions tran = new Transactions();
        frmConfirmMessage fConfirm = new frmConfirmMessage();
        DataTable dataTable = new DataTable();
        MySqlDataAdapter sqlAdapter = new MySqlDataAdapter();
        private int gItemId;
        private string gItemCode;
        private string gItemName;
        public bool gOkCancel = false;
        private int gBranchID = 0;
        private int gItemID;
        private int gCatID;
        private int gSupplierID;

        public frmIPPOAnalizer()
        {
            InitializeComponent();
        }

        private void ShowDetail()
        {
            gSB.Clear();
            gSB.Append("SELECT PO.ItemId, PO.ItemCode, PO.ItemName, PO.CategoryId, PO.CategoryCode, PO.CategoryName,  " +
                " PO.SupplierId, PO.SupplierName, PO.SupplierCode, PO.CostPrice, PO.SellingPrice, PO.WholeSalePrice, " +
                " PO.OpenStk, PO.Purchase, PO.PurchaseFree, PO.SCN, PO.SCNFree, PO.Sale, PO.SaleFree, PO.CCN, PO.CCNFree, PO.STKAdd, " +
                " PO.StkDED, PO.CloseStk, IT.BrandName FROM tblTEMPPOAnalyser AS PO INNER JOIN tblITEM AS IT ON IT.CustID = PO.ItemId ");
            dSet = GlbData.getDataSet(gSB.ToString(), "tblTEMPPOAnalyser");
            DataView dView = new DataView(dSet.Tables[0]);
            dgvGrid.DataSource = dView;
            SettingGrid();
        }

        public void SettingGrid()
        {
            dgvGrid.Columns[0].Visible = false; //ItemId
            dgvGrid.Columns[3].Visible = false;//CategoryId
            dgvGrid.Columns[4].Visible = false;//CategoryCode
            dgvGrid.Columns[6].Visible = false;//SupplierId
            dgvGrid.Columns[8].Visible = false;//SupplierCode
            dgvGrid.Columns[9].Visible = false;
            dgvGrid.Columns[10].Visible = false;
            dgvGrid.Columns[11].Visible = false;
            dgvGrid.Columns[12].Visible = false;
            dgvGrid.Columns[13].Visible = false;
            dgvGrid.Columns[14].Visible = false;
            dgvGrid.Columns[15].Visible = false;
            dgvGrid.Columns[16].Visible = false;
            dgvGrid.Columns[17].Visible = false;
            dgvGrid.Columns[18].Visible = false;
            dgvGrid.Columns[19].Visible = false;
            dgvGrid.Columns[20].Visible = false;
            dgvGrid.Columns[21].Visible = false;
            dgvGrid.Columns[22].Visible = false;
            dgvGrid.Columns[23].Visible = false;
            dgvGrid.Columns[24].Visible = false;

            dgvGrid.Columns[1].HeaderText = "Code";
            dgvGrid.Columns[1].Width = 100;
            dgvGrid.Columns[2].HeaderText = "Item Name";
            dgvGrid.Columns[2].Width = 250;
            dgvGrid.Columns[5].HeaderText = "Category";
            dgvGrid.Columns[5].Width = 150;
            dgvGrid.Columns[7].HeaderText = "Supplier";
            dgvGrid.Columns[7].Width = 220;
            //dgvGrid.Columns[9].HeaderText = "Cost Price";
            //dgvGrid.Columns[9].Width = 100;
            //dgvGrid.Columns[10].HeaderText = "Selling Price";
            //dgvGrid.Columns[10].Width = 100;
            //dgvGrid.Columns[11].HeaderText = "WholeSale Price";
            //dgvGrid.Columns[11].Width = 100;

            //dgvGrid.Columns[11].HeaderText = "Open STK";
            //dgvGrid.Columns[11].Width = 100;
            //dgvGrid.Columns[12].HeaderText = "Purchase";
            //dgvGrid.Columns[12].Width = 100;
            //dgvGrid.Columns[13].HeaderText = "Purchase Free";
            //dgvGrid.Columns[13].Width = 100;
            //dgvGrid.Columns[14].HeaderText = "SCN";
            //dgvGrid.Columns[14].Width = 100;
            //dgvGrid.Columns[15].HeaderText = "SCN Free";
            //dgvGrid.Columns[15].Width = 100;
            //dgvGrid.Columns[16].HeaderText = "Sale";
            //dgvGrid.Columns[16].Width = 100;
            //dgvGrid.Columns[17].HeaderText = "Sale Free";
            //dgvGrid.Columns[17].Width = 100;
            //dgvGrid.Columns[18].HeaderText = "CCN";
            //dgvGrid.Columns[18].Width = 100;
            //dgvGrid.Columns[19].HeaderText = "CCN Free";
            //dgvGrid.Columns[19].Width = 100;
            //dgvGrid.Columns[20].HeaderText = "STK ADD";
            //dgvGrid.Columns[20].Width = 100;
            //dgvGrid.Columns[21].HeaderText = "STK DED";
            //dgvGrid.Columns[21].Width = 100;
            //dgvGrid.Columns[22].HeaderText = "Close STK";
            //dgvGrid.Columns[22].Width = 100;

            //dgvGrid.Columns[8].DefaultCellStyle.Format = "N2";
            //dgvGrid.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dgvGrid.Columns[9].DefaultCellStyle.Format = "N2";
            //dgvGrid.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dgvGrid.Columns[10].DefaultCellStyle.Format = "N2";
            //dgvGrid.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //dgvGrid.Columns[11].DefaultCellStyle.Format = "N2";
            //dgvGrid.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dgvGrid.Columns[12].DefaultCellStyle.Format = "N2";
            //dgvGrid.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dgvGrid.Columns[13].DefaultCellStyle.Format = "N2";
            //dgvGrid.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dgvGrid.Columns[14].DefaultCellStyle.Format = "N2";
            //dgvGrid.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dgvGrid.Columns[15].DefaultCellStyle.Format = "N2";
            //dgvGrid.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dgvGrid.Columns[16].DefaultCellStyle.Format = "N2";
            //dgvGrid.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dgvGrid.Columns[17].DefaultCellStyle.Format = "N2";
            //dgvGrid.Columns[17].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dgvGrid.Columns[18].DefaultCellStyle.Format = "N2";
            //dgvGrid.Columns[18].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dgvGrid.Columns[19].DefaultCellStyle.Format = "N2";
            //dgvGrid.Columns[19].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dgvGrid.Columns[20].DefaultCellStyle.Format = "N2";
            //dgvGrid.Columns[20].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dgvGrid.Columns[21].DefaultCellStyle.Format = "N2";
            //dgvGrid.Columns[21].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dgvGrid.Columns[22].DefaultCellStyle.Format = "N2";
            //dgvGrid.Columns[22].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;



            dgvGrid.ClearSelection();
        }

        private void InsertRecord()
        {
            MySqlCommand cmd5 = new MySqlCommand("TRUNCATE TABLE tblTEMPPOAnalyser", GlobalData.GCon);
            cmd5.ExecuteNonQuery();

            gSB.Clear();
            gSB.Append(" INSERT INTO tblTEMPPOAnalyser ( " +
                " ItemId, ItemCode, ItemName, CategoryId, CategoryCode, CategoryName,  " +
                " SupplierId, SupplierName, SupplierCode, CostPrice, SellingPrice, WholeSalePrice, " +
                " OpenStk, Purchase, PurchaseFree, SCN, SCNFree, Sale, SaleFree, CCN, CCNFree, STKAdd, " +
                " StkDED, CloseStk ) " +
                " SELECT IT.CustId AS ItemId, IT.Code AS ItemCode, IT.NameOF AS ItemName, MC.CustID AS CategoryID, " +
                " MC.Code AS CategoryCode, MC.NameOF AS CategoryName, SU.CustID AS SupplierId, SU.NAmeOf AS SupplierName, " +
                " SU.Code AS SupplierCode, IT.Cost AS CostPrice, IT.SellingPrice AS SellingPrice, IT.WholeSalePrice AS WholeSalePrice, " +
                " 0 AS OpenStk, 0 AS Purchase, 0 AS PurchaseFree, 0 AS SCN, 0 AS SCNFree, 0 AS Sale, 0 AS SaleFree, 0 AS CCN, 0 AS CCNFree,  " +
                " 0 AS StkAdd, 0 AS StkDED, 0 AS CloseStk " +
                " FROM tblItem AS IT LEFT OUTER JOIN " +
                " tblComSTKStore AS STK ON IT.CustID = STK.ItemID INNER JOIN " +
                " tblStockRoom AS ST ON ST.CustID = STK.StockRoomID INNER JOIN " +
                " tblSupplier AS SU ON IT.SupplierID = SU.CustID LEFT OUTER JOIN " +
                " tblMajorCategory AS MC ON IT.CategoryID = MC.CustID ");
            MySqlCommand cmd = new MySqlCommand(gSB.ToString(), GlobalData.GCon);
            cmd.ExecuteNonQuery();

            //PURCHASE - FREE
            gSB.Clear();
            gSB.Append("UPDATE t1 SET t1.Purchase = PR.Purchase,  t1.PurchaseFree = PR.PurchaseFree " +
                " FROM tblTEMPPOAnalyser AS t1 INNER JOIN " +
                " (SELECT ItemId,  SUM(QtyIn) AS Purchase, SUM(FreeIn) AS PurchaseFree " +
                " FROM tblBinCard WHERE DateOn BETWEEN CONVERT(date, '" + dtpFrom.Text + "') AND CONVERT(date, '" + dtpTo.Text + "') AND TranCode = 'SUP002' " +
                " GROUP BY ItemId) AS PR ON PR.ItemId = t1.ItemId ");
            MySqlCommand command1 = new MySqlCommand(gSB.ToString(), GlobalData.GCon);
            command1.ExecuteNonQuery();

            //SCN - FREE
            gSB.Clear();
            gSB.Append("UPDATE t1 SET t1.SCN = SR.SCN, t1.SCNFree = SR.SCNFree " +
                " FROM tblTEMPPOAnalyser AS t1 INNER JOIN " +
                " (SELECT ItemId,  SUM(QtyOut) AS SCN, SUM(FreeOut) AS SCNFree " +
                " FROM tblBinCard WHERE DateOn BETWEEN CONVERT(date, '" + dtpFrom.Text + "') AND CONVERT(date, '" + dtpTo.Text + "') AND TranCode = 'SUP003' " +
                " GROUP BY ItemId) AS SR ON SR.ItemId = t1.ItemId ");
            MySqlCommand command2 = new MySqlCommand(gSB.ToString(), GlobalData.GCon);
            command2.ExecuteNonQuery();

            //SALE -FREE
            gSB.Clear();
            gSB.Append("UPDATE t1 SET t1.Sale = SAL.Sale, t1.SaleFree = SAL.SaleFree " +
                " FROM tblTEMPPOAnalyser AS t1 INNER JOIN " +
                " (SELECT ItemId,  SUM(QtyOut) AS Sale, SUM(FreeOut) AS SaleFree " +
                " FROM tblBinCard WHERE DateOn BETWEEN CONVERT(date, '" + dtpFrom.Text + "') AND CONVERT(date, '" + dtpTo.Text + "') AND TranCode = 'CUS002' " +
                " GROUP BY ItemId) AS SAL ON SAL.ItemId = t1.ItemId ");
            MySqlCommand command3 = new MySqlCommand(gSB.ToString(), GlobalData.GCon);
            command3.ExecuteNonQuery();

            //CCN - FREE
            gSB.Clear();
            gSB.Append("UPDATE t1 SET t1.CCN = CN.CCN, t1.CCNFree = CN.CCNFree " +
                " FROM tblTEMPPOAnalyser AS t1 INNER JOIN " +
                " (SELECT ItemId,  SUM(QtyIn) AS CCN, SUM(FreeIn) AS CCNFree " +
                " FROM tblBinCard WHERE DateOn BETWEEN CONVERT(date, '" + dtpFrom.Text + "') AND CONVERT(date, '" + dtpTo.Text + "') AND TranCode = 'CUS003' " +
                " GROUP BY ItemId) AS CN ON CN.ItemId = t1.ItemId ");
            MySqlCommand command4 = new MySqlCommand(gSB.ToString(), GlobalData.GCon);
            command4.ExecuteNonQuery();

            //ADJUSTMENT
            gSB.Clear();
            gSB.Append("UPDATE t1 SET t1.StkADD = ADJ.StkADD, t1.StkDED = ADJ.StkDED " +
                " FROM tblTEMPPOAnalyser AS t1 INNER JOIN " +
                " (SELECT ItemId,  SUM(QtyIn) AS StkADD, SUM(QtyOut) AS StkDED " +
                " FROM tblBinCard WHERE DateOn BETWEEN CONVERT(date, '" + dtpFrom.Text + "') AND CONVERT(date, '" + dtpTo.Text + "') AND TranCode = 'STO003' " +
                " GROUP BY ItemId) AS ADJ ON ADJ.ItemId = t1.ItemId ");
            MySqlCommand cmd4 = new MySqlCommand(gSB.ToString(), GlobalData.GCon);
            cmd4.ExecuteNonQuery();


            DataTable dataTable = GlbData.getDataTable("SELECT ItemId FROM tblTEMPPOAnalyser");
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                gSB.Clear();
                gSB.Append("SELECT ItemId,  ISNULL(SUM(QtyIn),0) AS Purchase, ISNULL(SUM(FreeIn),0) AS PurchaseFree " +
                " FROM tblBinCard WHERE DateOn <= CONVERT(date, '" + dtpFrom.Text + "') AND TranCode = 'SUP002' AND ItemId = " + dataTable.Rows[i][0].ToString() + " " +
                " GROUP BY ItemId");
                string purchaseOP = GlbData.GetValue(gSB.ToString(), "Purchase").ToString();
                string purchaseFreeOP = GlbData.GetValue(gSB.ToString(), "PurchaseFree").ToString();

                gSB.Clear();
                gSB.Append("SELECT ItemId,  ISNULL(SUM(QtyOut),0) AS SCN, ISNULL(SUM(FreeOut),0) AS SCNFree " +
                " FROM tblBinCard WHERE DateOn <= CONVERT(date, '" + dtpFrom.Text + "') AND TranCode = 'SUP003' AND ItemId = " + dataTable.Rows[i][0].ToString() + " " +
                " GROUP BY ItemId");
                string scnOP = GlbData.GetValue(gSB.ToString(), "SCN").ToString();
                string scnFreeOP = GlbData.GetValue(gSB.ToString(), "SCNFree").ToString();

                gSB.Clear();
                gSB.Append("SELECT ItemId,  ISNULL(SUM(QtyOut),0) AS Sale, ISNULL(SUM(FreeOut),0) AS SaleFree " +
                " FROM tblBinCard WHERE DateOn <= CONVERT(date, '" + dtpFrom.Text + "') AND TranCode = 'CUS002' AND ItemId = " + dataTable.Rows[i][0].ToString() + " " +
                " GROUP BY ItemId");
                string saleOP = GlbData.GetValue(gSB.ToString(), "Sale").ToString();
                string saleFreeOP = GlbData.GetValue(gSB.ToString(), "SaleFree").ToString();

                gSB.Clear();
                gSB.Append("SELECT ItemId,  ISNULL(SUM(QtyIn),0) AS CCN, ISNULL(SUM(FreeIn),0) AS CCNFree " +
                " FROM tblBinCard WHERE DateOn <= CONVERT(date, '" + dtpFrom.Text + "') AND TranCode = 'CUS003' AND ItemId = " + dataTable.Rows[i][0].ToString() + " " +
                " GROUP BY ItemId");
                string ccnOP = GlbData.GetValue(gSB.ToString(), "CCN").ToString();
                string ccnFreeOP = GlbData.GetValue(gSB.ToString(), "CCNFree").ToString();

                gSB.Clear();
                gSB.Append("SELECT ItemId,  ISNULL(SUM(QtyIn),0) AS StkADD, ISNULL(SUM(QtyOut),0) AS StkDED " +
                " FROM tblBinCard WHERE DateOn <= CONVERT(date, '" + dtpFrom.Text + "') AND TranCode = 'STO003' AND ItemId = " + dataTable.Rows[i][0].ToString() + " " +
                " GROUP BY ItemId");
                string stkAddOP = GlbData.GetValue(gSB.ToString(), "StkADD").ToString();
                string stkDedOP = GlbData.GetValue(gSB.ToString(), "StkDED").ToString();

                double purchaseOPSTK = 0;
                double purchaseFreeOPSTK = 0;
                double scnOPSTK = 0;
                double scnFreeOPSTK = 0;
                double saleOPSTK = 0;
                double saleFreeOPSTK = 0;
                double ccnOPSTK = 0;
                double ccnFreeOPSTK = 0;
                double stkAddOPSTK = 0;
                double stkDedOPSTK = 0;

                if (string.IsNullOrEmpty(purchaseOP)) purchaseOPSTK = 0; else purchaseOPSTK = Convert.ToDouble(purchaseOP);
                if (string.IsNullOrEmpty(purchaseFreeOP)) purchaseFreeOPSTK = 0; else purchaseFreeOPSTK = Convert.ToDouble(purchaseFreeOP);
                if (string.IsNullOrEmpty(scnOP)) scnOPSTK = 0; else scnOPSTK = Convert.ToDouble(scnOP);
                if (string.IsNullOrEmpty(scnFreeOP)) scnFreeOPSTK = 0; else scnFreeOPSTK = Convert.ToDouble(scnFreeOP);
                if (string.IsNullOrEmpty(saleOP)) saleOPSTK = 0; else saleOPSTK = Convert.ToDouble(saleOP);
                if (string.IsNullOrEmpty(saleFreeOP)) saleFreeOPSTK = 0; else saleFreeOPSTK = Convert.ToDouble(saleFreeOP);
                if (string.IsNullOrEmpty(ccnOP)) ccnOPSTK = 0; else ccnOPSTK = Convert.ToDouble(ccnOP);
                if (string.IsNullOrEmpty(ccnFreeOP)) ccnFreeOPSTK = 0; else ccnFreeOPSTK = Convert.ToDouble(ccnFreeOP);
                if (string.IsNullOrEmpty(stkAddOP)) stkAddOPSTK = 0; else stkAddOPSTK = Convert.ToDouble(stkAddOP);
                if (string.IsNullOrEmpty(stkDedOP)) stkDedOPSTK = 0; else stkDedOPSTK = Convert.ToDouble(stkDedOP);

                double openSTK = (purchaseOPSTK + purchaseFreeOPSTK - scnOPSTK - scnFreeOPSTK - saleOPSTK - saleFreeOPSTK + ccnOPSTK + ccnFreeOPSTK + stkAddOPSTK - stkDedOPSTK);

                MySqlCommand cmdOP = new MySqlCommand("UPDATE tblTEMPPOAnalyser SET OpenStk = " + openSTK + " WHERE ItemId=" + dataTable.Rows[i][0].ToString() + " ", GlobalData.GCon);
                cmdOP.ExecuteNonQuery();

                gSB.Clear();
                gSB.Append("SELECT ItemId,  ISNULL(SUM(QtyIn),0) AS Purchase, ISNULL(SUM(FreeIn),0) AS PurchaseFree " +
                " FROM tblBinCard WHERE DateOn <= CONVERT(date, '" + dtpTo.Text + "') AND TranCode = 'SUP002' AND ItemId = " + dataTable.Rows[i][0].ToString() + " " +
                " GROUP BY ItemId");
                string purchaseCL = GlbData.GetValue(gSB.ToString(), "Purchase").ToString();
                string purchaseFreeCL = GlbData.GetValue(gSB.ToString(), "PurchaseFree").ToString();

                gSB.Clear();
                gSB.Append("SELECT ItemId,  ISNULL(SUM(QtyOut),0) AS SCN, ISNULL(SUM(FreeOut),0) AS SCNFree " +
                " FROM tblBinCard WHERE DateOn <= CONVERT(date, '" + dtpTo.Text + "') AND TranCode = 'SUP003' AND ItemId = " + dataTable.Rows[i][0].ToString() + " " +
                " GROUP BY ItemId");
                string scnCL = GlbData.GetValue(gSB.ToString(), "SCN").ToString();
                string scnFreeCL = GlbData.GetValue(gSB.ToString(), "SCNFree").ToString();

                gSB.Clear();
                gSB.Append("SELECT ItemId,  ISNULL(SUM(QtyOut),0) AS Sale, ISNULL(SUM(FreeOut),0) AS SaleFree " +
                " FROM tblBinCard WHERE DateOn <= CONVERT(date, '" + dtpTo.Text + "') AND TranCode = 'CUS002' AND ItemId = " + dataTable.Rows[i][0].ToString() + " " +
                " GROUP BY ItemId");
                string saleCL = GlbData.GetValue(gSB.ToString(), "Sale").ToString();
                string saleFreeCL = GlbData.GetValue(gSB.ToString(), "SaleFree").ToString();

                gSB.Clear();
                gSB.Append("SELECT ItemId,  ISNULL(SUM(QtyIn),0) AS CCN, ISNULL(SUM(FreeIn),0) AS CCNFree " +
                " FROM tblBinCard WHERE DateOn <= CONVERT(date, '" + dtpTo.Text + "') AND TranCode = 'CUS003' AND ItemId = " + dataTable.Rows[i][0].ToString() + " " +
                " GROUP BY ItemId");
                string ccnCL = GlbData.GetValue(gSB.ToString(), "CCN").ToString();
                string ccnFreeCL = GlbData.GetValue(gSB.ToString(), "CCNFree").ToString();

                gSB.Clear();
                gSB.Append("SELECT ItemId,  ISNULL(SUM(QtyIn),0) AS StkADD, ISNULL(SUM(QtyOut),0) AS StkDED " +
                " FROM tblBinCard WHERE DateOn <= CONVERT(date, '" + dtpTo.Text + "') AND TranCode = 'STO003' AND ItemId = " + dataTable.Rows[i][0].ToString() + " " +
                " GROUP BY ItemId");
                string stkAddCL = GlbData.GetValue(gSB.ToString(), "StkADD").ToString();
                string stkDedCL = GlbData.GetValue(gSB.ToString(), "StkDED").ToString();

                double purchaseCLSTK = 0;
                double purchaseFreeCLSTK = 0;
                double scnCLSTK = 0;
                double scnFreeCLSTK = 0;
                double saleCLSTK = 0;
                double saleFreeCLSTK = 0;
                double ccnCLSTK = 0;
                double ccnFreeCLSTK = 0;
                double stkAddCLSTK = 0;
                double stkDedCLSTK = 0;

                if (string.IsNullOrEmpty(purchaseCL)) purchaseCLSTK = 0; else purchaseCLSTK = Convert.ToDouble(purchaseCL);
                if (string.IsNullOrEmpty(purchaseFreeCL)) purchaseFreeCLSTK = 0; else purchaseFreeCLSTK = Convert.ToDouble(purchaseFreeCL);
                if (string.IsNullOrEmpty(scnCL)) scnCLSTK = 0; else scnCLSTK = Convert.ToDouble(scnCL);
                if (string.IsNullOrEmpty(scnFreeCL)) scnFreeCLSTK = 0; else scnFreeCLSTK = Convert.ToDouble(scnFreeCL);
                if (string.IsNullOrEmpty(saleCL)) saleCLSTK = 0; else saleCLSTK = Convert.ToDouble(saleCL);
                if (string.IsNullOrEmpty(saleFreeCL)) saleFreeCLSTK = 0; else saleFreeCLSTK = Convert.ToDouble(saleFreeCL);
                if (string.IsNullOrEmpty(ccnCL)) ccnCLSTK = 0; else ccnCLSTK = Convert.ToDouble(ccnCL);
                if (string.IsNullOrEmpty(ccnFreeCL)) ccnFreeCLSTK = 0; else ccnFreeCLSTK = Convert.ToDouble(ccnFreeCL);
                if (string.IsNullOrEmpty(stkAddCL)) stkAddCLSTK = 0; else stkAddCLSTK = Convert.ToDouble(stkAddCL);
                if (string.IsNullOrEmpty(stkDedCL)) stkDedCLSTK = 0; else stkDedCLSTK = Convert.ToDouble(stkDedCL);

                double closeSTK = (purchaseCLSTK + purchaseFreeCLSTK - scnCLSTK - scnFreeCLSTK - saleCLSTK - saleFreeCLSTK + ccnCLSTK + ccnFreeCLSTK + stkAddCLSTK - stkDedCLSTK);

                MySqlCommand cmdCL = new MySqlCommand("UPDATE tblTEMPPOAnalyser SET CloseStk = " + closeSTK + " WHERE ItemId=" + dataTable.Rows[i][0].ToString() + " ", GlobalData.GCon);
                cmdCL.ExecuteNonQuery();
            }
        }    

        private void frmIPPOAnalizer_Load(object sender, EventArgs e)
        {
            cboDateRange.SelectedIndex = 1;
            FillBranch();
            cboBasedOn.SelectedIndex = 0;
        }

        private void cboDateRange_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtpFrom.Text = Convert.ToDateTime(GlbData.getFirstDate(cboDateRange)).ToShortDateString();
            dtpTo.Text = Convert.ToDateTime(GlbData.getLastDate(cboDateRange, Convert.ToDateTime(dtpFrom.Text))).ToShortDateString();
        }

        private void cboDateRange_Validating(object sender, CancelEventArgs e)
        {
            dtpFrom.Text = Convert.ToDateTime(GlbData.getFirstDate(cboDateRange)).ToShortDateString();
            dtpTo.Text = Convert.ToDateTime(GlbData.getLastDate(cboDateRange, Convert.ToDateTime(dtpFrom.Text))).ToShortDateString();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            btnShow.Enabled = false;
            InsertRecord();
            ShowDetail();
            btnShow.Enabled = true;
        }

        private void dgvGrid_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvGrid.Rows.Count == 0) return;
            if (dgvGrid.SelectedRows.Count == 0) return;

            lblItem.Text = dgvGrid.Rows[dgvGrid.CurrentRow.Index].Cells[1].Value.ToString() + " - " + dgvGrid.Rows[dgvGrid.CurrentRow.Index].Cells[2].Value.ToString();
            lblBrand.Text = dgvGrid.Rows[dgvGrid.CurrentRow.Index].Cells[24].Value.ToString();
            lblCategory.Text = dgvGrid.Rows[dgvGrid.CurrentRow.Index].Cells[5].Value.ToString();
            lblSupplier.Text = dgvGrid.Rows[dgvGrid.CurrentRow.Index].Cells[8].Value.ToString() + " - " + dgvGrid.Rows[dgvGrid.CurrentRow.Index].Cells[7].Value.ToString();
            lblCost.Text = string.Format("{0:N}", Convert.ToDouble(dgvGrid.Rows[dgvGrid.CurrentRow.Index].Cells[9].Value));
            lblWholeSale.Text = string.Format("{0:N}", Convert.ToDouble(dgvGrid.Rows[dgvGrid.CurrentRow.Index].Cells[11].Value));
            lblSelling.Text = string.Format("{0:N}", Convert.ToDouble(dgvGrid.Rows[dgvGrid.CurrentRow.Index].Cells[10].Value));
            lblOpen.Text = string.Format("{0:N}", Convert.ToDouble(dgvGrid.Rows[dgvGrid.CurrentRow.Index].Cells[12].Value));
            lblPurchase.Text = string.Format("{0:N}", Convert.ToDouble(dgvGrid.Rows[dgvGrid.CurrentRow.Index].Cells[13].Value));
            lblPurFree.Text = string.Format("{0:N}", Convert.ToDouble(dgvGrid.Rows[dgvGrid.CurrentRow.Index].Cells[14].Value));
            lblScn.Text = string.Format("{0:N}", Convert.ToDouble(dgvGrid.Rows[dgvGrid.CurrentRow.Index].Cells[15].Value));
            lblScnFree.Text = string.Format("{0:N}", Convert.ToDouble(dgvGrid.Rows[dgvGrid.CurrentRow.Index].Cells[16].Value));
            lblSale.Text = string.Format("{0:N}", Convert.ToDouble(dgvGrid.Rows[dgvGrid.CurrentRow.Index].Cells[17].Value));
            lblSaleFree.Text = string.Format("{0:N}", Convert.ToDouble(dgvGrid.Rows[dgvGrid.CurrentRow.Index].Cells[18].Value));
            lblCCN.Text = string.Format("{0:N}", Convert.ToDouble(dgvGrid.Rows[dgvGrid.CurrentRow.Index].Cells[19].Value));
            lblCCNFree.Text = string.Format("{0:N}", Convert.ToDouble(dgvGrid.Rows[dgvGrid.CurrentRow.Index].Cells[20].Value));
            lblStkAdd.Text = string.Format("{0:N}", Convert.ToDouble(dgvGrid.Rows[dgvGrid.CurrentRow.Index].Cells[21].Value));
            lblStkDed.Text = string.Format("{0:N}", Convert.ToDouble(dgvGrid.Rows[dgvGrid.CurrentRow.Index].Cells[22].Value));
            lblCloseStk.Text = string.Format("{0:N}", Convert.ToDouble(dgvGrid.Rows[dgvGrid.CurrentRow.Index].Cells[23].Value));

            gItemId = Convert.ToInt32(dgvGrid.Rows[dgvGrid.CurrentRow.Index].Cells[0].Value);
            gItemCode = dgvGrid.Rows[dgvGrid.CurrentRow.Index].Cells[1].Value.ToString();
            gItemName = dgvGrid.Rows[dgvGrid.CurrentRow.Index].Cells[2].Value.ToString();

            DispalySales(Convert.ToInt32(dgvGrid.Rows[dgvGrid.CurrentRow.Index].Cells[0].Value));
            pnlPO.Visible = true;
            btnHide.Text = "HIDE PANAL";
        }

        private void InsertRecords(int cItemID)
        {
            MySqlCommand cmd3 = new MySqlCommand("TRUNCATE TABLE tblTEMPChartPO", GlobalData.GCon);
            cmd3.ExecuteNonQuery();

            string firstMonth = "01-JAN-" + DateTime.Now.Year;
            string lastMonth = "31-DEC-" + DateTime.Now.Year;

            gSB.Clear();
            gSB.Append("INSERT INTO tblTEMPChartPO ( " +
                " MonthOf, Sales, CCN, MonthIndex ) " +
                " (SELECT CONVERT(char(3), BR.DateOn,0) AS SalMonth, SUM(DT.SQty) + SUM(DT.FreeQty) AS Sales , 0 AS CCN, MONTH(BR.DateOn) AS MonthIndex " +
                " FROM tblSaleBrief AS BR INNER JOIN " +
                " tblSaleDetail AS DT ON BR.BillID = DT.BriefID  " +
                " WHERE BR.DateOn BETWEEN CONVERT(date, '" + firstMonth + "') AND CONVERT(date, '" + lastMonth + "') AND  " +
                " BR.CompId = " + GlobalData.GCompID + " AND BR.IsActive = 'Y' AND DT.ItemID = " + cItemID + "  " +
                " GROUP BY CONVERT(char(3), BR.DateOn, 0), MONTH(BR.DateOn) " +
                "  ) ");
            MySqlCommand cmd = new MySqlCommand(gSB.ToString(), GlobalData.GCon);
            cmd.ExecuteNonQuery();

            gSB.Clear();
            gSB.Append("UPDATE t1 SET t1.CCN = CN.CCN " +
                 " FROM tblTEMPChartPO as t1 INNER JOIN " +
                 " (SELECT  SUM(DT.SQty) + SUM(DT.FreeQty) AS CCN, MONTH(BR.DateOn) AS MonthIndex " +
                 " FROM tblCCNBrief AS BR INNER JOIN " +
                 " tblCCNDetail AS DT ON DT.BriefID = BR.BillID " +
                 " WHERE BR.DateOn BETWEEN CONVERT(date, '" + firstMonth + "') AND CONVERT(date, '" + lastMonth + "') AND  " +
                 " BR.CompId = " + GlobalData.GCompID + " AND BR.IsActive = 'Y' AND DT.ItemID = " + cItemID + " " +
                 " GROUP BY  MONTH(BR.DateOn)) AS CN ON CN.MonthIndex = t1.MonthIndex");
            MySqlCommand cmd2 = new MySqlCommand(gSB.ToString(), GlobalData.GCon);
            cmd2.ExecuteNonQuery();
        }

        private void DispalySales(int cItemId)
        {
            InsertRecords(cItemId);

            gSB.Clear();
            gSB.Append("SELECT MonthOf, Sales, CCN, MonthIndex FROM tblTempChartPO ORDER BY MonthIndex");
            DataTable dataTable = GlbData.getDataTable(gSB.ToString());

            chart1.DataSource = dataTable;
            chart1.Series["Sales"].XValueMember = "MonthOf";
            chart1.Series["Sales"].YValueMembers = "Sales";
            chart1.Series["Returns"].YValueMembers = "CCN";//Product Sale N Return Comparison

            if(chart1.Titles.Count > 0)
                chart1.Titles.RemoveAt(0);

            chart1.Titles.Add("Product Sale N Return Comparison");
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            if (btnHide.Text == "SHOW PANAL")
            {
                btnHide.Text = "HIDE PANAL";
                pnlPO.Visible = true;
            }
            else
            {
                btnHide.Text = "SHOW PANAL";
                pnlPO.Visible = false;
            }
        }

        private void AddingGrid(int cItemID, string cCode, string cItemName, double cUnitPrice, double cFree, double cQty, double cTotalAmount, double cCost)
        {
            DataGridViewRow newRow = (DataGridViewRow)dgvPO.RowTemplate.Clone();
            newRow.CreateCells(dgvPO);

            newRow.Cells[0].Value = cItemID.ToString();
            newRow.Cells[1].Value = cCode.ToString();
            newRow.Cells[2].Value = cItemName.ToString();
            newRow.Cells[3].Value = string.Format("{0:N}", cUnitPrice);
            newRow.Cells[4].Value = cFree.ToString();
            newRow.Cells[5].Value = cQty.ToString();
            newRow.Cells[6].Value = string.Format("{0:N}", cTotalAmount);
            newRow.Cells[7].Value = string.Format("{0:N}", cCost);

            dgvPO.Rows.Add(newRow);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           if(IsRequiredGrid())
            {
                AddingGrid(gItemId, gItemCode, gItemName, Convert.ToDouble(lblCost.Text), 0, Convert.ToDouble(txtQty.Text), Convert.ToDouble(txtQty.Text) * Convert.ToDouble(lblCost.Text), Convert.ToDouble(lblCost.Text));
                pnlPO.Visible = false;
                btnHide.Text = "SHOW PANAL";
                txtQty.Text = "0";
            }
        }

        private Boolean IsRequiredGrid()
        {
            if (txtQty.Text == "" || Convert.ToDouble(txtQty.Text) == 0)
            {
                MessageBox.Show("Invalid Product Qty", "INVALID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQty.Focus();
                return false;
            }
            return true;
        }

        private bool IsRequired()
        {
            if (dgvPO.Rows.Count == 0)
            {
                MessageBox.Show("Empty Grid", "INVALID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void txtQty_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if (IsRequiredGrid())
                    btnSave.PerformClick();
            }
        }

        private void btnProces_Click(object sender, EventArgs e)
        {
            if(IsRequired())
            {
                gOkCancel = true;
                this.Hide();
            }
        }

        public void FillBranch()
        {
            try
            {
                string strQuery = " SELECT CustID, ADD1 + ' - ' + CITY AS NameOf FROM tblCompany ORDER BY NameOF";
                MySqlCommand MySqlCommand = new MySqlCommand();
                {
                    MySqlCommand.Connection = GlobalData.GCon;
                    MySqlCommand.CommandType = CommandType.Text;
                    MySqlCommand.CommandText = strQuery;
                }

                sqlAdapter = new MySqlDataAdapter();
                dataTable = new DataTable();
                {
                    sqlAdapter.SelectCommand = MySqlCommand;
                    sqlAdapter.Fill(dataTable);
                }

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
                return "  AND BR.CompID = " + gBranchID + " ";


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

        private void cboDateRange_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            dtpFrom.Text = Convert.ToDateTime(GlbData.getFirstDate(cboDateRange)).ToShortDateString();
            dtpTo.Text = Convert.ToDateTime(GlbData.getLastDate(cboDateRange, Convert.ToDateTime(dtpFrom.Text))).ToShortDateString();
        }

        private void cboDateRange_Validating_1(object sender, CancelEventArgs e)
        {
            dtpFrom.Text = Convert.ToDateTime(GlbData.getFirstDate(cboDateRange)).ToShortDateString();
            dtpTo.Text = Convert.ToDateTime(GlbData.getLastDate(cboDateRange, Convert.ToDateTime(dtpFrom.Text))).ToShortDateString();
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

        private string getProductID()
        {
            if (txtCusCode.Text.Trim() == "")
                return " ";
            else
                return " AND IT.CustID = " + gItemID + " ";
        }

        private string getCatID()
        {
            if (txtCategory.Text.Trim() == "")
                return " ";
            else
                return " AND IT.CategoryID = " + gCatID + " ";
        }

        private string getSupplierID()
        {
            if (txtSupCode.Text.Trim() == "")
                return " ";
            else
                return " AND IT.SupplierID = " + gSupplierID + " ";
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

        private void txtCode_TextChanged(object sender, EventArgs e)
        {
            if (txtCode.Text.Trim() != "")
            {
                dSet.Tables[0].DefaultView.RowFilter = "Code like '%" + txtCode.Text.Trim() + "%'";
                dgvGrid.DataSource = dSet.Tables[0].DefaultView;
            }
            else
            {
                dSet.Tables[0].DefaultView.RowFilter = "";
                dgvGrid.DataSource = dSet.Tables[0].DefaultView;
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() != "")
            {
                dSet.Tables[0].DefaultView.RowFilter = "ItemName like '%" + txtName.Text.Trim() + "%'";
                dgvGrid.DataSource = dSet.Tables[0].DefaultView;
            }
            else
            {
                dSet.Tables[0].DefaultView.RowFilter = "";
                dgvGrid.DataSource = dSet.Tables[0].DefaultView;
            }
            pnlPO.Visible = false;
        }

        private void txtCat_TextChanged(object sender, EventArgs e)
        {
            if (txtCat.Text.Trim() != "")
            {
                dSet.Tables[0].DefaultView.RowFilter = "CategoryName like '%" + txtCat.Text.Trim() + "%'";
                dgvGrid.DataSource = dSet.Tables[0].DefaultView;
            }
            else
            {
                dSet.Tables[0].DefaultView.RowFilter = "";
                dgvGrid.DataSource = dSet.Tables[0].DefaultView;
            }
            pnlPO.Visible = false;
        }

        private void txtSupplier_TextChanged(object sender, EventArgs e)
        {
            if (txtSupplier.Text.Trim() != "")
            {
                dSet.Tables[0].DefaultView.RowFilter = "SupplierName like '%" + txtSupplier.Text.Trim() + "%'";
                dgvGrid.DataSource = dSet.Tables[0].DefaultView;
            }
            else
            {
                dSet.Tables[0].DefaultView.RowFilter = "";
                dgvGrid.DataSource = dSet.Tables[0].DefaultView;
            }
            pnlPO.Visible = false;
        }
    }
}
