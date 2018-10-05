using System;
using System.IO;
using System.Windows.Forms;

namespace ITRW225_Information_System
{
    public partial class UI_Settings : Form
    {
        Form mainForm;
        public UI_Settings(Form mainForm)
        {
            this.mainForm = mainForm;
            InitializeComponent();
        }


        private void UI_Settings_Load(object sender, EventArgs e)
        {
            textBoxInvoice.Text = Properties.Settings.Default.InvoiceSavePath;
            textBoxDatabase.Text = Properties.Settings.Default.DatabaseBackupPath;
            textBoxReports.Text = Properties.Settings.Default.ReportsSavePath;
            textBoxEmail.Text = Properties.Settings.Default.EmailSavePath;
        }

        private enum DirectoryType
        {
            EMAIL,
            REPORT,
            INVOICE
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            e.Cancel = false;
        }

        private void dialogBrowse(DirectoryType type)
        {
            try
            {
                using (var fbd = new FolderBrowserDialog())
                {
                    DialogResult result = fbd.ShowDialog();

                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    {
                        switch (type)
                        {
                            case DirectoryType.EMAIL:
                                textBoxEmail.Text = fbd.SelectedPath;
                                Properties.Settings.Default.EmailSavePath = fbd.SelectedPath;
                                break;
                            case DirectoryType.INVOICE:
                                textBoxInvoice.Text = fbd.SelectedPath;
                                Properties.Settings.Default.InvoiceSavePath = fbd.SelectedPath;
                                break;
                            case DirectoryType.REPORT:
                                textBoxReports.Text = fbd.SelectedPath;
                                Properties.Settings.Default.ReportsSavePath = fbd.SelectedPath;
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                BE_LogSystem log = new BE_LogSystem(ex);
                log.saveError();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dialogBrowse(DirectoryType.INVOICE);
        }

        private void UI_Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((mainForm.MdiChildren.Length - 1) == 0)
            {
                UI_Dashboard dashboard = new UI_Dashboard();
                dashboard.MdiParent = mainForm;
                dashboard.Show();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                using (var fbd = new FolderBrowserDialog())
                {
                    DialogResult result = fbd.ShowDialog();

                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    {
                        textBoxDatabase.Text = fbd.SelectedPath;
                        Properties.Settings.Default.DatabaseBackupPath = fbd.SelectedPath;
                    }
                }
            }
            catch (Exception ex)
            {
                BE_LogSystem log = new BE_LogSystem(ex);
                log.saveError();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dialogBrowse(DirectoryType.REPORT);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dialogBrowse(DirectoryType.EMAIL);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if(!Directory.Exists(Properties.Settings.Default.DatabaseBackupPath))
                {
                    Directory.CreateDirectory(Properties.Settings.Default.DatabaseBackupPath);
                }
                File.Copy(Application.StartupPath + "\\Database.mdb", Properties.Settings.Default.DatabaseBackupPath + "\\Database.mdb", true);
                MessageBox.Show("Successfully backed up database!");
            }
            catch (Exception ex)
            {
                BE_LogSystem log = new BE_LogSystem(ex);
                log.saveError();
                MessageBox.Show("Failed backing up database!");
            }
        }
    }
}
