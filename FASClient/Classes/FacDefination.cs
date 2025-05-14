using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using UsmanCodeBlocks.Data.Sql;

namespace FASClient
{

    public class FacDefinition
    {
        public Int16 FacID { get; set; }
        public string FacIP { get; set; }
        public string Description { get; set; }
        public Int16 Flag { get; set; }
        public int Port_C { get; set; }
        public int Port_S { get; set; }
        public Int64 FacMac { get; set; }
        public string FacUUID { get; set; }
        public string FacComm { get; set; }
        public string Mac { get; set; }
        public int Restricted { get; set; }

        public FacDefinition() { }

        public FacDefinition(Int16 id)
        {
            DataTable dt = DBFactory.GetAllByQuery(Globals.GetConnectionString(), "SELECT * FROM FacDefinition Where FACID = " + id);
            if (dt.Rows.Count >= 1)
            {
                DataRow row = dt.Rows[0];
                this.FacID = Convert.ToInt16(row["facid"]);
                this.FacIP = row["facip"].ToString();
                this.Description = row["description"].ToString();
                if (!row.IsNull("flag")) { this.Flag = Convert.ToInt16(row["flag"]); }
                if (!row.IsNull("port_c")) { this.Port_C = Convert.ToInt32(row["port_c"]); }
                if (!row.IsNull("port_s")) { this.Port_S = Convert.ToInt32(row["port_s"]); }
                if (!row.IsNull("facmac")) { this.FacMac = Convert.ToInt64(row["facmac"]); }
                this.FacUUID = row["facuuid"].ToString();
                this.FacComm = row["faccomm"].ToString();
                this.Mac = row["mac"].ToString();
            }
        }

        public bool Save()
        {
            try
            {
                DBFactory.Insert(Globals.GetConnectionString(), this,false);
                Cache.facList.Add(this);
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
            string query = "UPDATE FACDEFINITION SET ";
            query += "FACIP = '" + this.FacIP + "', ";
            query += "Description = '" + this.Description + "', ";
            query += "MAC = '" + this.Mac + "', ";
            query += "Restricted = " + this.Restricted + ", ";
            query += "FACCOMM = '" + this.FacComm + "' WHERE FACID = " + this.FacID;

            try
            {
                int n = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(Globals.GetConnectionString(), CommandType.Text, query);
                var a = Cache.facList.Where(x => x.FacID == this.FacID).FirstOrDefault();
                if (a != null)
                {
                    a.FacIP = this.FacIP;
                    a.Description = this.Description;
                    a.Mac = this.Mac;
                    a.Flag = this.Flag;
                    a.Port_C = this.Port_C;
                    a.Port_S = this.Port_S;
                    a.FacMac = this.FacMac;
                    a.FacUUID = this.FacUUID;
                    a.FacComm = this.FacComm;
                    
                }

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
                Cache.facList.Remove(this);
                return true;
            }
            catch (Exception ex)
            {
                Globals.ShowException("Process Failure:\n\r" + ex.Message);
                return false;
            }
        }
        public DataTable GetAllByQuery()
        {
            try
            {
                return DBFactory.GetAllByQuery(Globals.GetConnectionString(), "SELECT *  FROM FacDefinition where Restricted = '1'");
            }
            catch (Exception ex)
            {
                Globals.ShowException("Process Failure:\n\r" + ex.Message);
                return null;
            }
        }

        public DataTable GetAll()
        {
            try
            {
                return DBFactory.GetAll(Globals.GetConnectionString(), "FacDefinition");
            }
            catch (Exception ex)
            {
                Globals.ShowException("Process Failure:\n\r" + ex.Message);
                return null;
            }
        }
    }
}
