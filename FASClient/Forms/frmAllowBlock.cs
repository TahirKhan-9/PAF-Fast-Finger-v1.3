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

namespace FASClient.Forms
{
    public partial class frmAllowBlock : Form
    {
        public string workingMode = "";
        DataTable imptData = new DataTable();
        DataTable blockedUser = new DataTable();
        string workmode = "";
        
        frmProgressDialog progress = new frmProgressDialog();
        DateTime dateStart = new DateTime();
        DateTime dateEnd = new DateTime();
        string reason = "";
        public OperationMode mode;
        bool isPermanent = false;

        public frmAllowBlock()
        {
            InitializeComponent();
        }

        private void frmAllowBlock_Load(object sender, EventArgs e)
        {
            cboMode.SelectedIndex = 2;
            this.Text = mode.ToString();

            //SetMode();
            setWorkingMode();
            rbFieldsCheckChange(null, null);
        }
        private void setWorkingMode()
        {
            if (rbStudent.Checked)
                workingMode = Constant.Student;
            else if (rbFaculty.Checked)
                workingMode = Constant.Faculty;
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

            //var tempList = Cache.employeeList.Where(x => x.Section == workingMode && x.Department == cboDept.SelectedText).ToList().Select(x => x.Code).ToList();
            //var tempList = (from emp in Cache.employeeList
            //                where emp.Section == workingMode && emp.Department == cboDept.SelectedText
            //                orderby emp.Code
            //                select emp.Code).Distinct().ToList();

            //List<String> srList = new List<String>();
            //srList.Add("All");

            //foreach (String code in tempList)
            //{
            //    string series = code.Split('-')[0];
            //    if (!srList.Contains(series))
            //        srList.Add(series);
            //}
            //srList.Sort();
            //cboSeries.DataSource = srList;
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
                           where emp.Code.Equals(txtCode.Text) && emp.Section.ToLower().Equals(workingMode.ToLower())
                           select emp).ToList();

