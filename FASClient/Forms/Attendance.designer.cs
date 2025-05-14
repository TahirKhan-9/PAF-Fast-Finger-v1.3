namespace FASClient
{
    partial class Attendance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Attendance));
            this.pbTracker = new System.Windows.Forms.ProgressBar();
            this.cboDept = new System.Windows.Forms.ComboBox();
            this.lblEmp = new System.Windows.Forms.Label();
            this.lblDept = new System.Windows.Forms.Label();
            this.chkAllDept = new System.Windows.Forms.CheckBox();
            this.chkEmployee = new System.Windows.Forms.CheckBox();
            this.myWorker = new System.ComponentModel.BackgroundWorker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.rbStaff = new System.Windows.Forms.RadioButton();
            this.rbStudents = new System.Windows.Forms.RadioButton();
            this.lblreportTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboEmployee = new System.Windows.Forms.ComboBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rbSBC = new System.Windows.Forms.RadioButton();
            this.groupSBC = new System.Windows.Forms.GroupBox();
            this.groupMS = new System.Windows.Forms.GroupBox();
            this.rbMS = new System.Windows.Forms.RadioButton();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.lblStart = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.panel1.SuspendLayout();
            this.groupSBC.SuspendLayout();
            this.groupMS.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbTracker
            // 
            this.pbTracker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pbTracker.Location = new System.Drawing.Point(12, 340);
            this.pbTracker.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pbTracker.Name = "pbTracker";
            this.pbTracker.Size = new System.Drawing.Size(489, 26);
            this.pbTracker.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pbTracker.TabIndex = 87;
            // 
            // cboDept
            // 
            this.cboDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDept.FormattingEnabled = true;
            this.cboDept.Location = new System.Drawing.Point(171, 52);
            this.cboDept.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboDept.Name = "cboDept";
            this.cboDept.Size = new System.Drawing.Size(305, 25);
            this.cboDept.TabIndex = 95;
            this.cboDept.SelectedIndexChanged += new System.EventHandler(this.cboUnit_SelectedIndexChanged);
            // 
            // lblEmp
            // 
            this.lblEmp.AutoSize = true;
            this.lblEmp.BackColor = System.Drawing.Color.Transparent;
            this.lblEmp.ForeColor = System.Drawing.Color.Black;
            this.lblEmp.Location = new System.Drawing.Point(8, 89);
            this.lblEmp.Name = "lblEmp";
            this.lblEmp.Size = new System.Drawing.Size(81, 19);
            this.lblEmp.TabIndex = 98;
            this.lblEmp.Text = "Employees :";
            // 
            // lblDept
            // 
            this.lblDept.AutoSize = true;
            this.lblDept.BackColor = System.Drawing.Color.Transparent;
            this.lblDept.ForeColor = System.Drawing.Color.Black;
            this.lblDept.Location = new System.Drawing.Point(8, 56);
            this.lblDept.Name = "lblDept";
            this.lblDept.Size = new System.Drawing.Size(83, 19);
            this.lblDept.TabIndex = 99;
            this.lblDept.Text = "Department";
            // 
            // chkAllDept
            // 
            this.chkAllDept.AutoSize = true;
            this.chkAllDept.BackColor = System.Drawing.Color.Transparent;
            this.chkAllDept.Enabled = false;
            this.chkAllDept.ForeColor = System.Drawing.Color.Black;
            this.chkAllDept.Location = new System.Drawing.Point(121, 54);
            this.chkAllDept.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkAllDept.Name = "chkAllDept";
            this.chkAllDept.Size = new System.Drawing.Size(43, 23);
            this.chkAllDept.TabIndex = 100;
            this.chkAllDept.Text = "All";
            this.chkAllDept.UseVisualStyleBackColor = false;
            this.chkAllDept.CheckedChanged += new System.EventHandler(this.chkUnit_CheckedChanged);
            // 
            // chkEmployee
            // 
            this.chkEmployee.AutoSize = true;
            this.chkEmployee.BackColor = System.Drawing.Color.Transparent;
            this.chkEmployee.Enabled = false;
            this.chkEmployee.ForeColor = System.Drawing.Color.Black;
            this.chkEmployee.Location = new System.Drawing.Point(121, 87);
            this.chkEmployee.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkEmployee.Name = "chkEmployee";
            this.chkEmployee.Size = new System.Drawing.Size(43, 23);
            this.chkEmployee.TabIndex = 101;
            this.chkEmployee.Text = "All";
            this.chkEmployee.UseVisualStyleBackColor = false;
            this.chkEmployee.CheckedChanged += new System.EventHandler(this.chkEmployee_CheckedChanged);
            // 
            // myWorker
            // 
            this.myWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorker_DoWork);
            this.myWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorker_RunWorkerCompleted);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnPreview);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 375);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(517, 57);
            this.panel1.TabIndex = 103;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.Firebrick;
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Firebrick;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(411, 14);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 31);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreview.BackColor = System.Drawing.Color.Teal;
            this.btnPreview.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnPreview.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.btnPreview.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSeaGreen;
            this.btnPreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreview.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreview.ForeColor = System.Drawing.Color.White;
            this.btnPreview.Location = new System.Drawing.Point(315, 14);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(90, 31);
            this.btnPreview.TabIndex = 6;
            this.btnPreview.Text = "Proceed";
            this.btnPreview.UseVisualStyleBackColor = false;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // rbStaff
            // 
            this.rbStaff.AutoSize = true;
            this.rbStaff.BackColor = System.Drawing.Color.Transparent;
            this.rbStaff.ForeColor = System.Drawing.Color.Black;
            this.rbStaff.Location = new System.Drawing.Point(99, 22);
            this.rbStaff.Name = "rbStaff";
            this.rbStaff.Size = new System.Drawing.Size(54, 23);
            this.rbStaff.TabIndex = 106;
            this.rbStaff.TabStop = true;
            this.rbStaff.Text = "Staff";
            this.rbStaff.UseVisualStyleBackColor = false;
            this.rbStaff.CheckedChanged += new System.EventHandler(this.rbStaff_CheckedChanged);
            // 
            // rbStudents
            // 
            this.rbStudents.AutoSize = true;
            this.rbStudents.BackColor = System.Drawing.Color.Transparent;
            this.rbStudents.ForeColor = System.Drawing.Color.Black;
            this.rbStudents.Location = new System.Drawing.Point(9, 22);
            this.rbStudents.Name = "rbStudents";
            this.rbStudents.Size = new System.Drawing.Size(75, 23);
            this.rbStudents.TabIndex = 105;
            this.rbStudents.TabStop = true;
            this.rbStudents.Text = "Student";
            this.rbStudents.UseVisualStyleBackColor = false;
            this.rbStudents.CheckedChanged += new System.EventHandler(this.rbStudents_CheckedChanged);
            // 
            // lblreportTitle
            // 
            this.lblreportTitle.BackColor = System.Drawing.Color.Teal;
            this.lblreportTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblreportTitle.Font = new System.Drawing.Font("Segoe UI Light", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblreportTitle.ForeColor = System.Drawing.Color.White;
            this.lblreportTitle.Location = new System.Drawing.Point(0, 0);
            this.lblreportTitle.Name = "lblreportTitle";
            this.lblreportTitle.Size = new System.Drawing.Size(517, 41);
            this.lblreportTitle.TabIndex = 108;
            this.lblreportTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(290, 304);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 19);
            this.label1.TabIndex = 111;
            this.label1.Text = "-";
            // 
            // cboEmployee
            // 
            this.cboEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEmployee.FormattingEnabled = true;
            this.cboEmployee.Location = new System.Drawing.Point(171, 85);
            this.cboEmployee.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboEmployee.Name = "cboEmployee";
            this.cboEmployee.Size = new System.Drawing.Size(305, 25);
            this.cboEmployee.TabIndex = 82;
            // 
            // txtCode
            // 
            this.txtCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCode.Location = new System.Drawing.Point(171, 32);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(306, 25);
            this.txtCode.TabIndex = 113;
            this.txtCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDept_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(8, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 19);
            this.label2.TabIndex = 114;
            this.label2.Text = "Staff / Student Code :";
            // 
            // rbSBC
            // 
            this.rbSBC.AutoSize = true;
            this.rbSBC.BackColor = System.Drawing.Color.Transparent;
            this.rbSBC.ForeColor = System.Drawing.Color.Black;
            this.rbSBC.Location = new System.Drawing.Point(135, 52);
            this.rbSBC.Name = "rbSBC";
            this.rbSBC.Size = new System.Drawing.Size(122, 23);
            this.rbSBC.TabIndex = 115;
            this.rbSBC.TabStop = true;
            this.rbSBC.Text = "Search By Code";
            this.rbSBC.UseVisualStyleBackColor = false;
            this.rbSBC.CheckedChanged += new System.EventHandler(this.rbSBC_CheckedChanged);
            // 
            // groupSBC
            // 
            this.groupSBC.BackColor = System.Drawing.Color.Transparent;
            this.groupSBC.Controls.Add(this.label2);
            this.groupSBC.Controls.Add(this.txtCode);
            this.groupSBC.Location = new System.Drawing.Point(12, 81);
            this.groupSBC.Name = "groupSBC";
            this.groupSBC.Size = new System.Drawing.Size(489, 83);
            this.groupSBC.TabIndex = 116;
            this.groupSBC.TabStop = false;
            this.groupSBC.Text = "Search By Code";
            // 
            // groupMS
            // 
            this.groupMS.BackColor = System.Drawing.Color.Transparent;
            this.groupMS.Controls.Add(this.cboEmployee);
            this.groupMS.Controls.Add(this.cboDept);
            this.groupMS.Controls.Add(this.lblEmp);
            this.groupMS.Controls.Add(this.lblDept);
            this.groupMS.Controls.Add(this.chkAllDept);
            this.groupMS.Controls.Add(this.chkEmployee);
            this.groupMS.Controls.Add(this.rbStudents);
            this.groupMS.Controls.Add(this.rbStaff);
            this.groupMS.Location = new System.Drawing.Point(12, 170);
            this.groupMS.Name = "groupMS";
            this.groupMS.Size = new System.Drawing.Size(489, 125);
            this.groupMS.TabIndex = 117;
            this.groupMS.TabStop = false;
            this.groupMS.Text = "Manual Search";
            // 
            // rbMS
            // 
            this.rbMS.AutoSize = true;
            this.rbMS.BackColor = System.Drawing.Color.Transparent;
            this.rbMS.ForeColor = System.Drawing.Color.Black;
            this.rbMS.Location = new System.Drawing.Point(12, 52);
            this.rbMS.Name = "rbMS";
            this.rbMS.Size = new System.Drawing.Size(117, 23);
            this.rbMS.TabIndex = 118;
            this.rbMS.TabStop = true;
            this.rbMS.Text = "Manual Search";
            this.rbMS.UseVisualStyleBackColor = false;
            this.rbMS.CheckedChanged += new System.EventHandler(this.rbSBC_CheckedChanged);
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Location = new System.Drawing.Point(317, 302);
            this.dtpEndDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(130, 25);
            this.dtpEndDate.TabIndex = 121;
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.BackColor = System.Drawing.Color.Transparent;
            this.lblStart.ForeColor = System.Drawing.Color.Black;
            this.lblStart.Location = new System.Drawing.Point(20, 304);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(87, 19);
            this.lblStart.TabIndex = 119;
            this.lblStart.Text = "Date Range :";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(161, 302);
            this.dtpStartDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(123, 25);
            this.dtpStartDate.TabIndex = 120;
            // 
            // Attendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(517, 432);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.lblStart);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.rbMS);
            this.Controls.Add(this.groupMS);
            this.Controls.Add(this.groupSBC);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rbSBC);
            this.Controls.Add(this.lblreportTitle);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pbTracker);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Attendance";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Attendance";
            this.Load += new System.EventHandler(this.Attendance_Load);
            this.panel1.ResumeLayout(false);
            this.groupSBC.ResumeLayout(false);
            this.groupSBC.PerformLayout();
            this.groupMS.ResumeLayout(false);
            this.groupMS.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ProgressBar pbTracker;
        private System.Windows.Forms.ComboBox cboDept;
        private System.Windows.Forms.Label lblEmp;
        private System.Windows.Forms.Label lblDept;
        private System.Windows.Forms.CheckBox chkAllDept;
        private System.Windows.Forms.CheckBox chkEmployee;
        private System.ComponentModel.BackgroundWorker myWorker;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.RadioButton rbStaff;
        private System.Windows.Forms.RadioButton rbStudents;
        private System.Windows.Forms.Label lblreportTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboEmployee;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rbSBC;
        private System.Windows.Forms.GroupBox groupSBC;
        private System.Windows.Forms.GroupBox groupMS;
        private System.Windows.Forms.RadioButton rbMS;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
    }
}