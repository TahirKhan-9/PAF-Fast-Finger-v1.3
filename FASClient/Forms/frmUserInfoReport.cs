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

namespace FASClient
{
    public partial class frmUserInfoReport : Form
    {
            public frmUserInfoReport()
        {
            InitializeComponent();
        }

        private void frmUserInfoReport_Load(object sender, EventArgs e)
        {
            cboReportType.SelectedIndex = 0;
            dtpEndDate.Value = DateTime.Now;
            dtpStartDate.Value = DateTime.Now;
            pbTracker.Visible = false;
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private List<UserInfoForPrint> PrepareReport(string startdate, string enddate, string category, string dept)
        {
            //Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(Globals.GetConnectionString(), CommandType.Text, "delete from userreport");

            List<UserInfoForPrint> userlist = new List<UserInfoForPrint>();
            
            List<Employee> empList = new List<Employee>();
            Dictionary<string, string> paramlist = new Dictionary<string, string>();
            
            paramlist.Add("@Section", category);  
                       
            paramlist.Add("@Dept", dept);
            paramlist.Add("@StartDate", startdate);
            paramlist.Add("@EndDate", enddate);
            DataTable table = SPHelper.executeSP("spGetRegistrationDetail", paramlist);

            userlist = Globals.ConvertDataTable<UserInfoForPrint>(table);

            return userlist;
            
        }
        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (!rbStudents.Checked && !rbStaff.Checked)
            {
                MessageBox.Show("Please Select Any Option from Student|Staff|Faculty First");
                return;
            }

            pbTracker.Value = 0;

            if (!chkAll.Checked)
            {
                if (cboDept.Text == "")
                {
                    MessageBox.Show("Please Select Department/Class");
                    return;
                }
            }

            string startDate = dtpStartDate.Value.ToString("dd-MMM-yyyy") + " 00:00:01";
            string endDate = dtpEndDate.Value.ToString("dd-MMM-yyyy") + " 23:59:59";

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("startdate", startDate);
            parameters.Add("enddate", endDate);

            string category = "";

            if (rbStaff.Checked)
                category = Constant.Staff;
            else if (rbStudents.Checked)
                category = Constant.Student;

            string dept = "";
            if (chkAll.Checked)
                dept = "ALL";
            else
                dept = cboDept.Text;

            parameters.Add("category", category);
            parameters.Add("dept", dept);
            btnPreview.Enabled = false;
            btnCancel.Enabled = false;

            pbTracker.Visible = true;


            myWorker.RunWorkerAsync(parameters);

        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            cboDept.Enabled = !chkAll.Checked;
        }

        private void rbStudents_CheckedChanged(object sender, EventArgs e)
        {
            if (rbStudents.Checked)
            {
                lblDept.Text = "Class : ";
                string query = "select distinct(department) from [Employee] order by department";

                if (rbStudents.Checked)
                    query = "select distinct department from [Employee] where Section = '" + Constant.Student + "' order by department";
                //query = "select distinct department from [Employee] where gid in (11,12) order by department";

                DataTable dt = new DataTable();
                dt = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(Globals.GetConnectionString(), CommandType.Text, query).Tables[0];
                cboDept.DataSource = dt;
                cboDept.DisplayMember = "department";
            }
        }

        private void rbStaff_CheckedChanged(object sender, EventArgs e)
        {
            if (rbStaff.Checked)
            {
                lblDept.Text = "Department : ";
                string query = "select distinct(department) from [Employee] order by department";
                if (rbStaff.Checked)
                    query = "select distinct department from [Employee] where Section = '"+ Constant.Staff+ "' order by department";

                DataTable dt = new DataTable();
                dt = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(Globals.GetConnectionString(), CommandType.Text, query).Tables[0];
                cboDept.DataSource = dt;
                cboDept.DisplayMember = "department";
            }
        }

       

