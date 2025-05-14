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
    public partial class frmRestrictedMachines : Form
    {
        int a = 0;
        frmProgressDialog progress = new frmProgressDialog();
        Employee emp;
        List<CheckBox> checkBoxes = new List<CheckBox>();

        public frmRestrictedMachines()
        {
            InitializeComponent();
           // dynamicCheckBox();
        }
        public frmRestrictedMachines(Employee Emp)
        {
            InitializeComponent();
            emp = Emp;
           // dynamicCheckBox();
        }
        private void dynamicCheckBox()
        {
            List<string> machNames = Cache.RestrictedDevices.Select(o => o.Description).ToList();
           
            foreach (var item in machNames)
            {
                if (a < machNames.Count)
                {
                    if (!String.IsNullOrEmpty(machNames[a]))
                    {
                        CheckBox chk = new CheckBox();
                        chk.Name = "CheckBox" + a;
                        chk.Text = machNames[a];
                        chk.BackColor = Color.Transparent;
                        chk.AutoSize = true;
                        chk.Checked = true;
                        chk.Font = new Font(chk.Font.FontFamily, 12.5f);
                        tableLayoutPanel1.Controls.Add(chk);
                        checkBoxes.Add(chk);

                    }
                }
                a++;
            }
        }

        private void frmRestrictedMachines_Load(object sender, EventArgs e)
        {
            dynamicCheckBox();
        }

        private void myWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            {
                List<string> userslist = e.Argument as List<string>;
                //foreach (FacDefinition wdevice in Cache.RestrictedDevices)
                //{
                    foreach (CheckBox item in checkBoxes)
                    {
                        if (item.Checked)
                        {
                            FacDefinition device = Cache.RestrictedDevices.FirstOrDefault(x => x.Description == item.Text);
                            {
                                int shour = 1, sminute = 0, ehour = 23, eminute = 59, Smonth = 1, Sdate = 1, Emonth = 12, Edate = 31;
                                e.Result = FASHelper.DenialUsers(userslist, (byte)device.FacID, (byte)Smonth, (byte)Sdate, (byte)shour, (byte)sminute, (byte)Emonth, (byte)Edate, (byte)ehour, (byte)eminute, (byte)0);
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
                                            //Globals.ShowMessage("Template saved successfully ...");
                                            emp.Denial = true;
                                                //emp.Update(false);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                //}

            }
        }

        private void myWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progress.Hide();
            Dictionary<string, int> resultset = e.Result as Dictionary<string, int>;
            if (resultset != null)
            {
                frmResult result = new frmResult();
                result.resultset = resultset;
                result.ShowDialog();
                btnSave.Enabled = true;
            }
            else
            {
                frmMessageBox messageBox = new frmMessageBox(MessageBoxType.Confirm, "Are You sure You Don't Want any Restrictions For This User!!!");
                messageBox.ShowDialog();
                if(messageBox.result== DialogResult.Yes)
                {
                    this.Close();
                }
                else
                {
                    btnSave.Enabled = true;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            List<string> userslist = new List<string>();
            if (emp != null)
            {
                userslist.Add(emp.CardID);
                btnSave.Enabled = false;
                progress.Show();
                myWorker.RunWorkerAsync(userslist);
            }
            else
            {
                frmMessageBox frmMessageBox = new frmMessageBox(MessageBoxType.Alert, "Details Not Found!!!");
                frmMessageBox.ShowDialog();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
