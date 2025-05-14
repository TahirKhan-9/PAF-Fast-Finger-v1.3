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
    public partial class frmDevicesLog : Form
    {
        DataTable dt;
        public frmDevicesLog()
        {
            InitializeComponent();
            cboDevices.DataSource = Cache.facList;
            cboDevices.DisplayMember = "Description";
            cboDevices.ValueMember = "FacIP";

        }

        private void frmDevicesLog_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime Sdate = dtpStartDate.Value.Date;
            DateTime Edate = dtpEndDate.Value.Date;
            string sDate = dtpStartDate.Value.ToString("yyyy-MM-dd");
            string eDate = dtpEndDate.Value.ToString("yyyy-MM-dd");

            string query = "SELECT *  FROM tbl_monitoring  WHERE [IP] = '" + cboDevices.SelectedValue + "' and([Date] between CONVERT(datetime, '" + Convert.ToDateTime(sDate).ToString("yyyy - MM - dd") + "') and CONVERT(datetime,'" + Convert.ToDateTime(eDate).ToString("yyyy - MM - dd")+"'));";
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

        private void cboDevices_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dtpEndDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void lblStart_Click(object sender, EventArgs e)
        {

        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
