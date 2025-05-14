using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;
using System.Data;

namespace FASClient.Classes
{
    public class SPHelper
    {
        public static DataTable executeSP(string spName, Dictionary<string, string> parameters)
        {
            try
            {
                SqlParameter[] paramArray = new SqlParameter[parameters.Count];
                int i = 0;
                foreach (KeyValuePair<string, string> pair in parameters)
                {
                    paramArray[i] = new SqlParameter(pair.Key, pair.Value);
                    i++;
                }
                return SqlHelper.ExecuteDataset(Globals.GetConnectionString(), CommandType.StoredProcedure, spName, paramArray).Tables[0];
            }
            catch (Exception e) {
                new Forms.frmMessageBox(MessageBoxType.Alert, e.Message+"\nTry Again...").ShowDialog();
                return new DataTable();
            }
            
        }
    }
}
