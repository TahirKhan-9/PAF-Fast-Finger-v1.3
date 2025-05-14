namespace FASClient.Forms
{
    partial class frmVehicle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVehicle));
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txttagID = new System.Windows.Forms.TextBox();
            this.txtempname = new System.Windows.Forms.TextBox();
            this.txtempID = new System.Windows.Forms.TextBox();
            this.txtvehicleno = new System.Windows.Forms.TextBox();
            this.rbCar = new System.Windows.Forms.RadioButton();
            this.rbBus = new System.Windows.Forms.RadioButton();
            this.txttagUID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
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
            this.panel2.Size = new System.Drawing.Size(363, 57);
            this.panel2.TabIndex = 43;
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
            this.btnExit.Location = new System.Drawing.Point(257, 14);
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
            this.btnSave.Location = new System.Drawing.Point(161, 14);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 31);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(6, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 44;
            this.label1.Text = "TagID/UID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(6, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 45;
            this.label2.Text = "Vehicle No:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(6, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 46;
            this.label3.Text = "Emp ID:";
            // 
            // txttagID
            // 
            this.txttagID.Location = new System.Drawing.Point(69, 12);
            this.txttagID.Name = "txttagID";
            this.txttagID.Size = new System.Drawing.Size(86, 20);
            this.txttagID.TabIndex = 47;
            this.txttagID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txttagID_KeyPress);
            // 
            // txtempname
            // 
            this.txtempname.Location = new System.Drawing.Point(161, 48);
            this.txtempname.Name = "txtempname";
            this.txtempname.Size = new System.Drawing.Size(182, 20);
            this.txtempname.TabIndex = 48;
            // 
            // txtempID
            // 
            this.txtempID.Location = new System.Drawing.Point(69, 48);
            this.txtempID.Name = "txtempID";
            this.txtempID.Size = new System.Drawing.Size(86, 20);
            this.txtempID.TabIndex = 49;
            this.txtempID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtempID_KeyPress);
            this.txtempID.Leave += new System.EventHandler(this.txtempID_Leave);
            // 
            // txtvehicleno
            // 
            this.txtvehicleno.Location = new System.Drawing.Point(69, 81);
            this.txtvehicleno.Name = "txtvehicleno";
            this.txtvehicleno.Size = new System.Drawing.Size(86, 20);
            this.txtvehicleno.TabIndex = 50;
            // 
            // rbCar
            // 
            this.rbCar.AutoSize = true;
            this.rbCar.BackColor = System.Drawing.Color.Transparent;
            this.rbCar.Location = new System.Drawing.Point(204, 83);
            this.rbCar.Name = "rbCar";
            this.rbCar.Size = new System.Drawing.Size(69, 17);
            this.rbCar.TabIndex = 51;
            this.rbCar.TabStop = true;
            this.rbCar.Text = "Car/Jeep";
            this.rbCar.UseVisualStyleBackColor = false;
            // 
            // rbBus
            // 
            this.rbBus.AutoSize = true;
            this.rbBus.BackColor = System.Drawing.Color.Transparent;
            this.rbBus.Location = new System.Drawing.Point(281, 83);
            this.rbBus.Name = "rbBus";
            this.rbBus.Size = new System.Drawing.Size(67, 17);
            this.rbBus.TabIndex = 52;
            this.rbBus.TabStop = true;
            this.rbBus.Text = "Bus/Van";
            this.rbBus.UseVisualStyleBackColor = false;
            // 
            // txttagUID
            // 
            this.txttagUID.Location = new System.Drawing.Point(161, 12);
            this.txttagUID.Name = "txttagUID";
            this.txttagUID.Size = new System.Drawing.Size(182, 20);
            this.txttagUID.TabIndex = 53;
            this.txttagUID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txttagUID_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(162, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 55;
            this.label5.Text = "Type:";
            // 
            // frmVehicle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(363, 175);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txttagUID);
            this.Controls.Add(this.rbBus);
            this.Controls.Add(this.rbCar);
            this.Controls.Add(this.txtvehicleno);
            this.Controls.Add(this.txtempID);
            this.Controls.Add(this.txtempname);
            this.Controls.Add(this.txttagID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmVehicle";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vehicle Registration";
            this.Load += new System.EventHandler(this.frmVehicle_Load);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txttagID;
        private System.Windows.Forms.TextBox txtempname;
        private System.Windows.Forms.TextBox txtempID;
        private System.Windows.Forms.TextBox txtvehicleno;
        private System.Windows.Forms.RadioButton rbCar;
        private System.Windows.Forms.RadioButton rbBus;
        private System.Windows.Forms.TextBox txttagUID;
        private System.Windows.Forms.Label label5;
    }
}