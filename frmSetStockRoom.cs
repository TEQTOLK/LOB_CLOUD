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
    public partial class frmSetStockRoom : Form
    {
        GlobalData GlbData = new GlobalData();
        DataSet dSet = new DataSet();
        StringBuilder gSB = new StringBuilder();
        MasterFiles masterFiles = new MasterFiles();
        Transactions tran = new Transactions();
        frmConfirmMessage fConfirm = new frmConfirmMessage();
        DataTable dataTable = new DataTable();
        MySqlDataAdapter sqlAdapter = new MySqlDataAdapter();

        private int gStockRoomID = 0;
        private int gBranchID = 0;

        public frmSetStockRoom()
        {
            InitializeComponent();
        }

        private void frmSetStockRoom_Load(object sender, EventArgs e)
        {
            GlbData.FillComboBox(cboStockroom, "tblStockRoom", " ORDER BY NameOF");
            FillBranch();
            FillStockRoom();
        }

        public void FillBranch()
        {
            try
            {
                string strQuery = " SELECT CustID, ADD1 + ' - ' + CITY AS NameOf FROM tblCompany ORDER BY NameOF";
                MySqlCommand MySqlCommand = new MySqlCommand();
                {
                    MySqlCommand.Connection = GlobalData.GCon;
                    MySqlCommand.CommandType = CommandType.Text;
                    MySqlCommand.CommandText = strQuery;
                }

                sqlAdapter = new MySqlDataAdapter();
                dataTable = new DataTable();
                {
                    sqlAdapter.SelectCommand = MySqlCommand;
                    sqlAdapter.Fill(dataTable);
                }

                cboBranch.Items.Clear();

                cboBranch.DataSource = dataTable;
                cboBranch.ValueMember = "CustID";
                cboBranch.DisplayMember = "NameOF";

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                dataTable = null;
            }
        }

        private void cboBranch_Validating(object sender, CancelEventArgs e)
        {
            if (cboBranch.Text == "")
                return;
            else
                gBranchID = Convert.ToInt32(cboBranch.SelectedValue);
        }

        private void cboStockroom_Validating(object sender, CancelEventArgs e)
        {
            if (cboStockroom.Text == "")
                return;
            else
                gStockRoomID = Convert.ToInt32(cboStockroom.SelectedValue);
        }

        private Boolean IsRequiredGrid()
        {
            if (cboStockroom.Text == "")
            {
                MessageBox.Show("Empty Stock Room", "INVALID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboStockroom.Focus();
                return false;
            }
            if (cboBranch.Text == "")
            {
                MessageBox.Show("Empty Branch", "INVALID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboBranch.Focus();
                return false;
            }
            return true;
        }

        private Boolean IsRequired()
        {
            if(dgvGrid.Rows.Count == 0)
            {
                MessageBox.Show("Empty Grid", "INVALID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dgvGrid.Focus();
                return false;
            }
            return true;
        }

        private void AddingGrid(int branchID, string branchName, int stockroomID, string stockroomName)
        {
            DataGridViewRow newRow = (DataGridViewRow)dgvGrid.RowTemplate.Clone();
            newRow.CreateCells(dgvGrid);

            newRow.Cells[0].Value = branchID.ToString();
            newRow.Cells[1].Value = branchName.ToString();
            newRow.Cells[2].Value = stockroomID.ToString();
            newRow.Cells[3].Value = stockroomName.ToString();

            dgvGrid.Rows.Add(newRow);
        }

        private void cboStockroom_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                if(IsRequiredGrid())
                {
                    if(CheckSameItem())
                    {
                        gBranchID = Convert.ToInt32(cboBranch.SelectedValue);
                        gStockRoomID = Convert.ToInt32(cboStockroom.SelectedValue);

                        AddingGrid(gBranchID, cboBranch.Text, gStockRoomID, cboStockroom.Text);
                    }
                }
            }
        }

        private Boolean CheckSameItem()
        {
            int tmpBranchID = 0;
            for (int i = 0; i < dgvGrid.Rows.Count; i++)
            {
                tmpBranchID = Convert.ToInt32(dgvGrid.Rows[i].Cells[0].Value);
                if(tmpBranchID == gBranchID)
                {
                    MessageBox.Show("Sorry.. This branch already exist", "INVALID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboBranch.Focus();
                    return false;
                }
            }
            return true;
        }

        private void dgvGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == dgvGrid.NewRowIndex || e.RowIndex < 0)
                return;

            if (e.ColumnIndex == dgvGrid.Columns["Column7"].Index)
                dgvGrid.Rows.RemoveAt(e.RowIndex);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            dgvGrid.Rows.Clear();
            dgvGrid.DataSource = null;
            cboBranch.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsRequired())
            {
                if (fConfirm.SayMessage("SV") == true)
                {
                   
                    tran.SaveSetStockRoom(dgvGrid);
                    GlbData.SayMessage("Save Success!!!", 1, "");
                    this.Close();
                }
            }
        }

        private void FillStockRoom()
        {
            gSB.Clear();
            gSB.Append("SELECT ST.CompID, CM.Add1 + ' - ' + CM.City AS Company, ST.StockRoomID, SM.NameOF AS StockRoom " +
                " FROM tblSetCompStockRoom AS ST INNER JOIN " +
                " tblStockRoom AS SM ON SM.CustID = ST.StockRoomID INNER JOIN " +
                " tblCompany AS CM ON CM.CustID = ST.CompID ");
            dataTable = GlbData.getDataTable(gSB.ToString());

            foreach (DataRow row in dataTable.Rows)
            {
                dgvGrid.Rows.Add(Convert.ToInt32(row["CompID"]), row["Company"].ToString(), Convert.ToInt32(row["StockRoomID"]), row["StockRoom"].ToString());
            }
            dataTable.Clear();
            dataTable = null;
        }
    }
}
