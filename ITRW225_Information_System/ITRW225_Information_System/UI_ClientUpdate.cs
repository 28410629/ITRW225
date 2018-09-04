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
    public partial class UI_ClientUpdate : Form
    {
        private List<string[]> clientDetails;
        private string oldClientID = "";
        private BE_EmployeeMaintenance employee = new BE_EmployeeMaintenance();

        public UI_ClientUpdate()
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

        private void ValidateID(TextBox textBox, CancelEventArgs e, ErrorProvider error)
        {
            bool answer = false;
            if (textBox.Text != oldClientID)
            {
                for (int i = 0; i < clientDetails.Count; i++)
                {
                    if (clientDetails[i][0] == textBox.Text)
                    {
                        answer = true;
                    }
                }
            }
            if (answer)
            {
                e.Cancel = true;
                error.SetError(textBox, "ID exists, choose another.");
            }
            else
            {
                e.Cancel = false;
                error.SetError(textBox, null);
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
            ValidateComponent((TextBox)sender, e, errorProviderCN);
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
            ValidateComponent((TextBox)sender, e, errorProviderPC);
        }

        private void textBoxCN2_Validating(object sender, CancelEventArgs e)
        {
            ValidateComponent((TextBox)sender, e, errorProviderCN2);
        }

        private void textBoxID_Validating(object sender, CancelEventArgs e)
        {
            ValidateID((TextBox)sender, e, errorProviderID);
        }
        /*
        public string updateDB()
        {
            try
            {
                using (OleDbConnection database = new OleDbConnection(Properties.Settings.Default.DatabaseConnectionString))
                {
                    database.Open();
                    OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM EMPLOYEE", database);
                    OleDbCommand commandEmployee = new OleDbCommand(String.Format("UPDATE EMPLOYEE SET EMPLOYEE_ID = '{0}', EMPLOYEE_TYPE_NUMBER = {1}, EMPLOYEE_NAME = '{2}', EMPLOYEE_SURNAME = '{3}' WHERE EMPLOYEE_ID = '{4}'", textBoxID.Text, posNumber, textBoxFN.Text, textBoxLN.Text, oldEmployeeID), database);
                    adapter.InsertCommand = commandEmployee;
                    adapter.InsertCommand.ExecuteNonQuery();
                    database.Close();
                }
                return "Succesfully saved to database!";
            }
            catch (Exception ex)
            {
                BE_LogSystem log = new BE_LogSystem(ex);
                log.saveError();
                return "Failed saving to database!";
            }
        }*/

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
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

                        break;
                }
            }
        }

        private void UI_ClientUpdate_Load(object sender, EventArgs e)
        {
            BE_DatabaseCommands commands = new BE_DatabaseCommands();

            clientDetails = commands.retrieveCustomDB("SELECT * FROM PERSON, CONTACT_DETAILS WHERE PERSON.Person_ID = CONTACT_DETAILS.Person_ID AND PERSON.Person_Is_Employee = False AND PERSON.Person_Is_Removed = False");

            for (int i = 0; i < clientDetails.Count; i++)
            {
                comboBoxSE.Items.Add((clientDetails[i][1] + " " + clientDetails[i][2]));
            }
        }

        private void comboBoxSE_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < clientDetails.Count; i++)
            {
                if ((clientDetails[i][1] + " " + clientDetails[i][2]) == comboBoxSE.SelectedItem.ToString())
                {
                    textBoxFN.Text = clientDetails[i][1];
                    textBoxLN.Text = clientDetails[i][2];
                    textBoxID.Text = clientDetails[i][0];
                    oldClientID = clientDetails[i][0];
                    textBoxHN.Text = clientDetails[i][6];
                    textBoxSN.Text = clientDetails[i][7];
                    textBoxPC.Text = clientDetails[i][8];
                    textBoxCN.Text = clientDetails[i][9];
                    textBoxCN2.Text = clientDetails[i][10];
                    textBoxS.Text = clientDetails[i][11];
                    textBoxEA.Text = clientDetails[i][13];
                    for (int k = 0; k < comboBoxCN.Items.Count; k++)
                    {
                        if (comboBoxCN.Items[k].ToString().Contains(clientDetails[i][12]))
                        {
                            comboBoxCN.SelectedIndex = k;
                        }
                    }
                }
            }
        }
    }
}
