using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Data;
using System.IO;
using Microsoft.ApplicationBlocks.Data;
using System.Reflection;
using Futronic.MfAPIHelper;
using System.ServiceProcess;
using FASClient.Forms;
using System.Net;
using System.Net.NetworkInformation;

namespace FASClient
{
    public enum OperationMode { AllowBlock=0, SendRetrieve=1};

    public enum UserType { Both = 0, Finger = 1, Card = 2};
    public enum MessageBoxType { Info = 0, Alert = 1, Error = 2, Confirm = 3 };

    public class Globals
    {
        public static AppUser User = new AppUser();
        public static FASHelper fasService = new FASHelper();
        public static bool defaultUser = false;
        public static int LoginID = 0;
        public static bool ValiditySensor = false;
        public static List<DbRecord> fpTemplates = new List<DbRecord>();
        public static string templateFolder = "";
        public static string photosFolder;
        public static string MasterPIN = "7";

        public static void GetPhotosFolder()
        {
            photosFolder = Application.StartupPath;
            string configFile = Application.StartupPath + "\\PhotoPath.txt";
            if (File.Exists(configFile))
            {
                photosFolder = File.ReadAllText(configFile);
            }
        }

        public static Image GetDefaultProfilePhoto()
        {
            return Image.FromFile(Application.StartupPath + "//nophoto.jpg");
        }

        public static void SetTemplateFolder(string path)
        {
            templateFolder = path;
            if (!Directory.Exists(templateFolder))
                Directory.CreateDirectory(templateFolder);
        }

        public static string GetAppTitle()
        {
            AssemblyTitleAttribute attributes = (AssemblyTitleAttribute)Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(AssemblyTitleAttribute), false);

            return attributes?.Title;
        }

        public static Dictionary<long,string> GetDevices()
        {
            Dictionary<long,string> list = new Dictionary<long, string>();
            if (!File.Exists(Application.StartupPath + "//app.config"))
                return list;

            string[] devices = File.ReadAllLines(Application.StartupPath + "//app.config");
            foreach(string item in devices.ToList())
            {
                string[] data = item.Split(',');
                list.Add(Convert.ToInt64(data[0]), data[1]);
            }
            return list;
        }

        public static bool UpdateDevices(string ip, long mac)
        {
            try
            { 
                if (!Cache.validDevices.ContainsKey(mac))
                {
                    // add new device
                    string line = mac.ToString() + "," + ip + "\n";
                    File.AppendAllText(Application.StartupPath + "//app.config", line);
                    Cache.validDevices.Add(mac, ip);
                }
                else
                {
                    // update existing
                    string deviceip = Cache.validDevices[mac];
                    if (deviceip.Trim() != ip.Trim())
                        Cache.validDevices[mac] = ip;

                    string line = "";
                    foreach(KeyValuePair<long,string> pair in Cache.validDevices)
                    {
                        line += pair.Key.ToString() + "," + pair.Value + "\n";
                    }

                    File.WriteAllText(Application.StartupPath + "//app.config", line);

                }
                return true;
            }
            catch(Exception ex)
            {
                new frmMessageBox(MessageBoxType.Error, ex.Message);
                return false;
            }
        }
        public static String HexToDecimal(String Hex)
        {
            string hex_value = Hex;

            //converting hex to integer
            int int_value = Convert.ToInt32(hex_value, 16);

            return int_value.ToString();
        }
        public static void MakeTransparent(Form context, Control ctrl, int x, int y)
        {
            Bitmap bMap = new Bitmap(context.BackgroundImage);
            Color[,] pixelArray = new Color[ctrl.Width, ctrl.Height];

            for (int i = 0; i < ctrl.Width; i++)
            {
                for (int j = 0; j < ctrl.Height; j++)
                {
                    pixelArray[i, j] = bMap.GetPixel(x + i, y + j);
                }
            }

            Bitmap bmp = new Bitmap(ctrl.Width, ctrl.Height);

            for (int i = 0; i < ctrl.Width; i++)
            {
                for (int j = 0; j < ctrl.Height; j++)
                {
                    bmp.SetPixel(i, j, pixelArray[i, j]);
                }
            }

            ctrl.BackgroundImage = bmp;
            ctrl.Location = new Point(x, y);
        }

