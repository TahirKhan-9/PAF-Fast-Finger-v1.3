using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Microsoft.ApplicationBlocks.Data;
using FASClient;

namespace FASClient
{
    class ShiftSchedule
    {
        public int id { get; set; }
        public string UserID { get; set; }
        public DateTime UsrDate { get; set; }
        public int ShiftID { get; set; }

        public virtual string ShiftName { get; set; }
        public virtual DateTime StartTime { get; set; }
        public virtual DateTime EndTime { get; set; }
        public virtual DateTime MinStartTime { get; set; }
        public virtual DateTime MaxStartTime { get; set; }
        public virtual DateTime MinEndTime { get; set; }
        public virtual DateTime MaxEndTime { get; set; }
        public virtual bool IsODShift { get; set; }

        public bool save()
        {
            string query = "insert into shiftschedule (UserID,usrDate,ShiftID) values('" + this.UserID + "','" + this.UsrDate.Date + "'," + this.ShiftID + ")";
            return Convert.ToBoolean(SqlHelper.ExecuteNonQuery(Globals.GetConnectionString(), CommandType.Text, query));
        }
        public bool update(int _id)
        {
            string query = "update shiftschedule set UserID='" + this.UserID + "',usrDate='" + this.UsrDate.Date + "',shiftID=" + this.ShiftID + " where id="+_id+"";
            return Convert.ToBoolean(SqlHelper.ExecuteNonQuery(Globals.GetConnectionString(), CommandType.Text, query));
        }
        public bool delete(int _id)
        {
            string query = "delete from shiftschedule where id = " + _id + "";
            return Convert.ToBoolean(SqlHelper.ExecuteNonQuery(Globals.GetConnectionString(), CommandType.Text, query));
        }
        public static ShiftSchedule Get(string _userID,DateTime _usrDate)
        {
            ShiftSchedule s = new ShiftSchedule();
            string query = "select * from V_Schedule where UserID='" + _userID + "'and usrDate='" + _usrDate.Date + "'";
            DataTable dt = new DataTable();
            dt = SqlHelper.ExecuteDataset(Globals.GetConnectionString(), CommandType.Text, query).Tables[0];
            if (dt.Rows.Count > 0)
            {
                s = Globals.GetItem<ShiftSchedule>(dt.Rows[0]);
            }
            return s;
        }
        public static List<ShiftSchedule> GetAll(string _userID, DateTime fromDate,DateTime toDate)
        {
            List<ShiftSchedule> list = new List<ShiftSchedule>();
            string query = "select * from ShiftSchedule where UserID='" + _userID + "'and usrDate between '" + fromDate.Date + "' and '" + toDate.Date + "' ";
            DataTable dt = new DataTable();
            dt = SqlHelper.ExecuteDataset(Globals.GetConnectionString(), CommandType.Text, query).Tables[0];
            if (dt.Rows.Count > 0)
            {
                list = Globals.ConvertDataTable<ShiftSchedule>(dt);
            }
            return list;
        }
    }
}
