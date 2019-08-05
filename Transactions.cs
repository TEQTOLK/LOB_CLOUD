using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Text;
using System.Windows.Forms;

namespace LOB
{
    public class Transactions
    {
        StringBuilder gSB = new StringBuilder();
        GlobalData GlbData = new GlobalData();

        #region Objects
        public int ItemID { get; set; }
        public string BillsFor { get; set; }
        public string Branch { get; set; }
        public string Bank { get; set; }
        public string CardCompany { get; set; }
        public DateTime ReturnedOn { get; set; }
        public double ChqValue { get; set; }
        public int TotalChq { get; set; }
        public string Notes { get; set; }
        public string State { get; set; }
        public int FromStockroom { get; set; }
        public int ToStockroom { get; set; }
        public string PurchaseOrderNo { get; set; }
        public long BillID { get; set; }
        public DateTime DateOn { get; set; }
        public string BillNo { get; set; }
        public string MOP { get; set; }
        public int CustID { get; set; }
        public string Add1 { get; set; }
        public string Add2 { get; set; }
        public string City { get; set; }
        public string Tp1 { get; set; }
        public string Tp2 { get; set; }
        public string Tp3 { get; set; }
        public string DescriptionOf { get; set; }
        public double GrossTotal { get; set; }
        public double NetTotal { get; set; }
        public double CNAmount { get; set; }
        public double TotalPaid { get; set; }
        public double ManAmount { get; set; }
        public double NetAmount { get; set; }
        public double Balance { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }
        public int CompID { get; set; }
        public DateTime PerformedOn { get; set; }
        public string ComputerName { get; set; }
        public int DelUserID { get; set; }
        public string DelUserName { get; set; }
        public int DelCompID { get; set; }
        public string DelComputerName { get; set; }
        public DateTime DelPerformedOn { get; set; }
        public string IsActive { get; set; }
        public double DisRate { get; set; }
        public double DisAmount { get; set; }
        public double VatRate { get; set; }
        public double VatAmount { get; set; }
        public int StockRoomID { get; set; }
        public string SystemRefNo { get; set; }
        public DateTime DueDate { get; set; }
        public double CSHPaidOn { get; set; }
        public double CHQPaidOn { get; set; }
        public double CCSPaidOn { get; set; }
        public double CREPaidOn { get; set; }
        public string TranCode { get; set; }
        public double Selling { get; set; }
        public double Cost { get; set; }
        public string IsReturn { get; set; }
        public string HeaderName { get; set; }
        public string MOPType { get; set; }
        public int BankID { get; set; }
        public string CHQNo { get; set; }
        public DateTime CHQDate { get; set; }
        public string Comments { get; set; }
        public int CardID { get; set; }
        public DateTime ExpairDate { get; set; }
        public string IsDeposited { get; set; }
        public string IsRealized { get; set; }
        public string RefNo { get; set; }
        public string IsReturned { get; set; }
        public DateTime DepositedOn { get; set; }
        public string DepositedBy { get; set; }
        public DateTime RealizedOn { get; set; }
        public string RealizedBy { get; set; }
        public int OwnerID { get; set; }
        public string OwnerName { get; set; }
        public decimal CashTendered { get; set; }
        public int BranchID { get; set; }
        public int SaleBillID { get; set; }
        public string TranName { get; set; }
        public double CSHCR { get; set; }
        public double CSHDR { get; set; }
        public string Reason { get; set; }
        public string IsDeleted { get; set; }
        public int MopID { get; set; }
        public double GrandOutStanding { get; set; }
        public string NameOf { get; set; }
        #endregion

        public long SaveOpenMainBrief()
        {
            long tmpRetID = 0;
            gSB.Clear();
            gSB.Append("INSERT INTO tblOpenMainBrief ( " +
                " DateOn, BillNo, MOP, CustID, Add1, Add2, City, Tp1, Tp2, Tp3, DescriptionOf, GrossTotal, " +
                " NetTotal, CNAmount, TotalPaid, ManAmount, NetAmount, Balance, UserID, UserName, " +
                " CompName, CompID, DelUserID, DelUserName, DelCompID, DelCompName, IsActive, " +
                " DisRate, DisAmount, VatRate, VatAmount, StockRoomID, SystemRefNo, DueDate, " +
                " CSHPaidOn, CHQPaidOn, CCSPAidOn, CREPaidOn, TranCode, NameOf ) " +
                " VALUES ( " +
                " @cDateOn, @cBillNo, @cMOP, @cCustID, @cAdd1, @cAdd2, @cCity, @cTp1, @cTp2, @cTp3, @cDescriptionOf, @cGrossTotal, " +
                " @cNetTotal, @cCNAmount, @cTotalPaid, @cManAmount, @cNetAmount, @cBalance, @cUserID, @cUserName, " +
                " @cCompName, @cCompID, @cDelUserID, @cDelUserName, @cDelCompID, @cDelCompName, @cIsActive, " +
                " @cDisRate, @cDisAmount, @cVatRate, @cVatAmount, @cStockRoomID, @cSystemRefNo, @cDueDate, " +
                " @cCSHPaidOn, @cCHQPaidOn, @cCCSPAidOn, @cCREPaidOn, @cTranCode, @cNameOf); SELECT SCOPE_IDENTITY(); ");

            MySqlCommand cmd = GlobalData.GCon.CreateCommand();
            MySqlTransaction trans = GlobalData.GCon.BeginTransaction();
            cmd.Connection = GlobalData.GCon;
            cmd.Transaction = trans;
            cmd.CommandText = gSB.ToString();

            try
            {
                cmd.Parameters.AddWithValue("@cDateOn", DateOn);
                cmd.Parameters.AddWithValue("@cBillNo", BillNo);
                cmd.Parameters.AddWithValue("@cMOP", MOP);
                cmd.Parameters.AddWithValue("@cCustID", CustID);
                cmd.Parameters.AddWithValue("@cAdd1", Add1);
                cmd.Parameters.AddWithValue("@cAdd2", Add2);
                cmd.Parameters.AddWithValue("@cCity", City);
                cmd.Parameters.AddWithValue("@cTp1", Tp1);
                cmd.Parameters.AddWithValue("@cTp2", Tp2);
                cmd.Parameters.AddWithValue("@cTp3", Tp3);
                cmd.Parameters.AddWithValue("@cDescriptionOf", DescriptionOf);
                cmd.Parameters.AddWithValue("@cGrossTotal", GrossTotal);
                cmd.Parameters.AddWithValue("@cNetTotal", NetTotal);
                cmd.Parameters.AddWithValue("@cCNAmount", CNAmount);
                cmd.Parameters.AddWithValue("@cTotalPaid", TotalPaid);
                cmd.Parameters.AddWithValue("@cManAmount", ManAmount);
                cmd.Parameters.AddWithValue("@cNetAmount", NetAmount);
                cmd.Parameters.AddWithValue("@cBalance", Balance);
                cmd.Parameters.AddWithValue("@cUserID", UserID);
                cmd.Parameters.AddWithValue("@cUserName", UserName);
                cmd.Parameters.AddWithValue("@cCompID", CompID);
                cmd.Parameters.AddWithValue("@cCompName", ComputerName);
                cmd.Parameters.AddWithValue("@cDelUserID", DelUserID);
                cmd.Parameters.AddWithValue("@cDelUserName", DelUserName);
                cmd.Parameters.AddWithValue("@cDelCompID", DelCompID);
                cmd.Parameters.AddWithValue("@cDelCompName", DelComputerName);
                cmd.Parameters.AddWithValue("@cIsActive", IsActive);
                cmd.Parameters.AddWithValue("@cDisRate", DisRate);
                cmd.Parameters.AddWithValue("@cDisAmount", DisAmount);
                cmd.Parameters.AddWithValue("@cVatRate", VatRate);
                cmd.Parameters.AddWithValue("@cVatAmount", VatAmount);
                cmd.Parameters.AddWithValue("@cStockRoomID", StockRoomID);
                cmd.Parameters.AddWithValue("@cSystemRefNo", SystemRefNo);
                cmd.Parameters.AddWithValue("@cDueDate", DueDate);
                cmd.Parameters.AddWithValue("@cCSHPaidOn", CSHPaidOn);
                cmd.Parameters.AddWithValue("@cCHQPaidOn", CHQPaidOn);
                cmd.Parameters.AddWithValue("@cCCSPaidOn", CCSPaidOn);
                cmd.Parameters.AddWithValue("@cCREPaidOn", CREPaidOn);
                cmd.Parameters.AddWithValue("@cTranCode", TranCode);
                cmd.Parameters.AddWithValue("@cNameOf", NameOf);

                tmpRetID = Convert.ToInt64(cmd.ExecuteScalar());
                trans.Commit();
                return tmpRetID;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                return 0;
            }

        }
        
