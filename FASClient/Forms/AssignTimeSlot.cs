using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FASClient.Forms
{
    public partial class AssignTimeSlot : Form
    {
        int x, y;
        public AssignTimeSlot()
        {
            InitializeComponent();
            

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AssignTimeSlot_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = Cache.timeSlots;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "ID";
            comboBox2.DataSource = Cache.RestrictedDevices;
            comboBox2.DisplayMember = "FacIP";
            comboBox2.ValueMember = "FacID";
            //int n = 10;
            //int height = 40;
            //CheckBox box;
            //for (int i = 0; i < 20; i++)
            //{
            //    box = new CheckBox();
            //    box.Tag = i.ToString();
            //    box.Text = "a";
            //    box.AutoSize = true;
            //    //box.Location = new Point(i * 50, height);
            //    y = height * i;
            //    if (y > this.Height)
            //        n = 40;
            //    box.Location = new Point(n,y); //vertical
            //                                                                                                                                 //box.Location = new Point(i * 50, 10); //horizontal
            //    this.Controls.Add(box);
            //}
        }
    }
}
