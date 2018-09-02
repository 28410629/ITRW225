using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

namespace ITRW225_Information_System
{
    class BE_UserMaintenance
    {
        public List<string[]> loadEmployee()
        {
            DataSet dataSetEmployee;
            List<string[]> list = new List<string[]>();
            using (OleDbConnection database = new OleDbConnection(Properties.Settings.Default.DatabaseConnectionString))
            {
                database.Open();
                OleDbDataAdapter adapterE = new OleDbDataAdapter("SELECT * FROM EMPLOYEE", database);
                dataSetEmployee = new DataSet();
                adapterE.Fill(dataSetEmployee, "listE");
                database.Close();
            }
            for (int i = 0; i < dataSetEmployee.Tables[0].Rows.Count; i++)
            {
                /* arr
                 * 0 - employee id
                 * 1 - full name
                 */
                string[] arr = new string[] { dataSetEmployee.Tables[0].Rows[i].ItemArray.GetValue(0).ToString(),
                                              dataSetEmployee.Tables[0].Rows[i].ItemArray.GetValue(2).ToString() + " " + 
                                              dataSetEmployee.Tables[0].Rows[i].ItemArray.GetValue(3).ToString() };
                list.Add(arr);
            }
            dataSetEmployee.Dispose();
            return list;
        }

        public List<string[]> loadLogin()
        {
            DataSet dataSetLogin;
            List<string[]> list = new List<string[]>();
            using (OleDbConnection database = new OleDbConnection(Properties.Settings.Default.DatabaseConnectionString))
            {
                database.Open();
                OleDbDataAdapter adapterL = new OleDbDataAdapter("SELECT * FROM LOGIN", database);
                dataSetLogin = new DataSet();
                adapterL.Fill(dataSetLogin, "listL");
                database.Close();
            }
            for (int i = 0; i < dataSetLogin.Tables[0].Rows.Count; i++)
            {
                /* arr
                 * 0 - employee id
                 * 1 - password
                 * 2 - client maintenance
                   3 - employee maintenance
                   4 - points of sale
                   5 - reports
                   6 - user maintenance
                   7 - settings
                 */
                string[] arr = new string[] { dataSetLogin.Tables[0].Rows[i].ItemArray.GetValue(1).ToString(),
                                              dataSetLogin.Tables[0].Rows[i].ItemArray.GetValue(3).ToString(),
                                              dataSetLogin.Tables[0].Rows[i].ItemArray.GetValue(4).ToString(),
                                              dataSetLogin.Tables[0].Rows[i].ItemArray.GetValue(5).ToString(),
                                              dataSetLogin.Tables[0].Rows[i].ItemArray.GetValue(6).ToString(),
                                              dataSetLogin.Tables[0].Rows[i].ItemArray.GetValue(7).ToString(),
                                              dataSetLogin.Tables[0].Rows[i].ItemArray.GetValue(8).ToString(),
                                              dataSetLogin.Tables[0].Rows[i].ItemArray.GetValue(9).ToString(),
                                              dataSetLogin.Tables[0].Rows[i].ItemArray.GetValue(10).ToString()};
                list.Add(arr);
            }
            dataSetLogin.Dispose();
            return list;
        }

