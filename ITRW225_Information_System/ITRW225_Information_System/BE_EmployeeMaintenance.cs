using System;
using System.Collections.Generic;
using System.Data.OleDb;

namespace ITRW225_Information_System
{
    public class BE_EmployeeMaintenance
    {
        /*
         textBoxFN.Text, textBoxHN.Text, textBoxCN.Text, textBoxEA.Text,
         textBoxID.Text, textBoxLN.Text, textBoxPC.Text, textBoxS.Text,
         textBoxSN.Text, textBoxVAT.Text, comboBoxCN.SelectedItem.ToString()
        */
        public string saveDB(string[] arr, bool addEmployee)
        {
            try
            {
                using (OleDbConnection database = new OleDbConnection(Properties.Settings.Default.DatabaseConnectionString))
                {
                    /*database.Open();
                    OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM EMPLOYEE", database);
                    OleDbCommand commandContact = new OleDbCommand(String.Format("INSERT INTO EMPLOYEE (EMPLOYEE_TYPE_NUMBER, CONTACT_DETAILS_NUMBER, EMPLOYEE_NAME, EMPLOYEE_SURNAME) VALUES({0}, {1}, {2}, {3})", 0, 0, arr[0], arr[1]), database);
                    adapter.InsertCommand = command;
                    adapter.InsertCommand.ExecuteNonQuery();
                    OleDbCommand commandEmployee = new OleDbCommand(String.Format("INSERT INTO EMPLOYEE (EMPLOYEE_TYPE_NUMBER, CONTACT_DETAILS_NUMBER, EMPLOYEE_NAME, EMPLOYEE_SURNAME) VALUES({0}, {1}, {2}, {3})", 0, 0, arr[0], arr[1]), database);
                    adapter.InsertCommand = command;
                    adapter.InsertCommand.ExecuteNonQuery();
                    database.Close();*/
                }
                return "Succesfully saved to database!";
            }
            catch (Exception ex)
            {
                BE_LogSystem log = new BE_LogSystem(ex);
                log.saveError();
                return "Failed saving to database!";
            }
        }

        public List<string> loadDB()
        {
            List<string> list = new List<string>();
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
                list.Add("Succesfully loaded database!");
                return list;
            }
            catch (Exception ex)
            {
                BE_LogSystem log = new BE_LogSystem(ex);
                log.saveError();
                list.Add("Failed loading database!");
                return list;
            }
        }
    }
}
