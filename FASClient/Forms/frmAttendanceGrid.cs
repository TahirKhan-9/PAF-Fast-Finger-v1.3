using FASClient.Classes;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FASClient.Forms
{
    public partial class frmAttendanceGrid : Form
    {
        int index = 0;
        List<string> users = new List<string>();
        public List<AttedanceReportData> data = new List<AttedanceReportData>();
        public bool isCancelled = true;
        List<string> hiddenCols = new List<string>();

        public frmAttendanceGrid()
        {
            InitializeComponent();
            hiddenCols.Add("code");
            hiddenCols.Add("name");
            hiddenCols.Add("designation");
            hiddenCols.Add("department");
            hiddenCols.Add("section");
            hiddenCols.Add("usrdate");
            hiddenCols.Add("dayno");
            hiddenCols.Add("uid");
            hiddenCols.Add("facid");
        }

        private void frmAttendanceGrid_Load(object sender, EventArgs e)
        {
            users = getusers();
            getData(users[index]);
        }

        void getData(string id)
        {
            //listView1.Items.Clear();
            List <AttedanceReportData> list = data.FindAll(x => x.Code == id);

            foreach(var item in list)
            {
                item.UsrDateString = item.USRDate.ToString("dd/MMM/yyyy");
            }

            Employee emp = Cache.employeeList.Find(x => x.Code == list[0].Code);
            txtName.Text = list[0].Name;
            txtDepartment.Text = list[0].Department;
            txtDesignation.Text = list[0].Designation;
            picProfile.Image = emp.GetImage();

            dgvData.DataSource = list;

            foreach (DataGridViewColumn col in dgvData.Columns)
            {
                if (hiddenCols.Contains(col.HeaderText.ToLower()))
                    col.Visible = false;

                if (col.HeaderText.ToLower().Equals("remarks"))
                    col.Width = 400;

                if (col.HeaderText.ToLower().Equals("usrdatestring"))
                {
                    col.HeaderText = "Date";
                }
            }


                txtRecNo.Text = (index + 1).ToString();
        }

        List<string> getusers()
        {
            List<string> list = new List<string>();
            list = data.Select(x => x.Code).Distinct().ToList();
            return list;
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (index == 0)
            {
                MessageBox.Show("Can't move to previous record");
                return;
            }
            index--;
            getData(users[index]);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (index == users.Count - 1)
            {
                MessageBox.Show("Can't move to Next record");
                return;
            }
            index++;
            getData(users[index]);
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            if (index == users.Count - 1)
            {
                MessageBox.Show("Can't move to Next record. This is the Last Record.");
                return;
            }

            index = users.Count - 1;
            getData(users[index]);
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            if (index == 0)
            {
                MessageBox.Show("Can't move to previous record. This is the First Record.");
                return;
            }

            index = 0;
            getData(users[index]);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            isCancelled = false;
            this.Close();
        }

        private void txtRecNo_TextChanged(object sender, EventArgs e)
        {
            //txtRecNo.Text = (Convert.ToInt32(txtRecNo.Text) + 1).ToString();
        }

        private void dgvData_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // save in table
            if (e.RowIndex == -1)
                return;

            string code = dgvData.Rows[e.RowIndex].Cells[0].Value.ToString();
            //MessageBox.Show("Remarks of Rec " + (e.RowIndex+1) + " Changed to " + dgvData.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());

            AttendanceReport record = new AttendanceReport();

            
            record.Code = dgvData.Rows[e.RowIndex].Cells[0].Value.ToString();
            record.Name = dgvData.Rows[e.RowIndex].Cells[1].Value.ToString();
            record.Department = dgvData.Rows[e.RowIndex].Cells[2].Value.ToString();
            record.Designation = dgvData.Rows[e.RowIndex].Cells[3].Value.ToString();
            record.UsrDate =Convert.ToDateTime(dgvData.Rows[e.RowIndex].Cells[6].Value.ToString()).Date;
            record.DayNo = Convert.ToInt32(dgvData.Rows[e.RowIndex].Cells[9].Value);
            string remarks = dgvData.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            record.Remarks = remarks;
            record.Update();
            

            string date = dgvData.Rows[e.RowIndex].Cells[5].Value.ToString();
            int dayno = Convert.ToInt32(dgvData.Rows[e.RowIndex].Cells[9].Value);
            var item = data.Where(x => x.Code == code && x.DayNo.Equals(dayno)).FirstOrDefault();

            string value = dgvData.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            string colName = dgvData.Columns[e.ColumnIndex].HeaderText.ToLower();

            //string remarks = dgvData.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

            if (item != null)
            {
                if (colName.Equals("timein")) {
                    if(!string.IsNullOrEmpty(value))

                    item.TimeIn =value;
                }
                else if (colName.Equals("remarks"))
                    item.Remarks = value;
            }
        }
        
        private void btnFind_Click(object sender, EventArgs e)
        {
            if (users.Contains(txtID.Text))
            {
                index = users.IndexOf(txtID.Text);
                getData(users[index]);
            }
            else
            {
                MessageBox.Show("This ID Does Not Exists in the Current View.");
            }


        }
    }
}
