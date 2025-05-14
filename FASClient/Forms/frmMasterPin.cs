using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FASClient
{
    public partial class frmMasterPin : Form
    {
        public string pin = "";
        public bool isCancelled = true;

        public frmMasterPin()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Enter Pin");
                return;
            } 

            pin = textBox1.Text;
            isCancelled = false;
            this.Close();
        }

        private void frmMasterPin_Load(object sender, EventArgs e)
        {
            textBox1.Text = pin;
        }
    }
}
