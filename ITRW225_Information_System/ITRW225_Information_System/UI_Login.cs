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
            labelStatus.Enabled = false;
            BE_Email mail = new BE_Email();
            labelStatus.Text = mail.SendResetPassword(textBoxUser.Text);
            labelStatus.Enabled = true;
        }

        private void UI_Login_Load(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.Image = Properties.Resources.logo_465x320__1_;
        }
    }
}
