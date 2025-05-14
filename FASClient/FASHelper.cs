using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace FASClient
{
    public class FASHelper
    {
        public static bool FASConnected = false;

        public static int Connect(string server)
        {
            string pwd = "welcome";
            string path = System.IO.Directory.GetCurrentDirectory() + "\\pwd.txt";
            if (System.IO.File.Exists(path))
            {
                pwd = System.IO.File.ReadAllText(path);
            }
            int ret = ExtendApi.FasInitializeWithPassword(server, 4900, pwd);
            //int ret = ExtendApi.FasInitialize(server, 4900);
            if (ret == 0)
                FASConnected = true;

            return ret;
        }

        public static int ResumeUser(string uid)
        {
            byte idFac = byte.Parse("0");
            byte typeUser = byte.Parse("07");
            int ret = ExtendApi.FasChangeUserType(idFac, uid, typeUser, false);
            return ret;
        }

        public static int SuspendUser(string uid)
        {
            byte idFac = byte.Parse("0");
            byte typeUser = byte.Parse("15");
            int ret = ExtendApi.FasChangeUserType(idFac, uid, typeUser, false);
            return ret;
        }

        public static int RestrictDenialUser(string uid,byte idFac,byte Smonth,byte day1, byte Shour,byte Sminute, byte Emonth, byte day2, byte Ehour, byte Eminute,byte weekday)
        {
            // flag = 0 for single user----------------flag = 1 for group
            int ret = ExtendApi.FasAddDenialSetting(idFac, false, 0, uid, Smonth, day1, weekday, Shour, Sminute,Emonth, day2, weekday, Ehour, Eminute, true);
            return ret;
        }

        public static int allowDenialUser(string uid, byte idFac)
        {
            // Action: 0-Delete, 1-Disable, 2-Enable. Level: 0-All, 1-Group, 2-User
            int ret = ExtendApi.FasEditDenialSetting(idFac, 0, 2, 0, uid, true);
            return ret;
        }

        public static int AddFpUser(string templateFile,string uid, string userName, string gid, int fingerID)
        {
            int ret = -1;
            bool bSorC = true;
            byte groupID = byte.Parse(gid);
            Byte idFac = byte.Parse("0");
            byte idFinger = byte.Parse(fingerID.ToString());
            byte userType = byte.Parse("07");

            ret = ExtendApi.FasAddFpUser(bSorC, idFac, 0, null, userName, uid, groupID, idFinger, userType, true);
            return ret;

        }

        public static int DeleteFpUser(string uid)
        {
            int ret = -1;
            bool bSorC = true;
            Byte idFac = byte.Parse("0");

            ret = ExtendApi.FasDeleteUser(bSorC, idFac, uid, false);
            return ret;
        }

        public static int AddCardUser(string templateFile, string uid, string userName, string gid)
        {

            bool bSorC;
            Byte idFac;
            byte idGroup = byte.Parse(gid);
            bSorC = true;
            idFac = byte.Parse("0");
            int ret;

            // send fas command
            ret = ExtendApi.FasAddFS25UserFromFile(bSorC, idFac, templateFile, userName, uid, idGroup, true);
            string msg = ExtendErr.GetErrorMessage(ret);
            return ret;
        }

        public static int FasGetFasFpUserTemplate(ref byte[] tmp, ref int ret) {

            int nTmlSize = 0;
            byte[] pTemplate = new byte[6663];
            
            Byte fingerid = byte.Parse("6");
            // send fas command
            ret = ExtendApi.FasGetFasFpUserTemplate("11710322",fingerid, ref nTmlSize,pTemplate);
            tmp = pTemplate;
            return ret;
        }

        public static int DeleteCardUser(string uid)
        {
            int ret = -1;
            bool bSorC = true;
            Byte idFac = byte.Parse("0");

            ret = ExtendApi.FasDeleteUser(bSorC, idFac, uid, false);
            return ret;
        }

        public static Dictionary<string,int> SendUsersToFAC(string deviceid, List<string> uids)
        {
            int ret = -1;
            Dictionary<string, int> resultset = new Dictionary<string, int>();
            Byte idFac = byte.Parse(deviceid);
            foreach(string uid in uids)
            {
                ret = 0;
                ret = ExtendApi.FasSendUserFromFasToFac(idFac, uid, false);
                if (!resultset.ContainsKey(uid)) { resultset.Add(uid, ret); }
            }

            return resultset;
        }

        //public static Dictionary<string, int> GetUsersFromFAC(string deviceid)
        //{
        //    int ret = -1;
        //    Dictionary<string, int> resultset = new Dictionary<string, int>();
        //    Byte idFac = byte.Parse(deviceid);
        //    ret = ExtendApi.FasGetFacUserToFas(idFac, uid, false);
        //    if (!resultset.ContainsKey(uid)) { resultset.Add(uid, ret); }

        //    return resultset;
        //}
        public static Dictionary<string, int> DenialUsers(List<string> uids, byte idFac, byte Smonth, byte day1, byte Shour, byte Sminute, byte Emonth, byte day2, byte Ehour, byte Eminute,byte weekday)
        {
            
            int ret = -1;
            Dictionary<string, int> resultset = new Dictionary<string, int>();
            foreach (string uid in uids)
            {
                ret = RestrictDenialUser(uid,idFac,Smonth,day1,Shour,Sminute,Emonth,day2,Ehour,Eminute,weekday);
                if (ret == 0)
                {
                    var a = Cache.employeeList.Find(x => x.CardID == uid || x.FingerID == uid);
                    String query = "insert into DenialUser (uid,name,department,idFac,Smonth,day1,Shour,Sminute,Emonth,day2,Ehour,Eminute,weekday,createdOn,createdBy) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}')";
                    query = string.Format(query, uid, a.Name, a.Department.ToString(), idFac.ToString(), Smonth.ToString(), day1.ToString(), Shour.ToString(), Sminute.ToString(), Emonth.ToString(),
                    day2.ToString(), Ehour.ToString(), Eminute.ToString(), weekday.ToString(),DateTime.Now.ToString(), Globals.User.LoginID);

                    int result = SqlHelper.ExecuteNonQuery(Globals.GetConnectionString(), CommandType.Text, query);
                }
                resultset.Add(uid, ret);
            }

            return resultset;
        }
        public static Dictionary<string, int> Denialvis(List<string> uids, byte idFac, byte Smonth, byte day1, byte Shour, byte Sminute, byte Emonth, byte day2, byte Ehour, byte Eminute, byte weekday)
        {

            int ret = -1;
            Dictionary<string, int> resultset = new Dictionary<string, int>();
            foreach (string uid in uids)
            {
                ret = RestrictDenialUser(uid, idFac, Smonth, day1, Shour, Sminute, Emonth, day2, Ehour, Eminute, weekday);
                if (ret == 0)
                {
                        String query = "INSERT INTO tbl_VisPermission(EmpID,Day,FacID,[Deny]) values('{0}',{1},{2},{3})";
                        query = string.Format(query, uid, weekday,idFac,1);
                        int result = SqlHelper.ExecuteNonQuery(Globals.GetConnectionString(), CommandType.Text, query);
                }
                resultset.Add(uid, ret);
            }

            return resultset;
        }

        public static Dictionary<string, int> AllowDenialUsers(List<string> uids, byte idFac)
        {
            int ret = -1;
            Dictionary<string, int> resultset = new Dictionary<string, int>();
            foreach (string uid in uids)
            {
                ret = allowDenialUser(uid, idFac);
               
                resultset.Add(uid, ret);
            }
            return resultset;
        }

        public static Dictionary<string,int> BlockUsers(List<string> uids)
        {
            int ret = -1;
            Dictionary<string, int> resultset = new Dictionary<string, int>();
            foreach (string uid in uids)
            {
                ret = SuspendUser(uid);
                resultset.Add(uid, ret);
            }

            return resultset;
        }

        public static Dictionary<string, int> AllowUsers(List<string> uids)
        {
            int ret = -1;
            Dictionary<string, int> resultset = new Dictionary<string, int>();
            foreach (string uid in uids)
            {
                ret = ResumeUser(uid);
                resultset.Add(uid, ret);
            }

            return resultset;
        }
    }
}
