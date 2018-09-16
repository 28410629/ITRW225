using System;
using System.Windows.Forms;

namespace ITRW225_Information_System
{
    public partial class UI_Login : Form
    {
        BE_LoginProcedures login;

        public UI_Login()
        {
            login = new BE_LoginProcedures(this);
            InitializeComponent();
        }

        private void labelForgot_Click(object sender, EventArgs e)
        {
            try
            {
                labelStatus.Text = "Busy resetting password, please wait.";
                labelStatus.Refresh();
                labelForgot.Enabled = false;
                labelStatus.Text = login.resetPasswordProcedure(textBoxUser.Text);
                labelForgot.Enabled = true;
            }
            catch (Exception ex)
            {
                BE_LogSystem log = new BE_LogSystem(ex);
                log.saveError();
            }
        }

        private void UI_Login_Load(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox1.Image = Properties.Resources.logo_465x320__1_;
            }
            catch (Exception ex)
            {
                BE_LogSystem log = new BE_LogSystem(ex);
                log.saveError();
            }
           
        }

        private void labelLogin_Click(object sender, EventArgs e)
        {
            try
            {
                textBoxUser.Focus();
                labelStatus.Text = "Logging in, please wait.";
                labelStatus.Refresh();
                labelLogin.Enabled = false;
                labelStatus.Text = login.loginProcedure(textBoxUser.Text, textBoxPassword.Text);
                labelLogin.Enabled = true;
                if (labelStatus.Text == "Login Successful")
                {
                    labelStatus.Text = "";
                    textBoxUser.Text = "";
                    textBoxPassword.Text = "";
                    labelStatus.Refresh();
                }
            }
            catch (Exception ex)
            {
                BE_LogSystem log = new BE_LogSystem(ex);
                log.saveError();
            }
        }

        private void UI_Login_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Return)
                {
                    labelLogin_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                BE_LogSystem log = new BE_LogSystem(ex);
                log.saveError();
            }
        }
    }
}
