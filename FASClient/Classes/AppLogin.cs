using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

namespace FASClient
{
    public class AppLogin
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string LoginID { get; set; }
        public string LoginPwd { get; set; }
        public DateTime LoginTime { get; set; }
        public DateTime LogoutTime { get; set; }


        public AppLogin()
        { }

        public int Login()
        {
            string query = "insert into applogin(userid,loginid,loginpwd,logintime) values(";
            query += this.UserID + ",'";
            query += this.LoginID + "','";
            query += this.LoginPwd + "','";
            query += this.LoginTime.ToString("dd-MMM-yyyy HH:mm:ss") + "');";

            query += "SELECT @@IDENTITY";
            return Convert.ToInt32(SqlHelper.ExecuteScalar(Globals.GetConnectionString(), CommandType.Text, query).ToString());
        }

        public bool Logout(int sessionID)
        {
            string query = "update applogin set logouttime = '" + this.LogoutTime.ToString("dd-MMM-yyyy HH:mm:ss") + "' where id = " + sessionID;
            return Convert.ToBoolean(Convert.ToInt32(SqlHelper.ExecuteNonQuery(Globals.GetConnectionString(), CommandType.Text, query).ToString()));
        }
    }
}
