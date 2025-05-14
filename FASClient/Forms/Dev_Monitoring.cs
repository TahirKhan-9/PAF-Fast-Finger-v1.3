using FASClient.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UsmanCodeBlocks.Data.Sql;

namespace FASClient.Forms
{
    public partial class frmDevMonitoring : Form
    {
        int rows, columns,devices;
        ipform Ipform;
        string query;
        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = initializeFAS();
        }

        private int initializeFAS()
        {
            string connstring = Globals.GetConnectionString();
            string[] cstr = connstring.Split(';');
            string[] newstr = cstr[0].Split('=');
            string serverstr = newstr[1].ToUpper();
            serverstr = serverstr.Replace("\\SQLEXPRESS", "").Trim();

            int ret = FASHelper.Connect(serverstr);

            return ret;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            int ret = (int)e.Result;
            if (ret == (int)ErrorCode.ERR_SUCCESS)
            {
                lblStatus.Text = "Campus Card Server:Connected";
            }
            else
            {
                lblStatus.Text = "Campus Card Server:Not Connected";
                query = "INSERT INTO[dbo].[tbl_monitoring]([Location],[IP],[Date],[Time])  VALUES (' fasServer ','10.0.60.30','" + DateTime.Now.Date.ToString() + "','" + DateTime.Now.ToString("HH:mm:ss") + "')";
                DBFactory.Insert(Globals.GetConnectionString(), query);
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void lblStatus_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            int active = Cache.ActiveDevces.Count;
            int inactive = Cache.facList.Count - Cache.ActiveDevces.Count;
            if (lblActive.InvokeRequired)
            {
                lblActive.Invoke(new MethodInvoker(delegate
                {
                    lblActive.Text = "Active Nodes: " + active;

                }
                ));
            }
            else
            {
                lblActive.Text = "Active Nodes: " + active;

            }
            if (lblInactive.InvokeRequired)
            {
                lblInactive.Invoke(new MethodInvoker(delegate
                {
                    lblInactive.Text = "In Active Nodes: " + inactive;

                }
                ));
            }
            else
            {
                lblInactive.Text = "In Active Nodes: " + inactive;
            }
            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            backgroundWorker2.RunWorkerAsync();
        }

        public frmDevMonitoring()
        {
            InitializeComponent();
            //pictureBox1.Width = (this.Width/2);
            //panel6.Width = this.Width/2  ;
            //Thread thread = new Thread(new ThreadStart(picturethread));
            //thread.IsBackground = true;
            //thread.SetApartmentState(ApartmentState.STA);
            //thread.Start();
        }

        private void picturethread()
        {
           // pictureBox1.Visible = true;
        }

        private void frmDevMonitoring_Load(object sender, EventArgs e)
        {
            //tableLayoutPanel1.row
            devices = Cache.facList.Count;
            rows = (devices <= 30) ? devices/3 : devices/4;
            columns = (devices <= 30) ? 3 : 4;
            float rowpercentage = 100 / rows;
            float columnpercentage = 100 / columns;
            #region table pannel
            TableLayoutPanel tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            //tableLayoutPanel1.Name = "tableLayoutPanel1";
            //tableLayoutPanel1.Size = new System.Drawing.Size(1060, 400);
            //tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, columnpercentage));
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = rows;
            //tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, rowpercentage));
            tableLayoutPanel1.Size = new System.Drawing.Size(1081, 471);
            tableLayoutPanel1.TabIndex = 0;
            tableLayoutPanel1.ColumnCount = columns;
            //tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.OutsetPartial;
            //tableLayoutPanel1.Dock = DockStyle.Fill;
            for (int i = 0; i < columns; i++)
            {
                tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, columnpercentage));
            }
            //tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            //tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            //tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            //tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            ////tableLayoutPanel1.ForeColor = Color.Red;
            //tableLayoutPanel1.BackColor = Color.Blue;
            //tableLayoutPanel1.Location = new System.Drawing.Point(235, 72);
            //tableLayoutPanel1.RowCount = rows;
            for (int i = 0; i < rows; i++)
            {
                tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, rowpercentage));
            }
            //panel6.Controls.Add(tableLayoutPanel1);
            #endregion
            foreach (var item in Cache.facList)
            {
                Ipform = new ipform(1000, item.FacIP, item.Description, 3, false, tableLayoutPanel1, columns, rows);
                
            }
            panel6.Controls.Add(tableLayoutPanel1);
            backgroundWorker1.RunWorkerAsync();
        }
    }
}
