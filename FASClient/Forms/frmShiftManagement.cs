using FASClient.Forms;
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
    public partial class frmShiftManagement : Form
    {
        public frmShiftManagement()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Shifts s = new Shifts();
            s.name = txtShiftName.Text;
            s.timein = TimeSpan.Parse(dtStartTime.Value.ToString("HH:mm:ss"));
            s.timeout = TimeSpan.Parse(dtEndTime.Value.ToString("HH:mm:ss"));
            s.start_timein = TimeSpan.Parse(dtMinST.Value.ToString("HH:mm:ss"));
            s.start_timeout = TimeSpan.Parse(dtMinET.Value.ToString("HH:mm:ss"));
            s.end_timein = TimeSpan.Parse(dtMaxST.Value.ToString("HH:mm:ss"));
            s.end_timeout = TimeSpan.Parse(dtMaxET.Value.ToString("HH:mm:ss"));

            if (s.timein == s.timeout)
            {
                new frmMessageBox(MessageBoxType.Alert, "Start time can not equal to End Time").ShowDialog();
                return;
            }
            else if (s.start_timeout > s.timeout)
            {
                new frmMessageBox(MessageBoxType.Alert, "Min End time can not greater than End Time").ShowDialog();
                return;
            }
            else if (s.end_timeout < s.timeout)
            {
                new frmMessageBox(MessageBoxType.Alert, "Max End time can not less than End Time").ShowDialog();
                return;
            }
            else if (s.start_timein == s.start_timeout)
            {
                new frmMessageBox(MessageBoxType.Alert, "Min Start time can not equal to Min End Time").ShowDialog();
                return;
            }
            else if (s.start_timein > s.timein)
            {
                new frmMessageBox(MessageBoxType.Alert, "Min Start time can not greater than Start Time").ShowDialog();
                return;
            }
            else if (s.end_timein == s.end_timeout)
            {
                new frmMessageBox(MessageBoxType.Alert, "Max Start time can not equal to Max End Time").ShowDialog();
                return;
            }
            else if (s.end_timein < s.timein)
            {
                new frmMessageBox(MessageBoxType.Alert, "Max Start time can not less than Start Time").ShowDialog();
                return;
            }
            
            

            if (Convert.ToInt32(lblID.Text) > 0)
            {
                s.id=Convert.ToInt32(lblID.Text);
                s.Update();
                MessageBox.Show("Shift Updated Successfully");
            }
            else
            {
                int result = s.Save();

                MessageBox.Show("Shift Added Successfully");
            }
            clear();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Sure to Remove this shift","",MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                return;
            if (Convert.ToInt32(lblID.Text) > 0)
            {
                Shifts s = new Shifts();
                s.Delete(Convert.ToInt32(lblID.Text));
                MessageBox.Show("Shift Deleted Successfully");
                clear();
            }
            else
                MessageBox.Show("Search Shift");
        }
        public void clear()
        {
            txtShiftName.Text = "";
            dtStartTime.Text = "00:00:00";
            dtEndTime.Text = "00:00:00";
            dtMinST.Text = "00:00:00";
            dtMinET.Text = "00:00:00";
            dtMaxST.Text = "00:00:00";
            dtMaxET.Text = "00:00:00";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            frmSearchShift f = new frmSearchShift();
            f.ShowDialog();
            if (string.IsNullOrEmpty(f.selectedshift))
                return;

            Shifts s = new Shifts().GetDetail(Convert.ToInt32(f.selectedshift));
            txtShiftName.Text = s.name;
            dtStartTime.Text = s.timein.ToString(); 
            dtEndTime.Text = s.timeout.ToString();
            dtMinST.Text = s.start_timein.ToString();
            dtMinET.Text = s.start_timeout.ToString();
            dtMaxST.Text = s.end_timein.ToString();
            dtMaxET.Text = s.end_timeout.ToString();
            lblID.Text = s.id.ToString();
        }

        private void frmShiftManagement_Load(object sender, EventArgs e)
        {
            this.Text = Globals.GetAppTitle() + " v" + Application.ProductVersion;
        }
    }
}