        public static Int32 GetMaxID(string colName, string tblName)
        {
            Int32 maxID = 0;
            string query = "select count(*) from " + tblName + " ";
            if (Convert.ToInt32(SqlHelper.ExecuteScalar(GetConnectionString(), CommandType.Text, query)) >= 1)
            {
                query = "select max(" + colName + ") as maxid from " + tblName + "";
                maxID = Convert.ToInt32(SqlHelper.ExecuteScalar(GetConnectionString(), CommandType.Text, query));
            }

            return maxID + 1;
        }

        public static string ConvertToString(string hexString)
        {
            string result = "";
            while (hexString.Length > 0)
            {
                string s = hexString.Substring(0, 1);
                //result += System.Convert.ToChar(Convert.ToUInt32(hexString.Substring(0,1),16)).ToString();
                if (Convert.ToChar(s).ToString() != "\0")
                    result += s;

                hexString = hexString.Substring(1,hexString.Length-1);
            }

            return  result;
        }

        public static void ShowException(string message)
        {
            Forms.frmMessageBox msgbox = new Forms.frmMessageBox(MessageBoxType.Error, message);
            msgbox.ShowDialog();
            //MessageBox.Show(message, AppName, MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            // log in text file
            //File.AppendAllText(Application.StartupPath + "\\errlog.txt", DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss") + "-" + message);
        }

        public static void ShowMessage(string message)
        {
            Forms.frmMessageBox msgbox = new Forms.frmMessageBox(MessageBoxType.Info, message);
            msgbox.ShowDialog();
            //MessageBox.Show(message, AppName, MessageBoxButtons.OKCancel, icon);
        }
        public static void ShowAlert(string message)
        {
            Forms.frmMessageBox msgbox = new Forms.frmMessageBox(MessageBoxType.Alert, message);
            msgbox.ShowDialog();
            //MessageBox.Show(message, AppName, MessageBoxButtons.OKCancel, icon);
        }

