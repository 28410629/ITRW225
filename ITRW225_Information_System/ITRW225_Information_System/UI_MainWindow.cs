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
    public partial class UI_MainWindow : Form
    {
        private Form loginWindow;

        public UI_MainWindow(Form loginWindow)
        {
            this.loginWindow = loginWindow;
            InitializeComponent();
        }

        private void UI_MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            switch (MessageBox.Show(this, "Are you sure you want to logout?", "Logging Out", MessageBoxButtons.YesNo))
            {
                case DialogResult.No:
                    e.Cancel = true;
                    break;
                case DialogResult.Yes:
                    loginWindow.ShowInTaskbar = true;
                    loginWindow.Show();
                    break;
                default:
                    break;
            }
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (MessageBox.Show(this, "Are you sure you want to logout?", "Logging Out", MessageBoxButtons.YesNo))
            {
                case DialogResult.No:
                    break;
                case DialogResult.Yes:
                    loginWindow.ShowInTaskbar = true;
                    loginWindow.Show();
                    this.Close();
                    break;
                default:
                    break;
            }
            
        }
    }
}