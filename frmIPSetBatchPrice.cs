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
    public partial class frmIPSetBatchPrice : Form
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
        Transactions tran = new Transactions();

        public frmIPSetBatchPrice()
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

        private void ClearLocal()
        {
            txtName.Clear();
            txtBrandName.Clear();
            txtPrice.Text = "0.00";
            lblCost.Text = "0.00";
            lblWholeSale.Text = "0.00";
            lblSelling.Text = "0.00";
            lblDiscount.Text = "0.00";
            txtBrandName.Text = "";
        }


        private void fillProduct()
        {
            masterFiles.FillProduct(txtCode.Text);
            gItemID = masterFiles.CustID;
            txtName.Text = masterFiles.NameOF;
            txtBrandName.Text = masterFiles.BrandName;
            lblCost.Text = string.Format("{0:N}", masterFiles.Cost);
            lblWholeSale.Text = string.Format("{0:N}", masterFiles.WholeSalePrice);
            lblSelling.Text = string.Format("{0:N}", masterFiles.SellingPrice);
            lblDiscount.Text = string.Format("{0:N}", masterFiles.Discount);
        }

        private void txtCode_TextChanged(object sender, EventArgs e)
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
                FillPrice();
            }
            else
            {
                MessageBox.Show("Sorry.. This item does not exist", "Empty Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void txtCode_Validating(object sender, CancelEventArgs e)
        {

        }

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                btnIFind.PerformClick();
        }

        private void AddingGrid(double cPrice)
        {
            DataGridViewRow newRow = (DataGridViewRow)dgvPrice.RowTemplate.Clone();
            newRow.CreateCells(dgvPrice);

            newRow.Cells[0].Value = string.Format("{0:N}", cPrice);

            dgvPrice.Rows.Add(newRow);
        }

        private Boolean IsRequiredGrid()
        {
            if (txtPrice.Text == "" || txtPrice.Text == "0" || txtPrice.Text == "0.00")
            {
                MessageBox.Show("Please Enter Price Here...", "INVALID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrice.Focus();
                return false;
            }
            return true;
        }

        private void txtPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if(IsRequiredGrid())
                {
                    AddingGrid(Convert.ToDouble(txtPrice.Text));
                    txtPrice.Clear();
                    txtPrice.Text = "0.00";
                    txtPrice.Focus();
                    txtPrice.SelectAll();
                }
            }
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

        private long DeleteRecord()
        {
            MySqlCommand cmd = new MySqlCommand("DELETE FROM tblSetBatchPrice WHERE ItemID = " + gItemID + " ", GlobalData.GCon);
            cmd.ExecuteNonQuery();
            return 1;
        }

        private long RoadToSave()
        {
            long tmpID = 0;

            DeleteRecord();

            tran.ItemID = gItemID;
            tran.SaveBatchPrice(dgvPrice);

           return tmpID = 1;
        }


        private Boolean IsRequired()
        {
            if (dgvPrice.Rows.Count == 0)
            {
                MessageBox.Show("Empty Grid...", "INVALID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dgvPrice.Focus();
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
                    long tmpKeyHolder = 0;
                    tmpKeyHolder = RoadToSave();

                    if (tmpKeyHolder == 0)
                    {
                        GlbData.SayMessage("Save Failed!!!", 0, "");
                    }
                    else
                    {
                        GlbData.SayMessage("Save Success!!!", 1, "");
                        ClearLocal();
                        dgvPrice.Rows.Clear();
                        txtCode.Clear();
                        txtCode.Focus();
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

        private void FillPrice()
        {
            gSB.Clear();
            gSB.Append("SELECT * FROM tblSetBatchPrice WHERE ItemID = " + gItemID + "");
            dataTable = GlbData.getDataTable(gSB.ToString());

            foreach (DataRow dRow in dataTable.Rows)
            {
                dgvPrice.Rows.Add(string.Format("{0:N}", Convert.ToDouble(dRow["Price"])));
            }

            dataTable = null;
        }
    }
}
