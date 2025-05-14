using Microsoft.ApplicationBlocks.Data;
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
    public partial class frmVisDenial : Form
    {
        frmProgressDialog progress = new frmProgressDialog();

        public frmVisDenial()
        {
            InitializeComponent();
        }

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                ResetFields();
                Employee emp = Cache.employeeList.Find(x => x.Code.Trim() == txtCode.Text.Trim() );
                //Employee emp = (from a in Cache.employeeList
                //                where a.Code == txtCode.Text && a.Section == workingMode
                //                select a).FirstOrDefault();

                if (emp != null)
                    TextBoxFill(emp);
                else
                    Globals.ShowMessage("User Not Found.");
            }
        }

        private void TextBoxFill(Employee emp)
        {
            txtCode.Text = emp.CardID;
            txtName.Text = emp.Name;
            txtDept.Text = emp.Department;
        }

        private void ResetFields()
        {

            txtName.Text = "";
            txtDept.Text = "";
        }

        private void rbEMP_CheckedChanged(object sender, EventArgs e)
        {
            cboDepartment.Enabled = rbUnit.Checked;
            txtCode.Enabled = rbEMP.Checked;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            List<string> userslist = new List<string>();
            String UID = "";
            if (txtCode != null)
                UID = txtCode.Text.ToString();

            //Employee emp = Cache.employeeList.Find(x => x.Code == Code);
            userslist.Add(UID);
            btnSave.Enabled = false;
            progress.Show();
            myWorker.RunWorkerAsync(userslist);
        }

        private void myWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            List<string> userslist = e.Argument as List<string>;
            foreach (FacDefinition device in Cache.facList)
            {
                {
                    int shour = 0, sminute = 0, ehour = 23, eminute = 59, Smonth = 0, Sdate = 0, Emonth = 0, Edate = 0;
                    for (int weekday = 1; weekday <= 7; weekday++)
                    {
                        e.Result = FASHelper.Denialvis(userslist, (byte)device.FacID, (byte)Smonth, (byte)Sdate, (byte)shour, (byte)sminute, (byte)Emonth, (byte)Edate, (byte)ehour, (byte)eminute, (byte)weekday);
                        
                    }


                    Dictionary<string, int> resultset = e.Result as Dictionary<string, int>;
                    if (resultset.Count >= 1)
                    {
                        foreach (KeyValuePair<string, int> pair in resultset)
                        {
                            Employee emp = Cache.employeeList.Find(x => x.FingerID == pair.Key || x.CardID == pair.Key);
                            if (emp != null)
                            {
                                if (pair.Value == 2007 || pair.Value == 0)
                                {
                                   emp.Denial = true;
                                    //emp.Update(false);
                                }
                            }
                        }
                    }
                }
            }
           
        }

        

        private void myWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progress.Hide();
            Dictionary<string, int> resultset = e.Result as Dictionary<string, int>;
            frmResult result = new frmResult();
            result.resultset = resultset;
            result.ShowDialog();
            btnSave.Enabled = true;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
