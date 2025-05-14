namespace FASClient
{
    partial class frmRoles
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRoles));
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.chkUserList = new System.Windows.Forms.CheckBox();
            this.chkTimeSheet = new System.Windows.Forms.CheckBox();
            this.chkAttendanceDetail = new System.Windows.Forms.CheckBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.chkDutySchedules = new System.Windows.Forms.CheckBox();
            this.chkCompany = new System.Windows.Forms.CheckBox();
            this.chkRoles = new System.Windows.Forms.CheckBox();
            this.chkDutyShifts = new System.Windows.Forms.CheckBox();
            this.chkLogins = new System.Windows.Forms.CheckBox();
            this.chkUserInfo = new System.Windows.Forms.CheckBox();
            this.chkImportUser = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chkCardManage = new System.Windows.Forms.CheckBox();
            this.chkSummary = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.lbRoles = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chkSuspendUsers = new System.Windows.Forms.CheckBox();
            this.chkDeviceUsers = new System.Windows.Forms.CheckBox();
            this.chkBlockUsers = new System.Windows.Forms.CheckBox();
            this.chkPhotosPath = new System.Windows.Forms.CheckBox();
            this.chkDevice = new System.Windows.Forms.CheckBox();
            this.chkEnrollment = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(258, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Location = new System.Drawing.Point(320, 70);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(392, 25);
            this.txtName.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(736, 54);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Light", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label2.Location = new System.Drawing.Point(3, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 30);
            this.label2.TabIndex = 0;
            this.label2.Text = "Roles Definition";
            // 
            // chkUserList
            // 
            this.chkUserList.AutoSize = true;
            this.chkUserList.BackColor = System.Drawing.Color.Transparent;
            this.chkUserList.ForeColor = System.Drawing.Color.Black;
            this.chkUserList.Location = new System.Drawing.Point(550, 332);
            this.chkUserList.Name = "chkUserList";
            this.chkUserList.Size = new System.Drawing.Size(81, 23);
            this.chkUserList.TabIndex = 21;
            this.chkUserList.Text = "User List";
            this.chkUserList.UseVisualStyleBackColor = false;
            // 
            // chkTimeSheet
            // 
            this.chkTimeSheet.AutoSize = true;
            this.chkTimeSheet.BackColor = System.Drawing.Color.Transparent;
            this.chkTimeSheet.ForeColor = System.Drawing.Color.Black;
            this.chkTimeSheet.Location = new System.Drawing.Point(550, 362);
            this.chkTimeSheet.Name = "chkTimeSheet";
            this.chkTimeSheet.Size = new System.Drawing.Size(95, 23);
            this.chkTimeSheet.TabIndex = 22;
            this.chkTimeSheet.Text = "Time Sheet";
            this.chkTimeSheet.UseVisualStyleBackColor = false;
            this.chkTimeSheet.Visible = false;
            // 
            // chkAttendanceDetail
            // 
            this.chkAttendanceDetail.AutoSize = true;
            this.chkAttendanceDetail.BackColor = System.Drawing.Color.Transparent;
            this.chkAttendanceDetail.ForeColor = System.Drawing.Color.Black;
            this.chkAttendanceDetail.Location = new System.Drawing.Point(549, 393);
            this.chkAttendanceDetail.Name = "chkAttendanceDetail";
            this.chkAttendanceDetail.Size = new System.Drawing.Size(137, 23);
            this.chkAttendanceDetail.TabIndex = 23;
            this.chkAttendanceDetail.Text = "Attendance Detail";
            this.chkAttendanceDetail.UseVisualStyleBackColor = false;
            this.chkAttendanceDetail.Visible = false;
            // 
            // txtID
            // 
            this.txtID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtID.Location = new System.Drawing.Point(320, 101);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(71, 25);
            this.txtID.TabIndex = 3;
            this.txtID.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(516, 301);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 19);
            this.label12.TabIndex = 20;
            this.label12.Text = "Reports";
            // 
            // chkDutySchedules
            // 
            this.chkDutySchedules.AutoSize = true;
            this.chkDutySchedules.BackColor = System.Drawing.Color.Transparent;
            this.chkDutySchedules.ForeColor = System.Drawing.Color.Black;
            this.chkDutySchedules.Location = new System.Drawing.Point(550, 243);
            this.chkDutySchedules.Name = "chkDutySchedules";
            this.chkDutySchedules.Size = new System.Drawing.Size(147, 23);
            this.chkDutySchedules.TabIndex = 19;
            this.chkDutySchedules.Text = "Vehicle Registration";
            this.chkDutySchedules.UseVisualStyleBackColor = false;
            // 
            // chkCompany
            // 
            this.chkCompany.AutoSize = true;
            this.chkCompany.BackColor = System.Drawing.Color.Transparent;
            this.chkCompany.ForeColor = System.Drawing.Color.Black;
            this.chkCompany.Location = new System.Drawing.Point(284, 158);
            this.chkCompany.Name = "chkCompany";
            this.chkCompany.Size = new System.Drawing.Size(141, 23);
            this.chkCompany.TabIndex = 5;
            this.chkCompany.Text = "Device Monitoring";
            this.chkCompany.UseVisualStyleBackColor = false;
            // 
            // chkRoles
            // 
            this.chkRoles.AutoSize = true;
            this.chkRoles.BackColor = System.Drawing.Color.Transparent;
            this.chkRoles.ForeColor = System.Drawing.Color.Black;
            this.chkRoles.Location = new System.Drawing.Point(284, 243);
            this.chkRoles.Name = "chkRoles";
            this.chkRoles.Size = new System.Drawing.Size(60, 23);
            this.chkRoles.TabIndex = 10;
            this.chkRoles.Text = "Roles";
            this.chkRoles.UseVisualStyleBackColor = false;
            this.chkRoles.CheckedChanged += new System.EventHandler(this.chkRoles_CheckedChanged);
            // 
            // chkDutyShifts
            // 
            this.chkDutyShifts.AutoSize = true;
            this.chkDutyShifts.BackColor = System.Drawing.Color.Transparent;
            this.chkDutyShifts.ForeColor = System.Drawing.Color.Black;
            this.chkDutyShifts.Location = new System.Drawing.Point(283, 332);
            this.chkDutyShifts.Name = "chkDutyShifts";
            this.chkDutyShifts.Size = new System.Drawing.Size(95, 23);
            this.chkDutyShifts.TabIndex = 8;
            this.chkDutyShifts.Text = "Duty Shifts";
            this.chkDutyShifts.UseVisualStyleBackColor = false;
            this.chkDutyShifts.Visible = false;
            // 
            // chkLogins
            // 
            this.chkLogins.AutoSize = true;
            this.chkLogins.BackColor = System.Drawing.Color.Transparent;
            this.chkLogins.ForeColor = System.Drawing.Color.Black;
            this.chkLogins.Location = new System.Drawing.Point(283, 274);
            this.chkLogins.Name = "chkLogins";
            this.chkLogins.Size = new System.Drawing.Size(68, 23);
            this.chkLogins.TabIndex = 11;
            this.chkLogins.Text = "Logins";
            this.chkLogins.UseVisualStyleBackColor = false;
            this.chkLogins.CheckedChanged += new System.EventHandler(this.chkLogins_CheckedChanged);
            // 
            // chkUserInfo
            // 
            this.chkUserInfo.AutoSize = true;
            this.chkUserInfo.BackColor = System.Drawing.Color.Transparent;
            this.chkUserInfo.ForeColor = System.Drawing.Color.Black;
            this.chkUserInfo.Location = new System.Drawing.Point(550, 185);
            this.chkUserInfo.Name = "chkUserInfo";
            this.chkUserInfo.Size = new System.Drawing.Size(84, 23);
            this.chkUserInfo.TabIndex = 18;
            this.chkUserInfo.Text = "User Info";
            this.chkUserInfo.UseVisualStyleBackColor = false;
            // 
            // chkImportUser
            // 
            this.chkImportUser.AutoSize = true;
            this.chkImportUser.BackColor = System.Drawing.Color.Transparent;
            this.chkImportUser.ForeColor = System.Drawing.Color.Black;
            this.chkImportUser.Location = new System.Drawing.Point(550, 158);
            this.chkImportUser.Name = "chkImportUser";
            this.chkImportUser.Size = new System.Drawing.Size(102, 23);
            this.chkImportUser.TabIndex = 17;
            this.chkImportUser.Text = "Import User";
            this.chkImportUser.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(258, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "Set up";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(516, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 19);
            this.label4.TabIndex = 16;
            this.label4.Text = "User Management";
            // 
            // chkCardManage
            // 
            this.chkCardManage.AutoSize = true;
            this.chkCardManage.BackColor = System.Drawing.Color.Transparent;
            this.chkCardManage.ForeColor = System.Drawing.Color.Black;
            this.chkCardManage.Location = new System.Drawing.Point(284, 214);
            this.chkCardManage.Name = "chkCardManage";
            this.chkCardManage.Size = new System.Drawing.Size(107, 23);
            this.chkCardManage.TabIndex = 9;
            this.chkCardManage.Text = "Mifare Utility";
            this.chkCardManage.UseVisualStyleBackColor = false;
            this.chkCardManage.CheckedChanged += new System.EventHandler(this.chkCardManage_CheckedChanged);
            // 
            // chkSummary
            // 
            this.chkSummary.AutoSize = true;
            this.chkSummary.BackColor = System.Drawing.Color.Transparent;
            this.chkSummary.ForeColor = System.Drawing.Color.Black;
            this.chkSummary.Location = new System.Drawing.Point(550, 423);
            this.chkSummary.Name = "chkSummary";
            this.chkSummary.Size = new System.Drawing.Size(160, 23);
            this.chkSummary.TabIndex = 24;
            this.chkSummary.Text = "Attendance Summary";
            this.chkSummary.UseVisualStyleBackColor = false;
            this.chkSummary.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Teal;
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.btnEdit);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.btnExit);
            this.panel2.Controls.Add(this.btnRemove);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(0, 558);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(736, 57);
            this.panel2.TabIndex = 25;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Chocolate;
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Chocolate;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Coral;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(534, 14);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 31);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Clear";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.BackColor = System.Drawing.Color.Teal;
            this.btnEdit.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnEdit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.btnEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSeaGreen;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(340, 13);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(90, 31);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Update";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.Teal;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSeaGreen;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(244, 14);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 31);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.Firebrick;
            this.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Firebrick;
            this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(630, 14);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(90, 31);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.BackColor = System.Drawing.Color.Teal;
            this.btnRemove.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnRemove.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.btnRemove.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSeaGreen;
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.ForeColor = System.Drawing.Color.White;
            this.btnRemove.Location = new System.Drawing.Point(436, 14);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(90, 31);
            this.btnRemove.TabIndex = 2;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // lbRoles
            // 
            this.lbRoles.FormattingEnabled = true;
            this.lbRoles.ItemHeight = 17;
            this.lbRoles.Location = new System.Drawing.Point(10, 62);
            this.lbRoles.Margin = new System.Windows.Forms.Padding(10);
            this.lbRoles.Name = "lbRoles";
            this.lbRoles.Size = new System.Drawing.Size(222, 480);
            this.lbRoles.TabIndex = 0;
            this.lbRoles.SelectedIndexChanged += new System.EventHandler(this.lbRoles_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(258, 370);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 19);
            this.label5.TabIndex = 12;
            this.label5.Text = "Device Management";
            // 
            // chkSuspendUsers
            // 
            this.chkSuspendUsers.AutoSize = true;
            this.chkSuspendUsers.BackColor = System.Drawing.Color.Transparent;
            this.chkSuspendUsers.ForeColor = System.Drawing.Color.Black;
            this.chkSuspendUsers.Location = new System.Drawing.Point(284, 426);
            this.chkSuspendUsers.Name = "chkSuspendUsers";
            this.chkSuspendUsers.Size = new System.Drawing.Size(118, 23);
            this.chkSuspendUsers.TabIndex = 14;
            this.chkSuspendUsers.Text = "Suspend Users";
            this.chkSuspendUsers.UseVisualStyleBackColor = false;
            // 
            // chkDeviceUsers
            // 
            this.chkDeviceUsers.AutoSize = true;
            this.chkDeviceUsers.BackColor = System.Drawing.Color.Transparent;
            this.chkDeviceUsers.ForeColor = System.Drawing.Color.Black;
            this.chkDeviceUsers.Location = new System.Drawing.Point(284, 397);
            this.chkDeviceUsers.Name = "chkDeviceUsers";
            this.chkDeviceUsers.Size = new System.Drawing.Size(123, 23);
            this.chkDeviceUsers.TabIndex = 13;
            this.chkDeviceUsers.Text = "Send/Get Users";
            this.chkDeviceUsers.UseVisualStyleBackColor = false;
            // 
            // chkBlockUsers
            // 
            this.chkBlockUsers.AutoSize = true;
            this.chkBlockUsers.BackColor = System.Drawing.Color.Transparent;
            this.chkBlockUsers.ForeColor = System.Drawing.Color.Black;
            this.chkBlockUsers.Location = new System.Drawing.Point(284, 454);
            this.chkBlockUsers.Name = "chkBlockUsers";
            this.chkBlockUsers.Size = new System.Drawing.Size(98, 23);
            this.chkBlockUsers.TabIndex = 15;
            this.chkBlockUsers.Text = "Block Users";
            this.chkBlockUsers.UseVisualStyleBackColor = false;
            // 
            // chkPhotosPath
            // 
            this.chkPhotosPath.AutoSize = true;
            this.chkPhotosPath.BackColor = System.Drawing.Color.Transparent;
            this.chkPhotosPath.ForeColor = System.Drawing.Color.Black;
            this.chkPhotosPath.Location = new System.Drawing.Point(284, 303);
            this.chkPhotosPath.Name = "chkPhotosPath";
            this.chkPhotosPath.Size = new System.Drawing.Size(150, 23);
            this.chkPhotosPath.TabIndex = 6;
            this.chkPhotosPath.Text = "Profile Pictures Path";
            this.chkPhotosPath.UseVisualStyleBackColor = false;
            this.chkPhotosPath.Visible = false;
            // 
            // chkDevice
            // 
            this.chkDevice.AutoSize = true;
            this.chkDevice.BackColor = System.Drawing.Color.Transparent;
            this.chkDevice.ForeColor = System.Drawing.Color.Black;
            this.chkDevice.Location = new System.Drawing.Point(284, 185);
            this.chkDevice.Name = "chkDevice";
            this.chkDevice.Size = new System.Drawing.Size(107, 23);
            this.chkDevice.TabIndex = 7;
            this.chkDevice.Text = "Device Setup";
            this.chkDevice.UseVisualStyleBackColor = false;
            // 
            // chkEnrollment
            // 
            this.chkEnrollment.AutoSize = true;
            this.chkEnrollment.BackColor = System.Drawing.Color.Transparent;
            this.chkEnrollment.ForeColor = System.Drawing.Color.Black;
            this.chkEnrollment.Location = new System.Drawing.Point(549, 214);
            this.chkEnrollment.Name = "chkEnrollment";
            this.chkEnrollment.Size = new System.Drawing.Size(94, 23);
            this.chkEnrollment.TabIndex = 26;
            this.chkEnrollment.Text = "Enrollment";
            this.chkEnrollment.UseVisualStyleBackColor = false;
            // 
            // frmRoles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(736, 615);
            this.Controls.Add(this.chkEnrollment);
            this.Controls.Add(this.chkDevice);
            this.Controls.Add(this.chkPhotosPath);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.chkSuspendUsers);
            this.Controls.Add(this.chkDeviceUsers);
            this.Controls.Add(this.chkBlockUsers);
            this.Controls.Add(this.lbRoles);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.chkSummary);
            this.Controls.Add(this.chkCardManage);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chkLogins);
            this.Controls.Add(this.chkUserInfo);
            this.Controls.Add(this.chkImportUser);
            this.Controls.Add(this.chkCompany);
            this.Controls.Add(this.chkRoles);
            this.Controls.Add(this.chkDutyShifts);
            this.Controls.Add(this.chkDutySchedules);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.chkAttendanceDetail);
            this.Controls.Add(this.chkTimeSheet);
            this.Controls.Add(this.chkUserList);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRoles";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Roles Definition";
            this.Load += new System.EventHandler(this.frmRoles_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkUserList;
        private System.Windows.Forms.CheckBox chkTimeSheet;
        private System.Windows.Forms.CheckBox chkAttendanceDetail;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox chkDutySchedules;
        private System.Windows.Forms.CheckBox chkCompany;
        private System.Windows.Forms.CheckBox chkRoles;
        private System.Windows.Forms.CheckBox chkDutyShifts;
        private System.Windows.Forms.CheckBox chkLogins;
        private System.Windows.Forms.CheckBox chkUserInfo;
        private System.Windows.Forms.CheckBox chkImportUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkCardManage;
        private System.Windows.Forms.CheckBox chkSummary;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.ListBox lbRoles;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkSuspendUsers;
        private System.Windows.Forms.CheckBox chkDeviceUsers;
        private System.Windows.Forms.CheckBox chkBlockUsers;
        private System.Windows.Forms.CheckBox chkPhotosPath;
        private System.Windows.Forms.CheckBox chkDevice;
        private System.Windows.Forms.CheckBox chkEnrollment;
    }
}