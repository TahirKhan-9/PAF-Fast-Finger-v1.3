using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsmanCodeBlocks.Data.Sql;

namespace FASClient.Classes
{
    public class tbl_Building
    {
        public int ID { get; set; }
        public string Building_Name { get; set; }
        public string Description { get; set; }
        
        public static DataTable GetAll()
        {
            try
            {
                return DBFactory.GetAllByQuery(Globals.GetConnectionString(), "select * from tbl_Building;");
            }
            catch (Exception ex)
            {
                Globals.ShowException("Process Failure:\n\r" + ex.Message);
                return null;
            }
        }
    }
}
