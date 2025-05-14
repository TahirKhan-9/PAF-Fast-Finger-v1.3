using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsmanCodeBlocks.Data.Sql;

namespace FASClient.Classes
{
    
   public class BlockedUser
    {

        public int id { get; set; }
        public string uid { get; set; }
        public string name { get; set; }
        public string department { get; set; }
        public string idFac { get; set; }
        public string Smonth { get; set; }
        public string day1 { get; set; }
        public string Shour { get; set; }
        public string Sminute { get; set; }
        public string Emonth { get; set; }
        public string day2 { get; set; }
        public string Ehour { get; set; }
        public string Eminute { get; set; }
        public string weekday { get; set; }
        public string createdOn { get; set; }
        public string createdBy { get; set; }
        public string modifiedOn { get; set; }
        public string modifiedBy { get; set; }

        public BlockedUser()
        {

        }
        public static DataTable GetAll()
        {
            try
            {
                return DBFactory.GetAllByQuery(Globals.GetConnectionString(), "select * from DenialUser;");
            }
            catch (Exception ex)
            {
                Globals.ShowException("Process Failure:\n\r" + ex.Message);
                return null;
            }
        }
        public static DataTable GetAllByquery(string query)
        {
            try
            {
                return DBFactory.GetAllByQuery(Globals.GetConnectionString(), query);
            }
            catch (Exception ex)
            {
                Globals.ShowException("Process Failure:\n\r" + ex.Message);
                return null;
            }
        }


    }
}
