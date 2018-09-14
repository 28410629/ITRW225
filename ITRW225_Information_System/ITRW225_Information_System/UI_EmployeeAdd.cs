using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace ITRW225_Information_System
{
    public partial class UI_EmployeeAdd : Form
    {
        private List<string[]> idDetails;
        Form mainForm;
        public UI_EmployeeAdd(Form mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
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

        private void ValidateNumber(TextBox textBox, CancelEventArgs e, ErrorProvider error, string type)
        {
            int length = 0;
            string msg = "";
            switch (type)
            {
                case "ID":
                    length = 13;
                    msg = "Must be 13 digit ID.";
                    break;
                case "Cell":
                    length = 10;
                    msg = "Must be 10 digit cellphone number.";
                    break;
                case "Postal":
                    length = 4;
                    msg = "Must be 4 digit postal code.";
                    break;
                default:
                    break;
            }
            if (String.IsNullOrWhiteSpace(textBox.Text))
            {
                e.Cancel = true;
                error.SetError(textBox, "Required field.");
            }
            else
            {
                bool result = long.TryParse(textBox.Text, out long resultL);
                if (result)
                {
                    if (textBox.Text.Length != length)
                    {
                        e.Cancel = true;
                        error.SetError(textBox, msg);
                    }
                    else
                    {
                        if (type == "ID")
                        {
                            if (checkID(textBox.Text))
                            {
                                e.Cancel = true;
                                error.SetError(textBox, "ID already exists!");
                            }
                            else
                            {
                                e.Cancel = false;
                                error.SetError(textBox, null);
                            }
                        }
                        else
                        {
                            e.Cancel = false;
                            error.SetError(textBox, null);
                        }
                    }
                }
                else
                {
                    e.Cancel = true;
                    error.SetError(textBox, "Must be a number!");
                }
            }
        }

        private bool checkID(string id)
        {
            bool exists = false;
            for (int i = 0; i < idDetails.Count; i++)
            {
                if (idDetails[i][0] == id)
                {
                    exists = true;
                }
            }
            return exists;
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
                try
                {
                    switch (comboBoxCN.SelectedItem.ToString())
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
                            BE_DatabaseCommands commands = new BE_DatabaseCommands();
                            string query = String.Format("");
                            commands.addDB(query, "CONTACT_DETAILS");
                            MessageBox.Show("Successfully updated database!");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    BE_LogSystem log = new BE_LogSystem(ex);
                    log.saveError();
                    MessageBox.Show("Failed updating database!");
                }
            }
        }

        private void UI_EmployeeAdd_Load(object sender, EventArgs e)
        {
            buttonClose.Focus();
            BE_DatabaseCommands commands = new BE_DatabaseCommands();
            idDetails = commands.retrieveCustomDB("SELECT * FROM PERSON, CONTACT_DETAILS WHERE PERSON.Person_ID = CONTACT_DETAILS.Person_ID");
        }

        private void UI_EmployeeAdd_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((mainForm.MdiChildren.Length - 1) == 0)
            {
                UI_Dashboard dashboard = new UI_Dashboard();
                dashboard.MdiParent = mainForm;
                dashboard.Show();
            }
        }
    }
}
