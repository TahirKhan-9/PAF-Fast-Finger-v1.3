using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.ApplicationBlocks.Data;

namespace FASClient.Forms
{
    public partial class frmUserMaster : Form
    {
        Dictionary<string, string> colsToShow = new Dictionary<string, string>();
        string workmode = "";
        string facid = "0";
        frmProgressDialog progress = new frmProgressDialog();
    
        public frmUserMaster()
        {
            InitializeComponent();
            colsToShow.Add("Code","Code");
            colsToShow.Add("Name","Name");
            //colsToShow.Add("NIC","NIC");
            //colsToShow.Add("FatherName","Father Name");
            colsToShow.Add("Designation","Designation");
            //colsToShow.Add("Address","Home Address");
            colsToShow.Add("Email","Email Address");
            //colsToShow.Add("ContactNo","Contact #");
            //colsToShow.Add("Suspend","Suspended");
           
        }

        void FillSections()
        {
            TreeNode coyNode = new TreeNode();
            // get organization name
            Company c = new Company().Get();
            if (c != null)
                tvSections.Nodes.Add(c.Name);
            else
                tvSections.Nodes.Add("Organization");

            List<string> seclist = Cache.employeeList.Select(x => x.Section.Trim()).Distinct().ToList();
            seclist.Sort();

            foreach (string section in seclist)
            {
                if (Cache.employeeList.Count(x => x.Section == section) >= 1)
                {
                    List<string> depts = Cache.employeeList.FindAll(x => x.Section == section).Select(y => y.Department).Distinct().ToList();
                    depts.Sort();

                    TreeNode[] nodes = new TreeNode[depts.Count];
                    for (int i = 0; i <= depts.Count - 1; i++)
                    {
                        nodes[i] = new TreeNode(depts[i]);
                    }
                    TreeNode node = new TreeNode(section, nodes);
                    tvSections.Nodes[0].Nodes.Add(node);
                }
                else
                {
                    TreeNode node = new TreeNode(section);
                    tvSections.Nodes[0].Nodes.Add(node);
                }
            }

            if (tvSections.Nodes.Count >= 1)
            {
               tvSections.SelectedNode = tvSections.Nodes[0];
               tvSections_AfterSelect(null, null);
            }
        }

        private void frmUsersMaster_Load(object sender, EventArgs e)
        {
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            lblActiveUsers.Text = "";
            //this.Text = Globals.AppName + " v" + Application.ProductVersion;
            foreach(KeyValuePair<string,string> pair in colsToShow)
                cboFields.Items.Add(pair.Value);

            FillSections();
            if (tvSections.Nodes.Count >= 1)
                tvSections.SelectedNode = tvSections.Nodes[0];

            lblActiveUsers.Text = string.Format("({0}) Total Users", Cache.employeeList.Count.ToString());

            this.WindowState = FormWindowState.Maximized;

           
        }

        private void tsClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsFingerRegistration_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count <= 0)
                return;

            string id = dgvUsers.SelectedRows[0].Cells[0].Value.ToString();
            Employee emp = Cache.employeeList.Find(x => x.Code == id);
            
            if (emp != null)
                return;

