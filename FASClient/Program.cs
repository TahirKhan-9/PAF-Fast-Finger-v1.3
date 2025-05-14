using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using FASClient.Forms;

namespace FASClient
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                #region App
                // Database Changes
                using (SqlConnection connection = new SqlConnection(Globals.GetConnectionString()))
                {
                    connection.Open();
                    DataTable schema = connection.GetSchema("Tables");

                    #region EmployeeTable
                    string query = "";

                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'EMPLOYEE' AND COLUMN_NAME = 'Hostel'", connection);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    if (count <= 0)
                    {
                        query = "ALTER TABLE EMPLOYEE ADD Hostel bit NULL";
                        using (SqlCommand command = new SqlCommand(query, connection))
                            command.ExecuteNonQuery();
                    }

                    cmd = new SqlCommand("SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'EMPLOYEE' AND COLUMN_NAME = 'HOSTELNAME'", connection);
                    if (Convert.ToInt32(cmd.ExecuteScalar().ToString()) <= 0)
                    {
                        query = "ALTER TABLE EMPLOYEE ADD HostelName varchar(200) null";
                        using (SqlCommand command = new SqlCommand(query, connection))
                            command.ExecuteNonQuery();
                    }

                    cmd = new SqlCommand("SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'EMPLOYEE' AND COLUMN_NAME = 'REPORTINGPERSON'", connection);
                    if (Convert.ToInt32(cmd.ExecuteScalar().ToString()) <= 0)
                    {
                        query = "ALTER TABLE EMPLOYEE ADD ReportingPerson bit null";
                        using (SqlCommand command = new SqlCommand(query, connection))
                            command.ExecuteNonQuery();
                    }

                    cmd = new SqlCommand("SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'BLOCKEDUSER' AND COLUMN_NAME = 'PERMANENT'", connection);
                    if (Convert.ToInt32(cmd.ExecuteScalar().ToString()) <= 0)
                    {
                        query = "ALTER TABLE BLOCKEDUSER ADD Permanent bit null";
                        using (SqlCommand command = new SqlCommand(query, connection))
                            command.ExecuteNonQuery();
                    }

                    String path = Directory.GetCurrentDirectory() + "\\Query.txt";

                    if (File.Exists(path))
                    {
                        query = File.ReadAllText(path);
                        using (SqlCommand command = new SqlCommand(query, connection))
                            command.ExecuteNonQuery();
                    }

                    using (SqlCommand command = new SqlCommand("update employee set section = 'Staff/Faculty' where section = 'Staff' or section = 'Faculty'", connection))
                        command.ExecuteNonQuery();


                    //int count = Convert.ToInt32(Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteScalar(connection, CommandType.Text, "SELECT COUNT(*) FROM EMPLOYEE WHERE HOSTELNAME IS NULL"));
                    //if (count > 1000)
                    //{
                    //    cmd = new SqlCommand("UPDATE EMPLOYEE SET HOSTEL = (SELECT distinct u.HOSTEL FROM [USER] u WHERE u.ID = Code AND u.HOSTEL IS NOT NULL)", connection);
                    //    cmd.ExecuteNonQuery();

                    //    cmd = new SqlCommand("UPDATE EMPLOYEE SET HOSTELNAME = (SELECT distinct u.HOSTELNAME FROM [USER] u WHERE u.ID = Code)", connection);
                    //    cmd.ExecuteNonQuery();
                    //}
                    #endregion

                    //cmd = new SqlCommand("SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'USER' AND COLUMN_NAME = 'ID'", connection);
                    //if (Convert.ToInt32(cmd.ExecuteScalar().ToString()) <= 0)
                    //{
                    //    // set students
                    //    query = "UPDATE Employee SET Section = 'Student' WHERE(Code = (SELECT DISTINCT ID FROM [User] AS u WHERE(GID IN(11, 12)) AND(ID = Employee.Code)))";
                    //    Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(connection, CommandType.Text, query);

                    //    // set staff
                    //    query = "UPDATE Employee SET Section = 'Staff' WHERE(Code = (SELECT DISTINCT ID FROM [User] AS u WHERE(GID IN(21, 22)) AND(ID = Employee.Code)))";
                    //    Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(connection, CommandType.Text, query);

                    //    // set faculty
                    //    query = "UPDATE Employee SET Section = 'Faculty' WHERE(Code = (SELECT DISTINCT ID FROM [User] AS u WHERE(GID IN(31, 32)) AND(ID = Employee.Code)))";
                    //    Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(connection, CommandType.Text, query);

                    //    // set visitor
                    //    query = "UPDATE Employee SET Section = 'Visitors' WHERE(Code = (SELECT DISTINCT ID FROM [User] AS u WHERE(GID IN(41, 42)) AND(ID = Employee.Code)))";
                    //    Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(connection, CommandType.Text, query);
                    //}

                    cmd = new SqlCommand("SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'FACDEFINITION' AND COLUMN_NAME = 'MAC'", connection);
                    if (Convert.ToInt32(cmd.ExecuteScalar().ToString()) <= 0)
                    {
                        query = "ALTER TABLE FACDEFINITION ADD Mac varchar(100) NULL";
                        using (SqlCommand command = new SqlCommand(query, connection))
                            command.ExecuteNonQuery();
                    }
                    connection.Close();

                }
                //Application.Run(new frm_Bui());
                 Application.Run(new frmMain());
                //Application.Run(new frmRestrictedMachines());

                #endregion

                //Application.Run(new Forms.frmConnectionString());

            }
            catch (SqlException ex)
            {
                if (ex.InnerException != null)
                {
                    if (ex.InnerException.Message.ToLower().Contains("network"))
                        MessageBox.Show("Server Not Connected. Try Again Later.");
                }
                else
                    MessageBox.Show("Failed to Start\n\r" + ex.Message);
            }
        }
    }
}
