using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Futronic.MfAPIHelper;
using System.Threading;
using FASClient.Forms;
using System.IO;

namespace FASClient
{
    public partial class frmPhotoPath : Form
    {
        string path = Application.StartupPath + "\\PhotoPath.txt";
        string picFolderPath = "";

        public frmPhotoPath()
        {
            InitializeComponent();
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
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPath.Text))
            {
                frmMessageBox message = new frmMessageBox(MessageBoxType.Alert, "Please select valid Path...");
                message.ShowDialog();
            }
            else
            {
                File.WriteAllText(path, txtPath.Text);
                frmMessageBox message = new frmMessageBox(MessageBoxType.Confirm, "Path saved Successfully...");
                message.ShowDialog();

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPhotoPath_Load(object sender, EventArgs e)
        {
            picFolderPath = getFolderPath();
            txtPath.Text = picFolderPath;
        }
        public string getFolderPath()
        {
            string pathInsideFile = "";
            if (System.IO.File.Exists(path))
            {
                pathInsideFile = File.ReadAllText(path);
            }
            return pathInsideFile;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            picFolderPath = getFolderPath();
            txtPath.Text = picFolderPath;

            string picFile = picFolderPath + "\\" + "17-10322" + ".png";
            if (File.Exists(picFile))
                pictureBox1.Image = Image.FromFile(picFile);
            else
                pictureBox1.Image = null;
        }
    }
}
