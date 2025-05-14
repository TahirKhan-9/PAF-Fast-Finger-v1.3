using FASClient.Classes;
using FASClient.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;

namespace FASClient
{
    public partial class frmMain : Form
    {
        Roles role = new Roles();

        public frmMain()
        {
            
            InitializeComponent();
        }



        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void importFromExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmImportUsers f = new frmImportUsers();
            f.ShowDialog();
        }

        private void companyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCompany f = new frmCompany();
            f.ShowDialog();
        }

        private void loginsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAppUsers f = new frmAppUsers();
            f.ShowDialog();
        }

        private void rolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRoles f = new frmRoles();
            f.ShowDialog();
        }

        private void dutyShiftsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShiftManagement f = new frmShiftManagement();
            f.ShowDialog();
        }

        private void dutySchedulesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShift f = new frmShift();
            f.ShowDialog();
        }

        private int initializeFAS()
        {
            string connstring = Globals.GetConnectionString();
            string[] cstr = connstring.Split(';');
            string[] newstr = cstr[0].Split('=');
            string serverstr = newstr[1].ToUpper();
            serverstr = serverstr.Replace("\\SQLEXPRESS", "").Trim();

            int ret = FASHelper.Connect(serverstr);

            return ret;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

            //disableMenu();

            // show login form
            this.Text = Globals.GetAppTitle() + " v" + Application.ProductVersion;
            
            Globals.SetTemplateFolder(Application.StartupPath + "\\Templates\\");
            frmLogin f = new frmLogin();
            this.Hide();
            f.ShowDialog();

            if (f.cancelled)
            {
                new frmMessageBox(MessageBoxType.Alert, "User Cancelled. Quitting ...").ShowDialog();
                this.Close();
            }
            else
            {
                if (!f.success)
                {
                    //MessageBox.Show("Invalid Login. Quitting ...");
                    this.Close();
                }
                else
                {
                    this.Show();
                    Globals.GetAppSettings();
                    lblStatus.Text = "Connecting to FAS ....";

                    //string mac = Usman.CodeBlocks.Networking.NetworkHelper.GetMac("192.168.1.137");
                    //MessageBox.Show("Your Mac : " + mac);

                    myWorker.RunWorkerAsync();

                    if (!Globals.defaultUser)
                    {
                        lblUser.Text = Globals.User.UserName + " [" + Globals.User.LoginID + "]";

                        // implement roles
                        role = new Roles(Globals.User.RoleID);
                        ImplementRoles();

                        //rbStudents_CheckedChanged(null, null);
                        //if (Globals.ValiditySensor)
                        //{
                        //    validityWorker.RunWorkerAsync();
                        //}
                    }
                    else
                    {
                        lblUser.Text = "Default User!";
                        setupToolStripMenuItem.Enabled = true;
                        //mnuAdministration.Enabled = true;
                        //mnuUserViewer.Enabled = false;
                        //mnuAllowBlock.Enabled = false;
                        //mnuCollectUsersToSend.Enabled = false;
                        //reportsToolStrip.Enabled = false;
                        //btnBrowse.Enabled = false;
                        //btnPost.Enabled = false;
                        //rbStudents.Enabled = false;
                        //rbEmployees.Enabled = false;
                        //rbPermResidents.Enabled = false;
                        //rbTempResidents.Enabled = false;
                    }
                    this.Show();
                }

                //frmSelectDevice frm = new frmSelectDevice();
                //frmLive frm = new frmLive();
                //frm.ShowDialog();
            }
        }
        void ImplementRoles()
        {
            if (role != null)
            {

                deviceMonitoringToolStripMenuItem.Enabled = (role.Company || (role.ImportUser
             && role.Company
             && role.DutyShifts
             && role.Role
             && role.Logins
             && role.UserInfo
             && role.Enrollment

             && role.DutySchedules
             && role.UserListReports
             && role.CardManagement
             && role.TimeSheetReport
             && role.AttendanceDetailReport
             && role.AttendanceSummaryReport

             && role.ProfilePhotosSetup
             && role.DeviceSetup
             && role.DeviceUsersManagement
             && role.SuspendUsers
             && role.BlockUsers));

                connectFASToolStripMenuItem.Enabled = (role.Enrollment || role.SuspendUsers|| role.BlockUsers || (role.ImportUser
             && role.Company
             && role.DutyShifts
             && role.Role
             && role.Logins
             && role.UserInfo
             && role.Enrollment

             && role.DutySchedules
             && role.UserListReports
             && role.CardManagement
             && role.TimeSheetReport
             && role.AttendanceDetailReport
             && role.AttendanceSummaryReport

             && role.ProfilePhotosSetup
             && role.DeviceSetup
             && role.DeviceUsersManagement
             && role.SuspendUsers
             && role.BlockUsers));
                generalSettingsToolStripMenuItem.Enabled = (role.ProfilePhotosSetup || (role.ImportUser
             && role.Company
             && role.DutyShifts
             && role.Role
             && role.Logins
             && role.UserInfo
             && role.Enrollment

             && role.DutySchedules
             && role.UserListReports
             && role.CardManagement
             && role.TimeSheetReport
             && role.AttendanceDetailReport
             && role.AttendanceSummaryReport

             && role.ProfilePhotosSetup
             && role.DeviceSetup
             && role.DeviceUsersManagement
             && role.SuspendUsers
             && role.BlockUsers));
                setPicturesPathToolStripMenuItem.Enabled = (role.ProfilePhotosSetup || (role.ImportUser
             && role.Company
             && role.DutyShifts
             && role.Role
             && role.Logins
             && role.UserInfo
             && role.Enrollment

             && role.DutySchedules
             && role.UserListReports
             && role.CardManagement
             && role.TimeSheetReport
             && role.AttendanceDetailReport
             && role.AttendanceSummaryReport

             && role.ProfilePhotosSetup
             && role.DeviceSetup
             && role.DeviceUsersManagement
             && role.SuspendUsers
             && role.BlockUsers));
                deviceToolStripMenuItem.Enabled = (role.DeviceSetup || role.DeviceUsersManagement || (role.ImportUser
             && role.Company
             && role.DutyShifts
             && role.Role
             && role.Logins
             && role.UserInfo
             && role.Enrollment

             && role.DutySchedules
             && role.UserListReports
             && role.CardManagement
             && role.TimeSheetReport
             && role.AttendanceDetailReport
             && role.AttendanceSummaryReport

             && role.ProfilePhotosSetup
             && role.DeviceSetup
             && role.DeviceUsersManagement
             && role.SuspendUsers
             && role.BlockUsers));
                vehicleRegistrationToolStripMenuItem.Enabled = (role.DutyShifts || role.DutySchedules || (role.ImportUser
             && role.Company
             && role.DutyShifts
             && role.Role
             && role.Logins
             && role.UserInfo
             && role.Enrollment

             && role.DutySchedules
             && role.UserListReports
             && role.CardManagement
             && role.TimeSheetReport
             && role.AttendanceDetailReport
             && role.AttendanceSummaryReport

             && role.ProfilePhotosSetup
             && role.DeviceSetup
             && role.DeviceUsersManagement
             && role.SuspendUsers
             && role.BlockUsers));
                logToolStripMenuItem.Enabled = ((role.ImportUser
             && role.Company
             && role.DutyShifts
             && role.Role
             && role.Logins
             && role.UserInfo
             && role.Enrollment

             && role.DutySchedules
             && role.UserListReports
             && role.CardManagement
             && role.TimeSheetReport
             && role.AttendanceDetailReport
             && role.AttendanceSummaryReport

             && role.ProfilePhotosSetup
             && role.DeviceSetup
             && role.DeviceUsersManagement
             && role.SuspendUsers
             && role.BlockUsers));
                cardManagementToolStripMenuItem.Enabled = (role.Enrollment || role.CardManagement || (role.ImportUser
             && role.Company
             && role.DutyShifts
             && role.Role
             && role.Logins
             && role.UserInfo
             && role.Enrollment

             && role.DutySchedules
             && role.UserListReports
             && role.CardManagement
             && role.TimeSheetReport
             && role.AttendanceDetailReport
             && role.AttendanceSummaryReport

             && role.ProfilePhotosSetup
             && role.DeviceSetup
             && role.DeviceUsersManagement
             && role.SuspendUsers
             && role.BlockUsers));
                rolesToolStripMenuItem.Enabled = (role.Role || (role.ImportUser
             && role.Company
             && role.DutyShifts
             && role.Role
             && role.Logins
             && role.UserInfo
             && role.Enrollment

             && role.DutySchedules
             && role.UserListReports
             && role.CardManagement
             && role.TimeSheetReport
             && role.AttendanceDetailReport
             && role.AttendanceSummaryReport

             && role.ProfilePhotosSetup
             && role.DeviceSetup
             && role.DeviceUsersManagement
             && role.SuspendUsers
             && role.BlockUsers));
                timeSlotToolStripMenuItem.Enabled = (role.DutySchedules || (role.ImportUser
             && role.Company
             && role.DutyShifts
             && role.Role
             && role.Logins
             && role.UserInfo
             && role.Enrollment

             && role.DutySchedules
             && role.UserListReports
             && role.CardManagement
             && role.TimeSheetReport
             && role.AttendanceDetailReport
             && role.AttendanceSummaryReport

             && role.ProfilePhotosSetup
             && role.DeviceSetup
             && role.DeviceUsersManagement
             && role.SuspendUsers
             && role.BlockUsers));
                loginsToolStripMenuItem.Enabled = (role.Logins || (role.ImportUser
             && role.Company
             && role.DutyShifts
             && role.Role
             && role.Logins
             && role.UserInfo
             && role.Enrollment

             && role.DutySchedules
             && role.UserListReports
             && role.CardManagement
             && role.TimeSheetReport
             && role.AttendanceDetailReport
             && role.AttendanceSummaryReport

             && role.ProfilePhotosSetup
             && role.DeviceSetup
             && role.DeviceUsersManagement
             && role.SuspendUsers
             && role.BlockUsers));
                exitToolStripMenuItem.Enabled = true;
                importFromExcelToolStripMenuItem.Enabled = (role.UserInfo || role.Enrollment|| role.UserListReports||(role.ImportUser
             && role.Company
             && role.DutyShifts
             && role.Role
             && role.Logins
             && role.UserInfo
             && role.Enrollment

             && role.DutySchedules
             && role.UserListReports
             && role.CardManagement
             && role.TimeSheetReport
             && role.AttendanceDetailReport
             && role.AttendanceSummaryReport

             && role.ProfilePhotosSetup
             && role.DeviceSetup
             && role.DeviceUsersManagement
             && role.SuspendUsers
             && role.BlockUsers));
                userInformationToolStripMenuItem.Enabled = (role.Enrollment || role.UserInfo || (role.ImportUser
             && role.Company
             && role.DutyShifts
             && role.Role
             && role.Logins
             && role.UserInfo
             && role.Enrollment

             && role.DutySchedules
             && role.UserListReports
             && role.CardManagement
             && role.TimeSheetReport
             && role.AttendanceDetailReport
             && role.AttendanceSummaryReport

             && role.ProfilePhotosSetup
             && role.DeviceSetup
             && role.DeviceUsersManagement
             && role.SuspendUsers
             && role.BlockUsers));
                dutySchedulesToolStripMenuItem.Enabled = (role.DutySchedules || (role.ImportUser
             && role.Company
             && role.DutyShifts
             && role.Role
             && role.Logins
             && role.UserInfo
             && role.Enrollment

             && role.DutySchedules
             && role.UserListReports
             && role.CardManagement
             && role.TimeSheetReport
             && role.AttendanceDetailReport
             && role.AttendanceSummaryReport

             && role.ProfilePhotosSetup
             && role.DeviceSetup
             && role.DeviceUsersManagement
             && role.SuspendUsers
             && role.BlockUsers));
                deviceUsersToolStripMenuItem.Enabled = (role.DeviceSetup || role.DeviceUsersManagement ||(role.ImportUser
             && role.Company
             && role.DutyShifts
             && role.Role
             && role.Logins
             && role.UserInfo
             && role.Enrollment

             && role.DutySchedules
             && role.UserListReports
             && role.CardManagement
             && role.TimeSheetReport
             && role.AttendanceDetailReport
             && role.AttendanceSummaryReport

             && role.ProfilePhotosSetup
             && role.DeviceSetup
             && role.DeviceUsersManagement
             && role.SuspendUsers
             && role.BlockUsers));
                DenialUsersToolStripMenuItem.Enabled = (role.SuspendUsers || role.BlockUsers ||(role.ImportUser
             && role.Company
             && role.DutyShifts
             && role.Role
             && role.Logins
             && role.UserInfo
             && role.Enrollment

             && role.DutySchedules
             && role.UserListReports
             && role.CardManagement
             && role.TimeSheetReport
             && role.AttendanceDetailReport
             && role.AttendanceSummaryReport

             && role.ProfilePhotosSetup
             && role.DeviceSetup
             && role.DeviceUsersManagement
             && role.SuspendUsers
             && role.BlockUsers));
                blockedUsersToolStripMenuItem.Enabled = (role.SuspendUsers || role.BlockUsers || (role.ImportUser
             && role.Company
             && role.DutyShifts
             && role.Role
             && role.Logins
             && role.UserInfo
             && role.Enrollment

             && role.DutySchedules
             && role.UserListReports
             && role.CardManagement
             && role.TimeSheetReport
             && role.AttendanceDetailReport
             && role.AttendanceSummaryReport

             && role.ProfilePhotosSetup
             && role.DeviceSetup
             && role.DeviceUsersManagement
             && role.SuspendUsers
             && role.BlockUsers));
                userListsToolStripMenuItem.Enabled = (role.UserListReports || (role.ImportUser
             && role.Company
             && role.DutyShifts
             && role.Role
             && role.Logins
             && role.UserInfo
             && role.Enrollment

             && role.DutySchedules
             && role.UserListReports
             && role.CardManagement
             && role.TimeSheetReport
             && role.AttendanceDetailReport
             && role.AttendanceSummaryReport

             && role.ProfilePhotosSetup
             && role.DeviceSetup
             && role.DeviceUsersManagement
             && role.SuspendUsers
             && role.BlockUsers));
                registrationDetailToolStripMenuItem.Enabled = ( true|| (role.ImportUser
             && role.Company
             && role.DutyShifts
             && role.Role
             && role.Logins
             && role.UserInfo
             && role.Enrollment

             && role.DutySchedules
             && role.UserListReports
             && role.CardManagement
             && role.TimeSheetReport
             && role.AttendanceDetailReport
             && role.AttendanceSummaryReport

             && role.ProfilePhotosSetup
             && role.DeviceSetup
             && role.DeviceUsersManagement
             && role.SuspendUsers
             && role.BlockUsers));
                timeSheetToolStripMenuItem.Enabled = (role.TimeSheetReport || (role.ImportUser
             && role.Company
             && role.DutyShifts
             && role.Role
             && role.Logins
             && role.UserInfo
             && role.Enrollment

             && role.DutySchedules
             && role.UserListReports
             && role.CardManagement
             && role.TimeSheetReport
             && role.AttendanceDetailReport
             && role.AttendanceSummaryReport

             && role.ProfilePhotosSetup
             && role.DeviceSetup
             && role.DeviceUsersManagement
             && role.SuspendUsers
             && role.BlockUsers));
                dailyAttendanceToolStripMenuItem.Enabled = dailyLogToolStripMenuItem.Enabled = ( true|| (role.ImportUser
             && role.Company
             && role.DutyShifts
             && role.Role
             && role.Logins
             && role.UserInfo
             && role.Enrollment

             && role.DutySchedules
             && role.UserListReports
             && role.CardManagement
             && role.TimeSheetReport
             && role.AttendanceDetailReport
             && role.AttendanceSummaryReport

             && role.ProfilePhotosSetup
             && role.DeviceSetup
             && role.DeviceUsersManagement
             && role.SuspendUsers
             && role.BlockUsers));
                attendanceDetailToolStripMenuItem.Enabled = ( role.AttendanceDetailReport || (role.ImportUser
             && role.Company
             && role.DutyShifts
             && role.Role
             && role.Logins
             && role.UserInfo
             && role.Enrollment

             && role.DutySchedules
             && role.UserListReports
             && role.CardManagement
             && role.TimeSheetReport
             && role.AttendanceDetailReport
             && role.AttendanceSummaryReport

             && role.ProfilePhotosSetup
             && role.DeviceSetup
             && role.DeviceUsersManagement
             && role.SuspendUsers
             && role.BlockUsers));
                SummarytoolStripMenuItem.Enabled = (role.AttendanceSummaryReport || (role.ImportUser
             && role.Company
             && role.DutyShifts
             && role.Role
             && role.Logins
             && role.UserInfo
             && role.Enrollment

             && role.DutySchedules
             && role.UserListReports
             && role.CardManagement
             && role.TimeSheetReport
             && role.AttendanceDetailReport
             && role.AttendanceSummaryReport

             && role.ProfilePhotosSetup
             && role.DeviceSetup
             && role.DeviceUsersManagement
             && role.SuspendUsers
             && role.BlockUsers));
                couponReportToolStripMenuItem.Enabled = ((role.ImportUser
             && role.Company
             && role.DutyShifts
             && role.Role
             && role.Logins
             && role.UserInfo
             && role.Enrollment

             && role.DutySchedules
             && role.UserListReports
             && role.CardManagement
             && role.TimeSheetReport
             && role.AttendanceDetailReport
             && role.AttendanceSummaryReport

             && role.ProfilePhotosSetup
             && role.DeviceSetup
             && role.DeviceUsersManagement
             && role.SuspendUsers
             && role.BlockUsers));
                tsbUsers.Enabled = (role.UserInfo || role.Enrollment || (role.ImportUser
             && role.Company
             && role.DutyShifts
             && role.Role
             && role.Logins
             && role.UserInfo
             && role.Enrollment

             && role.DutySchedules
             && role.UserListReports
             && role.CardManagement
             && role.TimeSheetReport
             && role.AttendanceDetailReport
             && role.AttendanceSummaryReport

             && role.ProfilePhotosSetup
             && role.DeviceSetup
             && role.DeviceUsersManagement
             && role.SuspendUsers
             && role.BlockUsers));
                tsbImport.Enabled = (role.UserInfo || role.Enrollment || (role.ImportUser
             && role.Company
             && role.DutyShifts
             && role.Role
             && role.Logins
             && role.UserInfo
             && role.Enrollment

             && role.DutySchedules
             && role.UserListReports
             && role.CardManagement
             && role.TimeSheetReport
             && role.AttendanceDetailReport
             && role.AttendanceSummaryReport

             && role.ProfilePhotosSetup
             && role.DeviceSetup
             && role.DeviceUsersManagement
             && role.SuspendUsers
             && role.BlockUsers));
                tsbSchedule.Enabled = (role.DutyShifts || role.DutySchedules || (role.ImportUser
             && role.Company
             && role.DutyShifts
             && role.Role
             && role.Logins
             && role.UserInfo
             && role.Enrollment

             && role.DutySchedules
             && role.UserListReports
             && role.CardManagement
             && role.TimeSheetReport
             && role.AttendanceDetailReport
             && role.AttendanceSummaryReport

             && role.ProfilePhotosSetup
             && role.DeviceSetup
             && role.DeviceUsersManagement
             && role.SuspendUsers
             && role.BlockUsers));
                tspLive.Enabled = ((role.ImportUser
             && role.Company
             && role.DutyShifts
             && role.Role
             && role.Logins
             && role.UserInfo
             && role.Enrollment

             && role.DutySchedules
             && role.UserListReports
             && role.CardManagement
             && role.TimeSheetReport
             && role.AttendanceDetailReport
             && role.AttendanceSummaryReport

             && role.ProfilePhotosSetup
             && role.DeviceSetup
             && role.DeviceUsersManagement
             && role.SuspendUsers
             && role.BlockUsers));
                tsbTodayAt.Enabled = ((role.ImportUser
             && role.Company
             && role.DutyShifts
             && role.Role
             && role.Logins
             && role.UserInfo
             && role.Enrollment

             && role.DutySchedules
             && role.UserListReports
             && role.CardManagement
             && role.TimeSheetReport
             && role.AttendanceDetailReport
             && role.AttendanceSummaryReport

             && role.ProfilePhotosSetup
             && role.DeviceSetup
             && role.DeviceUsersManagement
             && role.SuspendUsers
             && role.BlockUsers));
                tsbExit.Enabled = true;

                if (role.AttendanceDetailReport)
                {
                }
                if (role.AttendanceSummaryReport)
                {
                }
                if (role.BlockUsers)
                {
                }
                if (role.CardManagement)
                {
                }
                if (role.Company)
                {
                }
                if (role.DeviceSetup)
                {
                }
                if (role.DeviceUsersManagement)
                {
                }
                if (role.DutySchedules)
                {
                }
                if (role.DutyShifts)
                {
                }
                if (role.Enrollment)
                {
                }
                if (role.ImportUser)
                {
                }
                if (role.Logins)
                {
                }
                if (role.SuspendUsers)
                {
                }
                if (role.TimeSheetReport)
                {
                }
                if (role.UserInfo)
                {
                }
                if (role.UserListReports)
                {
                }


                //setupToolStripMenuItem.Enabled = role
                //userManagementToolStripMenuItem.Enabled = role
                //deviceManagementToolStripMenuItem.Enabled = role
                //reportsToolStripMenuItem.Enabled = role
                //tsbUsers.Enabled = role
                //tsbImport.Enabled = role
                //tsbSchedule.Enabled = role
                //tspLive.Enabled = role
                //tsbTodayAt.Enabled = role



                //companyToolStripMenuItem.Enabled = role.Company;
                //deviceToolStripMenuItem.Enabled = role.DeviceSetup;
                //dutyShiftsToolStripMenuItem.Enabled = role.DutyShifts;
                //cardManagementToolStripMenuItem.Enabled = role.CardManagement;
                //rolesToolStripMenuItem.Enabled = role.Role;
                //loginsToolStripMenuItem.Enabled = role.Logins;
                //importFromExcelToolStripMenuItem.Enabled = role.ImportUser;
                //userInformationToolStripMenuItem.Enabled = role.UserInfo;
                //dutySchedulesToolStripMenuItem.Enabled = role.DutySchedules;
                //deviceUsersToolStripMenuItem.Enabled = role.DeviceUsersManagement;
                //suspendedUsersToolStripMenuItem.Enabled = role.SuspendUsers;
                //blockedUsersToolStripMenuItem.Enabled = role.BlockUsers;
                //userListsToolStripMenuItem.Enabled = role.UserListReports;
                //timeSheetToolStripMenuItem.Enabled = role.TimeSheetReport;
                //attendanceDetailToolStripMenuItem.Enabled = role.AttendanceDetailReport;
                //SummarytoolStripMenuItem.Enabled = role.AttendanceSummaryReport;

                //tsbImport.Enabled = role.ImportUser;
                //tsbUsers.Enabled = role.UserInfo;
                //tsbSchedule.Enabled = role.DutySchedules;
                //tsbTodayAt.Enabled = role.AttendanceDetailReport;
            }
        }

        void disableMenu()
        {
            foreach (ToolStripMenuItem menu in menuHolder.Items)
            {
                foreach (ToolStripMenuItem item in menu.DropDownItems)
                {
                    item.Enabled = false;
                }
            }

            foreach (ToolStripButton menu in toolsHolder.Items)
            {
                menu.Enabled = false;
            }
        }
        private void logReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void timeSheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Attendance at = new Attendance();
            at.DateLabel = "Select Month";
            at.ReportLabel = "Time Sheet";
            at.reportTitle = "Time Sheet Report";
            //at.rbTimeSheet_CheckedChanged();
            at.Timesheet = true;
            at.ShowDialog();
        }

        private void dailyAttendanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Attendance at = new Attendance();
            at.ReportLabel = "Daily Attendance";
            at.DateLabel = "Select Date";

            //at.rbDailyAttendance_CheckedChanged();
            at.dailyAttendance = true;
            at.ShowDialog();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Attendance at = new Attendance();
            at.DateLabel = "Select Month";
            at.ReportLabel = "Monthly Summary";
            at.reportTitle = "Attendance Summary Report";
            //at.rbAttendanceSummary_CheckedChanged();
            at.summary = true;
            at.ShowDialog();
        }

        private void userInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frmUserMaster f = new Forms.frmUserMaster();
            //f.MdiParent = this;
            //frmUserInfo f = new frmUserInfo();
            f.Show();

        }

        private void cardManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCardMaster f = new FrmCardMaster();
            f.ShowDialog();
        }

        private void deviceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGetMac f = new frmGetMac();
            f.ShowDialog();
        }

        private void logToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLive f = new frmLive();
            f.ShowDialog();
        }

        private void tsbUsers_Click(object sender, EventArgs e)
        {
            //panel1.Visible = false;
            //panel2.Visible = false;
            //panel3.Visible = false;

            Forms.frmUserMaster f = new Forms.frmUserMaster();
            //panel3.Controls.Add(f);
            //f.MdiParent = this;
            //frmUserInfo f = new frmUserInfo();
            //f.TopMost = true;
            f.Show();
        }

        private void tsbImport_Click(object sender, EventArgs e)
        {
            frmImportUsers f = new frmImportUsers();
            f.ShowDialog();
        }

        private void tsbSchedule_Click(object sender, EventArgs e)
        {
            frmShift f = new frmShift();
            f.ShowDialog();
        }

        private void tspLive_Click(object sender, EventArgs e)
        {
            frmLive f = new frmLive();
            f.ShowDialog();
        }

        private void tsbExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tsbTodayAt_Click(object sender, EventArgs e)
        {
            Attendance at = new Attendance();
            at.ReportLabel = "Daily Attendance";
            at.DateLabel = "Select Date";
            at.DateEditable = false;
            //at.rbDailyAttendance_CheckedChanged();
            at.dailyAttendance = true;
            at.ShowDialog();
        }

        private void userListsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmUserInfoReport().ShowDialog();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            ExtendApi.FasTerminate();
            Environment.Exit(0);
        }

        private void myWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = initializeFAS();

        }

        private void myWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            int ret = (int)e.Result;
            if (ret == (int)ErrorCode.ERR_SUCCESS)
                lblStatus.Text = "FAS Server Connected";
            else
                lblStatus.Text = "FAS Server Not Connected. You can connect FAS Server manually => " + ExtendErr.GetErrorMessage(ret);
        }

        private void setPicturesPathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPhotoPath p = new frmPhotoPath();
            p.ShowDialog();
        }

        private void registrationDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmUserInfoReport().ShowDialog();
        }

        private void attendanceDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAttendanceDetail f = new FASClient.frmAttendanceDetail();
            f.ShowDialog();
        }

        private void generalSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Building f = new Building();
            //frmSettings f = new frmSettings();
            f.ShowDialog();
        }

        private void blockedUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAllowBlock f = new frmAllowBlock();
            f.mode = OperationMode.AllowBlock;
            f.ShowDialog();
        }

        private void deviceUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSendRetrive f = new frmSendRetrive();
            f.mode = OperationMode.SendRetrieve;
            f.ShowDialog();
        }

        private void timeSlotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTimeSlot f = new frmTimeSlot();
            f.Show();
        }

        private void connectFASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            myWorker.RunWorkerAsync();
        }

        private void couponReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHostelReport frm = new frmHostelReport();
            frm.ShowDialog();
        }

        private void dailyLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Attendance at = new Attendance();
            at.ReportLabel = "Daily Log";
            at.DateLabel = "Select Date";

            //at.rbDailyAttendance_CheckedChanged();
            at.dailyLog = true;
            at.ShowDialog();
        }

        private void DenialUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Selection s = new Selection();
            s.ShowDialog();

            //frmDenial frmdenial = new frmDenial();
            //frmdenial.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.ddspak.com");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.paf-iast.edu.pk/");
        }

        private void denialVisitorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVisDenial frmVisdenial = new frmVisDenial();
            frmVisdenial.ShowDialog();
        }

        private void menuHolder_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void deviceManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            denialVisitorsToolStripMenuItem.Enabled = true;
        }

        private void vehicleRegistrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVehicle vehicle = new frmVehicle();
            vehicle.ShowDialog();
        }

        private void deviceMonitoringToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void deviceMonitorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDevMonitoring frm = new frmDevMonitoring();
            frm.Show();
        }

        private void deviceLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDevicesLog frm = new frmDevicesLog();
            frm.Show();
        }

        private void syncOfflineRecordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOfflineDataSync frm = new frmOfflineDataSync();
            frm.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolsHolder_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblreportTitle_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if(userInformationToolStripMenuItem.Enabled)
            {
                Forms.frmUserMaster f = new Forms.frmUserMaster();
                f.Show();

            }
        }

        private void panel14_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (vehicleRegistrationToolStripMenuItem.Enabled)
            {
                Forms.frmVehicle f = new Forms.frmVehicle();
                f.Show();

            }
        }

        private void panel15_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (denialVisitorsToolStripMenuItem.Enabled)
            {
                Forms.frmVisDenial f = new Forms.frmVisDenial();
                f.Show();

            }
        }

        private void panel16_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            if (deviceMonitoringToolStripMenuItem.Enabled)
            {
                Forms.frmDevMonitoring f = new Forms.frmDevMonitoring();
                f.Show();

            }
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_MouseHover(object sender, EventArgs e)
        {
            // pictureBox4.Size += new Size(100, 50);
           
           
        }

        private void panel15_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            pictureBox4.BackColor = Color.FromArgb(179, 179, 179);
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.BackColor = Color.Transparent;
        }

        private void pictureBox5_MouseEnter(object sender, EventArgs e)
        {
            pictureBox5.BackColor = Color.FromArgb(179, 179, 179);
        }

        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            pictureBox5.BackColor = Color.Transparent;
        }

        private void pictureBox6_MouseEnter(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.FromArgb(179, 179, 179);
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.Transparent;
        }

        private void pictureBox7_MouseEnter(object sender, EventArgs e)
        {
            pictureBox7.BackColor = Color.FromArgb(179, 179, 179);
        }

        private void pictureBox7_MouseLeave(object sender, EventArgs e)
        {
            pictureBox7.BackColor = Color.Transparent;
        }

        private void pictureBox8_MouseEnter(object sender, EventArgs e)
        {
            pictureBox8.BackColor = Color.FromArgb(179, 179, 179);
        }

        private void pictureBox8_MouseLeave(object sender, EventArgs e)
        {
            pictureBox8.BackColor = Color.Transparent;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            var smtp = new SmtpClient
            {
                //Host = "mail.ddspak.com",
                Host = "smtp.gmail.com",
                Port = 25,
                EnableSsl = false,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                //Credentials = new NetworkCredential("tech@ddspak.com", "Masood@Hateem@2019")
                Credentials = new NetworkCredential("techsuppdds@gmail.com", "Ddsrfid@246")
            };

            using (var message = new MailMessage("techsuppdds@gmail.com", "iamusamawaheed@gmail.com")
            {
                Subject = "test",
                Body = "test",
                IsBodyHtml = true
            })

                try
                {
                    smtp.Send(message);
                }
                catch (Exception ex)
                {
                    // ViewBag.Message = "Error sent.";
                }
            //EmailTemplate em = new EmailTemplate();
            //em.Email("Testing!!!!!!!!!!!!!");
        }

        private void liveAttendanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLive frm = new frmLive();
            frm.Show();
        }
    }
}
