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
    public partial class frmSearchShift : Form
    {
        public string selectedshift = "";
        public frmSearchShift()
        {
            InitializeComponent();
        }
        public void searchList(string q)
        {
            listView1.Items.Clear();
            Shifts s = new Shifts();
            DataTable dt = new DataTable();
            dt = s.GetAll(q);
            foreach (DataRow row in dt.Rows)
            {
                ListViewItem item = new ListViewItem(row["ShiftID"].ToString());
                item.SubItems.Add(row["shiftname"].ToString());
                item.SubItems.Add(Convert.ToDateTime(row["StartTime"].ToString()).ToString("HH:mm:ss"));
                item.SubItems.Add(Convert.ToDateTime(row["EndTime"].ToString()).ToString("HH:mm:ss"));
                listView1.Items.Add(item);
            }
        }
        private void frmSearchShift_Load(object sender, EventArgs e)
        {
            searchList("");
            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==(char)13)
            {
                searchList("select * from shifts where shiftname like '%"+textBox1.Text+"%' ");
            }
        }
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            selectedshift = listView1.SelectedItems[0].Text;
            this.Close();
        }
    }
}