                if (empList.Count >= 1)
                {
                    List<string> codes = new List<string>();
                    codes = empList.Select(x => x.Code).Distinct().ToList();

                    fillListV(codes);

                }
            }
            else
            {
                if (string.IsNullOrEmpty(cboDept.Text))
                {
                    new frmMessageBox(MessageBoxType.Alert, "Please Select Department/Program First.").ShowDialog();
                    txtCode.Focus();
                    return;
                }

                empList = (from emp in Cache.employeeList
                           where emp.Department.ToLower().Trim().Equals(cboDept.Text.ToLower().Trim()) && emp.Section.ToLower().Trim().Equals(workingMode.ToLower().Trim())
                           select emp).ToList();
                if (empList.Count >= 1)
                {
                    List<string> codes = new List<string>();
                    //if (!cboSeries.Text.Equals("All"))
                    //{
                        //codes = empList.Where(y => y.Code.StartsWith(cboSeries.Text)).Select(x => x.Code).Distinct().ToList();
                    //}
                    //else
                        codes = empList.Select(x => x.Code).Distinct().ToList();

                    fillListV(codes);

                }
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
                    
                    if (cboMode.SelectedIndex == 0)
                    {
                        if(!string.IsNullOrEmpty(emp.FingerID))
                            users.Add(new User(emp.FingerID));
                        if (!string.IsNullOrEmpty(emp.CardID))
                         users.Add(new User(emp.CardID));
                    }
                    else if (cboMode.SelectedIndex == 1)
                    {
                        if (!string.IsNullOrEmpty(emp.FingerID))
                        users.Add(new User(emp.FingerID));
                    }
                    else if (cboMode.SelectedIndex == 2)
                    {
                        if (!string.IsNullOrEmpty(emp.CardID))
                        users.Add(new User(emp.CardID));
                    }

                    foreach (var user in users)
                    {
                        bool exist = false;
                        ListViewItem item = new ListViewItem((lvUsers.Items.Count + 1).ToString());

                        if (!string.IsNullOrEmpty(user.UID))
                        {
                            item.SubItems.Add(user.UID);
                            item.Tag = user.UID;
                            item.SubItems.Add(emp.Code);
                            item.SubItems.Add(emp.Name);
                            item.SubItems.Add(emp.Designation);
                            item.SubItems.Add(emp.Department);
                        }
                        
                        foreach (ListViewItem lvi in lvUsers.Items)
                        {
                            if (item.Tag == null)
                            {
                                exist = true;
                                break;
                            }
                            else if (lvi.Tag.Equals(item.Tag.ToString()))
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
            
        }

        public void fillListB(Dictionary<string, string> emps)
        {
            foreach (KeyValuePair<string, string> keyValue in emps)
            {
                Employee emp = Cache.employeeList.Find(x => x.Code == keyValue.Value);
                if (emp != null)
                {

                    bool exist = false;
                    ListViewItem item = new ListViewItem((lvUsers.Items.Count + 1).ToString());

                    item.SubItems.Add(keyValue.Key);
                    item.Tag = keyValue.Key;
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
                Employee emp = Cache.employeeList.Find(x => x.Code.Trim() == txtCode.Text.Trim() && x.Section.Trim() == workingMode.Trim());
                //Employee emp = (from a in Cache.employeeList
                //                where a.Code == txtCode.Text && a.Section == workingMode
                //                select a).FirstOrDefault();

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
            //cboSeries.Enabled = rbDept.Checked;
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
            if (lvUsers.Items.Count == 0)
                return;

            Dictionary<string, int> resultset = new Dictionary<string, int>();
            List<string> userslist = new List<string>();

            if (lvUsers.Items.Count > 0)
            {
                
                dateStart = dtStart.Value;
               
                dateEnd = dtEnd.Value;

                if (!chkPermanent.Checked)
                    if (dateEnd < dateStart)
                    {
                        Globals.ShowMessage("End Date Should be greater than Start Date");
                        return;
                    }

                reason = txtReason.Text;
                workmode = "block";

                foreach (ListViewItem item in lvUsers.Items)
                {

                    String Code = item.SubItems[2].Text;
                    String UID = "";
                    if (item.Tag != null)
                        UID = item.Tag.ToString();

                    //Employee emp = Cache.employeeList.Find(x => x.Code == Code);
                    userslist.Add(UID);
                }

                progress.Show();

                myWorker.RunWorkerAsync(userslist);
            }
            else
                Globals.ShowMessage("Please add User to Block");
        }

        private void btnShowBlockedUsers_Click(object sender, EventArgs e)
        {
            lvUsers.Items.Clear();
            string query = "select distinct * from [BlockedUser] where EndDate > '{0}' order by empID";
            query = string.Format(query,DateTime.Now.ToString("dd-MMM-yyyy"));
            blockedUser = new DataTable();
            blockedUser = SqlHelper.ExecuteDataset(Globals.GetConnectionString(), CommandType.Text, query).Tables[0];

            Dictionary<string,string> codes = new Dictionary<string,string>();
            foreach (DataRow row in blockedUser.Rows)
            {
                string code = row[2].ToString();
                string uid = row[1].ToString();
                codes.Add(uid,code);
            }
            fillListB(codes);
            //if (lvUsers.Items.Count > 0)
            //{
            //    btnBlock.Enabled = false;
            //}
        }

        private void btnAllow_Click(object sender, EventArgs e)
        {
            List<string> userslist = new List<string>();

            if (lvUsers.Items.Count == 0)
                return;

            

            foreach (ListViewItem item in lvUsers.Items)
            {
                string code = item.SubItems[1].Text;
                if (!string.IsNullOrEmpty(code))
                    userslist.Add(code);
            }

            workmode = "allow";
            progress.Show();

            myWorker.RunWorkerAsync(userslist);

                        

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
            if (workmode.Contains("block"))
            {
                e.Result = FASHelper.BlockUsers(userslist);
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

                                String query = "insert into BlockedUser (UID,empid,Permanent,FromDate,EndDate,Reason) values('{0}','{1}',{2},'{3}','{4}','{5}')";
                                if (!isPermanent)
                                    query = string.Format(query, pair.Key, emp.Code, Convert.ToInt32(isPermanent), dateStart.ToString("dd-MMM-yyyy"), dateEnd.ToString("dd-MMM-yyyy"), reason);
                                else
                                {
                                    query = "insert into BlockedUser (UID,empid,Permanent,Reason) values('{0}','{1}',{2},'{3}')";
                                    query = string.Format(query, pair.Key, emp.Code, Convert.ToInt32(isPermanent),reason);
                                }

                                int result = SqlHelper.ExecuteNonQuery(Globals.GetConnectionString(), CommandType.Text, query);

                                emp.Suspend = true;
                                emp.Update(false);
                            }
                        }
                    }
                }
            }

            if (workmode.Contains("allow"))
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
                                string query = "delete from BlockedUser where UID in ('{0}')";
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
            frmResult result = new frmResult();
            result.resultset = resultset;
            result.ShowDialog();

            


        }

        private void lvUsers_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (lvUsers.SelectedItems.Count == 0)
                return;


            ListViewItem item = lvUsers.SelectedItems[0];
            string UID = item.SubItems[1].Text;
            string query = "select distinct * from [BlockedUser] where EndDate > '{0}' and UID = '{1}' order by empID";

            query = string.Format(query, DateTime.Now.ToString("dd-MMM-yyyy"),UID);

            DataTable User = new DataTable();
            User = SqlHelper.ExecuteDataset(Globals.GetConnectionString(), CommandType.Text, query).Tables[0];
            if (User.Rows.Count == 0)
                return;
            DataRow row = User.Rows[0];

            string reason = row[5].ToString();

            txtReason.Text = reason;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void chkPermanent_CheckedChanged(object sender, EventArgs e)
        {
            dtEnd.Enabled = !chkPermanent.Checked;
            dtStart.Enabled = !chkPermanent.Checked;

            isPermanent = chkPermanent.Checked;
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}
