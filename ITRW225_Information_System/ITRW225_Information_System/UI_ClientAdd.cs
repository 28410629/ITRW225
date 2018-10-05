using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;
using System.Windows.Forms;

namespace ITRW225_Information_System
{
    public partial class UI_ClientAdd : Form
    {
        private List<string[]> idDetails;
        Form mainForm;
        BE_TextboxValidation validation = new BE_TextboxValidation();

        public UI_ClientAdd(Form mainForm)
        {
            InitializeComponent();
            comboBoxCN.SelectedIndex = 0;
            this.mainForm = mainForm;
        }

        private void UI_ClientMaintenance_Load(object sender, EventArgs e)
        {
            BE_DatabaseCommands commands = new BE_DatabaseCommands();
            idDetails = commands.retrieveCustomDB("SELECT * FROM PERSON, CONTACT_DETAILS WHERE PERSON.Person_ID = CONTACT_DETAILS.Person_ID");
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            e.Cancel = false;
        }

        private void textBoxFN_Validating(object sender, CancelEventArgs e)
        {
            validation.ValidateComponent((TextBox)sender, e, errorProviderFN);
        }

        private void textBoxLN_Validating(object sender, CancelEventArgs e)
        {
            validation.ValidateComponent((TextBox)sender, e, errorProviderLN);
        }

        private void textBoxCN_Validating(object sender, CancelEventArgs e)
        {
            validation.ValidateNumber((TextBox)sender, e, errorProviderCN, BE_Enum.NumberType.CELL, null, -1);
        }

        private void textBoxID_Validating(object sender, CancelEventArgs e)
        {
            validation.ValidateNumber((TextBox)sender, e, errorProviderID, BE_Enum.NumberType.ID, idDetails, 0);
        }

        private void textBoxVAT_Validating(object sender, CancelEventArgs e)
        {
            validation.ValidateComponent((TextBox)sender, e, errorProviderVAT);
        }

        private void textBoxEA_Validating(object sender, CancelEventArgs e)
        {
            validation.ValidateEmail((TextBox)sender, e, errorProviderEA, idDetails, 14);
        }

        private void textBoxHN_Validating(object sender, CancelEventArgs e)
        {
            validation.ValidateComponent((TextBox)sender, e, errorProviderHN);
        }

        private void textBoxSN_Validating(object sender, CancelEventArgs e)
        {
            validation.ValidateComponent((TextBox)sender, e, errorProviderSN);
        }

        private void textBoxS_Validating(object sender, CancelEventArgs e)
        {
            validation.ValidateComponent((TextBox)sender, e, errorProviderS);
        }

        private void textBoxPC_Validating(object sender, CancelEventArgs e)
        {
            validation.ValidateNumber((TextBox)sender, e, errorProviderPC, BE_Enum.NumberType.POSTAL, null, -1);
        }

        private void textBoxCN2_Validating(object sender, CancelEventArgs e)
        {
            validation.ValidateComponent((TextBox)sender, e, errorProviderCN2);
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
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
                                string query = String.Format("INSERT INTO PERSON (Person_ID,Person_Name,Person_Surname,Person_Is_Removed,Person_Is_Employee,Person_Type, Person_Added) VALUES('{0}', '{1}', '{2}', False, False, 5, @1)", textBoxID.Text, textBoxFN.Text, textBoxLN.Text);
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
                            ClearTextBoxes();
                            comboBoxCN.SelectedIndex = 0;
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

        private void ClearTextBoxes()
        {
            Action<Control.ControlCollection> func = null;

            func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is TextBox)
                        (control as TextBox).Clear();
                    else
                        func(control.Controls);
            };

            func(Controls);
        }

        private void UI_ClientAdd_FormClosing(object sender, FormClosingEventArgs e)
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
