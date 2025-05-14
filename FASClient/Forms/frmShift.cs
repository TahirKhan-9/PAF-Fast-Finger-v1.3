using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.ApplicationBlocks.Data;

namespace FASClient
{
    public partial class frmShift : Form
    {
        public frmShift()
        {
            InitializeComponent();
            
        }

        private void btnSearchByName_Click(object sender, EventArgs e)
        {
            frmSearch f = new frmSearch();
            f.ShowDialog();
            txtID.Text = f.result;
            txtName.Text = f.name;
            txtUnit.Text = f.dpt;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (rbEMP.Checked)
            {
                ListViewItem item = new ListViewItem(txtID.Text);
                item.SubItems.Add(txtName.Text);
                item.SubItems.Add(txtUnit.Text);

                
                if (!containsItem(item))
                {
                    listView1.Items.Add(item);
                }
            }
            else
            {
                List<Employee> emplist = Cache.employeeList.FindAll(x => x.Department == cbounit.Text);
                foreach (Employee emp in emplist)
                {
                    ListViewItem item = new ListViewItem(emp.Code);
                    item.SubItems.Add(emp.Name);
                    item.SubItems.Add(emp.Department);
                    listView1.Items.Add(item);
                }
            }
        }

        public bool containsItem(ListViewItem item)
        {
            foreach (ListViewItem i in listView1.Items)
            {
                if (i.Text.Equals(item.Text))
                    return true;
            }
            return false;
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if(listView1.SelectedItems.Count != 0)
            listView1.Items.Remove(listView1.SelectedItems[0]);
        }

