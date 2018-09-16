using System;
using System.Net.Mail;
using System.Threading;

namespace ITRW225_Information_System
{
    public class BE_SendEmail
    {
        private string[] emailTo;
        private string body;
        private string subject;
        string attachmentPath;

        public void sendMailAttachment(string[] emailTo, string body, string subject, string attachmentPath)
        {
            Thread thread = new Thread(new ThreadStart(runSendMailAttachment));
            thread.Start();

            this.emailTo = emailTo;
            this.body = body;
            this.subject = subject;
            this.attachmentPath = attachmentPath;
        }

        public void sendMail(string[] emailTo, string body, string subject)
        {
            Thread thread = new Thread(new ThreadStart(runSendMailAttachment));
            thread.Start();

            this.emailTo = emailTo;
            this.body = body;
            this.subject = subject;
        }

        private void runSendMailAttachment()
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("leafgreenitsolutions.mrsalad@gmail.com");

                // email to
                for (int i = 0; i < emailTo.Length; i++)
                {
                    mail.To.Add(emailTo[i]);
                }

                mail.Subject = "Mr Salad - " + DateTime.Today.ToLongDateString() + " - " + subject;

                mail.Body = body;

                Attachment attachment = new Attachment(attachmentPath);
                mail.Attachments.Add(attachment);

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("leafgreenitsolutions.mrsalad@gmail.com", "Google18!");
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                BE_LogSystem log = new BE_LogSystem(ex);
                log.saveError();
            }
        }

        private void runSendMail()
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("leafgreenitsolutions.mrsalad@gmail.com");

                // email to
                for (int i = 0; i < emailTo.Length; i++)
                {
                    mail.To.Add(emailTo[i]);
                }

                mail.Subject = "Mr Salad - " + DateTime.Today.ToLongDateString() + " - " + subject;

                mail.Body = body;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("leafgreenitsolutions.mrsalad@gmail.com", "Google18!");
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                BE_LogSystem log = new BE_LogSystem(ex);
                log.saveError();
            }
        }
    }
}
