using System;
using System.IO;
using System.Net.Mail;
using System.Threading;
using System.Windows.Forms;

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
            try
            {
                Thread thread = new Thread(new ThreadStart(runSendMailAttachment));
                thread.Start();

                this.emailTo = emailTo;
                this.body = body;
                this.subject = subject;
                this.attachmentPath = attachmentPath;
            }
            catch (Exception ex)
            {
                BE_LogSystem log = new BE_LogSystem(ex);
                log.saveError();
            }
        }

        public void sendMail(string[] emailTo, string body, string subject)
        {
            try
            {
                Thread thread = new Thread(new ThreadStart(runSendMailAttachment));
                thread.Start();

                this.emailTo = emailTo;
                this.body = body;
                this.subject = subject;
            }
            catch (Exception ex)
            {
                BE_LogSystem log = new BE_LogSystem(ex);
                log.saveError();
            }
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
                MessageBox.Show("Email sent: " + subject);

                //log email
                string path = Properties.Settings.Default.EmailSavePath;
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                path += String.Format("\\{0} {1} {2}.txt", DateTime.Now.Year, DateTime.Now.ToString("MMMM"), DateTime.Now.Day);
                using (StreamWriter writer = new StreamWriter(path, append: true))
                {
                    writer.WriteLine(DateTime.Now.ToString("h:mm:ss tt"));
                    writer.WriteLine("Subject :" + subject);
                    for (int i = 0; i < emailTo.Length; i++)
                    {
                        writer.WriteLine("Emailed To:" + emailTo[i]);
                    }
                    writer.WriteLine("Status: Successfully Sent");
                }
            }
            catch (Exception ex)
            {
                BE_LogSystem log = new BE_LogSystem(ex);
                log.saveError();
                string path = Properties.Settings.Default.EmailSavePath;
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                path += String.Format("\\{0} {1} {2}.txt", DateTime.Now.Year, DateTime.Now.ToString("MMMM"), DateTime.Now.Day);
                using (StreamWriter writer = new StreamWriter(path, append: true))
                {
                    writer.WriteLine(DateTime.Now.ToString("h:mm:ss tt"));
                    writer.WriteLine("Subject :" + subject);
                    for (int i = 0; i < emailTo.Length; i++)
                    {
                        writer.WriteLine("Emailed To:" + emailTo[i]);
                    }
                    writer.WriteLine("Status: Sending Failed");
                }
                MessageBox.Show("Unsuccesfully sent email: " + subject);
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
                MessageBox.Show("Email sent: " + subject);

                // log email
                string path = Properties.Settings.Default.EmailSavePath;
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                path += String.Format("\\{0} {1} {2}.txt", DateTime.Now.Year, DateTime.Now.ToString("MMMM"), DateTime.Now.Day);
                using (StreamWriter writer = new StreamWriter(path, append: true))
                {
                    writer.WriteLine(DateTime.Now.ToString("h:mm:ss tt"));
                    writer.WriteLine("Subject :" + subject);
                    for (int i = 0; i < emailTo.Length; i++)
                    {
                        writer.WriteLine("Emailed To:" + emailTo[i]);
                    }
                    writer.WriteLine("Status: Successfully Sent");
                }
            }
            catch (Exception ex)
            {
                BE_LogSystem log = new BE_LogSystem(ex);
                log.saveError();
                string path = Properties.Settings.Default.EmailSavePath;
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                path += String.Format("\\{0} {1} {2}.txt", DateTime.Now.Year, DateTime.Now.ToString("MMMM"), DateTime.Now.Day);
                using (StreamWriter writer = new StreamWriter(path, append: true))
                {
                    writer.WriteLine(DateTime.Now.ToString("h:mm:ss tt"));
                    writer.WriteLine("Subject :" + subject);
                    for (int i = 0; i < emailTo.Length; i++)
                    {
                        writer.WriteLine("Emailed To:" + emailTo[i]);
                    }
                    writer.WriteLine("Status: Sending Failed");
                }
                MessageBox.Show("Unsuccesfully sent email: " + subject);
                MessageBox.Show("Unsuccesfully sent email: " + subject);
            }
        }
    }
}
