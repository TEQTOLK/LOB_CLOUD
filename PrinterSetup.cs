using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LOB
{
    public class PrinterSetup
    {
        StringBuilder gSB = new StringBuilder();
        DataTable dataTable = new DataTable();
        GlobalData GlbData = new GlobalData();

        public string CompanyName { get; set; }
        public string Add1 { get; set; }
        public string Add2 { get; set; }
        public string City { get; set; }
        public string Tp1 { get; set; }
        public string Tp2 { get; set; }
        public string Tp3 { get; set; }

        public string BillNo { get; set; }
        public double GrossTotal { get; set; }
        public double NetTotal { get; set; }
        public double Discount { get; set; }
        public double PaidAmount { get; set; }
        public double Balance { get; set; }
        public string MOPType { get; set; }
        public DataGridView DataGridView { get; set; }
        public RichTextBox RichTextBox { get; set; }

        private void getCompanyInfo()
        {
            gSB.Clear();
            gSB.Append("SELECT * FROM tblCompany WHERE CustID = " + GlobalData.GCompID + " ");
            dataTable = GlbData.getDataTable(gSB.ToString());

            foreach (DataRow dRow in dataTable.Rows)
            {
                CompanyName = dRow["NameOF"].ToString();
                Add1 = dRow["Add1"].ToString();
                Add2 = dRow["Add2"].ToString();
                City = dRow["City"].ToString();
                Tp1 = dRow["Tp1"].ToString();
                Tp2 = dRow["Tp2"].ToString();
                Tp3 = dRow["Tp3"].ToString();
            }
            dataTable = null;
        }

        public PrinterSetup()
        {
            getCompanyInfo();
        }

        public void printReceipt()
        {
            try
            {
                PrintDocument pd = new PrintDocument();
                pd.PrintController = new StandardPrintController();
                pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPage);
                pd.Print();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        void pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            Font font1 = new Font("Calibri", 16, FontStyle.Bold);
            Font font2 = new Font("Calibri", 8, FontStyle.Bold | FontStyle.Regular);
            Font font3 = new Font("CalibriI", 13, FontStyle.Bold);
            Font font4 = new Font("Calibri", 8, FontStyle.Bold | FontStyle.Regular);
            Font font5 = new Font("Calibri", 9, FontStyle.Bold | FontStyle.Regular);
            Font font6 = new Font("Calibri", 9, FontStyle.Regular | FontStyle.Regular);

            float fontHeight = font1.GetHeight();

            int startX = 2;
            int starX = 10;
            int add = 10;
            int tp = 10;
            int rec = 84;
            int startY = 45;
            int offset = 40;

            int billY = 175;

            //Image img = Image.FromFile(Application.StartupPath + "\\logo.jpg");
            //g.DrawImage(img, 40, 0, img.Width, img.Height);
            g.DrawString(CompanyName, font1, new SolidBrush(Color.Black), starX, startY);

            g.DrawString(Add1 + ", " + City, font6, new SolidBrush(Color.Black), add, startY + 30);
            g.DrawString("TP: " + Tp1 + ", " + Tp2 , font6, new SolidBrush(Color.Black), 10, startY + 45);

            g.DrawString("SALES RECIEPT\n", font5, new SolidBrush(Color.Black), rec, startY + 65);
            g.DrawString("CASHIER  ", font2, new SolidBrush(Color.Black), startX, startY + 115);
            g.DrawString("BILL NO   ", font2, new SolidBrush(Color.Black), startX, startY + 101);
            g.DrawString("BILL DATE     ", font2, new SolidBrush(Color.Black), startX, startY + 87);

            g.DrawString(GlobalData.GUsername.ToUpper(), font2, new SolidBrush(Color.Black), startX + 60, startY + 115);
            g.DrawString(BillNo, font2, new SolidBrush(Color.Black), startX + 60, startY + 101);
            g.DrawString(System.DateTime.Now.ToString("dd-MMM-yyyy h:mm tt"), font2, new SolidBrush(Color.Black), startX + 60, startY + 87);

            g.DrawString("CODE                                        QTY        RATE             TOTAL", font2, new SolidBrush(Color.Black), startX, startY + 137);
            g.DrawLine(new Pen(Color.Black, 1), 3, 204, 260, 204);
            
            for (int i = 0; i < DataGridView.Rows.Count; i++)
            {
                string p_name = DataGridView.Rows[i].Cells[2].Value.ToString().Trim();
                string code = DataGridView.Rows[i].Cells[1].Value.ToString().Trim();
                string price = DataGridView.Rows[i].Cells[5].Value.ToString().Trim();
                string qty = DataGridView.Rows[i].Cells[3].Value.ToString().Trim();
                string total = double.Parse(DataGridView.Rows[i].Cells[7].Value.ToString()).ToString("0,0.00");

                g.DrawString(p_name, font2, new SolidBrush(Color.Black), startX, billY + offset);
                g.DrawString(code, font2, new SolidBrush(Color.Black), startX + 8, billY + 13 + offset);
                g.DrawString(qty.PadRight(0), font2, new SolidBrush(Color.Black), startX + 130, billY + 13 + offset);
                g.DrawString(price, font2, new SolidBrush(Color.Black), startX + 160, billY + 13 + offset);
                g.DrawString(total.PadLeft(12), font2, new SolidBrush(Color.Black), startX + 210, billY + 13 + offset);
                offset = offset + (int)fontHeight + 2;

            }

            offset = offset + 8;

            g.DrawString("SUB TOTAL", font2, new SolidBrush(Color.Black), 110, billY + offset + 9);
            string st = GrossTotal.ToString("0,0.00");
            g.DrawString(st.PadLeft(24), font2, new SolidBrush(Color.Black), 180, billY + offset + 9);

            g.DrawString("DISCOUNT", font2, new SolidBrush(Color.Black), 110, billY + offset + 25);
            string d = Discount.ToString("0,0.00");
            g.DrawString(d.PadLeft(25), font2, new SolidBrush(Color.Black), 180, billY + offset + 25);
            
            g.DrawString("NET TOTAL", font2, new SolidBrush(Color.Black), 110, billY + offset + 41);
            g.DrawString(NetTotal.ToString("0,0.00").PadLeft(24), font2, new SolidBrush(Color.Black), 180, billY + offset + 41);
            
            string cash = PaidAmount.ToString("0,0.00");
            if (!cash.Contains("."))
            {
                cash += ".00";
            }
            g.DrawString("CASH AMOUNT", font2, new SolidBrush(Color.Black), 110, billY + offset + 57);
            g.DrawString(cash.PadLeft(24), font2, new SolidBrush(Color.Black), 180, billY + offset + 57);

            string bal = Balance.ToString("0,0.00");
            if (bal.Contains("-"))
            {
                bal = "0.00";
            }
            g.DrawString("BALANCE", font2, new SolidBrush(Color.Black), 110, billY + offset + 73);
            g.DrawString(bal.PadLeft(24), font2, new SolidBrush(Color.Black), 180, billY + offset + 73);

            g.DrawString("[ " + MOPType + " ]", font4, new SolidBrush(Color.Black), 5, billY + offset + 80);

            g.DrawString("Thank You Shopping With Us", font4, new SolidBrush(Color.Black), 65, billY + offset + 100);
            g.DrawString("Exchange Possible Within 3 Days", font4, new SolidBrush(Color.Black), 55, billY + offset + 114);

            //g.DrawLine(new Pen(Color.Black, 1), 3, billY + offset + 128, startX, billY + offset + 128);g.DrawString("--------------------------------------------------------------------------", font2, new SolidBrush(Color.Black), startX, billY + offset + 128);
            g.DrawString("___________________________________________________", font2, new SolidBrush(Color.Black), startX, billY + offset + 123);
            //g.DrawString("--------------------------------------------------------------------------", font2, new SolidBrush(Color.Black), startX, billY + offset + 128);
            g.DrawString("© TeQto (Pvt) Ltd.", font4, new SolidBrush(Color.Black), 80, billY + offset + 138);
            g.DrawString("(071-6256756 / 071-9564218)", font4, new SolidBrush(Color.Black), 60, billY + offset + 152);
         
        }

        public void printReceiptText()
        {
            Graphics g = RichTextBox.CreateGraphics();
            g.Clear(Color.White);

            Font font1 = new Font("Calibri", 16, FontStyle.Bold);
            Font font2 = new Font("Calibri", 8, FontStyle.Bold | FontStyle.Regular);
            Font font3 = new Font("CalibriI", 13, FontStyle.Bold);
            Font font4 = new Font("Calibri", 8, FontStyle.Bold | FontStyle.Regular);
            Font font5 = new Font("Calibri", 9, FontStyle.Bold | FontStyle.Regular);
            Font font6 = new Font("Calibri", 9, FontStyle.Regular | FontStyle.Regular);

            float fontHeight = font1.GetHeight();

            int startX = 2;
            int starX = 10;
            int add = 10;
            int tp = 10;
            int rec = 84;
            int startY = 45;
            int offset = 40;

            int billY = 175;

            //Image img = Image.FromFile(Application.StartupPath + "\\logo.jpg");
            //g.DrawImage(img, 40, 0, img.Width, img.Height);
            g.DrawString(CompanyName, font1, new SolidBrush(Color.Black), starX, startY);

            g.DrawString(Add1 + ", " + City, font6, new SolidBrush(Color.Black), add, startY + 30);
            g.DrawString("TP: " + Tp1 + ", " + Tp2, font6, new SolidBrush(Color.Black), 10, startY + 45);

            g.DrawString("SALES RECIEPT\n", font5, new SolidBrush(Color.Black), rec, startY + 65);
            g.DrawString("CASHIER  ", font2, new SolidBrush(Color.Black), startX, startY + 115);
            g.DrawString("BILL NO   ", font2, new SolidBrush(Color.Black), startX, startY + 101);
            g.DrawString("BILL DATE     ", font2, new SolidBrush(Color.Black), startX, startY + 87);

            g.DrawString(GlobalData.GUsername.ToUpper(), font2, new SolidBrush(Color.Black), startX + 60, startY + 115);
            g.DrawString(BillNo, font2, new SolidBrush(Color.Black), startX + 60, startY + 101);
            g.DrawString(System.DateTime.Now.ToString("dd-MMM-yyyy h:mm tt"), font2, new SolidBrush(Color.Black), startX + 60, startY + 87);

            g.DrawString("CODE                                        QTY        RATE             TOTAL", font2, new SolidBrush(Color.Black), startX, startY + 137);
            g.DrawLine(new Pen(Color.Black, 1), 3, 204, 260, 204);

            for (int i = 0; i < DataGridView.Rows.Count; i++)
            {
                string p_name = DataGridView.Rows[i].Cells[2].Value.ToString().Trim();
                string code = DataGridView.Rows[i].Cells[1].Value.ToString().Trim();
                string price = DataGridView.Rows[i].Cells[4].Value.ToString().Trim();
                string qty = DataGridView.Rows[i].Cells[3].Value.ToString().Trim();
                string total = double.Parse(DataGridView.Rows[i].Cells[5].Value.ToString()).ToString("0,0.00");

                g.DrawString(p_name, font2, new SolidBrush(Color.Black), startX, billY + offset);
                g.DrawString(code, font2, new SolidBrush(Color.Black), startX + 8, billY + 13 + offset);
                g.DrawString(qty.PadRight(0), font2, new SolidBrush(Color.Black), startX + 130, billY + 13 + offset);
                g.DrawString(price, font2, new SolidBrush(Color.Black), startX + 160, billY + 13 + offset);
                g.DrawString(total.PadLeft(12), font2, new SolidBrush(Color.Black), startX + 210, billY + 13 + offset);
                offset = offset + (int)fontHeight + 2;

            }

            offset = offset + 8;

            g.DrawString("SUB TOTAL", font2, new SolidBrush(Color.Black), 110, billY + offset + 9);
            string st = GrossTotal.ToString("0,0.00");
            g.DrawString(st.PadLeft(24), font2, new SolidBrush(Color.Black), 180, billY + offset + 9);

            g.DrawString("DISCOUNT", font2, new SolidBrush(Color.Black), 110, billY + offset + 25);
            string d = Discount.ToString("0,0.00");
            g.DrawString(d.PadLeft(25), font2, new SolidBrush(Color.Black), 180, billY + offset + 25);

            g.DrawString("NET TOTAL", font2, new SolidBrush(Color.Black), 110, billY + offset + 41);
            g.DrawString(NetTotal.ToString("0,0.00").PadLeft(24), font2, new SolidBrush(Color.Black), 180, billY + offset + 41);

            string cash = PaidAmount.ToString("0,0.00");
            if (!cash.Contains("."))
            {
                cash += ".00";
            }
            g.DrawString("CASH AMOUNT", font2, new SolidBrush(Color.Black), 110, billY + offset + 57);
            g.DrawString(cash.PadLeft(24), font2, new SolidBrush(Color.Black), 180, billY + offset + 57);

            string bal = Balance.ToString("0,0.00");
            if (bal.Contains("-"))
            {
                bal = "0.00";
            }
            g.DrawString("BALANCE", font2, new SolidBrush(Color.Black), 110, billY + offset + 73);
            g.DrawString(bal.PadLeft(25), font2, new SolidBrush(Color.Black), 180, billY + offset + 73);

            g.DrawString("[ " + MOPType + " ]", font4, new SolidBrush(Color.Black), 5, billY + offset + 80);

            g.DrawString("Thank You Shopping With Us", font4, new SolidBrush(Color.Black), 65, billY + offset + 100);
            g.DrawString("Exchange Possible Within 3 Days", font4, new SolidBrush(Color.Black), 55, billY + offset + 114);

            //g.DrawLine(new Pen(Color.Black, 1), 3, billY + offset + 128, startX, billY + offset + 128);g.DrawString("--------------------------------------------------------------------------", font2, new SolidBrush(Color.Black), startX, billY + offset + 128);
            g.DrawString("___________________________________________________", font2, new SolidBrush(Color.Black), startX, billY + offset + 123);
            //g.DrawString("--------------------------------------------------------------------------", font2, new SolidBrush(Color.Black), startX, billY + offset + 128);
            g.DrawString("© TeQto (Pvt) Ltd.", font4, new SolidBrush(Color.Black), 80, billY + offset + 138);
            g.DrawString("(071-6256756 / 071-9564218)", font4, new SolidBrush(Color.Black), 60, billY + offset + 152);

        }
    }
}
