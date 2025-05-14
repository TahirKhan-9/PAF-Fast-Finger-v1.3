using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FASClient.Forms;

namespace FASClient
{
    public partial class frmCompany : Form
    {
        string logoPath = "";
        public frmCompany()
        {
            
            InitializeComponent();
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCompany_Load(object sender, EventArgs e)
        {
            Company c = new Company().Get();
            if (c != null)
            {
                txtID.Text = c.ID.ToString();
                txtAddress.Text = c.Address;
                txtCity.Text = c.City;
                txtName.Text = c.Name;
                txtPhone.Text = c.Phone;
                txtState.Text = c.State;
                logoPath = c.ImagePath;
                if (!string.IsNullOrEmpty(logoPath))
                    pictureBox1.Image = new Bitmap(logoPath);
            }
        }

        void clear()
        {
            txtID.Text = "";
            txtAddress.Text = "";
            txtCity.Text = "";
            txtName.Text = "";
            txtPhone.Text = "";
            txtState.Text = "";
            pictureBox1.Image = null;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Company c = new Company();
            c.Address = txtAddress.Text;
            c.City = txtCity.Text;
            c.Name = txtName.Text;
            c.Phone = txtPhone.Text;
            c.State = txtState.Text;
            c.ImagePath = logoPath;
            if (!string.IsNullOrEmpty(txtID.Text))
                c.ID = Convert.ToInt32(txtID.Text);

            //c.Delete();
            if (c.Save())
            {
                frmMessageBox msgbox = new frmMessageBox(MessageBoxType.Info, "Organization Information Saved Successfully ...");
                msgbox.ShowDialog();
            }

            

            //MessageBox.Show("Saved Successfully");
            //clear();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Open Image";
            dlg.Filter = "PNG files (*.png)|*.png";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(dlg.FileName);
                logoPath = dlg.FileName;
            }
            dlg.Dispose();
        }
    }
}
