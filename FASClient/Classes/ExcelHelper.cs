using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.IO;

namespace FASClient
{
    public class ExcelHelper
    {
        static string strCon;
        static OleDbConnection con;
        
        public static void Connect(string fileName)
        {
            if (!fileName.Contains(".xlsx"))
                strCon = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = '" + fileName + "'; Extended Properties = 'Excel 8.0;HDR=YES;'";
            else
              //  strCon = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source= '" + fileName + "';Extended Properties=Excel 12.0 Xml;HDR=YES';";
                strCon = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties='Excel 12.0;IMEX=1;'"; ;
            con = new OleDbConnection(strCon);
            con.Open();
        }

        public static void DisConnect()
        {
            if (con.State != ConnectionState.Closed)
                con.Close();
        }

        public static DataTable GetData(string fileName,string sheet)
        {
            
            Connect(fileName);
            OleDbDataAdapter da = new OleDbDataAdapter("select * from [Sheet" + sheet + "$]", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DisConnect();
            return dt;
        }

        public static List<DataTable> GetData(string fileName)
        {
            List<DataTable> tables = new List<DataTable>();

            Connect(fileName);

            DataTable dtSheets = new DataTable();
            dtSheets = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            if (dtSheets.Rows.Count >= 1)
            {
                foreach (DataRow sheet in dtSheets.Rows)
                {
                    string s = sheet[2].ToString();
                    int len = s.Length;
                    int index = s.IndexOf('$');

                    if (index + 2 < len) { s = s.Remove(index+2, len - (index+2)); }

                    OleDbDataAdapter da = new OleDbDataAdapter("select * from [" + s + "]", con);
                    DataTable dt = new DataTable();
                    dt.TableName = sheet[2].ToString();
                    da.Fill(dt);

                    tables.Add(dt);
                }
            }

            DisConnect();

            return tables;
        }
       
    }
}