            frmFingerRegistration f = new frmFingerRegistration();
            f.emp = emp;
            f.ShowDialog();            

        }

        void SetDataSource(List<Employee> users)
        {
            dgvUsers.DataSource = null;
            dgvUsers.DataSource = users;            

            string section = "";
            string dept = "";

            foreach(DataGridViewColumn col in dgvUsers.Columns)
            {
                col.Name = col.HeaderText;
                string val = "";
                colsToShow.TryGetValue(col.Name, out val);
                col.HeaderText = val;
                if (!colsToShow.ContainsKey(col.Name))
                    col.Visible = false;
            }

            dgvUsers.Columns["Code"].Width = 100;            // code column
            dgvUsers.Columns["Name"].Width = 200;            // name column
            dgvUsers.Columns["FatherName"].Width = 150;            // father name column
            dgvUsers.Columns["NIC"].Width = 100;            // nic column
            dgvUsers.Columns["Designation"].Width = 150;            // designation column
            dgvUsers.Columns["ContactNo"].Width = 100;            // contact no column
            //dgvUsers.Columns["Validity"].Width = 120;            // validity column
            dgvUsers.Columns["Address"].Width = 300;            // address column
            dgvUsers.Columns["Email"].Width = 200;            // email column

            foreach (DataGridViewRow row in dgvUsers.Rows)
            {
                Employee emp = (Employee)row.DataBoundItem;
                //User u = Cache.userList.Find(x => x.UID == emp.FingerID);
                if (emp != null)
                {
                    if (emp.Suspend)
                        row.DefaultCellStyle.BackColor = Color.LightPink;
                }
            }

            TreeNode node = tvSections.SelectedNode;
            if (node.Parent != null)
            {
                section = node.Parent.Text;
                dept = node.Text;
            }
            else
                section = node.Text;

            //calculate totals
            int totalUsers = users.Count();
            int fingerUsers = users.Count(x => x.FingerID != null);
            int cardUsers = users.Count(x => x.CardID != null);

            //int totalFingers = 0;
            //if (string.IsNullOrEmpty(dept))
            //{
            //    totalFingers = Cache.userList.Count(x => x.Finger1 != null && x.UType == (int)UserType.Finger && x.Section == section);
            //    totalFingers += Cache.userList.Count(x => x.Finger2 != null && x.UType == (int)UserType.Finger && x.Section == section);
            //    totalFingers += Cache.userList.Count(x => x.Finger3 != null && x.UType == (int)UserType.Finger && x.Section == section);
            //}
            //else
            //{
            //    totalFingers = Cache.userList.Count(x => x.Finger1 != null && x.UType == (int)UserType.Finger && x.Section == section && x.Department == dept);
            //    totalFingers = Cache.userList.Count(x => x.Finger2 != null && x.UType == (int)UserType.Finger && x.Section == section && x.Department == dept);
            //    totalFingers = Cache.userList.Count(x => x.Finger3 != null && x.UType == (int)UserType.Finger && x.Section == section && x.Department == dept);
            //}


            //int totalCards = 0;
            //if (string.IsNullOrEmpty(dept))
            //    totalCards = Cache.userList.Count(x => x.Finger1 != null && x.UType == (int)UserType.Card && x.Section == section);
            //else
            //    totalCards = Cache.userList.Count(x => x.Finger1 != null && x.UType == (int)UserType.Card && x.Section == section && x.Department == dept);


            //lblActiveUsers.Text = "(" + totalUsers.ToString() + ") Total Users";
        }

        private void tvSections_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = tvSections.SelectedNode;
            if (node.Parent == null)
            {
                // company wise
                string section = node.Text;
                SetDataSource(Cache.employeeList);
            }
            else
            {
                if (node.Nodes.Count >= 1)
                {
                    // section wise
                    string section = node.Text;
                    List<Employee> empList = Cache.employeeList.FindAll(x => x.Section == section);
                    SetDataSource(empList);
                }
                else
                {
                    // section and department wise
                    string section = node.Parent.Text;
                    string dept = node.Text;
                    List<Employee> empList = Cache.employeeList.FindAll(x => x.Section == section && x.Department == dept);
                    SetDataSource(empList);
                }
            }
            
            

        }

        private void tsSearch_Click(object sender, EventArgs e)
        {
            
        }

        private void txtKeyword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                tsSearch_Click(null, null);
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmUserInfo f = new frmUserInfo();
            f.editMode = false;
            f.ShowDialog();
            // refresh grid view
            SetDataSource(Cache.employeeList);

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count <= 0)
                return;

            string id = dgvUsers.SelectedRows[0].Cells["Code"].Value.ToString();

            frmUserInfo f = new frmUserInfo();
            f.editMode = true;
            f.employee = Cache.employeeList.Find(x => x.Code == id);
            f.ShowDialog();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count <= 0)
                return;

            //DialogResult r = new frmMessageBox(MessageBoxType.Confirm, "Sure to Remove this User?").ShowDialog();
            frmMessageBox r = new frmMessageBox(MessageBoxType.Confirm, "Sure to Remove this User?");
            r.ShowDialog();

            if (r.result == System.Windows.Forms.DialogResult.Yes)
            {
                string id = dgvUsers.SelectedRows[0].Cells["Code"].Value.ToString();
                string name = dgvUsers.SelectedRows[0].Cells["Name"].Value.ToString();
                List<Employee> emp1 = Cache.employeeList.Where(x => x.Code == id && x.Name == name).ToList();
                Employee emp = emp1.FirstOrDefault();
                if (emp == null)
                    return;

                byte idFac = byte.Parse("0");
                int fingerStatus = ExtendApi.FasDeleteUser(true, idFac, emp.FingerID, false);
                int cardStatus = ExtendApi.FasDeleteUser(true, idFac, emp.CardID, false);

                if (fingerStatus == 2007 || fingerStatus == 0 || cardStatus == 2007 || cardStatus == 0)
                {
                    if (emp.Delete())
                    {
                        Globals.ShowMessage("User Deleted Successfully.\n Fingerprint Return Code " + fingerStatus.ToString() + "\nCard Return Code " + cardStatus.ToString());
                    }
                }
                else
                {
                    if (fingerStatus == 2003 || cardStatus == 2003)
                        if (!emp.UserExist())
                            if (emp.Delete())
                            {
                                Globals.ShowMessage("User Deleted Successfully.\nFinger not registered.\nCard not registered");
                                return;
                            }
                    Globals.ShowMessage("User Deletion Failed.\n Fingerprint Return Code " + fingerStatus.ToString() + "\nCard Return Code " + cardStatus.ToString());
                }

                //if (string.IsNullOrEmpty(emp.FingerID) && string.IsNullOrEmpty(emp.CardID))
                //{
                //    r = new frmMessageBox(MessageBoxType.Confirm, "No Machine Record Found.\nDo you want to remove the USER also?");
                //    r.ShowDialog();
                //    if (r.result == DialogResult.Yes)
                //    {
                //        // delete user from employee

                //        if (emp.Delete())
                //        {
                //            r = new frmMessageBox(MessageBoxType.Info, "USER Deleted Successfully..");
                //            r.ShowDialog();
                //        }
                //    }
                //}
                //else {
                //    frmFingerCardOperation f = new frmFingerCardOperation();
                //    f.emp = emp;
                //    f.workMode = "delete";
                //    f.ShowDialog();
                //}


            }
        }

        private void btnRegisterFinger_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count <= 0)
                return;

            if (dgvUsers.SelectedRows.Count> 1)
            {
                Globals.ShowAlert("Please Select One Employee Only.");
                return;
            }

            string id = dgvUsers.SelectedRows[0].Cells["Code"].Value.ToString();
            Employee emp = Cache.employeeList.Find(x => x.Code == id);

            if (emp == null)
                return;

            frmFingerRegistration f = new frmFingerRegistration();
            f.emp = emp;
            f.ShowDialog();
        }

        private void btnRegisterCard_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count <= 0)
                return;

            if (dgvUsers.SelectedRows.Count > 1)
            {
                Globals.ShowAlert("Please Select One Employee Only.");
                return;
            }

            string id = dgvUsers.SelectedRows[0].Cells["Code"].Value.ToString();
            Employee emp = Cache.employeeList.Find(x => x.Code == id);
            if (emp == null)
                return;

            if (btnRegisterCard.Text.Contains("Change"))
            {
                if (Globals.ConfirmAction("Sure to Change Existing Card Information of the Selected User?") == DialogResult.No)
                    return;
            }

            FrmcardUtility c = new FrmcardUtility();
            c.emp = emp;
            c.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtKeyword.Text))
            {
                MessageBox.Show("Please Enter Keyword to Search", "DDS FAS Client v2");
                txtKeyword.Focus();
                return;
            }

            if (string.IsNullOrEmpty(cboFields.Text))
                return;

            List<Employee> list = new List<Employee>();

            if (cboFields.Text.ToLower().Equals("code"))
                list = Cache.employeeList.FindAll(x => x.Code == txtKeyword.Text);

            if (cboFields.Text.ToLower().Equals("name"))
                list = Cache.employeeList.FindAll(x => x.Name.ToLower().Contains(txtKeyword.Text.ToLower()));

            if (cboFields.Text.ToLower().Equals("fathername"))
                list = Cache.employeeList.FindAll(x => x.FatherName.ToLower().Contains(txtKeyword.Text.ToLower()));

            if (cboFields.Text.ToLower().Equals("designation"))
                list = Cache.employeeList.FindAll(x => x.Designation != null && x.Designation.ToLower().Contains(txtKeyword.Text.ToLower()));

            if (cboFields.Text.ToLower().Equals("nic"))
                list = Cache.employeeList.FindAll(x => x.NIC.ToLower().Contains(txtKeyword.Text.ToLower()));

            if (cboFields.Text.ToLower().Equals("contactno"))
                list = Cache.employeeList.FindAll(x => x.ContactNo.ToLower().Contains(txtKeyword.Text.ToLower()));


            SetDataSource(list);
        }

        private void btnSendToMachine_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
                return;

            Dictionary<string, int> resultset = new Dictionary<string, int>();
            List<string> userslist = new List<string>();
            workmode = "Send Users";

            frmFingerCardOperation f = new frmFingerCardOperation();
            f.workMode = workmode;
            f.ShowDialog();
            facid = f.facID.ToString();

            if (f.isCancelled)
            {
                new frmMessageBox(MessageBoxType.Info, "Cancelled By User").ShowDialog();
                return;
            }

            foreach (DataGridViewRow row in dgvUsers.SelectedRows)
            {
                string id = row.Cells["Code"].Value.ToString();
                Employee emp = Cache.employeeList.Find(x => x.Code == id);
                if (f.fingerSelected)
                {
                    User user = new User(emp.FingerID);
                    if (!user.Suspend)
                        if (!(string.IsNullOrEmpty(user.Finger1) && string.IsNullOrEmpty(user.Finger2) && string.IsNullOrEmpty(user.Finger3)))
                            userslist.Add(emp.FingerID);
                }
                if (f.cardSelected) {
                    User user = new User(emp.CardID);
                    if (!user.Suspend)
                        if (!(string.IsNullOrEmpty(user.Finger1) && string.IsNullOrEmpty(user.Finger2) && string.IsNullOrEmpty(user.Finger3)))
                            userslist.Add(emp.CardID);
                }
            }

            

            myWorker.RunWorkerAsync(userslist);
            progress.ShowDialog();
        }

        private void btnSuspendUsers_Click(object sender, EventArgs e)
        {
            string id = dgvUsers.SelectedRows[0].Cells["Code"].Value.ToString();
            Employee emp = Cache.employeeList.Find(x => x.Code == id);

            if (btnSuspendUsers.Text.Contains("Activate"))
            {
                int fingerStatus = -1;
                int cardStatus = -1;
                // resume user                
                if (emp.FingerID != null) { fingerStatus = FASHelper.ResumeUser(emp.FingerID); }
                if (emp.CardID != null) { cardStatus = FASHelper.ResumeUser(emp.CardID); }

                if (fingerStatus == 2007 || fingerStatus == 0 || cardStatus == 2007 || cardStatus == 0)
                {
                    // update employee table
                    emp.Suspend = false;
                    if (emp.Update(false))
                    {
                        Globals.ShowMessage("User Activated Successfully ...");
                        dgvUsers.SelectedRows[0].DefaultCellStyle.BackColor = Color.White;
                    }
                }

                Globals.ShowMessage("Fingerprint Activated With Return Code : " + fingerStatus.ToString() + "\nCard Activated With Return Code : " + cardStatus.ToString());

            }
            else
            {
                // suspend user
                int fingerStatus = -1;
                int cardStatus = -1;             
                if (emp.FingerID != null) { fingerStatus = FASHelper.SuspendUser(emp.FingerID); }
                if (emp.CardID != null) { cardStatus = FASHelper.SuspendUser(emp.CardID); }

                if (fingerStatus == 2007 || fingerStatus == 0 || cardStatus == 2007 || cardStatus == 0)
                {
                    // update employee table
                    emp.Suspend = true;
                    if (emp.Update(false))
                    {

                        dgvUsers.SelectedRows[0].DefaultCellStyle.BackColor = Color.LightPink;
                    }
                }

                Globals.ShowMessage("Fingerprint Suspended With Return Code : " + fingerStatus.ToString() + "\nCard Suspended With Return Code : " + cardStatus.ToString());
            }

        }

        private void btnBlockUsers_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
                return;

            Dictionary<string, int> resultset = new Dictionary<string, int>();
            List<string> userslist = new List<string>();
            workmode = btnBlockUsers.Text.Contains("Block") ? "Block" : "Allow";

            frmFingerCardOperation f = new frmFingerCardOperation();
            f.workMode = workmode;
            f.ShowDialog();

            if (f.isCancelled)
            {
                new frmMessageBox(MessageBoxType.Info, "Cancelled By User").ShowDialog();
                return;
            }
            
            foreach(DataGridViewRow row in dgvUsers.SelectedRows)
            {
                string id = row.Cells["Code"].Value.ToString();
                Employee emp = Cache.employeeList.Find(x => x.Code == id);
                if (f.fingerSelected) { userslist.Add(emp.FingerID); }
                if (f.cardSelected) { userslist.Add(emp.CardID); }
            }

            myWorker.RunWorkerAsync(userslist);
            progress.ShowDialog();
        }

        private void dgvUsers_Click(object sender, EventArgs e)
        {
            if (dgvUsers.RowCount < 1)
                return;
            string id = dgvUsers.SelectedRows[0].Cells["Code"].Value.ToString();
            Employee emp = Cache.employeeList.Find(x => x.Code == id);
            if (emp == null)
                return;
            if (!string.IsNullOrEmpty(emp.CardID))
                btnRegisterCard.Text = "Change Card";
            else
                btnRegisterCard.Text = "Register Card";

            if (emp.Suspend)
            {
                btnSuspendUsers.Text = "Activate User(s)";
                btnRegisterCard.Enabled = false;
                btnRegisterFinger.Enabled = false;

                btnBlockUsers.Text = "Allow User(s)";
            }
            else
            {
                btnSuspendUsers.Text = "Suspend User(s)";
                btnRegisterCard.Enabled = true;
                btnRegisterFinger.Enabled = true;

                btnBlockUsers.Text = "Block User(s)";
            }

            
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            AssignTimeSlot a = new AssignTimeSlot();
            a.Show();
            //frmPhotoPath p = new frmPhotoPath();
            //p.ShowDialog();
        }

        private void dgvUsers_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            DataGridViewRow row = dgvUsers.SelectedRows[e.RowIndex];

            if (row.Cells[e.ColumnIndex].Value.ToString() == "true")
            {

            }
        }

        private void myWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            List<string> userslist = e.Argument as List<string>;
            if (workmode.Contains("Block"))
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
                                emp.Suspend = true;
                                emp.Update(false);
                            }
                        }
                    }
                }
            }

            if (workmode.Contains("Allow"))
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
                                emp.Suspend = false;
                                emp.Update(false);
                            }
                        }
                    }
                }
            }

            if (workmode.Contains("Send"))
                e.Result = FASHelper.SendUsersToFAC(facid, userslist);

            
            

        }

        private void myWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progress.Close();
            Dictionary<string, int> resultset = e.Result as Dictionary<string, int>;
            frmResult result = new frmResult();
            result.resultset = resultset;
            result.ShowDialog();

            if (workmode.Contains("Allow") || workmode.Contains("Block"))
                SetDataSource(Cache.employeeList);
        }

        private void dgvUsers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsers.RowCount < 1 || dgvUsers.SelectedRows.Count == 0)
                return;


            string id = dgvUsers.SelectedRows[0].Cells["Code"].Value.ToString();
            Employee emp = Cache.employeeList.Find(x => x.Code == id);
            if (emp == null)
                return;

            if (!string.IsNullOrEmpty(emp.CardID))
            {
                btnRegisterCard.Enabled = false;
                User u = new User(emp.CardID);
                if (!string.IsNullOrEmpty(u.UID))
                    btnRegisterCard.Text = "Change Card";
                else
                    btnRegisterCard.Text = "Register Card";
            }
            else
            {
                btnRegisterCard.Text = "Register Card";
                btnRegisterCard.Enabled = false;
            }

            if (!string.IsNullOrEmpty(emp.FingerID))
            {
                btnRegisterFinger.Enabled = false;
                User u = new User(emp.FingerID);
                if (!string.IsNullOrEmpty(u.UID))
                    btnRegisterFinger.Text = "Manage Fingers";
                else
                    btnRegisterFinger.Text = "Register Fingers";
            }
            else
            {
                btnRegisterFinger.Text = "Manage Fingers";
                btnRegisterFinger.Enabled = false;
            }


            if (emp.Suspend)
            {
                btnSuspendUsers.Text = "Activate User(s)";
                btnRegisterCard.Enabled = false;
                btnRegisterFinger.Enabled = false;

                btnBlockUsers.Text = "Allow User(s)";
            }
            else
            {
                btnSuspendUsers.Text = "Suspend User(s)";
                btnRegisterCard.Enabled = true;
                btnRegisterFinger.Enabled = true;

                btnBlockUsers.Text = "Block User(s)";
            }
        }

        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtKeyword_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnSearch.PerformClick();
            }
        }

       
    }
}
