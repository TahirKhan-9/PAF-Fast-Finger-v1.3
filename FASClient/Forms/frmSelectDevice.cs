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
    public partial class frmSelectDevice : Form
    {
        public int facid = 0;
        public List<int> SelectedDevices = new List<int>();
        public bool forReport = false;
        public List<string> Devices = new List<string>();
        
        public frmSelectDevice()
        {
            InitializeComponent();
        }
        public void refreshList()
        {
            lvDetail.Items.Clear();
            FacDefinition f = new FacDefinition();
            DataTable dt = new DataTable();
            dt = f.GetAll();
            foreach (DataRow row in dt.Rows)
            {
                ListViewItem item = new ListViewItem(row["Facid"].ToString());
                item.SubItems.Add(row["FacIP"].ToString());
                item.SubItems.Add(row["Description"].ToString());
                lvDetail.Items.Add(item);
            }
        }
        private void frmSelectDevice_Load(object sender, EventArgs e)
        {
            if (forReport)
            {
                lblTitle.Text = "Select devices from the list for report";
                lvDetail.MultiSelect = true;
            }

            this.Text = Globals.GetAppTitle() + " v" + Application.ProductVersion;
            Globals.MakeTransparent(this, lvDetail, lvDetail.Location.X, lvDetail.Location.Y);
            refreshList();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (lvDetail.CheckedItems.Count == 0)
                return;

            if (forReport)
            {
                SelectDevices();
            }
            else
            {
                foreach (ListViewItem item in lvDetail.Items)
                {
                    if(item.Checked)
                    {
                        facid = Convert.ToInt32(item.Text);
                        SelectedDevices.Add(facid);
                    }
                    
                }
                //ListViewItem item = lvDetail.SelectedItems[0];
                //facid = Convert.ToInt32(item.Text);
            }

            this.Close();
        }
        void SelectDevices()
        {
            Devices = new List<string>();
            foreach (ListViewItem item in lvDetail.SelectedItems)
            {
                Devices.Add(item.SubItems[0].Text);
            }
        }
    }
}
