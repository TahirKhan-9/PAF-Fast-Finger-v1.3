using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.ApplicationBlocks.Data;
using Excel2SQL.Reports;
using FASClient.Reports;
using Usman.CodeBlocks.Crypto;
using FASClient.Forms;

namespace FASClient
{
    public partial class Attendance : Form
    {
        public bool DateEditable = true;
        List<int> list = new List<int>();
        string Section = "";
        string chklist = "";
        public string reportTitle = "";
        public string DateLabel
        {
            get { return lblStart.Text; }
            set { lblStart.Text = value; }
        }

        public string ReportLabel
        {
            get { return this.Text; }
            set { this.Text = value; }
        }


        DateTime startDate;
        DateTime endDate;
        public bool dailyAttendance = false;
        public bool dailyLog = false;
        public bool Timesheet = false;
        public bool summary = false;

        public Attendance()
        {
            InitializeComponent();
        }
        public void INOUT(string query)
        {
            // List<AttendanceData> listad = new List<AttendanceData>();

        }
        private void btnPreview_Click(object sender, EventArgs e)
        {

            if (!rbStudents.Checked && !rbStaff.Checked)
            {
                MessageBox.Show("No valid selection Found.");
                return;
            }

            string sec = "";
            if (rbStaff.Checked)
                sec = Constant.Staff;
            else if (rbStudents.Checked)
                sec = Constant.Student;

            //pbTracker.Value = 0;

            if (!chkAllDept.Checked)
            {
                if (cboDept.Text == "")
                    return;
            }

            string startDate = dtpStartDate.Value.ToString("dd-MMM-yyyy") + " 00:00:01";
            string endDate = dtpEndDate.Value.ToString("dd-MMM-yyyy") + " 23:59:59";

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("startdate", startDate);
            parameters.Add("enddate", endDate);

            string category = "";
            string code = "";

            if (rbStaff.Checked)
                category = Constant.Staff;
            else if (rbStudents.Checked)
                category = Constant.Student;

            string dept = "";

            if (chkAllDept.Checked)
                dept = "ALL";
            else
                dept = cboDept.Text;

            parameters.Add("category", category);

            var emp = cboEmployee.SelectedItem as Employee;

            if (chkEmployee.Checked)
                code = "ALL";
            else
            {
                //code = Cache.employeeList.FindAll(x => x.Name.Trim().Equals(cboEmployee.Text.Trim()) && x.Section.Trim().Equals(category.Trim())).FirstOrDefault().Code;
                if (emp != null)
                    code = emp.Code;
            }
            parameters.Add("code", code);

            parameters.Add("dept", dept);

            parameters.Add("sec", sec);

            btnPreview.Enabled = false;
            btnCancel.Enabled = false;

            pbTracker.Visible = true;


            myWorker.RunWorkerAsync(parameters);

        }
        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            //DataTable dt = new DataTable();
            //dt = SqlHelper.ExecuteDataset(Globals.GetConnectionString(), CommandType.Text, e.Argument.ToString()).Tables[0];

            //e.Result = dt;
            Dictionary<string, string> prams = e.Argument as Dictionary<string, string>;
            string startdate = "";
            string enddate = "";
            string dept = "";
            string code = "";
            string sec = "";
            prams.TryGetValue("startdate", out startdate);

            prams.TryGetValue("enddate", out enddate);

            prams.TryGetValue("code", out code);

            prams.TryGetValue("dept", out dept);

            prams.TryGetValue("sec", out sec);

            e.Result = PrepareReport(startdate, enddate, dept, sec, code);
        }

