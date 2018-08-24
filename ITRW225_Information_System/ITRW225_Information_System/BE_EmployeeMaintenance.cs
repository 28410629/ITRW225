using System;
using System.Data.OleDb;

namespace ITRW225_Information_System
{
    public class BE_EmployeeMaintenance
    {
        public string saveDB(string[] arr, bool addEmployee)
        {
            try
            {
                /*using (OleDbConnection database = new OleDbConnection(Properties.Settings.Default.DatabaseConnectionString))
                {
                    database.Open();
                    OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM EMPLOYEE", database);
                    OleDbCommand command = new OleDbCommand(String.Format("UPDATE LOGIN SET [A_CLIENT_MAINTENANCE] = @0, [A_EMPLOYEE_MAINTENANCE] = @1, [A_POINTS_OF_SALE] = @2, [A_REPORTS] = @3, [A_USER_MAINTENANCE] = @4, [A_SETTINGS] = @5 WHERE [EMPLOYEE_ID] = 0"), database);
                    adapter.InsertCommand = command;
                    adapter.InsertCommand.ExecuteNonQuery();
                    database.Close();
                }*/
                return "Succesfully saved to database!";
            }
            catch (Exception ex)
            {
                BE_LogSystem log = new BE_LogSystem(ex);
                log.saveError();
                return "Failed saving to database!";
            }
        }
    }
}