        public string updateCheckDB(bool[] arr, string employeeID)
        {
            List<string> list = new List<string>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i])
                {
                    list.Add("true");
                }
                else
                {
                    list.Add("false");
                }
            }
            try
            {
                using (OleDbConnection database = new OleDbConnection(Properties.Settings.Default.DatabaseConnectionString))
                {
                    database.Open();
                    OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM LOGIN", database);
                    OleDbCommand command = new OleDbCommand(String.Format("UPDATE LOGIN SET [A_CLIENT_MAINTENANCE] = @0, [A_EMPLOYEE_MAINTENANCE] = @1, [A_POINTS_OF_SALE] = @2, [A_REPORTS] = @3, [A_USER_MAINTENANCE] = @4, [A_SETTINGS] = @5 WHERE [EMPLOYEE_ID] = {0}", employeeID), database);
                    command.Parameters.Add("@0", OleDbType.Boolean).Value = list[0];
                    command.Parameters.Add("@1", OleDbType.Boolean).Value = list[1];
                    command.Parameters.Add("@2", OleDbType.Boolean).Value = list[2];
                    command.Parameters.Add("@3", OleDbType.Boolean).Value = list[3];
                    command.Parameters.Add("@4", OleDbType.Boolean).Value = list[4];
                    command.Parameters.Add("@5", OleDbType.Boolean).Value = list[5];
                    adapter.InsertCommand = command;
                    adapter.InsertCommand.ExecuteNonQuery();
                    database.Close();
                }
                return "Updated permissions!";
            }
            catch (Exception ex)
            {
                BE_LogSystem log = new BE_LogSystem(ex);
                log.saveError();
                return "Failed updating permission!";
            }
            
        }

        public string updatePassCheckDB(bool[] arr, string employeeID, string password)
        {
            List<string> list = new List<string>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i])
                {
                    list.Add("true");
                }
                else
                {
                    list.Add("false");
                }
            }
            try
            {
                using (OleDbConnection database = new OleDbConnection(Properties.Settings.Default.DatabaseConnectionString))
                {
                    BE_DatabaseCommands dbCommands = new BE_DatabaseCommands();
                    database.Open();
                    OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM LOGIN", database);
                    OleDbCommand command = new OleDbCommand(String.Format("UPDATE LOGIN SET [A_CLIENT_MAINTENANCE] = @0, [A_EMPLOYEE_MAINTENANCE] = @1, [A_POINTS_OF_SALE] = @2, [A_REPORTS] = @3, [A_USER_MAINTENANCE] = @4, [A_SETTINGS] = @5, [PASSWORD] = '{0}' WHERE [EMPLOYEE_ID] = {1}", dbCommands.hashPassword(password), employeeID), database);
                    command.Parameters.Add("@0", OleDbType.Boolean).Value = list[0];
                    command.Parameters.Add("@1", OleDbType.Boolean).Value = list[1];
                    command.Parameters.Add("@2", OleDbType.Boolean).Value = list[2];
                    command.Parameters.Add("@3", OleDbType.Boolean).Value = list[3];
                    command.Parameters.Add("@4", OleDbType.Boolean).Value = list[4];
                    command.Parameters.Add("@5", OleDbType.Boolean).Value = list[5];
                    adapter.InsertCommand = command;
                    adapter.InsertCommand.ExecuteNonQuery();
                    database.Close();
                }
                return "Updated permissions and password!";
            }
            catch (Exception ex)
            {
                BE_LogSystem log = new BE_LogSystem(ex);
                log.saveError();
                return "Failed updating permission and password!";
            }
        }

        public string accessSystemDB(string access, string employeeID)
        {
            try
            {
                using (OleDbConnection database = new OleDbConnection(Properties.Settings.Default.DatabaseConnectionString))
                {
                    BE_DatabaseCommands dbCommands = new BE_DatabaseCommands();
                    database.Open();
                    OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM LOGIN", database);
                    OleDbCommand command = new OleDbCommand(String.Format("UPDATE LOGIN SET [A_TO_SYSTEM] = @0 WHERE [EMPLOYEE_ID] = {0}", employeeID), database);
                    command.Parameters.Add("@0", OleDbType.Boolean).Value = access;
                    adapter.InsertCommand = command;
                    adapter.InsertCommand.ExecuteNonQuery();
                    database.Close();
                }
                return "Updated access permission to system!";
            }
            catch (Exception ex)
            {
                BE_LogSystem log = new BE_LogSystem(ex);
                log.saveError();
                return "Failed updating access permission to system!";
            }
        }
    }
}
