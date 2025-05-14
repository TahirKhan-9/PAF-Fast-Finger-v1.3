namespace FASClient
{
    partial class frmAttendanceDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAttendanceDetail));
            this.lblStart = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.pbTracker = new System.Windows.Forms.ProgressBar();
            this.cboDept = new System.Windows.Forms.ComboBox();
            this.chkAllDept = new System.Windows.Forms.CheckBox();
            this.bgWorker = new System.ComponentModel.BackgroundWorker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.rbDept = new System.Windows.Forms.RadioButton();
            this.rbEmp = new System.Windows.Forms.RadioButton();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtDesig = new System.Windows.Forms.TextBox();
            this.txtDept = new System.Windows.Forms.TextBox();
            this.chkSendEmail = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.BackColor = System.Drawing.Color.Transparent;
            this.lblStart.ForeColor = System.Drawing.Color.Black;
            this.lblStart.Location = new System.Drawing.Point(26, 216);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(87, 19);
            this.lblStart.TabIndex = 9;
            this.lblStart.Text = "Date Range :";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(188, 212);
            this.dtpStartDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(123, 25);
            this.dtpStartDate.TabIndex = 10;
            // 
            // pbTracker
            // 
            this.pbTracker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pbTracker.Location = new System.Drawing.Point(26, 286);
            this.pbTracker.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pbTracker.Name = "pbTracker";
            this.pbTracker.Size = new System.Drawing.Size(448, 26);
            this.pbTracker.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pbTracker.TabIndex = 13;
            // 
            // cboDept
            // 
            this.cboDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDept.FormattingEnabled = true;
            this.cboDept.Location = new System.Drawing.Point(188, 75);
            this.cboDept.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboDept.Name = "cboDept";
            this.cboDept.Size = new System.Drawing.Size(286, 25);
            this.cboDept.TabIndex = 3;
            this.cboDept.SelectedIndexChanged += new System.EventHandler(this.cboDept_SelectedIndexChanged);
            // 
            // chkAllDept
            // 
            this.chkAllDept.AutoSize = true;
            this.chkAllDept.BackColor = System.Drawing.Color.Transparent;
            this.chkAllDept.ForeColor = System.Drawing.Color.Black;
            this.chkAllDept.Location = new System.Drawing.Point(138, 77);
            this.chkAllDept.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkAllDept.Name = "chkAllDept";
            this.chkAllDept.Size = new System.Drawing.Size(43, 23);
            this.chkAllDept.TabIndex = 2;
            this.chkAllDept.Text = "All";
            this.chkAllDept.UseVisualStyleBackColor = false;
            this.chkAllDept.CheckedChanged += new System.EventHandler(this.chkAllDept_CheckedChanged);
            // 
            // bgWorker
            // 
            this.bgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorker_DoWork);
            this.bgWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorker_RunWorkerCompleted);
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
            this.panel1.Location = new System.Drawing.Point(0, 330);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(493, 57);
            this.panel1.TabIndex = 14;
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
            this.btnCancel.Location = new System.Drawing.Point(387, 14);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 31);
            this.btnCancel.TabIndex = 1;
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
            this.btnPreview.Location = new System.Drawing.Point(291, 14);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(90, 31);
            this.btnPreview.TabIndex = 0;
            this.btnPreview.Text = "Proceed";
            this.btnPreview.UseVisualStyleBackColor = false;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Teal;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Segoe UI Light", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(493, 41);
            this.label3.TabIndex = 0;
            this.label3.Text = "Attendance Report";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Location = new System.Drawing.Point(344, 212);
            this.dtpEndDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(130, 25);
            this.dtpEndDate.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(321, 214);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 19);
            this.label1.TabIndex = 11;
            this.label1.Text = "-";
            // 
            // rbDept
            // 
            this.rbDept.AutoSize = true;
            this.rbDept.BackColor = System.Drawing.Color.Transparent;
            this.rbDept.ForeColor = System.Drawing.Color.Black;
            this.rbDept.Location = new System.Drawing.Point(30, 75);
            this.rbDept.Name = "rbDept";
            this.rbDept.Size = new System.Drawing.Size(101, 23);
            this.rbDept.TabIndex = 1;
            this.rbDept.TabStop = true;
            this.rbDept.Text = "Department";
            this.rbDept.UseVisualStyleBackColor = false;
            this.rbDept.CheckedChanged += new System.EventHandler(this.rbDept_CheckedChanged);
            // 
            // rbEmp
            // 
            this.rbEmp.AutoSize = true;
            this.rbEmp.BackColor = System.Drawing.Color.Transparent;
            this.rbEmp.ForeColor = System.Drawing.Color.Black;
            this.rbEmp.Location = new System.Drawing.Point(30, 110);
            this.rbEmp.Name = "rbEmp";
            this.rbEmp.Size = new System.Drawing.Size(86, 23);
            this.rbEmp.TabIndex = 4;
            this.rbEmp.TabStop = true;
            this.rbEmp.Text = "Employee";
            this.rbEmp.UseVisualStyleBackColor = false;
            this.rbEmp.CheckedChanged += new System.EventHandler(this.rbEmp_CheckedChanged);
            // 
            // txtCode
            // 
            this.txtCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCode.Location = new System.Drawing.Point(188, 107);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(90, 25);
            this.txtCode.TabIndex = 5;
            this.txtCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCode_KeyPress);
            // 
            // txtName
            // 
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Enabled = false;
            this.txtName.Location = new System.Drawing.Point(277, 107);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(197, 25);
            this.txtName.TabIndex = 6;
            // 
            // txtDesig
            // 
            this.txtDesig.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDesig.Enabled = false;
            this.txtDesig.Location = new System.Drawing.Point(188, 138);
            this.txtDesig.Name = "txtDesig";
            this.txtDesig.Size = new System.Drawing.Size(286, 25);
            this.txtDesig.TabIndex = 7;
            // 
            // txtDept
            // 
            this.txtDept.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDept.Enabled = false;
            this.txtDept.Location = new System.Drawing.Point(188, 169);
            this.txtDept.Name = "txtDept";
            this.txtDept.Size = new System.Drawing.Size(286, 25);
            this.txtDept.TabIndex = 8;
            // 
            // chkSendEmail
            // 
            this.chkSendEmail.AutoSize = true;
            this.chkSendEmail.BackColor = System.Drawing.Color.Transparent;
            this.chkSendEmail.ForeColor = System.Drawing.Color.Teal;
            this.chkSendEmail.Location = new System.Drawing.Point(188, 248);
            this.chkSendEmail.Name = "chkSendEmail";
            this.chkSendEmail.Size = new System.Drawing.Size(226, 23);
            this.chkSendEmail.TabIndex = 15;
            this.chkSendEmail.Text = "Send Email to Reporting Persons";
            this.chkSendEmail.UseVisualStyleBackColor = false;
            this.chkSendEmail.Visible = false;
            // 
            // frmAttendanceDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(493, 387);
            this.Controls.Add(this.chkSendEmail);
            this.Controls.Add(this.txtDept);
            this.Controls.Add(this.txtDesig);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.rbEmp);
            this.Controls.Add(this.rbDept);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.chkAllDept);
            this.Controls.Add(this.cboDept);
            this.Controls.Add(this.lblStart);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.pbTracker);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "frmAttendanceDetail";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Attendance";
            this.Load += new System.EventHandler(this.Attendance_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //  private AxCrystal.AxCrystalReport Cr;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.ProgressBar pbTracker;
        private System.Windows.Forms.ComboBox cboDept;
        private System.Windows.Forms.CheckBox chkAllDept;
        private System.ComponentModel.BackgroundWorker bgWorker;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbDept;
        private System.Windows.Forms.RadioButton rbEmp;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtDesig;
        private System.Windows.Forms.TextBox txtDept;
        private System.Windows.Forms.CheckBox chkSendEmail;
    }
}