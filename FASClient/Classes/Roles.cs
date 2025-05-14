using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using UsmanCodeBlocks.Data.Sql;
using System.Reflection;

namespace FASClient
{

    public class Roles
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool Company { get; set; }
        public bool DutyShifts { get; set; }
        public bool Role { get; set; }
        public bool Logins { get; set; }
        public bool ImportUser { get; set; }
        public bool UserInfo { get; set; }
        public bool UserGroups { get; set; }
        public bool DutySchedules { get; set; }
        public bool UserListReports { get; set; }
        public bool TimeSheetReport { get; set; }
        public bool AttendanceDetailReport { get; set; }
        public bool AttendanceSummaryReport { get; set; }
        public bool Enrollment { get; set; }
        public bool CardManagement { get; set; }
        public bool Photos { get; set; }
        public bool DeviceSetup { get; set; }
        public bool DeviceUsersManagement { get; set; }
        public bool SuspendUsers { get; set; }
        public bool BlockUsers { get; set; }
        public bool ProfilePhotosSetup { get; set; }

        public Roles() { }

        public Roles(int _id)
        {
            try
            {
                Type temp = typeof(Roles);
                DataTable dt = DBFactory.GetByID(Globals.GetConnectionString(), "Roles", _id);
                if (dt != null)
                {
                    DataRow row = dt.Rows[0];
                    Roles role = Globals.GetItem<Roles>(row);
                    //foreach (PropertyInfo p in temp.GetProperties())
                    //{
                        foreach (PropertyInfo pi in temp.GetProperties())
                        {
                            pi.SetValue(this, pi.GetValue(role, null), null);
                        }
                    //}
                }
            }
            catch(Exception ex)
            {
                Globals.ShowException("Process Failed.\r\n" + ex.Message);
            }

        }

        public bool Save()
        {
            try
            {
                this.ID = Convert.ToInt32(DBFactory.Insert(Globals.GetConnectionString(), this, true));
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
            string query = UsmanCodeBlocks.Data.Sql.Local.DBFactory.GetUpdateString(Globals.GetConnectionString(), this);
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

        public DataTable GetAll()
        {
            try
            {
                return DBFactory.GetAll(Globals.GetConnectionString(), "Roles");
            }
            catch (Exception ex)
            {
                Globals.ShowException("Process Failure:\n\r" + ex.Message);
                return null;
            }
        }

        public List<Roles> GetList()
        {
            List<Roles> list = new List<FASClient.Roles>();
            try
            {
                DataTable dt =  DBFactory.GetAll(Globals.GetConnectionString(), "Roles");
                if (dt.Rows.Count >= 1)
                    list = Globals.ConvertDataTable<Roles>(dt);

                return list;
            }
            catch (Exception ex)
            {
                Globals.ShowException("Process Failure:\n\r" + ex.Message);
                return null;
            }
        }

        public bool isConsumed()
        {
            try
            {
                string query = "select count(*) from appuser where roleid = " + this.ID;
                int n = DBFactory.GetRecCountByQuery(Globals.GetConnectionString(), query);
                return Convert.ToBoolean(n);
            }
            catch (Exception ex)
            {
                Globals.ShowException("Process Failure:\n\r" + ex.Message);
                return false;
            }
        }
    }
}