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
    public partial class frmIPSupplier : Form
    {
        private Boolean gEditFlag = false;
        private int gCustID = 0;
        private int gAreaID = 0;

        DataSet dSet = new DataSet();
        frmConfirmMessage fConfirm = new frmConfirmMessage();
        StringBuilder gSB = new StringBuilder();
        GlobalData GlbData = new GlobalData();
        DataTable dataTable = new DataTable();
        MySqlDataAdapter sqlAdapter = new MySqlDataAdapter();
        MasterFiles masterFiles = new MasterFiles();
        frmIPSearchDealer f = new frmIPSearchDealer();

        public frmIPSupplier()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private long SaveOrUpdateSupplier()
        {
            long tmpID = 0;

            masterFiles.Code = txtCode.Text.Trim();
            masterFiles.NameOF = txtName.Text.Trim();
            masterFiles.Add1 = txtAddress01.Text.Trim();
            masterFiles.Add2 = txtAddress02.Text.Trim();
            masterFiles.City = txtCity.Text.Trim();
            masterFiles.Tp1 = txtTp1.Text.Trim();
            masterFiles.Tp2 = txtTp2.Text.Trim();
            masterFiles.Tp3 = txtTp3.Text.Trim();
            masterFiles.EmailID = txtEmail.Text.Trim();
            masterFiles.OfficeNo = txtOffice.Text.Trim();
            masterFiles.Note = txtDesc.Text.Trim();
            masterFiles.AreaID = gAreaID;

            if (chkActive.Checked == true)
                masterFiles.IsActive = "Y";
            else
                masterFiles.IsActive = "N";

            if (gEditFlag == false)
            {
                masterFiles.SaveSupplier();
                tmpID = 1;
            }
               
            else
                tmpID = masterFiles.UpdateSupplier();

            return tmpID;
        }

        private void ClearLocal()
        {
            txtName.Clear();
            txtAddress01.Clear();
            txtAddress01.Clear();
            txtCity.Clear();
            txtTp1.Clear();
            txtTp2.Clear();
            txtTp3.Clear();
            txtOffice.Clear();
            txtDesc.Clear();
            btnDelete.Enabled = false;
        }

        private Boolean IsRequired()
        {
            if(txtCode.Text == "")
            {
                MessageBox.Show("Empty Code", "INVALID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCode.Focus();
                return false;
            }
            if(txtName.Text == "")
            {
                MessageBox.Show("Empty Name", "INVALID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }
            if(txtAddress01.Text == "")
            {
                MessageBox.Show("Empty Address", "INVALID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAddress01.Focus();
                return false;
            }
            if(txtCity.Text == "")
            {
                MessageBox.Show("Empty City", "INVALID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCity.Focus();
                return false;
            }
            if(txtTp1.Text == "")
            {
                MessageBox.Show("Empty Telephone No", "INVALID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTp1.Focus();
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
                    gAreaID = Convert.ToInt32(cmbArea.SelectedValue);
                    tmpKeyHolder = SaveOrUpdateSupplier();

                    if (tmpKeyHolder == 0)
                    {
                        GlbData.SayMessage("Save Failed!!!", 0, "");
                    }
                    else
                    {
                        GlbData.SayMessage("Save Success!!!", 1, "");
                        ClearLocal();
                        txtCode.Clear();
                        txtCode.Focus();
                    }
                }
            }
        }

        private long DeleteRecord()
        {
            MySqlCommand cmd = new MySqlCommand("DELETE FROM tblSupplier WHERE Code= '" + txtCode.Text + "' ", GlobalData.GCon);
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
            txtCode.Clear();
            txtCode.Focus();
        }

        private void frmIPSupplier_Load(object sender, EventArgs e)
        {
            GlbData.FillComboBox(cmbArea, "tblArea", "ORDER BY NameOF");
        }

        private void btnIFind_Click(object sender, EventArgs e)
        {
            f.TABLE_NAME = "tblSupplier";
            f.ShowDialog();
            if (f.gOkCancel == true)
            {
                txtCode.Text = f.CODE;
                gCustID = f.CUSTID;
                txtCode.Focus();
            }
        }

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Down)
            {
                btnIFind.PerformClick();
            }
        }

        private void fillSupplier()
        {
            masterFiles.FillSupplier(txtCode.Text.Trim());
            txtName.Text = masterFiles.NameOF;
            txtAddress01.Text = masterFiles.Add1;
            txtAddress02.Text = masterFiles.Add2;
            txtCity.Text = masterFiles.City;
            txtTp1.Text = masterFiles.Tp1;
            txtTp2.Text = masterFiles.Tp2;
            txtTp3.Text = masterFiles.Tp3;
            txtOffice.Text = masterFiles.OfficeNo;
            txtEmail.Text = masterFiles.EmailID;
            txtDesc.Text = masterFiles.Note;
            gAreaID = masterFiles.AreaID;
            cmbArea.SelectedValue = gAreaID;
        }

        private void txtCode_Validating(object sender, CancelEventArgs e)
        {
            if(txtCode.Text == "")
            {
                ClearLocal();
                txtCode.Clear();
                return;
            }

            gSB.Clear();
            gSB.Append("SELECT Code FROM tblSupplier WHERE Code = '" + txtCode.Text.Trim() + "' ");
            if (GlbData.AlreadyExist(gSB.ToString()))
            {
                gEditFlag = true;
                fillSupplier();
                btnDelete.Enabled = true;
            }
            else
            {
                gEditFlag = false;
            }
        }

        private void btnArea_Click(object sender, EventArgs e)
        {
            frmIPCommon fCommon = new frmIPCommon();
            fCommon.gTableName = "tblArea";
            fCommon.gHeaderName = "Area ".ToUpper();
            fCommon.ShowDialog();
            GlbData.FillComboBox(cmbArea, "tblArea", "ORDER BY NameOF");
        }

        private void cmbArea_Validating(object sender, CancelEventArgs e)
        {
            if (cmbArea.Items.Count == 0)
                return;

            gAreaID = Convert.ToInt32(cmbArea.SelectedValue);
        }
    }
}
