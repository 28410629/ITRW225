using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITRW225_Information_System
{
    public partial class UI_CredentialsAuthorise : Form
    {
        private string[] userArr;
        Form mainForm;

        public UI_CredentialsAuthorise(string[] userArr, Form mainForm)
        {
            this.userArr = userArr;
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void UI_CredentialsAuthorise_Load(object sender, EventArgs e)
        {
            string message = "";
            for (int i = 0; i < userArr.Length; i++)
            {
                message += userArr[i] + "\n";
            }
            MessageBox.Show(message);
        }

        private void buttonAuthorise_Click(object sender, EventArgs e)
        {
            BE_DatabaseCommands command = new BE_DatabaseCommands();
            if (Convert.ToBoolean(userArr[5]) && textBoxEmail.Text == userArr[2] && command.hashPassword(textBoxPassword.Text) == userArr[3])
            {
                MessageBox.Show("It worked!");
            }
        }

        private void UI_CredentialsAuthorise_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((mainForm.MdiChildren.Length - 1) == 0)
            {
                UI_Dashboard dashboard = new UI_Dashboard();
                dashboard.MdiParent = mainForm;
                dashboard.Show();
            }
        }
    }
}
