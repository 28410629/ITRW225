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
        private string[] userArr;

        public UI_MainWindow(Form loginWindow, string[] userArr)
        {
            this.loginWindow = loginWindow;
            this.userArr = userArr;
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
            this.Close();
        }

        private void userMaintenanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI_UserMaintenance user = new UI_UserMaintenance();
            user.MdiParent = this;
            user.Show();
        }

        private void UI_MainWindow_Load(object sender, EventArgs e)
        {
            /* Array for user access to system:
             3 - client maintenance
             4 - employee maintenance
             5 - points of sale
             6 - reports
             7 - user maintenance
             8 - settings
             */
            clientMaintenanceToolStripMenuItem.Enabled = Convert.ToBoolean(userArr[3]);
            employeeMaintenanceToolStripMenuItem.Enabled = Convert.ToBoolean(userArr[4]);
            pointsOfSaleToolStripMenuItem.Enabled = Convert.ToBoolean(userArr[5]);
            reportsToolStripMenuItem.Enabled = Convert.ToBoolean(userArr[6]);
            userMaintenanceToolStripMenuItem.Enabled = Convert.ToBoolean(userArr[7]);
            preferencesToolStripMenuItem.Enabled = Convert.ToBoolean(userArr[8]);
        }

        private void addEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI_AddNewEmployee employee = new UI_AddNewEmployee();
            employee.MdiParent = this;
            employee.Show();
        }
    }
}