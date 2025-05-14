namespace FASClient.Forms
{
    partial class frmDenial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDenial));
            this.lblreportTitle = new System.Windows.Forms.Label();
            this.rbResident = new System.Windows.Forms.RadioButton();
            this.rbVisitor = new System.Windows.Forms.RadioButton();
            this.rbFaculty = new System.Windows.Forms.RadioButton();
            this.rbStudent = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cboMode = new System.Windows.Forms.ComboBox();
            this.lblBrowse = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboSeries = new System.Windows.Forms.ComboBox();
            this.cboDept = new System.Windows.Forms.ComboBox();
            this.rbFile = new System.Windows.Forms.RadioButton();
            this.rbDept = new System.Windows.Forms.RadioButton();
            this.txtDept = new System.Windows.Forms.TextBox();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.rbCode = new System.Windows.Forms.RadioButton();
            this.lvUsers = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Eminute = new System.Windows.Forms.TextBox();
            this.Ehour = new System.Windows.Forms.TextBox();
            this.Sminute = new System.Windows.Forms.TextBox();
            this.Shour = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboDevice = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chkPermanent = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtEnd = new System.Windows.Forms.DateTimePicker();
            this.dtStart = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnShowBlockedUsers = new System.Windows.Forms.Button();
            this.btnAllow = new System.Windows.Forms.Button();
            this.btnBlock = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.myWorker = new System.ComponentModel.BackgroundWorker();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblreportTitle
            // 
            this.lblreportTitle.BackColor = System.Drawing.Color.Teal;
            this.lblreportTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblreportTitle.Font = new System.Drawing.Font("Segoe UI Light", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblreportTitle.ForeColor = System.Drawing.Color.White;
            this.lblreportTitle.Location = new System.Drawing.Point(0, 0);
            this.lblreportTitle.Name = "lblreportTitle";
            this.lblreportTitle.Size = new System.Drawing.Size(903, 41);
            this.lblreportTitle.TabIndex = 110;
            this.lblreportTitle.Text = "Denial Users Setting";
            this.lblreportTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rbResident
            // 
            this.rbResident.AutoSize = true;
            this.rbResident.BackColor = System.Drawing.Color.Transparent;
            this.rbResident.Location = new System.Drawing.Point(653, 44);
            this.rbResident.Name = "rbResident";
            this.rbResident.Size = new System.Drawing.Size(67, 17);
            this.rbResident.TabIndex = 111;
            this.rbResident.Text = "Resident";
            this.rbResident.UseVisualStyleBackColor = false;
            this.rbResident.Visible = false;
            this.rbResident.CheckedChanged += new System.EventHandler(this.rbFilterCheckChange);
            // 
            // rbVisitor
            // 
            this.rbVisitor.AutoSize = true;
            this.rbVisitor.BackColor = System.Drawing.Color.Transparent;
            this.rbVisitor.Location = new System.Drawing.Point(440, 44);
            this.rbVisitor.Name = "rbVisitor";
            this.rbVisitor.Size = new System.Drawing.Size(53, 17);
            this.rbVisitor.TabIndex = 112;
            this.rbVisitor.Text = "Visitor";
            this.rbVisitor.UseVisualStyleBackColor = false;
            this.rbVisitor.Visible = false;
            this.rbVisitor.CheckedChanged += new System.EventHandler(this.rbFilterCheckChange);
            // 
            // rbFaculty
            // 
            this.rbFaculty.AutoSize = true;
            this.rbFaculty.BackColor = System.Drawing.Color.Transparent;
            this.rbFaculty.Location = new System.Drawing.Point(805, 44);
            this.rbFaculty.Name = "rbFaculty";
            this.rbFaculty.Size = new System.Drawing.Size(86, 17);
            this.rbFaculty.TabIndex = 113;
            this.rbFaculty.Text = "Staff/Faculty";
            this.rbFaculty.UseVisualStyleBackColor = false;
            this.rbFaculty.CheckedChanged += new System.EventHandler(this.rbFilterCheckChange);
            // 
            // rbStudent
            // 
            this.rbStudent.AutoSize = true;
            this.rbStudent.BackColor = System.Drawing.Color.Transparent;
            this.rbStudent.Checked = true;
            this.rbStudent.Location = new System.Drawing.Point(739, 44);
            this.rbStudent.Name = "rbStudent";
            this.rbStudent.Size = new System.Drawing.Size(62, 17);
            this.rbStudent.TabIndex = 114;
            this.rbStudent.TabStop = true;
            this.rbStudent.Text = "Student";
            this.rbStudent.UseVisualStyleBackColor = false;
            this.rbStudent.CheckedChanged += new System.EventHandler(this.rbFilterCheckChange);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.btnRemove);
            this.groupBox2.Controls.Add(this.btnAdd);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cboMode);
            this.groupBox2.Controls.Add(this.lblBrowse);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cboSeries);
            this.groupBox2.Controls.Add(this.cboDept);
            this.groupBox2.Controls.Add(this.rbFile);
            this.groupBox2.Controls.Add(this.rbDept);
            this.groupBox2.Controls.Add(this.txtDept);
            this.groupBox2.Controls.Add(this.txtFile);
            this.groupBox2.Controls.Add(this.txtName);
            this.groupBox2.Controls.Add(this.txtCode);
            this.groupBox2.Controls.Add(this.rbCode);
            this.groupBox2.Location = new System.Drawing.Point(12, 67);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(879, 141);
            this.groupBox2.TabIndex = 115;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Select Users";
            // 
            // btnRemove
            // 
            this.btnRemove.BackColor = System.Drawing.Color.Indigo;
            this.btnRemove.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnRemove.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Indigo;
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.ForeColor = System.Drawing.Color.White;
            this.btnRemove.Location = new System.Drawing.Point(697, 99);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(166, 31);
            this.btnRemove.TabIndex = 11;
            this.btnRemove.Text = "Remove Selected User(s)";
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.Purple;
            this.btnAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.BlueViolet;
            this.btnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Purple;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(577, 99);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(114, 31);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "Add User(s)";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(687, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Mode";
            // 
            // cboMode
            // 
            this.cboMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMode.FormattingEnabled = true;
            this.cboMode.Items.AddRange(new object[] {
            "FP+Card",
            "Fingers Only",
            "Cards Only"});
            this.cboMode.Location = new System.Drawing.Point(736, 68);
            this.cboMode.Name = "cboMode";
            this.cboMode.Size = new System.Drawing.Size(127, 21);
            this.cboMode.TabIndex = 9;
            // 
            // lblBrowse
            // 
            this.lblBrowse.AutoSize = true;
            this.lblBrowse.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBrowse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblBrowse.Location = new System.Drawing.Point(468, 102);
            this.lblBrowse.Name = "lblBrowse";
            this.lblBrowse.Size = new System.Drawing.Size(53, 19);
            this.lblBrowse.TabIndex = 6;
            this.lblBrowse.Text = "Browse";
            this.lblBrowse.Visible = false;
            this.lblBrowse.Click += new System.EventHandler(this.lblBrowse_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(527, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Series";
            this.label1.Visible = false;
            // 
            // cboSeries
            // 
            this.cboSeries.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSeries.Enabled = false;
            this.cboSeries.FormattingEnabled = true;
            this.cboSeries.Location = new System.Drawing.Point(577, 68);
            this.cboSeries.Name = "cboSeries";
            this.cboSeries.Size = new System.Drawing.Size(89, 21);
            this.cboSeries.TabIndex = 7;
            this.cboSeries.Visible = false;
            // 
            // cboDept
            // 
            this.cboDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDept.FormattingEnabled = true;
            this.cboDept.Location = new System.Drawing.Point(156, 68);
            this.cboDept.Name = "cboDept";
            this.cboDept.Size = new System.Drawing.Size(365, 21);
            this.cboDept.TabIndex = 5;
            this.cboDept.SelectedIndexChanged += new System.EventHandler(this.cboDept_SelectedIndexChanged);
            // 
            // rbFile
            // 
            this.rbFile.AutoSize = true;
            this.rbFile.BackColor = System.Drawing.Color.Transparent;
            this.rbFile.Location = new System.Drawing.Point(21, 102);
            this.rbFile.Name = "rbFile";
            this.rbFile.Size = new System.Drawing.Size(99, 17);
            this.rbFile.TabIndex = 4;
            this.rbFile.Tag = "1";
            this.rbFile.Text = "Import From File";
            this.rbFile.UseVisualStyleBackColor = false;
            this.rbFile.Visible = false;
            // 
            // rbDept
            // 
            this.rbDept.AutoSize = true;
            this.rbDept.BackColor = System.Drawing.Color.Transparent;
            this.rbDept.Location = new System.Drawing.Point(21, 68);
            this.rbDept.Name = "rbDept";
            this.rbDept.Size = new System.Drawing.Size(80, 17);
            this.rbDept.TabIndex = 4;
            this.rbDept.Tag = "1";
            this.rbDept.Text = "Department";
            this.rbDept.UseVisualStyleBackColor = false;
            // 
            // txtDept
            // 
            this.txtDept.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDept.Enabled = false;
            this.txtDept.Location = new System.Drawing.Point(577, 37);
            this.txtDept.Name = "txtDept";
            this.txtDept.Size = new System.Drawing.Size(286, 20);
            this.txtDept.TabIndex = 3;
            // 
            // txtFile
            // 
            this.txtFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFile.Enabled = false;
            this.txtFile.Location = new System.Drawing.Point(156, 99);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(306, 20);
            this.txtFile.TabIndex = 2;
            this.txtFile.Visible = false;
            // 
            // txtName
            // 
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Enabled = false;
            this.txtName.Location = new System.Drawing.Point(272, 37);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(299, 20);
            this.txtName.TabIndex = 2;
            // 
            // txtCode
            // 
            this.txtCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCode.Location = new System.Drawing.Point(156, 37);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(110, 20);
            this.txtCode.TabIndex = 1;
            this.txtCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCode_KeyPress);
            // 
            // rbCode
            // 
            this.rbCode.AutoSize = true;
            this.rbCode.BackColor = System.Drawing.Color.Transparent;
            this.rbCode.Checked = true;
            this.rbCode.Location = new System.Drawing.Point(21, 37);
            this.rbCode.Name = "rbCode";
            this.rbCode.Size = new System.Drawing.Size(83, 17);
            this.rbCode.TabIndex = 0;
            this.rbCode.TabStop = true;
            this.rbCode.Tag = "1";
            this.rbCode.Text = "Code/Roll #";
            this.rbCode.UseVisualStyleBackColor = false;
            this.rbCode.CheckedChanged += new System.EventHandler(this.rbCode_CheckedChanged);
            // 
            // lvUsers
            // 
            this.lvUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader8,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.BID});
            this.lvUsers.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvUsers.FullRowSelect = true;
            this.lvUsers.HideSelection = false;
            this.lvUsers.Location = new System.Drawing.Point(12, 214);
            this.lvUsers.Name = "lvUsers";
            this.lvUsers.Size = new System.Drawing.Size(879, 275);
            this.lvUsers.TabIndex = 116;
            this.lvUsers.UseCompatibleStateImageBehavior = false;
            this.lvUsers.View = System.Windows.Forms.View.Details;
            this.lvUsers.SelectedIndexChanged += new System.EventHandler(this.lvUsers_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Sno";
            this.columnHeader1.Width = 62;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "UID";
            this.columnHeader8.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Code/Roll#";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Name";
            this.columnHeader3.Width = 250;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Designation/Class";
            this.columnHeader4.Width = 200;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Department/Program";
            this.columnHeader5.Width = 250;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "FingerID";
            this.columnHeader6.Width = 0;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "CardID";
            this.columnHeader7.Width = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.Eminute);
            this.groupBox1.Controls.Add(this.Ehour);
            this.groupBox1.Controls.Add(this.Sminute);
            this.groupBox1.Controls.Add(this.Shour);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cboDevice);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.chkPermanent);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dtEnd);
            this.groupBox1.Controls.Add(this.dtStart);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtReason);
            this.groupBox1.Location = new System.Drawing.Point(12, 495);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(879, 112);
            this.groupBox1.TabIndex = 117;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Blocking Criteria";
            // 
            // Eminute
            // 
            this.Eminute.Location = new System.Drawing.Point(672, 19);
            this.Eminute.Name = "Eminute";
            this.Eminute.Size = new System.Drawing.Size(27, 20);
            this.Eminute.TabIndex = 116;
            this.Eminute.Visible = false;
            // 
            // Ehour
            // 
            this.Ehour.Location = new System.Drawing.Point(639, 19);
            this.Ehour.Name = "Ehour";
            this.Ehour.Size = new System.Drawing.Size(27, 20);
            this.Ehour.TabIndex = 117;
            this.Ehour.Visible = false;
            // 
            // Sminute
            // 
            this.Sminute.Location = new System.Drawing.Point(305, 21);
            this.Sminute.Name = "Sminute";
            this.Sminute.Size = new System.Drawing.Size(27, 20);
            this.Sminute.TabIndex = 115;
            this.Sminute.Visible = false;
            // 
            // Shour
            // 
            this.Shour.Location = new System.Drawing.Point(272, 21);
            this.Shour.Name = "Shour";
            this.Shour.Size = new System.Drawing.Size(27, 20);
            this.Shour.TabIndex = 115;
            this.Shour.Visible = false;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(114, 46);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(333, 21);
            this.comboBox1.TabIndex = 114;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(20, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 13);
            this.label7.TabIndex = 113;
            this.label7.Text = "Select Time Slot:";
            // 
            // cboDevice
            // 
            this.cboDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDevice.FormattingEnabled = true;
            this.cboDevice.Location = new System.Drawing.Point(540, 46);
            this.cboDevice.Name = "cboDevice";
            this.cboDevice.Size = new System.Drawing.Size(333, 21);
            this.cboDevice.TabIndex = 114;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(457, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 113;
            this.label6.Text = "Select Device:";
            // 
            // chkPermanent
            // 
            this.chkPermanent.AutoSize = true;
            this.chkPermanent.Location = new System.Drawing.Point(722, 23);
            this.chkPermanent.Name = "chkPermanent";
            this.chkPermanent.Size = new System.Drawing.Size(77, 17);
            this.chkPermanent.TabIndex = 112;
            this.chkPermanent.Text = "Permanent";
            this.chkPermanent.UseVisualStyleBackColor = true;
            this.chkPermanent.Visible = false;
            this.chkPermanent.CheckedChanged += new System.EventHandler(this.chkPermanent_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(455, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "To :";
            this.label4.Visible = false;
            // 
            // dtEnd
            // 
            this.dtEnd.CustomFormat = "dd-MMM-yyyy";
            this.dtEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtEnd.Location = new System.Drawing.Point(491, 19);
            this.dtEnd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Size = new System.Drawing.Size(142, 20);
            this.dtEnd.TabIndex = 111;
            this.dtEnd.Visible = false;
            // 
            // dtStart
            // 
            this.dtStart.CustomFormat = "dd-MMM-yyyy hh-mm-ss";
            this.dtStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtStart.Location = new System.Drawing.Point(115, 21);
            this.dtStart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtStart.Name = "dtStart";
            this.dtStart.Size = new System.Drawing.Size(151, 20);
            this.dtStart.TabIndex = 111;
            this.dtStart.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Reason:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "From :";
            this.label3.Visible = false;
            // 
            // txtReason
            // 
            this.txtReason.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReason.Location = new System.Drawing.Point(115, 79);
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(758, 20);
            this.txtReason.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.btnShowBlockedUsers);
            this.panel1.Controls.Add(this.btnAllow);
            this.panel1.Controls.Add(this.btnBlock);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 613);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(903, 56);
            this.panel1.TabIndex = 118;
            // 
            // btnShowBlockedUsers
            // 
            this.btnShowBlockedUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnShowBlockedUsers.BackColor = System.Drawing.Color.Teal;
            this.btnShowBlockedUsers.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SeaGreen;
            this.btnShowBlockedUsers.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Teal;
            this.btnShowBlockedUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowBlockedUsers.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowBlockedUsers.ForeColor = System.Drawing.Color.White;
            this.btnShowBlockedUsers.Location = new System.Drawing.Point(12, 13);
            this.btnShowBlockedUsers.Name = "btnShowBlockedUsers";
            this.btnShowBlockedUsers.Size = new System.Drawing.Size(153, 31);
            this.btnShowBlockedUsers.TabIndex = 0;
            this.btnShowBlockedUsers.Text = "Show Blocked Users";
            this.btnShowBlockedUsers.UseVisualStyleBackColor = false;
            this.btnShowBlockedUsers.Visible = false;
            this.btnShowBlockedUsers.Click += new System.EventHandler(this.btnShowBlockedUsers_Click);
            // 
            // btnAllow
            // 
            this.btnAllow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAllow.BackColor = System.Drawing.Color.Green;
            this.btnAllow.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SeaGreen;
            this.btnAllow.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green;
            this.btnAllow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAllow.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAllow.ForeColor = System.Drawing.Color.White;
            this.btnAllow.Location = new System.Drawing.Point(577, 13);
            this.btnAllow.Name = "btnAllow";
            this.btnAllow.Size = new System.Drawing.Size(101, 31);
            this.btnAllow.TabIndex = 1;
            this.btnAllow.Text = "Allow";
            this.btnAllow.UseVisualStyleBackColor = false;
            this.btnAllow.Visible = false;
            this.btnAllow.Click += new System.EventHandler(this.btnAllow_Click);
            // 
            // btnBlock
            // 
            this.btnBlock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBlock.BackColor = System.Drawing.Color.OrangeRed;
            this.btnBlock.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Coral;
            this.btnBlock.FlatAppearance.MouseOverBackColor = System.Drawing.Color.OrangeRed;
            this.btnBlock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBlock.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBlock.ForeColor = System.Drawing.Color.White;
            this.btnBlock.Location = new System.Drawing.Point(684, 13);
            this.btnBlock.Name = "btnBlock";
            this.btnBlock.Size = new System.Drawing.Size(101, 31);
            this.btnBlock.TabIndex = 2;
            this.btnBlock.Text = "Block";
            this.btnBlock.UseVisualStyleBackColor = false;
            this.btnBlock.Click += new System.EventHandler(this.btnBlock_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.BackColor = System.Drawing.Color.Chocolate;
            this.btnClear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Firebrick;
            this.btnClear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(470, 13);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(101, 31);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Visible = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.Firebrick;
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Firebrick;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(791, 13);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(101, 31);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "E&xit";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click_1);
            // 
            // myWorker
            // 
            this.myWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.myWorker_DoWork);
            this.myWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.myWorker_RunWorkerCompleted);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // frmDenial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(903, 669);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lvUsers);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.rbResident);
            this.Controls.Add(this.rbVisitor);
            this.Controls.Add(this.rbFaculty);
            this.Controls.Add(this.rbStudent);
            this.Controls.Add(this.lblreportTitle);
            this.MaximizeBox = false;
            this.Name = "frmDenial";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Denial Users";
            this.Load += new System.EventHandler(this.frmDenial_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblreportTitle;
        private System.Windows.Forms.RadioButton rbResident;
        private System.Windows.Forms.RadioButton rbVisitor;
        private System.Windows.Forms.RadioButton rbFaculty;
        private System.Windows.Forms.RadioButton rbStudent;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboMode;
        private System.Windows.Forms.Label lblBrowse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboSeries;
        private System.Windows.Forms.ComboBox cboDept;
        private System.Windows.Forms.RadioButton rbFile;
        private System.Windows.Forms.RadioButton rbDept;
        private System.Windows.Forms.TextBox txtDept;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.RadioButton rbCode;
        private System.Windows.Forms.ListView lvUsers;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader BID;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkPermanent;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtEnd;
        private System.Windows.Forms.DateTimePicker dtStart;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnShowBlockedUsers;
        private System.Windows.Forms.Button btnAllow;
        private System.Windows.Forms.Button btnBlock;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cboDevice;
        private System.Windows.Forms.Label label6;
        private System.ComponentModel.BackgroundWorker myWorker;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox Eminute;
        private System.Windows.Forms.TextBox Ehour;
        private System.Windows.Forms.TextBox Sminute;
        private System.Windows.Forms.TextBox Shour;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label7;
    }
}