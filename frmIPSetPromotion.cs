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
    public partial class frmIPSetPromotion : Form
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
        Transactions tran = new Transactions();

        public frmIPSetPromotion()
        {
            InitializeComponent();
        }

        private void ClearLocal()
        {
            txtDes.Text = "";
            dtpEnd.Text = DateTime.Now.ToString();
            dtpStart.Text = DateTime.Now.ToString();
            ClearGrid();
        }

        private void ClearGrid()
        {
            txtAmountFrom.Text = "0.00";
            txtDisRate.Text = "0.00";
            txtAmountTo.Text = "0.00";
        }

        private void AddingGrid(double cFrom, double cTo, double cDisRate)
        {
            DataGridViewRow newRow = (DataGridViewRow)dgvPrice.RowTemplate.Clone();
            newRow.CreateCells(dgvPrice);

            newRow.Cells[0].Value = string.Format("{0:N}", cFrom);
            newRow.Cells[1].Value = string.Format("{0:N}", cTo);
            newRow.Cells[2].Value = string.Format("{0:N}", cDisRate);

            dgvPrice.Rows.Add(newRow);
        }

        private bool IsRequired()
        {
            if(Convert.ToDateTime(dtpEnd.Text) < Convert.ToDateTime(dtpStart.Text))
            {
                MessageBox.Show("Invalid Date Range", "INVALID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpEnd.Focus();
                return false;
            }
            gSB.Clear();
            gSB.Append("SELECT * FROM tblSetPromotion WHERE StartOn <= CONVERT(date, '" + dtpEnd.Text + "') AND EndOn >= CONVERT(date, '" + dtpStart.Text + "') ");
            if(GlbData.AlreadyExist(gSB.ToString()))
            {
                MessageBox.Show("Invalid Date Range", "INVALID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if(dgvPrice.Rows.Count == 0)
            {
                MessageBox.Show("Empty Grid", "INVALID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dgvPrice.Focus();
                return false;
            }
            return true;
        }

        private Boolean IsRequiredGrid()
        {
            if (txtAmountFrom.Text == "" || txtAmountFrom.Text == "0" || txtAmountFrom.Text == "0.00")
            {
                MessageBox.Show("Please Enter From Amount Here...", "INVALID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAmountFrom.Focus();
                return false;
            }
            if (txtAmountTo.Text == "" || txtAmountTo.Text == "0" || txtAmountTo.Text == "0.00")
            {
                MessageBox.Show("Please Enter To Amount Here...", "INVALID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAmountTo.Focus();
                return false;
            }
            if (txtDisRate.Text == "" || txtDisRate.Text == "0" || txtDisRate.Text == "0.00")
            {
                MessageBox.Show("Please Enter Discount Rate Here...", "INVALID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDisRate.Focus();
                return false;
            }
            if (Convert.ToDouble(txtDisRate.Text) > 100)
            {
                MessageBox.Show("Discount rate can't be grater than 100", "INVALID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDisRate.SelectAll();
                txtDisRate.Focus();
                return false;
            }
            double toAmount, fromAmount = 0;
            double.TryParse(txtAmountFrom.Text, out fromAmount);
            double.TryParse(txtAmountTo.Text, out toAmount);

            if (toAmount < fromAmount)
            {
                MessageBox.Show("To Amount can't less than From Amount", "INVALID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAmountTo.SelectAll();
                txtAmountTo.Focus();
                return false;
            }
            return true;
        }

        private void txtDisRate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (IsRequiredGrid())
                {
                    AddingGrid(Convert.ToDouble(txtAmountFrom.Text), Convert.ToDouble(txtAmountTo.Text), Convert.ToDouble(txtDisRate.Text));
                    ClearGrid();
                    txtAmountFrom.Focus();
                    txtAmountFrom.SelectAll();
                }
            }
        }

        private void txtAmountFrom_Validating(object sender, CancelEventArgs e)
        {
            txtAmountFrom.Text = string.Format("{0:N}", Convert.ToDouble(txtAmountFrom.Text));
        }

        private void txtAmountTo_Validating(object sender, CancelEventArgs e)
        {
            txtAmountTo.Text = string.Format("{0:N}", Convert.ToDouble(txtAmountTo.Text));            
        }

        private void txtDisRate_Validating(object sender, CancelEventArgs e)
        {
            txtDisRate.Text = string.Format("{0:N}", Convert.ToDouble(txtDisRate.Text));
        }

        private void dgvPrice_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == dgvPrice.NewRowIndex || e.RowIndex < 0)
                return;

            if (e.ColumnIndex == dgvPrice.Columns["Column7"].Index)
            {
                dgvPrice.Rows.RemoveAt(e.RowIndex);
            }
        }

        private long SavePromotion()
        {
            gSB.Clear();
            gSB.Append("INSERT INTO tblSetPromotion ( " +
                " StartOn, EndOn, DescriptionOf, AmountFrom, AmountTo, DisRate, IsActive) " +
                " VALUES ( " +
                " @StartOn, @EndOn, @DescriptionOf, @AmountFrom, @AmountTo, @DisRate, @IsActive) ");

            MySqlCommand cmd = GlobalData.GCon.CreateCommand();
            MySqlTransaction trans = GlobalData.GCon.BeginTransaction();
            cmd.Connection = GlobalData.GCon;
            cmd.Transaction = trans;
            cmd.CommandText = gSB.ToString();

            try
            {
                for (int i = 0; i < dgvPrice.Rows.Count; i++)
                {
                    cmd.Parameters.AddWithValue("@StartOn", Convert.ToDateTime(dtpStart.Text));
                    cmd.Parameters.AddWithValue("@EndOn", Convert.ToDateTime(dtpEnd.Text));
                    cmd.Parameters.AddWithValue("@DescriptionOf", txtDes.Text.Trim());
                    cmd.Parameters.AddWithValue("@AmountFrom", Convert.ToDouble(dgvPrice.Rows[i].Cells[0].Value));
                    cmd.Parameters.AddWithValue("@AmountTo", Convert.ToDouble(dgvPrice.Rows[i].Cells[1].Value));
                    cmd.Parameters.AddWithValue("@DisRate", Convert.ToDouble(dgvPrice.Rows[i].Cells[2].Value));
                    cmd.Parameters.AddWithValue("@IsActive", "Y");
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
                trans.Commit();

                return 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                trans.Rollback();
                return 0;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsRequired())
            {
                if (fConfirm.SayMessage("SV") == true)
                {
                    long tmpKeyHolder = 0;
                    tmpKeyHolder = SavePromotion();

                    if (tmpKeyHolder == 0)
                    {
                        GlbData.SayMessage("Save Failed!!!", 0, "");
                    }
                    else
                    {
                        GlbData.SayMessage("Save Success!!!", 1, "");
                        ClearLocal();
                        dgvPrice.Rows.Clear();
                        dtpStart.Focus();
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearLocal();
            dgvPrice.Rows.Clear();
        }
    }
}
