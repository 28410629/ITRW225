using System;
using System.Collections.Generic;
using System.Data;
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

        public string updateDB(string[] arr)
        {
            try
            {
                /*{                                    0 textBoxFN.Text,
                                                       1 textBoxLN.Text,
                                                       2 textBoxID.Text,
                                                       3 textBoxHN.Text,
                                                       4 textBoxSN.Text,
                                                       5 textBoxPC.Text,
                                                       6 textBoxCN.Text,
                                                       7 textBoxCN2.Text,
                                                       8 textBoxS.Text,
                                                       9 textBoxEA.Text,
                                                       10 comboBoxCN.SelectedItem.ToString(),
                                                       11 posNumber,
                                                       12 oldEmployeeID,
                                                       13 contactDetailsNumber  };*/
                /*using (OleDbConnection database = new OleDbConnection(Properties.Settings.Default.DatabaseConnectionString))
                {
                    database.Open();
                    OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM EMPLOYEE", database);
                    OleDbCommand commandEmployee = new OleDbCommand(String.Format("UPDATE EMPLOYEE SET EMPLOYEE_ID, EMPLOYEE_TYPE_NUMBER, EMPLOYEE_NAME, EMPLOYEE_SURNAME) VALUES({0}, {1}, {2}, {3}) WHERE EMPLOYEE_ID = {4};", arr[2], arr[11], arr[0], arr[1], arr[12]), database);
                    adapter.InsertCommand = commandEmployee;
                    adapter.InsertCommand.ExecuteNonQuery();
                    database.Close();
                }*/
                using (OleDbConnection database = new OleDbConnection(Properties.Settings.Default.DatabaseConnectionString))
                {
                    database.Open();
                    OleDbDataAdapter adapterC = new OleDbDataAdapter("SELECT * FROM CONTACT_DETAILS", database);
                    OleDbCommand commandContact = new OleDbCommand(String.Format("UPDATE CONTACT_DETAILS SET [HOUSE_NUMBER] = '@HN', [STREET_NAME] = '@SN', [POSTAL_CODE] = '@PC', [CELL_NUMBER] = '@OCN', [BACKUP_CELL_NUMBER] = '@BCN', [SUBURB] = '@S', [CITY] = '@CN', [EMAIL] = '@EA', [EMPLOYEE_ID] = '@NID' WHERE CONTACT_DETAILS_NUMBER = @CDN"), database);
                    commandContact.Parameters.AddWithValue("@CDN", arr[13]);
                    commandContact.Parameters.AddWithValue("@NID", arr[2]);
                    commandContact.Parameters.AddWithValue("@EA", arr[9]);
                    commandContact.Parameters.AddWithValue("@CN", arr[10]);
                    commandContact.Parameters.AddWithValue("@S", arr[8]);
                    commandContact.Parameters.AddWithValue("@BCN", arr[7]);
                    commandContact.Parameters.AddWithValue("@OCN", arr[6]);
                    commandContact.Parameters.AddWithValue("@PC", arr[5]);
                    commandContact.Parameters.AddWithValue("@SN", arr[4]);
                    commandContact.Parameters.AddWithValue("@HN", arr[3]);
                    adapterC.InsertCommand = commandContact;
                    adapterC.InsertCommand.ExecuteNonQuery();
                    database.Close();
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

        public List<string[]> loadEmployee()
        {
            DataSet dataSetEmployee;
            List<string[]> list = new List<string[]>();
            using (OleDbConnection database = new OleDbConnection(Properties.Settings.Default.DatabaseConnectionString))
            {
                database.Open();
                OleDbDataAdapter adapterE = new OleDbDataAdapter("SELECT * FROM EMPLOYEE ORDER BY EMPLOYEE_NAME ASC", database);
                dataSetEmployee = new DataSet();
                adapterE.Fill(dataSetEmployee, "listE");
                database.Close();
            }
            for (int i = 0; i < dataSetEmployee.Tables[0].Rows.Count; i++)
            {
                /* arr
                 * 0 - employee id
                 * 1 - employee type
                 * 2 - name
                 * 3 - surname
                 */
                string[] arr = new string[] { dataSetEmployee.Tables[0].Rows[i].ItemArray.GetValue(0).ToString(),
                                              dataSetEmployee.Tables[0].Rows[i].ItemArray.GetValue(1).ToString(),
                                              dataSetEmployee.Tables[0].Rows[i].ItemArray.GetValue(2).ToString(),
                                              dataSetEmployee.Tables[0].Rows[i].ItemArray.GetValue(3).ToString() };
                list.Add(arr);
            }
            dataSetEmployee.Dispose();
            return list;
        }

        public List<string[]> loadContactDetails()
        {
            DataSet dataSetLogin;
            List<string[]> list = new List<string[]>();
            using (OleDbConnection database = new OleDbConnection(Properties.Settings.Default.DatabaseConnectionString))
            {
                database.Open();
                OleDbDataAdapter adapterL = new OleDbDataAdapter("SELECT * FROM CONTACT_DETAILS", database);
                dataSetLogin = new DataSet();
                adapterL.Fill(dataSetLogin, "listC");
                database.Close();
            }
            for (int i = 0; i < dataSetLogin.Tables[0].Rows.Count; i++)
            {
                /* arr
                 * 0 - house number
                 * 1 - street name
                 * 2 - postal code
                   3 - cell number
                   4 - cell number 2
                   5 - suburb
                   6 - city
                   7 - email
                   8 - employee id
                 */
                string[] arr = new string[] { dataSetLogin.Tables[0].Rows[i].ItemArray.GetValue(1).ToString(),
                                              dataSetLogin.Tables[0].Rows[i].ItemArray.GetValue(2).ToString(),
                                              dataSetLogin.Tables[0].Rows[i].ItemArray.GetValue(3).ToString(),
                                              dataSetLogin.Tables[0].Rows[i].ItemArray.GetValue(4).ToString(),
                                              dataSetLogin.Tables[0].Rows[i].ItemArray.GetValue(5).ToString(),
                                              dataSetLogin.Tables[0].Rows[i].ItemArray.GetValue(6).ToString(),
                                              dataSetLogin.Tables[0].Rows[i].ItemArray.GetValue(7).ToString(),
                                              dataSetLogin.Tables[0].Rows[i].ItemArray.GetValue(8).ToString(),
                                              dataSetLogin.Tables[0].Rows[i].ItemArray.GetValue(9).ToString()};
                list.Add(arr);
            }
            dataSetLogin.Dispose();
            return list;
        }

        public List<string[]> loadType()
        {
            DataSet dataSetEmployee;
            List<string[]> list = new List<string[]>();
            using (OleDbConnection database = new OleDbConnection(Properties.Settings.Default.DatabaseConnectionString))
            {
                database.Open();
                OleDbDataAdapter adapterE = new OleDbDataAdapter("SELECT * FROM EMPLOYEE_TYPE ORDER BY EMPLOYEE_POSITION ASC", database);
                dataSetEmployee = new DataSet();
                adapterE.Fill(dataSetEmployee, "listE");
                database.Close();
            }
            for (int i = 0; i < dataSetEmployee.Tables[0].Rows.Count; i++)
            {
                /* arr
                 * 0 - type number
                 * 1 - description
                 */
                string[] arr = new string[] { dataSetEmployee.Tables[0].Rows[i].ItemArray.GetValue(0).ToString(),
                                              dataSetEmployee.Tables[0].Rows[i].ItemArray.GetValue(1).ToString() };
                list.Add(arr);
            }
            dataSetEmployee.Dispose();
            return list;
        }
    }
}
