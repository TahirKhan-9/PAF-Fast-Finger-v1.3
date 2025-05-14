using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FASClient.Forms
{
    public partial class frmProgressDialog : Form
    {
        public frmProgressDialog()
        {
            InitializeComponent();
            this.AllowTransparency = true;
            this.TransparencyKey = this.BackColor;
        }

        private void frmProgressDialog_Load(object sender, EventArgs e)
        {

        }
    }
}
