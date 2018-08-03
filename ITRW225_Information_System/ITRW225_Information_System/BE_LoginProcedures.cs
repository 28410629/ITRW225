using System;
using System.Data;
using System.Data.OleDb;
using System.Net.Mail;
using System.Windows.Forms;

namespace ITRW225_Information_System
{
    public class BE_LoginProcedures
    {
        private Form loginWindow;
        private string email;
        private string password;

        public BE_LoginProcedures(Form loginWindow, string email, string password)
        {
            this.loginWindow = loginWindow;
            this.email = email;
            this.password = password;
        }

        public string loginProcedure()
        {
            if (String.IsNullOrWhiteSpace(email))
            {
                return "Please enter your email address.";
            }
            else
            {
                if (String.IsNullOrWhiteSpace(password))
                {
                    return "Please enter your password.";
                }
                else
                {
                    string rowCount;
                    string[] userArr;
                    BE_DatabaseCommands dbCommands = new BE_DatabaseCommands();
                    using (OleDbConnection database = new OleDbConnection(Properties.Settings.Default.DatabaseConnectionString))
                    {
                        database.Open();
                        OleDbDataAdapter adapter = new OleDbDataAdapter(String.Format("SELECT * FROM LOGIN WHERE [EMAIL] = '{0}' AND PASSWORD = '{1}'", email, dbCommands.hashPassword(password)), database);
                        DataSet dataSet = new DataSet();
                        adapter.Fill(dataSet, "list");
                        database.Close();
                        rowCount = Convert.ToString(dataSet.Tables[0].Rows.Count);
                        if (dataSet.Tables[0].Rows.Count == 1)
                        {
                            userArr = new string[] { rowCount, dataSet.Tables[0].Rows[0].ItemArray.GetValue(1).ToString(), dataSet.Tables[0].Rows[0].ItemArray.GetValue(2).ToString(), dataSet.Tables[0].Rows[0].ItemArray.GetValue(4).ToString(), dataSet.Tables[0].Rows[0].ItemArray.GetValue(5).ToString(), dataSet.Tables[0].Rows[0].ItemArray.GetValue(6).ToString(), dataSet.Tables[0].Rows[0].ItemArray.GetValue(7).ToString(), dataSet.Tables[0].Rows[0].ItemArray.GetValue(8).ToString(), dataSet.Tables[0].Rows[0].ItemArray.GetValue(9).ToString() };
                        }
                        else
                        {
                            userArr = new string[] { rowCount };
                        }
                    }
                    if (userArr[0] == "0")
                    {
                        return "User is not registered on the system.";
                    }
                    else if (userArr[0] == "1")
                    {
                        UI_MainWindow mdiWindow = new UI_MainWindow(loginWindow, userArr);
                        loginWindow.ShowInTaskbar = false;
                        loginWindow.Hide();
                        mdiWindow.Show();
                        return "Login Successful";
                    }
                    else
                    {
                        return "Contact IT administration! Database might be tempered with!";
                    }
                }
            }
        }

        public string resetPasswordProcedure()
        {
            if (String.IsNullOrWhiteSpace(email))
            {
                return "Please enter your email address.";
            }
            else
            {
                int userAmount;
                using (OleDbConnection database = new OleDbConnection(Properties.Settings.Default.DatabaseConnectionString))
                {
                    database.Open();
                    OleDbDataAdapter adapter = new OleDbDataAdapter(String.Format("SELECT * FROM LOGIN WHERE [EMAIL] = '{0}'", email), database);
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet, "list");
                    database.Close();
                    userAmount = dataSet.Tables[0].Rows.Count;
                }
                if (userAmount == 0)
                {
                    return "User is not registered on the system.";
                }
                else if (userAmount > 1)
                {
                    return "Contact IT administration! Database might be tempered with!";
                }
                else
                {
                    try
                    {
                        MailMessage mail = new MailMessage();
                        SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                        mail.From = new MailAddress("leafgreenitsolutions.mrsalad@gmail.com");
                        mail.To.Add(email);
                        mail.Subject = "Mr Salad - Reset Password for " + email;
                        BE_GeneratePassword pass = new BE_GeneratePassword();
                        string password = pass.generate();
                        mail.Body = "Your new password is: " + password;

                        SmtpServer.Port = 587;
                        SmtpServer.Credentials = new System.Net.NetworkCredential("leafgreenitsolutions.mrsalad@gmail.com", "Google18!");
                        SmtpServer.EnableSsl = true;
                        SmtpServer.Send(mail);

                        updatePassDB();

                        return "New password sent: " + email;
                    }
                    catch (Exception ex)
                    {
                        BE_LogSystem log = new BE_LogSystem(ex);
                        log.saveError();
                        return "Reset password was not sent: " + email;
                    }
                }
            }
        }

        private void updatePassDB()
        {
            BE_DatabaseCommands dbCommands = new BE_DatabaseCommands();
            using (OleDbConnection database = new OleDbConnection(Properties.Settings.Default.DatabaseConnectionString))
            {
                database.Open();
                OleDbDataAdapter adapter = new OleDbDataAdapter(@"SELECT * FROM LOGIN", database);
                OleDbCommand command = new OleDbCommand(String.Format("UPDATE LOGIN SET [PASSWORD] = '{0}' WHERE [EMAIL] = '{1}'", dbCommands.hashPassword(password), email), database);
                adapter.InsertCommand = command;
                adapter.InsertCommand.ExecuteNonQuery();
                database.Close();
            }
        }
    }
}