        public static DialogResult ConfirmAction(string message)
        {
            Forms.frmMessageBox msgbox = new Forms.frmMessageBox(MessageBoxType.Confirm, message);
            msgbox.ShowDialog();
            return msgbox.result;
            //return MessageBox.Show(message, AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        public static String MfAPIException2ErrorMessage(MfAPIException ex)
        {
            String szMessage;
            switch ((FTR_ERROR_CODES)ex.ErrorCode)
            {
                case FTR_ERROR_CODES.MF_CARD_TYPE_INVALID:
                    szMessage = "Invalid card type.";
                    break;

                case FTR_ERROR_CODES.MF_NO_CARD:
                    szMessage = "No card in reader field.";
                    break;

                case FTR_ERROR_CODES.MF_INVALID_CARD_KEY:
                    szMessage = "Invalid card key.";
                    break;

                case FTR_ERROR_CODES.MF_CARD_NOT_EMPTY:
                    szMessage = "Card is not empty.";
                    break;

                case FTR_ERROR_CODES.MF_CARD_WRITE_ERROR:
                    szMessage = "Can not write data into the card.";
                    break;

                case FTR_ERROR_CODES.MF_CARD_READ_ERROR:
                    szMessage = "Can not read data from the card.";
                    break;

                case FTR_ERROR_CODES.MF_CARD_INVALID_FORMAT:
                    szMessage = "The card has invalid format.";
                    break;

                case FTR_ERROR_CODES.MF_NO_IMAGE:
                    szMessage = "No image.";
                    break;

                case FTR_ERROR_CODES.MF_BAD_QUALITY:
                    szMessage = "Bad quality.";
                    break;

                case FTR_ERROR_CODES.MF_EMPTY_BASE:
                    szMessage = "No any templates in local database";
                    break;

                case FTR_ERROR_CODES.MF_UNKNOW_USER:
                    szMessage = "Compare sample with local database unsuccessfull";
                    break;

                case FTR_ERROR_CODES.MF_BAD_ARGUMENT:
                    szMessage = "Bad parameters.";
                    break;

                case FTR_ERROR_CODES.MF_FAKE_FINGER:
                    szMessage = "Fake finger detected.";
                    break;

                case FTR_ERROR_CODES.MF_CRC_ERROR:
                    szMessage = "CRC error.";
                    break;

                case FTR_ERROR_CODES.MF_RXD_TIMEOUT:
                    szMessage = "Timeout error.";
                    break;

                case FTR_ERROR_CODES.MF_RECORD_EMPTY:
                    szMessage = "The record is empty.";
                    break;

                case FTR_ERROR_CODES.MF_RECORD_INVALID:
                    szMessage = "The record is invalid.";
                    break;

                case FTR_ERROR_CODES.MF_USER_ID_IS_ABSENT:
                    szMessage = "Template with requested UserID not exist in database";
                    break;

                case FTR_ERROR_CODES.MF_USER_ID_ALREADY_EXIST:
                    szMessage = "The UserID already exists.";
                    break;

                case FTR_ERROR_CODES.MF_SRXD_TIMEOUT:
                    szMessage = "SRXD timeout error.";
                    break;

                case FTR_ERROR_CODES.MF_USER_SUSPENDET:
                    szMessage = "The user is suspended.";
                    break;

                case FTR_ERROR_CODES.MF_UNKNOWN_COMMAND:
                    szMessage = "Unknown command.";
                    break;

                case FTR_ERROR_CODES.MF_IMAGE_MOVED:
                    szMessage = "Finger image is moved.";
                    break;

                case FTR_ERROR_CODES.MF_HARDWARE_ERROR:
                    szMessage = "Hardware error.";
                    break;

                case FTR_ERROR_CODES.MF_BAD_FLASH:
                    szMessage = "Bad flash.";
                    break;

                case FTR_ERROR_CODES.MF_RESULT_TOO_MANY_VIP:
                    szMessage = "Limit for VIP users exceed";
                    break;

                case FTR_ERROR_CODES.MF_TOO_BIG_GROUP:
                    szMessage = "Limit for users in one group exceed";
                    break;

                case FTR_ERROR_CODES.MF_WRITE_ERROR:
                    szMessage = "Write error.";
                    break;

                case FTR_ERROR_CODES.MF_RESULT_COMPARE_ERROR:
                    szMessage = "Result compare error.";
                    break;

                case FTR_ERROR_CODES.MF_RESULT_NO_SPACE:
                    szMessage = "No free space.";
                    break;

                default:
                    szMessage = String.Format("Unknown error code: {0}", ex.ErrorCode);
                    break;
            }

            return szMessage;
        }

        public static byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                return ms.ToArray();
            }
        }

        public static Image ByteToImage(Byte[] data)
        {
            if (data != null)
            {
                using (var ms = new MemoryStream(data))
                {
                    return Image.FromStream(ms);
                }
            }
            else
                return null;
        }

        public static string GetConnectionString()
        {
            string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=fassql;Integrated Security=True";
            string file = Application.StartupPath + "\\dbconfig.txt";
            if (File.Exists(file))
            {
                connectionString = File.ReadAllText(file);
            }

            return connectionString;
        }
        public static string RMSConnectionString()
        {
            string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=rms_a;Integrated Security=True";
            string file = Application.StartupPath + "\\RMSconfig.txt";
            if (File.Exists(file))
            {
                connectionString = File.ReadAllText(file);
            }

            return connectionString;
        }
        public static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }

        public static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name.ToLower() == column.ColumnName.ToLower())
                    {
                        if (!dr.IsNull(column.ColumnName))
                            pro.SetValue(obj, dr[column.ColumnName], null);
                    }
                    else
                        continue;
                }
            }
            return obj;
        }

        public static T CopyObject<T>(Object obj)
        {
            Type temp1 = obj.GetType();
            Type temp = typeof(T);
            T obj2 = Activator.CreateInstance<T>();

            foreach (PropertyInfo pro in temp.GetProperties())
            {
                foreach (PropertyInfo p in temp1.GetProperties())
                {
                    if (pro == p)
                    {
                        pro.SetValue(obj2, p.GetValue(obj, null), null);
                    }
                }
            }

            return obj2;
        }

        public static void AddListViewRow<T>(ListView lv, Object obj)
        {
            Type temp = obj.GetType();
            T obj2 = Activator.CreateInstance<T>();
            ListViewItem item = new ListViewItem();
            foreach (ColumnHeader ch in lv.Columns)
            {
                foreach(PropertyInfo p in temp.GetProperties())
                {
                    if (ch.Text.ToLower() == p.Name.ToLower())
                    {
                        item.SubItems.Add(p.GetValue(obj, null).ToString());
                    }
                }
            }
            lv.Items.Add(item);
        }

        public static void RestartService(string serviceName, int timeoutMilliseconds)
        {
            ServiceController service = new ServiceController(serviceName);
            try
            {
                int millisec1 = Environment.TickCount;
                TimeSpan timeout = TimeSpan.FromMilliseconds(timeoutMilliseconds);

                service.Stop();
                service.WaitForStatus(ServiceControllerStatus.Stopped, timeout);

                // count the rest of the timeout
                int millisec2 = Environment.TickCount;
                timeout = TimeSpan.FromMilliseconds(timeoutMilliseconds - (millisec2 - millisec1));

                service.Start();
                service.WaitForStatus(ServiceControllerStatus.Running, timeout);
            }
            catch
            {
                // ...
            }
        }

        public static void GetAppSettings()
        {
            DataTable dt = new DataTable();
            dt = SqlHelper.ExecuteDataset(GetConnectionString(), CommandType.Text, "select * from appsettings").Tables[0];
            if (dt.Rows.Count >= 1)
            {
                DataRow row = dt.Rows[0];
                if (!row.IsNull("validitysensor")) { ValiditySensor = Convert.ToBoolean(Convert.ToInt32(row["validitysensor"].ToString())); }
            }
        }

        public static string GetMacAddress(string ipAddress)
        {
            if (!PingHost(ipAddress))
                return "";

            string macAddress = string.Empty;
            System.Diagnostics.Process pProcess = new System.Diagnostics.Process();
            pProcess.StartInfo.FileName = "arp";
            pProcess.StartInfo.Arguments = "-a " + ipAddress;
            pProcess.StartInfo.UseShellExecute = false;
            pProcess.StartInfo.RedirectStandardOutput = true;
            pProcess.StartInfo.CreateNoWindow = true;
            pProcess.Start();
            string strOutput =
                pProcess.StandardOutput.ReadToEnd();
            string[] substrings = strOutput.Split('-');
            if (substrings.Length >= 8)
            {
                macAddress = substrings[3].Substring(Math.Max(0, substrings[3].Length - 2))
                         + "-" + substrings[4] + "-" + substrings[5] + "-" + substrings[6]
                         + "-" + substrings[7] + "-"
                         + substrings[8].Substring(0, 2);
                return macAddress;
            }
            else
            {
                return "";
            }

        }

        public static bool PingHost(string nameOrAddress)
        {
            bool pingable = false;
            Ping pinger = null;

            try
            {
                pinger = new Ping();
                PingReply reply = pinger.Send(nameOrAddress);
                pingable = reply.Status == IPStatus.Success;
            }
            catch (PingException)
            {
                // Discard PingExceptions and return false;
            }
            finally
            {
                if (pinger != null)
                {
                    pinger.Dispose();
                }
            }

            return pingable;
        }


    }

     
}
