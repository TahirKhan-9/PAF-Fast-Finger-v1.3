namespace FASClient.Forms
{
    partial class frmProgressDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProgressDialog));
            this.picProgress = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picProgress)).BeginInit();
            this.SuspendLayout();
            // 
            // picProgress
            // 
            this.picProgress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picProgress.Image = ((System.Drawing.Image)(resources.GetObject("picProgress.Image")));
            this.picProgress.Location = new System.Drawing.Point(5, 5);
            this.picProgress.Name = "picProgress";
            this.picProgress.Size = new System.Drawing.Size(66, 65);
            this.picProgress.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picProgress.TabIndex = 0;
            this.picProgress.TabStop = false;
            // 
            // frmProgressDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Pink;
            this.ClientSize = new System.Drawing.Size(76, 75);
            this.Controls.Add(this.picProgress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmProgressDialog";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmProgressDialog";
            this.Load += new System.EventHandler(this.frmProgressDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picProgress)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picProgress;
    }
}