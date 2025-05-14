namespace FASClient.Forms
{
    partial class frmHostelReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHostelReport));
            this.txtDept = new System.Windows.Forms.TextBox();
            this.txtDesig = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.rbEmp = new System.Windows.Forms.RadioButton();
            this.rbDept = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPreview = new System.Windows.Forms.Button();
            this.bgWorker = new System.ComponentModel.BackgroundWorker();
            this.chkAllDept = new System.Windows.Forms.CheckBox();
            this.cboDept = new System.Windows.Forms.ComboBox();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblStart = new System.Windows.Forms.Label();
            this.chkAllDevices = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDevices = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.pbTracker = new System.Windows.Forms.ProgressBar();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtDept
            // 
            this.txtDept.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDept.Enabled = false;
            this.txtDept.Location = new System.Drawing.Point(188, 169);
            this.txtDept.Name = "txtDept";
            this.txtDept.Size = new System.Drawing.Size(286, 24);
            this.txtDept.TabIndex = 24;
            // 
            // txtDesig
            // 
            this.txtDesig.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDesig.Enabled = false;
            this.txtDesig.Location = new System.Drawing.Point(188, 138);
            this.txtDesig.Name = "txtDesig";
            this.txtDesig.Size = new System.Drawing.Size(286, 24);
            this.txtDesig.TabIndex = 23;
            // 
            // txtName
            // 
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Enabled = false;
            this.txtName.Location = new System.Drawing.Point(277, 107);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(197, 24);
            this.txtName.TabIndex = 22;
            // 
            // txtCode
            // 
            this.txtCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCode.Enabled = false;
            this.txtCode.Location = new System.Drawing.Point(188, 107);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(90, 24);
            this.txtCode.TabIndex = 21;
            this.txtCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCode_KeyPress);
            // 
            // rbEmp
            // 
            this.rbEmp.AutoSize = true;
            this.rbEmp.BackColor = System.Drawing.Color.Transparent;
            this.rbEmp.ForeColor = System.Drawing.Color.Black;
            this.rbEmp.Location = new System.Drawing.Point(30, 110);
            this.rbEmp.Name = "rbEmp";
            this.rbEmp.Size = new System.Drawing.Size(81, 21);
            this.rbEmp.TabIndex = 20;
            this.rbEmp.TabStop = true;
            this.rbEmp.Text = "Employee";
            this.rbEmp.UseVisualStyleBackColor = false;
            this.rbEmp.CheckedChanged += new System.EventHandler(this.rbEmp_CheckedChanged);
            // 
            // rbDept
            // 
            this.rbDept.AutoSize = true;
            this.rbDept.BackColor = System.Drawing.Color.Transparent;
            this.rbDept.ForeColor = System.Drawing.Color.Black;
            this.rbDept.Location = new System.Drawing.Point(30, 75);
            this.rbDept.Name = "rbDept";
            this.rbDept.Size = new System.Drawing.Size(96, 21);
            this.rbDept.TabIndex = 17;
            this.rbDept.TabStop = true;
            this.rbDept.Text = "Department";
            this.rbDept.UseVisualStyleBackColor = false;
            this.rbDept.CheckedChanged += new System.EventHandler(this.rbDept_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(321, 214);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 17);
            this.label1.TabIndex = 27;
            this.label1.Text = "-";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Location = new System.Drawing.Point(344, 212);
            this.dtpEndDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(130, 24);
            this.dtpEndDate.TabIndex = 28;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Teal;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Segoe UI Light", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(490, 41);
            this.label3.TabIndex = 16;
            this.label3.Text = "Hostel Report";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.btnCancel.Location = new System.Drawing.Point(384, 14);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 31);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
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
            this.panel1.Location = new System.Drawing.Point(0, 362);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(490, 57);
            this.panel1.TabIndex = 30;
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
            this.btnPreview.Location = new System.Drawing.Point(288, 14);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(90, 31);
            this.btnPreview.TabIndex = 0;
            this.btnPreview.Text = "Proceed";
            this.btnPreview.UseVisualStyleBackColor = false;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // bgWorker
            // 
            this.bgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorker_DoWork);
            this.bgWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorker_RunWorkerCompleted);
            // 
            // chkAllDept
            // 
            this.chkAllDept.AutoSize = true;
            this.chkAllDept.BackColor = System.Drawing.Color.Transparent;
            this.chkAllDept.ForeColor = System.Drawing.Color.Black;
            this.chkAllDept.Location = new System.Drawing.Point(138, 77);
            this.chkAllDept.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkAllDept.Name = "chkAllDept";
            this.chkAllDept.Size = new System.Drawing.Size(41, 21);
            this.chkAllDept.TabIndex = 18;
            this.chkAllDept.Text = "All";
            this.chkAllDept.UseVisualStyleBackColor = false;
            this.chkAllDept.CheckedChanged += new System.EventHandler(this.chkAllDept_CheckedChanged);
            // 
            // cboDept
            // 
            this.cboDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDept.FormattingEnabled = true;
            this.cboDept.Location = new System.Drawing.Point(188, 75);
            this.cboDept.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboDept.Name = "cboDept";
            this.cboDept.Size = new System.Drawing.Size(286, 23);
            this.cboDept.TabIndex = 19;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(188, 212);
            this.dtpStartDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(123, 24);
            this.dtpStartDate.TabIndex = 26;
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.BackColor = System.Drawing.Color.Transparent;
            this.lblStart.ForeColor = System.Drawing.Color.Black;
            this.lblStart.Location = new System.Drawing.Point(26, 216);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(82, 17);
            this.lblStart.TabIndex = 25;
            this.lblStart.Text = "Date Range :";
            // 
            // chkAllDevices
            // 
            this.chkAllDevices.AutoSize = true;
            this.chkAllDevices.BackColor = System.Drawing.Color.Transparent;
            this.chkAllDevices.ForeColor = System.Drawing.Color.Black;
            this.chkAllDevices.Location = new System.Drawing.Point(138, 259);
            this.chkAllDevices.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkAllDevices.Name = "chkAllDevices";
            this.chkAllDevices.Size = new System.Drawing.Size(41, 21);
            this.chkAllDevices.TabIndex = 31;
            this.chkAllDevices.Text = "All";
            this.chkAllDevices.UseVisualStyleBackColor = false;
            this.chkAllDevices.CheckedChanged += new System.EventHandler(this.chkAllDevices_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(27, 260);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 17);
            this.label2.TabIndex = 33;
            this.label2.Text = "Devices :";
            // 
            // txtDevices
            // 
            this.txtDevices.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDevices.Location = new System.Drawing.Point(188, 258);
            this.txtDevices.Name = "txtDevices";
            this.txtDevices.Size = new System.Drawing.Size(240, 24);
            this.txtDevices.TabIndex = 34;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.BackColor = System.Drawing.Color.Transparent;
            this.lblSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSearch.Font = new System.Drawing.Font("Calibri", 9F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblSearch.Location = new System.Drawing.Point(434, 263);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(39, 14);
            this.lblSearch.TabIndex = 35;
            this.lblSearch.Text = "search";
            this.lblSearch.Click += new System.EventHandler(this.lblSearch_Click);
            // 
            // pbTracker
            // 
            this.pbTracker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pbTracker.Location = new System.Drawing.Point(25, 317);
            this.pbTracker.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pbTracker.Name = "pbTracker";
            this.pbTracker.Size = new System.Drawing.Size(448, 26);
            this.pbTracker.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pbTracker.TabIndex = 36;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(186, 283);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(223, 14);
            this.label4.TabIndex = 37;
            this.label4.Text = "Enter comma seprated IDs of machines.";
            // 
            // frmHostelReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 419);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pbTracker);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtDevices);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chkAllDevices);
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
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.lblStart);
            this.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmHostelReport";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hostel Report";
            this.Load += new System.EventHandler(this.frmHostelReport_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtDept;
        private System.Windows.Forms.TextBox txtDesig;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.RadioButton rbEmp;
        private System.Windows.Forms.RadioButton rbDept;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnPreview;
        private System.ComponentModel.BackgroundWorker bgWorker;
        private System.Windows.Forms.CheckBox chkAllDept;
        private System.Windows.Forms.ComboBox cboDept;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.CheckBox chkAllDevices;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDevices;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.ProgressBar pbTracker;
        private System.Windows.Forms.Label label4;
    }
}