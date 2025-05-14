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
using Usman.CodeBlocks.Crypto;

namespace FASClient.Forms
{
    public partial class frmHostelReport : Form
    {
        string chklist = "";
        public frmHostelReport()
        {
            InitializeComponent();
        }

        private void frmHostelReport_Load(object sender, EventArgs e)
        {
            this.Text = Globals.GetAppTitle() + " v" + Application.ProductVersion;

            var list = (from emp in Cache.employeeList
                        where emp.Department != null && emp.Department != ""
                        orderby emp.Department
                        select emp.Department).Distinct().ToList();


            // fill departments
            List<string> deptlist = Cache.employeeList.Select(x => x.Department).Distinct().ToList().Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();
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

        private void txtCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                Employee empInfo = Cache.employeeList.Find(x => x.Code == txtCode.Text);
                if (empInfo != null)
                {
                    txtCode.Text = empInfo.Code;
                    txtDept.Text = empInfo.Department;
                    txtDesig.Text = empInfo.Designation;
                    txtName.Text = empInfo.Name;
                }
                else
                {
                    txtCode.Text = "";
                    txtDept.Text = "";
                    txtDesig.Text = "";
                    txtName.Text = "";
                }
            }
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
            txtDevices.Text = "";
        }

        private void rbDept_CheckedChanged(object sender, EventArgs e)
        {
            txtCode.Enabled = !rbDept.Checked;
            cboDept.Enabled = rbDept.Checked;
            chkAllDept.Enabled = rbDept.Checked;
            chkAllDept.Checked = false;
        }

        private void rbEmp_CheckedChanged(object sender, EventArgs e)
        {
            txtCode.Enabled = rbEmp.Checked;
            cboDept.Enabled = !rbEmp.Checked;
            chkAllDept.Enabled = !rbEmp.Checked;
        }

        private void chkAllDept_CheckedChanged(object sender, EventArgs e)
        {
            cboDept.Enabled = !chkAllDept.Checked;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
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
            else if (rbDept.Checked)
            {
                if (!chkAllDept.Checked && string.IsNullOrEmpty(cboDept.Text))
                {
                    MessageBox.Show("Please Select Any Department");
                    return;
                }

                string dept = chkAllDept.Checked ? "ALL" : cboDept.Text;
                parameters.Add("dept", dept);
            }
            if (!chkAllDevices.Checked && string.IsNullOrEmpty(txtDevices.Text))
            {
                MessageBox.Show("Please Select Devices");
                return;
            }
            string devices = chkAllDevices.Checked ? "ALL" : txtDevices.Text;
            parameters.Add("devices", devices);

            bgWorker.RunWorkerAsync(parameters);
        }

        private void chkAllDevices_CheckedChanged(object sender, EventArgs e)
        {
            txtDevices.Enabled = !chkAllDevices.Checked;
            lblSearch.Enabled = !chkAllDevices.Checked;
        }

        private void lblSearch_Click(object sender, EventArgs e)
        {
            frmSelectDevice dev = new frmSelectDevice();
            dev.forReport = true;
            dev.ShowDialog();

            if (dev.Devices.Count > 0)
            {
                txtDevices.Text = "";
                string devices = "";
                foreach(string item in dev.Devices)
                {
                    devices += item + ",";
                }
                devices = devices.Remove(devices.Length - 1);
                txtDevices.Text = devices;
            }
        }

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Dictionary<string, string> prams = e.Argument as Dictionary<string, string>;
            string startdate = "";
            string enddate = "";
            string dept = "";
            string code = "";
            string devices = "";

            prams.TryGetValue("startdate", out startdate);

            prams.TryGetValue("enddate", out enddate);

            prams.TryGetValue("dept", out dept);

            prams.TryGetValue("code", out code);

            prams.TryGetValue("devices", out devices);


            e.Result = PrepareReport(startdate, enddate, dept, code, devices);
        }
        List<HostelReportData> PrepareReport(string startdate, string enddate, string dept, string code, string devices)
        {
            List<HostelReportData> userlist = new List<HostelReportData>();

            string query = "select v.Code, v.Name, v.Department, v.Date, v.USRDATE, v.DayNo, v.Time, v.FacID,f.Description, ";
            query += "ISNULL((select distinct Name from TimeSlot where CONVERT(datetime, v.Time, 108) >= CONVERT(datetime, StartTime, 108) and ";
            query += "CONVERT(datetime, v.Time,108) <= CONVERT(datetime, EndTime, 108)";
            query += "),'Not Allocated') as TimeSlot ";
            query += "from V_RALog v, FacDefinition f where f.FacID = v.FacID ";
            query += "{0} {1} {2} {3} ";
            query += "order by Code";

            if (devices.ToLower().Equals("all"))
                devices = "";
            else
                devices = "and v.FacID in (" + devices + ")";

            if (!string.IsNullOrEmpty(code))
                code = "and v.code = '" + code + "'";

            if (dept.ToLower().Equals("all"))
                dept = "";
            else
                dept = "and v.Department = '" + dept + "'";

            string dateRange = "and v.USRDATE >= CONVERT(datetime,'" + Convert.ToDateTime(startdate).ToString("yyyy-MM-dd") + "') and v.USRDATE <= CONVERT(datetime,'" + Convert.ToDateTime(enddate).ToString("yyyy-MM-dd") + "') ";

            query = string.Format(query, devices, code, dept, dateRange);

            DataTable dt = SqlHelper.ExecuteDataset(Globals.GetConnectionString(), CommandType.Text, query).Tables[0];
            userlist = Globals.ConvertDataTable<HostelReportData>(dt);

            return userlist;
        }
        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pbTracker.Visible = false;
            btnPreview.Enabled = true;
            btnCancel.Enabled = true;
            List<HostelReportData> userlist = e.Result as List<HostelReportData>;

            if (userlist.Count == 0)
            {
                new frmMessageBox(MessageBoxType.Alert, "No Record Found for the Current Selection").ShowDialog();
                return;
            }

            //frmAttendanceGrid fag = new frmAttendanceGrid();
            //fag.data = userlist;
            //fag.ShowDialog();

            //if (fag.isCancelled)
            //    return;

            //userlist = fag.data;

            frmReportViewer f = new frmReportViewer();
            Reports.HostelMessReport rpt = new Reports.HostelMessReport();

            DateTime from = dtpStartDate.Value;
            DateTime to = dtpEndDate.Value;

            rpt.SetParameterValue(0, from.ToString());
            rpt.SetParameterValue(1, to.ToString());
            rpt.SetDataSource(userlist);


            f.rpt = rpt;
            f.Show();
        }
    }

    public class HostelReportData
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string Time { get; set; }
        public DateTime USRDate { get; set; }
        public DateTime Date { get; set; }
        public string TimeSlot { get; set; }
        public string Description { get; set; }


        public HostelReportData() { }

        public HostelReportData(string _code, string _name, string _dept, DateTime _date, DateTime _usrdate, string _time, string _timeslot, string _description)
        {
            this.Code = _code;
            this.Name = _name;
            this.Department = _dept;
            this.Date = _date;
            this.USRDate = _usrdate;
            this.Time = _time;
            this.TimeSlot = _timeslot;
            this.Description = _description;
        }
    }
}
