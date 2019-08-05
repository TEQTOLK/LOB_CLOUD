using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar;

namespace LOB
{
    public partial class frmSuccessMessage : Form
    {
        public frmSuccessMessage()
        {
            InitializeComponent();
        }

        public void SayMessage(string cMessage, int cId, string cTag)
        {
            if (cId == 0)
            {
                lblMessage.Text = cMessage;
                this.BackColor = Color.Red;

                DesktopAlert.AlertPosition = eAlertPosition.TopRight;
                DesktopAlert.TextMarkupEnabled = true;
                DesktopAlert.Show(eSymbolSet.Awesome + cTag);
            }
            else
            {
                lblMessage.Text = cMessage;
                this.BackColor = Color.Green;

                DesktopAlert.AlertPosition = eAlertPosition.TopRight;
                DesktopAlert.TextMarkupEnabled = true;
                DesktopAlert.Show(eSymbolSet.Material + cTag);
            }
        }

        private void EmptyAction()
        {
        }
        private void fadeOut(object sender, EventArgs e)
        {
            if (Opacity <= 0)     //check if opacity is 0
            {
                t1.Stop();    //if it is, we stop the timer
                Close();   //and we try to close the form
            }
            else
                Opacity -= 0.45;
        }

        private void frmSuccessMessage_Load(object sender, EventArgs e)
        {
            if (t1.Interval == 50)
            {
                this.Close();
            }
           
        }

        private void frmSuccessMessage_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;    //cancel the event so the form won't be closed

            t1.Tick += new EventHandler(fadeOut);  //this calls the fade out function
            t1.Start();

            if (Opacity == 0)  //if the form is completly transparent
                e.Cancel = false;   //resume the event - the program can be closed
        }
    }
}
