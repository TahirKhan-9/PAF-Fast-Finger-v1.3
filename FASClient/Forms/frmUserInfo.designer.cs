namespace FASClient
{
    partial class frmUserInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUserInfo));
            this.txtName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFatherName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblDeptField = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblDesigField = new System.Windows.Forms.Label();
            this.btnVerificationForm = new System.Windows.Forms.Button();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.lblIDField = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtCNIC = new System.Windows.Forms.MaskedTextBox();
            this.picUser = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPrintVerification = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnClearImage = new System.Windows.Forms.Button();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpValidity = new System.Windows.Forms.DateTimePicker();
            this.txtContactNo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.picWorker = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.cboDepartment = new System.Windows.Forms.ComboBox();
            this.cboDesignation = new System.Windows.Forms.ComboBox();
            this.chkHostel = new System.Windows.Forms.CheckBox();
            this.txtHostel = new System.Windows.Forms.TextBox();
            this.chkReportingPerson = new System.Windows.Forms.CheckBox();
            this.txtFingerID = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCardID = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboSection = new System.Windows.Forms.ComboBox();
            this.chkKioskPerson = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboSeries = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.picUser)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Location = new System.Drawing.Point(134, 106);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(416, 25);
            this.txtName.TabIndex = 5;
            this.txtName.Leave += new System.EventHandler(this.txtName_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(21, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 19);
            this.label4.TabIndex = 4;
            this.label4.Text = "Name :";
            // 
            // txtFatherName
            // 
            this.txtFatherName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFatherName.Location = new System.Drawing.Point(134, 136);
            this.txtFatherName.Name = "txtFatherName";
            this.txtFatherName.Size = new System.Drawing.Size(416, 25);
            this.txtFatherName.TabIndex = 7;
            this.txtFatherName.Leave += new System.EventHandler(this.txtFatherName_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(21, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 19);
            this.label5.TabIndex = 6;
            this.label5.Text = "Father Name :";
            // 
            // lblDeptField
            // 
            this.lblDeptField.AutoSize = true;
            this.lblDeptField.BackColor = System.Drawing.Color.Transparent;
            this.lblDeptField.ForeColor = System.Drawing.Color.Black;
            this.lblDeptField.Location = new System.Drawing.Point(21, 201);
            this.lblDeptField.Name = "lblDeptField";
            this.lblDeptField.Size = new System.Drawing.Size(90, 19);
            this.lblDeptField.TabIndex = 10;
            this.lblDeptField.Text = "Department :";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(187)))), ((int)(((byte)(209)))));
            this.btnUpdate.Location = new System.Drawing.Point(386, 491);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(81, 39);
            this.btnUpdate.TabIndex = 34;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(21, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 19);
            this.label3.TabIndex = 8;
            this.label3.Text = "CNIC # :";
            // 
            // lblDesigField
            // 
            this.lblDesigField.AutoSize = true;
            this.lblDesigField.BackColor = System.Drawing.Color.Transparent;
            this.lblDesigField.ForeColor = System.Drawing.Color.Black;
            this.lblDesigField.Location = new System.Drawing.Point(21, 231);
            this.lblDesigField.Name = "lblDesigField";
            this.lblDesigField.Size = new System.Drawing.Size(89, 19);
            this.lblDesigField.TabIndex = 12;
            this.lblDesigField.Text = "Designation :";
            // 
            // btnVerificationForm
            // 
            this.btnVerificationForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnVerificationForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(187)))), ((int)(((byte)(209)))));
            this.btnVerificationForm.Location = new System.Drawing.Point(185, 491);
            this.btnVerificationForm.Name = "btnVerificationForm";
            this.btnVerificationForm.Size = new System.Drawing.Size(108, 39);
            this.btnVerificationForm.TabIndex = 32;
            this.btnVerificationForm.Text = "Print Verification Form";
            this.btnVerificationForm.UseVisualStyleBackColor = false;
            this.btnVerificationForm.Visible = false;
            // 
            // btnAddNew
            // 
            this.btnAddNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(187)))), ((int)(((byte)(209)))));
            this.btnAddNew.Location = new System.Drawing.Point(299, 491);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(81, 39);
            this.btnAddNew.TabIndex = 33;
            this.btnAddNew.Text = "Add New";
            this.btnAddNew.UseVisualStyleBackColor = false;
            this.btnAddNew.Visible = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(21, 261);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(72, 19);
            this.label14.TabIndex = 14;
            this.label14.Text = "Category :";
            // 
            // lblIDField
            // 
            this.lblIDField.AutoSize = true;
            this.lblIDField.BackColor = System.Drawing.Color.Transparent;
            this.lblIDField.ForeColor = System.Drawing.Color.Black;
            this.lblIDField.Location = new System.Drawing.Point(21, 80);
            this.lblIDField.Name = "lblIDField";
            this.lblIDField.Size = new System.Drawing.Size(61, 19);
            this.lblIDField.TabIndex = 1;
            this.lblIDField.Text = "Emp ID :";
            // 
            // txtID
            // 
            this.txtID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtID.Location = new System.Drawing.Point(134, 76);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(159, 25);
            this.txtID.TabIndex = 2;
            this.txtID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtID_KeyPress);
            // 
            // txtEmail
            // 
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Location = new System.Drawing.Point(134, 375);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(416, 25);
            this.txtEmail.TabIndex = 21;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(21, 378);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(101, 19);
            this.label15.TabIndex = 20;
            this.label15.Text = "Email Address :";
            // 
            // txtCNIC
            // 
            this.txtCNIC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCNIC.Location = new System.Drawing.Point(134, 167);
            this.txtCNIC.Mask = "#####-#######-#";
            this.txtCNIC.Name = "txtCNIC";
            this.txtCNIC.Size = new System.Drawing.Size(416, 25);
            this.txtCNIC.TabIndex = 9;
            // 
            // picUser
            // 
            this.picUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picUser.Image = global::FASClient.Properties.Resources._283;
            this.picUser.Location = new System.Drawing.Point(575, 76);
            this.picUser.Name = "picUser";
            this.picUser.Size = new System.Drawing.Size(245, 193);
            this.picUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picUser.TabIndex = 46;
            this.picUser.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.btnPrintVerification);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 483);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(832, 57);
            this.panel1.TabIndex = 31;
            // 
            // btnPrintVerification
            // 
            this.btnPrintVerification.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintVerification.BackColor = System.Drawing.Color.Teal;
            this.btnPrintVerification.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnPrintVerification.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.btnPrintVerification.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSeaGreen;
            this.btnPrintVerification.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintVerification.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintVerification.ForeColor = System.Drawing.Color.White;
            this.btnPrintVerification.Location = new System.Drawing.Point(35, 14);
            this.btnPrintVerification.Name = "btnPrintVerification";
            this.btnPrintVerification.Size = new System.Drawing.Size(171, 31);
            this.btnPrintVerification.TabIndex = 0;
            this.btnPrintVerification.Text = "Print Verification Form";
            this.btnPrintVerification.UseVisualStyleBackColor = false;
            this.btnPrintVerification.Click += new System.EventHandler(this.btnPrintVerification_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.BackColor = System.Drawing.Color.Chocolate;
            this.btnClear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Chocolate;
            this.btnClear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Coral;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(634, 14);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(90, 31);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
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
            this.btnExit.Location = new System.Drawing.Point(730, 14);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(90, 31);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "E&xit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
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
            this.btnSave.Location = new System.Drawing.Point(538, 14);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 31);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnImport
            // 
            this.btnImport.BackColor = System.Drawing.Color.Teal;
            this.btnImport.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnImport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.btnImport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSeaGreen;
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImport.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.ForeColor = System.Drawing.Color.White;
            this.btnImport.Location = new System.Drawing.Point(575, 40);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(96, 31);
            this.btnImport.TabIndex = 29;
            this.btnImport.Text = "Browse";
            this.btnImport.UseVisualStyleBackColor = false;
            this.btnImport.Visible = false;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnClearImage
            // 
            this.btnClearImage.BackColor = System.Drawing.Color.Chocolate;
            this.btnClearImage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Chocolate;
            this.btnClearImage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Coral;
            this.btnClearImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearImage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearImage.ForeColor = System.Drawing.Color.White;
            this.btnClearImage.Location = new System.Drawing.Point(724, 40);
            this.btnClearImage.Name = "btnClearImage";
            this.btnClearImage.Size = new System.Drawing.Size(96, 31);
            this.btnClearImage.TabIndex = 30;
            this.btnClearImage.Text = "Clear Image";
            this.btnClearImage.UseVisualStyleBackColor = false;
            this.btnClearImage.Visible = false;
            this.btnClearImage.Click += new System.EventHandler(this.btnClearImage_Click);
            // 
            // txtAddress
            // 
            this.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddress.Location = new System.Drawing.Point(134, 289);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(416, 80);
            this.txtAddress.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(21, 292);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 19);
            this.label2.TabIndex = 18;
            this.label2.Text = "Address :";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.BackColor = System.Drawing.Color.Transparent;
            this.lblDate.ForeColor = System.Drawing.Color.Black;
            this.lblDate.Location = new System.Drawing.Point(571, 346);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(80, 19);
            this.lblDate.TabIndex = 26;
            this.lblDate.Text = "Valid Upto :";
            // 
            // dtpValidity
            // 
            this.dtpValidity.CustomFormat = "dd-MMM-yyyy";
            this.dtpValidity.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpValidity.Location = new System.Drawing.Point(658, 344);
            this.dtpValidity.Name = "dtpValidity";
            this.dtpValidity.Size = new System.Drawing.Size(162, 25);
            this.dtpValidity.TabIndex = 27;
            // 
            // txtContactNo
            // 
            this.txtContactNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtContactNo.Location = new System.Drawing.Point(134, 406);
            this.txtContactNo.Name = "txtContactNo";
            this.txtContactNo.Size = new System.Drawing.Size(416, 25);
            this.txtContactNo.TabIndex = 23;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(21, 409);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 19);
            this.label9.TabIndex = 22;
            this.label9.Text = "Contact # :";
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.Color.SeaGreen;
            this.lblStatus.ForeColor = System.Drawing.Color.White;
            this.lblStatus.Location = new System.Drawing.Point(571, 377);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(249, 54);
            this.lblStatus.TabIndex = 28;
            this.lblStatus.Text = "ACTIVE";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStatus.Click += new System.EventHandler(this.lblStatus_Click);
            // 
            // picWorker
            // 
            this.picWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.picWorker_DoWork);
            this.picWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.picWorker_RunWorkerCompleted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI Light", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Teal;
            this.label1.Location = new System.Drawing.Point(16, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "User Information";
            // 
            // cboDepartment
            // 
            this.cboDepartment.FormattingEnabled = true;
            this.cboDepartment.Location = new System.Drawing.Point(134, 198);
            this.cboDepartment.Name = "cboDepartment";
            this.cboDepartment.Size = new System.Drawing.Size(416, 25);
            this.cboDepartment.TabIndex = 11;
            // 
            // cboDesignation
            // 
            this.cboDesignation.FormattingEnabled = true;
            this.cboDesignation.Location = new System.Drawing.Point(134, 228);
            this.cboDesignation.Name = "cboDesignation";
            this.cboDesignation.Size = new System.Drawing.Size(416, 25);
            this.cboDesignation.TabIndex = 13;
            // 
            // chkHostel
            // 
            this.chkHostel.AutoSize = true;
            this.chkHostel.BackColor = System.Drawing.Color.Transparent;
            this.chkHostel.Location = new System.Drawing.Point(570, 430);
            this.chkHostel.Name = "chkHostel";
            this.chkHostel.Size = new System.Drawing.Size(164, 23);
            this.chkHostel.TabIndex = 24;
            this.chkHostel.Text = "Availing Hostel Facility";
            this.chkHostel.UseVisualStyleBackColor = false;
            this.chkHostel.Visible = false;
            // 
            // txtHostel
            // 
            this.txtHostel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHostel.Location = new System.Drawing.Point(570, 452);
            this.txtHostel.Name = "txtHostel";
            this.txtHostel.Size = new System.Drawing.Size(245, 25);
            this.txtHostel.TabIndex = 25;
            this.txtHostel.Visible = false;
            // 
            // chkReportingPerson
            // 
            this.chkReportingPerson.AutoSize = true;
            this.chkReportingPerson.BackColor = System.Drawing.Color.Transparent;
            this.chkReportingPerson.Location = new System.Drawing.Point(308, 77);
            this.chkReportingPerson.Name = "chkReportingPerson";
            this.chkReportingPerson.Size = new System.Drawing.Size(133, 23);
            this.chkReportingPerson.TabIndex = 3;
            this.chkReportingPerson.Text = "Reporting Person";
            this.chkReportingPerson.UseVisualStyleBackColor = false;
            // 
            // txtFingerID
            // 
            this.txtFingerID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFingerID.Enabled = false;
            this.txtFingerID.Location = new System.Drawing.Point(134, 437);
            this.txtFingerID.Name = "txtFingerID";
            this.txtFingerID.Size = new System.Drawing.Size(141, 25);
            this.txtFingerID.TabIndex = 49;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(21, 440);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 19);
            this.label6.TabIndex = 48;
            this.label6.Text = "Finger ID :";
            // 
            // txtCardID
            // 
            this.txtCardID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCardID.Enabled = false;
            this.txtCardID.Location = new System.Drawing.Point(409, 438);
            this.txtCardID.Name = "txtCardID";
            this.txtCardID.Size = new System.Drawing.Size(141, 25);
            this.txtCardID.TabIndex = 51;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(326, 441);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 19);
            this.label8.TabIndex = 50;
            this.label8.Text = "Card ID :";
            // 
            // cboSection
            // 
            this.cboSection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSection.FormattingEnabled = true;
            this.cboSection.Location = new System.Drawing.Point(134, 260);
            this.cboSection.Name = "cboSection";
            this.cboSection.Size = new System.Drawing.Size(416, 25);
            this.cboSection.TabIndex = 52;
            this.cboSection.SelectedIndexChanged += new System.EventHandler(this.cboSection_SelectedIndexChanged);
            // 
            // chkKioskPerson
            // 
            this.chkKioskPerson.AutoSize = true;
            this.chkKioskPerson.Location = new System.Drawing.Point(449, 77);
            this.chkKioskPerson.Name = "chkKioskPerson";
            this.chkKioskPerson.Size = new System.Drawing.Size(104, 23);
            this.chkKioskPerson.TabIndex = 53;
            this.chkKioskPerson.Text = "Kiosk Admin";
            this.chkKioskPerson.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(567, 295);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 16);
            this.label7.TabIndex = 55;
            this.label7.Text = "Select Building:";
            // 
            // cboSeries
            // 
            this.cboSeries.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSeries.FormattingEnabled = true;
            this.cboSeries.Location = new System.Drawing.Point(647, 292);
            this.cboSeries.Name = "cboSeries";
            this.cboSeries.Size = new System.Drawing.Size(173, 25);
            this.cboSeries.TabIndex = 54;
            // 
            // frmUserInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(832, 540);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cboSeries);
            this.Controls.Add(this.chkKioskPerson);
            this.Controls.Add(this.cboSection);
            this.Controls.Add(this.txtCardID);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtFingerID);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.chkReportingPerson);
            this.Controls.Add(this.txtHostel);
            this.Controls.Add(this.chkHostel);
            this.Controls.Add(this.cboDesignation);
            this.Controls.Add(this.cboDepartment);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.txtContactNo);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dtpValidity);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnClearImage);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.picUser);
            this.Controls.Add(this.txtCNIC);
            this.Controls.Add(this.btnVerificationForm);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblDesigField);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.lblDeptField);
            this.Controls.Add(this.txtFatherName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblIDField);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.btnAddNew);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUserInfo";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Info";
            this.Load += new System.EventHandler(this.frmUserInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picUser)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFatherName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblDeptField;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblDesigField;
        private System.Windows.Forms.Button btnVerificationForm;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblIDField;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.MaskedTextBox txtCNIC;
        private System.Windows.Forms.PictureBox picUser;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnClearImage;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpValidity;
        private System.Windows.Forms.TextBox txtContactNo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblStatus;
        private System.ComponentModel.BackgroundWorker picWorker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboDepartment;
        private System.Windows.Forms.ComboBox cboDesignation;
        private System.Windows.Forms.CheckBox chkHostel;
        private System.Windows.Forms.TextBox txtHostel;
        private System.Windows.Forms.Button btnPrintVerification;
        private System.Windows.Forms.CheckBox chkReportingPerson;
        private System.Windows.Forms.TextBox txtFingerID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCardID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboSection;
        private System.Windows.Forms.CheckBox chkKioskPerson;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboSeries;
    }
}