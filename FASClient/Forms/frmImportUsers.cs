using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.ApplicationBlocks.Data;

namespace FASClient
{
    public partial class frmImportUsers : Form
    {
        string category = "";
        List<Employee> empList = new List<Employee>();
        public frmImportUsers()
        {
            InitializeComponent();
        }

        private void btnBrows_Click(object sender, EventArgs e)
        {
            
            fileDialog.FileName = string.Empty;
            fileDialog.Filter = "Excel 2003 Files (*.xls) | *.xls|Excel 2007 Files (*.xlsx) | *.xlsx";
            fileDialog.InitialDirectory = Application.StartupPath;
            fileDialog.ShowDialog();
            if (!string.IsNullOrEmpty(fileDialog.FileName))
            {
                txtFile.Text = fileDialog.FileName;
                DataTable dt = new DataTable();
                dt = ExcelHelper.GetData(txtFile.Text, "1");
                if (dt.Rows.Count >= 1)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        int i = 1;
                        ListViewItem item = new ListViewItem((lvData.Items.Count + 1).ToString());
                        if(!string.IsNullOrEmpty(row[1].ToString()))
                            i++;
                        if (!string.IsNullOrEmpty(row[2].ToString()))
                            i++;
                        if (!string.IsNullOrEmpty(row[3].ToString()))
                            i++;
                        if (!string.IsNullOrEmpty(row[4].ToString()))
                            i++;
                        if (!string.IsNullOrEmpty(row[5].ToString()))
                            i++;
                        if (!string.IsNullOrEmpty(row[6].ToString()))
                            i++;
                        if (!string.IsNullOrEmpty(row[7].ToString()))
                            i++;
                        if (!string.IsNullOrEmpty(row[8].ToString()))
                            i++;
                        if (!string.IsNullOrEmpty(row[9].ToString()))
                            i++;
                        item.SubItems.Add(row[1].ToString());   //  id/rollno
                        item.SubItems.Add(row[2].ToString());   //  name
                        item.SubItems.Add(row[3].ToString());   //  father name
                        item.SubItems.Add(row[4].ToString());   //  cnic
                        item.SubItems.Add(row[5].ToString());   //  class/department/house/residence area
                        item.SubItems.Add(row[6].ToString());   //  Address
                        item.SubItems.Add(row[7].ToString());   //  Validity
                        item.SubItems.Add(row[8].ToString());   //  Contact
                        item.SubItems.Add(row[9].ToString());   //  Hostel

                        Application.DoEvents();

                        if (i > 1) {
                            lvData.Items.Add(item);
                            Employee emp = new Employee();
                            emp.Code = item.SubItems[1].Text;
                            emp.Name = item.SubItems[2].Text;
                            emp.FatherName = item.SubItems[3].Text;
                            emp.NIC = item.SubItems[4].Text;
                            emp.Department = item.SubItems[5].Text;
                            emp.Address = item.SubItems[6].Text;
                            emp.ContactNo = item.SubItems[8].Text;
                            emp.HostelName = item.SubItems[9].Text;
                            emp.Section = category;

                            if (string.IsNullOrEmpty(item.SubItems[9].Text))
                                emp.Hostel = false;
                            else
                                emp.Hostel = true;

                            emp.Suspend = false;

                            empList.Add(emp);
                        }

                        rbStudent.Enabled = rbFaculty.Enabled = rbResident.Enabled = rbVisitor.Enabled = false;

                    }

                    //lblTotalUsers.Text = lvData.Items.Count.ToString();
                }
            }
        }

        private void btnPost_Click(object sender, EventArgs e)
        {
            // save in db
            if (lvData.Items.Count == 0)
            {
                MessageBox.Show("There is no data to post. Please Import Some Data first by browsing the Excel File.");
                return;
            }

            startPosting();


        }

        void startPosting() {
            pbStatus.Visible = true;
            pbStatus.Value = 0;
            btnBrows.Enabled = btnPost.Enabled = btnClear.Enabled = btnClose.Enabled = false;
            bgWorker.RunWorkerAsync();
        }
        void endPosting()
        {
            pbStatus.Visible = false;
            pbStatus.Value = 0;
            rbStudent.Enabled = rbFaculty.Enabled = rbResident.Enabled = rbVisitor.Enabled = true;
            btnBrows.Enabled = btnPost.Enabled = btnClear.Enabled = btnClose.Enabled = true;
            empList.Clear();
            lvData.Items.Clear();

            Globals.ShowMessage("Data Posted Succssefully");
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            rbStudent.Enabled = rbFaculty.Enabled = rbResident.Enabled = rbVisitor.Enabled = true;
            lvData.Clear();
        }

        private void setCategory(object sender, EventArgs e)
        {
            if (rbStudent.Checked)
                category = Constant.Student;
            else if (rbFaculty.Checked)
                category = Constant.Staff;
            else if (rbResident.Checked)
                category = Constant.Resident;
            else if (rbVisitor.Checked)
                category = Constant.Visitor;
        }

        private void frmImportUsers_Load(object sender, EventArgs e)
        {
            setCategory(null, null);
        }

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            int total = empList.Count;
            int c = 0;
            foreach (Employee emp in empList)
            {
                int count = Cache.employeeList.Count(x => x.Code == emp.Code);

                c = c + 1;
                if (count <= 0)
                {
                    
                    if (emp.Save())
                    {
                        int progress = (c * 100) / total;
                        bgWorker.ReportProgress(progress);
                    }

                }
            }
        }

        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            endPosting();
        }

        private void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbStatus.Value = e.ProgressPercentage;
        }
    }
}
