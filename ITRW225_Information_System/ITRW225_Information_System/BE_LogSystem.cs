using System;
using System.IO;
using System.Net.Mail;
using System.Threading;

namespace ITRW225_Information_System
{
    public class BE_LogSystem
    {
        private string source;
        private string message;
        private string stackTrace;
        private string attachmentPath;

        public BE_LogSystem(Exception ex)
        {
            message = ex.Message;
            source = ex.Source;
            stackTrace = ex.StackTrace;
        }

        public void saveError()
        {
            Thread thread = new Thread(new ThreadStart(runSaveError));
            thread.Start();
        }

        private void runSaveError()
        {
            try
            {
                string path = Directory.GetCurrentDirectory() + "\\Logs";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                path += String.Format("\\{0} {1} {2}.txt", DateTime.Now.Year, DateTime.Now.ToString("MMMM"), DateTime.Now.Day);
                attachmentPath = path;
                using (StreamWriter writer = new StreamWriter(path, append: true))
                {
                    writer.WriteLine(DateTime.Now.ToString("h:mm:ss tt") + " " + source);
                    writer.WriteLine();
                    writer.WriteLine(message);
                    writer.WriteLine();
                    writer.WriteLine(stackTrace);
                    writer.WriteLine();
                    writer.WriteLine("-------------------------------------------FIN-------------------------------------------");
                    writer.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Log Error: " + ex.Message);
            }
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("leafgreenitsolutions.mrsalad@gmail.com");
                // developers:
                mail.To.Add("coen.human@gmail.com");
                mail.To.Add("savannahtfritze@gmail.com");
                mail.To.Add("pbrand61@gmail.com");
                mail.To.Add("heino1369@gmail.com");
                mail.Subject = "Mr Salad - System Error Log:  " + DateTime.Today.ToLongDateString();

                mail.Body = "See attached text file.";

                Attachment attachment = new Attachment(attachmentPath);
                mail.Attachments.Add(attachment);

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("leafgreenitsolutions.mrsalad@gmail.com", "Google18!");
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Log Mail Error: " + ex.Message);
            }
        }
    }
}
