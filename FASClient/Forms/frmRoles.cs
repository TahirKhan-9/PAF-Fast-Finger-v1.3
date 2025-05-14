using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FASClient
{
    public partial class frmRoles : Form
    {
        public frmRoles()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRoles_Load(object sender, EventArgs e)
        {
            this.Text = Globals.GetAppTitle() + " v" + Application.ProductVersion;
            Globals.MakeTransparent(this, lbRoles, lbRoles.Location.X, lbRoles.Location.Y);
            btnCancel_Click(null, null);
        }

        void ResetFields()
        {
            txtID.Text = "";
            txtName.Text = "";
            chkCompany.Checked = false;
            chkDutyShifts.Checked = false;
            chkRoles.Checked = false;
            chkLogins.Checked = false;
            chkImportUser.Checked = false;
            chkUserInfo.Checked = false;
            chkDutySchedules.Checked = false;
            chkAttendanceDetail.Checked = false;
            chkTimeSheet.Checked = false;
            chkUserList.Checked = false;
            chkCardManage.Checked = false;
            chkSummary.Checked = false;
            chkPhotosPath.Checked = false;
            chkDevice.Checked = false;
            chkDeviceUsers.Checked = false;
            chkSuspendUsers.Checked = false;
            chkEnrollment.Checked = false;
            chkBlockUsers.Checked = false;

        }

        void FillListBox()
        {
            lbRoles.DataSource = null;
            List<Roles> roles = new Roles().GetList();

            if (roles.Count() >= 1)
            {
                lbRoles.DataSource = roles;
                lbRoles.DisplayMember = "Name";
                lbRoles.ValueMember = "ID";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            FillListBox();
            ResetFields();            
            btnEdit.Enabled = false;
            btnSave.Enabled = true;
            btnRemove.Enabled = false;
        }

        void TextBoxFill()
        {
            Roles role = (Roles)lbRoles.SelectedItem;
            txtID.Text = role.ID.ToString();
            txtName.Text = role.Name;
            chkCompany.Checked = role.Company;
            chkDutyShifts.Checked = role.DutyShifts;
            chkRoles.Checked = role.Role;
            chkLogins.Checked = role.Logins;
            chkImportUser.Checked = role.ImportUser;
            chkUserInfo.Checked = role.UserInfo;
            chkDutySchedules.Checked = role.DutySchedules;
            chkAttendanceDetail.Checked = role.AttendanceDetailReport;
            chkTimeSheet.Checked = role.TimeSheetReport;
            chkUserList.Checked = role.UserListReports;
            chkSummary.Checked = role.AttendanceSummaryReport;
            chkCardManage.Checked = role.CardManagement;
            chkPhotosPath.Checked = role.ProfilePhotosSetup;
            chkDevice.Checked = role.DeviceSetup;
            chkDeviceUsers.Checked = role.DeviceUsersManagement;
            chkSuspendUsers.Checked = role.SuspendUsers;
            chkBlockUsers.Checked = role.BlockUsers;
            chkEnrollment.Checked = role.Enrollment;

            btnEdit.Enabled = true;
            btnSave.Enabled = false;
            btnRemove.Enabled = true;
            
        }

        void Save(bool editMode)
        {
            Roles r = new Roles();
            r.Name = txtName.Text;
            r.ImportUser = chkImportUser.Checked;
            r.Company = chkCompany.Checked;
            r.DutyShifts = chkDutyShifts.Checked;
            r.Role = chkRoles.Checked;
            r.Logins = chkLogins.Checked;
            r.UserInfo = chkUserInfo.Checked;
            r.Enrollment = chkEnrollment.Checked;

            r.DutySchedules = chkDutySchedules.Checked;
            r.UserListReports = chkUserList.Checked;
            r.CardManagement = chkCardManage.Checked;
            r.TimeSheetReport = chkTimeSheet.Checked;
            r.AttendanceDetailReport = chkAttendanceDetail.Checked;
            r.AttendanceSummaryReport = chkSummary.Checked;

            r.ProfilePhotosSetup = chkPhotosPath.Checked;
            r.DeviceSetup = chkDevice.Checked;
            r.DeviceUsersManagement = chkDeviceUsers.Checked;
            r.SuspendUsers = chkSuspendUsers.Checked;
            r.BlockUsers = chkBlockUsers.Checked;

            if (!editMode)
            {
                if (r.Save())
                {
                    MessageBox.Show("Role Added Successfully ....");
                    btnCancel_Click(null, null);
                }
            }
            else
            {
                r.ID = Convert.ToInt32(txtID.Text);
                if (r.Update())
                {
                    MessageBox.Show("Role Updated Successfully...");
                    btnCancel_Click(null, null);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Please Enter Role Name First.");
                txtName.Focus();
                return;
            }

            Save(false);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            
            if (!string.IsNullOrEmpty(lbRoles.Text))
            {
                Roles role = (Roles)lbRoles.SelectedItem;
                if (role.isConsumed())
                {
                    Globals.ShowAlert("This Role is used in one or more Logins.\nIt cant be deleted.");
                    return;
                }
                if (role.Delete())
                {
                    MessageBox.Show("Selected Role Removed Successfully ....");
                    btnCancel_Click(null, null);
                }
            }
        }


        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Please Enter Role Name First.");
                txtName.Focus();
                return;
            }

            Save(true);
        }

        private void lbRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lbRoles.Text))
            {
                TextBoxFill();
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void chkManageStudents_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkCardManage_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkLogins_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkRoles_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
