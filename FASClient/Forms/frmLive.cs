using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FASClient
{
    public partial class frmLive : Form
    {
        public bool closePending = false;
        public FacDefinition device = new FacDefinition();
        string flag = "";
        string oldTime;
        string fileName = Application.StartupPath + "\\PhotoPath.txt";
        string picFolderPath = "";
        string lastID = "0";
        private List<int> _SelectedDevices;
        private string Gquery;

        public frmLive()
        {
            InitializeComponent();
            picFolderPath = getFolderPath();
        }
        public void clear()
        {
            lblDate.Text = "";
            lblDepart.Text = "";
            lblDesignation.Text = "";
            lblLocation.Text = "";
            lblName.Text = "";
            lblStatus.Text = "";
            lblUID.Text = "";
        }

        private void frmLive_Load(object sender, EventArgs e)
        {
            lblTitle.Text = Globals.GetAppTitle() + " v" + Application.ProductVersion;
            frmSelectDevice f = new frmSelectDevice();
            f.ShowDialog();
            if (f.SelectedDevices == null)
            {
                this.Close();
            }
            else
            {
                clear();
                _SelectedDevices = f.SelectedDevices;
                Gquery = "select Top (1) uid,facid,date,gid,rn from Ralog ";
                string joiner = "WHERE FACID = ";
                foreach (var item in f.SelectedDevices)
                {
                    Gquery += joiner + item;
                    joiner = " OR FACID = ";
                }
                Gquery +=" order by Date desc";
               // device = Cache.facList.Find(x => x.FacID == f.facid);
               //if (device != null)
               //{
               //lblLocation.Text = "Device : " + device.Description;
               //string query = "select count(distinct id) from [user]";
               //DataTable dt2 = new DataTable();
               //dt2 = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(Globals.GetConnectionString(), CommandType.Text, query).Tables[0];
               //if (dt2.Rows.Count > 0)
               //    lblEnrolled.Text = dt2.Rows[0][0].ToString();
                backgroundWorker1.RunWorkerAsync();
                //}
                //else
                //{
                //    this.Close();
                //}
                
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (!e.Cancel)
            {
                //DateTime dat = new DateTime();
                //dat = DateTime.Now;
                //dat = dat.AddMinutes(-1);
                //string query = "select Top (1) uid,facid,date,gid from Ralog where facid=" + device.FacID + " and Date between '" + dat + "' and '" + DateTime.Now + "'  order by Date desc";
                //string query = "select Top (1) uid,facid,date,gid,rn from Ralog WHERE FACID = " + device.FacID + " order by Date desc";
                DataTable dt = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(Globals.GetConnectionString(), CommandType.Text, Gquery).Tables[0];
                if (dt.Rows.Count > 0)
                //complete();
                {
                    

                    e.Result = dt;
                    //string q2 = "select count(distinct UID) from ralog where date between '" + DateTime.Today + "' and '" + DateTime.Today.AddDays(1) + "'";
                    //DataTable dt2= new DataTable();
                    //dt2= Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(Globals.GetConnectionString(), CommandType.Text, q2).Tables[0];
                    //lblPresent.Text = dt2.Rows[0][0].ToString();
                }

            }
            // backgroundWorker1_DoWork(null, null);

        }

        public string getFolderPath()
        {
            string path = "";
            if (System.IO.File.Exists(fileName))
            {
                path = File.ReadAllText(fileName);
            }

            return path;
        }
    
        public void complete()
        {
            //string path = "";
            //string query="select * from [user] where uid='"+dt.Rows[0][0]+"'";
            //DataTable DT2= new DataTable();
            //DT2 = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(Globals.GetConnectionString(), CommandType.Text, query).Tables[0];
            ////lblName.Text = DT2.Rows[0]["Name"].ToString();
            ////lblUID.Text = DT2.Rows[0]["uid"].ToString();

            //path = DT2.Rows[0]["imagepath"].ToString();
            //if (!string.IsNullOrEmpty(path))
            //    pictureBox1.Image = new Bitmap(path);
        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
            //closePending = false;
            DataTable dt = (DataTable)e.Result;
            if (dt != null)
            {

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    if (Convert.ToInt64(row["rn"]).ToString().Equals(lastID))
                    {

                    }
                    else
                    {
                        lastID = row["rn"].ToString();
                        //if (flag != dt.Rows[0][0].ToString())
                        //{
                        //string queryloc = "select description from facdefinition where facid=" + Convert.ToInt16(dt.Rows[0][1].ToString()) + "";
                        //DataTable DT3 = new DataTable();
                        //DT3 = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(Globals.GetConnectionString(), CommandType.Text, queryloc).Tables[0];
                        //lblLocation.Text = DT3.Rows[0][0].ToString();
                        //lblDate.Text = DateTime.Now.ToString();
                        //string path = "";
                        string uid = dt.Rows[0][0].ToString();
                        //User user = Cache.userList.FindAll(x => x.UID == uid)[0];
                        Employee emp = Cache.employeeList.Find(x => x.FingerID == uid || x.CardID == uid);
                        device = Cache.facList.Find(x => x.FacID == Convert.ToInt64(row["FacID"]));
                        //DataTable DT2 = new DataTable();
                        //DT2 = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(Globals.GetConnectionString(), CommandType.Text, query).Tables[0];
                        lblName.Text = emp.Name;
                        lblUID.Text = emp.Code;
                        lblStatus.Text = emp.Suspend ? "Suspended" : "Active";
                        lblDepart.Text = emp.Department;
                        lblDesignation.Text = emp.Section;
                        lblLocation.Text = device.Description;
                        lblDate.Text = dt.Rows[0]["Date"].ToString();
                        populate_list(emp, device.Description, dt.Rows[0]["Date"].ToString());
                        if (lblStatus.Text == "Active")
                        {
                            //lblStatus.Text = "Active";
                            lblStatus.BackColor = Color.SeaGreen;
                        }
                        else
                        {
                            //lblStatus.Text = "Suspended";
                            lblStatus.BackColor = Color.FromArgb(192, 0, 0);
                        }
                        //pictureBox1.Image = null;

                        //if (emp.Photo != null)
                        //    pictureBox1.Image = Globals.ByteToImage(emp.Photo);
                        //else
                        //    pictureBox1.Image = null;
                        string picFile = picFolderPath + "\\" + emp.Code + ".jpg";
                        if (File.Exists(picFile))
                            pictureBox1.Image = Image.FromFile(picFile);
                        else
                            //pictureBox1.Image = null;

                        //path = DT2.Rows[0]["imagepath"].ToString();
                        //if (!string.IsNullOrEmpty(path))
                        //    pictureBox1.Image = new Bitmap(path);
                        flag = dt.Rows[0][0].ToString();
                        //}
                    }

                }
            }

            if (closePending)
                this.Close();
            else
                backgroundWorker1.RunWorkerAsync();
            
        }
        void populate_list(Employee emp,String loc, String Dt)
        {
            //DataGridView item = new DataGridView(emp.Code);
            //item.SubItems.Add(emp.Name);
            //item.SubItems.Add(emp.Department);
            //item.SubItems.Add(emp.Section);
            //item.SubItems.Add(loc);
            //item.SubItems.Add(Dt);
            string[] row = new string[] { emp.Code, emp.Name,emp.Department,emp.Section,loc,Dt };
            Application.DoEvents();
            dataGridView1.Rows.Add(row);
            this.dataGridView1.Sort(this.dataGridView1.Columns["Column6"], ListSortDirection.Descending);


            //lvData.Items.Add(item);
        }

        private void frmLive_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
           // backgroundWorker1.CancelAsync();
            if (backgroundWorker1.IsBusy)
            {
                closePending = true;
                backgroundWorker1.CancelAsync();
                e.Cancel = true;
                this.Enabled = false;   // or this.Hide()
                return;
            }
            //base.OnFormClosing(e);
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblCurrentTime.Text = DateTime.Now.ToString("MMMM dd, yyyy, HH:mm:ss");
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }
    }
}
