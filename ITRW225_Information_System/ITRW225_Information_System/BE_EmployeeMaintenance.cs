using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

namespace ITRW225_Information_System
{
    public class BE_EmployeeMaintenance
    {

        public string updateDB(string[] arr)
        {
            try
            {
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

        public List<string[]> loadType()
        {
            try
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
            catch (Exception ex)
            {
                BE_LogSystem log = new BE_LogSystem(ex);
                log.saveError();
                return null;
            }
        }
    }
}
