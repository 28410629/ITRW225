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

        public BE_LoginProcedures(Form loginWindow)
        {
            this.loginWindow = loginWindow;
        }

        public string loginProcedure(string email, string password)
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
                    bool access = false;
                    BE_DatabaseCommands dbCommands = new BE_DatabaseCommands();
                    using (OleDbConnection database = new OleDbConnection(Properties.Settings.Default.DatabaseConnectionString))
                    {
                        database.Open();
                        OleDbDataAdapter adapter = new OleDbDataAdapter(String.Format("SELECT * FROM LOGIN, CONTACT_DETAILS WHERE LOGIN.Person_ID = CONTACT_DETAILS.Person_ID AND CONTACT_DETAILS.Email_Address = '{0}' AND LOGIN.Password = '{1}'", email, dbCommands.hashPassword(password)), database);
                        DataSet dataSet = new DataSet();
                        adapter.Fill(dataSet, "list");
                        database.Close();
                        rowCount = Convert.ToString(dataSet.Tables[0].Rows.Count);
                        if (dataSet.Tables[0].Rows.Count == 1)
                        {
                            userArr = new string[10];
                            userArr[0] = rowCount;
                            userArr[1] = dataSet.Tables[0].Rows[0].ItemArray.GetValue(16).ToString();
                            for (int j = 2; j < 10; j++)
                            {
                                userArr[j] = dataSet.Tables[0].Rows[0].ItemArray.GetValue(j-1).ToString();
                            }
                            access = Convert.ToBoolean(userArr[9]);
                        }
                        else
                        {
                            userArr = new string[] { rowCount };
                        }
                    }
                    if (userArr[0] == "0")
                    {
                        return "Email or password incorrect, are you registered on the system?";
                    }
                    else if (userArr[0] == "1")
                    {
                        if (access)
                        {
                            loginWindow.ShowInTaskbar = false;
                            loginWindow.Hide();
                            UI_MainWindow mdiWindow = new UI_MainWindow(loginWindow, userArr);
                            mdiWindow.Show();
                            return "Login Successful";
                        }
                        else
                        {
                            return "Access to system is blocked by administrator!";
                        }
                    }
                    else
                    {
                        return "Contact IT administration! Database might be tempered with!";
                    }
                }
            }
        }

        public string resetPasswordProcedure(string email)
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
                    OleDbDataAdapter adapter = new OleDbDataAdapter(String.Format("SELECT * FROM CONTACT_DETAILS WHERE [Email_Address] = '{0}'", email), database);
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

                        updatePassDB(email, password);

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

        private void updatePassDB(string email, string password)
        {
            BE_DatabaseCommands dbCommands = new BE_DatabaseCommands();
            using (OleDbConnection database = new OleDbConnection(Properties.Settings.Default.DatabaseConnectionString))
            {
                database.Open();
                OleDbDataAdapter adapter = new OleDbDataAdapter(@"SELECT * FROM LOGIN", database);
                OleDbCommand command = new OleDbCommand(String.Format("UPDATE LOGIN INNER JOIN CONTACT_DETAILS ON LOGIN.Person_ID = CONTACT_DETAILS.Person_ID SET LOGIN.Password = 'hello' WHERE CONTACT_DETAILS.Email_Address = 'coen.human@gmail.com'"), database);
                //UPDATE LOGIN SET [PASSWORD] = '{0}' WHERE [EMAIL] = '{1}'", dbCommands.hashPassword(password), email)
                adapter.InsertCommand = command;
                adapter.InsertCommand.ExecuteNonQuery();
                database.Close();
            }
        }
    }
}
