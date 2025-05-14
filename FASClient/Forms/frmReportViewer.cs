using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;
using FASClient.Classes;
using FASClient.Forms;

namespace FASClient
{
    public partial class frmReportViewer : Form
    {
        public object rpt;
        public string receiverID;
        public int senderID;
        public string period = "";
        public string reportFileName;
        public string reportFilePath;
        public bool export;
        public string deptName;
        public string headEmail;
        public string headId;
        public bool sendToAll;

        public frmReportViewer()
        {
            InitializeComponent();
        }

        private void frmReportViewer_Load(object sender, EventArgs e)
        {

            this.crViewer.ReportSource = rpt;
            this.crViewer.RefreshReport();

            //if (string.IsNullOrEmpty(reportFileName))
            //{
            //    this.crViewer.ReportSource = rpt;
            //    this.crViewer.RefreshReport();
            //}
            //else
            //{
            //    //ReportDocument doc = new ReportDocument();
            //    //doc.Load(reportFilePath);
            //    //crViewer.ReportSource = doc;

            //    //this.crViewer.RefreshReport();



            //}

            //if (export)
            //{
            //    if (deptName == "All")
            //    {
            //        if (sendToAll)
            //        {
            //            Reports.AttendanceDetail report = (Reports.AttendanceDetail)rpt;
            //            report.RecordSelectionFormula = "";

            //            DataTable dt = new DataTable();
            //            dt = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(Globals.GetConnectionString(), CommandType.Text, "select distinct department from attendancereport order by department").Tables[0];
            //            if (dt.Rows.Count >= 1)
            //            {
            //                if (MessageBox.Show("Do you want to send this Report to Supervisor by Email?", "Sending Email", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            //                {
            //                    foreach (DataRow row in dt.Rows)
            //                    {
            //                        doc.RecordSelectionFormula = "{AttendanceReport.Department} = '" + row[0].ToString() + "' ";
            //                        DepartmentHeads dh = new DepartmentHeads(row[0].ToString());
            //                        if (dh.Email == null || dh.Email == "")
            //                        { }
            //                        else
            //                            ExportAndSend(doc, dh.Email, dh.HODID);
            //                    }
            //                }
            //            }
            //        }
            //        else
            //        {
            //            if (MessageBox.Show("Do you want to send this Report to Supervisor by Email?", "Sending Email", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            //            {
            //                if (headEmail == null || headEmail == "")
            //                { }
            //                else
            //                    ExportAndSend(doc, headEmail, headId);
            //            }
            //        }
            //    }
            //    else
            //    {
            //        if (MessageBox.Show("Do you want to send this Report to Supervisor by Email?", "Sending Email", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            //        {
            //            //DataTable dt = new DataTable();
            //            //dt = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(Globals.GetConnectionString(), CommandType.Text, "select HODID,HODName from departmentheads where department='"+deptName +"' ").Tables[0];
            //            DepartmentHeads dh = new DepartmentHeads(deptName);
            //            if (dh.Email == null || dh.Email == "")
            //            { }
            //            else
            //                ExportAndSend(doc, dh.Email, dh.HODID);
            //        }
            //    }
            //}
            //else
            //{

            //}
        }

        string GetFileName(string fileName)
        {
            string reportsFolder = Application.StartupPath + "\\Reports\\";
            if (!Directory.Exists(reportsFolder))
                Directory.CreateDirectory(reportsFolder);


            string exportFilePath = reportsFolder + reportFileName + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".pdf";

            return exportFilePath;
        }

        string MakeEmailData()
        {
            string msg = "Dear Sir\n\rAttendance Report for Your Department";

            return msg;
        }
        
    }
}
