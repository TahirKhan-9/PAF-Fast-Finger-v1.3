using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsmanCodeBlocks.Data.Sql;

namespace FASClient.Classes
{
    public class p_person
    {
        public string work_no { get; set; }
        public string id_no { get; set; }
        public string id_name { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string card_no { get; set; }

        public string title_no { get; set; }

        public  DataTable GetAllByquery(string query)
        {
            try
            {
                return DBFactory.GetAllByQuery(Globals.RMSConnectionString(), query);
            }
            catch (Exception ex)
            {
                Globals.ShowException("Process Failure:\n\r" + ex.Message);
                return null;
            }
        }
        public bool Update(string emp_code, string veh_no, string empName, string veh_type , string tag_uid)
        {
            try
            {
                string query = "UPDATE [rms_a].[dbo].[p_person] SET id_no='" + emp_code + "', id_name = '" + veh_no + "' , last_name = '" + empName + "', title_no = '" + veh_type + "' WHERE work_no = '" + tag_uid + "';";
                bool n = DBFactory.Update(Globals.RMSConnectionString(), query);
                if (n)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                Globals.ShowException("Process Failed.\r\n" + ex.Message);
                return false;
            }
        }

    }
}
