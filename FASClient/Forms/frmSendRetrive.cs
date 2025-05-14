using FASClient.Classes;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UsmanCodeBlocks.Data.Sql;

namespace FASClient.Forms
{
    public partial class frmSendRetrive : Form
    {
        public string workingMode = "";
        DataTable imptData = new DataTable();
        string workmode = "";
        frmProgressDialog progress = new frmProgressDialog();
        DateTime dateStart = new DateTime();
        DateTime dateEnd = new DateTime();
        string reason = "";
        public OperationMode mode;
        int deviceID = 0;


        public frmSendRetrive()
        {
            InitializeComponent();
        }

        private void frmSendRetrive_Load(object sender, EventArgs e)
        {
            cboMode.SelectedIndex = 0;
            
            this.Text = mode.ToString();
            cboDevice.DataSource = Cache.facList;
            cboDevice.DisplayMember = "Description";
            cboDevice.ValueMember = "FacID";

            //SetMode();
            setWorkingMode();
            rbFieldsCheckChange(null, null);
        }
        private void setWorkingMode()
        {
            if (rbStudent.Checked)
                workingMode = Constant.Student;
            else if (rbFaculty.Checked)
                workingMode = Constant.Staff;
            else if (rbResident.Checked)
                workingMode = Constant.Resident;
            else if (rbVisitor.Checked)
                workingMode = Constant.Visitor;

            // fill programs
            var dptList = (from emp in Cache.employeeList
                        where emp.Section == workingMode && emp.Department != null && emp.Department != ""
                        orderby emp.Department
                        select emp.Department).Distinct().ToList();

            //dptList.Add("All");
            dptList.Sort();
            cboDept.DataSource = dptList;

            fillSeries();

            ResetFields();
            
        }

        void fillSeries()
        {

            var tempList = (from emp in Cache.employeeList
                            where emp.Section == workingMode && emp.Department == cboDept.SelectedText
                            orderby emp.Code
                            select emp.Code).Distinct().ToList();

            var tempLis = (from emp in Cache.employeeList
                            where emp.Section == workingMode && emp.Department != null && emp.Department == cboDept.SelectedItem
                            orderby emp.Code
                            select emp.Code).Distinct().ToList();

            List<String> srList = new List<String>();
            srList.Add("All");

            foreach (String code in tempList)
            {
                string series = code.Split('-')[0];
                if (!srList.Contains(series))
                    srList.Add(series);
            }
            srList.Sort();
            cboSeries.DataSource = srList;


        }
        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            List<Employee> empList = new List<Employee>();

            if (rbCode.Checked)
            {
                if (string.IsNullOrEmpty(txtCode.Text))
                {
                    new frmMessageBox(MessageBoxType.Alert, "Please Enter Code/Roll# First.").ShowDialog();
                    txtCode.Focus();
                    return;
                }

                empList = (from emp in Cache.employeeList
                           where (emp.Code.Equals(txtCode.Text) && emp.Section.ToLower().Equals(workingMode.ToLower()) && emp.Suspend == false)
                           select emp).ToList();
            }
            else
            {
                if (string.IsNullOrEmpty(cboDept.Text))
                {
                    new frmMessageBox(MessageBoxType.Alert, "Please Select Department/Program First.").ShowDialog();
                    txtCode.Focus();
                    return;
                }

                if (cboDept.Text == "All")
                    empList = (from emp in Cache.employeeList
                               where emp.Section.ToLower().Equals(workingMode.ToLower()) && emp.Suspend == false
                               select emp).ToList();
                else
                        empList = (from emp in Cache.employeeList
                           where emp.Department.ToLower().Equals(cboDept.Text.ToLower()) && emp.Section.ToLower().Equals(workingMode.ToLower()) && emp.Suspend == false
                                   select emp).ToList();
            }

