using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LOB
{
    public partial class frmIPDashboard : Form
    {
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

        public frmIPDashboard()
        {
            InitializeComponent();
        }
        

        private void frmIPDashboard_Load(object sender, EventArgs e)
        {
            DispalySales();
            FillTranInfo();
        }

        private void InsertRecords()
        {
            MySqlCommand cmd3 = new MySqlCommand("TRUNCATE TABLE tblTEMPChart", GlobalData.GCon);
            cmd3.ExecuteNonQuery();

            string firstMonth = "01-JAN-" + DateTime.Now.Year;
            string lastMonth = "31-DEC-" + DateTime.Now.Year;

            gSB.Clear();
            gSB.Append("INSERT INTO tblTEMPChart ( " +
                " MonthOf, Sales, CCN, MonthIndex ) " +
                " (SELECT CONVERT(char(3), DateOn,0) AS SalMonth, SUM(ManAmount) AS Sales , 0 AS CCN, MONTH(DateOn) AS MonthIndex " +
                " FROM tblSaleBrief " +
                " WHERE DateOn BETWEEN CONVERT(date, '" + firstMonth + "') AND CONVERT(date, '" + lastMonth + "') AND  " +
                " CompId = " + GlobalData.GCompID + " AND IsActive = 'Y'  " + 
                " GROUP BY CONVERT(char(3), DateOn, 0), MONTH(DateOn) " +
                "  ) ");
            MySqlCommand cmd = new MySqlCommand(gSB.ToString(), GlobalData.GCon);
            cmd.ExecuteNonQuery();

            gSB.Clear();
            gSB.Append("UPDATE t1 SET t1.CCN = CN.CCN " +
                 " FROM tblTEMPChart as t1 INNER JOIN " +
                 " (SELECT  SUM(ManAmount) AS CCN, MONTH(DateOn) AS MonthIndex " +
                 " FROM tblCCNBrief " +
                 " WHERE DateOn BETWEEN CONVERT(date, '" + firstMonth + "') AND CONVERT(date, '" + lastMonth + "') AND  " +
                 " CompId = " + GlobalData.GCompID + " AND IsActive = 'Y'  " +
                 " GROUP BY  MONTH(DateOn)) AS CN ON CN.MonthIndex = t1.MonthIndex" );
            MySqlCommand cmd2 = new MySqlCommand(gSB.ToString(), GlobalData.GCon);
            cmd2.ExecuteNonQuery();
        }

        private void DispalySales()
        {
            InsertRecords();

            gSB.Clear();
            gSB.Append("SELECT MonthOf, Sales, CCN, MonthIndex FROM tblTempChart ORDER BY MonthIndex");
            dataTable = GlbData.getDataTable(gSB.ToString());

            chart1.DataSource = dataTable;
            chart1.Series["Sales"].XValueMember = "MonthOf";
            chart1.Series["Sales"].YValueMembers = "Sales";
            chart1.Series["Returns"].YValueMembers = "CCN";
            chart1.Titles.Add("Sales Comparison");
        }

        private void FillTranInfo()
        {
            gSB.Clear();
            gSB.Append("SELECT ISNULL(SUM(ManAmount),0) AS Sale FROM tblSaleBrief WHERE DateOn = CONVERT(date, '" + DateTime.Now + "') AND CompId = " + GlobalData.GCompID + " AND IsActive = 'Y' ");
            lblSale.Text = string.Format("{0:N}", Convert.ToDouble(GlbData.GetValue(gSB.ToString(), "Sale")));

            gSB.Clear();
            gSB.Append("SELECT ISNULL(SUM(ManAmount),0) AS CCN FROM tblCCNBrief WHERE DateOn = CONVERT(date, '" + DateTime.Now + "') AND CompId = " + GlobalData.GCompID + " ");
            lblReturns.Text = string.Format("{0:N}", Convert.ToDouble(GlbData.GetValue(gSB.ToString(), "CCN")));

            lblNetSale.Text = string.Format("{0:N}", Convert.ToDouble(lblSale.Text) - Convert.ToDouble(lblReturns.Text));

            gSB.Clear();
            gSB.Append("SELECT  ISNULL(SUM(MO.CashTendered),0) AS Collection " +
                " FROM tblCustPayBrief AS BR INNER JOIN " +
                " tblMOP AS MO ON BR.MOPID = MO.MOPID INNER JOIN " +
                " tblCompany AS CO ON CO.CustID = BR.CompID " +
                " WHERE BR.DateOn = CONVERT(date, '" + DateTime.Now + "') AND BR.CompId = " + GlobalData.GCompID + " AND BR.TranCode = 'CUS004' ");
            lblCollections.Text = string.Format("{0:N}", Convert.ToDouble(GlbData.GetValue(gSB.ToString(), "Collection")));

            gSB.Clear();
            gSB.Append("SELECT ISNULL(COUNT(BillID),0) AS Bills FROM tblSaleBrief WHERE DateOn = CONVERT(date, '" + DateTime.Now + "') AND CompId = " + GlobalData.GCompID + " AND IsActive = 'Y' ");
            lblBills.Text = GlbData.GetValue(gSB.ToString(), "Bills").ToString();
        }
    }
}
