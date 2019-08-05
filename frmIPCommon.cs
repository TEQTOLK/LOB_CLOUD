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
    public partial class frmIPCommon : Form
    {
        public string gTableName = "";
        private Boolean gEditFalg = false;
        public string gHeaderName = "";

        DataSet dSet = new DataSet();
        frmConfirmMessage fConfirm = new frmConfirmMessage();
        StringBuilder gSB = new StringBuilder();
        GlobalData GlbData = new GlobalData();
        DataTable dataTable = new DataTable();
        MySqlDataAdapter sqlAdapter = new MySqlDataAdapter();
        MasterFiles masterFiles = new MasterFiles();

        public frmIPCommon()
        {
            InitializeComponent();
        }

        public long SaveOrUpdateCommon()
        {
            long tmpID = 0;

            masterFiles.Code = txtCode.Text.Trim();
            masterFiles.NameOF = txtName.Text.Trim();
            masterFiles.DescriptionOf = "";


            if (gEditFalg == true)
            {
                masterFiles.UpdateCommon(gTableName);
                tmpID = 0;
            }
            else
                tmpID = masterFiles.SaveCommon(gTableName);

            return tmpID;
        }

        public void FillCommon()
        {
            masterFiles.FillCommon(txtCode.Text.Trim(), gTableName);
            txtName.Text = masterFiles.NameOF;
        }

        private void txtCode_Validating(object sender, CancelEventArgs e)
        {
            if (txtCode.Text == "")
            {
                txtCode.Clear();
                txtName.Clear();
                return;
            }

            gSB.Clear();
            gSB.Append("SELECT Code FROM " + gTableName + " WHERE Code = '" + txtCode.Text.Trim() + "' ");
            if(GlbData.AlreadyExist(gSB.ToString()))
            {
                gEditFalg = true;
                FillCommon();
                btnDelete.Enabled = true;
            }
            else
            {
                gEditFalg = false;
            }
        }

        private Boolean IsRequired()
        {
            if(txtCode.Text.Trim() == "")
            {
                MessageBox.Show("Empty Code", "INVALID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCode.Focus();
                return false;
            }
            if(txtName.Text.Trim() == "")
            {
                MessageBox.Show("Empty Name", "INVALID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }
            return true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fillCommon()
        {
            gSB.Clear();
            gSB.Append("SELECT CustID, Code, NameOf FROM " + gTableName + "  ");
            dSet = GlbData.getDataSet(gSB.ToString(), gTableName);
            DataView dView = new DataView(dSet.Tables[0]);
            dgvDetail.DataSource = dView;
            SettingGrid();
        }

        public void SettingGrid()
        {
            dgvDetail.Columns["CustID"].Visible = false;
            dgvDetail.Columns["Code"].HeaderText = "Code";
            dgvDetail.Columns["Code"].Width = 100;
            dgvDetail.Columns["NameOF"].HeaderText = "Name";
            dgvDetail.Columns["NameOF"].Width = 380;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsRequired())
            {
                if (fConfirm.SayMessage("SV") == true)
                {
                    long tmpKeyHolder = 0;
                    tmpKeyHolder = SaveOrUpdateCommon();

                    if (tmpKeyHolder == 0)
                    {
                        GlbData.SayMessage("Save Failed!!!", 0, "");
                    }
                    else
                    {
                        GlbData.SayMessage("Save Success!!!", 1, "");
                        txtCode.Clear();
                        txtName.Clear();
                        txtCode.Focus();
                        fillCommon();
                    }
                }
            }
        }

        private void frmIPCommon_Load(object sender, EventArgs e)
        {
            lblHeader.Text = gHeaderName;
            this.Text = gHeaderName;
            fillCommon();
        }

        private long DeleteRecord()
        {
            MySqlCommand cmd = new MySqlCommand("DELETE FROM " + gTableName + " WHERE Code= '" + txtCode.Text + "' ", GlobalData.GCon);
            cmd.ExecuteNonQuery();
            return 1;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(IsRequired())
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
                        txtCode.Clear();
                        txtName.Clear();
                        txtCode.Focus();
                        fillCommon();
                    }
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtCode.Clear();
            txtName.Clear();
            txtCode.Focus();
            btnDelete.Enabled = false;
            fillCommon();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text.Trim() != "")
            {
                dSet.Tables[0].DefaultView.RowFilter = "NameOf like '%" + txtSearch.Text + "%'";
                dgvDetail.DataSource = dSet.Tables[0].DefaultView;
            }
            else
            {
                dSet.Tables[0].DefaultView.RowFilter = "";
                dgvDetail.DataSource = dSet.Tables[0].DefaultView;
            }
        }
    }
}