            if (empList.Count >= 1)
            {
                List<string> codes = new List<string>();
                if (!cboSeries.Text.Equals("All") && !rbCode.Checked)
                {
                    codes = empList.Where(y => y.Code.StartsWith(cboSeries.Text)).Select(x => x.Code).Distinct().ToList();
                }
                else
                    codes = empList.Select(x => x.Code).Distinct().ToList();

                fillListV(codes);
                //foreach(Employee emp in empList)
                //{
                //    bool exist = false;
                //    ListViewItem item = new ListViewItem((lvUsers.Items.Count + 1).ToString());
                //    item.Tag = emp.Code;
                //    item.SubItems.Add(emp.Code);
                //    item.SubItems.Add(emp.Name);
                //    item.SubItems.Add(emp.Designation);
                //    item.SubItems.Add(emp.Department);
                //    item.SubItems.Add(emp.FingerID);
                //    item.SubItems.Add(emp.CardID);
                //    foreach (ListViewItem lvi in lvUsers.Items)
                //    {
                //        if (lvi.Tag == item.Tag)
                //        {
                //            exist = true;
                //            break;
                //        }
                //    }
                           
                //    if(!exist)
                //        lvUsers.Items.Add(item);
                //}
            }
            else
            {
                Globals.ShowAlert("No User Found or the User is Suspended");
            }
        }

        public void fillListV(List<string> empCodes)
        {
            foreach (string code in empCodes)
            {
                Employee emp = Cache.employeeList.Find(x => x.Code == code);
                if (emp != null)
                {
                    List<User> users = new List<User>();
                    
                    if (cboMode.SelectedIndex == 0 || cboMode.SelectedIndex == 1) 
                    {
                        if (!string.IsNullOrEmpty(emp.FingerID))
                        {
                            User user = new User(emp.FingerID);
                            if (!user.Suspend)
                                if(!(string.IsNullOrEmpty(user.Finger1) && string.IsNullOrEmpty(user.Finger2)&& string.IsNullOrEmpty(user.Finger3)))
                                    users.Add(user);
                        }
                    }

                    if (cboMode.SelectedIndex == 0 || cboMode.SelectedIndex == 2)
                    {
                        if (!string.IsNullOrEmpty(emp.CardID))
                        {
                            User user = new User(emp.CardID);
                            if (!user.Suspend)
                                if(!string.IsNullOrEmpty(user.Finger1))
                                    users.Add(user);
                        }
                    }

                    foreach (var user in users)
                    {
                        bool exist = false;
                        ListViewItem item = new ListViewItem((lvUsers.Items.Count + 1).ToString());

                        if (user.UID == null)
                        {
                            item.SubItems.Add("");
                            item.Tag = "";
                        }
                        else
                        {
                            item.SubItems.Add(user.UID);
                            item.Tag = user.UID;
                        }
                        item.SubItems.Add(emp.Code);
                        item.SubItems.Add(emp.Name);
                        item.SubItems.Add(emp.Designation);
                        item.SubItems.Add(emp.Department);
                        
                        //item.SubItems.Add(emp.CardID);
                        foreach (ListViewItem lvi in lvUsers.Items)
                        {
                            if (lvi.Tag.Equals(item.Tag.ToString()))
                            {
                                exist = true;
                                break;
                            }
                        }


                        if (!exist)
                            lvUsers.Items.Add(item);

                        Application.DoEvents();
                    }
                }
            }
            
        }

        public void fillListB(Dictionary<string,string> emps)
        {
            foreach (KeyValuePair<string,string> keyValue in emps)
            {
                Employee emp = Cache.employeeList.Find(x => x.Code == keyValue.Key);
                if (emp != null)
                {
                   
                        bool exist = false;
                        ListViewItem item = new ListViewItem((lvUsers.Items.Count + 1).ToString());
                    
                        item.SubItems.Add(keyValue.Value);
                        item.Tag = keyValue.Value;
                        item.SubItems.Add(emp.Code);
                        item.SubItems.Add(emp.Name);
                        item.SubItems.Add(emp.Designation);
                        item.SubItems.Add(emp.Department);

                        //item.SubItems.Add(emp.CardID);
                        foreach (ListViewItem lvi in lvUsers.Items)
                        {
                            if (lvi.Tag.Equals(item.Tag.ToString()))
                            {
                                exist = true;
                                break;
                            }
                        }

                        if (!exist)
                            lvUsers.Items.Add(item);
                    
                }
            }

        }

        private void rbFilterCheckChange(object sender, EventArgs e)
        {
            setWorkingMode();
        }

