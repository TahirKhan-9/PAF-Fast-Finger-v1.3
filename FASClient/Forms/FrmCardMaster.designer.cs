namespace FASClient
{
    partial class FrmCardMaster
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
            this.btnMaster = new System.Windows.Forms.Button();
            this.btnErase = new System.Windows.Forms.Button();
            this.btnFormat = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblinfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnMaster
            // 
            this.btnMaster.BackColor = System.Drawing.Color.Teal;
            this.btnMaster.Enabled = false;
            this.btnMaster.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnMaster.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.btnMaster.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SeaGreen;
            this.btnMaster.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaster.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaster.Location = new System.Drawing.Point(71, 51);
            this.btnMaster.Name = "btnMaster";
            this.btnMaster.Size = new System.Drawing.Size(173, 40);
            this.btnMaster.TabIndex = 0;
            this.btnMaster.Text = "Make Master Card";
            this.btnMaster.UseVisualStyleBackColor = false;
            this.btnMaster.Click += new System.EventHandler(this.btnMaster_Click);
            // 
            // btnErase
            // 
            this.btnErase.BackColor = System.Drawing.Color.Teal;
            this.btnErase.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnErase.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.btnErase.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SeaGreen;
            this.btnErase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnErase.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnErase.Location = new System.Drawing.Point(71, 97);
            this.btnErase.Name = "btnErase";
            this.btnErase.Size = new System.Drawing.Size(173, 40);
            this.btnErase.TabIndex = 1;
            this.btnErase.Text = "Erase Card";
            this.btnErase.UseVisualStyleBackColor = false;
            this.btnErase.Click += new System.EventHandler(this.btnErase_Click);
            // 
            // btnFormat
            // 
            this.btnFormat.BackColor = System.Drawing.Color.Teal;
            this.btnFormat.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnFormat.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.btnFormat.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SeaGreen;
            this.btnFormat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFormat.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFormat.Location = new System.Drawing.Point(71, 143);
            this.btnFormat.Name = "btnFormat";
            this.btnFormat.Size = new System.Drawing.Size(173, 42);
            this.btnFormat.TabIndex = 2;
            this.btnFormat.Text = "Format Card";
            this.btnFormat.UseVisualStyleBackColor = false;
            this.btnFormat.Click += new System.EventHandler(this.btnFormat_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(22, 244);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 13);
            this.lblMessage.TabIndex = 3;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Teal;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SeaGreen;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(71, 191);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(173, 42);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "E&xit";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblinfo
            // 
            this.lblinfo.BackColor = System.Drawing.Color.Transparent;
            this.lblinfo.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblinfo.ForeColor = System.Drawing.Color.Black;
            this.lblinfo.Location = new System.Drawing.Point(10, 266);
            this.lblinfo.Name = "lblinfo";
            this.lblinfo.Size = new System.Drawing.Size(299, 19);
            this.lblinfo.TabIndex = 5;
            this.lblinfo.Text = "label1";
            this.lblinfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblinfo.Visible = false;
            // 
            // FrmCardMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(115)))), ((int)(((byte)(170)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(316, 292);
            this.Controls.Add(this.lblinfo);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnFormat);
            this.Controls.Add(this.btnErase);
            this.Controls.Add(this.btnMaster);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.White;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCardMaster";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Card Management";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmCardMaster_FormClosing);
            this.Load += new System.EventHandler(this.FrmCardMaster_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnMaster;
        private System.Windows.Forms.Button btnErase;
        private System.Windows.Forms.Button btnFormat;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblinfo;
    }
}