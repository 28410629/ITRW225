using System;
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
                    BE_DatabaseCommands dbCommands = new BE_DatabaseCommands();
                    string[] userAmount = dbCommands.checkLogin(email, password);
                    if (userAmount[0] == "0")
                    {
                        return "User is not registered on the system.";
                    }
                    else if (userAmount[0] == "1")
                    {
                        UI_MainWindow mdiWindow = new UI_MainWindow(loginWindow, userAmount);
                        loginWindow.ShowInTaskbar = false;
                        loginWindow.Hide();
                        mdiWindow.Show();
                        return "Successful";
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
                BE_DatabaseCommands dbCommands = new BE_DatabaseCommands();
                int userAmount = dbCommands.checkEmail(email);
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
                    BE_Email mail = new BE_Email();
                    return mail.SendResetPassword(email);
                }
            }
        }
    }
}
