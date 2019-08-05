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
    public partial class frmIPMain : Form
    {
        StringBuilder gSB = new StringBuilder();
        DataTable dataTable = new DataTable();
        GlobalData GlbData = new GlobalData();
        frmIPCommon fCommon = new frmIPCommon();

        public frmIPMain()
        {
            InitializeComponent();
        }

        private void getCompanyInfo()
        {
            gSB.Clear();
            gSB.Append("SELECT * FROM tblCompany WHERE CustID = " + GlobalData.GCompID + " ");
            dataTable = GlbData.getDataTable(gSB.ToString());

            foreach (DataRow dRow in dataTable.Rows)
            {
                GlobalData.GCompName = dRow["NameOF"].ToString();
                GlobalData.GComAdd1 = dRow["Add1"].ToString();
                GlobalData.GComAdd2 = dRow["Add2"].ToString();
                GlobalData.GComCity = dRow["City"].ToString();
                GlobalData.GComTp1 = dRow["Tp1"].ToString();
            }
            dataTable = null;
        }

        private void frmIPMain_Load(object sender, EventArgs e)
        {
            getCompanyInfo();
            lblCompanyName.Text = GlobalData.GCompName;
            lblAddress.Text = GlobalData.GComAdd1 + " , " + GlobalData.GComCity;

            frmIPDashboard f = new frmIPDashboard();
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void stockRoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fCommon.gTableName = "tblStockRoom";
            fCommon.gHeaderName = "Stock Room".ToUpper();
            fCommon.ShowDialog();
        }

        private void mainCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fCommon.gTableName = "tblMajorCategory";
            fCommon.gHeaderName = "Major Category".ToUpper();
            fCommon.ShowDialog();
        }

        private void bankNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fCommon.gTableName = "tblBank";
            fCommon.gHeaderName = "Bank Name".ToUpper();
            fCommon.ShowDialog();
        }

        private void creditCardCompanyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fCommon.gTableName = "tblCardCompany";
            fCommon.gHeaderName = "Card Company".ToUpper();
            fCommon.ShowDialog();
        }

        private void bankBranchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fCommon.gTableName = "tblBranch";
            fCommon.gHeaderName = "Branch Name".ToUpper();
            fCommon.ShowDialog();
        }

        private void returnReasonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fCommon.gTableName = "tblReason";
            fCommon.gHeaderName = "Reason".ToUpper();
            fCommon.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void productToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIPSupplier f = new frmIPSupplier();
            f.ShowDialog();
        }

        private void productInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIPProduct f = new frmIPProduct();
            f.ShowDialog();
        }

        private void binLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fCommon.gTableName = "tblBinLocation";
            fCommon.gHeaderName = "Bin Location".ToUpper();
            fCommon.ShowDialog();
        }

        private void openMainStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIPOpenStock f = new frmIPOpenStock();
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void newUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIPUser f = new frmIPUser();
            f.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void changePinCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void companyDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIPCompany f = new frmIPCompany();
            f.ShowDialog();
        }

        private void changePasswordToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmIPChngPassword f = new frmIPChngPassword();
            f.ShowDialog();
        }

        private void changePinCodeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmIPChngPincode f = new frmIPChngPincode();
            f.ShowDialog();
        }

        private void gRNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIPPurchase f = new frmIPPurchase();
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void salesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRptSales f = new frmRptSales();
            f.ShowDialog();
        }

        private void areaSalesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRptAreaSales f = new frmRptAreaSales();
            f.ShowDialog();
        }

        private void productInformationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmRptProductInfo f = new frmRptProductInfo();
            f.ShowDialog();
        }

        private void outstandingReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRptCUSOutstanding f = new frmRptCUSOutstanding();
            f.ShowDialog();
        }

        private void customerPaymentReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRptCUSPayment f = new frmRptCUSPayment();
            f.ShowDialog();
        }

        private void markDamageGoodsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIPMarkDMGGood f = new frmIPMarkDMGGood();
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void stockAdjustmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIPSTKAdjustment f = new frmIPSTKAdjustment();
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void stockTransferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIPGoodTransferNote f = new frmIPGoodTransferNote();
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void purchaseReturnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIPSRN f = new frmIPSRN();
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void outstandingBillsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOutstanding f = new frmOutstanding();
            f.ShowDialog();
        }

        private void stockReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRptStockInfo f = new frmRptStockInfo();
            f.ShowDialog();
        }

        private void setStockRoomToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmSetStockRoom f = new frmSetStockRoom();
            f.ShowDialog();
        }

        private void chequeDepositToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIPCHQDeposit f = new frmIPCHQDeposit();
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void chequeRealizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIPCHQRealize f = new frmIPCHQRealize();
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void chequeReturnsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIPCHQReturn f = new frmIPCHQReturn();
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void billCancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIPBillCancel f = new frmIPBillCancel();
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void bankAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIPBankAcc f = new frmIPBankAcc();
            f.ShowDialog();
        }

        private void billViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIPBillView f = new frmIPBillView();
            f.TABLE_NAME = "tblPurchaseBrief";
            f.ShowDialog();
        }

        private void purchaseGRNReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRptPurchase f = new frmRptPurchase();
            f.ShowDialog();
        }

        private void pRNSettlementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIPSUPPayment f = new frmIPSUPPayment();
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void supplierPaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRptSUPPayment f = new frmRptSUPPayment();
            f.ShowDialog();
        }

        private void supplierReturnNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRptPURReturn f = new frmRptPURReturn();
            f.ShowDialog();
        }

        private void supplierOutstandingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRptSUPOutstanding f = new frmRptSUPOutstanding();
            f.ShowDialog();
        }

        private void customerReturnNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIPCCN f = new frmIPCCN();
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void customerReturnNoteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmRptSALReturn f = new frmRptSALReturn();
            f.ShowDialog();
        }

        private void customerInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIPCustomer f = new frmIPCustomer();
            f.ShowDialog();
        }

        private void customerPaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIPCUSPayment f = new frmIPCUSPayment();
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void directSaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void directSaleToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmIPSales f = new frmIPSales();
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void customerListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRptCUSList f = new frmRptCUSList();
            f.ShowDialog();
        }

        private void supplierListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRptSUPList f = new frmRptSUPList();
            f.ShowDialog();
        }

        private void setBatchPriceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIPSetBatchPrice f = new frmIPSetBatchPrice();
            f.ShowDialog();
        }

        private void setDefaultCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIPSetCustomer f = new frmIPSetCustomer();
            f.ShowDialog();
        }

        private void userWiseSaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRptUserSales f = new frmRptUserSales();
            f.ShowDialog();
        }

        private void stoackNValueReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRptStockNValue f = new frmRptStockNValue();
            f.ShowDialog();
        }

        private void binCardReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRptBinCard f = new frmRptBinCard();
            f.ShowDialog();
        }

        private void frmIPMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void totalStockFlowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRptTotalStockFlow f = new frmRptTotalStockFlow();
            f.ShowDialog();
        }

        private void setSessionalPromotionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIPSetPromotion f = new frmIPSetPromotion();
            f.ShowDialog();
        }

        private void setItemFreeSchemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIPSetFreeScheme f = new frmIPSetFreeScheme();
            f.ShowDialog();
        }

        private void netSaleReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRptNetSales f = new frmRptNetSales();
            f.ShowDialog();
        }

        private void grossProfitReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRptGrossProfit f = new frmRptGrossProfit();
            f.ShowDialog();
        }

        private void setGlobalSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSetGlobal f = new frmSetGlobal();
            f.ShowDialog();
        }

        private void returnNoteSettlementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIPSRSettlement f = new frmIPSRSettlement();
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void returnNoteSettlementToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmIPPRSettlement f = new frmIPPRSettlement();
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void outstandingBillsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmOutstanding f = new frmOutstanding();
            f.ShowDialog();
        }

        private void returnNoteSettlementToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmRptCCNSettlement f = new frmRptCCNSettlement();
            f.ShowDialog();
        }

        private void returnNoteSettlementToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmRptPRNSettlement f = new frmRptPRNSettlement();
            f.ShowDialog();
        }

        private void minusStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRptMinusStk f = new frmRptMinusStk();
            f.ShowDialog();
        }

        private void nonStockProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRptZeroStk f = new frmRptZeroStk();
            f.ShowDialog();
        }

        private void earlierSaleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmIPEarlierPurchase f = new frmIPEarlierPurchase();
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void earlierSaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIPEarlierSale f = new frmIPEarlierSale();
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void SALE_Click(object sender, EventArgs e)
        {
            directSaleToolStripMenuItem.PerformClick();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            customerReturnNoteToolStripMenuItem.PerformClick();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            customerPaymentToolStripMenuItem.PerformClick();
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            returnNoteSettlementToolStripMenuItem.PerformClick();
        }

        private void buttonX7_Click(object sender, EventArgs e)
        {
            gRNToolStripMenuItem.PerformClick();
        }

        private void buttonX6_Click(object sender, EventArgs e)
        {
            purchaseReturnToolStripMenuItem.PerformClick();
        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
            pRNSettlementToolStripMenuItem.PerformClick();
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            returnNoteSettlementToolStripMenuItem1.PerformClick();
        }

        private void buttonX11_Click(object sender, EventArgs e)
        {
            chequeDepositToolStripMenuItem.PerformClick();
        }

        private void buttonX10_Click(object sender, EventArgs e)
        {
            chequeRealizeToolStripMenuItem.PerformClick();
        }

        private void buttonX9_Click(object sender, EventArgs e)
        {
            chequeReturnsToolStripMenuItem.PerformClick();
        }

        private void buttonX15_Click(object sender, EventArgs e)
        {
            openMainStockToolStripMenuItem.PerformClick();
        }

        private void buttonX12_Click(object sender, EventArgs e)
        {
            markDamageGoodsToolStripMenuItem.PerformClick();
        }

        private void buttonX14_Click(object sender, EventArgs e)
        {
            stockAdjustmentToolStripMenuItem.PerformClick();
        }

        private void buttonX13_Click(object sender, EventArgs e)
        {
            stockTransferToolStripMenuItem.PerformClick();
        }

        private void billCancelToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmIPBillCancel f = new frmIPBillCancel();
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void paymentCancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIPCUSPAYCancel f = new frmIPCUSPAYCancel();
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void toolStripMenuItem22_Click(object sender, EventArgs e)
        {
            frmIPSUPPAYCancel f = new frmIPSUPPAYCancel();
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void purchaseOrderPOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIPPO f = new frmIPPO();
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }
    }
}
