﻿using System;
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
    public partial class UI_Login : Form
    {
        public UI_Login()
        {
            InitializeComponent();
        }

        private void labelForgot_Click(object sender, EventArgs e)
        {
            labelStatus.Text = "";
            labelForgot.Enabled = false;
            BE_LoginProcedures login = new BE_LoginProcedures(this);
            labelStatus.Text = login.resetPasswordProcedure(textBoxUser.Text);
            labelForgot.Enabled = true;
        }

        private void UI_Login_Load(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.Image = Properties.Resources.logo_465x320__1_;
        }

        private void labelLogin_Click(object sender, EventArgs e)
        {
            labelStatus.Text = "Logging in, please wait.";
            labelLogin.Enabled = false;
            BE_LoginProcedures login = new BE_LoginProcedures(this);
            labelStatus.Text = login.loginProcedure(textBoxUser.Text,textBoxPassword.Text);
            labelLogin.Enabled = true;
        }

        private void UI_Login_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                labelLogin_Click(sender, e);
            }
        }
    }
}
