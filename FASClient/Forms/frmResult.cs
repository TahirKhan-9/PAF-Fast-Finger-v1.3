using FASClient.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FASClient.Forms
{
    public partial class frmResult : Form
    {
        public Dictionary<string, int> resultset = new Dictionary<string, int>();

        public frmResult()
        {
            InitializeComponent();
        }

        private void frmResult_Load(object sender, EventArgs e)
        {
            if (resultset.Count == 0)
                return;

            foreach (KeyValuePair<string, int> pair in resultset)
            {
                Employee emp = Cache.employeeList.Find(x => x.FingerID == pair.Key || x.CardID == pair.Key);
                if (emp != null)
                {
                    ListViewItem item = new ListViewItem(emp.Code);
                    item.SubItems.Add(emp.Name);
                    item.SubItems.Add(pair.Key);
                    item.SubItems.Add(pair.Value.ToString());
                    item.SubItems.Add(ExtendErr.GetErrorMessage(pair.Value));

                    Application.DoEvents();
                    lvData.Items.Add(item);
                }
                else
                {
                    ListViewItem item = new ListViewItem("");
                    item.SubItems.Add("UNKNOWN");
                    item.SubItems.Add(pair.Key);
                    item.SubItems.Add(pair.Value.ToString());
                    item.SubItems.Add(ExtendErr.GetErrorMessage(pair.Value));

                    Application.DoEvents();
                    lvData.Items.Add(item);
                }
            }


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
