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
    public partial class frmConfirmMessage : Form
    {
        public Boolean gOkCancel = false;

        public frmConfirmMessage()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            gOkCancel = true;
            this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            gOkCancel = false;
            this.Hide();
        }

        public Boolean SayMessage(string cMessage)
        {
            switch (cMessage)
            {
                case "SV":
                    lblMessage.Text = "Do you want to save?";
                    this.ShowDialog();
                    break;
                case "DL":
                    lblMessage.Text = "Do you want to Delete?";
                    this.ShowDialog();
                    break;
                case "CL":
                    lblMessage.Text = "Do you want to Continue?";
                    this.ShowDialog();
                    break;
                case "ET":
                    lblMessage.Text = "Do you want to Edit?";
                    this.ShowDialog();
                    break;
                case "PR":
                    lblMessage.Text = "Do you want to Print?";
                    this.ShowDialog();
                    break;
                default:
                    break;
            }

            if (gOkCancel == true)
            {             
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
