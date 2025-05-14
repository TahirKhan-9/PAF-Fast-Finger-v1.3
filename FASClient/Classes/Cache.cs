using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using Futronic.SDK.WorkedEx;
using System.Data;
using Microsoft.ApplicationBlocks.Data;
using System.IO;
using FASClient;
using Futronic.SDKHelper;
using FASClient.Classes;
using System.Windows.Forms;

namespace FASClient
{
    public class Cache
    {
        //public static List<User> userList = new List<User>();
        public static List<Employee> employeeList = new List<Employee>();
        public static List<BlockedUser> blockedUsers = new List<BlockedUser>();
        public static List<TimeSlot> timeSlots = new List<TimeSlot>();
        public static List<TimeSlot> DaytimeSlots = new List<TimeSlot>();
        public static List<TimeSlot> ALLtimeSlots = new List<TimeSlot>();
        public static List<FacDefinition> facList = new List<FacDefinition>();
        public static List<FacDefinition> RestrictedDevices = new List<FacDefinition>();
        public static List<p_person> tag = new List<p_person>();
        public static Dictionary<long, string> validDevices = new Dictionary<long, string>();
        public static List<string> MasterCards = new List<string>();
        public static List<string> ActiveDevces = new List<string>();
        public static void Load()
        {
            string file = Application.StartupPath + "\\masterCard.txt";
            if (File.Exists(file))
            {
                MasterCards = File.ReadAllLines(file).ToList();
            }

            LoadConfig();

            //userList = Globals.ConvertDataTable<User>(new User().GetAll());
            Globals.GetPhotosFolder();
            employeeList = Globals.ConvertDataTable<Employee>(new Employee().GetAll());
            //foreach(Employee emp in employeeList)
            //{

            //}
            blockedUsers = Globals.ConvertDataTable<BlockedUser>(BlockedUser.GetAll());
            ALLtimeSlots = Globals.ConvertDataTable<TimeSlot>(TimeSlot.GetAllTimes());
            timeSlots = Globals.ConvertDataTable<TimeSlot>(TimeSlot.GetAll());
            DaytimeSlots = Globals.ConvertDataTable<TimeSlot>(TimeSlot.GetAllDay());
            RestrictedDevices = Globals.ConvertDataTable<FacDefinition>(new FacDefinition().GetAllByQuery());
            facList = Globals.ConvertDataTable<FacDefinition>(new FacDefinition().GetAll());
            //tag = Globals.ConvertDataTable<p_person>(new p_person().GetAllByquery("SELECT [work_no],[id_no],[id_name],[first_name],[last_name],[title_no] FROM[rms_a].[dbo].[p_person]"));
            //validDevices = Globals.GetDevices();
            if (validDevices.Count == 0)
            {
                // add existing devices
                foreach (FacDefinition fac in facList)
                {
                    if (!string.IsNullOrEmpty(fac.FacComm))
                    {
                        // add in dictionary
                        string key = Usman.CodeBlocks.Crypto.StringCipher.Decrypt(fac.FacComm);
                        if (key.Trim().Equals(fac.FacMac.ToString().Trim()))
                            validDevices.Add(fac.FacMac, fac.FacIP);
                    }
                    else
                    {
                        // find mac and update in table
                        string mac = Usman.CodeBlocks.Networking.NetworkHelper.GetMac(fac.FacIP);
                        if (!mac.Equals("000000000000"))
                        {
                            fac.FacComm = Usman.CodeBlocks.Crypto.StringCipher.Encrypt(mac);
                            fac.FacMac = Convert.ToInt64(mac);
                            if (fac.Update())
                                validDevices.Add(fac.FacMac, fac.FacIP);
                        }
                    }
                }
            }
            //GetAllTemplates();
        }

        static void LoadConfig()
        {
            string configFile = Application.StartupPath + "\\config.dds";
            string[] configText = System.IO.File.ReadAllLines(configFile);
            if (configText.Length >= 1)
            {
                foreach (string line in configText)
                {
                    if (line.Contains("MasterPIN"))
                    {
                        string[] data = line.Split('=');
                        Globals.MasterPIN = data[1];
                    }
                }
            }
        }

        public static void GetAllTemplates()
        {
            string query = "select * from [user] where finger1 is not null and utype = 1";
            DataTable dt = new DataTable();
            dt = SqlHelper.ExecuteDataset(Globals.GetConnectionString(), CommandType.Text, query).Tables[0];
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    if (!row.IsNull("finger1"))
                    {
                        DbRecord User = new DbRecord();
                        User.UserName = row["name"].ToString();
                        byte[] template1 = (byte[])row["template1"];
                        User.Template = template1;


                        Globals.fpTemplates.Add(User);
                    }

                    if (!row.IsNull("finger2"))
                    {
                        DbRecord User = new DbRecord();
                        User.UserName = row["name"].ToString();
                        byte[] template = (byte[])row["template2"];
                        User.Template = template;

                        Globals.fpTemplates.Add(User);
                    }

                    if (!row.IsNull("finger3"))
                    {
                        DbRecord User = new DbRecord();
                        User.UserName = row["name"].ToString();
                        byte[] template = (byte[])row["template3"];
                        User.Template = template;

                        Globals.fpTemplates.Add(User);
                    }
                }
            }
        }
    }
}
