using FASClient.Classes;
using FASClient.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FASClient.Forms
{
    public partial class frmSettings : Form
    {
        string file = Application.StartupPath + "\\PhotoPath.txt";
        string picFolderPath = "";

        public frmSettings()
        {
            InitializeComponent();
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            this.Text = Globals.GetAppTitle() + " v" + Application.ProductVersion;
            picFolderPath = getFolderPath();
            txtPath.Text = picFolderPath;

            // get email settings
            EmailServer obj = new EmailServer().Get();
            if (obj.ID > 0)
            {
                txtServer.Text = obj.SMTPServer;
                txtPort.Text = obj.SMTPPort;
                txtUser.Text = obj.UserName;
                txtPassword.Text = obj.Password;
            }

            txtFooter.Text = Settings.Default.rptVFFooter;
        }

        public string getFolderPath()
        {
            string pathInsideFile = "";
            if (System.IO.File.Exists(file))
            {
                pathInsideFile = File.ReadAllText(file);
            }
            return pathInsideFile;
        }


        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();

            folderDlg.ShowNewFolderButton = true;

            DialogResult result = folderDlg.ShowDialog();

            if (result == DialogResult.OK)
            {
                txtPath.Text = folderDlg.SelectedPath;
                Environment.SpecialFolder root = folderDlg.RootFolder;
                picFolderPath = txtPath.Text;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           if (!string.IsNullOrEmpty(txtServer.Text))
            {
                if (string.IsNullOrEmpty(txtPort.Text))
                {
                    new frmMessageBox(MessageBoxType.Alert, "Please Enter Valid SMTP Port Address").ShowDialog();
                    txtPort.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(txtUser.Text))
                {
                    new frmMessageBox(MessageBoxType.Alert, "Please Enter User Name That will be used to Send Email").ShowDialog();
                    txtUser.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(txtPassword.Text))
                {
                    new frmMessageBox(MessageBoxType.Alert, "Please Enter Password of the User Also.").ShowDialog();
                    txtPassword.Focus();
                    return;
                }

                EmailServer obj = new EmailServer(txtServer.Text, txtPort.Text, txtUser.Text, txtPassword.Text);
                if (obj.Save())
                {
                    new frmMessageBox(MessageBoxType.Info, "Email Server Settings Updated Successfully.").ShowDialog();
                }
            }

            if (!string.IsNullOrEmpty(txtPath.Text))
            {
                //if (txtPath.Text.Trim().Equals(picFolderPath))
                //    return;
                
                File.WriteAllText(file, txtPath.Text);
                frmMessageBox message = new frmMessageBox(MessageBoxType.Info, "Profile Pictures Directory Path Updated Successfully...");
                message.ShowDialog();
            }

            Settings.Default.rptVFFooter = txtFooter.Text;
            Settings.Default.Save();
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
