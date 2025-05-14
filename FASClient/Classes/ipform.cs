using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using UsmanCodeBlocks.Data.Sql;

namespace FASClient.Classes
{
    class ipform : UserControl
    {
        string location;
        string query;
        public Panel f;
        private int ScreenWidth = Screen.PrimaryScreen.Bounds.Width;
        SqlConnection con = new SqlConnection("Data Source=USAMA-IT;Initial Catalog=IPAddresses;Integrated Security=True");
        //con.Open();
        int pFail = 0, pSuccess = 0;
        //SqlDataAdapter sda;
        //DataTable dt;
        int a = 1, interval, DTFailure;
        public Label lblDeviceName = new Label();
        public Label lblDeviceIP = new Label();
        public Label lblRTT = new Label();
        public Label lblPcount = new Label();
        //int fNext,nLine;
        Ping p = new Ping();
        public string status = "null", pstatus = "null";
        string rtt;
        public Timer timer1 = new Timer();
        PingReply rep;
        SqlCommand cmd, cmd1;
        string shop_name;


        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ipform
            // 
            this.Name = "ipform";
            this.Size = new System.Drawing.Size(150, 144);
            this.ResumeLayout(false);

        }

        bool wlog;

        //PingOptions options = new PingOptions();

        public ipform(int interval_time, string ip, string shpname, int failure, bool logt, TableLayoutPanel form, int col, int row)
        {
            //query = "INSERT INTO[dbo].[tbl_monitoring]([Location],[IP],[Date],[Time])  VALUES ('" + shpname + "','" + ip + "','" + DateTime.Now.Date.ToString() + "','"+DateTime.Now.ToString("HH:mm:ss")+"')";
            location = shpname;
            wlog = logt;
            //con.Open();
            DTFailure = failure;
            //DTFailure = 3;
            interval = interval_time;
            //interval = 1;
            f = new Panel();
            // f.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            //f.AutoSize = true;
            //f.Height = 50;
            //f.Width = MeWidth;
            int[] width = form.GetColumnWidths();
            int[] height = form.GetRowHeights();
            f.Width = width[0];
            f.Height = height[0];
            f.Dock = DockStyle.Fill;
            //f.Width = Width;
            //f.Height = height[0];

            //fNext += f.Width; nLine = 0;
            //f.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            //f.MinimizeBox = false;
            // f.MaximizeBox = false;
            // f.Location = new Point(x, y);
            // f.StartPosition = FormStartPosition.Manual;
            // f.ControlBox = false;
            // f.ShowIcon = false;
            // f.Icon = new System.Drawing.Icon(@"C:\Users\sammy\Contacts\Desktop\paypal.ico");
            //f.WindowState = FormWindowState.Normal;
            shop_name = shpname;
            //options.DontFragment = true;
            //x += 25;
            //y += 10;
            //f.Height = 100;
            //con = new SqlConnection("Data Source=(local);Initial Catalog=IPAddresses;Integrated Security=True");
            //con.Open();
            //sda = new SqlDataAdapter("Select IP from IPs", con);
            //dt = new DataTable();
            //sda.Fill(dt);
            timer1.Interval = interval_time;
            timer1.Enabled = true;
            timer1.Tick += new EventHandler((sender, e) => timer1_Tick(sender, e, ip));
            form.Controls.Add(f);
            //this.Show();
            /*fNext = fNext + f.Width;
            if (fNext == 1435)
            {
                nLine = nLine + f.Height;
                fNext = 0;
            }*/
            //            fNext = f.Right;
            //          nLine = 0;
            // con.Close(); 
            // lblDeviceName_MouseHover+= new EventHandler(object,e);

        }

        public void timer1_Tick(object sender, EventArgs e, string ip)
        {
            // con.Open();
            string IP = ip;
            if (wlog == true)
            {
                //cmd1 = new SqlCommand("UPDATE IPs SET LastStatus = @status where DeviceIP LIKE @ip", con);
                //cmd1.Parameters.AddWithValue("@status", status);
                //cmd1.Parameters.AddWithValue("@ip", ip);
                //cmd1.ExecuteNonQuery();
            }
            this.iping(IP);
            if (wlog == true)
            {
                if (pstatus != status)
                {
                    //cmd = new SqlCommand("Insert into status(IP,status,shop_name) values('" + ip + "','" + status + "','" + shop_name + "')", con);
                    //cmd.ExecuteNonQuery();
                }
            }
            pstatus = status;
            /*iping(dt.Rows[b][0].ToString());
            f.Text = dt.Rows[b][0].ToString();
            b++;*/
            //con.Close();
        }

