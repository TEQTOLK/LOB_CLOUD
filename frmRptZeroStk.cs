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
    public partial class frmRptZeroStk : Form
    {
        private int gItemID = 0;
        StringBuilder gSB = new StringBuilder();
        GlobalData GlbData = new GlobalData();
        PrintReport print = new PrintReport();
        private int gCatID = 0;
        private int gSupplierID = 0;
        private int gStockroomID = 0;

        public frmRptZeroStk()
        {
            InitializeComponent();
        }

        private void frmRptSales_Load(object sender, EventArgs e)
        {
            GlbData.FillComboBoxALL(cboStockroom, "tblStockRoom", " ORDER BY NameOf");
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            btnShow.Enabled = false;
            string tmpQuery = "";

            tmpQuery = getQuery() + getStockroomID(); ;
            print.RoadToPrintReport(tmpQuery, @"C:\LOB\Bin\Debug\Rep\ZeroSTK.rpt", rptView);

            btnShow.Enabled = true;
        }

        private string getStockroomID()
        {
            if (cboStockroom.Text.Trim() == "")
                return " ";

            if (cboStockroom.SelectedIndex == 0)
                return " ";
            else
                return "  AND ST.CustID = " + gStockroomID + " ";

        }

        private string getQuery()
        {
            return " SELECT IT.Code AS CUCode, IT.NameOF AS CUName, MC.NameOF AS CUAdd1,  " +
                " SU.NameOF AS CUAdd2, ISNULL(STK.Qty,0) AS UnitPrice, ST.CustID AS Discount, ST.NameOF AS Name, " +
                " IT.WholeSalePrice AS TotalAmount, MC.CustID AS Qty, SU.CustID AS BRPaidAmount " +
                " FROM tblItem AS IT LEFT OUTER JOIN " +
                " tblComSTKStore AS STK ON IT.CustID = STK.ItemID INNER JOIN " +
                " tblStockRoom AS ST ON ST.CustID = STK.StockRoomID INNER JOIN " +
                " tblSupplier AS SU ON IT.SupplierID = SU.CustID LEFT OUTER JOIN " +
                " tblMajorCategory AS MC ON IT.CategoryID = MC.CustID " +
                " WHERE ISNULL(STK.Qty,0) = 0 ";
        }
        
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

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
    }
}
