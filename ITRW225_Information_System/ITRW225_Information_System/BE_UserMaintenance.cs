using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITRW225_Information_System
{
    class BE_UserMaintenance
    {
        public void loadInformation()
        {
            using (OleDbConnection database = new OleDbConnection(Properties.Settings.Default.DatabaseConnectionString))
            {
                database.Open();
                OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM ", database);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "list");
                database.Close();
                //dataSet.Tables[0].Rows.Count;
            }
        }
    }
}
