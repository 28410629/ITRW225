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
                    foreach (var item in MdiChildren)
                    {
                        item.Close();
                    }
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

        private void UI_MainWindow_Load(object sender, EventArgs e)
        {
            /* Array for user access to system:
             4 - client maintenance
             5 - employee maintenance
             6 - points of sale
             7 - reports
             8 - user maintenance
             9 - settings
             */
            clientMaintenanceToolStripMenuItem.Enabled = Convert.ToBoolean(userArr[3]);
            employeeMaintenanceToolStripMenuItem.Enabled = Convert.ToBoolean(userArr[4]);
            pointsOfSaleToolStripMenuItem.Enabled = Convert.ToBoolean(userArr[5]);
            reportsToolStripMenuItem.Enabled = Convert.ToBoolean(userArr[6]);
            userAccessToolStripMenuItem.Enabled = Convert.ToBoolean(userArr[7]);
            preferencesToolStripMenuItem.Enabled = Convert.ToBoolean(userArr[8]);

            UI_Dashboard dashboard = new UI_Dashboard();
            dashboard.MdiParent = this;
            dashboard.Show();
        }

        private void addEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var item in MdiChildren)
            {
                if (item is UI_EmployeeAdd)
                {
                    item.Focus();
                    return;
                }
                if (item is UI_Dashboard)
                {
                    item.Close();
                }
            }
            UI_EmployeeAdd employee = new UI_EmployeeAdd(this);
            employee.MdiParent = this;
            employee.Show();
        }

        private void updateEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var item in MdiChildren)
            {
                if (item is UI_EmployeeUpdate)
                {
                    item.Focus();
                    return;
                }
                if (item is UI_Dashboard)
                {
                    item.Close();
                }
            }
            UI_EmployeeUpdate employee = new UI_EmployeeUpdate(this);
            employee.MdiParent = this;
            employee.Show();
        }

        private void addClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var item in MdiChildren)
            {
                if (item is UI_ClientAdd)
                {
                    item.Focus();
                    return;
                }
                if (item is UI_Dashboard)
                {
                    item.Close();
                }
            }
            UI_ClientAdd employee = new UI_ClientAdd(this);
            employee.MdiParent = this;
            employee.Show();
        }

        private void updateClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var item in MdiChildren)
            {
                if (item is UI_ClientUpdate)
                {
                    item.Focus();
                    return;
                }
                if (item is UI_Dashboard)
                {
                    item.Close();
                }
            }
            UI_ClientUpdate employee = new UI_ClientUpdate(this);
            employee.MdiParent = this;
            employee.Show();
        }

        private void cancelOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var item in MdiChildren)
            {
                if (item is UI_POSActiveOrder)
                {
                    item.Focus();
                    return;
                }
                if (item is UI_Dashboard)
                {
                    item.Close();
                }
            }
            UI_POSActiveOrder employee = new UI_POSActiveOrder(this, userArr);
            employee.MdiParent = this;
            employee.Show();
        }

        private void placeOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var item in MdiChildren)
            {
                if (item is UI_POSPlaceOrder)
                {
                    item.Focus();
                    return;
                }
                if (item is UI_Dashboard)
                {
                    item.Close();
                }
            }
            UI_POSPlaceOrder employee = new UI_POSPlaceOrder(this, userArr);
            employee.MdiParent = this;
            employee.Show();
        }

        private void salesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var item in MdiChildren)
            {
                if (item is UI_ReportSales)
                {
                    item.Focus();
                    return;
                }
                if (item is UI_Dashboard)
                {
                    item.Close();
                }
            }
            UI_ReportSales employee = new UI_ReportSales(this);
            employee.MdiParent = this;
            employee.Show();
        }

        private void userAccessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var item in MdiChildren)
            {
                if (item is UI_UserMaintenance)
                {
                    item.Focus();
                    return;
                }
                if (item is UI_Dashboard)
                {
                    item.Close();
                }
            }
            UI_UserMaintenance user = new UI_UserMaintenance(this);
            user.MdiParent = this;
            user.Show();
        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var item in MdiChildren)
            {
                if (item is UI_ReportSales)
                {
                    item.Focus();
                    return;
                }
                if (item is UI_Dashboard)
                {
                    item.Close();
                }
            }
            UI_ReportSales user = new UI_ReportSales(this);
            user.MdiParent = this;
            user.Show();
        }

        private void pastOrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var item in MdiChildren)
            {
                if (item is UI_POSViewPastOrder)
                {
                    item.Focus();
                    return;
                }
                if (item is UI_Dashboard)
                {
                    item.Close();
                }
            }
            UI_POSViewPastOrder employee = new UI_POSViewPastOrder(this);
            employee.MdiParent = this;
            employee.Show();
        }

        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var item in MdiChildren)
            {
                if (item is UI_Settings)
                {
                    item.Focus();
                    return;
                }
                if (item is UI_Dashboard)
                {
                    item.Close();
                }
            }
            UI_Settings employee = new UI_Settings(this);
            employee.MdiParent = this;
            employee.Show();
        }

        private void feedbackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var item in MdiChildren)
            {
                if (item is UI_Feedback)
                {
                    item.Focus();
                    return;
                }
                if (item is UI_Dashboard)
                {
                    item.Close();
                }
            }
            UI_Feedback employee = new UI_Feedback(this);
            employee.MdiParent = this;
            employee.Show();
        }
    }
}