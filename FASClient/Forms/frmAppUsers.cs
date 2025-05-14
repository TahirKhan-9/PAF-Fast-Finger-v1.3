using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ADService.Helper.AD;
using FASClient.Forms;
using Usman.CodeBlocks.Crypto;

namespace FASClient
{
    public partial class frmAppUsers : Form
    {

        public frmAppUsers()
        {
            InitializeComponent();

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void ResetFields()
        {
            txtUserID.Text = "";
            txtUserName.Text = "";
            txtLoginID.Text = "";
            txtPassword.Text = "";
            //txtConfirm.Text = "";
            btnSave.Enabled = false;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ResetFields();
        }

        private void frmAppUsers_Load(object sender, EventArgs e)
        {
            this.Text = Globals.GetAppTitle() + " v" + Application.ProductVersion;
            Globals.MakeTransparent(this, lvUsers, lvUsers.Location.X, lvUsers.Location.Y);
            cboRole.DataSource = new Roles().GetList();
            cboRole.ValueMember = "ID";
            cboRole.DisplayMember = "Name";
            btnSave.Enabled = false;
            FillList();
            btnCancel_Click(null, null);
        }

        void FillList()
        {
            lvUsers.Items.Clear();

            List<AppUser> users = new List<FASClient.AppUser>();
            users = new AppUser().GetList();
            foreach (AppUser u in users)
            {
                ListViewItem item = new ListViewItem((lvUsers.Items.Count + 1).ToString());
                item.SubItems.Add(u.UserID.ToString());
                item.SubItems.Add(u.UserName);
                item.SubItems.Add(u.LoginID);
                item.SubItems.Add(u.LoginPwd);
                item.SubItems.Add(new Roles(u.RoleID).Name);
                lvUsers.Items.Add(item);
            }
        }

        private void btnShowPassword_Click(object sender, EventArgs e)
        {
            MessageBox.Show(txtPassword.Text, txtLoginID.Text + " Password", MessageBoxButtons.OK);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                new frmMessageBox(MessageBoxType.Alert, "Please Enter User Name").ShowDialog();
                txtUserName.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtLoginID.Text))
            {
                new frmMessageBox(MessageBoxType.Alert, "Please Enter Login ID").ShowDialog();
                txtLoginID.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                new frmMessageBox(MessageBoxType.Alert, "Please Enter Password").ShowDialog();
                txtPassword.Focus();
                return;
            }

            //if (txtPassword.Text != txtConfirm.Text)
            //{
            //    new frmMessageBox(MessageBoxType.Alert, "Password did not matched with Confirm Password").ShowDialog();
            //    txtConfirm.Focus();
            //    return;
            //}

            // first user must be administrator
            if (Globals.defaultUser)
            {
                //if (!chkAdmin.Checked)
                //{
                //    MessageBox.Show("Please Add Administrator Account First\n\rOr Login from Administrator Account to Create More Users.");
                //    return;
                //}
            }
            //chkAdmin.Visible = true;
            AppUser u = new AppUser();
            u.UserName = txtUserName.Text;
            u.LoginID = txtLoginID.Text;
            u.LoginPwd = txtPassword.Text;
            u.RoleID = Convert.ToInt32(cboRole.SelectedValue);
            //u.IsAdmin = chkAdmin.Checked;

            if (string.IsNullOrEmpty(txtUserID.Text))
            {
                // save new record
                if (u.Save())
                {
                    new frmMessageBox(MessageBoxType.Info, "User Added Successfully ...").ShowDialog();
                    // add in the list
                    ListViewItem item = new ListViewItem((lvUsers.Items.Count + 1).ToString());
                    item.SubItems.Add(u.UserID.ToString());
                    item.SubItems.Add(u.UserName);
                    item.SubItems.Add(u.LoginID);
                    item.SubItems.Add(StringCipher.Decrypt(u.LoginPwd));
                    item.SubItems.Add(new Roles(u.RoleID).Name);
                    lvUsers.Items.Add(item);

                    btnCancel_Click(sender, e);
                }
            }
            else
            {
                // update old record
                u.UserID = Convert.ToInt32(txtUserID.Text);
                if (u.Update())
                {
                    new frmMessageBox(MessageBoxType.Info, "User Updated Successfully").ShowDialog();
                    ListViewItem item = lvUsers.SelectedItems[0];
                    item.SubItems[1].Text = u.UserID.ToString();
                    item.SubItems[2].Text = u.UserName;
                    item.SubItems[3].Text = u.LoginID;
                    item.SubItems[4].Text = u.LoginPwd;
                    item.SubItems[5].Text = new Roles(u.RoleID).Name;

                    btnCancel_Click(sender, e);
                }
            }

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserID.Text))
            {
                new frmMessageBox(MessageBoxType.Alert, "Select A User First.").ShowDialog();
                return;
            }

            AppUser user = new AppUser(Convert.ToInt32(txtUserID.Text));
            if (Globals.User == user)
            {
                new frmMessageBox(MessageBoxType.Alert, "Cant Delete Current Logged In User.").ShowDialog();
                return;
            }

            if (user.Delete())
            {
                new frmMessageBox(MessageBoxType.Info, "User Removed Successfully...").ShowDialog();
                ListViewItem item = lvUsers.SelectedItems[0];
                lvUsers.Items.Remove(item);
            }
        }

        private void lvUsers_SelectedIndexChanged(object sender, EventArgs e)
        {

            btnCancel_Click(null, null);

            if (lvUsers.SelectedItems.Count <= 0)
                return;

            ListViewItem item = lvUsers.SelectedItems[0];
            AppUser user = new AppUser(Convert.ToInt32(item.SubItems[1].Text));

            if (user != null)
            {
                txtUserID.Text = user.UserID.ToString();
                txtUserName.Text = user.UserName;
                txtLoginID.Text = user.LoginID;
                txtPassword.Text = user.LoginPwd;
                cboRole.Text = new Roles(user.RoleID).Name;
            }
        }

        private void lvUsers_Click(object sender, EventArgs e)
        {

        }

        private void cboRoles_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAuthenticate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtLoginID.Text))
            {
                new frmMessageBox(MessageBoxType.Alert, "Please Enter Login ID").ShowDialog();
                txtLoginID.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                new frmMessageBox(MessageBoxType.Alert, "Please Enter Password").ShowDialog();
                txtPassword.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtConfirm.Text))
            {
                new frmMessageBox(MessageBoxType.Alert, "Please Enter Domain Name").ShowDialog();
                txtConfirm.Focus();
                return;
            }
            if (new ADHelper().AuthenticateUser(txtConfirm.Text.ToString(), txtLoginID.Text.ToString(), txtPassword.Text.ToString()))
            {
                new frmMessageBox(MessageBoxType.Confirm, "Login Authenticated").ShowDialog();
                btnSave.Enabled = true;
            }
            else
            {
                new frmMessageBox(MessageBoxType.Alert, "Login Authentication Failed").ShowDialog();
            }
        }
    }
}
