using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using UsmanCodeBlocks.Data.Sql;

namespace FASClient
{
    class Company
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string ImagePath { get; set; }
        public string State { get; set; }

        public bool Save()
        {

            try
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(Globals.GetConnectionString(), CommandType.Text, "Delete from Company");
                Convert.ToInt32(DBFactory.Insert(Globals.GetConnectionString(), this, false));
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
            try
            {
                DBFactory.Update(Globals.GetConnectionString(), this);
                return true;
            }
            catch (Exception ex)
            {
                Globals.ShowException("Process Failed.\r\n" + ex.Message);
                return false;
            }
        }

        public bool Delete()
        {

            try
            {
                DBFactory.Delete(Globals.GetConnectionString(), this);
                return true;
            }
            catch (Exception ex)
            {
                Globals.ShowException("Process Failure:\n\r" + ex.Message);
                return false;
            }
        }

        public Company Get()
        {
            Company coy = new FASClient.Company();
            try
            {
                DataTable dt = DBFactory.GetAll(Globals.GetConnectionString(), "Company");
                if (dt.Rows.Count >= 1)
                    coy = Globals.GetItem<Company>(dt.Rows[0]);

                return coy;
            }
            catch (Exception ex)
            {
                Globals.ShowException("Process Failure:\n\r" + ex.Message);
                return null;
            }
        }

    }
}
