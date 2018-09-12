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
    public partial class UI_EmployeeRemove : Form
    {
        private string[] userArr;
        private Form MainParent;
        public UI_EmployeeRemove(Form MainParent, string[] userArr)
        {
            this.MainParent = MainParent;
            this.userArr = userArr;
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            switch (MessageBox.Show(this, "Are you sure you want to remove" + "comboBox1.SelectedItem.ToString()" + "?", "Warning", MessageBoxButtons.YesNo))
            {
                case DialogResult.No:
                    break;
                case DialogResult.Yes:
                    UI_CredentialsAuthorise authorise = new UI_CredentialsAuthorise(userArr, MainParent);
                    authorise.MdiParent = MainParent;
                    authorise.Show();
                    break;
                default:
                    break;
            }
        }

        private void UI_EmployeeRemove_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((MainParent.MdiChildren.Length - 1) == 0)
            {
                UI_Dashboard dashboard = new UI_Dashboard();
                dashboard.MdiParent = MainParent;
                dashboard.Show();
            }
        }
    }
}