        private void frmShift_Load(object sender, EventArgs e)
        {
            this.Text = Globals.GetAppTitle() + " v" + Application.ProductVersion;
            rbEMP.Checked = true;
            User u = new User();
            List<string> depts = Cache.employeeList.Select(x => x.Department).Distinct().ToList();
            cbounit.DataSource = depts;

            DataTable dt = new DataTable();
            string query = "select shiftid,shiftName from shifts";
            dt = SqlHelper.ExecuteDataset(Globals.GetConnectionString(), CommandType.Text, query).Tables[0];
            ////foreach (DataRow row in dt.Rows)
            ////{
            ////    cboSunday.Items.Add(row[0].ToString());
            ////    cboMonday.Items.Add(row[0].ToString());
            ////    cboTuesday.Items.Add(row[0].ToString());
            ////    cboWednesday.Items.Add(row[0].ToString());
            ////    cboThursday.Items.Add(row[0].ToString());
            ////    cboFriday.Items.Add(row[0].ToString());
            ////    cboSaturday.Items.Add(row[0].ToString());
            ////}
            cboSunday.DataSource = dt;
            cboSunday.ValueMember = "shiftid";
            cboSunday.DisplayMember = "shiftname";
            cboMonday.DataSource = dt.Copy();
            cboMonday.ValueMember = "shiftid";
            cboMonday.DisplayMember = "shiftname";
            cboTuesday.DataSource = dt.Copy();
            cboTuesday.ValueMember = "shiftid";
            cboTuesday.DisplayMember = "shiftname";
            cboWednesday.DataSource = dt.Copy();
            cboWednesday.ValueMember = "shiftid";
            cboWednesday.DisplayMember = "shiftname";
            cboThursday.DataSource = dt.Copy();
            cboThursday.ValueMember = "shiftid";
            cboThursday.DisplayMember = "shiftname";
            cboFriday.DataSource = dt.Copy();
            cboFriday.ValueMember = "shiftid";
            cboFriday.DisplayMember = "shiftname";
            cboSaturday.DataSource = dt.Copy();
            cboSaturday.ValueMember = "shiftid";
            cboSaturday.DisplayMember = "shiftname";
        }

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                DataTable dt = new DataTable();
                string query = "select Name, DEPARTMENT from [user] where id = " + Convert.ToInt32(txtID.Text) + " ";
                dt = SqlHelper.ExecuteDataset(Globals.GetConnectionString(), CommandType.Text, query).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    txtName.Text = dt.Rows[0][0].ToString();
                    txtUnit.Text = dt.Rows[0][1].ToString();
                }
            }
        }

        

        private void cbounit_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DataTable dt = new DataTable();
            //string query = "select id,Name, DEPARTMENT from [user] where department = '" + cbounit.Text + "' ";
            //dt = SqlHelper.ExecuteDataset(Globals.GetConnectionString(), CommandType.Text, query).Tables[0];
            //if (dt.Rows.Count > 0)
            //{
            //    foreach (DataRow row in dt.Rows)
            //    {
            //        ListViewItem item = new ListViewItem(row[0].ToString());
            //        item.SubItems.Add(row[1].ToString());
            //        item.SubItems.Add(row[2].ToString());
            //        listView1.Items.Add(item);
            //    }
            //}
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
        }

        private void rbEMP_CheckedChanged(object sender, EventArgs e)
        {
            cbounit.Enabled = rbUnit.Checked;
            txtID.Enabled = rbEMP.Checked;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count < 1)
            {
                MessageBox.Show("Select Employee first");
                return;
            }
            if (dtEnd.Value.Date < dtStart.Value.Date)
            {
                MessageBox.Show("Select a valid Date Interval");
                return;
            }
            string empid = "";
            foreach (ListViewItem item in listView1.Items)
            {
                empid+=item.Text+"','";
            }
            empid = empid.Remove(empid.Length - 3, 3);
            string dltquery = "delete from Shiftschedule where userid in ('" + empid + "') and usrDate between '" + dtStart.Value.ToString("dd-MMM-yyyy") + "' and '" + dtEnd.Value.ToString("dd-MMM-yyyy") + "'";
            SqlHelper.ExecuteNonQuery(Globals.GetConnectionString(), CommandType.Text, dltquery);
            string query = "";
            foreach (ListViewItem item in listView1.Items)
            {
                DateTime dateCounter = new DateTime();
                dateCounter = dtStart.Value;
                while (dateCounter <= dtEnd.Value)
                {
                   // ShiftSchedule s = new ShiftSchedule();
                    int shiftid = 0;
                    switch (dateCounter.DayOfWeek)
                    {
                        case DayOfWeek.Sunday:
                            shiftid = Convert.ToInt32(cboSunday.SelectedValue);
                            break;
                        case DayOfWeek.Monday:
                            shiftid = Convert.ToInt32(cboMonday.SelectedValue);
                            break;
                        case DayOfWeek.Tuesday:
                            shiftid = Convert.ToInt32(cboTuesday.SelectedValue);
                            break;
                        case DayOfWeek.Wednesday:
                            shiftid = Convert.ToInt32(cboWednesday.SelectedValue);
                            break;
                        case DayOfWeek.Thursday:
                            shiftid = Convert.ToInt32(cboThursday.SelectedValue);
                            break;
                        case DayOfWeek.Friday:
                            shiftid = Convert.ToInt32(cboFriday.SelectedValue);
                            break;
                        case DayOfWeek.Saturday:
                            shiftid = Convert.ToInt32(cboSaturday.SelectedValue);
                            break;
                            
                    }
                    //s.ShiftID = shiftid;
                    //s.UserID = item.Text;
                    //s.UsrDate = dateCounter.Date;
                    query += "insert into shiftschedule (UserID,usrDate,ShiftID) values('" + item.Text + "','" + dateCounter.ToString("dd-MMM-yyyy") + "'," + shiftid + ");";

                    
                    dateCounter = dateCounter.AddDays(1);
                }
            }

            SqlHelper.ExecuteNonQuery(Globals.GetConnectionString(), CommandType.Text, query);
            MessageBox.Show("Shifts Added Successfully");
        }

        private void rbUnit_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dtStart_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtEnd_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
