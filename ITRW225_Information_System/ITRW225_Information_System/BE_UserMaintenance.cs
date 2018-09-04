using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

namespace ITRW225_Information_System
{
    class BE_UserMaintenance
    {
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

        
    }
}
