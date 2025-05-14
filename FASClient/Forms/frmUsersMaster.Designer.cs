namespace FASClient.Forms
{
    partial class frmUserMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUserMaster));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnTest = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnBlockUsers = new System.Windows.Forms.Button();
            this.btnSuspendUsers = new System.Windows.Forms.Button();
            this.btnSendToMachine = new System.Windows.Forms.Button();
            this.btnRegisterCard = new System.Windows.Forms.Button();
            this.btnRegisterFinger = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.lblActiveUsers = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtKeyword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboFields = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.tvSections = new System.Windows.Forms.TreeView();
            this.myWorker = new System.ComponentModel.BackgroundWorker();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.btnTest);
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnRemove);
            this.panel1.Controls.Add(this.btnEdit);
            this.panel1.Controls.Add(this.btnAddNew);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 612);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1084, 60);
            this.panel1.TabIndex = 2;
            // 
            // btnTest
            // 
            this.btnTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTest.BackColor = System.Drawing.Color.OrangeRed;
            this.btnTest.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnTest.FlatAppearance.MouseDownBackColor = System.Drawing.Color.OrangeRed;
            this.btnTest.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Tomato;
            this.btnTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTest.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTest.ForeColor = System.Drawing.Color.White;
            this.btnTest.Location = new System.Drawing.Point(264, 17);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(76, 31);
            this.btnTest.TabIndex = 18;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = false;
            this.btnTest.Visible = false;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.Controls.Add(this.btnBlockUsers);
            this.flowLayoutPanel1.Controls.Add(this.btnSuspendUsers);
            this.flowLayoutPanel1.Controls.Add(this.btnSendToMachine);
            this.flowLayoutPanel1.Controls.Add(this.btnRegisterCard);
            this.flowLayoutPanel1.Controls.Add(this.btnRegisterFinger);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(337, 17);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(648, 31);
            this.flowLayoutPanel1.TabIndex = 17;
            // 
            // btnBlockUsers
            // 
            this.btnBlockUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBlockUsers.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnBlockUsers.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnBlockUsers.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnBlockUsers.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnBlockUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBlockUsers.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBlockUsers.ForeColor = System.Drawing.Color.White;
            this.btnBlockUsers.Location = new System.Drawing.Point(530, 0);
            this.btnBlockUsers.Margin = new System.Windows.Forms.Padding(0);
            this.btnBlockUsers.Name = "btnBlockUsers";
            this.btnBlockUsers.Size = new System.Drawing.Size(118, 31);
            this.btnBlockUsers.TabIndex = 24;
            this.btnBlockUsers.Text = "Block User(s)";
            this.btnBlockUsers.UseVisualStyleBackColor = false;
            this.btnBlockUsers.Click += new System.EventHandler(this.btnBlockUsers_Click);
            // 
            // btnSuspendUsers
            // 
            this.btnSuspendUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSuspendUsers.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnSuspendUsers.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSuspendUsers.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnSuspendUsers.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnSuspendUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuspendUsers.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuspendUsers.ForeColor = System.Drawing.Color.White;
            this.btnSuspendUsers.Location = new System.Drawing.Point(412, 0);
            this.btnSuspendUsers.Margin = new System.Windows.Forms.Padding(0);
            this.btnSuspendUsers.Name = "btnSuspendUsers";
            this.btnSuspendUsers.Size = new System.Drawing.Size(118, 31);
            this.btnSuspendUsers.TabIndex = 23;
            this.btnSuspendUsers.Text = "Suspend User(s)";
            this.btnSuspendUsers.UseVisualStyleBackColor = false;
            this.btnSuspendUsers.Visible = false;
            this.btnSuspendUsers.Click += new System.EventHandler(this.btnSuspendUsers_Click);
            // 
            // btnSendToMachine
            // 
            this.btnSendToMachine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSendToMachine.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnSendToMachine.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSendToMachine.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnSendToMachine.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnSendToMachine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendToMachine.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendToMachine.ForeColor = System.Drawing.Color.White;
            this.btnSendToMachine.Location = new System.Drawing.Point(294, 0);
            this.btnSendToMachine.Margin = new System.Windows.Forms.Padding(0);
            this.btnSendToMachine.Name = "btnSendToMachine";
            this.btnSendToMachine.Size = new System.Drawing.Size(118, 31);
            this.btnSendToMachine.TabIndex = 22;
            this.btnSendToMachine.Text = "Send To Machine";
            this.btnSendToMachine.UseVisualStyleBackColor = false;
            this.btnSendToMachine.Click += new System.EventHandler(this.btnSendToMachine_Click);
            // 
            // btnRegisterCard
            // 
            this.btnRegisterCard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRegisterCard.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnRegisterCard.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnRegisterCard.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnRegisterCard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnRegisterCard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegisterCard.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegisterCard.ForeColor = System.Drawing.Color.White;
            this.btnRegisterCard.Location = new System.Drawing.Point(176, 0);
            this.btnRegisterCard.Margin = new System.Windows.Forms.Padding(0);
            this.btnRegisterCard.Name = "btnRegisterCard";
            this.btnRegisterCard.Size = new System.Drawing.Size(118, 31);
            this.btnRegisterCard.TabIndex = 21;
            this.btnRegisterCard.Text = "Register Card";
            this.btnRegisterCard.UseVisualStyleBackColor = false;
            this.btnRegisterCard.Click += new System.EventHandler(this.btnRegisterCard_Click);
            // 
            // btnRegisterFinger
            // 
            this.btnRegisterFinger.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRegisterFinger.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnRegisterFinger.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnRegisterFinger.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnRegisterFinger.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnRegisterFinger.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegisterFinger.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegisterFinger.ForeColor = System.Drawing.Color.White;
            this.btnRegisterFinger.Location = new System.Drawing.Point(58, 0);
            this.btnRegisterFinger.Margin = new System.Windows.Forms.Padding(0);
            this.btnRegisterFinger.Name = "btnRegisterFinger";
            this.btnRegisterFinger.Size = new System.Drawing.Size(118, 31);
            this.btnRegisterFinger.TabIndex = 20;
            this.btnRegisterFinger.Text = "Manage Fingers";
            this.btnRegisterFinger.UseVisualStyleBackColor = false;
            this.btnRegisterFinger.Click += new System.EventHandler(this.btnRegisterFinger_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Firebrick;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Firebrick;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(988, 17);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(84, 31);
            this.btnClose.TabIndex = 16;
            this.btnClose.Text = "E&xit";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemove.BackColor = System.Drawing.Color.OrangeRed;
            this.btnRemove.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnRemove.FlatAppearance.MouseDownBackColor = System.Drawing.Color.OrangeRed;
            this.btnRemove.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Tomato;
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.ForeColor = System.Drawing.Color.White;
            this.btnRemove.Location = new System.Drawing.Point(159, 17);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(76, 31);
            this.btnRemove.TabIndex = 13;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEdit.BackColor = System.Drawing.Color.Teal;
            this.btnEdit.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnEdit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.btnEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSeaGreen;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(102, 17);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(57, 31);
            this.btnEdit.TabIndex = 12;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAddNew
            // 
            this.btnAddNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddNew.BackColor = System.Drawing.Color.Teal;
            this.btnAddNew.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAddNew.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.btnAddNew.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSeaGreen;
            this.btnAddNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNew.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNew.ForeColor = System.Drawing.Color.White;
            this.btnAddNew.Location = new System.Drawing.Point(12, 17);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(90, 31);
            this.btnAddNew.TabIndex = 10;
            this.btnAddNew.Text = "Add New";
            this.btnAddNew.UseVisualStyleBackColor = false;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // lblActiveUsers
            // 
            this.lblActiveUsers.AutoSize = true;
            this.lblActiveUsers.BackColor = System.Drawing.Color.Transparent;
            this.lblActiveUsers.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblActiveUsers.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblActiveUsers.Location = new System.Drawing.Point(15, 55);
            this.lblActiveUsers.Name = "lblActiveUsers";
            this.lblActiveUsers.Size = new System.Drawing.Size(84, 19);
            this.lblActiveUsers.TabIndex = 7;
            this.lblActiveUsers.Text = "Active Users";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.lblActiveUsers);
            this.panel2.Controls.Add(this.txtKeyword);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.cboFields);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btnSearch);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1084, 103);
            this.panel2.TabIndex = 3;
            // 
            // txtKeyword
            // 
            this.txtKeyword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKeyword.Location = new System.Drawing.Point(609, 70);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.Size = new System.Drawing.Size(381, 23);
            this.txtKeyword.TabIndex = 5;
            this.txtKeyword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtKeyword_KeyPress_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label3.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label3.Location = new System.Drawing.Point(497, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "Search Keyword";
            // 
            // cboFields
            // 
            this.cboFields.FormattingEnabled = true;
            this.cboFields.Location = new System.Drawing.Point(293, 70);
            this.cboFields.Name = "cboFields";
            this.cboFields.Size = new System.Drawing.Size(169, 23);
            this.cboFields.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label2.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label2.Location = new System.Drawing.Point(222, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Search In";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Light", 24F);
            this.label1.ForeColor = System.Drawing.Color.Teal;
            this.label1.Location = new System.Drawing.Point(9, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 45);
            this.label1.TabIndex = 1;
            this.label1.Text = "USERS LIST";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.Indigo;
            this.btnSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DodgerBlue;
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(996, 65);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(80, 28);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dgvUsers
            // 
            this.dgvUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvUsers.Location = new System.Drawing.Point(251, 109);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsers.Size = new System.Drawing.Size(825, 497);
            this.dgvUsers.TabIndex = 8;
            this.dgvUsers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsers_CellContentClick);
            this.dgvUsers.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsers_CellValueChanged);
            this.dgvUsers.SelectionChanged += new System.EventHandler(this.dgvUsers_SelectionChanged);
            this.dgvUsers.Click += new System.EventHandler(this.dgvUsers_Click);
            // 
            // tvSections
            // 
            this.tvSections.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tvSections.Location = new System.Drawing.Point(10, 109);
            this.tvSections.Name = "tvSections";
            this.tvSections.Size = new System.Drawing.Size(235, 496);
            this.tvSections.TabIndex = 7;
            this.tvSections.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvSections_AfterSelect);
            // 
            // myWorker
            // 
            this.myWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.myWorker_DoWork);
            this.myWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.myWorker_RunWorkerCompleted);
            // 
            // frmUserMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1084, 672);
            this.Controls.Add(this.dgvUsers);
            this.Controls.Add(this.tvSections);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "frmUserMaster";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Users List";
            this.Load += new System.EventHandler(this.frmUsersMaster_Load);
            this.panel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblActiveUsers;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtKeyword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboFields;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.TreeView tvSections;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnBlockUsers;
        private System.Windows.Forms.Button btnSuspendUsers;
        private System.Windows.Forms.Button btnSendToMachine;
        private System.Windows.Forms.Button btnRegisterCard;
        private System.Windows.Forms.Button btnRegisterFinger;
        private System.Windows.Forms.Button btnTest;
        private System.ComponentModel.BackgroundWorker myWorker;
    }
}