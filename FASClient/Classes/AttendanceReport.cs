using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsmanCodeBlocks.Data.Sql.Local;

namespace FASClient.Classes
{
    public class AttendanceReport
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
        public DateTime UsrDate { get; set; }
        public int DayNo { get; set; }
        public string Remarks { get; set; }

        public bool Save()
        {
            string query = DBFactory.GetInsertString(Globals.GetConnectionString(), this, true);
            try
            {
                int result = Convert.ToInt32(DBFactory.Insert(Globals.GetConnectionString(), this, true));
                return true;
            }
            catch (Exception ex)
            {
                Globals.ShowException("Process Failed.\r\n" + ex.Message);
                return false;
            }
        }

        public bool Update()
        {
            string query = "UPDATE [AttendanceReport] SET Code = '"+this.Code+ "' , Name = '"+this.Name+ "' , Designation = '"+this.Designation+ "' , Department = '"+this.Department+ "' , UsrDate = '"+this.UsrDate.Date+ "' , DayNo = "+this.DayNo+ " , Remarks = '" + this.Remarks + "'  WHERE Code = '"+this.Code+ "' And  UsrDate = '"+this.UsrDate+ "' And DayNo = "+this.DayNo+" IF @@ROWCOUNT = 0 " + DBFactory.GetInsertString(Globals.GetConnectionString(), this, true);
            
            


            try
            {
                bool updated = Convert.ToBoolean(SqlHelper.ExecuteNonQuery(Globals.GetConnectionString(), CommandType.Text, query));

                
                if (updated)
                {

                }
                else{

                }

                return updated;
            }
            catch (Exception ex)
            {
                Globals.ShowException("Process Failed.\r\n" + ex.Message);
                return false;
            }
        }
        
    }
}
