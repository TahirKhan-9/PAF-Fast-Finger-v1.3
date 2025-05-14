using System;
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
    public partial class frmOfflineDataSync : Form
    {
        DataTable dt = new DataTable();
        int ret;
        frmProgressDialog progress = new frmProgressDialog();
        public frmOfflineDataSync()
        {
            InitializeComponent();
            cboDevices.DataSource = Cache.facList;
            cboDevices.DisplayMember = "Description";
            cboDevices.ValueMember = "FacID";
            filltable();
        }
        void filltable()
        {
            try
            {
                string query = "SELECT *  FROM tbl_FacOfflineData order by Last_Update desc;";
                dt = DBFactory.GetAllByQuery(Globals.GetConnectionString(), query);

                if (dt != null)
                {
                    dataGridView1.DataSource = dt;
                }
                else
                {
                    Globals.ShowMessage("No Data Found!!!");
                }
            }
            catch (Exception ex)
            {
                Globals.ShowAlert("(filltable)" + ex.Message);
            }
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblreportTitle_Click(object sender, EventArgs e)
        {

        }

        private void cboDevice_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void syncAll_Click(object sender, EventArgs e)
        {
            List<string> Faclist = new List<string>();

            try
            {
                foreach (var item in Cache.facList)
                {
                    Faclist.Add(item.FacID.ToString());
                    
                }
                progress.Show();
                backgroundWorker1.RunWorkerAsync(Faclist);
                //    {
                //        ret = ExtendApi.FasGetFacRALToFas((byte)item.FacID, true, true);
                //        string msg = ExtendErr.GetErrorMessage(ret);

                //        if (ret == 0)
                //        {
                //            int result = DBFactory.Insert(Globals.GetConnectionString(), "INSERT INTO [dbo].[tbl_FacOfflineData]([FacID],[FacIP],[Location] ,[Last_Update]  ,[Status])  VALUES (" + item.FacID + ",'" + item.FacIP + "','" + item.Description + "'," + "',GETDATE(),'" + ",'Succeed')");
                //            if (result != 1)
                //            {
                //                Globals.ShowMessage("Data Sync Successfull && Database Connection Failed!");
                //            }

                //        }
                //        else
                //        {
                //            string query = "INSERT INTO [dbo].[tbl_FacOfflineData]([FacID],[FacIP],[Location] ,[Last_Update]  ,[Status])  VALUES (" + item.FacID + ",'" + item.FacIP + "','" + item.Description + "',GETDATE(),'" + msg + "')";
                //            int result = DBFactory.Insert(Globals.GetConnectionString(), query);
                //            if (result != 1)
                //            {
                //                Globals.ShowMessage("Data Sync Failed && Database Connection Failed!");
                //            }
                //        }

                //    }
                //}
               
                //filltable();
            }
            catch (Exception ex)
            {
                Globals.ShowAlert("(SynAll)" + ex.Message);
            }
        }
        private void syn_click(object sender, EventArgs e)
        {
            List<string> Faclist = new List<string>();
            string code = cboDevices.SelectedValue.ToString();
            Faclist.Add(code);
            progress.Show();
            backgroundWorker1.RunWorkerAsync(Faclist);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            List<string> Faclist = e.Argument as List<string>;

            try
            {
                foreach (var FacIDs in Faclist)
                {

                    int SelectedFacID = Int32.Parse(FacIDs);
                    FacDefinition item = Cache.facList.FirstOrDefault(x => x.FacID == SelectedFacID);
                    ret = ExtendApi.FasGetFacRALToFas((byte)item.FacID, true, true);
                    string msg = ExtendErr.GetErrorMessage(ret);
                    if (ret == 0)
                    {
                        int result = DBFactory.Insert(Globals.GetConnectionString(), "INSERT INTO [dbo].[tbl_FacOfflineData]([FacID],[FacIP],[Location] ,[Last_Update]  ,[Status])  VALUES (" + item.FacID + ",'" + item.FacIP + "','" + item.Description + "'," + "',GETDATE(),'" + ",'Succeed')");
                        if (result != 1)
                        {
                            Globals.ShowMessage("Data Sync Successfull && Database Connection Failed!");
                        }

                    }
                    else
                    {
                        string query = "INSERT INTO [dbo].[tbl_FacOfflineData]([FacID],[FacIP],[Location] ,[Last_Update]  ,[Status])  VALUES (" + item.FacID + ",'" + item.FacIP + "','" + item.Description + "',GETDATE(),'" + msg + "')";
                        int result = DBFactory.Insert(Globals.GetConnectionString(), query);
                        if (result != 1)
                        {
                            Globals.ShowMessage("Data Sync Failed && Database Connection Failed!");
                        }
                    }
                   
                }
            }
            catch (Exception ex)
            {
                Globals.ShowAlert("(Sync)" + ex.Message);
            }

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progress.Hide();
            filltable();
        }
    }
}
