using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ADService.Helper.AD;
using Microsoft.ApplicationBlocks.Data;

namespace FASClient
{
    public partial class frmLogin : Form
    {
        public bool user_not_exist = false;
        public bool cancelled = false;
        public bool success = false;
        int counter = 0;

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            cancelled = true;
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            //if (string.IsNullOrEmpty(txtLoginID.Text) && string.IsNullOrEmpty(txtPassword.Text))
            //{
            //    frmLive f = new frmLive();
            //    f.ShowDialog();
            //    return;
            //}

            if (string.IsNullOrEmpty(txtLoginID.Text))
            {
                new Forms.frmMessageBox(MessageBoxType.Alert, "Please Enter Login ID.").ShowDialog();
                txtLoginID.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                new Forms.frmMessageBox(MessageBoxType.Alert, "Please Enter Password Also.").ShowDialog();
                txtPassword.Focus();
                return;
            }

            //int n = new AppUser().TotalUsers();
            if (txtLoginID.Text.ToLower() == "admin" && txtPassword.Text.ToLower() == "admin")
            {
                Globals.defaultUser = true;
                success = true;
                pbTracker.Visible = true;
                bgWorker.RunWorkerAsync();
            }
            else
            {
               
                Globals.User = new AppUser().Login(txtLoginID.Text, txtPassword.Text);
                if (Globals.User.UserID == 0)
                {
                    if (counter >= 3)
                    {
                        success = false;
                        cancelled = true;
                        this.Close();
                    }
                    else
                    {
                        counter++;
                        new Forms.frmMessageBox(MessageBoxType.Alert, "User Login not Exists.").ShowDialog();
                        txtLoginID.Focus();
                        return;
                    }
                }
                else
                {
                    if (new ADHelper().AuthenticateUser(txtDomain.Text.ToString(), txtLoginID.Text.ToString(), txtPassword.Text.ToString()))
                    {
                        AppLogin login = new AppLogin();
                        login.UserID = Globals.User.UserID;
                        login.LoginID = Globals.User.LoginID;
                        login.LoginPwd = Globals.User.LoginPwd;
                        login.LoginTime = DateTime.Now;
                        login.ID = login.Login();

                        Globals.LoginID = login.ID;
                        success = true;
                        cancelled = false;
                        pbTracker.Visible = true;
                        bgWorker.RunWorkerAsync();
                    }
                    else
                    {
                        new Forms.frmMessageBox(MessageBoxType.Alert, "User Login failed from AD.").ShowDialog();
                        txtLoginID.Focus();
                        return;
                    }
                }
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            this.Text = Globals.GetAppTitle() + " v" + Application.ProductVersion;
            lblTitle.Text = "Login to " + Globals.GetAppTitle() + " v" + Application.ProductVersion;
            pbTracker.Visible = false;
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnLogin_Click(sender, null);
            }
        }

        private void txtLoginID_Enter(object sender, EventArgs e)
        {
            txtLoginID.SelectAll();
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            txtPassword.SelectAll();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Cache.Load();

        }

        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pbTracker.Visible = false;
            this.Close();
        }

        private void txtDomain_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnLogin_Click(sender, null);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
