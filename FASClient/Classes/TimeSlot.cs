using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsmanCodeBlocks.Data.Sql;

namespace FASClient.Classes
{
    public class TimeSlot
    {
        public int ID { get; set; }

        public string Name { get; set; }    

        public string StartTime { get; set; }

        public string EndTime { get; set; }
        public string SDate { get; set; }

        public string EDate { get; set; }


        public String WeekDay { get; set; }


        public TimeSlot() { }

        public TimeSlot(int id)
        {
            DataTable dt = DBFactory.GetAllByQuery(Globals.GetConnectionString(), "SELECT * FROM TimeSlot Where FACID = " + id);
            if (dt.Rows.Count >= 1)
            {
                DataRow row = dt.Rows[0];
                this.ID = Convert.ToInt16(row["ID"]);
                this.Name = row["Name"].ToString();
                this.StartTime = row["StartTime"].ToString();
                this.EndTime = row["EndTime"].ToString();
            }
        }

        public bool Save(int selection)
        {
            try
            {
                DBFactory.Insert(Globals.GetConnectionString(), this, false);
                if(selection == 0)
                Cache.timeSlots.Add(this);
                else if(selection == 1)
                Cache.DaytimeSlots.Add(this);

                Cache.ALLtimeSlots.Add(this);

                return true;
            }
            catch (Exception ex)
            {
                Globals.ShowException("Process Failed.\r\n" + ex.Message);
                return false;
            }
        }

        public bool Update(int selection, TimeSlot ts)
        {
            //string query = "UPDATE FACDEFINITION SET ";
            //query += "FACIP = '" + this.FacIP + "', ";
            //query += "Description = '" + this.Description + "', ";
            //query += "MAC = '" + this.Mac + "', ";
            //query += "FACCOMM = '" + this.FacComm + "' WHERE FACID = " + this.FacID;
            var a = ts;
            try
            {
                //int n = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(Globals.GetConnectionString(), CommandType.Text, query);
                bool n = DBFactory.Update(Globals.GetConnectionString(), this);
                if (selection == 0)
                     a = Cache.timeSlots.Where(x => x.ID == this.ID).FirstOrDefault();
                else if (selection == 1)
                     a = Cache.DaytimeSlots.Where(x => x.ID == this.ID).FirstOrDefault();
                if (a != null)
                {
                    a.ID = this.ID;
                    a.Name = this.Name;
                    a.StartTime = this.StartTime;
                    a.EndTime = this.EndTime;
                }

                return true;
            }
            catch (Exception ex)
            {
                Globals.ShowException("Process Failed.\r\n" + ex.Message);
                return false;
            }
        }

        public bool Delete(int selection)
        {
            try
            {
                bool a =DBFactory.Delete(Globals.GetConnectionString(), this);
                if (selection == 0 && a == true)
                {
                    //Cache.ALLtimeSlots.Remove(this);
                    Cache.timeSlots.Remove(this);
                    return true;

                }
                else if (selection == 1 && a == true)
                {
                    //Cache.ALLtimeSlots.Remove(this);
                    Cache.DaytimeSlots.Remove(this);
                    return true;

                }
                //Cache.ALLtimeSlots.Remove(this);
                return false;
            }
            catch (Exception ex)
            {
                Globals.ShowException("Process Failure:\n\r" + ex.Message);
                return false;
            }
        }

        public static DataTable GetAll()
        {
            try
            {
                return DBFactory.GetAllByQuery(Globals.GetConnectionString(), "select * from TimeSlot where WeekDay is null or WeekDay ='';");
            }
            catch (Exception ex)
            {
                Globals.ShowException("Process Failure:\n\r" + ex.Message);
                return null;
            }
        }
        public static DataTable GetAllTimes()
        {
            try
            {
                return DBFactory.GetAll(Globals.GetConnectionString(), "TimeSlot");
            }
            catch (Exception ex)
            {
                Globals.ShowException("Process Failure:\n\r" + ex.Message);
                return null;
            }
        }
        public static DataTable GetAllDay()
        {
            try
            {
                return DBFactory.GetAllByQuery(Globals.GetConnectionString(), "select * from TimeSlot where WeekDay is not null and WeekDay !='';");
            }
            catch (Exception ex)
            {
                Globals.ShowException("Process Failure:\n\r" + ex.Message);
                return null;
            }
        }
    }
}
