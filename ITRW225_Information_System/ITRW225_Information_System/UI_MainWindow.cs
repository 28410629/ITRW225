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
            }
            UI_EmployeeAdd employee = new UI_EmployeeAdd();
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
            }
            UI_EmployeeUpdate employee = new UI_EmployeeUpdate();
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
            }
            UI_ClientAdd employee = new UI_ClientAdd();
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
            }
            UI_ClientUpdate employee = new UI_ClientUpdate();
            employee.MdiParent = this;
            employee.Show();
        }

        private void removeEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var item in MdiChildren)
            {
                if (item is UI_EmployeeRemove)
                {
                    item.Focus();
                    return;
                }
            }
            UI_EmployeeRemove employee = new UI_EmployeeRemove(this, userArr);
            employee.MdiParent = this;
            employee.Show();
        }

        private void cancelOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var item in MdiChildren)
            {
                if (item is UI_POSCancelOrder)
                {
                    item.Focus();
                    return;
                }
            }
            UI_POSCancelOrder employee = new UI_POSCancelOrder();
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
            }
            UI_POSPlaceOrder employee = new UI_POSPlaceOrder();
            employee.MdiParent = this;
            employee.Show();
        }

        private void viewOrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var item in MdiChildren)
            {
                if (item is UI_POSViewOrder)
                {
                    item.Focus();
                    return;
                }
            }
            UI_POSViewOrder employee = new UI_POSViewOrder();
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
            }
            UI_ReportSales employee = new UI_ReportSales();
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
            }
            UI_UserMaintenance user = new UI_UserMaintenance();
            user.MdiParent = this;
            user.Show();
        }
    }
}