        public void iping(string ip)
        {
            double FontSize = 14, FontSizeName = 22;
            try
            {
                rep = p.Send(ip, interval);
                rtt = rep.RoundtripTime.ToString();
                status = rep.Status.ToString();
                a = a + 1;
                if (status == "TimedOut")
                {
                    pFail++; pSuccess = 0;
                }
                if (status == "Success")
                {
                    pFail = 0; pSuccess++;

                }
                //f.Text = ip;
                //f.Text = dt.Rows[b][0].ToString();
                //return status;

            }
            catch (PingException)
            {

                status = " Network Unavailable";
            }
            finally
            {
                lblDeviceName.Font = new Font("Calibri", Convert.ToInt32(FontSizeName), FontStyle.Bold);
                lblDeviceName.Text = shop_name;
                lblDeviceName.Height = Convert.ToInt32(this.f.Height * 0.5);
                //lblDeviceName.Width = this.f.Width;
                //lblDeviceName.Left = 0;
                lblDeviceName.Top = 0;
                lblDeviceName.Dock = DockStyle.Top;
                lblDeviceName.TextAlign = ContentAlignment.MiddleCenter;
                lblDeviceName.Show();

                /* lblDeviceIP.MouseHover += f_MouseHover;
                 */
                //lblDeviceName.Dock = DockStyle.Fill; 
                //namelabel.AutoSize = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
                //namelabel.AutoSize = false;

                lblDeviceIP.Text = ip;
                lblDeviceIP.Font = new Font("Calibri", Convert.ToInt32(FontSize));
                //lblDeviceIP.Height = Convert.ToInt32(this.f.Height * 0.35);
                //lblDeviceIP.Width = Convert.ToInt32(this.f.Width * 0.6);
                //lblDeviceIP.Left = 0;
                //lblDeviceIP.Top = lblDeviceName.Height + 1;
                lblDeviceIP.TextAlign = ContentAlignment.MiddleLeft;
                lblDeviceIP.Dock = DockStyle.Bottom;
                lblDeviceIP.Show();

                //lblRTT.Show();
                //lblRTT.Text = rtt;
                //lblRTT.Font = new Font("Calibri", Convert.ToInt32(FontSize));
                //lblRTT.Width = Convert.ToInt32(this.f.Width * 0.25);
                //lblRTT.Left = lblDeviceIP.Width - lblRTT.Width / 9;
                //lblRTT.Height = Convert.ToInt32(this.f.Height * 0.35);
                //lblRTT.Top = lblDeviceName.Height + 3;

                if (status == "Success")
                {
                    lblPcount.Text = pSuccess.ToString();
                }
                else
                    if (status == "TimedOut")
                {
                    lblPcount.Text = pFail.ToString();
                }
                //lblPcount.Height = Convert.ToInt32(this.f.Height * 0.35);
                //lblPcount.Width = Convert.ToInt32(this.f.Width * 0.4);
                //lblPcount.Left = this.f.Width - lblPcount.Width - 7;
                //lblPcount.Top = lblDeviceName.Height + 1;
                lblPcount.TextAlign = ContentAlignment.MiddleRight;
                lblPcount.Font = new Font("Calibri", Convert.ToInt32(FontSize));
                lblPcount.Dock = DockStyle.Bottom;
                lblPcount.Show();

                if (status == "Success")
                {
                    // f.Icon = new System.Drawing.Icon(@"C:\tick.ico");
                    f.BackColor = Color.Green;
                    lblDeviceName.BackColor = this.f.BackColor;
                    lblDeviceIP.BackColor = this.f.BackColor;
                    lblPcount.BackColor = this.f.BackColor;
                    if (!Cache.ActiveDevces.Contains(ip))
                    {
                        Cache.ActiveDevces.Add(ip);
                    }

                }
                else
                if (status == "TimedOut")
                {
                    if (pFail <= DTFailure)
                    {
                        //  f.Icon = new System.Drawing.Icon(@"C:\wrong.ico");


                        f.BackColor = Color.Yellow;
                        lblDeviceName.BackColor = this.f.BackColor;
                        lblDeviceIP.BackColor = this.f.BackColor;
                        lblPcount.BackColor = this.f.BackColor;

                    }
                    else
                    if (pFail > DTFailure)
                    {
                        // f.Icon = new System.Drawing.Icon(@"C:\wrong.ico");
                        query = "INSERT INTO[dbo].[tbl_monitoring]([Location],[IP],[Date],[Time])  VALUES ('" + location + "','" + ip + "','" + DateTime.Now.Date.ToString() + "','" + DateTime.Now.ToString("HH:mm:ss") + "')";
                        f.BackColor = Color.Red;
                        lblDeviceName.BackColor = this.f.BackColor;
                        lblDeviceIP.BackColor = this.f.BackColor;
                        lblPcount.BackColor = this.f.BackColor;
                        DBFactory.Insert(Globals.GetConnectionString(), query);

                        if (Cache.ActiveDevces.Contains(ip))
                        {
                            Cache.ActiveDevces.Remove(ip);


                        }
                    }
                }
                else
                {
                    //  f.Icon = new System.Drawing.Icon(@"C:\wrong.ico");


                    f.BackColor = Color.Blue;
                    lblDeviceName.BackColor = this.f.BackColor;
                    lblDeviceIP.BackColor = this.f.BackColor;
                    lblPcount.BackColor = this.f.BackColor;

                }

                /*       
                   if (status == "NetworkUnavailable" )

                   {
                       f.Icon = new System.Drawing.Icon(@"C:\Users\sammy\Contacts\Desktop\wrong.ico");

                               namelabel.BackColor = Color.Blue;
                   }

                   if (status == "DestinationHostUnreaachable")
                   {
                       f.Icon = new System.Drawing.Icon(@"C:\Users\sammy\Contacts\Desktop\wrong.ico");

                       namelabel.BackColor = Color.Blue;
                   }*/

                f.Controls.Add(lblDeviceName);
                f.Controls.Add(lblDeviceIP);
                //f.Controls.Add(lblRTT);
                f.Controls.Add(lblPcount);


                //MessageBox.Show(status);
                //return status;


            }

            //  con.Close();   
        }

        public void shw()
        {

            f.Show();

            //           con.Close();   

        }

    }
}

