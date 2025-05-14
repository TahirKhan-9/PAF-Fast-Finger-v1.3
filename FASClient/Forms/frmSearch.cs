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
    public partial class frmSearch : Form
    {
        public string result = "";
        public string search_mode = "";
        public String name = "";
        public string dpt = "";
        public frmSearch()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtKeyword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                DataTable dt = new DataTable();
                string query = "select distinct ID, Name, DESIGNATION, DEPARTMENT from [user] where name like '%" + txtKeyword.Text + "%'  order by id";
                //if (search_mode.ToLower() == "student")
                 //   query = "select distinct ID, Name, DESIGNATION, DEPARTMENT from [user] where name like '%" + txtKeyword.Text + "%' and gid in (11,12) order by id";

                //if (search_mode.ToLower() == "staff")
                //    query = "select distinct ID, Name, DESIGNATION, DEPARTMENT from [user] where name like '%" + txtKeyword.Text + "%' and gid in (21,22) order by id";

                //if (search_mode.ToLower() == "pr")
                //    query = "select distinct ID, Name, DESIGNATION, DEPARTMENT from [user] where name like '%" + txtKeyword.Text + "%' and gid in (31,32) order by id";

                //if (search_mode.ToLower() == "visitor")
                //    query = "select distinct ID, Name, DESIGNATION, DEPARTMENT from [user] where name like '%" + txtKeyword.Text + "%' and gid = 42 order by id";

                //if (search_mode.ToLower() == "tr")
                //    query = "select distinct ID, Name, DESIGNATION, DEPARTMENT from [user] where name like '%" + txtKeyword.Text + "%' and gid in (51, 52) order by id";

                dt = SqlHelper.ExecuteDataset(Globals.GetConnectionString(), CommandType.Text, query).Tables[0];

                dgvResult.DataSource = null;
                dgvResult.DataSource = dt;

                if (dgvResult.Rows.Count >= 1)
                {
                    dgvResult.Focus();
                    dgvResult.Rows[0].Selected = true;
                }
            }
        }

        private void frmSearch_Load(object sender, EventArgs e)
        {

        }

        private void dgvResult_DoubleClick(object sender, EventArgs e)
        {
            
            DataGridViewRow row = dgvResult.CurrentRow;
            if (row != null)
            {
                if (row.Cells[0].Value != null)
                {
                    result = row.Cells[0].Value.ToString();
                    name = row.Cells[1].Value.ToString();
                    dpt = row.Cells[3].Value.ToString();
                    this.Close();
                }
            }
        }

        private void txtKeyword_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvResult_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                int index = dgvResult.CurrentRow.Index;
                if (index == 0)
                    return;
                DataGridViewRow row = dgvResult.Rows[index - 1];
                if (row.Cells[0].Value == null)
                    return;

                if (row != null)
                {
                    if (row.Cells[0].Value != null)
                    {
                        result = row.Cells[0].Value.ToString();
                        name = row.Cells[1].Value.ToString();
                        dpt = row.Cells[3].Value.ToString();
                        this.Close();
                    }
                }
            }
        }

       

    }
}
