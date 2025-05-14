using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.ApplicationBlocks.Data;
using Usman.CodeBlocks.Crypto;
using FASClient.Classes;
using System.Globalization;

namespace FASClient
{
    public partial class frmTimeSlot : Form
    {
        private DataTable timeSlot;
        private int Selection = 0;
        private int day ;

        public frmTimeSlot()
        {
            InitializeComponent();
        }

        void ResetFields()
        {
            txtName.Text = "";
            dtEndTime.Value = DateTime.Now;
            dtStartTime.Value = DateTime.Now;
            textBox1.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            button1.Enabled = false;
            button2.Enabled = false;
            btnSave.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Selection == 0)
            {
                TimeSlot ts = new Classes.TimeSlot();
                ts.Name = txtName.Text;
                ts.StartTime = dtStartTime.Value.ToString("HH:mm:ss");
                ts.EndTime = dtEndTime.Value.ToString("HH:mm:ss");
                ts.SDate = dtStart.Value.Date.ToString("dd-MM-yyyy");
                ts.EDate = dtEnd.Value.Date.ToString("dd-MM-yyyy");
                if (ts.Save(Selection))
                {
                    Globals.ShowMessage("Time Slot Created Successfully ...");
                    ResetFields();
                    FillTable();
                }
            }
            else
            if (Selection == 1)
            {
                TimeSlot ts = new Classes.TimeSlot();
                ts.Name = textBox1.Text;
                ts.StartTime = dateTimePicker2.Value.ToString("HH:mm:ss");
                ts.EndTime = dateTimePicker1.Value.ToString("HH:mm:ss");
                ts.WeekDay = checkboxvalue().ToString();
                if (ts.WeekDay != "8")
                    if (ts.Save(Selection))
                    {
                        Globals.ShowMessage("Time Slot Created Successfully ...");
                        ResetFields();
                        FillTable();
                    }
                    else
                    {}
                else
                {
                    Globals.ShowMessage("Please Select the day ...");
                }
            }
        }

        private void edit_Click(object sender, EventArgs e)
        {
            // edit
            if (Selection == 0)
            {
                TimeSlot ts = Cache.timeSlots.Find(x => x.ID == Convert.ToInt32(txtID.Text));
                ts.Name = txtName.Text;
                ts.StartTime = dtStartTime.Text;
                ts.EndTime = dtEndTime.Text;
                ts.SDate = dtStart.Value.ToString("dd-MM-yyyy");
                ts.EDate = dtEnd.Value.ToString("dd-MM-yyyy");
                if (ts.Update(Selection,ts))
                {
                    Globals.ShowMessage("Time Slot Updated Successfully ...");
                    ResetFields();
                    FillTable();
                }
            }
            if (Selection == 1)
            {
                TimeSlot ts = Cache.DaytimeSlots.Find(x => x.ID == Convert.ToInt32(textBox2.Text));
                ts.Name = textBox1.Text;
                ts.StartTime = dateTimePicker2.Text;
                ts.EndTime = dateTimePicker1.Text;

                if (ts.Update(Selection,ts))
                {
                    Globals.ShowMessage("Time Slot Updated Successfully ...");
                    ResetFields();
                    FillTable();
                }
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            // delete
            if(Selection==0)
            {
                TimeSlot ts = Cache.timeSlots.Find(x => x.ID == Convert.ToInt32(txtID.Text));
                if (ts.Delete(Selection))
                {
                    //Cache.timeSlots.Remove(ts);
                    //Cache.ALLtimeSlots.Remove(ts);
                    Globals.ShowMessage("Time Slot Deleted Successfully ...");
                    ResetFields();
                    FillTable();
                }
                else
                {
                    Globals.ShowMessage("Connection Error Please Restart App ...");
                }
            }
            if (Selection == 1)
            {
                TimeSlot ts = Cache.DaytimeSlots.Find(x => x.ID == Convert.ToInt32(textBox2.Text));
                if (ts.Delete(Selection))
                {
                    //Cache.DaytimeSlots.Remove(ts);
                    //Cache.ALLtimeSlots.Remove(ts);
                    Globals.ShowMessage("Time Slot Deleted Successfully ...");
                    ResetFields();
                    FillTable();
                }
                else
                {
                    Globals.ShowMessage("Connection Error Please Restart App ...");
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTimeSlot_Load(object sender, EventArgs e)
        {
            lvTimeSlot.Items.Clear();
            ResetFields();
            FillTable();


        }

        void FillTable()
        {
            if (Selection == 0)
            {
                lvTimeSlot.Items.Clear();
                foreach (TimeSlot ts in Cache.timeSlots)
                {
                    ListViewItem item = new ListViewItem(ts.ID.ToString());
                    item.SubItems.Add(ts.Name);
                    item.SubItems.Add(ts.StartTime);
                    item.SubItems.Add(ts.EndTime);
                    item.SubItems.Add(ts.SDate);
                    item.SubItems.Add(ts.EDate);
                    lvTimeSlot.Items.Add(item);
                }
            }
            if (Selection == 1)
            {
                listView1.Items.Clear();
                foreach (TimeSlot ts in Cache.DaytimeSlots)
                {
                    ListViewItem item = new ListViewItem(ts.ID.ToString());
                    item.SubItems.Add(Constant.weekdays(ts.WeekDay.ToString()));
                    item.SubItems.Add(ts.Name);
                    item.SubItems.Add(ts.StartTime);
                    item.SubItems.Add(ts.EndTime);
                    
                    listView1.Items.Add(item);
                }
            }
        }

        private void lvTimeSlot_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvTimeSlot.SelectedItems.Count == 0)
                return;

            ListViewItem item = lvTimeSlot.SelectedItems[0];
            txtID.Text = item.Text;
            TimeSlot ts = Cache.timeSlots.Find(x => x.ID == Convert.ToInt32(txtID.Text));

            txtName.Text = ts.Name;
            dtStartTime.Text = ts.StartTime;
            dtEndTime.Text = ts.EndTime;
           // dtStart.Value=DateTime.ParseExact("25/03/2017", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            dtStart.Value = DateTime.ParseExact(ts.SDate,"dd-MM-yyyy", CultureInfo.InvariantCulture);
            dtEnd.Value = DateTime.ParseExact(ts.EDate, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            button1.Enabled = true;
            button2.Enabled = true;
            btnSave.Enabled = false;

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
                Selection = 0;
            else
                if (tabControl1.SelectedIndex == 1)

                Selection = 1;
            lvTimeSlot.Items.Clear();
            listView1.Items.Clear();
            ResetFields();
            FillTable();

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
                return;

            ListViewItem item = listView1.SelectedItems[0];
            textBox2.Text = item.Text;
            TimeSlot ts = Cache.DaytimeSlots.Find(x => x.ID == Convert.ToInt32(textBox2.Text));

            textBox1.Text = ts.Name;
            dateTimePicker2.Text = ts.StartTime;
            dateTimePicker1.Text = ts.EndTime;
            button1.Enabled = true;
            button2.Enabled = true;
            btnSave.Enabled = false;
        }
        private int checkboxvalue()
        {
            if (Monday.Checked)
               return day = 2;
            if (Tuesaday.Checked)
                return day = 3;
            if (Wednesday.Checked)
                return day = 4;
            if (Thursaday.Checked)
                return day = 5;
            if (Friday.Checked)
                return day = 6;
            if (Saturday.Checked)
                return day = 7;
            if (Sunday.Checked)
                return day = 1;
            return 0;
        }

    }

   
}
