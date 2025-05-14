using FASClient.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UsmanCodeBlocks.Data.Sql;

namespace FASClient.Forms
{
    public partial class allowDenial : Form
    {
        private int deviceID;
        public static List<BlockedUser> FacblockedUsers = new List<BlockedUser>();
        frmProgressDialog progress = new frmProgressDialog();
        FacDefinition a;

        public allowDenial()
        {
            InitializeComponent();
        }

        private void btnAllow_Click(object sender, EventArgs e)
        {
            if (lvUsers.SelectedRows.Count <= 0)
                return;

            string uid = lvUsers.SelectedRows[0].Cells["uid"].Value.ToString();
            List<string> userslist = new List<string>();
            userslist.Add(uid);


            progress.Show();

            myWorker.RunWorkerAsync(userslist);
        }


        private void allowDenial_Load(object sender, EventArgs e)
        {
            try
            {
                cboDevice.DataSource = Cache.RestrictedDevices;
                cboDevice.DisplayMember = "Description";
                cboDevice.ValueMember = "FacID";
                cboFields.Items.Add("Code"); cboFields.Items.Add("Name"); cboFields.Items.Add("Department");
                //deviceID = int.Parse(cboDevice.SelectedValue.ToString());
               // a = Cache.RestrictedDevices.Find(x => x.FacIP == deviceID);
                filltable();
            }
            catch(Exception ex)
            {
                new frmMessageBox(MessageBoxType.Error, "No Restricted Area available!!!!");
            }
            // FacblockedUsers = Globals.ConvertDataTable<BlockedUser>(BlockedUser.GetAllByquery(query));

            //BlockedUser b=  Cache.blockedUsers.BinarySearch(x => x.idFac == a.FacID.ToString());
            //List<BlockedUser> b = from s in Cache.blockedUsers where s.idFac == a.FacID.ToString() select s  ;

            //lvUsers.DataSource = codes;
            //foreach (BlockedUser ts in codes)
            //{
            //    string startDate = ts.day1 + ts.Smonth;
            //    string EndDate = ts.day2 + ts.Emonth;
            //    // ListViewItem item = new ListViewItem(ts.ToString());

            //    ListViewItem item = new ListViewItem(ts.id.ToString());
            //    item.SubItems.Add(ts.uid);
            //    item.SubItems.Add(ts.name);
            //    item.SubItems.Add(ts.department);
            //    item.SubItems.Add(startDate);
            //    item.SubItems.Add(EndDate);
            //    item.SubItems.Add(ts.Shour+ts.Sminute);
            //    item.SubItems.Add(ts.Ehour+ts.Eminute);
            //    item.SubItems.Add(ts.weekday);
            //    lvUsers.DataSource = item;
            //   // lvUsers.Items.Add(item);
            //}
        }
        void filltable()
        {
            deviceID = int.Parse(cboDevice.SelectedValue.ToString());
            string query = "select * from DenialUser where idFac ='" + deviceID + "'";
            DataTable dt = BlockedUser.GetAllByquery(query);
            lvUsers.DataSource = dt;
        }
        private void myWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            List<string> userslist = e.Argument as List<string>;

            e.Result = FASHelper.AllowDenialUsers(userslist, (byte)deviceID);

            Dictionary<string, int> resultset = e.Result as Dictionary<string, int>;
            
            //DBFactory.Delete(Globals.GetConnectionString(), "delete from  DenialUser where id = '")


        }

        private void myWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                string query = "delete from  DenialUser where uid = " + lvUsers.SelectedRows[0].Cells["uid"].Value + " AND idFac = '" + deviceID + "';";
                DBFactory.Delete(Globals.GetConnectionString(), query);
                progress.Hide();
                filltable();
                Dictionary<string, int> resultset = e.Result as Dictionary<string, int>;
                frmResult result = new frmResult();
                result.resultset = resultset;
                result.ShowDialog();
            }
            catch(Exception ex)
            {
                Globals.ShowException("Process Failure:\n\r" + ex.Message);

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            filltable();
        }

        private void cboDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
          //  deviceID = int.Parse(cboDevice.SelectedValue.ToString());

            // a = Cache.RestrictedDevices.Find(x => x.FacIP == deviceID);

        }
    }
}