        public void SaveOpenMainDetail(long cBriefID, DataGridView cDateGridView)
        {
            gSB.Clear();
            gSB.Append("INSERT INTO tblOpenMainDetail ( " +
                " ItemId, SQty, FreeQty, UnitPrice, TotalAmount, Selling, Cost, " +
                " LineDis, LineDisAmount, LineVatRate, LineVatAmount, IsReturn, CostOfSale, BriefID) " +
                " VALUES ( " +
                " @cItemId, @cSQty, @cFreeQty, @cUnitPrice, @cTotalAmount, @cSelling, @cCost, " +
                " @cLineDis, @cLineDisAmount, @cLineVatRate, @cLineVatAmount, @cIsReturn, @cCostOfSale, @cBriefID) ");

            MySqlCommand cmd = GlobalData.GCon.CreateCommand();
            MySqlTransaction trans = GlobalData.GCon.BeginTransaction();
            cmd.Connection = GlobalData.GCon;
            cmd.Transaction = trans;
            cmd.CommandText = gSB.ToString();

            try
            {
                for (int i = 0; i < cDateGridView.Rows.Count; i++)
                {
                    cmd.Parameters.AddWithValue("@cItemID", Convert.ToInt32(cDateGridView.Rows[i].Cells[0].Value));
                    cmd.Parameters.AddWithValue("@cSQty", Convert.ToDouble(cDateGridView.Rows[i].Cells[4].Value));
                    cmd.Parameters.AddWithValue("@cFreeQty", 0);
                    cmd.Parameters.AddWithValue("@cUnitPrice", Convert.ToDouble(cDateGridView.Rows[i].Cells[3].Value));
                    cmd.Parameters.AddWithValue("@cTotalAmount", Convert.ToDouble(cDateGridView.Rows[i].Cells[5].Value));
                    cmd.Parameters.AddWithValue("@cSelling", Convert.ToDouble(cDateGridView.Rows[i].Cells[3].Value));
                    cmd.Parameters.AddWithValue("@cCost", Convert.ToDouble(cDateGridView.Rows[i].Cells[6].Value));
                    cmd.Parameters.AddWithValue("@cLineDis", 0);
                    cmd.Parameters.AddWithValue("@cLineDisAmount", 0);
                    cmd.Parameters.AddWithValue("@cLineVatRate", 0);
                    cmd.Parameters.AddWithValue("@cLineVatAmount", 0);
                    cmd.Parameters.AddWithValue("@cIsReturn", "N");
                    cmd.Parameters.AddWithValue("@cCostOfSale", Convert.ToDouble(cDateGridView.Rows[i].Cells[4].Value) * Convert.ToDouble(cDateGridView.Rows[i].Cells[6].Value));
                    cmd.Parameters.AddWithValue("@cBriefID", cBriefID);

                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
                    trans.Commit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                trans.Rollback();
            }
        }

        public long SavePurchaseBrief()
        {
            long tmpRetID = 0;
            gSB.Clear();
            gSB.Append("INSERT INTO tblPurchaseBrief ( " +
                " DateOn, BillNo, MOP, CustID, Add1, Add2, City, Tp1, Tp2, Tp3, DescriptionOf, GrossTotal, " +
                " NetTotal, CNAmount, TotalPaid, ManAmount, NetAmount, Balance, UserID, UserName, " +
                " CompName, CompID, DelUserID, DelUserName, DelCompID, DelCompName, IsActive, " +
                " DisRate, DisAmount, VatRate, VatAmount, StockRoomID, SystemRefNo, DueDate, " +
                " CSHPaidOn, CHQPaidOn, CCSPAidOn, CREPaidOn, TranCode, NameOf, PurchaseOrderNo ) " +
                " VALUES ( " +
                " @cDateOn, @cBillNo, @cMOP, @cCustID, @cAdd1, @cAdd2, @cCity, @cTp1, @cTp2, @cTp3, @cDescriptionOf, @cGrossTotal, " +
                " @cNetTotal, @cCNAmount, @cTotalPaid, @cManAmount, @cNetAmount, @cBalance, @cUserID, @cUserName, " +
                " @cCompName, @cCompID, @cDelUserID, @cDelUserName, @cDelCompID, @cDelCompName, @cIsActive, " +
                " @cDisRate, @cDisAmount, @cVatRate, @cVatAmount, @cStockRoomID, @cSystemRefNo, @cDueDate, " +
                " @cCSHPaidOn, @cCHQPaidOn, @cCCSPAidOn, @cCREPaidOn, @cTranCode, @cNameOf, @cPurchaseOrderNo); SELECT SCOPE_IDENTITY(); ");

            MySqlCommand cmd = GlobalData.GCon.CreateCommand();
            MySqlTransaction trans = GlobalData.GCon.BeginTransaction();
            cmd.Connection = GlobalData.GCon;
            cmd.Transaction = trans;
            cmd.CommandText = gSB.ToString();

            try
            {
                cmd.Parameters.AddWithValue("@cDateOn", DateOn);
                cmd.Parameters.AddWithValue("@cBillNo", BillNo);
                cmd.Parameters.AddWithValue("@cMOP", MOP);
                cmd.Parameters.AddWithValue("@cCustID", CustID);
                cmd.Parameters.AddWithValue("@cAdd1", Add1);
                cmd.Parameters.AddWithValue("@cAdd2", Add2);
                cmd.Parameters.AddWithValue("@cCity", City);
                cmd.Parameters.AddWithValue("@cTp1", Tp1);
                cmd.Parameters.AddWithValue("@cTp2", Tp2);
                cmd.Parameters.AddWithValue("@cTp3", Tp3);
                cmd.Parameters.AddWithValue("@cDescriptionOf", DescriptionOf);
                cmd.Parameters.AddWithValue("@cGrossTotal", GrossTotal);
                cmd.Parameters.AddWithValue("@cNetTotal", NetTotal);
                cmd.Parameters.AddWithValue("@cCNAmount", CNAmount);
                cmd.Parameters.AddWithValue("@cTotalPaid", TotalPaid);
                cmd.Parameters.AddWithValue("@cManAmount", ManAmount);
                cmd.Parameters.AddWithValue("@cNetAmount", NetAmount);
                cmd.Parameters.AddWithValue("@cBalance", Balance);
                cmd.Parameters.AddWithValue("@cUserID", UserID);
                cmd.Parameters.AddWithValue("@cUserName", UserName);
                cmd.Parameters.AddWithValue("@cCompID", CompID);
                cmd.Parameters.AddWithValue("@cCompName", ComputerName);
                cmd.Parameters.AddWithValue("@cDelUserID", DelUserID);
                cmd.Parameters.AddWithValue("@cDelUserName", DelUserName);
                cmd.Parameters.AddWithValue("@cDelCompID", DelCompID);
                cmd.Parameters.AddWithValue("@cDelCompName", DelComputerName);
                cmd.Parameters.AddWithValue("@cIsActive", IsActive);
                cmd.Parameters.AddWithValue("@cDisRate", DisRate);
                cmd.Parameters.AddWithValue("@cDisAmount", DisAmount);
                cmd.Parameters.AddWithValue("@cVatRate", VatRate);
                cmd.Parameters.AddWithValue("@cVatAmount", VatAmount);
                cmd.Parameters.AddWithValue("@cStockRoomID", StockRoomID);
                cmd.Parameters.AddWithValue("@cSystemRefNo", SystemRefNo);
                cmd.Parameters.AddWithValue("@cDueDate", DueDate);
                cmd.Parameters.AddWithValue("@cCSHPaidOn", CSHPaidOn);
                cmd.Parameters.AddWithValue("@cCHQPaidOn", CHQPaidOn);
                cmd.Parameters.AddWithValue("@cCCSPaidOn", CCSPaidOn);
                cmd.Parameters.AddWithValue("@cCREPaidOn", CREPaidOn);
                cmd.Parameters.AddWithValue("@cTranCode", TranCode);
                cmd.Parameters.AddWithValue("@cNameOf", NameOf);
                cmd.Parameters.AddWithValue("@cPurchaseOrderNo", PurchaseOrderNo);

                tmpRetID = Convert.ToInt64(cmd.ExecuteScalar());
                trans.Commit();
                return tmpRetID;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                MessageBox.Show(ex.Message);
                return 0;
            }

        }

        public void SavePurchaseDetail(long cBriefID, DataGridView cDateGridView)
        {
            gSB.Clear();
            gSB.Append("INSERT INTO tblPurchaseDetail ( " +
                " ItemId, SQty, FreeQty, UnitPrice, TotalAmount, Selling, Cost, " +
                " LineDis, LineDisAmount, LineVatRate, LineVatAmount, IsReturn, CostOfSale, BriefID) " +
                " VALUES ( " +
                " @cItemId, @cSQty, @cFreeQty, @cUnitPrice, @cTotalAmount, @cSelling, @cCost, " +
                " @cLineDis, @cLineDisAmount, @cLineVatRate, @cLineVatAmount, @cIsReturn, @cCostOfSale, @cBriefID) ");

            MySqlCommand cmd = GlobalData.GCon.CreateCommand();
            MySqlTransaction trans = GlobalData.GCon.BeginTransaction();
            cmd.Connection = GlobalData.GCon;
            cmd.Transaction = trans;
            cmd.CommandText = gSB.ToString();

            try
            {
                for (int i = 0; i < cDateGridView.Rows.Count; i++)
                {
                    cmd.Parameters.AddWithValue("@cItemID", Convert.ToInt32(cDateGridView.Rows[i].Cells[0].Value));
                    cmd.Parameters.AddWithValue("@cSQty", Convert.ToDouble(cDateGridView.Rows[i].Cells[5].Value));
                    cmd.Parameters.AddWithValue("@cFreeQty", Convert.ToDouble(cDateGridView.Rows[i].Cells[4].Value));
                    cmd.Parameters.AddWithValue("@cUnitPrice", Convert.ToDouble(cDateGridView.Rows[i].Cells[3].Value));
                    cmd.Parameters.AddWithValue("@cTotalAmount", Convert.ToDouble(cDateGridView.Rows[i].Cells[6].Value));
                    cmd.Parameters.AddWithValue("@cSelling", Convert.ToDouble(cDateGridView.Rows[i].Cells[3].Value));
                    cmd.Parameters.AddWithValue("@cCost", Convert.ToDouble(cDateGridView.Rows[i].Cells[7].Value));
                    cmd.Parameters.AddWithValue("@cLineDis", 0);
                    cmd.Parameters.AddWithValue("@cLineDisAmount", 0);
                    cmd.Parameters.AddWithValue("@cLineVatRate", 0);
                    cmd.Parameters.AddWithValue("@cLineVatAmount", 0);
                    cmd.Parameters.AddWithValue("@cIsReturn", "N");
                    cmd.Parameters.AddWithValue("@cCostOfSale", Convert.ToDouble(cDateGridView.Rows[i].Cells[5].Value) * Convert.ToDouble(cDateGridView.Rows[i].Cells[7].Value));
                    cmd.Parameters.AddWithValue("@cBriefID", cBriefID);

                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
                trans.Commit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                trans.Rollback();
            }
        }

        public void SaveSTOCKFlow(long cBriefID, DataGridView cDateGridView, string cAD)
        {
            gSB.Clear();
            gSB.Append("INSERT INTO tblBinCard ( " +
                " BillNo, DateOn, ItemID, SQty, FreeIn, FreeOut, UnitPrice, QtyIn, QtyOut, HeaderName, " +
                " UserID, UserName, CompID, CompName, DelUserID, DelUserName, DelCompID, DelCompName, IsActive, IsDeleted, " +
                " TotalAmount, Selling, Cost, LineDis, LineDisAmount, LineVatRate, LineVatAmount, SaleBillID, TranCode, StockRoomID ) " +
                " VALUES ( " +
                " @BillNo, @DateOn, @ItemID, @SQty, @FreeIn, @FreeOut, @UnitPrice, @QtyIn, @QtyOut, @HeaderName, " +
                " @UserID, @UserName, @CompID, @CompName, @DelUserID, @DelUserName, @DelCompID, @DelCompName, @IsActive, @IsDeleted, " +
                " @TotalAmount, @Selling, @Cost, @LineDis, @LineDisAmount, @LineVatRate, @LineVatAmount, @SaleBillID, @TranCode, @StockRoomID ) ");

            MySqlCommand cmd = GlobalData.GCon.CreateCommand();
            MySqlTransaction trans = GlobalData.GCon.BeginTransaction();
            cmd.Connection = GlobalData.GCon;
            cmd.Transaction = trans;
            cmd.CommandText = gSB.ToString();

            try
            {
                for (int i = 0; i < cDateGridView.Rows.Count; i++)
                {
                    cmd.Parameters.AddWithValue("@BillNo", BillNo);
                    cmd.Parameters.AddWithValue("@DateOn", DateOn);
                    cmd.Parameters.AddWithValue("@ItemID", Convert.ToInt32(cDateGridView.Rows[i].Cells[0].Value));
                    cmd.Parameters.AddWithValue("@SQty", Convert.ToDouble(cDateGridView.Rows[i].Cells[5].Value));                       
                    cmd.Parameters.AddWithValue("@UnitPrice", Convert.ToDouble(cDateGridView.Rows[i].Cells[3].Value));

                    if(cAD == "A")
                    {
                        cmd.Parameters.AddWithValue("@QtyIn", Convert.ToDouble(cDateGridView.Rows[i].Cells[5].Value));
                        cmd.Parameters.AddWithValue("@QtyOut", 0);
                        cmd.Parameters.AddWithValue("@FreeIn", Convert.ToDouble(cDateGridView.Rows[i].Cells[4].Value));
                        cmd.Parameters.AddWithValue("@FreeOut", 0);
                    }         
                    else
                    {
                        cmd.Parameters.AddWithValue("@QtyIn", 0);
                        cmd.Parameters.AddWithValue("@QtyOut", Convert.ToDouble(cDateGridView.Rows[i].Cells[5].Value));
                        cmd.Parameters.AddWithValue("@FreeIn", 0);
                        cmd.Parameters.AddWithValue("@FreeOut", Convert.ToDouble(cDateGridView.Rows[i].Cells[4].Value));
                    }

                    cmd.Parameters.AddWithValue("@HeaderName", HeaderName);
                    cmd.Parameters.AddWithValue("@UserID", UserID);
                    cmd.Parameters.AddWithValue("@UserName", UserName);
                    cmd.Parameters.AddWithValue("@CompID", CompID);
                    cmd.Parameters.AddWithValue("@CompName", ComputerName);
                    cmd.Parameters.AddWithValue("@DelUserID", DelUserID);
                    cmd.Parameters.AddWithValue("@DelUserName", DelUserName);
                    cmd.Parameters.AddWithValue("@DelCompID", DelCompID);
                    cmd.Parameters.AddWithValue("@DelCompName", DelComputerName);
                    cmd.Parameters.AddWithValue("@IsActive", IsActive);
                    cmd.Parameters.AddWithValue("@IsDeleted", "N");
                    cmd.Parameters.AddWithValue("@TotalAmount", Convert.ToDouble(cDateGridView.Rows[i].Cells[6].Value));
                    cmd.Parameters.AddWithValue("@Selling", Convert.ToDouble(cDateGridView.Rows[i].Cells[3].Value));
                    cmd.Parameters.AddWithValue("@Cost", Convert.ToDouble(cDateGridView.Rows[i].Cells[7].Value));
                    cmd.Parameters.AddWithValue("@LineDis", 0);
                    cmd.Parameters.AddWithValue("@LineDisAmount", 0);
                    cmd.Parameters.AddWithValue("@LineVatRate", 0);
                    cmd.Parameters.AddWithValue("@LineVatAmount", 0);
                    cmd.Parameters.AddWithValue("@SaleBillID", SaleBillID);
                    cmd.Parameters.AddWithValue("@TranCode", TranCode);
                    cmd.Parameters.AddWithValue("@StockRoomID", StockRoomID);

                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
                trans.Commit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                trans.Rollback();
            }
        }

        public void SaveJOURNAL(decimal cCredit, decimal cDebit, string cOwnerCode, int cOwnerID, string cOwnerName,
        int cDrAcc, int cCrAcc, string cIsActive, string cCrDrStatus, string cDescription, int cAcc, DateTime cDateOn,
        int cUserID, string cUserName, int cCompID, string cComputerName, int cDelUserID, string cDelUserName, 
        int cDelCompID, string cDelComputerName)
        {

            gSB.Clear();
            gSB.Append("INSERT INTO tblJournalPOS ( " +
                " Credit, Debit, OwnerCode, OwnerID, OwnerName, " +
                " DrAcc, CrAcc, IsActive, CrDrStatus, DescriptionOf, AccID, DateOn, " +
                " UserID, UserName, omputerName, CompID, DelUserID, DelUserName, DelCompID, DelCompName ) " +
                " VALUES ( " +
                " cCredit, cDebit, cOwnerCode, cOwnerID, cOwnerName, " +
                " cDrAcc, cCrAcc, cIsActive, cCrDrStatus, cDescriptionOf, cAccID, cDateOn, " +
                " cUserID, cUserName, cComputerName, cCompID, cDelUserID, cDelUserName, cDelCompID, cDelCompName ) ");
            MySqlCommand cmd = GlobalData.GCon.CreateCommand();
            MySqlTransaction trans = GlobalData.GCon.BeginTransaction();
            cmd.Connection = GlobalData.GCon;
            cmd.Transaction = trans;
            cmd.CommandText = gSB.ToString();

            try
            {
                cmd.Parameters.AddWithValue("cCredit", cCredit);
                cmd.Parameters.AddWithValue("cDebit", cDebit);
                cmd.Parameters.AddWithValue("cOwnerCode", cOwnerCode);
                cmd.Parameters.AddWithValue("cOwnerID", cOwnerID);
                cmd.Parameters.AddWithValue("cOwnerName", cOwnerName);
                cmd.Parameters.AddWithValue("DrAcc", cDrAcc);
                cmd.Parameters.AddWithValue("CrAcc", cCrAcc);
                cmd.Parameters.AddWithValue("CrDrStatus", cCrDrStatus);
                cmd.Parameters.AddWithValue("DescriptionOf", cDescription);
                cmd.Parameters.AddWithValue("AccID", cAcc);
                cmd.Parameters.AddWithValue("DateOn", cDateOn);
                cmd.Parameters.AddWithValue("IsActive", cIsActive);
                cmd.Parameters.AddWithValue("cUserID", UserID);
                cmd.Parameters.AddWithValue("cUserName", UserName);
                cmd.Parameters.AddWithValue("cCompID", CompID);
                cmd.Parameters.AddWithValue("cComputerName", ComputerName);
                cmd.Parameters.AddWithValue("cDelUserID", DelUserID);
                cmd.Parameters.AddWithValue("cDelUserName", DelUserName);
                cmd.Parameters.AddWithValue("cDelCompID", DelCompID);
                cmd.Parameters.AddWithValue("cDelComputerName", DelComputerName);

                cmd.ExecuteNonQuery();
                trans.Commit();
            }
            catch (Exception)
            {
                trans.Rollback();
            }
        }

        public long SaveMOP(long cBriefID)
        {
            long tmpRetID = 0;
            gSB.Clear();
            gSB.Append("INSERT INTO tblMOP ( " +
                " MopType, NetAmount, BankID, CHQNo, CHQDate, Comments, CardID, ExpairDate, " +
                " IsDeposited, IsRealized, IsActive, RefNo, TotalPaid, " +
                " IsReturned, OwnerID, OwnerName, CashTendered, Balance, " +
                " UserID, UserName, CompName, CompID, DelUserID, DelUserName, DelCompID, DelCompName, BillId, BranchId ) " +
                " VALUES ( " +
                " @MopType, @NetAmount, @BankID, @CHQNo, @CHQDate, @Comments, @CardID, @ExpairDate, " +
                " @IsDeposited, @IsRealized, @IsActive, @RefNo, @TotalPaid, " +
                " @IsReturned, @OwnerID, @OwnerName, @CashTendered, @Balance, " +
                " @cUserID, @cUserName, @cComputerName, @cCompID, @cDelUserID, @cDelUserName, @cDelCompID, @cDelCompName, @BillID, @BranchId ); SELECT SCOPE_IDENTITY(); ");
            MySqlCommand cmd = GlobalData.GCon.CreateCommand();
            MySqlTransaction trans = GlobalData.GCon.BeginTransaction();
            cmd.Connection = GlobalData.GCon;
            cmd.Transaction = trans;
            cmd.CommandText = gSB.ToString();

            try
            {
                cmd.Parameters.AddWithValue("@MopType", MOPType);
                cmd.Parameters.AddWithValue("@NetAmount", NetAmount);
                cmd.Parameters.AddWithValue("@BankID", BankID);
                cmd.Parameters.AddWithValue("@CHQNo", CHQNo);
                cmd.Parameters.AddWithValue("@CHQDate", CHQDate);
                cmd.Parameters.AddWithValue("@Comments", Comments);
                cmd.Parameters.AddWithValue("@CardID", CardID);
                cmd.Parameters.AddWithValue("@ExpairDate", ExpairDate);
                cmd.Parameters.AddWithValue("@IsDeposited", IsDeposited);
                cmd.Parameters.AddWithValue("@IsRealized", IsRealized);
                cmd.Parameters.AddWithValue("@IsActive", IsActive);
                cmd.Parameters.AddWithValue("@RefNo", RefNo);
                cmd.Parameters.AddWithValue("@TotalPaid", TotalPaid);
                cmd.Parameters.AddWithValue("@IsReturned", IsReturned);
                cmd.Parameters.AddWithValue("@OwnerID", OwnerID);
                cmd.Parameters.AddWithValue("@OwnerName", OwnerName);
                cmd.Parameters.AddWithValue("@CashTendered", CashTendered);
                cmd.Parameters.AddWithValue("@Balance", Balance);
                cmd.Parameters.AddWithValue("@cUserID", UserID);
                cmd.Parameters.AddWithValue("@cUserName", UserName);
                cmd.Parameters.AddWithValue("@cCompID", CompID);
                cmd.Parameters.AddWithValue("@cComputerName", ComputerName);
                cmd.Parameters.AddWithValue("@cDelUserID", DelUserID);
                cmd.Parameters.AddWithValue("@cDelUserName", DelUserName);
                cmd.Parameters.AddWithValue("@cDelCompID", DelCompID);
                cmd.Parameters.AddWithValue("@cDelCompName", DelComputerName);
                cmd.Parameters.AddWithValue("@BillID", cBriefID);
                cmd.Parameters.AddWithValue("@BranchId", BranchID);

                tmpRetID = Convert.ToInt64(cmd.ExecuteScalar());
                trans.Commit();
                return tmpRetID;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                trans.Rollback();
                return 0;
            }
        }

        public void SaveOrUpdateStock(int cItemID, string cAD, double cQty)
        {
            gSB.Clear();
            gSB.Append("SELECT * FROM tblComSTKStore WHERE ItemID = " + cItemID + " AND StockRoomID = " + GlobalData.GStockRoomID + " AND CompID = " + GlobalData.GCompID + "");
            if (GlbData.AlreadyExist(gSB.ToString()))
            {
                if (cAD == "A")
                {
                    gSB.Clear();
                    gSB.Append("UPDATE tblComSTKStore SET Qty = Qty + " + cQty + " WHERE ItemID = " + cItemID + " AND StockRoomID = " + GlobalData.GStockRoomID + " AND CompID = " + GlobalData.GCompID + " ");

                    MySqlCommand command = new MySqlCommand(gSB.ToString(), GlobalData.GCon);
                    command.ExecuteNonQuery();
                }
                else
                {
                    gSB.Clear();
                    gSB.Append("UPDATE tblComSTKStore SET Qty = Qty - " + cQty + " WHERE ItemID = " + cItemID + " AND StockRoomID = " + GlobalData.GStockRoomID + " AND CompID = " + GlobalData.GCompID + " ");

                    MySqlCommand command = new MySqlCommand(gSB.ToString(), GlobalData.GCon);
                    command.ExecuteNonQuery();
                }
            }
            else
            {
                gSB.Clear();
                gSB.Append("INSERT INTO tblComSTKStore(ItemID, StockRoomID, CompID, Qty) VALUES (" + cItemID + ", " + GlobalData.GStockRoomID + ", " + GlobalData.GCompID + ", " + cQty + ") ");

                MySqlCommand command = new MySqlCommand(gSB.ToString(), GlobalData.GCon);
                command.ExecuteNonQuery();
            }
        }

        public void SaveOrUpdateStock(int cItemID, string cAD, double cQty, int cStockRoomID)
        {
            gSB.Clear();
            gSB.Append("SELECT * FROM tblComSTKStore WHERE ItemID = " + cItemID + " AND StockRoomID = " + cStockRoomID + " AND CompID = " + GlobalData.GCompID + "");
            if (GlbData.AlreadyExist(gSB.ToString()))
            {
                if (cAD == "A")
                {
                    gSB.Clear();
                    gSB.Append("UPDATE tblComSTKStore SET Qty = Qty + " + cQty + " WHERE ItemID = " + cItemID + " AND StockRoomID = " + cStockRoomID + " AND CompID = " + GlobalData.GCompID + " ");

                    MySqlCommand command = new MySqlCommand(gSB.ToString(), GlobalData.GCon);
                    command.ExecuteNonQuery();
                }
                else
                {
                    gSB.Clear();
                    gSB.Append("UPDATE tblComSTKStore SET Qty = Qty - " + cQty + " WHERE ItemID = " + cItemID + " AND StockRoomID = " + cStockRoomID + " AND CompID = " + GlobalData.GCompID + " ");

                    MySqlCommand command = new MySqlCommand(gSB.ToString(), GlobalData.GCon);
                    command.ExecuteNonQuery();
                }
            }
            else
            {
                gSB.Clear();
                gSB.Append("INSERT INTO tblComSTKStore(ItemID, StockRoomID, CompID) VALUES (" + cItemID + ", " + cStockRoomID + ", " + GlobalData.GCompID + ") ");

                MySqlCommand command = new MySqlCommand(gSB.ToString(), GlobalData.GCon);
                command.ExecuteNonQuery();
            }
        }

        public long SaveMarkDAMBrief()
        {
            long tmpRetID = 0;
            gSB.Clear();
            gSB.Append("INSERT INTO tblMarkDAMBrief ( " +
                " DateOn, BillNo, MOP, CustID, Add1, Add2, City, Tp1, Tp2, Tp3, DescriptionOf, GrossTotal, " +
                " NetTotal, CNAmount, TotalPaid, ManAmount, NetAmount, Balance, UserID, UserName, " +
                " CompName, CompID, DelUserID, DelUserName, DelCompID, DelCompName, IsActive, " +
                " DisRate, DisAmount, VatRate, VatAmount, StockRoomID, SystemRefNo, DueDate, " +
                " CSHPaidOn, CHQPaidOn, CCSPAidOn, CREPaidOn, TranCode, NameOf ) " +
                " VALUES ( " +
                " @cDateOn, @cBillNo, @cMOP, @cCustID, @cAdd1, @cAdd2, @cCity, @cTp1, @cTp2, @cTp3, @cDescriptionOf, @cGrossTotal, " +
                " @cNetTotal, @cCNAmount, @cTotalPaid, @cManAmount, @cNetAmount, @cBalance, @cUserID, @cUserName, " +
                " @cCompName, @cCompID, @cDelUserID, @cDelUserName, @cDelCompID, @cDelCompName, @cIsActive, " +
                " @cDisRate, @cDisAmount, @cVatRate, @cVatAmount, @cStockRoomID, @cSystemRefNo, @cDueDate, " +
                " @cCSHPaidOn, @cCHQPaidOn, @cCCSPAidOn, @cCREPaidOn, @cTranCode, @cNameOf); SELECT SCOPE_IDENTITY(); ");

            MySqlCommand cmd = GlobalData.GCon.CreateCommand();
            MySqlTransaction trans = GlobalData.GCon.BeginTransaction();
            cmd.Connection = GlobalData.GCon;
            cmd.Transaction = trans;
            cmd.CommandText = gSB.ToString();

            try
            {
                cmd.Parameters.AddWithValue("@cDateOn", DateOn);
                cmd.Parameters.AddWithValue("@cBillNo", BillNo);
                cmd.Parameters.AddWithValue("@cMOP", MOP);
                cmd.Parameters.AddWithValue("@cCustID", CustID);
                cmd.Parameters.AddWithValue("@cAdd1", Add1);
                cmd.Parameters.AddWithValue("@cAdd2", Add2);
                cmd.Parameters.AddWithValue("@cCity", City);
                cmd.Parameters.AddWithValue("@cTp1", Tp1);
                cmd.Parameters.AddWithValue("@cTp2", Tp2);
                cmd.Parameters.AddWithValue("@cTp3", Tp3);
                cmd.Parameters.AddWithValue("@cDescriptionOf", DescriptionOf);
                cmd.Parameters.AddWithValue("@cGrossTotal", GrossTotal);
                cmd.Parameters.AddWithValue("@cNetTotal", NetTotal);
                cmd.Parameters.AddWithValue("@cCNAmount", CNAmount);
                cmd.Parameters.AddWithValue("@cTotalPaid", TotalPaid);
                cmd.Parameters.AddWithValue("@cManAmount", ManAmount);
                cmd.Parameters.AddWithValue("@cNetAmount", NetAmount);
                cmd.Parameters.AddWithValue("@cBalance", Balance);
                cmd.Parameters.AddWithValue("@cUserID", UserID);
                cmd.Parameters.AddWithValue("@cUserName", UserName);
                cmd.Parameters.AddWithValue("@cCompID", CompID);
                cmd.Parameters.AddWithValue("@cCompName", ComputerName);
                cmd.Parameters.AddWithValue("@cDelUserID", DelUserID);
                cmd.Parameters.AddWithValue("@cDelUserName", DelUserName);
                cmd.Parameters.AddWithValue("@cDelCompID", DelCompID);
                cmd.Parameters.AddWithValue("@cDelCompName", DelComputerName);
                cmd.Parameters.AddWithValue("@cIsActive", IsActive);
                cmd.Parameters.AddWithValue("@cDisRate", DisRate);
                cmd.Parameters.AddWithValue("@cDisAmount", DisAmount);
                cmd.Parameters.AddWithValue("@cVatRate", VatRate);
                cmd.Parameters.AddWithValue("@cVatAmount", VatAmount);
                cmd.Parameters.AddWithValue("@cStockRoomID", StockRoomID);
                cmd.Parameters.AddWithValue("@cSystemRefNo", SystemRefNo);
                cmd.Parameters.AddWithValue("@cDueDate", DueDate);
                cmd.Parameters.AddWithValue("@cCSHPaidOn", CSHPaidOn);
                cmd.Parameters.AddWithValue("@cCHQPaidOn", CHQPaidOn);
                cmd.Parameters.AddWithValue("@cCCSPaidOn", CCSPaidOn);
                cmd.Parameters.AddWithValue("@cCREPaidOn", CREPaidOn);
                cmd.Parameters.AddWithValue("@cTranCode", TranCode);
                cmd.Parameters.AddWithValue("@cNameOf", NameOf);

                tmpRetID = Convert.ToInt64(cmd.ExecuteScalar());
                trans.Commit();
                return tmpRetID;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                return 0;
            }

        }

        public void SaveMarkDAMDetail(long cBriefID, DataGridView cDateGridView)
        {
            gSB.Clear();
            gSB.Append("INSERT INTO tblMarkDAMDetail ( " +
                " ItemId, SQty, FreeQty, UnitPrice, TotalAmount, Selling, Cost, " +
                " LineDis, LineDisAmount, LineVatRate, LineVatAmount, IsReturn, CostOfSale, BriefID) " +
                " VALUES ( " +
                " @cItemId, @cSQty, @cFreeQty, @cUnitPrice, @cTotalAmount, @cSelling, @cCost, " +
                " @cLineDis, @cLineDisAmount, @cLineVatRate, @cLineVatAmount, @cIsReturn, @cCostOfSale, @cBriefID) ");

            MySqlCommand cmd = GlobalData.GCon.CreateCommand();
            MySqlTransaction trans = GlobalData.GCon.BeginTransaction();
            cmd.Connection = GlobalData.GCon;
            cmd.Transaction = trans;
            cmd.CommandText = gSB.ToString();

            try
            {
                for (int i = 0; i < cDateGridView.Rows.Count; i++)
                {
                    cmd.Parameters.AddWithValue("@cItemID", Convert.ToInt32(cDateGridView.Rows[i].Cells[0].Value));
                    cmd.Parameters.AddWithValue("@cSQty", Convert.ToDouble(cDateGridView.Rows[i].Cells[4].Value));
                    cmd.Parameters.AddWithValue("@cFreeQty", 0);
                    cmd.Parameters.AddWithValue("@cUnitPrice", Convert.ToDouble(cDateGridView.Rows[i].Cells[3].Value));
                    cmd.Parameters.AddWithValue("@cTotalAmount", Convert.ToDouble(cDateGridView.Rows[i].Cells[5].Value));
                    cmd.Parameters.AddWithValue("@cSelling", Convert.ToDouble(cDateGridView.Rows[i].Cells[3].Value));
                    cmd.Parameters.AddWithValue("@cCost", Convert.ToDouble(cDateGridView.Rows[i].Cells[6].Value));
                    cmd.Parameters.AddWithValue("@cLineDis", 0);
                    cmd.Parameters.AddWithValue("@cLineDisAmount", 0);
                    cmd.Parameters.AddWithValue("@cLineVatRate", 0);
                    cmd.Parameters.AddWithValue("@cLineVatAmount", 0);
                    cmd.Parameters.AddWithValue("@cIsReturn", "N");
                    cmd.Parameters.AddWithValue("@cCostOfSale", Convert.ToDouble(cDateGridView.Rows[i].Cells[4].Value) * Convert.ToDouble(cDateGridView.Rows[i].Cells[6].Value));
                    cmd.Parameters.AddWithValue("@cBriefID", cBriefID);

                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
                trans.Commit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                trans.Rollback();
            }
        }

        public long SaveSTKADJBrief()
        {
            long tmpRetID = 0;
            gSB.Clear();
            gSB.Append("INSERT INTO tblSTKADJBrief ( " +
                " DateOn, BillNo, MOP, CustID, Add1, Add2, City, Tp1, Tp2, Tp3, DescriptionOf, GrossTotal, " +
                " NetTotal, CNAmount, TotalPaid, ManAmount, NetAmount, Balance, UserID, UserName, " +
                " CompName, CompID, DelUserID, DelUserName, DelCompID, DelCompName, IsActive, " +
                " DisRate, DisAmount, VatRate, VatAmount, StockRoomID, SystemRefNo, DueDate, " +
                " CSHPaidOn, CHQPaidOn, CCSPAidOn, CREPaidOn, TranCode, NameOf ) " +
                " VALUES ( " +
                " @cDateOn, @cBillNo, @cMOP, @cCustID, @cAdd1, @cAdd2, @cCity, @cTp1, @cTp2, @cTp3, @cDescriptionOf, @cGrossTotal, " +
                " @cNetTotal, @cCNAmount, @cTotalPaid, @cManAmount, @cNetAmount, @cBalance, @cUserID, @cUserName, " +
                " @cCompName, @cCompID, @cDelUserID, @cDelUserName, @cDelCompID, @cDelCompName, @cIsActive, " +
                " @cDisRate, @cDisAmount, @cVatRate, @cVatAmount, @cStockRoomID, @cSystemRefNo, @cDueDate, " +
                " @cCSHPaidOn, @cCHQPaidOn, @cCCSPAidOn, @cCREPaidOn, @cTranCode, @cNameOf); SELECT SCOPE_IDENTITY(); ");

            MySqlCommand cmd = GlobalData.GCon.CreateCommand();
            MySqlTransaction trans = GlobalData.GCon.BeginTransaction();
            cmd.Connection = GlobalData.GCon;
            cmd.Transaction = trans;
            cmd.CommandText = gSB.ToString();

            try
            {
                cmd.Parameters.AddWithValue("@cDateOn", DateOn);
                cmd.Parameters.AddWithValue("@cBillNo", BillNo);
                cmd.Parameters.AddWithValue("@cMOP", MOP);
                cmd.Parameters.AddWithValue("@cCustID", CustID);
                cmd.Parameters.AddWithValue("@cAdd1", Add1);
                cmd.Parameters.AddWithValue("@cAdd2", Add2);
                cmd.Parameters.AddWithValue("@cCity", City);
                cmd.Parameters.AddWithValue("@cTp1", Tp1);
                cmd.Parameters.AddWithValue("@cTp2", Tp2);
                cmd.Parameters.AddWithValue("@cTp3", Tp3);
                cmd.Parameters.AddWithValue("@cDescriptionOf", DescriptionOf);
                cmd.Parameters.AddWithValue("@cGrossTotal", GrossTotal);
                cmd.Parameters.AddWithValue("@cNetTotal", NetTotal);
                cmd.Parameters.AddWithValue("@cCNAmount", CNAmount);
                cmd.Parameters.AddWithValue("@cTotalPaid", TotalPaid);
                cmd.Parameters.AddWithValue("@cManAmount", ManAmount);
                cmd.Parameters.AddWithValue("@cNetAmount", NetAmount);
                cmd.Parameters.AddWithValue("@cBalance", Balance);
                cmd.Parameters.AddWithValue("@cUserID", UserID);
                cmd.Parameters.AddWithValue("@cUserName", UserName);
                cmd.Parameters.AddWithValue("@cCompID", CompID);
                cmd.Parameters.AddWithValue("@cCompName", ComputerName);
                cmd.Parameters.AddWithValue("@cDelUserID", DelUserID);
                cmd.Parameters.AddWithValue("@cDelUserName", DelUserName);
                cmd.Parameters.AddWithValue("@cDelCompID", DelCompID);
                cmd.Parameters.AddWithValue("@cDelCompName", DelComputerName);
                cmd.Parameters.AddWithValue("@cIsActive", IsActive);
                cmd.Parameters.AddWithValue("@cDisRate", DisRate);
                cmd.Parameters.AddWithValue("@cDisAmount", DisAmount);
                cmd.Parameters.AddWithValue("@cVatRate", VatRate);
                cmd.Parameters.AddWithValue("@cVatAmount", VatAmount);
                cmd.Parameters.AddWithValue("@cStockRoomID", StockRoomID);
                cmd.Parameters.AddWithValue("@cSystemRefNo", SystemRefNo);
                cmd.Parameters.AddWithValue("@cDueDate", DueDate);
                cmd.Parameters.AddWithValue("@cCSHPaidOn", CSHPaidOn);
                cmd.Parameters.AddWithValue("@cCHQPaidOn", CHQPaidOn);
                cmd.Parameters.AddWithValue("@cCCSPaidOn", CCSPaidOn);
                cmd.Parameters.AddWithValue("@cCREPaidOn", CREPaidOn);
                cmd.Parameters.AddWithValue("@cTranCode", TranCode);
                cmd.Parameters.AddWithValue("@cNameOf", NameOf);

                tmpRetID = Convert.ToInt64(cmd.ExecuteScalar());
                trans.Commit();
                return tmpRetID;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                return 0;
            }

        }

        public void SaveSTKADJDetail(long cBriefID, DataGridView cDateGridView)
        {
            gSB.Clear();
            gSB.Append("INSERT INTO tblSTKADJDetail ( " +
                " ItemId, SQty, FreeQty, UnitPrice, TotalAmount, Selling, Cost, " +
                " LineDis, LineDisAmount, LineVatRate, LineVatAmount, IsReturn, CostOfSale, BriefID, State) " +
                " VALUES ( " +
                " @cItemId, @cSQty, @cFreeQty, @cUnitPrice, @cTotalAmount, @cSelling, @cCost, " +
                " @cLineDis, @cLineDisAmount, @cLineVatRate, @cLineVatAmount, @cIsReturn, @cCostOfSale, @cBriefID, @State) ");

            MySqlCommand cmd = GlobalData.GCon.CreateCommand();
            MySqlTransaction trans = GlobalData.GCon.BeginTransaction();
            cmd.Connection = GlobalData.GCon;
            cmd.Transaction = trans;
            cmd.CommandText = gSB.ToString();

            try
            {
                for (int i = 0; i < cDateGridView.Rows.Count; i++)
                {
                    cmd.Parameters.AddWithValue("@cItemID", Convert.ToInt32(cDateGridView.Rows[i].Cells[0].Value));
                    cmd.Parameters.AddWithValue("@cSQty", Convert.ToDouble(cDateGridView.Rows[i].Cells[4].Value));
                    cmd.Parameters.AddWithValue("@cFreeQty", 0);
                    cmd.Parameters.AddWithValue("@cUnitPrice", Convert.ToDouble(cDateGridView.Rows[i].Cells[3].Value));
                    cmd.Parameters.AddWithValue("@cTotalAmount", Convert.ToDouble(cDateGridView.Rows[i].Cells[5].Value));
                    cmd.Parameters.AddWithValue("@cSelling", Convert.ToDouble(cDateGridView.Rows[i].Cells[3].Value));
                    cmd.Parameters.AddWithValue("@cCost", Convert.ToDouble(cDateGridView.Rows[i].Cells[6].Value));
                    cmd.Parameters.AddWithValue("@cLineDis", 0);
                    cmd.Parameters.AddWithValue("@cLineDisAmount", 0);
                    cmd.Parameters.AddWithValue("@cLineVatRate", 0);
                    cmd.Parameters.AddWithValue("@cLineVatAmount", 0);
                    cmd.Parameters.AddWithValue("@cIsReturn", "N");
                    cmd.Parameters.AddWithValue("@cCostOfSale", Convert.ToDouble(cDateGridView.Rows[i].Cells[4].Value) * Convert.ToDouble(cDateGridView.Rows[i].Cells[6].Value));
                    cmd.Parameters.AddWithValue("@cBriefID", cBriefID);
                    cmd.Parameters.AddWithValue("@State", cDateGridView.Rows[i].Cells[7].Value.ToString());

                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
                trans.Commit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                trans.Rollback();
            }
        }

        public long SaveGTNBrief()
        {
            long tmpRetID = 0;
            gSB.Clear();
            gSB.Append("INSERT INTO tblGTNBrief ( " +
                " DateOn, BillNo, MOP, CustID, Add1, Add2, City, Tp1, Tp2, Tp3, DescriptionOf, GrossTotal, " +
                " NetTotal, CNAmount, TotalPaid, ManAmount, NetAmount, Balance, UserID, UserName, " +
                " CompName, CompID, DelUserID, DelUserName, DelCompID, DelCompName, IsActive, " +
                " DisRate, DisAmount, VatRate, VatAmount, StockRoomID, SystemRefNo, DueDate, " +
                " CSHPaidOn, CHQPaidOn, CCSPAidOn, CREPaidOn, TranCode, NameOf, FromStockroom, ToStockroom ) " +
                " VALUES ( " +
                " @cDateOn, @cBillNo, @cMOP, @cCustID, @cAdd1, @cAdd2, @cCity, @cTp1, @cTp2, @cTp3, @cDescriptionOf, @cGrossTotal, " +
                " @cNetTotal, @cCNAmount, @cTotalPaid, @cManAmount, @cNetAmount, @cBalance, @cUserID, @cUserName, " +
                " @cCompName, @cCompID, @cDelUserID, @cDelUserName, @cDelCompID, @cDelCompName, @cIsActive, " +
                " @cDisRate, @cDisAmount, @cVatRate, @cVatAmount, @cStockRoomID, @cSystemRefNo, @cDueDate, " +
                " @cCSHPaidOn, @cCHQPaidOn, @cCCSPAidOn, @cCREPaidOn, @cTranCode, @cNameOf, @FromStockroom, @ToStockroom); SELECT SCOPE_IDENTITY(); ");

            MySqlCommand cmd = GlobalData.GCon.CreateCommand();
            MySqlTransaction trans = GlobalData.GCon.BeginTransaction();
            cmd.Connection = GlobalData.GCon;
            cmd.Transaction = trans;
            cmd.CommandText = gSB.ToString();

            try
            {
                cmd.Parameters.AddWithValue("@cDateOn", DateOn);
                cmd.Parameters.AddWithValue("@cBillNo", BillNo);
                cmd.Parameters.AddWithValue("@cMOP", MOP);
                cmd.Parameters.AddWithValue("@cCustID", CustID);
                cmd.Parameters.AddWithValue("@cAdd1", Add1);
                cmd.Parameters.AddWithValue("@cAdd2", Add2);
                cmd.Parameters.AddWithValue("@cCity", City);
                cmd.Parameters.AddWithValue("@cTp1", Tp1);
                cmd.Parameters.AddWithValue("@cTp2", Tp2);
                cmd.Parameters.AddWithValue("@cTp3", Tp3);
                cmd.Parameters.AddWithValue("@cDescriptionOf", DescriptionOf);
                cmd.Parameters.AddWithValue("@cGrossTotal", GrossTotal);
                cmd.Parameters.AddWithValue("@cNetTotal", NetTotal);
                cmd.Parameters.AddWithValue("@cCNAmount", CNAmount);
                cmd.Parameters.AddWithValue("@cTotalPaid", TotalPaid);
                cmd.Parameters.AddWithValue("@cManAmount", ManAmount);
                cmd.Parameters.AddWithValue("@cNetAmount", NetAmount);
                cmd.Parameters.AddWithValue("@cBalance", Balance);
                cmd.Parameters.AddWithValue("@cUserID", UserID);
                cmd.Parameters.AddWithValue("@cUserName", UserName);
                cmd.Parameters.AddWithValue("@cCompID", CompID);
                cmd.Parameters.AddWithValue("@cCompName", ComputerName);
                cmd.Parameters.AddWithValue("@cDelUserID", DelUserID);
                cmd.Parameters.AddWithValue("@cDelUserName", DelUserName);
                cmd.Parameters.AddWithValue("@cDelCompID", DelCompID);
                cmd.Parameters.AddWithValue("@cDelCompName", DelComputerName);
                cmd.Parameters.AddWithValue("@cIsActive", IsActive);
                cmd.Parameters.AddWithValue("@cDisRate", DisRate);
                cmd.Parameters.AddWithValue("@cDisAmount", DisAmount);
                cmd.Parameters.AddWithValue("@cVatRate", VatRate);
                cmd.Parameters.AddWithValue("@cVatAmount", VatAmount);
                cmd.Parameters.AddWithValue("@cStockRoomID", StockRoomID);
                cmd.Parameters.AddWithValue("@cSystemRefNo", SystemRefNo);
                cmd.Parameters.AddWithValue("@cDueDate", DueDate);
                cmd.Parameters.AddWithValue("@cCSHPaidOn", CSHPaidOn);
                cmd.Parameters.AddWithValue("@cCHQPaidOn", CHQPaidOn);
                cmd.Parameters.AddWithValue("@cCCSPaidOn", CCSPaidOn);
                cmd.Parameters.AddWithValue("@cCREPaidOn", CREPaidOn);
                cmd.Parameters.AddWithValue("@cTranCode", TranCode);
                cmd.Parameters.AddWithValue("@cNameOf", NameOf);
                cmd.Parameters.AddWithValue("@FromStockroom", FromStockroom);
                cmd.Parameters.AddWithValue("@ToStockroom", ToStockroom);

                tmpRetID = Convert.ToInt64(cmd.ExecuteScalar());
                trans.Commit();
                return tmpRetID;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                return 0;
            }

        }

        public void SaveGTNDetail(long cBriefID, DataGridView cDateGridView)
        {
            gSB.Clear();
            gSB.Append("INSERT INTO tblGTNDetail ( " +
                " ItemId, SQty, FreeQty, UnitPrice, TotalAmount, Selling, Cost, " +
                " LineDis, LineDisAmount, LineVatRate, LineVatAmount, IsReturn, CostOfSale, BriefID) " +
                " VALUES ( " +
                " @cItemId, @cSQty, @cFreeQty, @cUnitPrice, @cTotalAmount, @cSelling, @cCost, " +
                " @cLineDis, @cLineDisAmount, @cLineVatRate, @cLineVatAmount, @cIsReturn, @cCostOfSale, @cBriefID) ");

            MySqlCommand cmd = GlobalData.GCon.CreateCommand();
            MySqlTransaction trans = GlobalData.GCon.BeginTransaction();
            cmd.Connection = GlobalData.GCon;
            cmd.Transaction = trans;
            cmd.CommandText = gSB.ToString();

            try
            {
                for (int i = 0; i < cDateGridView.Rows.Count; i++)
                {
                    cmd.Parameters.AddWithValue("@cItemID", Convert.ToInt32(cDateGridView.Rows[i].Cells[0].Value));
                    cmd.Parameters.AddWithValue("@cSQty", Convert.ToDouble(cDateGridView.Rows[i].Cells[4].Value));
                    cmd.Parameters.AddWithValue("@cFreeQty", 0);
                    cmd.Parameters.AddWithValue("@cUnitPrice", Convert.ToDouble(cDateGridView.Rows[i].Cells[3].Value));
                    cmd.Parameters.AddWithValue("@cTotalAmount", Convert.ToDouble(cDateGridView.Rows[i].Cells[5].Value));
                    cmd.Parameters.AddWithValue("@cSelling", Convert.ToDouble(cDateGridView.Rows[i].Cells[3].Value));
                    cmd.Parameters.AddWithValue("@cCost", Convert.ToDouble(cDateGridView.Rows[i].Cells[6].Value));
                    cmd.Parameters.AddWithValue("@cLineDis", 0);
                    cmd.Parameters.AddWithValue("@cLineDisAmount", 0);
                    cmd.Parameters.AddWithValue("@cLineVatRate", 0);
                    cmd.Parameters.AddWithValue("@cLineVatAmount", 0);
                    cmd.Parameters.AddWithValue("@cIsReturn", "N");
                    cmd.Parameters.AddWithValue("@cCostOfSale", Convert.ToDouble(cDateGridView.Rows[i].Cells[4].Value) * Convert.ToDouble(cDateGridView.Rows[i].Cells[6].Value));
                    cmd.Parameters.AddWithValue("@cBriefID", cBriefID);

                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
                trans.Commit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                trans.Rollback();
            }
        }

        public long SavePRNBrief()
        {
            long tmpRetID = 0;
            gSB.Clear();
            gSB.Append("INSERT INTO tblPRNBrief ( " +
                " DateOn, BillNo, MOP, CustID, Add1, Add2, City, Tp1, Tp2, Tp3, DescriptionOf, GrossTotal, " +
                " NetTotal, CNAmount, TotalPaid, ManAmount, NetAmount, Balance, UserID, UserName, " +
                " CompName, CompID, DelUserID, DelUserName, DelCompID, DelCompName, IsActive, " +
                " DisRate, DisAmount, VatRate, VatAmount, StockRoomID, SystemRefNo, DueDate, " +
                " CSHPaidOn, CHQPaidOn, CCSPAidOn, CREPaidOn, TranCode, NameOf, PurchaseOrderNo ) " +
                " VALUES ( " +
                " @cDateOn, @cBillNo, @cMOP, @cCustID, @cAdd1, @cAdd2, @cCity, @cTp1, @cTp2, @cTp3, @cDescriptionOf, @cGrossTotal, " +
                " @cNetTotal, @cCNAmount, @cTotalPaid, @cManAmount, @cNetAmount, @cBalance, @cUserID, @cUserName, " +
                " @cCompName, @cCompID, @cDelUserID, @cDelUserName, @cDelCompID, @cDelCompName, @cIsActive, " +
                " @cDisRate, @cDisAmount, @cVatRate, @cVatAmount, @cStockRoomID, @cSystemRefNo, @cDueDate, " +
                " @cCSHPaidOn, @cCHQPaidOn, @cCCSPAidOn, @cCREPaidOn, @cTranCode, @cNameOf, @cPurchaseOrderNo); SELECT SCOPE_IDENTITY(); ");

            MySqlCommand cmd = GlobalData.GCon.CreateCommand();
            MySqlTransaction trans = GlobalData.GCon.BeginTransaction();
            cmd.Connection = GlobalData.GCon;
            cmd.Transaction = trans;
            cmd.CommandText = gSB.ToString();

            try
            {
                cmd.Parameters.AddWithValue("@cDateOn", DateOn);
                cmd.Parameters.AddWithValue("@cBillNo", BillNo);
                cmd.Parameters.AddWithValue("@cMOP", MOP);
                cmd.Parameters.AddWithValue("@cCustID", CustID);
                cmd.Parameters.AddWithValue("@cAdd1", Add1);
                cmd.Parameters.AddWithValue("@cAdd2", Add2);
                cmd.Parameters.AddWithValue("@cCity", City);
                cmd.Parameters.AddWithValue("@cTp1", Tp1);
                cmd.Parameters.AddWithValue("@cTp2", Tp2);
                cmd.Parameters.AddWithValue("@cTp3", Tp3);
                cmd.Parameters.AddWithValue("@cDescriptionOf", DescriptionOf);
                cmd.Parameters.AddWithValue("@cGrossTotal", GrossTotal);
                cmd.Parameters.AddWithValue("@cNetTotal", NetTotal);
                cmd.Parameters.AddWithValue("@cCNAmount", CNAmount);
                cmd.Parameters.AddWithValue("@cTotalPaid", TotalPaid);
                cmd.Parameters.AddWithValue("@cManAmount", ManAmount);
                cmd.Parameters.AddWithValue("@cNetAmount", NetAmount);
                cmd.Parameters.AddWithValue("@cBalance", Balance);
                cmd.Parameters.AddWithValue("@cUserID", UserID);
                cmd.Parameters.AddWithValue("@cUserName", UserName);
                cmd.Parameters.AddWithValue("@cCompID", CompID);
                cmd.Parameters.AddWithValue("@cCompName", ComputerName);
                cmd.Parameters.AddWithValue("@cDelUserID", DelUserID);
                cmd.Parameters.AddWithValue("@cDelUserName", DelUserName);
                cmd.Parameters.AddWithValue("@cDelCompID", DelCompID);
                cmd.Parameters.AddWithValue("@cDelCompName", DelComputerName);
                cmd.Parameters.AddWithValue("@cIsActive", IsActive);
                cmd.Parameters.AddWithValue("@cDisRate", DisRate);
                cmd.Parameters.AddWithValue("@cDisAmount", DisAmount);
                cmd.Parameters.AddWithValue("@cVatRate", VatRate);
                cmd.Parameters.AddWithValue("@cVatAmount", VatAmount);
                cmd.Parameters.AddWithValue("@cStockRoomID", StockRoomID);
                cmd.Parameters.AddWithValue("@cSystemRefNo", SystemRefNo);
                cmd.Parameters.AddWithValue("@cDueDate", DueDate);
                cmd.Parameters.AddWithValue("@cCSHPaidOn", CSHPaidOn);
                cmd.Parameters.AddWithValue("@cCHQPaidOn", CHQPaidOn);
                cmd.Parameters.AddWithValue("@cCCSPaidOn", CCSPaidOn);
                cmd.Parameters.AddWithValue("@cCREPaidOn", CREPaidOn);
                cmd.Parameters.AddWithValue("@cTranCode", TranCode);
                cmd.Parameters.AddWithValue("@cNameOf", NameOf);
                cmd.Parameters.AddWithValue("@cPurchaseOrderNo", PurchaseOrderNo);

                tmpRetID = Convert.ToInt64(cmd.ExecuteScalar());
                trans.Commit();
                return tmpRetID;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                MessageBox.Show(ex.Message);
                return 0;
            }

        }

        public void SavePRNDetail(long cBriefID, DataGridView cDateGridView)
        {
            gSB.Clear();
            gSB.Append("INSERT INTO tblPRNDetail ( " +
                " ItemId, SQty, FreeQty, UnitPrice, TotalAmount, Selling, Cost, " +
                " LineDis, LineDisAmount, LineVatRate, LineVatAmount, IsReturn, CostOfSale, BriefID) " +
                " VALUES ( " +
                " @cItemId, @cSQty, @cFreeQty, @cUnitPrice, @cTotalAmount, @cSelling, @cCost, " +
                " @cLineDis, @cLineDisAmount, @cLineVatRate, @cLineVatAmount, @cIsReturn, @cCostOfSale, @cBriefID) ");

            MySqlCommand cmd = GlobalData.GCon.CreateCommand();
            MySqlTransaction trans = GlobalData.GCon.BeginTransaction();
            cmd.Connection = GlobalData.GCon;
            cmd.Transaction = trans;
            cmd.CommandText = gSB.ToString();

            try
            {
                for (int i = 0; i < cDateGridView.Rows.Count; i++)
                {
                    cmd.Parameters.AddWithValue("@cItemID", Convert.ToInt32(cDateGridView.Rows[i].Cells[0].Value));
                    cmd.Parameters.AddWithValue("@cSQty", Convert.ToDouble(cDateGridView.Rows[i].Cells[5].Value));
                    cmd.Parameters.AddWithValue("@cFreeQty", Convert.ToDouble(cDateGridView.Rows[i].Cells[4].Value));
                    cmd.Parameters.AddWithValue("@cUnitPrice", Convert.ToDouble(cDateGridView.Rows[i].Cells[3].Value));
                    cmd.Parameters.AddWithValue("@cTotalAmount", Convert.ToDouble(cDateGridView.Rows[i].Cells[6].Value));
                    cmd.Parameters.AddWithValue("@cSelling", Convert.ToDouble(cDateGridView.Rows[i].Cells[3].Value));
                    cmd.Parameters.AddWithValue("@cCost", Convert.ToDouble(cDateGridView.Rows[i].Cells[7].Value));
                    cmd.Parameters.AddWithValue("@cLineDis", 0);
                    cmd.Parameters.AddWithValue("@cLineDisAmount", 0);
                    cmd.Parameters.AddWithValue("@cLineVatRate", 0);
                    cmd.Parameters.AddWithValue("@cLineVatAmount", 0);
                    cmd.Parameters.AddWithValue("@cIsReturn", "N");
                    cmd.Parameters.AddWithValue("@cCostOfSale", Convert.ToDouble(cDateGridView.Rows[i].Cells[5].Value) * Convert.ToDouble(cDateGridView.Rows[i].Cells[7].Value));
                    cmd.Parameters.AddWithValue("@cBriefID", cBriefID);

                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
                trans.Commit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                trans.Rollback();
            }
        }

        public void SaveSTOCKFlow(long cBriefID, DataGridView cDateGridView)
        {
            gSB.Clear();
            gSB.Append("INSERT INTO tblBinCard ( " +
                " BillNo, DateOn, ItemID, SQty, FreeQty, UnitPrice, QtyIn, QtyOut, HeaderName, " +
                " UserID, UserName, CompID, CompName, DelUserID, DelUserName, DelCompID, DelCompName, IsActive, IsDeleted, " +
                " TotalAmount, Selling, Cost, LineDis, LineDisAmount, LineVatRate, LineVatAmount, SaleBillID, TranCode, StockRoomID ) " +
                " VALUES ( " +
                " @BillNo, @DateOn, @ItemID, @SQty, @FreeQty, @UnitPrice, @QtyIn, @QtyOut, @HeaderName, " +
                " @UserID, @UserName, @CompID, @CompName, @DelUserID, @DelUserName, @DelCompID, @DelCompName, @IsActive, @IsDeleted, " +
                " @TotalAmount, @Selling, @Cost, @LineDis, @LineDisAmount, @LineVatRate, @LineVatAmount, @SaleBillID, @TranCode, @StockRoomID ) ");

            MySqlCommand cmd = GlobalData.GCon.CreateCommand();
            MySqlTransaction trans = GlobalData.GCon.BeginTransaction();
            cmd.Connection = GlobalData.GCon;
            cmd.Transaction = trans;
            cmd.CommandText = gSB.ToString();

            try
            {
                for (int i = 0; i < cDateGridView.Rows.Count; i++)
                {
                    cmd.Parameters.AddWithValue("@BillNo", BillNo);
                    cmd.Parameters.AddWithValue("@DateOn", DateOn);
                    cmd.Parameters.AddWithValue("@ItemID", Convert.ToInt32(cDateGridView.Rows[i].Cells[0].Value));
                    cmd.Parameters.AddWithValue("@SQty", Convert.ToDouble(cDateGridView.Rows[i].Cells[4].Value));
                    cmd.Parameters.AddWithValue("@FreeQty", 0);

                    cmd.Parameters.AddWithValue("@UnitPrice", Convert.ToDouble(cDateGridView.Rows[i].Cells[3].Value));
                    if (cDateGridView.Rows[i].Cells[7].Value.ToString() == "ADD")
                    {
                        cmd.Parameters.AddWithValue("@QtyIn", Convert.ToDouble(cDateGridView.Rows[i].Cells[4].Value));
                        cmd.Parameters.AddWithValue("@QtyOut", 0);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@QtyIn", 0);
                        cmd.Parameters.AddWithValue("@QtyOut", Convert.ToDouble(cDateGridView.Rows[i].Cells[4].Value));
                    }

                    cmd.Parameters.AddWithValue("@HeaderName", HeaderName);
                    cmd.Parameters.AddWithValue("@UserID", UserID);
                    cmd.Parameters.AddWithValue("@UserName", UserName);
                    cmd.Parameters.AddWithValue("@CompID", CompID);
                    cmd.Parameters.AddWithValue("@CompName", ComputerName);
                    cmd.Parameters.AddWithValue("@DelUserID", DelUserID);
                    cmd.Parameters.AddWithValue("@DelUserName", DelUserName);
                    cmd.Parameters.AddWithValue("@DelCompID", DelCompID);
                    cmd.Parameters.AddWithValue("@DelCompName", DelComputerName);
                    cmd.Parameters.AddWithValue("@IsActive", IsActive);
                    cmd.Parameters.AddWithValue("@IsDeleted", "N");
                    cmd.Parameters.AddWithValue("@TotalAmount", Convert.ToDouble(cDateGridView.Rows[i].Cells[5].Value));
                    cmd.Parameters.AddWithValue("@Selling", Convert.ToDouble(cDateGridView.Rows[i].Cells[3].Value));
                    cmd.Parameters.AddWithValue("@Cost", Convert.ToDouble(cDateGridView.Rows[i].Cells[6].Value));
                    cmd.Parameters.AddWithValue("@LineDis", 0);
                    cmd.Parameters.AddWithValue("@LineDisAmount", 0);
                    cmd.Parameters.AddWithValue("@LineVatRate", 0);
                    cmd.Parameters.AddWithValue("@LineVatAmount", 0);
                    cmd.Parameters.AddWithValue("@SaleBillID", SaleBillID);
                    cmd.Parameters.AddWithValue("@TranCode", TranCode);
                    cmd.Parameters.AddWithValue("@StockRoomID", StockRoomID);

                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
                trans.Commit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                trans.Rollback();
            }
        }

        public void SaveSetStockRoom(DataGridView cDateGridView)
        {

            MySqlCommand command = new MySqlCommand("TRUNCATE TABLE tblSetCompStockRoom", GlobalData.GCon);
            command.ExecuteNonQuery();

            gSB.Clear();
            gSB.Append("INSERT INTO tblSetCompStockRoom ( " +
                " CompID, StockRoomID ) " +
                " VALUES ( " +
                " @CompID, @StockRoomID) ");

            MySqlCommand cmd = GlobalData.GCon.CreateCommand();
            MySqlTransaction trans = GlobalData.GCon.BeginTransaction();
            cmd.Connection = GlobalData.GCon;
            cmd.Transaction = trans;
            cmd.CommandText = gSB.ToString();

            try
            {
                for (int i = 0; i < cDateGridView.Rows.Count; i++)
                {
                    cmd.Parameters.AddWithValue("@CompID", Convert.ToInt32(cDateGridView.Rows[i].Cells[0].Value));
                    cmd.Parameters.AddWithValue("@StockRoomID", Convert.ToInt32(cDateGridView.Rows[i].Cells[2].Value));

                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
                trans.Commit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                trans.Rollback();
            }
        }

        public long SaveCHQDepositBrief()
        {
            long tmpRetID = 0;
            gSB.Clear();
            gSB.Append("INSERT INTO tblChqDepositBrief ( " +
                " RefNo, TotalChq, ChqValue, BankID, Notes, DepositedOn, DepositedBy, " +
                " PerformedOn, UserID, UserName, CompID, CompName) " +
                " VALUES ( " +
                " @RefNo, @TotalChq, @ChqValue, @BankID, @Notes, @DepositedOn, @DepositedBy, " +
                " NOW(), @UserID, @UserName, @CompID, @CompName); SELECT SCOPE_IDENTITY(); ");

            MySqlCommand cmd = GlobalData.GCon.CreateCommand();
            MySqlTransaction trans = GlobalData.GCon.BeginTransaction();
            cmd.Connection = GlobalData.GCon;
            cmd.Transaction = trans;
            cmd.CommandText = gSB.ToString();

            try
            {
                cmd.Parameters.AddWithValue("@RefNo", RefNo);
                cmd.Parameters.AddWithValue("@TotalChq", TotalChq);
                cmd.Parameters.AddWithValue("@ChqValue", ChqValue);
                cmd.Parameters.AddWithValue("@Notes", Notes);
                cmd.Parameters.AddWithValue("@DepositedOn", DepositedOn);
                cmd.Parameters.AddWithValue("@DepositedBy", DepositedBy);
                cmd.Parameters.AddWithValue("@UserID", UserID);
                cmd.Parameters.AddWithValue("@UserName", UserName);
                cmd.Parameters.AddWithValue("@CompID", CompID);
                cmd.Parameters.AddWithValue("@CompName", ComputerName);
                cmd.Parameters.AddWithValue("@BankID", BankID);

                tmpRetID = Convert.ToInt64(cmd.ExecuteScalar());
                trans.Commit();
                return tmpRetID;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                return 0;
            }

        }

        public void SaveCHQDepositDetail(long cBriefID, ListView cListView)
        {
            gSB.Clear();
            gSB.Append("INSERT INTO tblChqDepositDetail ( " +
                " BriefID, ChqNo, ChqValue, MOPID ) " +
                " VALUES ( " +
                " @BriefID, @ChqNo, @ChqValue, @MOPID) ");

            MySqlCommand cmd = GlobalData.GCon.CreateCommand();
            MySqlTransaction trans = GlobalData.GCon.BeginTransaction();
            cmd.Connection = GlobalData.GCon;
            cmd.Transaction = trans;
            cmd.CommandText = gSB.ToString();

            try
            {
                for (int i = 0; i < cListView.Items.Count; i++)
                {
                    cmd.Parameters.AddWithValue("@BriefID", cBriefID);
                    cmd.Parameters.AddWithValue("@ChqNo", cListView.Items[i].SubItems[2].Text);
                    cmd.Parameters.AddWithValue("@ChqValue", Convert.ToDouble(cListView.Items[i].SubItems[3].Text));
                    cmd.Parameters.AddWithValue("@MOPID", cListView.Items[i].SubItems[6].Text);

                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
                trans.Commit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                trans.Rollback();
            }
        }

        public long SaveCHQRealizeBrief()
        {
            long tmpRetID = 0;
            gSB.Clear();
            gSB.Append("INSERT INTO tblChqRealizeBrief ( " +
                " RefNo, TotalChq, ChqValue, BankID, Notes, RealizedOn, " +
                " PerformedOn, UserID, UserName, CompID, CompName) " +
                " VALUES ( " +
                " @RefNo, @TotalChq, @ChqValue, @BankID, @Notes, @RealizedOn, " +
                " NOW(), @UserID, @UserName, @CompID, @CompName); SELECT SCOPE_IDENTITY(); ");

            MySqlCommand cmd = GlobalData.GCon.CreateCommand();
            MySqlTransaction trans = GlobalData.GCon.BeginTransaction();
            cmd.Connection = GlobalData.GCon;
            cmd.Transaction = trans;
            cmd.CommandText = gSB.ToString();

            try
            {
                cmd.Parameters.AddWithValue("@RefNo", RefNo);
                cmd.Parameters.AddWithValue("@TotalChq", TotalChq);
                cmd.Parameters.AddWithValue("@ChqValue", ChqValue);
                cmd.Parameters.AddWithValue("@Notes", Notes);
                cmd.Parameters.AddWithValue("@RealizedOn", RealizedOn);
                cmd.Parameters.AddWithValue("@UserID", UserID);
                cmd.Parameters.AddWithValue("@UserName", UserName);
                cmd.Parameters.AddWithValue("@CompID", CompID);
                cmd.Parameters.AddWithValue("@CompName", ComputerName);
                cmd.Parameters.AddWithValue("@BankID", BankID);

                tmpRetID = Convert.ToInt64(cmd.ExecuteScalar());
                trans.Commit();
                return tmpRetID;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                MessageBox.Show(ex.Message);
                return 0;
            }

        }

        public void SaveCHQRealizeDetail(long cBriefID, ListView cListView)
        {
            gSB.Clear();
            gSB.Append("INSERT INTO tblChqRealizeDetail ( " +
                " BriefID, ChqNo, ChqValue, MOPID ) " +
                " VALUES ( " +
                " @BriefID, @ChqNo, @ChqValue, @MOPID) ");

            MySqlCommand cmd = GlobalData.GCon.CreateCommand();
            MySqlTransaction trans = GlobalData.GCon.BeginTransaction();
            cmd.Connection = GlobalData.GCon;
            cmd.Transaction = trans;
            cmd.CommandText = gSB.ToString();

            try
            {
                for (int i = 0; i < cListView.Items.Count; i++)
                {
                    cmd.Parameters.AddWithValue("@BriefID", cBriefID);
                    cmd.Parameters.AddWithValue("@ChqNo", cListView.Items[i].SubItems[2].Text);
                    cmd.Parameters.AddWithValue("@ChqValue", Convert.ToDouble(cListView.Items[i].SubItems[3].Text));
                    cmd.Parameters.AddWithValue("@MOPID", cListView.Items[i].SubItems[6].Text);

                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
                trans.Commit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                trans.Rollback();
            }
        }

        public long SaveCHQReturnBrief()
        {
            long tmpRetID = 0;
            gSB.Clear();
            gSB.Append("INSERT INTO tblChqReturnBrief ( " +
                " RefNo, TotalChq, ChqValue, BankID, Notes, ReturnedOn, " +
                " PerformedOn, UserID, UserName, CompID, CompName) " +
                " VALUES ( " +
                " @RefNo, @TotalChq, @ChqValue, @BankID, @Notes, @ReturnedOn, " +
                " NOW(), @UserID, @UserName, @CompID, @CompName); SELECT SCOPE_IDENTITY(); ");

            MySqlCommand cmd = GlobalData.GCon.CreateCommand();
            MySqlTransaction trans = GlobalData.GCon.BeginTransaction();
            cmd.Connection = GlobalData.GCon;
            cmd.Transaction = trans;
            cmd.CommandText = gSB.ToString();

            try
            {
                cmd.Parameters.AddWithValue("@RefNo", RefNo);
                cmd.Parameters.AddWithValue("@TotalChq", TotalChq);
                cmd.Parameters.AddWithValue("@ChqValue", ChqValue);
                cmd.Parameters.AddWithValue("@Notes", Notes);
                cmd.Parameters.AddWithValue("@ReturnedOn", ReturnedOn);
                cmd.Parameters.AddWithValue("@UserID", UserID);
                cmd.Parameters.AddWithValue("@UserName", UserName);
                cmd.Parameters.AddWithValue("@CompID", CompID);
                cmd.Parameters.AddWithValue("@CompName", ComputerName);
                cmd.Parameters.AddWithValue("@BankID", BankID);

                tmpRetID = Convert.ToInt64(cmd.ExecuteScalar());
                trans.Commit();
                return tmpRetID;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                MessageBox.Show(ex.Message);
                return 0;
            }

        }

        public void SaveCHQReturnDetail(long cBriefID, ListView cListView)
        {
            gSB.Clear();
            gSB.Append("INSERT INTO tblChqReturnDetail ( " +
                " BriefID, ChqNo, ChqValue, MOPID ) " +
                " VALUES ( " +
                " @BriefID, @ChqNo, @ChqValue, @MOPID) ");

            MySqlCommand cmd = GlobalData.GCon.CreateCommand();
            MySqlTransaction trans = GlobalData.GCon.BeginTransaction();
            cmd.Connection = GlobalData.GCon;
            cmd.Transaction = trans;
            cmd.CommandText = gSB.ToString();

            try
            {
                for (int i = 0; i < cListView.Items.Count; i++)
                {
                    cmd.Parameters.AddWithValue("@BriefID", cBriefID);
                    cmd.Parameters.AddWithValue("@ChqNo", cListView.Items[i].SubItems[2].Text);
                    cmd.Parameters.AddWithValue("@ChqValue", Convert.ToDouble(cListView.Items[i].SubItems[3].Text));
                    cmd.Parameters.AddWithValue("@MOPID", cListView.Items[i].SubItems[6].Text);

                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
                trans.Commit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                trans.Rollback();
            }
        }

        public long SaveSALEBrief()
        {
            long tmpRetID = 0;
            gSB.Clear();
            gSB.Append("INSERT INTO tblSaleBrief ( " +
                " DateOn, BillNo, MOP, CustID, Add1, Add2, City, Tp1, Tp2, Tp3, DescriptionOf, GrossTotal, " +
                " NetTotal, CNAmount, TotalPaid, ManAmount, NetAmount, Balance, UserID, UserName, " +
                " CompName, CompID, DelUserID, DelUserName, DelCompID, DelCompName, IsActive, " +
                " DisRate, DisAmount, VatRate, VatAmount, StockRoomID, SystemRefNo, DueDate, " +
                " CSHPaidOn, CHQPaidOn, CCSPAidOn, CREPaidOn, TranCode, NameOf ) " +
                " VALUES ( " +
                " @cDateOn, @cBillNo, @cMOP, @cCustID, @cAdd1, @cAdd2, @cCity, @cTp1, @cTp2, @cTp3, @cDescriptionOf, @cGrossTotal, " +
                " @cNetTotal, @cCNAmount, @cTotalPaid, @cManAmount, @cNetAmount, @cBalance, @cUserID, @cUserName, " +
                " @cCompName, @cCompID, @cDelUserID, @cDelUserName, @cDelCompID, @cDelCompName, @cIsActive, " +
                " @cDisRate, @cDisAmount, @cVatRate, @cVatAmount, @cStockRoomID, @cSystemRefNo, @cDueDate, " +
                " @cCSHPaidOn, @cCHQPaidOn, @cCCSPAidOn, @cCREPaidOn, @cTranCode, @cNameOf); SELECT SCOPE_IDENTITY(); ");

            MySqlCommand cmd = GlobalData.GCon.CreateCommand();
            MySqlTransaction trans = GlobalData.GCon.BeginTransaction();
            cmd.Connection = GlobalData.GCon;
            cmd.Transaction = trans;
            cmd.CommandText = gSB.ToString();

            try
            {
                cmd.Parameters.AddWithValue("@cDateOn", DateOn);
                cmd.Parameters.AddWithValue("@cBillNo", BillNo);
                cmd.Parameters.AddWithValue("@cMOP", MOP);
                cmd.Parameters.AddWithValue("@cCustID", CustID);
                cmd.Parameters.AddWithValue("@cAdd1", Add1);
                cmd.Parameters.AddWithValue("@cAdd2", Add2);
                cmd.Parameters.AddWithValue("@cCity", City);
                cmd.Parameters.AddWithValue("@cTp1", Tp1);
                cmd.Parameters.AddWithValue("@cTp2", Tp2);
                cmd.Parameters.AddWithValue("@cTp3", Tp3);
                cmd.Parameters.AddWithValue("@cDescriptionOf", DescriptionOf);
                cmd.Parameters.AddWithValue("@cGrossTotal", GrossTotal);
                cmd.Parameters.AddWithValue("@cNetTotal", NetTotal);
                cmd.Parameters.AddWithValue("@cCNAmount", CNAmount);
                cmd.Parameters.AddWithValue("@cTotalPaid", TotalPaid);
                cmd.Parameters.AddWithValue("@cManAmount", ManAmount);
                cmd.Parameters.AddWithValue("@cNetAmount", NetAmount);
                cmd.Parameters.AddWithValue("@cBalance", Balance);
                cmd.Parameters.AddWithValue("@cUserID", UserID);
                cmd.Parameters.AddWithValue("@cUserName", UserName);
                cmd.Parameters.AddWithValue("@cCompID", CompID);
                cmd.Parameters.AddWithValue("@cCompName", ComputerName);
                cmd.Parameters.AddWithValue("@cDelUserID", DelUserID);
                cmd.Parameters.AddWithValue("@cDelUserName", DelUserName);
                cmd.Parameters.AddWithValue("@cDelCompID", DelCompID);
                cmd.Parameters.AddWithValue("@cDelCompName", DelComputerName);
                cmd.Parameters.AddWithValue("@cIsActive", IsActive);
                cmd.Parameters.AddWithValue("@cDisRate", DisRate);
                cmd.Parameters.AddWithValue("@cDisAmount", DisAmount);
                cmd.Parameters.AddWithValue("@cVatRate", VatRate);
                cmd.Parameters.AddWithValue("@cVatAmount", VatAmount);
                cmd.Parameters.AddWithValue("@cStockRoomID", StockRoomID);
                cmd.Parameters.AddWithValue("@cSystemRefNo", SystemRefNo);
                cmd.Parameters.AddWithValue("@cDueDate", DueDate);
                cmd.Parameters.AddWithValue("@cCSHPaidOn", CSHPaidOn);
                cmd.Parameters.AddWithValue("@cCHQPaidOn", CHQPaidOn);
                cmd.Parameters.AddWithValue("@cCCSPaidOn", CCSPaidOn);
                cmd.Parameters.AddWithValue("@cCREPaidOn", CREPaidOn);
                cmd.Parameters.AddWithValue("@cTranCode", TranCode);
                cmd.Parameters.AddWithValue("@cNameOf", NameOf);

                tmpRetID = Convert.ToInt64(cmd.ExecuteScalar());
                trans.Commit();
                return tmpRetID;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                MessageBox.Show(ex.Message);
                return 0;
            }

        }

        public void SaveSaleDetail(long cBriefID, DataGridView cDateGridView)
        {
            gSB.Clear();
            gSB.Append("INSERT INTO tblSaleDetail ( " +
                " ItemId, SQty, FreeQty, UnitPrice, TotalAmount, Selling, Cost, " +
                " LineDis, LineDisAmount, LineVatRate, LineVatAmount, IsReturn, CostOfSale, BriefID) " +
                " VALUES ( " +
                " @cItemId, @cSQty, @cFreeQty, @cUnitPrice, @cTotalAmount, @cSelling, @cCost, " +
                " @cLineDis, @cLineDisAmount, @cLineVatRate, @cLineVatAmount, @cIsReturn, @cCostOfSale, @cBriefID) ");

            MySqlCommand cmd = GlobalData.GCon.CreateCommand();
            MySqlTransaction trans = GlobalData.GCon.BeginTransaction();
            cmd.Connection = GlobalData.GCon;
            cmd.Transaction = trans;
            cmd.CommandText = gSB.ToString();

            try
            {
                for (int i = 0; i < cDateGridView.Rows.Count; i++)
                {
                    cmd.Parameters.AddWithValue("@cItemID", Convert.ToInt32(cDateGridView.Rows[i].Cells[0].Value));
                    cmd.Parameters.AddWithValue("@cSQty", Convert.ToDouble(cDateGridView.Rows[i].Cells[5].Value));
                    cmd.Parameters.AddWithValue("@cFreeQty", Convert.ToDouble(cDateGridView.Rows[i].Cells[4].Value));
                    cmd.Parameters.AddWithValue("@cUnitPrice", Convert.ToDouble(cDateGridView.Rows[i].Cells[3].Value));
                    cmd.Parameters.AddWithValue("@cTotalAmount", Convert.ToDouble(cDateGridView.Rows[i].Cells[6].Value));
                    cmd.Parameters.AddWithValue("@cSelling", Convert.ToDouble(cDateGridView.Rows[i].Cells[3].Value));
                    cmd.Parameters.AddWithValue("@cCost", Convert.ToDouble(cDateGridView.Rows[i].Cells[7].Value));
                    cmd.Parameters.AddWithValue("@cLineDis", 0);
                    cmd.Parameters.AddWithValue("@cLineDisAmount", 0);
                    cmd.Parameters.AddWithValue("@cLineVatRate", 0);
                    cmd.Parameters.AddWithValue("@cLineVatAmount", 0);
                    cmd.Parameters.AddWithValue("@cIsReturn", "N");
                    cmd.Parameters.AddWithValue("@cCostOfSale", Convert.ToDouble(cDateGridView.Rows[i].Cells[5].Value) * Convert.ToDouble(cDateGridView.Rows[i].Cells[7].Value));
                    cmd.Parameters.AddWithValue("@cBriefID", cBriefID);

                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
                trans.Commit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                trans.Rollback();
            }
        }

        public long SaveMOP_NEW(long cBriefID)
        {
            long tmpRetID = 0;
            gSB.Clear();
            gSB.Append("INSERT INTO tblMOP ( " +
                " MopType, NetAmount, BankID, CHQNo, CHQDate, Comments, CardID, ExpairDate, " +
                " IsDeposited, IsRealized, IsActive, RefNo, TotalPaid, " +
                " IsReturned, OwnerID, OwnerName, CashTendered, Balance, " +
                " UserID, UserName, CompName, CompID, DelUserID, DelUserName, DelCompID, DelCompName, BillId, BranchId, BillsFor, " +
                " Bank, Branch, CardCompany, DateOn) " +
                " VALUES ( " +
                " @MopType, @NetAmount, @BankID, @CHQNo, @CHQDate, @Comments, @CardID, @ExpairDate, " +
                " @IsDeposited, @IsRealized, @IsActive, @RefNo, @TotalPaid, " +
                " @IsReturned, @OwnerID, @OwnerName, @CashTendered, @Balance, " +
                " @cUserID, @cUserName, @cComputerName, @cCompID, @cDelUserID, @cDelUserName, @cDelCompID, @cDelCompName, @BillID, @BranchId, @BillsFor, " +
                " @Bank, @Branch, @CardCompany, @DateOn); SELECT SCOPE_IDENTITY(); ");
            MySqlCommand cmd = GlobalData.GCon.CreateCommand();
            MySqlTransaction trans = GlobalData.GCon.BeginTransaction();
            cmd.Connection = GlobalData.GCon;
            cmd.Transaction = trans;
            cmd.CommandText = gSB.ToString();

            try
            {
                cmd.Parameters.AddWithValue("@MopType", MOPType);
                cmd.Parameters.AddWithValue("@NetAmount", NetAmount);
                cmd.Parameters.AddWithValue("@BankID", BankID);
                cmd.Parameters.AddWithValue("@CHQNo", CHQNo);
                cmd.Parameters.AddWithValue("@CHQDate", CHQDate);
                cmd.Parameters.AddWithValue("@Comments", Comments);
                cmd.Parameters.AddWithValue("@CardID", CardID);
                cmd.Parameters.AddWithValue("@ExpairDate", ExpairDate);
                cmd.Parameters.AddWithValue("@IsDeposited", IsDeposited);
                cmd.Parameters.AddWithValue("@IsRealized", IsRealized);
                cmd.Parameters.AddWithValue("@IsActive", IsActive);
                cmd.Parameters.AddWithValue("@RefNo", RefNo);
                cmd.Parameters.AddWithValue("@TotalPaid", TotalPaid);
                cmd.Parameters.AddWithValue("@IsReturned", IsReturned);
                cmd.Parameters.AddWithValue("@OwnerID", OwnerID);
                cmd.Parameters.AddWithValue("@OwnerName", OwnerName);
                cmd.Parameters.AddWithValue("@CashTendered", CashTendered);
                cmd.Parameters.AddWithValue("@Balance", Balance);
                cmd.Parameters.AddWithValue("@cUserID", UserID);
                cmd.Parameters.AddWithValue("@cUserName", UserName);
                cmd.Parameters.AddWithValue("@cCompID", CompID);
                cmd.Parameters.AddWithValue("@cComputerName", ComputerName);
                cmd.Parameters.AddWithValue("@cDelUserID", DelUserID);
                cmd.Parameters.AddWithValue("@cDelUserName", DelUserName);
                cmd.Parameters.AddWithValue("@cDelCompID", DelCompID);
                cmd.Parameters.AddWithValue("@cDelCompName", DelComputerName);
                cmd.Parameters.AddWithValue("@BillID", cBriefID);
                cmd.Parameters.AddWithValue("@BranchId", BranchID);
                cmd.Parameters.AddWithValue("@BillsFor", BillsFor);
                cmd.Parameters.AddWithValue("@Branch", Branch);
                cmd.Parameters.AddWithValue("@Bank", Bank);
                cmd.Parameters.AddWithValue("@CardCompany", CardCompany);
                cmd.Parameters.AddWithValue("@DateOn", DateOn);

                tmpRetID = Convert.ToInt64(cmd.ExecuteScalar());
                trans.Commit();
                return tmpRetID;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                trans.Rollback();
                return 0;
            }
        }

        public long SaveCustPayBrief()
        {
            long tmpRetID = 0;
            gSB.Clear();
            gSB.Append("INSERT INTO tblCustPayBrief ( " +
                " DateOn,BillNo, CustId, Add1, Add2, City, Tp1, Tp2, Tp3, DescriptionOf,NetTotal, " +
                " PerformedOn, UserId, UserName, CompId, CompName, isDeleted, DelUserId, DelUserName, " +
                " DelCompId, DelCompName, isActive, TranCode, MopId, GrandOutStanding, NameOf ) " +
                " VALUES ( " +
                " @cDateOn, @cBillNo, @cCustID, @cAdd1, @cAdd2, @cCity, @cTp1, @cTp2, @cTp3, @cDescriptionOf, @cNetTotal, " +
                " @cPerformedOn, @cUserID, @cUserName, @cCompId, @cCompName, @cisDeleted, @cDelUserId, @cDelUserName, " +
                " @cDelCompId, @cDelCompName, @cisActive, @cTranCode, @cMopId," +
                " @cGrandOutStanding, @cNameOf);SELECT SCOPE_IDENTITY(); ");

            MySqlCommand cmd = GlobalData.GCon.CreateCommand();
            MySqlTransaction trans = GlobalData.GCon.BeginTransaction();
            cmd.Connection = GlobalData.GCon;
            cmd.Transaction = trans;
            cmd.CommandText = gSB.ToString();

            try
            {
                cmd.Parameters.AddWithValue("@cDateOn", DateOn);
                cmd.Parameters.AddWithValue("@cBillNo", BillNo);
                cmd.Parameters.AddWithValue("@cCustID", CustID);
                cmd.Parameters.AddWithValue("@cAdd1", Add1);
                cmd.Parameters.AddWithValue("@cAdd2", Add2);
                cmd.Parameters.AddWithValue("@cCity", City);
                cmd.Parameters.AddWithValue("@cTp1", Tp1);
                cmd.Parameters.AddWithValue("@cTp2", Tp2);
                cmd.Parameters.AddWithValue("@cTp3", Tp3);
                cmd.Parameters.AddWithValue("@cDescriptionOf", DescriptionOf);
                cmd.Parameters.AddWithValue("@cNetTotal", NetTotal);
                cmd.Parameters.AddWithValue("@cPerformedOn", PerformedOn);
                cmd.Parameters.AddWithValue("@cUserID", UserID);
                cmd.Parameters.AddWithValue("@cUserName", UserName);
                cmd.Parameters.AddWithValue("@cCompID", CompID);
                cmd.Parameters.AddWithValue("@cCompName", ComputerName);
                cmd.Parameters.AddWithValue("@cisDeleted", IsDeleted);
                cmd.Parameters.AddWithValue("@cDelUserID", DelUserID);
                cmd.Parameters.AddWithValue("@cDelUserName", DelUserName);
                cmd.Parameters.AddWithValue("@cDelCompID", DelCompID);
                cmd.Parameters.AddWithValue("@cDelCompName", DelComputerName);
                cmd.Parameters.AddWithValue("@cisActive", IsActive);
                cmd.Parameters.AddWithValue("@cTranCode", TranCode);
                cmd.Parameters.AddWithValue("@cMopId", MopID);
                cmd.Parameters.AddWithValue("@cGrandoutStanding", GrandOutStanding);
                cmd.Parameters.AddWithValue("@cNameOf", NameOf);

                tmpRetID = Convert.ToInt64(cmd.ExecuteScalar());
                trans.Commit();
                return tmpRetID;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                trans.Rollback();
                return 0;
            }

        }

        public void SaveCustPayDetail(int cPaidID, int cMOPID)
        {
            gSB.Clear();
            gSB.Append("INSERT INTO tblCustPayDetail ( " +
                " PaidID, MOPID ) " +
                " VALUES ( " +
                " @PaidID, @MOPID ) ");

            MySqlCommand cmd = GlobalData.GCon.CreateCommand();
            MySqlTransaction trans = GlobalData.GCon.BeginTransaction();
            cmd.Connection = GlobalData.GCon;
            cmd.Transaction = trans;
            cmd.CommandText = gSB.ToString();

            try
            {
                cmd.Parameters.AddWithValue("@PaidID", cPaidID);
                cmd.Parameters.AddWithValue("@MOPID", cMOPID);

                cmd.ExecuteNonQuery();
                trans.Commit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                trans.Rollback();
            }

        }

        public void SaveCustPayDetail(int cPaidID, int cMOPID, int cSaleBillId, double cAmount)
        {
            gSB.Clear();
            gSB.Append("INSERT INTO tblCustPayDetail ( " +
                " PaidID, MOPID, SaleBillID, Amount ) " +
                " VALUES ( " +
                " @PaidID, @MOPID, @SaleBillID, @Amount ) ");

            MySqlCommand cmd = GlobalData.GCon.CreateCommand();
            MySqlTransaction trans = GlobalData.GCon.BeginTransaction();
            cmd.Connection = GlobalData.GCon;
            cmd.Transaction = trans;
            cmd.CommandText = gSB.ToString();

            try
            {
                cmd.Parameters.AddWithValue("@PaidID", cPaidID);
                cmd.Parameters.AddWithValue("@MOPID", cMOPID);
                cmd.Parameters.AddWithValue("@SaleBillID", cSaleBillId);
                cmd.Parameters.AddWithValue("@Amount", cAmount);

                cmd.ExecuteNonQuery();
                trans.Commit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                trans.Rollback();
            }

        }

        public long SaveCCNBrief()
        {
            long tmpRetID = 0;
            gSB.Clear();
            gSB.Append("INSERT INTO tblCCNBrief ( " +
                " DateOn, BillNo, MOP, CustID, Add1, Add2, City, Tp1, Tp2, Tp3, DescriptionOf, GrossTotal, " +
                " NetTotal, CNAmount, TotalPaid, ManAmount, NetAmount, Balance, UserID, UserName, " +
                " CompName, CompID, DelUserID, DelUserName, DelCompID, DelCompName, IsActive, " +
                " DisRate, DisAmount, VatRate, VatAmount, StockRoomID, SystemRefNo, DueDate, " +
                " CSHPaidOn, CHQPaidOn, CCSPAidOn, CREPaidOn, TranCode, NameOf ) " +
                " VALUES ( " +
                " @cDateOn, @cBillNo, @cMOP, @cCustID, @cAdd1, @cAdd2, @cCity, @cTp1, @cTp2, @cTp3, @cDescriptionOf, @cGrossTotal, " +
                " @cNetTotal, @cCNAmount, @cTotalPaid, @cManAmount, @cNetAmount, @cBalance, @cUserID, @cUserName, " +
                " @cCompName, @cCompID, @cDelUserID, @cDelUserName, @cDelCompID, @cDelCompName, @cIsActive, " +
                " @cDisRate, @cDisAmount, @cVatRate, @cVatAmount, @cStockRoomID, @cSystemRefNo, @cDueDate, " +
                " @cCSHPaidOn, @cCHQPaidOn, @cCCSPAidOn, @cCREPaidOn, @cTranCode, @cNameOf); SELECT SCOPE_IDENTITY(); ");

            MySqlCommand cmd = GlobalData.GCon.CreateCommand();
            MySqlTransaction trans = GlobalData.GCon.BeginTransaction();
            cmd.Connection = GlobalData.GCon;
            cmd.Transaction = trans;
            cmd.CommandText = gSB.ToString();

            try
            {
                cmd.Parameters.AddWithValue("@cDateOn", DateOn);
                cmd.Parameters.AddWithValue("@cBillNo", BillNo);
                cmd.Parameters.AddWithValue("@cMOP", MOP);
                cmd.Parameters.AddWithValue("@cCustID", CustID);
                cmd.Parameters.AddWithValue("@cAdd1", Add1);
                cmd.Parameters.AddWithValue("@cAdd2", Add2);
                cmd.Parameters.AddWithValue("@cCity", City);
                cmd.Parameters.AddWithValue("@cTp1", Tp1);
                cmd.Parameters.AddWithValue("@cTp2", Tp2);
                cmd.Parameters.AddWithValue("@cTp3", Tp3);
                cmd.Parameters.AddWithValue("@cDescriptionOf", DescriptionOf);
                cmd.Parameters.AddWithValue("@cGrossTotal", GrossTotal);
                cmd.Parameters.AddWithValue("@cNetTotal", NetTotal);
                cmd.Parameters.AddWithValue("@cCNAmount", CNAmount);
                cmd.Parameters.AddWithValue("@cTotalPaid", TotalPaid);
                cmd.Parameters.AddWithValue("@cManAmount", ManAmount);
                cmd.Parameters.AddWithValue("@cNetAmount", NetAmount);
                cmd.Parameters.AddWithValue("@cBalance", Balance);
                cmd.Parameters.AddWithValue("@cUserID", UserID);
                cmd.Parameters.AddWithValue("@cUserName", UserName);
                cmd.Parameters.AddWithValue("@cCompID", CompID);
                cmd.Parameters.AddWithValue("@cCompName", ComputerName);
                cmd.Parameters.AddWithValue("@cDelUserID", DelUserID);
                cmd.Parameters.AddWithValue("@cDelUserName", DelUserName);
                cmd.Parameters.AddWithValue("@cDelCompID", DelCompID);
                cmd.Parameters.AddWithValue("@cDelCompName", DelComputerName);
                cmd.Parameters.AddWithValue("@cIsActive", IsActive);
                cmd.Parameters.AddWithValue("@cDisRate", DisRate);
                cmd.Parameters.AddWithValue("@cDisAmount", DisAmount);
                cmd.Parameters.AddWithValue("@cVatRate", VatRate);
                cmd.Parameters.AddWithValue("@cVatAmount", VatAmount);
                cmd.Parameters.AddWithValue("@cStockRoomID", StockRoomID);
                cmd.Parameters.AddWithValue("@cSystemRefNo", SystemRefNo);
                cmd.Parameters.AddWithValue("@cDueDate", DueDate);
                cmd.Parameters.AddWithValue("@cCSHPaidOn", CSHPaidOn);
                cmd.Parameters.AddWithValue("@cCHQPaidOn", CHQPaidOn);
                cmd.Parameters.AddWithValue("@cCCSPaidOn", CCSPaidOn);
                cmd.Parameters.AddWithValue("@cCREPaidOn", CREPaidOn);
                cmd.Parameters.AddWithValue("@cTranCode", TranCode);
                cmd.Parameters.AddWithValue("@cNameOf", NameOf);

                tmpRetID = Convert.ToInt64(cmd.ExecuteScalar());
                trans.Commit();
                return tmpRetID;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                MessageBox.Show(ex.Message);
                return 0;
            }

        }

        public void SaveCCNDetail(long cBriefID, DataGridView cDateGridView)
        {
            gSB.Clear();
            gSB.Append("INSERT INTO tblCCNDetail ( " +
                " ItemId, SQty, FreeQty, UnitPrice, TotalAmount, Selling, Cost, " +
                " LineDis, LineDisAmount, LineVatRate, LineVatAmount, IsReturn, CostOfSale, BriefID) " +
                " VALUES ( " +
                " @cItemId, @cSQty, @cFreeQty, @cUnitPrice, @cTotalAmount, @cSelling, @cCost, " +
                " @cLineDis, @cLineDisAmount, @cLineVatRate, @cLineVatAmount, @cIsReturn, @cCostOfSale, @cBriefID) ");

            MySqlCommand cmd = GlobalData.GCon.CreateCommand();
            MySqlTransaction trans = GlobalData.GCon.BeginTransaction();
            cmd.Connection = GlobalData.GCon;
            cmd.Transaction = trans;
            cmd.CommandText = gSB.ToString();

            try
            {
                for (int i = 0; i < cDateGridView.Rows.Count; i++)
                {
                    cmd.Parameters.AddWithValue("@cItemID", Convert.ToInt32(cDateGridView.Rows[i].Cells[0].Value));
                    cmd.Parameters.AddWithValue("@cSQty", Convert.ToDouble(cDateGridView.Rows[i].Cells[5].Value));
                    cmd.Parameters.AddWithValue("@cFreeQty", Convert.ToDouble(cDateGridView.Rows[i].Cells[4].Value));
                    cmd.Parameters.AddWithValue("@cUnitPrice", Convert.ToDouble(cDateGridView.Rows[i].Cells[3].Value));
                    cmd.Parameters.AddWithValue("@cTotalAmount", Convert.ToDouble(cDateGridView.Rows[i].Cells[6].Value));
                    cmd.Parameters.AddWithValue("@cSelling", Convert.ToDouble(cDateGridView.Rows[i].Cells[3].Value));
                    cmd.Parameters.AddWithValue("@cCost", Convert.ToDouble(cDateGridView.Rows[i].Cells[7].Value));
                    cmd.Parameters.AddWithValue("@cLineDis", 0);
                    cmd.Parameters.AddWithValue("@cLineDisAmount", 0);
                    cmd.Parameters.AddWithValue("@cLineVatRate", 0);
                    cmd.Parameters.AddWithValue("@cLineVatAmount", 0);
                    cmd.Parameters.AddWithValue("@cIsReturn", "N");
                    cmd.Parameters.AddWithValue("@cCostOfSale", Convert.ToDouble(cDateGridView.Rows[i].Cells[5].Value) * Convert.ToDouble(cDateGridView.Rows[i].Cells[7].Value));
                    cmd.Parameters.AddWithValue("@cBriefID", cBriefID);

                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
                trans.Commit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                trans.Rollback();
            }
        }

        public void SaveBatchPrice(DataGridView cDateGridView)
        {
            gSB.Clear();
            gSB.Append("INSERT INTO tblSetBatchPrice ( " +
                " ItemID, Price) " +
                " VALUES ( " +
                " @ItemId, @Price) ");

            MySqlCommand cmd = GlobalData.GCon.CreateCommand();
            MySqlTransaction trans = GlobalData.GCon.BeginTransaction();
            cmd.Connection = GlobalData.GCon;
            cmd.Transaction = trans;
            cmd.CommandText = gSB.ToString();

            try
            {
                for (int i = 0; i < cDateGridView.Rows.Count; i++)
                {
                    cmd.Parameters.AddWithValue("@ItemID", ItemID);
                    cmd.Parameters.AddWithValue("@Price", Convert.ToDouble(cDateGridView.Rows[i].Cells[0].Value));
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
                trans.Commit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                trans.Rollback();
            }
        }

        public long SavePOBrief()
        {
            long tmpRetID = 0;
            gSB.Clear();
            gSB.Append("INSERT INTO tblPOBrief ( " +
                " DateOn, BillNo, MOP, CustID, Add1, Add2, City, Tp1, Tp2, Tp3, DescriptionOf, GrossTotal, " +
                " NetTotal, CNAmount, TotalPaid, ManAmount, NetAmount, Balance, UserID, UserName, " +
                " CompName, CompID, DelUserID, DelUserName, DelCompID, DelCompName, IsActive, " +
                " DisRate, DisAmount, VatRate, VatAmount, StockRoomID, SystemRefNo, DueDate, " +
                " CSHPaidOn, CHQPaidOn, CCSPAidOn, CREPaidOn, TranCode, NameOf, PurchaseOrderNo ) " +
                " VALUES ( " +
                " @cDateOn, @cBillNo, @cMOP, @cCustID, @cAdd1, @cAdd2, @cCity, @cTp1, @cTp2, @cTp3, @cDescriptionOf, @cGrossTotal, " +
                " @cNetTotal, @cCNAmount, @cTotalPaid, @cManAmount, @cNetAmount, @cBalance, @cUserID, @cUserName, " +
                " @cCompName, @cCompID, @cDelUserID, @cDelUserName, @cDelCompID, @cDelCompName, @cIsActive, " +
                " @cDisRate, @cDisAmount, @cVatRate, @cVatAmount, @cStockRoomID, @cSystemRefNo, @cDueDate, " +
                " @cCSHPaidOn, @cCHQPaidOn, @cCCSPAidOn, @cCREPaidOn, @cTranCode, @cNameOf, @cPurchaseOrderNo); SELECT SCOPE_IDENTITY(); ");

            MySqlCommand cmd = GlobalData.GCon.CreateCommand();
            MySqlTransaction trans = GlobalData.GCon.BeginTransaction();
            cmd.Connection = GlobalData.GCon;
            cmd.Transaction = trans;
            cmd.CommandText = gSB.ToString();

            try
            {
                cmd.Parameters.AddWithValue("@cDateOn", DateOn);
                cmd.Parameters.AddWithValue("@cBillNo", BillNo);
                cmd.Parameters.AddWithValue("@cMOP", MOP);
                cmd.Parameters.AddWithValue("@cCustID", CustID);
                cmd.Parameters.AddWithValue("@cAdd1", Add1);
                cmd.Parameters.AddWithValue("@cAdd2", Add2);
                cmd.Parameters.AddWithValue("@cCity", City);
                cmd.Parameters.AddWithValue("@cTp1", Tp1);
                cmd.Parameters.AddWithValue("@cTp2", Tp2);
                cmd.Parameters.AddWithValue("@cTp3", Tp3);
                cmd.Parameters.AddWithValue("@cDescriptionOf", DescriptionOf);
                cmd.Parameters.AddWithValue("@cGrossTotal", GrossTotal);
                cmd.Parameters.AddWithValue("@cNetTotal", NetTotal);
                cmd.Parameters.AddWithValue("@cCNAmount", CNAmount);
                cmd.Parameters.AddWithValue("@cTotalPaid", TotalPaid);
                cmd.Parameters.AddWithValue("@cManAmount", ManAmount);
                cmd.Parameters.AddWithValue("@cNetAmount", NetAmount);
                cmd.Parameters.AddWithValue("@cBalance", Balance);
                cmd.Parameters.AddWithValue("@cUserID", UserID);
                cmd.Parameters.AddWithValue("@cUserName", UserName);
                cmd.Parameters.AddWithValue("@cCompID", CompID);
                cmd.Parameters.AddWithValue("@cCompName", ComputerName);
                cmd.Parameters.AddWithValue("@cDelUserID", DelUserID);
                cmd.Parameters.AddWithValue("@cDelUserName", DelUserName);
                cmd.Parameters.AddWithValue("@cDelCompID", DelCompID);
                cmd.Parameters.AddWithValue("@cDelCompName", DelComputerName);
                cmd.Parameters.AddWithValue("@cIsActive", IsActive);
                cmd.Parameters.AddWithValue("@cDisRate", DisRate);
                cmd.Parameters.AddWithValue("@cDisAmount", DisAmount);
                cmd.Parameters.AddWithValue("@cVatRate", VatRate);
                cmd.Parameters.AddWithValue("@cVatAmount", VatAmount);
                cmd.Parameters.AddWithValue("@cStockRoomID", StockRoomID);
                cmd.Parameters.AddWithValue("@cSystemRefNo", SystemRefNo);
                cmd.Parameters.AddWithValue("@cDueDate", DueDate);
                cmd.Parameters.AddWithValue("@cCSHPaidOn", CSHPaidOn);
                cmd.Parameters.AddWithValue("@cCHQPaidOn", CHQPaidOn);
                cmd.Parameters.AddWithValue("@cCCSPaidOn", CCSPaidOn);
                cmd.Parameters.AddWithValue("@cCREPaidOn", CREPaidOn);
                cmd.Parameters.AddWithValue("@cTranCode", TranCode);
                cmd.Parameters.AddWithValue("@cNameOf", NameOf);
                cmd.Parameters.AddWithValue("@cPurchaseOrderNo", PurchaseOrderNo);

                tmpRetID = Convert.ToInt64(cmd.ExecuteScalar());
                trans.Commit();
                return tmpRetID;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                MessageBox.Show(ex.Message);
                return 0;
            }

        }

        public void SavePODetail(long cBriefID, DataGridView cDateGridView)
        {
            gSB.Clear();
            gSB.Append("INSERT INTO tblPODetail ( " +
                " ItemId, SQty, FreeQty, UnitPrice, TotalAmount, Selling, Cost, " +
                " LineDis, LineDisAmount, LineVatRate, LineVatAmount, IsReturn, CostOfSale, BriefID) " +
                " VALUES ( " +
                " @cItemId, @cSQty, @cFreeQty, @cUnitPrice, @cTotalAmount, @cSelling, @cCost, " +
                " @cLineDis, @cLineDisAmount, @cLineVatRate, @cLineVatAmount, @cIsReturn, @cCostOfSale, @cBriefID) ");

            MySqlCommand cmd = GlobalData.GCon.CreateCommand();
            MySqlTransaction trans = GlobalData.GCon.BeginTransaction();
            cmd.Connection = GlobalData.GCon;
            cmd.Transaction = trans;
            cmd.CommandText = gSB.ToString();

            try
            {
                for (int i = 0; i < cDateGridView.Rows.Count; i++)
                {
                    cmd.Parameters.AddWithValue("@cItemID", Convert.ToInt32(cDateGridView.Rows[i].Cells[0].Value));
                    cmd.Parameters.AddWithValue("@cSQty", Convert.ToDouble(cDateGridView.Rows[i].Cells[5].Value));
                    cmd.Parameters.AddWithValue("@cFreeQty", Convert.ToDouble(cDateGridView.Rows[i].Cells[4].Value));
                    cmd.Parameters.AddWithValue("@cUnitPrice", Convert.ToDouble(cDateGridView.Rows[i].Cells[3].Value));
                    cmd.Parameters.AddWithValue("@cTotalAmount", Convert.ToDouble(cDateGridView.Rows[i].Cells[6].Value));
                    cmd.Parameters.AddWithValue("@cSelling", Convert.ToDouble(cDateGridView.Rows[i].Cells[3].Value));
                    cmd.Parameters.AddWithValue("@cCost", Convert.ToDouble(cDateGridView.Rows[i].Cells[7].Value));
                    cmd.Parameters.AddWithValue("@cLineDis", 0);
                    cmd.Parameters.AddWithValue("@cLineDisAmount", 0);
                    cmd.Parameters.AddWithValue("@cLineVatRate", 0);
                    cmd.Parameters.AddWithValue("@cLineVatAmount", 0);
                    cmd.Parameters.AddWithValue("@cIsReturn", "N");
                    cmd.Parameters.AddWithValue("@cCostOfSale", Convert.ToDouble(cDateGridView.Rows[i].Cells[5].Value) * Convert.ToDouble(cDateGridView.Rows[i].Cells[7].Value));
                    cmd.Parameters.AddWithValue("@cBriefID", cBriefID);

                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
                trans.Commit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                trans.Rollback();
            }
        }
    }
}