        private List<AttedanceReportData> PrepareReport(string startdate, string enddate, string dept, string sec, string code)
        {
            //Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(Globals.GetConnectionString(), CommandType.Text, "delete from userreport");

            List<AttedanceReportData> userlist = new List<AttedanceReportData>();


            //string query = "SELECT Code, Name, Designation, Department, USRDate, DayNo, MIN(Time) AS TimeIn FROM V_RALog Where Year(Date) = " + Convert.ToDateTime(startdate).Year + " AND Section != 'Student' GROUP BY Code, DayNo, USRDate, Name, Designation, Department ";


            string query = "";
            if (!dailyLog)
            {
                if (!code.Equals("ALL"))
                    query = "SELECT Code, Name, Designation, Department, USRDate, DayNo, MIN(Time)AS TimeIn,Case When count([Time]) < 2 Then '' ELSE max([Time]) END AS TimeOut, Case When count([Date]) = 1 THEN '' ELSE Max([Date]) - Min([Date]) END AS TotalWork FROM V_RALog Where Section = '" + sec + "' AND [USRDATE] between CONVERT(datetime,'" + Convert.ToDateTime(startdate).ToString("yyyy-MM-dd") + "') and CONVERT(datetime,'" + Convert.ToDateTime(enddate).ToString("yyyy-MM-dd") + "') AND code = '" + code + "' GROUP BY Code, DayNo, USRDate, Name, Designation, Department ";
                else if (!dept.Equals("ALL"))
                    query = "SELECT Code, Name, Designation, Department, USRDate, DayNo, MIN(Time)AS TimeIn,Case When count([Time]) < 2 Then '' ELSE max([Time]) END AS TimeOut, Case When count([Date]) = 1 THEN '' ELSE Max([Date]) - Min([Date]) END AS TotalWork FROM V_RALog Where Section = '" + sec + "' AND [USRDATE] between CONVERT(datetime,'" + Convert.ToDateTime(startdate).ToString("yyyy-MM-dd") + "') and CONVERT(datetime,'" + Convert.ToDateTime(enddate).ToString("yyyy-MM-dd") + "') AND Department = '" + dept + "' GROUP BY Code, DayNo, USRDate, Name, Designation, Department ";
                else
                    query = "SELECT Code, Name, Designation, Department, USRDate, DayNo, MIN(Time)AS TimeIn,Case When count([Time]) < 2 Then '' ELSE max([Time]) END AS TimeOut, Case When count([Date]) = 1 THEN '' ELSE Max([Date]) - Min([Date]) END AS TotalWork FROM V_RALog Where Section = '" + sec + "' AND [USRDATE] between CONVERT(datetime,'" + Convert.ToDateTime(startdate).ToString("yyyy-MM-dd") + "') and CONVERT(datetime,'" + Convert.ToDateTime(enddate).ToString("yyyy-MM-dd") + "') GROUP BY Code, DayNo, USRDate, Name, Designation, Department ";
            }
            else
            {
                if (!code.Equals("ALL"))
                    query = "SELECT Code, Name, Designation, Department, USRDate, DayNo, [Time] AS TimeIn FROM V_RALog Where Section = '" + sec + "' AND [USRDATE] between CONVERT(datetime,'" + Convert.ToDateTime(startdate).ToString("yyyy-MM-dd") + "') and CONVERT(datetime,'" + Convert.ToDateTime(enddate).ToString("yyyy-MM-dd") + "') AND code = '" + code + "' GROUP BY Code, DayNo, USRDate, Name, Designation, Department,Time ";
                else if (!dept.Equals("ALL"))
                    query = "SELECT Code, Name, Designation, Department, USRDate, DayNo, [Time] AS TimeIn FROM V_RALog Where Section = '" + sec + "' AND [USRDATE] between CONVERT(datetime,'" + Convert.ToDateTime(startdate).ToString("yyyy-MM-dd") + "') and CONVERT(datetime,'" + Convert.ToDateTime(enddate).ToString("yyyy-MM-dd") + "') AND Department = '" + dept + "' GROUP BY Code, DayNo, USRDate, Name, Designation, Department ,Time";
                else
                    query = "SELECT Code, Name, Designation, Department, USRDate, DayNo, [Time] AS TimeIn FROM V_RALog Where Section = '" + sec + "' AND [USRDATE] between CONVERT(datetime,'" + Convert.ToDateTime(startdate).ToString("yyyy-MM-dd") + "') and CONVERT(datetime,'" + Convert.ToDateTime(enddate).ToString("yyyy-MM-dd") + "') GROUP BY Code, DayNo, USRDate, Name, Designation, Department ,Time";
            }

            //string query = "Select Code,Name,Department,Designation,Section,USRDate,DayNo,min([Time]) as TimeIn,Case When count([Time]) < 2 Then '' ELSE max([Time]) END AS TimeOut, Case When count([Date]) = 1 THEN '' ELSE Max([Date]) - Min([Date]) END AS TotalWork from V_RALog group by Code, Name, Department, Designation, Section, USRDate, DayNo ";

            //if (!code.Equals("ALL"))
            //    query += "having code = '" + code + "' AND DayNo between {0} and {1}";
            //else if (!dept.Equals("ALL"))
            //    query += "having department = '" + dept + "' AND DayNo between {0} and {1}";
            //else
            //    query += "having section = '" + sec + "' AND DayNo between {0} and {1}";

            //query = String.Format(query, Convert.ToDateTime(startdate).DayOfYear, Convert.ToDateTime(enddate).DayOfYear);

            DataTable dt = SqlHelper.ExecuteDataset(Globals.GetConnectionString(), CommandType.Text, query).Tables[0];
            userlist = Globals.ConvertDataTable<AttedanceReportData>(dt);

            List<AttedanceReportData> TempUserList = new List<AttedanceReportData>();
            DateTime endCounter = new DateTime();

            endCounter = Convert.ToDateTime(enddate);

            List<string> dateList = new List<string>();
            List<string> codes = userlist.Select(x => x.Code).Distinct().ToList();

            foreach (string c in codes)
            {
                //List<int> daysIncluded = userlist.FindAll(x => x.Code == c).Select(y => y.DayNo).Distinct().ToList();
                //DateTime dateCounter = Convert.ToDateTime(startdate);

                List<DateTime> daysIncluded = userlist.FindAll(x => x.Code == c).Select(y => y.USRDate.Date).Distinct().ToList();
                DateTime dateCounter = Convert.ToDateTime(startdate);
                while (dateCounter <= endCounter)
                {
                    DateTime compareDay = dateCounter.Date;

                    if (!daysIncluded.Contains(compareDay))
                    {
                        AttedanceReportData ad = userlist.FindAll(x => x.Code == c).FirstOrDefault();
                        AttedanceReportData user = new AttedanceReportData(c, ad.Name, ad.Department, ad.Designation, dateCounter, compareDay.DayOfYear, "", ad.Remarks);
                        userlist.Add(user);
                    }
                    dateCounter = dateCounter.AddDays(1);

                }

                //                List<string> availTim = userlist.FindAll(x => x.Code == c).Select(y => y.USRDate).Distinct().ToList();
            }

            return userlist;

        }
        private void Attendance_Load(object sender, EventArgs e)
        {
            this.Text = Globals.GetAppTitle() + " v" + Application.ProductVersion;
            lblreportTitle.Text = reportTitle;
            ResetFields();
            // devices check
            foreach (FacDefinition device in Cache.facList)
            {
                long mac = device.FacMac;
                string comm = device.FacComm;

                if (Cache.validDevices.ContainsKey(mac))
                {
                    string macComm = "";
                    Cache.validDevices.TryGetValue(mac, out macComm);
                    if (StringCipher.Decrypt(comm.Trim()).Equals(macComm))
                        chklist = chklist + (device.FacID.ToString()) + ",";
                }
            }

            if (!string.IsNullOrEmpty(chklist))
                chklist = chklist.Remove(chklist.Length - 1, 1);
            else
                chklist = "13";

            pbTracker.Visible = false;


        }

