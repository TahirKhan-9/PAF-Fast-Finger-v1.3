using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Usman.CodeBlocks.Crypto;
using UsmanCodeBlocks.Data.Sql;

namespace FASClient.Classes
{
    public class EmailServer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string SMTPServer { get; set; }
        public string SMTPPort { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        
        public bool Save()
        {
            
            string query = UsmanCodeBlocks.Data.Sql.Local.DBFactory.GetInsertString(Globals.GetConnectionString(), this, true);
            try
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(Globals.GetConnectionString(), CommandType.Text, "delete from emailserver");
                this.ID = Convert.ToInt32(DBFactory.Insert(Globals.GetConnectionString(), this, true));
                if (this.ID >= 1)
                {

                }
                return true;
            }
            catch (Exception ex)
            {
                Globals.ShowException("Process Failed.\r\n" + ex.Message);
                return false;
            }
        }

        public bool Update(bool photoChanged)
        {
            string query = UsmanCodeBlocks.Data.Sql.Local.DBFactory.GetUpdateString(Globals.GetConnectionString(), this);

            try
            {

                bool updated = DBFactory.Update(Globals.GetConnectionString(), this);

                return updated;
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
                return DBFactory.GetAll(Globals.GetConnectionString(), "EmailServer");
            }
            catch (Exception ex)
            {
                Globals.ShowException("Process Failure:\n\r" + ex.Message);
                return null;
            }
        }

        public EmailServer() { }

        public EmailServer(string server, string port, string user, string pwd)
        {
            this.Name = server;
            this.SMTPServer = server;
            this.SMTPPort = port;
            this.UserName = user;
            this.Password = StringCipher.Encrypt(pwd);
        }

        public EmailServer Get()
        {
            EmailServer obj = new EmailServer();
            DataTable dt = this.GetAll();
            if (dt.Rows.Count >= 1)
            {
                DataRow row = dt.Rows[0];
                obj = Globals.GetItem<EmailServer>(row);
                obj.Password = StringCipher.Decrypt(obj.Password);
            }

            return obj;
        }

    }
}
