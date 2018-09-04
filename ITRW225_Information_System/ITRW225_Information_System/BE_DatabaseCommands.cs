using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Text;

namespace ITRW225_Information_System
{
    public class BE_DatabaseCommands
    {
        public string hashPassword(string password)
        {
            var bytes = new UTF8Encoding().GetBytes(password);
            var hashBytes = System.Security.Cryptography.MD5.Create().ComputeHash(bytes);
            return Convert.ToBase64String(hashBytes);
        }

        public string updateDB(string query, string tableName)
        {
            return executeNonQuery(query, tableName);
        }

        public string addDB(string query, string tableName)
        {
            return executeNonQuery(query, tableName);
        }

        public List<string[]> retrieveCustomDB(string query)
        {
            try
            {
                DataSet data;
                List<string[]> list = new List<string[]>();
                using (OleDbConnection database = new OleDbConnection(Properties.Settings.Default.DatabaseConnectionString))
                {
                    database.Open();
                    OleDbDataAdapter adapterE = new OleDbDataAdapter(query, database);
                    data = new DataSet();
                    adapterE.Fill(data, "list");
                    database.Close();
                }
                for (int i = 0; i < data.Tables[0].Rows.Count; i++)
                {
                    string[] arr = new string[data.Tables[0].Columns.Count];
                    for (int j = 0; j < data.Tables[0].Columns.Count; j++)
                    {
                        arr[j] = data.Tables[0].Rows[i].ItemArray.GetValue(j).ToString();
                    }
                    list.Add(arr);
                }
                data.Dispose();
                return list;
            }
            catch (Exception ex)
            {
                BE_LogSystem log = new BE_LogSystem(ex);
                log.saveError();
                return null;
            }
        }

        public List<string[]> retrieveDB(string tableName)
        {
            try
            {
                DataSet data;
                List<string[]> list = new List<string[]>();
                using (OleDbConnection database = new OleDbConnection(Properties.Settings.Default.DatabaseConnectionString))
                {
                    database.Open();
                    OleDbDataAdapter adapterE = new OleDbDataAdapter("SELECT * FROM [" + tableName + "]", database);
                    data = new DataSet();
                    adapterE.Fill(data, "list");
                    database.Close();
                }
                for (int i = 0; i < data.Tables[0].Rows.Count; i++)
                {
                    string[] arr = new string[data.Tables[0].Columns.Count];
                    for (int j = 0; j < data.Tables[0].Columns.Count; j++)
                    {
                        arr[j] = data.Tables[0].Rows[i].ItemArray.GetValue(j).ToString();
                    }
                    list.Add(arr);
                }
                data.Dispose();
                return list;
            }
            catch (Exception ex)
            {
                BE_LogSystem log = new BE_LogSystem(ex);
                log.saveError();
                return null;
            }
        }

        private string executeNonQuery(string query, string table)
        {
            try
            {
                using (OleDbConnection db = new OleDbConnection(Properties.Settings.Default.DatabaseConnectionString))
                {
                    db.Open();
                    OleDbDataAdapter adpt = new OleDbDataAdapter("SELECT * FROM " + table, db);
                    OleDbCommand cmd = new OleDbCommand(query, db);
                    adpt.InsertCommand = cmd;
                    adpt.InsertCommand.ExecuteNonQuery();
                    db.Close();
                }
                return "Successfully updated database!";
            }
            catch (Exception ex)
            {
                BE_LogSystem log = new BE_LogSystem(ex);
                log.saveError();
                return "Failed updating database!";
            }
        }

    }
}
