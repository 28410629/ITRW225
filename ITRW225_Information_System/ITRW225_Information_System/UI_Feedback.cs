using System;
using System.Net.Mail;
using System.Windows.Forms;

namespace ITRW225_Information_System
{
    public partial class UI_Feedback : Form
    {
        private Form mainForm;
        public UI_Feedback(Form mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void UI_Feedback_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((mainForm.MdiChildren.Length - 1) == 0)
            {
                UI_Dashboard dashboard = new UI_Dashboard();
                dashboard.MdiParent = mainForm;
                dashboard.Show();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            e.Cancel = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                button1.Enabled = false;
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("leafgreenitsolutions.mrsalad@gmail.com");
                // developers:
                mail.To.Add("coen.human@gmail.com");
                mail.To.Add("savannahtfritze@gmail.com");
                mail.To.Add("pbrand61@gmail.com");
                mail.To.Add("heino1369@gmail.com");

                mail.Subject = "Mr Salad - Feedback:  " + DateTime.Today.ToLongDateString() + " - " + textBoxSubject.Text;

                mail.Body = textBoxPersonEmail.Text + "\n\n" + textBoxBody.Text;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("leafgreenitsolutions.mrsalad@gmail.com", "Google18!");
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
                MessageBox.Show("Email was sent!");
                button1.Enabled = true;
            }
            catch (Exception ex)
            {
                BE_LogSystem log = new BE_LogSystem(ex);
                log.saveError();
                button1.Enabled = true;
                MessageBox.Show("Email was NOT sent!");
            }
        }
    }
}
