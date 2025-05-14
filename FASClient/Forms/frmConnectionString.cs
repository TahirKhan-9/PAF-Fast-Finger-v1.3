using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FASClient.Forms
{
    public partial class frmConnectionString : Form
    {
        public frmConnectionString()
        {
            InitializeComponent();
        }

        private void frmConnectionString_Load(object sender, EventArgs e)
        {
            string connString = Globals.GetConnectionString();
            if (!string.IsNullOrEmpty(connString))
            {
                string[] data = connString.Split(';');
                if (data.Length >= 1)
                {
                    string serverString = data[0];
                    string[] a = serverString.Split('=');
                    txtServer.Text = a[1];

                    string dbString = data[1];
                    string[] b = dbString.Split('=');
                    cboDatabase.Text = b[1];
                }

                if (data.Length >= 3)
                {
                    string authentication = data[2];
                    if (authentication.Contains("Trusted_Connection"))
                        chkSQLAuthentication.Checked = false;
                    else
                    {
                        chkSQLAuthentication.Checked = true;
                        string[] userString = authentication.Split('=');
                        txtUserId.Text = userString[1];

                        string[] passData = data[4].Split('=');
                        txtPassword.Text = passData[1];
                    }
                }

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //this.Close();
            Application.Exit();
        }
    }
}
