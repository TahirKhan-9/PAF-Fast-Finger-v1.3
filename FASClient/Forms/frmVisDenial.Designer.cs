namespace FASClient.Forms
{
    partial class frmVisDenial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVisDenial));
            this.txtDept = new System.Windows.Forms.TextBox();
            this.btnSearchByName = new System.Windows.Forms.Label();
            this.cboDepartment = new System.Windows.Forms.ComboBox();
            this.rbUnit = new System.Windows.Forms.RadioButton();
            this.rbEMP = new System.Windows.Forms.RadioButton();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.myWorker = new System.ComponentModel.BackgroundWorker();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtDept
            // 
            this.txtDept.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDept.Enabled = false;
            this.txtDept.Location = new System.Drawing.Point(113, 41);
            this.txtDept.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDept.Name = "txtDept";
            this.txtDept.Size = new System.Drawing.Size(306, 20);
            this.txtDept.TabIndex = 41;
            // 
            // btnSearchByName
            // 
            this.btnSearchByName.AutoSize = true;
            this.btnSearchByName.BackColor = System.Drawing.Color.Transparent;
            this.btnSearchByName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearchByName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchByName.ForeColor = System.Drawing.Color.Blue;
            this.btnSearchByName.Location = new System.Drawing.Point(7, 39);
            this.btnSearchByName.Name = "btnSearchByName";
            this.btnSearchByName.Size = new System.Drawing.Size(54, 14);
            this.btnSearchByName.TabIndex = 40;
            this.btnSearchByName.Text = "[ Search ]";
            // 
            // cboDepartment
            // 
            this.cboDepartment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(187)))), ((int)(((byte)(209)))));
            this.cboDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDepartment.FormattingEnabled = true;
            this.cboDepartment.Items.AddRange(new object[] {
            "Visitors"});
            this.cboDepartment.Location = new System.Drawing.Point(113, 71);
            this.cboDepartment.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboDepartment.Name = "cboDepartment";
            this.cboDepartment.Size = new System.Drawing.Size(307, 21);
            this.cboDepartment.TabIndex = 39;
            this.cboDepartment.Visible = false;
            // 
            // rbUnit
            // 
            this.rbUnit.AutoSize = true;
            this.rbUnit.BackColor = System.Drawing.Color.Transparent;
            this.rbUnit.ForeColor = System.Drawing.Color.Black;
            this.rbUnit.Location = new System.Drawing.Point(10, 73);
            this.rbUnit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbUnit.Name = "rbUnit";
            this.rbUnit.Size = new System.Drawing.Size(80, 17);
            this.rbUnit.TabIndex = 38;
            this.rbUnit.Text = "Department";
            this.rbUnit.UseVisualStyleBackColor = false;
            this.rbUnit.Visible = false;
            // 
            // rbEMP
            // 
            this.rbEMP.AutoSize = true;
            this.rbEMP.BackColor = System.Drawing.Color.Transparent;
            this.rbEMP.Checked = true;
            this.rbEMP.ForeColor = System.Drawing.Color.Black;
            this.rbEMP.Location = new System.Drawing.Point(10, 14);
            this.rbEMP.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbEMP.Name = "rbEMP";
            this.rbEMP.Size = new System.Drawing.Size(53, 17);
            this.rbEMP.TabIndex = 37;
            this.rbEMP.TabStop = true;
            this.rbEMP.Text = "Visitor";
            this.rbEMP.UseVisualStyleBackColor = false;
            this.rbEMP.CheckedChanged += new System.EventHandler(this.rbEMP_CheckedChanged);
            // 
            // txtName
            // 
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Enabled = false;
            this.txtName.Location = new System.Drawing.Point(220, 13);
            this.txtName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 20);
            this.txtName.TabIndex = 36;
            // 
            // txtCode
            // 
            this.txtCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCode.Location = new System.Drawing.Point(113, 13);
            this.txtCode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(104, 20);
            this.txtCode.TabIndex = 35;
            this.txtCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtID_KeyPress);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Teal;
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.btnExit);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(0, 118);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(436, 57);
            this.panel2.TabIndex = 42;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
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
            this.btnExit.Location = new System.Drawing.Point(330, 14);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(90, 31);
            this.btnExit.TabIndex = 7;
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
            this.btnSave.Location = new System.Drawing.Point(234, 14);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 31);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // myWorker
            // 
            this.myWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.myWorker_DoWork);
            this.myWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.myWorker_RunWorkerCompleted);
            // 
            // frmVisDenial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(436, 175);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.txtDept);
            this.Controls.Add(this.btnSearchByName);
            this.Controls.Add(this.cboDepartment);
            this.Controls.Add(this.rbUnit);
            this.Controls.Add(this.rbEMP);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtCode);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmVisDenial";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Visitor Denial";
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDept;
        private System.Windows.Forms.Label btnSearchByName;
        private System.Windows.Forms.ComboBox cboDepartment;
        private System.Windows.Forms.RadioButton rbUnit;
        private System.Windows.Forms.RadioButton rbEMP;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSave;
        private System.ComponentModel.BackgroundWorker myWorker;
    }
}