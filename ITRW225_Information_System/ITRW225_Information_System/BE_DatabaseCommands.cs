using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.OleDb;
using System.Text;
using System.Threading.Tasks;
using System.Data;

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

        public string[] checkLogin(string user, string pass)
        {
            try
            {
                using (OleDbConnection database = new OleDbConnection(Properties.Settings.Default.DatabaseConnectionString))
                {
                    database.Open();
                    OleDbDataAdapter adapter = new OleDbDataAdapter(String.Format("SELECT * FROM LOGIN WHERE EMAIL = '{0}' AND PASSWORD = '{1}'", user, hashPassword(pass)), database);
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet, "list");
                    database.Close();
                    if (dataSet.Tables[0].Rows.Count == 1)
                    {
                        //string some
                        string[] arr = new string[] { "1" };
                        return arr;
                    }
                    else
                    {
                        string[] arr = new string[] { "0" };
                        return arr;
                    }
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int checkEmail(string email)
        {
            try
            {
                using (OleDbConnection database = new OleDbConnection(Properties.Settings.Default.DatabaseConnectionString))
                {
                    database.Open();
                    OleDbDataAdapter adapter = new OleDbDataAdapter(String.Format("SELECT * FROM LOGIN WHERE [EMAIL] = '{0}'", email), database);
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet, "list");
                    database.Close();
                    return dataSet.Tables[0].Rows.Count;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
