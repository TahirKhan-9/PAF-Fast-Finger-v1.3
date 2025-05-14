using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FASClient.Forms
{
    public partial class frmMessageBox : Form
    {
        public DialogResult result;

        public frmMessageBox()
        {
            InitializeComponent();
        }

        public frmMessageBox(MessageBoxType type, string message)
        {
            InitializeComponent();
            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            switch(type)
            {
                case MessageBoxType.Info:
                    btnOk.Text = "OK";
                    btnCancel.Text = "Cancel";
                    //lblTitle.Text = "Information";
                    break;
                case MessageBoxType.Alert:
                    btnOk.Text = "Got It";
                    btnCancel.Text = "Cancel";
                    //lblTitle.Text = "Alert";
                    break;
                case MessageBoxType.Error:
                    btnOk.Text = "OK";
                    btnCancel.Text = "Cancel";
                    //lblTitle.Text = "Error";
                    break;
                case MessageBoxType.Confirm:
                    btnOk.Text = "Yes";
                    btnCancel.Text = "No";
                    //lblTitle.Text = "Confirm Your Action";
                    break;
                default:
                    btnOk.Text = "OK";
                    btnCancel.Text = "Cancel";
                    //lblTitle.Text = "Information";
                    break;
            }

            lblMessage.Text = message;
        }

        private void frmMessageBox_Load(object sender, EventArgs e)
        {
            this.Text = Globals.GetAppTitle() + " v" + Application.ProductVersion;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (btnOk.Text == "Yes")
                result = System.Windows.Forms.DialogResult.Yes;
               //this.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (btnCancel.Text == "No")
                result = System.Windows.Forms.DialogResult.No;

            this.Close();
        }
    }
}
