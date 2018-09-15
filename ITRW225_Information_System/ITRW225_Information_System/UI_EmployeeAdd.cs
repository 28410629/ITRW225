using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;
using System.Windows.Forms;

namespace ITRW225_Information_System
{
    public partial class UI_EmployeeAdd : Form
    {
        private List<string[]> employeeType;
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
                if (textBox.Text.Contains("'") || textBox.Text.Contains("\"") || textBox.Text.Contains("||") || textBox.Text.Contains("-") || textBox.Text.Contains("*") || textBox.Text.Contains("/") || textBox.Text.Contains("<>") || textBox.Text.Contains("<") || textBox.Text.Contains(">") || textBox.Text.Contains(",") || textBox.Text.Contains("=") || textBox.Text.Contains("<=") || textBox.Text.Contains(">=") || textBox.Text.Contains("~=") || textBox.Text.Contains("!=") || textBox.Text.Contains("^=") || textBox.Text.Contains("(") || textBox.Text.Contains(")"))
                {
                    e.Cancel = true;
                    error.SetError(textBox, "Invalid Character!");
                }
                else
                {
                    e.Cancel = false;
                    error.SetError(textBox, null);
                }
            }
        }

        private void ValidateEmail(TextBox textBox, CancelEventArgs e, ErrorProvider error)
        {
            if (String.IsNullOrWhiteSpace(textBox.Text))
            {
                e.Cancel = true;
                error.SetError(textBox, "Required field.");
            }
            else
            {
                if (checkEmail(textBox.Text))
                {
                    e.Cancel = true;
                    error.SetError(textBox, "Email already exists!");
                }
                else
                {
                    if (textBox.Text.Contains("'") || textBox.Text.Contains("\"") || textBox.Text.Contains("||") || textBox.Text.Contains("-") || textBox.Text.Contains("*") || textBox.Text.Contains("/") || textBox.Text.Contains("<>") || textBox.Text.Contains("<") || textBox.Text.Contains(">") || textBox.Text.Contains(",") || textBox.Text.Contains("=") || textBox.Text.Contains("<=") || textBox.Text.Contains(">=") || textBox.Text.Contains("~=") || textBox.Text.Contains("!=") || textBox.Text.Contains("^=") || textBox.Text.Contains("(") || textBox.Text.Contains(")"))
                    {
                        e.Cancel = true;
                        error.SetError(textBox, "Invalid Character!");
                    }
                    else
                    {
                        e.Cancel = false;
                        error.SetError(textBox, null);
                    }
                }
            }
        }

        private bool checkEmail(string email)
        {
            bool exists = false;
            for (int i = 0; i < idDetails.Count; i++)
            {
                if (idDetails[i][14] == email)
                {
                    exists = true;
                }
            }
            return exists;
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
            ValidateEmail((TextBox)sender, e, errorProviderEA);
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
                            buttonSave.Enabled = false;
                            // this adds person
                            using (OleDbConnection db = new OleDbConnection(Properties.Settings.Default.DatabaseConnectionString))
                            {
                                string query = String.Format("INSERT INTO PERSON (Person_ID,Person_Name,Person_Surname,Person_Is_Removed,Person_Is_Employee,Person_Type, Person_Added) VALUES('{0}', '{1}', '{2}', False, True, " + (comboBoxPosition.SelectedIndex + 1) + ", @1)", textBoxID.Text, textBoxFN.Text, textBoxLN.Text);
                                db.Open();
                                OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM PERSON", db);
                                OleDbCommand command = new OleDbCommand(query, db);
                                command.Parameters.Add("@1", OleDbType.Date).Value = DateTime.Today;
                                adapter.InsertCommand = command;
                                adapter.InsertCommand.ExecuteNonQuery();
                                db.Close();
                            }
                            // this add contact details
                            using (OleDbConnection db = new OleDbConnection(Properties.Settings.Default.DatabaseConnectionString))
                            {
                                string query = String.Format("INSERT INTO CONTACT_DETAILS (Person_ID, House_Number, Street_Name, Postal_Code, Cell_Number_1, Cell_Number_2, Suburb, City, Email_Address) VALUES('{0}', '{1}', '{2}', {3}, {4}, {5}, '{6}', '{7}', '{8}')", textBoxID.Text, textBoxHN.Text, textBoxSN.Text, textBoxPC.Text, textBoxCN.Text, textBoxCN2.Text, textBoxS.Text, comboBoxCN.SelectedItem.ToString(), textBoxEA.Text);
                                db.Open();
                                OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM PERSON", db);
                                OleDbCommand command = new OleDbCommand(query, db);
                                adapter.InsertCommand = command;
                                adapter.InsertCommand.ExecuteNonQuery();
                                db.Close();
                            }
                            MessageBox.Show("Successfully updated database!");
                            buttonSave.Enabled = true;
                            break;
                    }
                }
                catch (Exception ex)
                {
                    BE_LogSystem log = new BE_LogSystem(ex);
                    log.saveError();
                    MessageBox.Show("Failed updating database!");
                    buttonSave.Enabled = true;
                }
            }
        }

        private void UI_EmployeeAdd_Load(object sender, EventArgs e)
        {
            buttonClose.Focus();
            BE_DatabaseCommands commands = new BE_DatabaseCommands();
            idDetails = commands.retrieveCustomDB("SELECT * FROM PERSON, CONTACT_DETAILS WHERE PERSON.Person_ID = CONTACT_DETAILS.Person_ID");
            employeeType = commands.retrieveDB("PERSON_TYPE");
            for (int i = 0; i < employeeType.Count; i++)
            {
                comboBoxPosition.Items.Add(employeeType[i][1]);
            }
            comboBoxPosition.SelectedIndex = 0;
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
