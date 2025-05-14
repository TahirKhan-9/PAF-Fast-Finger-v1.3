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
using FASClient.Classes;
using System.Globalization;

namespace FASClient
{
    public partial class frmAttendanceDetail : Form
    {
        public bool DateEditable = true;
        List<int> list = new List<int>();
        string Section = "";
        string chklist = "";
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

        public bool dailyAttendance = false;
        public bool Timesheet = false;
        public bool summary = false;
        
        public frmAttendanceDetail()
        {
            InitializeComponent();
        }
        private void Attendance_Load(object sender, EventArgs e)
        {
            this.Text = Globals.GetAppTitle() + " v" + Application.ProductVersion;

            var list = (from emp in Cache.employeeList
                        where emp.Section != "Student" && emp.Department != null && emp.Department != ""
                        orderby emp.Department
                        select emp.Department).Distinct().ToList();
            

            // fill departments
            List<string> deptlist = Cache.employeeList.FindAll(y => !y.Section.Equals("Student")).Select(x => x.Department).Distinct().ToList();
            deptlist.Sort();
            cboDept.DataSource = list;

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
            ResetFields();

        }
        public void INOUT(string query)
        {
           // List<AttendanceData> listad = new List<AttendanceData>();

        }
        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (dtpEndDate.Value < dtpStartDate.Value)
            {
                new frmMessageBox(MessageBoxType.Alert, "Date Range Not Valid.").ShowDialog();
                return;
            }

            Employee empInfo = new Employee();

            pbTracker.Value = 0;

            string startDate = dtpStartDate.Value.ToString("dd-MMM-yyyy");
            string endDate = dtpEndDate.Value.ToString("dd-MMM-yyyy");

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("startdate", startDate);
            parameters.Add("enddate", endDate);
            

            btnPreview.Enabled = false;
            btnCancel.Enabled = false;
            pbTracker.Visible = true;

            if (rbEmp.Checked)
            {
                if (string.IsNullOrEmpty(txtCode.Text))
                {
                    MessageBox.Show("Please Select Employee First");
                    return;
                }

                parameters.Add("code", txtCode.Text);

            }
            else if(rbDept.Checked)
            {
                if (!chkAllDept.Checked && string.IsNullOrEmpty(cboDept.Text))
                {
                    MessageBox.Show("Please Select Any Department");
                    return;
                }

                string dept = chkAllDept.Checked ? "ALL" : cboDept.Text;
                parameters.Add("dept", dept);
            }

            bgWorker.RunWorkerAsync(parameters);


        }

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Dictionary<string, string> prams = e.Argument as Dictionary<string, string>;
            string startdate = "";
            string enddate = "";
            string dept = "";
            string code = "";

            prams.TryGetValue("startdate", out startdate);
            
            prams.TryGetValue("enddate", out enddate);

            prams.TryGetValue("dept", out dept);

            prams.TryGetValue("code", out code);


