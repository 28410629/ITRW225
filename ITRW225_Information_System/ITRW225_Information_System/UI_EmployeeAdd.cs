using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace ITRW225_Information_System
{
    public partial class UI_EmployeeAdd : Form
    {
        public UI_EmployeeAdd()
        {
            InitializeComponent();
        }

        private void ValidateComponent(TextBox textBox, CancelEventArgs e, ErrorProvider error)
        {
            if (String.IsNullOrWhiteSpace(textBox.Text))
            {
                e.Cancel = true;
                error.SetError(textBox, "Required field.");
            }
            else
            {
                e.Cancel = false;
                error.SetError(textBox, null);
            }
        }

        private void textBoxFN_Validating_1(object sender, CancelEventArgs e)
        {
            ValidateComponent((TextBox)sender, e, errorProviderFN);
        }

        private void textBoxLN_Validating_1(object sender, CancelEventArgs e)
        {
            ValidateComponent((TextBox)sender, e, errorProviderLN);
        }

        private void textBoxCN_Validating_1(object sender, CancelEventArgs e)
        {
            ValidateComponent((TextBox)sender, e, errorProviderCN);
        }

        private void textBoxID_Validating_1(object sender, CancelEventArgs e)
        {
            ValidateComponent((TextBox)sender, e, errorProviderID);
        }

        private void textBoxVAT_Validating_1(object sender, CancelEventArgs e)
        {
            ValidateComponent((TextBox)sender, e, errorProviderVAT);
        }

        private void textBoxEA_Validating_1(object sender, CancelEventArgs e)
        {
            ValidateComponent((TextBox)sender, e, errorProviderEA);
        }

        private void textBoxHN_Validating_1(object sender, CancelEventArgs e)
        {
            ValidateComponent((TextBox)sender, e, errorProviderHN);
        }

        private void textBoxSN_Validating_1(object sender, CancelEventArgs e)
        {
            ValidateComponent((TextBox)sender, e, errorProviderSN);
        }

        private void textBoxS_Validating_1(object sender, CancelEventArgs e)
        {
            ValidateComponent((TextBox)sender, e, errorProviderS);
        }

        private void textBoxPC_Validating_1(object sender, CancelEventArgs e)
        {
            ValidateComponent((TextBox)sender, e, errorProviderPC);
        }

        private void buttonSave_Click_1(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                switch(comboBoxCN.SelectedItem.ToString())
                {
                    case "Eastern Cape":
                        MessageBox.Show("Inappropriate location selection.");
                        break;
                    case "Free State":
                        MessageBox.Show("Inappropriate location selection.");
                        break;
                    case "Gauteng":
                        MessageBox.Show("Inappropriate location selection.");
                        break;
                    case "KwaZulu-Natal":
                        MessageBox.Show("Inappropriate location selection.");
                        break;
                    case "Limpopo":
                        MessageBox.Show("Inappropriate location selection.");
                        break;
                    case "Mpumalanga":
                        MessageBox.Show("Inappropriate location selection.");
                        break;
                    case "North West":
                        MessageBox.Show("Inappropriate location selection.");
                        break;
                    case "Northern Cape":
                        MessageBox.Show("Inappropriate location selection.");
                        break;
                    case "Western Cape":
                        MessageBox.Show("Inappropriate location selection.");
                        break;
                    case "":
                        MessageBox.Show("Inappropriate location selection.");
                        break;
                    case "Please select location.":
                        MessageBox.Show("Please select appropriate location.");
                        break;
                    default:
                        BE_EmployeeMaintenance employee = new BE_EmployeeMaintenance();
                        string[] arr = new string[] { textBoxFN.Text, textBoxHN.Text, textBoxCN.Text, textBoxEA.Text,
                                                      textBoxID.Text, textBoxLN.Text, textBoxPC.Text, textBoxS.Text,
                                                      textBoxSN.Text, textBoxVAT.Text, comboBoxCN.SelectedItem.ToString() };
                        string message = employee.saveDB(arr, true);
                        MessageBox.Show(message);
                        break;
                }
            }
        }

        private void UI_EmployeeAdd_Load(object sender, EventArgs e)
        {
            buttonClose.Focus();
        }
    }
}
