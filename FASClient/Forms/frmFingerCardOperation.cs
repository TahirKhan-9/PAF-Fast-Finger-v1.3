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
    public partial class frmFingerCardOperation : Form
    {
        public string workMode = "";
        public Employee emp;
        User fingerUser;
        User cardUser;
        public bool fingerSelected = false;
        public bool cardSelected = false;
        public bool isCancelled = true;
        public int facID = 0;

        public frmFingerCardOperation()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmFingerCardOperation_Load(object sender, EventArgs e)
        {
            lblTitle.Text = string.Format(lblTitle.Text, workMode.ToUpper());
            chkFP.Checked = true;
            chkCard.Checked = true;

            List<FacDefinition> devices = Globals.ConvertDataTable<FacDefinition>(new FacDefinition().GetAll());
            cboDevices.DataSource = devices;
            cboDevices.DisplayMember = "FacIP";
            cboDevices.ValueMember = "FacID";

            if (cboDevices.Items.Count >= 1)
                cboDevices.SelectedIndex = 0;

            if (workMode.Contains("Send"))
                groupBox1.Visible = true;
            else
                groupBox1.Visible = false;

            //List<User> users = new List<User>();
            //if (emp.FingerID != null)
            //    fingerUser = new User(emp.FingerID);

            //if (emp.CardID != null)
            //    cardUser = new User(emp.CardID);

            //if (fingerUser != null || emp.FingerID != null)
            //    chkFP.Enabled = true;
            //else
            //    chkFP.Enabled = false;

            //if (cardUser != null || emp.CardID != null)
            //    chkCard.Enabled = true;
            //else
            //    chkCard.Enabled = false;


            //lblEmp.Text = string.Format("{0} - {1}", emp.Code, emp.Name);
        }

        private void btnProceed_Click(object sender, EventArgs e)
        {
            fingerSelected = chkFP.Checked;
            cardSelected = chkCard.Checked;
            isCancelled = false;
            facID = ((FacDefinition)cboDevices.SelectedItem).FacID;

            this.Close();
        }

    }
}