            e.Result = PrepareReport(startdate, enddate,  dept,code);
            
        }
        private List<AttedanceReportData> PrepareReport(string startdate, string enddate,string dept,string code)
        {
            //Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(Globals.GetConnectionString(), CommandType.Text, "delete from userreport");

            List<AttedanceReportData> userlist = new List<AttedanceReportData>();

            //            SELECT Code, Name, Designation, Department, USRDate, DayNo, MIN(Time)AS TimeIn FROM V_RALog
            //Where Section = 'Staff/Faculty'  and[USRDATE] between '2017-11-28 00:00:00.000' and '2018-11-28 00:00:00.000' AND code = '1004-37'
            //GROUP BY Code, DayNo, USRDate, Name, Designation, Department

            string query = "";
            if (!string.IsNullOrEmpty(code))
                query = "SELECT Code, Name, Designation, Department, USRDate, DayNo, MIN(Time)AS TimeIn FROM V_RALog Where Section = '" + Constant.Staff + "' AND [USRDATE] between CONVERT(datetime,'"+ Convert.ToDateTime(startdate).ToString("yyyy-MM-dd") + "') and CONVERT(datetime,'" + Convert.ToDateTime(enddate).ToString("yyyy-MM-dd") + "') AND code = '"+ code + "' GROUP BY Code, DayNo, USRDate, Name, Designation, Department ";
            else if (!dept.Equals("ALL"))
                query = "SELECT Code, Name, Designation, Department, USRDate, DayNo, MIN(Time)AS TimeIn FROM V_RALog Where Section = '" + Constant.Staff + "' AND [USRDATE] between CONVERT(datetime,'"+ Convert.ToDateTime(startdate).ToString("yyyy-MM-dd") + "') and CONVERT(datetime,'" + Convert.ToDateTime(enddate).ToString("yyyy-MM-dd") + "') AND Department = '" + dept + "' GROUP BY Code, DayNo, USRDate, Name, Designation, Department ";
            else
                query = "SELECT Code, Name, Designation, Department, USRDate, DayNo, MIN(Time)AS TimeIn FROM V_RALog Where Section = '" + Constant.Staff + "' AND [USRDATE] between CONVERT(datetime,'"+ Convert.ToDateTime(startdate).ToString("yyyy-MM-dd") + "') and CONVERT(datetime,'" + Convert.ToDateTime(enddate).ToString("yyyy-MM-dd") + "') GROUP BY Code, DayNo, USRDate, Name, Designation, Department ";

            //string query = "SELECT Code, Name, Designation, Department, USRDate, DayNo, MIN(Time) AS TimeIn FROM V_RALog Where Year(Date) = " + Convert.ToDateTime(startdate).Year + " AND Section = '"+Constant.Staff+"' GROUP BY Code, DayNo, USRDate, Name, Designation, Department ";
            //if (!string.IsNullOrEmpty(code))
            //    query += "having code = '" + code+"' AND DayNo between {0} and {1}";
            //else if(!dept.Equals("ALL"))
            //    query += "having department = '" + dept+ "'AND DayNo between {0} and {1}";
            //else
            //    query += "having DayNo between {0} and {1}";

            //    query = String.Format(query, Convert.ToDateTime(startdate).DayOfYear, Convert.ToDateTime(enddate).DayOfYear);

            DataTable dt = SqlHelper.ExecuteDataset(Globals.GetConnectionString(), CommandType.Text, query).Tables[0];
            userlist = Globals.ConvertDataTable<AttedanceReportData>(dt);
            List<AttedanceReportData> TempUserList = new List<AttedanceReportData>();
            DateTime endCounter = new DateTime();            
            
            endCounter = Convert.ToDateTime(enddate);

            List<string> dateList = new List<string>();
            List<string> codes = userlist.Select(x => x.Code).Distinct().ToList();

            foreach (string c in codes)
            {
                List<DateTime> daysIncluded = userlist.FindAll(x => x.Code == c).Select(y => y.USRDate.Date).Distinct().ToList();
                DateTime dateCounter = Convert.ToDateTime(startdate);
                while (dateCounter <= endCounter)
                {
                    DateTime compareDay = dateCounter.Date;

                    if (!daysIncluded.Contains(compareDay))
                    {
                        AttedanceReportData ad = userlist.FindAll(x => x.Code == c).FirstOrDefault();
                        AttedanceReportData user = new AttedanceReportData(c, ad.Name, ad.Department, ad.Designation, dateCounter, compareDay.DayOfYear,"", ad.Remarks);
                        userlist.Add(user);
                    }
                    dateCounter = dateCounter.AddDays(1);

                }

//                List<string> availTim = userlist.FindAll(x => x.Code == c).Select(y => y.USRDate).Distinct().ToList();
            }

            

            query = "";
            if (!string.IsNullOrEmpty(code))
                query = "SELECT * FROM AttendanceReport Where [UsrDate] between CONVERT(datetime,'"+ Convert.ToDateTime(startdate).ToString("yyyy-MM-dd") + "') and CONVERT(datetime,'" + Convert.ToDateTime(enddate).ToString("yyyy-MM-dd") + "') AND code = '" + code + "' ";
            else if (!dept.Equals("ALL"))
                query = "SELECT * FROM AttendanceReport Where [USRDATE] between CONVERT(datetime,'"+ Convert.ToDateTime(startdate).ToString("yyyy-MM-dd") + "') and CONVERT(datetime,'" + Convert.ToDateTime(enddate).ToString("yyyy-MM-dd") + "') AND Department = '" + dept + "' ";
            else
                query = "SELECT * FROM AttendanceReport Where [USRDATE] between CONVERT(datetime,'"+ Convert.ToDateTime(startdate).ToString("yyyy-MM-dd") + "') and CONVERT(datetime,'" + Convert.ToDateTime(enddate).ToString("yyyy-MM-dd") + "') ";

            dt = SqlHelper.ExecuteDataset(Globals.GetConnectionString(), CommandType.Text, query).Tables[0];
            List<AttendanceReport> remarkList = Globals.ConvertDataTable<AttendanceReport>(dt);

            foreach (AttendanceReport remark in remarkList) {

                AttedanceReportData record = userlist.Where(x => x.Code == remark.Code && x.DayNo == remark.DayNo && x.USRDate == remark.UsrDate).FirstOrDefault();
                if (record != null)
                    record.Remarks = remark.Remarks;

            }
            userlist = userlist.OrderBy(x => x.USRDate).ToList();
            return userlist;
            
        }
        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pbTracker.Visible = false;
            btnPreview.Enabled = true;
            btnCancel.Enabled = true;
            List<AttedanceReportData> userlist = e.Result as List<AttedanceReportData>;

            if (userlist.Count == 0)
            {
                new frmMessageBox(MessageBoxType.Alert, "No Record Found for the Current Selection").ShowDialog();
                return;
            }

            frmAttendanceGrid fag = new frmAttendanceGrid();
            fag.data = userlist;
            fag.ShowDialog();

            if (fag.isCancelled)
                return;

            userlist = fag.data;
            frmReportViewer f = new frmReportViewer();
            Reports.AttendanceDetail rptAttDt = new Reports.AttendanceDetail();            
            rptAttDt.SetDataSource(userlist);
            f.rpt = rptAttDt;
            f.Show();

        }
       

        void ResetFields()
        {
            dtpStartDate.Value = DateTime.Today;
            dtpEndDate.Value = DateTime.Today;
            chkAllDept.Checked = false;
            rbDept.Checked = true;
            if (cboDept.Items.Count >= 1) { cboDept.SelectedIndex = 0; }
            txtCode.Text = "";
            txtName.Text = "";
            txtDesig.Text = "";
            txtDept.Text = "";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
           this.Close();
        }

        private void cboDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Employee> emplist = Cache.employeeList.FindAll(x => x.Department.ToLower().Trim().Equals(cboDept.Text.ToLower().Trim()));
            
        }

        private void rbDept_CheckedChanged(object sender, EventArgs e)
        {
            chkAllDept.Enabled = rbDept.Checked;
            
        }

        private void chkAllDept_CheckedChanged(object sender, EventArgs e)
        {
            cboDept.Enabled = !chkAllDept.Checked;
        }

        private void rbEmp_CheckedChanged(object sender, EventArgs e)
        {
            txtCode.Enabled = rbEmp.Checked;
            cboDept.Enabled = !rbEmp.Checked;
            chkAllDept.Enabled = !rbEmp.Checked;

        }

        private void txtCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                Employee empInfo = Cache.employeeList.Find(x => x.Code == txtCode.Text);
                txtCode.Text = empInfo.Code;
                txtDept.Text = empInfo.Department;
                txtDesig.Text = empInfo.Designation;
                txtName.Text = empInfo.Name;
            }
        }
    }
    public class AttedanceReportData
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string Designation { get; set; }
        public string Section { get; set; }
        public DateTime USRDate { get; set; }
        public string UsrDateString { get; set; }

        private string _TimeIn; // field
        private string _TimeOUT; // field


        public string TimeIn {
            get { return _TimeIn; }
            set {
                if (!string.IsNullOrEmpty(value))
                    _TimeIn = timeFormate(value);
                else
                    _TimeIn = value;
            }
        }
        private string timeFormate(string dateString)
        {

            CultureInfo provider = CultureInfo.InvariantCulture;
            DateTime dateTime = DateTime.ParseExact(dateString, new string[] { "HH:mm:ss", "h:mm:ss tt" }, provider, DateTimeStyles.None);
            return dateTime.ToString("h:mm:ss tt");
        }
        public int FacID { get; set; }
        public int DayNo { get; set; }
        public string Remarks { get; set; }
        public string TimeOut {
            get { return _TimeOUT; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    _TimeOUT = timeFormate(value);
                else
                    _TimeOUT = value;
            }
        }
        public DateTime TotalWork { get; set; }


        public AttedanceReportData() { }

        public AttedanceReportData(string _code, string _name, string _dept, string _desig, DateTime _usrdate, int _dayno, string _time, string _remarks)
        {
            this.Code = _code;
            this.Name = _name;
            this.Department = _dept;
            this.Designation = _desig;
            this.USRDate = _usrdate;
            this.DayNo = _dayno;
            this.TimeIn = _time;
            this.Remarks = _remarks;
            
        }
    }
}
