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
    public partial class UI_AddNewEmployee : Form
    {
        public UI_AddNewEmployee()
        {
            InitializeComponent();
        }

        private void ValidateComponent(CancelEventArgs e, TextBox textBox)
        {
            if (String.IsNullOrWhiteSpace(textBoxFN.Text))
            {
                e.Cancel = true;
                textBox.Focus();
                errorProviderALL.SetError(textBox, "Required field.");
            }
            else
            {
                e.Cancel = false;
                errorProviderALL.SetError(textBox, null);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                MessageBox.Show("It worked!");
            }
        }

        private void textBoxFN_Validating(object sender, CancelEventArgs e)
        {
            ValidateComponent(e, (TextBox)sender);
            /*if (String.IsNullOrWhiteSpace(textBoxFN.Text))
            {
                e.Cancel = true;
                textBoxFN.Focus();
                errorProviderALL.SetError(textBoxFN, "Required field.");
            }
            else
            {
                e.Cancel = false;
                errorProviderALL.SetError(textBoxFN, null);
            }*/
        }
    }
}
