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
    public partial class frmIPCHQReturn : Form
    {
        private int gBankID = 0;
        private DateTime gReturnOn = new DateTime();
        private double gAddionalCharge = 0;
        private long gBriefID = 0;

        GlobalData GlbData = new GlobalData();
        DataSet dSet = new DataSet();
        StringBuilder gSB = new StringBuilder();
        MasterFiles masterFiles = new MasterFiles();
        Transactions tran = new Transactions();
        frmConfirmMessage fConfirm = new frmConfirmMessage();
        DataTable dataTable = new DataTable();
        MySqlDataAdapter sqlAdapter = new MySqlDataAdapter();

        public frmIPCHQReturn()
        {
            InitializeComponent();
        }

        public void SettingGrid()
        {
            lstGrid.CheckBoxes = true;
            lstGrid.Columns.Add("BILL NO", 100, HorizontalAlignment.Left);
            lstGrid.Columns.Add("CHEQUE DATE", 100, HorizontalAlignment.Left);
            lstGrid.Columns.Add("CHEQUE NO", 100, HorizontalAlignment.Left);
            lstGrid.Columns.Add("NET TOTAL", 80, HorizontalAlignment.Right);
            lstGrid.Columns.Add("PERFORMED DATE", 150, HorizontalAlignment.Left);
            lstGrid.Columns.Add("PERFORMED USER", 190, HorizontalAlignment.Left);
            lstGrid.Columns.Add("MOP ID", 0, HorizontalAlignment.Left);
            lstGrid.Columns.Add("BANK ID", 0, HorizontalAlignment.Left);
            lstGrid.Columns.Add("BANK", 100, HorizontalAlignment.Left);
            lstGrid.Columns.Add("OWNER ID", 0, HorizontalAlignment.Left);
            lstGrid.Columns.Add("OWNER NAME", 0, HorizontalAlignment.Left);
        }

        private void DispalyAllCHQ()
        {
            gSB.Clear();
            gSB.Append(" SELECT * FROM tblMOP AS MO INNER JOIN tblBank AS BK ON MO.BankID = BK.CustID" +
                                   " WHERE  (MO.IsDeposited = 'Y') AND (MO.IsRealized = 'N') AND (MO.IsReturned = 'N') AND (MO.MopType = 'CHQ') AND (MO.BankID = " + gBankID + ") ");
            dataTable = GlbData.getDataTable(gSB.ToString());
            lstGrid.Items.Clear();

            foreach (DataRow dRow in dataTable.Rows)
            {
                ListViewItem LItem = new ListViewItem();
                LItem.Text = dRow["RefNo"].ToString();
                LItem.SubItems.Add(Convert.ToDateTime(dRow["CHQDate"]).ToShortDateString());
                LItem.SubItems.Add(dRow["CHQNo"].ToString());
                LItem.SubItems.Add(string.Format("{0:N}", Convert.ToDouble(dRow["NetAmount"])));
                LItem.SubItems.Add(dRow["PerformedOn"].ToString());
                LItem.SubItems.Add(dRow["Username"].ToString());
                LItem.SubItems.Add(dRow["MopID"].ToString());
                LItem.SubItems.Add(dRow["BankID"].ToString());
                LItem.SubItems.Add(dRow["NameOF"].ToString());
                LItem.SubItems.Add(dRow["OwnerID"].ToString());
                LItem.SubItems.Add(dRow["OwnerName"].ToString());
                lstGrid.Items.Add(LItem);
            }

            dataTable.Clear();
            dataTable = null;
            TotalVal();
        }

        private void TotalVal()
        {
            double tmpSum = 0;
            double tmpTotal = 0;
            int counter = 0;

            for (int j = 0; j < lstGrid.Items.Count; j++)
            {
                double tmpVal = Convert.ToDouble(lstGrid.Items[j].SubItems[3].Text);
                tmpTotal += tmpVal;

                if (lstGrid.Items[j].Checked == true)
                {
                    counter += 1;
                    double tmpVal2 = Convert.ToDouble(lstGrid.Items[j].SubItems[3].Text);
                    tmpSum += tmpVal2;
                }
            }

            lblSelectedChq.Text = counter.ToString();
            lblSelectedChqVal.Text = string.Format("{0:N}", tmpSum);
            lblTotalChqVal.Text = string.Format("{0:N}", tmpTotal);
            lblTotChq.Text = lstGrid.Items.Count.ToString();
        }

        private void FillBank()
        {
            cmbBank.DataSource = GlbData.getDataSet("SELECT CustID, NameOF FROM tblBank ", "tblBank").Tables[0];
            cmbBank.ValueMember = "CustID";
            cmbBank.DisplayMember = "NameOF";
        }

        private void frmIPCHQReturn_Load(object sender, EventArgs e)
        {
            SettingGrid();
            FillBank();
            DispalyAllCHQ();
        }

        private void cmbBank_Validating(object sender, CancelEventArgs e)
        {
            if (cmbBank.Text == "")
                return;
            else
                gBankID = Convert.ToInt32(cmbBank.SelectedValue);

            DispalyAllCHQ();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstGrid.Items.Count; i++)
            {
                lstGrid.Items[i].Checked = true;
                lstGrid.Items[i].Selected = true;
                lstGrid.Items[i].BackColor = Color.BlanchedAlmond;
            }
            TotalVal();
        }

        private void btnDeselect_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstGrid.Items.Count; i++)
            {
                lstGrid.Items[i].Checked = false;
                lstGrid.Items[i].Selected = false;
                lstGrid.Items[i].BackColor = Color.White;
            }
            TotalVal();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                for (int i = 0; i < lstGrid.Items.Count; i++)
                {
                    if (lstGrid.Items[i].SubItems[0].Text == txtSearch.Text)
                    {
                        lstGrid.Items[i].Checked = true;
                        lstGrid.Items[i].BackColor = Color.BlanchedAlmond;
                        txtSearch.Clear();
                        break;
                    }
                }

                TotalVal();
            }
        }

        private void lstGrid_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            for (int i = 0; i < lstGrid.Items.Count; i++)
            {
                if (lstGrid.Items[i].Checked == true)
                    lstGrid.Items[i].BackColor = Color.BlanchedAlmond;
                else
                    lstGrid.Items[i].BackColor = Color.White;
            }

            TotalVal();
        }

        private long RoadToSave()
        {
            long tmpID = 0;
            string tmpBillNo = GlbData.getUniqueNumber("CHQRET", GlobalData.GCompID).ToString();

            tran.RefNo = tmpBillNo;
            tran.TotalChq = Convert.ToInt32(lblSelectedChq.Text);
            tran.ChqValue = Convert.ToDouble(lblSelectedChqVal.Text);
            tran.Notes = "";
            tran.ReturnedOn = gReturnOn;
            tran.BankID = 0;
            tran.UserID = GlobalData.GUserID;
            tran.UserName = GlobalData.GUsername;
            tran.CompID = GlobalData.GCompID;
            tran.ComputerName = GlobalData.GCompName;

            tmpID = tran.SaveCHQReturnBrief();
            tran.SaveCHQReturnDetail(tmpID, lstGrid);
            UpdateMOP();
            SavePayment();
            
            return tmpID;
        }

        private void UpdateMOP()
        {
            for (int i = 0; i < lstGrid.Items.Count; i++)
            {
                if (lstGrid.Items[i].Checked == true)
                {
                    MySqlCommand command = new MySqlCommand("UPDATE tblMOP SET IsReturned = 'Y' , ReturnedOn = '" + gReturnOn + "' " +
                    " WHERE MOPID = " + Convert.ToInt32(lstGrid.Items[i].SubItems[6].Text) + " ", GlobalData.GCon);
                    command.ExecuteNonQuery();
                }
            }
        }

        public bool IsRequired()
        {
            if (lstGrid.Items.Count == 0)
            {
                MessageBox.Show("Empty Grid", "Empty Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lstGrid.Focus();
                return false;
            }
            if (lstGrid.CheckedItems.Count == 0)
            {
                MessageBox.Show("Please check atleast one cheque", "Empty Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lstGrid.Focus();
                return false;
            }

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsRequired())
            {
                if (fConfirm.SayMessage("SV") == true)
                {
                    gReturnOn = Convert.ToDateTime(dtpDate.Text);
                    long tmpKeyHolder = 0;
                    tmpKeyHolder = RoadToSave();

                    if (tmpKeyHolder == 0)
                    {
                        GlbData.SayMessage("Save Failed!!!", 0, "");
                    }
                    else
                    {
                        GlbData.SayMessage("Save Success!!!", 1, "");
                        this.Close();
                    }
                }
            }
        }

        private long SavePayment()
        {
            for (int i = 0; i < lstGrid.Items.Count; i++)
            {
                if(lstGrid.Items[i].Checked == true)
                {
                    string tmpBillNo = GlbData.getUniqueNumber("SALE", GlobalData.GCompID).ToString();

                    tran.DateOn = gReturnOn;
                    tran.BillNo = tmpBillNo;
                    tran.MOP = "CRE";
                    tran.CustID = Convert.ToInt32(lstGrid.Items[i].SubItems[9].Text);
                    tran.Add1 = "";
                    tran.Add2 = "";
                    tran.City = "";
                    tran.Tp1 = "";
                    tran.Tp2 = "";
                    tran.Tp3 = "";
                    tran.DescriptionOf = "CHQ Return [" + lstGrid.Items[i].SubItems[2].Text + "]";
                    tran.GrossTotal = Convert.ToDouble(lstGrid.Items[i].SubItems[3].Text);
                    tran.CNAmount = 0;
                    tran.NetTotal = Convert.ToDouble(lstGrid.Items[i].SubItems[3].Text);
                    tran.TotalPaid = 0;
                    tran.NetAmount = Convert.ToDouble(lstGrid.Items[i].SubItems[3].Text);
                    tran.ManAmount = Convert.ToDouble(lstGrid.Items[i].SubItems[3].Text);
                    tran.Balance = 0;
                    tran.DisRate = 0;
                    tran.DisAmount = Convert.ToDouble(0);
                    tran.VatRate = 0;
                    tran.VatAmount = 0;
                    tran.StockRoomID = 0;
                    tran.SystemRefNo = "";
                    tran.DueDate = gReturnOn;
                    tran.UserID = GlobalData.GUserID;
                    tran.UserName = GlobalData.GUsername;
                    tran.CompID = GlobalData.GCompID;
                    tran.ComputerName = GlobalData.GCompName;
                    tran.DelUserID = 0;
                    tran.DelUserName = "";
                    tran.DelCompID = 0;
                    tran.DelComputerName = "";
                    tran.IsActive = "N";
                    tran.TranCode = "CUS002";
                    tran.NameOf = lstGrid.Items[i].SubItems[10].Text;

                    gBriefID = tran.SaveSALEBrief();
                }
            }
            return gBriefID;
        }
    }
}
