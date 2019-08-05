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
    public partial class frmIPSetFreeScheme : Form
    {
        private int gItemID = 0;

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

        public frmIPSetFreeScheme()
        {
            InitializeComponent();
        }

        private void btnIFind_Click(object sender, EventArgs e)
        {
            frmIPItemSearch f1 = new frmIPItemSearch();
            f1.ShowDialog();
            if (f1.gOkCancel == true)
            {
                txtCode.Text = f1.CODE;
                txtCode.Focus();
            }
        }

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down) btnIFind.PerformClick();
        }

        private void ClearLocal()
        {
            txtName.Clear();
            txtBrandName.Clear();
            txtBrandName.Text = "";
        }

        private void fillProduct()
        {
            masterFiles.FillProduct(txtCode.Text);
            gItemID = masterFiles.CustID;
            txtName.Text = masterFiles.NameOF;
            txtBrandName.Text = masterFiles.BrandName;
        }

        private void txtCode_Validating(object sender, CancelEventArgs e)
        {
            if (txtCode.Text == "")
            {
                ClearLocal();
                txtCode.Clear();
                return;
            }

            gSB.Clear();
            gSB.Append("SELECT * FROM tblItem WHERE Code = '" + txtCode.Text.Trim() + "' ");
            if (GlbData.AlreadyExist(gSB.ToString()))
            {
                fillProduct();
                FillGrid();
            }
            else
            {
                MessageBox.Show("Sorry.. This item does not exist", "Empty Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void AddingGrid(double cFrom, double cTo, double cFree)
        {
            DataGridViewRow newRow = (DataGridViewRow)dgvPrice.RowTemplate.Clone();
            newRow.CreateCells(dgvPrice);

            newRow.Cells[0].Value =  cFrom;
            newRow.Cells[1].Value = cTo; 
            newRow.Cells[2].Value = cFree;

            dgvPrice.Rows.Add(newRow);
        }

        private void ClearGrid()
        {
            txtAmountFrom.Text = "0";
            txtDisRate.Text = "0";
            txtAmountTo.Text = "0";
        }

        private Boolean IsRequiredGrid()
        {
            if (txtAmountFrom.Text == "")
            {
                MessageBox.Show("Please Enter From Qty Here...", "INVALID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAmountFrom.Focus();
                return false;
            }
            if (txtAmountTo.Text == "" || txtAmountTo.Text == "0")
            {
                MessageBox.Show("Please Enter To Qty Here...", "INVALID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAmountTo.Focus();
                return false;
            }
            if (txtDisRate.Text == "" || txtDisRate.Text == "0")
            {
                MessageBox.Show("Please Enter Free Qty Here...", "INVALID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDisRate.Focus();
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool IsRequired()
        {
            if(txtCode.Text == "")
            {
                MessageBox.Show("Empty Item", "INVALID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCode.Focus();
                return false;
            }
            if (dgvPrice.Rows.Count == 0)
            {
                MessageBox.Show("Empty Grid", "INVALID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dgvPrice.Focus();
                return false;
            }
            return true;
        }

        private long SaveFreeScheme()
        {
            gSB.Clear();
            gSB.Append("INSERT INTO tblSetFreeScheme ( " +
                " ItemID, FromQty, ToQty, FreeQty, IsActive) " +
                " VALUES ( " +
                " @ItemID, @FromQty, @ToQty, @FreeQty, @IsActive) ");

            MySqlCommand cmd = GlobalData.GCon.CreateCommand();
            MySqlTransaction trans = GlobalData.GCon.BeginTransaction();
            cmd.Connection = GlobalData.GCon;
            cmd.Transaction = trans;
            cmd.CommandText = gSB.ToString();

            try
            {
                for (int i = 0; i < dgvPrice.Rows.Count; i++)
                {
                    cmd.Parameters.AddWithValue("@ItemID", gItemID);
                    cmd.Parameters.AddWithValue("@FromQty", Convert.ToDouble(dgvPrice.Rows[i].Cells[0].Value));
                    cmd.Parameters.AddWithValue("@ToQty", Convert.ToDouble(dgvPrice.Rows[i].Cells[1].Value));
                    cmd.Parameters.AddWithValue("@FreeQty", Convert.ToDouble(dgvPrice.Rows[i].Cells[2].Value));
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
                    tmpKeyHolder = SaveFreeScheme();

                    if (tmpKeyHolder == 0)
                    {
                        GlbData.SayMessage("Save Failed!!!", 0, "");
                    }
                    else
                    {
                        GlbData.SayMessage("Save Success!!!", 1, "");
                        ClearLocal();
                        dgvPrice.Rows.Clear();
                        txtCode.Focus();
                    }
                }
            }
        }

        private long DeleteRecord()
        {
            MySqlCommand cmd = new MySqlCommand("DELETE FROM tblSetFreeScheme WHERE ItemID = " + gItemID + " ", GlobalData.GCon);
            cmd.ExecuteNonQuery();
            return 1;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (IsRequired())
            {
                if (fConfirm.SayMessage("DL") == true)
                {
                    long tmpKeyHolder = 0;
                    tmpKeyHolder = DeleteRecord();

                    if (tmpKeyHolder == 0)
                    {
                        GlbData.SayMessage("Delete Failed!!!", 0, "");
                    }
                    else
                    {
                        GlbData.SayMessage("Delete Success!!!", 1, "");
                        ClearLocal();
                        txtCode.Clear();
                        txtCode.Focus();
                    }
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearLocal();
            dgvPrice.Rows.Clear();
            txtCode.Focus();
        }

        private void FillGrid()
        {
            gSB.Clear();
            gSB.Append("SELECT * FROM tblSetFreeScheme WHERE ItemID = " + gItemID + "");
            dataTable = GlbData.getDataTable(gSB.ToString());

            foreach (DataRow dRow in dataTable.Rows)
            {
                dgvPrice.Rows.Add(Convert.ToDouble(dRow["FromQty"]).ToString(), Convert.ToDouble(dRow["ToQty"]).ToString(), Convert.ToDouble(dRow["FreeQty"]).ToString());
            }

            dataTable = null;
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
    }
}
