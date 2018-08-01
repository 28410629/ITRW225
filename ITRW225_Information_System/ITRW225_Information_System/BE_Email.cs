using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace ITRW225_Information_System
{
    public class BE_Email
    {
        public string SendResetPassword(string email)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("leafgreenitsolutions.mrsalad@gmail.com");
                mail.To.Add(email);
                mail.Subject = "Mr Salad - Reset Password for " + email;
                BE_GeneratePassword pass = new BE_GeneratePassword();
                mail.Body = "Your new password is: " + pass.generate();

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("leafgreenitsolutions.mrsalad@gmail.com", "Google18!");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                BE_DatabaseCommands dbCommand = new BE_DatabaseCommands();
                // save new password to database
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
