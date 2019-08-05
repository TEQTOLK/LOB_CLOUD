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
    public partial class frmIPCHQDeposit : Form
    {
        private string gNotes = "";
        private DateTime gDepositedOn = new DateTime();
        private string gDepositedBy = "";
        private int gBankID = 0;

        GlobalData GlbData = new GlobalData();
        DataSet dSet = new DataSet();
        StringBuilder gSB = new StringBuilder();
        MasterFiles masterFiles = new MasterFiles();
        Transactions tran = new Transactions();
        frmConfirmMessage fConfirm = new frmConfirmMessage();
        DataTable dataTable = new DataTable();
        MySqlDataAdapter sqlAdapter = new MySqlDataAdapter();

        public frmIPCHQDeposit()
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

        private void DispalyAllCHQ(string cDateRange)
        {
            gSB.Clear();
            gSB.Append(" SELECT * FROM tblMOP AS MO INNER JOIN tblBank AS BK ON MO.BankID = BK.CustID" +
                                   " WHERE  (MO.IsDeposited = 'N') AND (MO.IsRealized = 'N') AND (MO.MopType = 'CHQ') " + cDateRange);
            dataTable = GlbData.getDataTable(gSB.ToString());
            lstGrid.Items.Clear();

            foreach (DataRow dRow in dataTable.Rows)
            {
                ListViewItem LItem = new ListViewItem();
                LItem.Text = dRow["RefNo"].ToString();
                LItem.SubItems.Add(Convert.ToDateTime(dRow["CHQDate"]).ToShortDateString());
                LItem.SubItems.Add(dRow["CHQNo"].ToString());
                LItem.SubItems.Add(string.Format("{0:N}",Convert.ToDouble(dRow["NetAmount"])));
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

        private void frmIPCHQDeposit_Load(object sender, EventArgs e)
        {
            SettingGrid();
            DispalyAllCHQ("");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEarlierCHQ_Click(object sender, EventArgs e)
        {
            DispalyAllCHQ(" AND MO.CHQDate < CONVERT(DATE, NOW())");
        }

        private void btnTodayCHQ_Click(object sender, EventArgs e)
        {
            DispalyAllCHQ(" AND MO.CHQDate = CONVERT(DATE, NOW())");
        }

        private void btnALLChq_Click(object sender, EventArgs e)
        {
            DispalyAllCHQ("");
        }

        private void btnRange_Click(object sender, EventArgs e)
        {
            pnlDate.Visible = true;
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            DispalyAllCHQ(" AND MO.CHQDate BETWEEN CONVERT(DATE, '" + dtpFrom.Value.Date + "') AND CONVERT(DATE, '" + dtpTo.Value.Date + "')");
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

                if(lstGrid.Items[j].Checked == true)
                {
                    counter += 1;
                    double tmpVal2 = Convert.ToDouble(lstGrid.Items[j].SubItems[3].Text);
                    tmpSum += tmpVal2;
                }
            }

            lblSelectedChq.Text = counter.ToString();
            lblSelectedChqVal.Text = string.Format("{0:N}", tmpSum);
            lblTotalChqVal.Text= string.Format("{0:N}", tmpTotal);
            lblTotChq.Text = lstGrid.Items.Count.ToString();
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

        private void UpdateMOP()
        {
            for (int i = 0; i < lstGrid.Items.Count; i++)
            {
                if(lstGrid.Items[i].Checked == true)
                {
                    MySqlCommand command = new MySqlCommand("UPDATE tblMOP SET IsDeposited = 'Y' , DepositedOn = '" + gDepositedOn + "', " +
                    " DepositeBy = '" + gDepositedBy + "' WHERE MOPID = " + Convert.ToInt32(lstGrid.Items[i].SubItems[6].Text) + " ", GlobalData.GCon);
                    command.ExecuteNonQuery();
                }
            }
        }
       
        private long RoadToSave()
        {
            long tmpID = 0;
            string tmpBillNo = GlbData.getUniqueNumber("CHQDEP", GlobalData.GCompID).ToString();

            tran.RefNo = tmpBillNo;
            tran.TotalChq = Convert.ToInt32(lblSelectedChq.Text);
            tran.ChqValue = Convert.ToDouble(lblSelectedChqVal.Text);
            tran.Notes = gNotes;
            tran.DepositedOn = gDepositedOn;
            tran.DepositedBy = gDepositedBy;
            tran.BankID = gBankID;
            tran.UserID = GlobalData.GUserID;
            tran.UserName = GlobalData.GUsername;
            tran.CompID = GlobalData.GCompID;
            tran.ComputerName = GlobalData.GCompName;

            tmpID = tran.SaveCHQDepositBrief();
            tran.SaveCHQDepositDetail(tmpID, lstGrid);
            UpdateMOP();

            return tmpID;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsRequired())
            {
                if (fConfirm.SayMessage("SV") == true)
                {
                    frmCHQDepositPOP f = new frmCHQDepositPOP();
                    f.ShowDialog();

                    if(f.gOkCancel==true)
                    {
                        gNotes = f.txtNotes.Text.Trim();
                        gDepositedOn = Convert.ToDateTime(f.dtpDate.Text);
                        gDepositedBy = f.txtName.Text.Trim();
                        gBankID = f.gBankID;
                    }

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
    }
}
