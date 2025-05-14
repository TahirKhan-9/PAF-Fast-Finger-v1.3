using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using UsmanCodeBlocks.Data.Sql;

namespace FASClient
{
    public class User
    {
        public Int16 GID { get; set; }
        public String UID { get; set; }
        public String Name { get; set; }
        public Int16 UType { get; set; }
        public Int16 SecurityLevel { get; set; }
        public String Finger1 { get; set; }
        public String Finger2 { get; set; }
        public String Finger3 { get; set; }
        public Int16 Admin { get; set; }
        public bool Suspend { get; set; }
        public DateTime CreatedDate { get; set; }

        public User() { }

        public User(string _uid)
        {
            String query = "SELECT GID,UID,NAME,UTYPE,SECURITYLEVEL,FINGER1,FINGER2,FINGER3,ADMIN,SUSPEND,CREATEDDATE FROM [USER] WHERE UID = '" + _uid + "'";
            DataTable dt = DBFactory.GetAllByQuery(Globals.GetConnectionString(), query);
            if (dt.Rows.Count >= 1)
            {
                DataRow row = dt.Rows[0];
                this.GID = Convert.ToInt16(row["gid"].ToString());
                this.UID = row["uid"].ToString();
                this.Name = row["name"].ToString();
                this.UType = Convert.ToInt16(row["utype"].ToString());
                this.SecurityLevel = Convert.ToInt16(row["securitylevel"].ToString());
                this.Finger1 = row["finger1"].ToString();
                this.Finger2 = row["finger2"].ToString();
                this.Finger3 = row["finger3"].ToString();
                this.Admin = Convert.ToInt16(row["admin"].ToString());
                this.Suspend = Convert.ToBoolean(row["suspend"].ToString());
                if (!row.IsNull("createddate")) { this.CreatedDate = Convert.ToDateTime(row["createddate"].ToString()); }
            }
        }

        public DataTable GetAll()
        {
            try
            {
                List<string> exCols = new List<string>();
                exCols.Add("Password");
                exCols.Add("Template1");
                exCols.Add("Template2");
                exCols.Add("Template3");

                //DataTable dt =  DBFactory.GetAll(Globals.GetConnectionString(), "User", exCols);
                DataTable dt = DBFactory.GetAllByQuery(Globals.GetConnectionString(), "SELECT GID,UID,Name,UType,SecurityLevel,Finger1,Finger2,Finger3,Admin,Suspend,CreatedDate FROM [User] Order by UID");
                return dt;
            }
            catch (Exception ex)
            {
                Globals.ShowException("Process Failure:\n\r" + ex.Message);
                return null;
            }
        }

        public int GetFingerCount(string _uid, int mode)
        {
            int count = 0;
            DataTable dtfinger = new DataTable();
            dtfinger = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(Globals.GetConnectionString(), CommandType.Text, "select utype, finger1,finger2,finger3 from [user] where uid = '" + _uid + "'").Tables[0];
            if (dtfinger.Rows.Count >= 1)
            {
                DataRow drow = dtfinger.Rows[0];
                if (mode == 1)
                {
                    // calculate fingers
                    if (!drow.IsNull("finger1") && drow["utype"].ToString() == "1") count++;
                    if (!drow.IsNull("finger2") && drow["utype"].ToString() == "1") count++;
                    if (!drow.IsNull("finger3") && drow["utype"].ToString() == "1") count++;
                }
                if (mode == 2)
                {
                    // get card status
                    if (!drow.IsNull("finger1") && drow["utype"].ToString() == "2")
                        count = 1;
                }
            }

            return count;
        }
    }
}