        private void ResetFields()
        {
            dtpStartDate.Value = DateTime.Today;
            dtpEndDate.Value = DateTime.Today;

            if (cboDept.Items.Count >= 1) { cboDept.SelectedIndex = 0; }
            if (cboEmployee.Items.Count >= 1)
            {
                cboEmployee.SelectedIndex = 0;
            }

            rbMS.Checked = true;
        }



        //private void cboStation_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    chkUnit.Enabled = true;
        //    chkUnit.Checked = false;
        //    cboDept.Enabled = true;
        //    chkEmployee.Enabled = true;
        //    chkEmployee.Checked = false;
        //    cboEmployee.Enabled = true;

        //    cboEmployee.DataSource = null;
        //    //cboUnit.Items.Clear();
        //    List<string> depts = Cache.employeeList.FindAll(x => x.Section == cboStation.Text).Select(y => y.Department).Distinct().ToList();
        //    cboDept.DataSource = depts;
        //}

        private void cboUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboEmployee.Enabled = true;
            chkEmployee.Checked = false;
            chkEmployee.Enabled = true;
            cboEmployee.DataSource = null;
            List<Employee> emplist = Cache.employeeList.FindAll(x => x.Department.ToLower() == cboDept.Text.ToLower() && x.Section == Section).OrderBy(x => x.Name).ToList();

