using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITRW225_Information_System
{
    public partial class UI_ClientAdd : Form
    {
        Form mainForm;
        public UI_ClientAdd(Form mainForm)
        {
            InitializeComponent();
            comboBoxCN.SelectedIndex = 0;
            this.mainForm = mainForm;
        }

        private void UI_ClientMaintenance_Load(object sender, EventArgs e)
        {

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
                        e.Cancel = false;
                        error.SetError(textBox, null);
                    }
                }
                else
                {
                    e.Cancel = true;
                    error.SetError(textBox, "Must be a number!");
                }
            }
        }

        private void textBoxFN_Validating(object sender, CancelEventArgs e)
        {
            ValidateComponent((TextBox)sender, e, errorProviderFN);
        }

        private void textBoxLN_Validating(object sender, CancelEventArgs e)
        {
            ValidateComponent((TextBox)sender, e, errorProviderLN);
        }

        private void textBoxCN_Validating(object sender, CancelEventArgs e)
        {
            ValidateNumber((TextBox)sender, e, errorProviderCN, "Cell");
        }

        private void textBoxID_Validating(object sender, CancelEventArgs e)
        {
            ValidateNumber((TextBox)sender, e, errorProviderID, "ID");
        }

        private void textBoxVAT_Validating(object sender, CancelEventArgs e)
        {
            ValidateComponent((TextBox)sender, e, errorProviderVAT);
        }

        private void textBoxEA_Validating(object sender, CancelEventArgs e)
        {
            ValidateComponent((TextBox)sender, e, errorProviderEA);
        }

        private void textBoxHN_Validating(object sender, CancelEventArgs e)
        {
            ValidateComponent((TextBox)sender, e, errorProviderHN);
        }

        private void textBoxSN_Validating(object sender, CancelEventArgs e)
        {
            ValidateComponent((TextBox)sender, e, errorProviderSN);
        }

        private void textBoxS_Validating(object sender, CancelEventArgs e)
        {
            ValidateComponent((TextBox)sender, e, errorProviderS);
        }

        private void textBoxPC_Validating(object sender, CancelEventArgs e)
        {
            ValidateNumber((TextBox)sender, e, errorProviderPC, "Postal");
        }

        private void textBoxCN2_Validating(object sender, CancelEventArgs e)
        {
            ValidateNumber((TextBox)sender, e, errorProviderCN2, "Cell");
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
