using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

namespace FASClient
{
    public class Shifts
    {
        public int id { get; set; }
        public string name { get; set; }
        public TimeSpan timein { get; set; }
        public TimeSpan timeout { get; set; }
        public TimeSpan actualhrs { get; set; }
        public TimeSpan start_timein { get; set; }
        public TimeSpan end_timein { get; set; }
        public TimeSpan start_timeout { get; set; }
        public TimeSpan end_timeout { get; set; }
        public double workmins { get; set; }
        public TimeSpan totalDuty { get; set; }
        public bool IsODShift { get; set; }

        string query;
        string dbCon = Globals.GetConnectionString();
        DataTable dt;

        public int Save()
        {
            query = "insert into shifts(shiftname,starttime,endtime,minstarttime,maxstarttime,minendtime,maxendtime) values('";
            query = query + this.name + "','";
            query = query + this.timein.ToString() + "','";
            query = query + this.timeout + "','";
            query = query + this.start_timein + "','";
            query = query + this.end_timein + "','";
            query = query + this.start_timeout + "','";
            query = query + this.end_timeout + "')";

            int result = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(dbCon, CommandType.Text, query);

            return result;

        }

        public int Delete(int id)
        {
            query = "delete from shifts where shiftid = " + id + "";
            return Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(dbCon, CommandType.Text, query);
        }
        public DataTable GetAll(string q)
        {
            if (string.IsNullOrEmpty(q))
                query = "select * from shifts";
            else
                query = q;
            DataTable dt = new DataTable();
            dt = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(dbCon, CommandType.Text, query).Tables[0];
            return dt;
        }
        public int Update()
        {
            query = "update shifts set ";
            query = query + "shiftname = '" + this.name + "',";
            query = query + "starttime = '" + this.timein.ToString() + "',";
            query = query + "endtime = '" + this.timeout + "',";
            query = query + "minstarttime = '" + this.start_timein + "',";
            query = query + "maxstarttime = '" + this.end_timein + "',";
            query = query + "minendtime = '" + this.start_timeout + "',";
            query = query + "maxendtime = '" + this.end_timeout + "' ";
            query = query + "where shiftid = " + this.id + "";

            return SqlHelper.ExecuteNonQuery(dbCon, CommandType.Text, query);
        }

        public Shifts GetDetail(int id)
        {
            Shifts s = new Shifts();
            query = "select * from shifts where shiftid = " + id + "";
            dt = new DataTable();
            dt = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(dbCon, CommandType.Text, query).Tables[0];
            if (dt.Rows.Count >= 1)
            {
                DataRow row = dt.Rows[0];
                s.id = id;
                s.name = row["shiftname"].ToString();
                s.timein = TimeSpan.Parse(Convert.ToDateTime(row["starttime"].ToString()).ToString("HH:mm"));
                s.timeout = TimeSpan.Parse(Convert.ToDateTime(row["endtime"].ToString()).ToString("HH:mm"));
                if (s.name.ToLower().Equals("rest"))
                    s.actualhrs = TimeSpan.Parse("00:00:00");
                else
                    s.actualhrs = s.timeout.Subtract(s.timein);

                s.start_timein = TimeSpan.Parse(Convert.ToDateTime(row["minstarttime"].ToString()).ToString("HH:mm"));
                s.end_timein = TimeSpan.Parse(Convert.ToDateTime(row["maxstarttime"].ToString()).ToString("HH:mm"));
                s.start_timeout = TimeSpan.Parse(Convert.ToDateTime(row["minendtime"].ToString()).ToString("HH:mm"));
                s.end_timeout = TimeSpan.Parse(Convert.ToDateTime(row["maxendtime"].ToString()).ToString("HH:mm"));
            }
            return s;
        }


    }
}