            cboEmployee.DataSource = emplist;
            cboEmployee.DisplayMember = "Name";
            cboEmployee.ValueMember = "ID";

        }

        private void chkUnit_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAllDept.Checked == true)
            {
                cboDept.Enabled = false;
                cboEmployee.Enabled = false;
                chkEmployee.Checked = true;
                chkEmployee.Enabled = false;
            }
            else
            {
                cboDept.Enabled = true;
                cboEmployee.Enabled = true;
                chkEmployee.Checked = false;
                chkEmployee.Enabled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkEmployee_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEmployee.Checked)
            {
                cboEmployee.Text = "All";
                cboEmployee.Enabled = false;
            }
            else
            {
                cboEmployee.Text = "";
                cboEmployee.Enabled = true;
            }
        }





        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pbTracker.Visible = false;
            btnPreview.Enabled = true;
            btnCancel.Enabled = true;
            List<AttedanceReportData> userlist = e.Result as List<AttedanceReportData>;
            List<AttedanceSummaryReportData> user = new List<AttedanceSummaryReportData>();
            if (!dailyLog) {
                

                if (userlist.Count == 0)
                {
                    new frmMessageBox(MessageBoxType.Alert, "No Record Found for the Current Selection").ShowDialog();
                    return;
                }

                else
                {
                    List<string> codes = userlist.Select(x => x.Code).Distinct().ToList();

                    foreach (string code in codes)
                    {
                        var Employee = userlist.Find(x => x.Code == code);
                        List<AttedanceReportData> list = userlist.FindAll(x => x.Code == code);

                        int totalPresents = userlist.Select(x => x.Code == code && !string.IsNullOrEmpty(x.TimeIn.Trim())).ToList().Count;
                        totalPresents = userlist.Where(x => x.Code == code).Count(y => !string.IsNullOrEmpty(y.TimeIn));
                        int totalDays = userlist.Count(x => x.Code == code);
                        List<DateTime> totalWorks = userlist.Where(x => x.Code == code).Select(y => y.TotalWork).ToList();
                        TimeSpan totalWork = TimeSpan.Parse("00:00:00");
                        foreach (DateTime time in totalWorks)
                        {
                            totalWork += TimeSpan.Parse(time.ToString("HH:mm:ss"));
                        }

                        user.Add(new AttedanceSummaryReportData(Employee.Code, Employee.Name, Employee.Department, Employee.Section, Employee.Designation, totalDays, totalPresents, totalWork));


                    }
                }
            }
            

            frmReportViewer f = new frmReportViewer();
            if (lblreportTitle.Text.Equals("Attendance Summary Report"))
            {
                Reports.AttendanceSummary rpt = new Reports.AttendanceSummary();
                rpt.SetDataSource(user);
                f.rpt = rpt;
            }
            else if (dailyLog) {
                Reports.DayLogReport rpt = new Reports.DayLogReport();
                rpt.SetDataSource(userlist);
                f.rpt = rpt;
            }
            else
            {
                Reports.TimeSheet rpt = new Reports.TimeSheet();
                rpt.SetDataSource(userlist);
                f.rpt = rpt;
            }

            f.Show();


            //if (dt.Rows.Count > 0)
            //    //showReport(dt);
            //else
            //    new frmMessageBox(MessageBoxType.Alert, "No Record Found in the Selection").ShowDialog();
        }
        private void rbStudents_CheckedChanged(object sender, EventArgs e)
        {
            if (!rbSBC.Checked)
                if (rbStudents.Checked)
                {
                    Section = Constant.Student;
                    lblDept.Text = "Class : ";
                    lblEmp.Text = "Student :";

                    List<string> deptList = Cache.employeeList.FindAll(x => x.Section == Constant.Student).Select(y => y.Department).Distinct().ToList().Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();
                    deptList.Sort();
                    cboDept.DataSource = deptList;
                }
        }

        private void rbStaff_CheckedChanged(object sender, EventArgs e)
        {
            if (!rbSBC.Checked)
                if (rbStaff.Checked)
                {
                    Section = Constant.Staff;
                    lblDept.Text = "Department : ";
                    lblEmp.Text = "Employee :";

                    var list = (from emp in Cache.employeeList
                                where emp.Section == Constant.Staff && emp.Department != null && emp.Department != ""
                                orderby emp.Department
                                select emp.Department).Distinct().ToList();

                    List<string> deptList = Cache.employeeList.FindAll(x => x.Section == Constant.Staff).Select(y => y.Department).Distinct().ToList().Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();
                    deptList.Sort();
                    list.Sort();
                    cboDept.DataSource = list;

                    cboDept.Enabled = true;
                    cboEmployee.Enabled = true;
                    chkAllDept.Enabled = true;
                    chkEmployee.Enabled = true;
                    chkAllDept.Checked = false;
                    chkEmployee.Checked = false;
                }

        }

        private void rbSBC_CheckedChanged(object sender, EventArgs e)
        {
            rbStaff.Checked = false;
            rbStudents.Checked = false;

            cboDept.DataSource = null;
            cboEmployee.DataSource = null;

            if (rbMS.Checked)
            {
                groupSBC.Enabled = false;
                groupMS.Enabled = true;

            }
            else if (rbSBC.Checked)
            {
                groupMS.Enabled = false;
                groupSBC.Enabled = true;
            }
        }

        private void txtDept_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                List<Employee> emplist = Cache.employeeList.FindAll(x => x.Code == txtCode.Text).OrderBy(x => x.Name).ToList();
                List<string> deptList = emplist.Select(y => y.Department).Distinct().ToList().Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();
                cboDept.DataSource = deptList;

                cboEmployee.DataSource = emplist;
                cboEmployee.DisplayMember = "Name";
                cboEmployee.ValueMember = "ID";

                switch (emplist.FirstOrDefault().Section)
                {
                    case Constant.Staff:
                        rbStaff.Checked = true;
                        rbStudents.Checked = false;
                        break;
                    case Constant.Student:
                        rbStaff.Checked = false;
                        rbStudents.Checked = true;
                        break;
                }
            }
        }
    }

    public class AttedanceSummaryReportData
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string Designation { get; set; }
        public string Section { get; set; }
        public int TotalDays { get; set; }
        public int TotalPresents { get; set; }
        public string TotalWork { get; set; }

        AttedanceSummaryReportData() { }


        public AttedanceSummaryReportData(string code, string name, string department, string section, string designation, int totalDays, int totalPresents, TimeSpan totalWork)
        {
            Code = code;
            Name = name;
            Department = department;
            Section = section;
            Designation = designation;
            TotalDays = totalDays;
            TotalPresents = totalPresents;
            TotalWork = totalWork.ToString();
        }
    }
}
    