        private void myWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Dictionary<string, string> prams = e.Argument as Dictionary<string,string>;
            string startdate = "";
            string enddate = "";
            string category = "";
            string dept = "";
            prams.TryGetValue("startdate", out startdate);
            prams.TryGetValue("enddate", out enddate);
            prams.TryGetValue("category", out category);
            prams.TryGetValue("dept", out dept);

            e.Result = PrepareReport(startdate,enddate,category,dept);
        }

        private void myWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pbTracker.Visible = false;
            btnPreview.Enabled = true;
            btnCancel.Enabled = true;
            List<UserInfoForPrint> userlist = e.Result as List<UserInfoForPrint>;
            var listWithoutCol = userlist.Select(x => new { x.ID,x.DESIGNATION,x.Section,x.TotalFingers,x.CardCreatedDate,x.Card,x.CARDID,x.CNIC,x.CONTACT,x.DEPARTMENT,x.FingerCreatedDate,x.FULLNAME,x.FINGERID,x.CardVerify,x.FingerVerify }).ToList();
            frmReportViewer f = new frmReportViewer();
            
            switch (cboReportType.SelectedIndex)
            {

                case 0:
                    Reports.CardFingerRegistrationDetail rptCardFinger = new Reports.CardFingerRegistrationDetail();
                    //Card_Registration_Detail_Employees rpt = new Card_Registration_Detail_Employees();
                    // set to datasource
                    rptCardFinger.SetDataSource(listWithoutCol);

                    //rptCardFinger.SetDataSource(userlist);
                    f.rpt = rptCardFinger;
                    break;
                case 1:
                case 2:
                    Reports.FingerRegistrationDetail rpt = new Reports.FingerRegistrationDetail();
                    //Card_Registration_Detail_Employees rpt = new Card_Registration_Detail_Employees();
                    // set to datasource
                    if (cboReportType.SelectedIndex == 1)
                    {
                        List<UserInfoForPrint> list = userlist.FindAll(y => y.TotalFingers > 0);
                        rpt.SetDataSource(list.FindAll(y => y.FingerCreatedDate.Date >= dtpStartDate.Value.Date && y.FingerCreatedDate.Date <= dtpEndDate.Value.Date));

                    }

                    if (cboReportType.SelectedIndex == 2)
                    {
                        List<UserInfoForPrint> list = userlist.FindAll(y => y.TotalFingers < 3);
                        rpt.SetDataSource(list.FindAll(y => y.FingerCreatedDate >= dtpStartDate.Value && y.FingerCreatedDate <= dtpEndDate.Value));
                    }

                    f.rpt = rpt;
                    break;
                case 3:
                case 4:
                    Reports.CardRegistrationDetail rptCard = new Reports.CardRegistrationDetail();
                    //Card_Registration_Detail_Employees rpt = new Card_Registration_Detail_Employees();
                    // set to datasource
                    if (cboReportType.SelectedIndex == 3)
                    {
                        List<UserInfoForPrint> list = userlist.FindAll(y => y.Card > 0);
                        rptCard.SetDataSource(list.FindAll(y => y.CardCreatedDate >= dtpStartDate.Value && y.CardCreatedDate <= dtpEndDate.Value));
                    }
                    else
                    {
                        List<UserInfoForPrint> list = userlist.FindAll(y => y.Card == 0);
                        rptCard.SetDataSource(list.FindAll(y => y.CardCreatedDate >= dtpStartDate.Value && y.CardCreatedDate <= dtpEndDate.Value));
                    }
                    //rptCard.SetDataSource(userlist);
                    f.rpt = rptCard;
                    break;
            }

            f.Show();
            
        }

        private void cboReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //switch (cboReportType.SelectedIndex)
            //{
            //    case 0:
            //        dtpStartDate.Enabled = false;//false
            //        dtpEndDate.Enabled = false;
            //        break;
            //    case 4:
            //        dtpStartDate.Enabled = true;//false
            //        dtpEndDate.Enabled = true;//false
            //        break;
            //    case 1:
            //    case 2:
            //    case 3:
            //        dtpStartDate.Enabled = true;
            //        dtpEndDate.Enabled = true;
            //        break;
            //}
        }
    }
}
