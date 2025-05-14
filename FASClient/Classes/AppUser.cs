using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Microsoft.ApplicationBlocks.Data;
using Usman.CodeBlocks.Crypto;
using UsmanCodeBlocks.Data.Sql;

namespace FASClient
{
    public class AppUser
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string LoginID { get; set; }
        public string LoginPwd { get; set; }
        public int RoleID { get; set; }

        public AppUser()
        { }

        public AppUser(int id)
        {
            string query = "select * from appuser where userid = " + id;
            DataTable dt = new DataTable();
            dt = SqlHelper.ExecuteDataset(Globals.GetConnectionString(), CommandType.Text, query).Tables[0];
            if (dt.Rows.Count >= 1)
            {
                DataRow row = dt.Rows[0];
                this.UserID = Convert.ToInt32(row["userid"].ToString());
                this.UserName = row["username"].ToString();
                this.LoginID = row["loginid"].ToString();
                this.LoginPwd = StringCipher.Decrypt(row["loginpwd"].ToString());
                this.RoleID = Convert.ToInt32(row["roleid"].ToString());
            }
        }

        public int TotalUsers()
        {
            string query = "select count(*) from appuser";
            return Convert.ToInt32(SqlHelper.ExecuteScalar(Globals.GetConnectionString(), CommandType.Text, query).ToString());
        }

        public bool Save()
        {
            string query = UsmanCodeBlocks.Data.Sql.Local.DBFactory.GetInsertString(Globals.GetConnectionString(), this, true);

            try
            {
                this.LoginPwd = StringCipher.Encrypt("ddspak");
                this.UserID = Convert.ToInt32(DBFactory.Insert(Globals.GetConnectionString(), this, true));
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
                this.LoginPwd = StringCipher.Encrypt(this.LoginPwd);
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
                return DBFactory.GetAll(Globals.GetConnectionString(), "AppUser");
            }
            catch (Exception ex)
            {
                Globals.ShowException("Process Failure:\n\r" + ex.Message);
                return null;
            }
        }

        public List<AppUser> GetList()
        {
            List<AppUser> list = new List<AppUser>();
            try
            {
                DataTable dt =  DBFactory.GetAll(Globals.GetConnectionString(), "AppUser");
                if (dt.Rows.Count >= 1)
                    list = Globals.ConvertDataTable<AppUser>(dt);
                return list;
            }
            catch (Exception ex)
            {
                Globals.ShowException("Process Failure:\n\r" + ex.Message);
                return null;
            }
        }

        public AppUser Login(string login, string pass)
        {
            AppUser u = new AppUser();
            //string query = "select * from appuser where loginid = '" + login + "' and loginpwd = '" + StringCipher.Encrypt(pass) + "'";
            string query = "select * from appuser where loginid = '" + login + "'";
            DataTable dt = new DataTable();
            dt = DBFactory.GetAllByQuery(Globals.GetConnectionString(), query);
            if (dt.Rows.Count >= 1)
            {
                DataRow row = dt.Rows[0];
                u.UserID = Convert.ToInt32(row["userid"].ToString());
                u.UserName = row["username"].ToString();
                u.LoginID = row["loginid"].ToString();
                u.LoginPwd = StringCipher.Decrypt(row["loginpwd"].ToString());
                u.RoleID = Convert.ToInt32(row["roleid"].ToString());
            }

            return u;
        }

    }
}