        private void txtCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                ResetFields();
                Employee emp = Cache.employeeList.Find(x => x.Code == txtCode.Text && x.Section == workingMode);
                if (emp != null)
                    TextBoxFill(emp);
                else
                    Globals.ShowMessage("User Not Found.");
            }
        }

        public void ResetFields()
        {
            txtName.Text = "";
            txtDept.Text = "";
        }
        public void TextBoxFill(Employee emp)
        {
            txtName.Text = emp.Name;
            txtDept.Text = emp.Department;
        }

        private void rbFieldsCheckChange(object sender, EventArgs e)
        {
            cboDept.Enabled = rbDept.Checked;
            cboSeries.Enabled = rbDept.Checked;
            txtCode.Enabled = rbCode.Checked;
            lblBrowse.Enabled = rbFile.Checked;
            
            rbStudent.Enabled = !rbFile.Checked;
            rbFaculty.Enabled = !rbFile.Checked;
            rbVisitor.Enabled = !rbFile.Checked;
            rbResident.Enabled = !rbFile.Checked;
            btnAdd.Enabled = !rbFile.Checked;

            ResetFields();
        }

        private void lblBrowse_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtFile.Text = openFileDialog1.FileName;
                if (!string.IsNullOrEmpty(txtFile.Text))
                {
                    imptData = ExcelHelper.GetData(txtFile.Text, "1");
                    List<string> codes = new List<string>();
                    foreach (DataRow row in imptData.Rows)
                        codes.Add(row[0].ToString());

                    fillListV(codes);
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvUsers.SelectedItems)
                item.Remove();
        }

        private void btnBlock_Click(object sender, EventArgs e)
        {
            
            List<string> userslist = new List<string>();

            if (lvUsers.Items.Count == 0)
                return;



            foreach (ListViewItem item in lvUsers.SelectedItems)
            {
                string code = item.SubItems[1].Text;
                if (!string.IsNullOrEmpty(code))
                    userslist.Add(code);
            }

            workmode = "send";
            
            myWorker.RunWorkerAsync(userslist);
            progress.ShowDialog();
        }

        

       

        private void btnClear_Click(object sender, EventArgs e)
        {
            lvUsers.Items.Clear();
            btnBlock.Enabled = true;

        }

        private void cboDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillSeries();
            ResetFields();
        }

        private void myWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            List<string> userslist = e.Argument as List<string>;
            if (workmode.Contains("send"))
            {
                Dictionary<string, int> resultset = FASHelper.SendUsersToFAC(deviceID.ToString(),userslist);
                e.Result = resultset;
                if (resultset.Count >= 1)
                {
                    
                }
            }
            else if (workmode.Contains("retrive"))
            {
                e.Result = FASHelper.AllowUsers(userslist);
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
                                // remove from blockedusers
                                string query = "delete from BlockedUser where UID in ({0})";
                                query = string.Format(query, pair.Key);

                                int result = SqlHelper.ExecuteNonQuery(Globals.GetConnectionString(), CommandType.Text, query);

                                emp.Suspend = false;
                                emp.Update(false);
                            }
                        }
                    }
                }
            }
        }

        private void myWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progress.Hide();
            lvUsers.Items.Clear();
            Dictionary<string, int> resultset = e.Result as Dictionary<string, int>;

            Globals.ShowMessage(resultset.Count.ToString() + " Users Sent Successfully with following result");

            frmResult result = new frmResult();
            result.resultset = resultset;
            result.ShowDialog();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            List<string> userslist = new List<string>();

            if (lvUsers.Items.Count == 0)
                return;

            deviceID = Convert.ToInt32(cboDevice.SelectedValue);

            foreach (ListViewItem item in lvUsers.Items)
            {
                string code = item.SubItems[1].Text;
                if (!string.IsNullOrEmpty(code))
                    userslist.Add(code);
            }


            Globals.ShowMessage("You are Sending " + userslist.Count.ToString() + " Users to " + "(" + cboDevice.Text + ")");
            workmode = "send";
            

            myWorker.RunWorkerAsync(userslist);
            progress.ShowDialog();
        }

        private void btnRetrive_Click(object sender, EventArgs e)
        {
            

            
        }
    }
}
