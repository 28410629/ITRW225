using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;
using System.Windows.Forms;

namespace ITRW225_Information_System
{
    public partial class UI_EmployeeUpdate : Form
    {
        private List<string[]> employeeDetails;
        private List<string[]> employeeType;
        private string oldEmployeeID = "";
        private string contactDetailsNumber = "";
        private string posNumber = "";
        private BE_EmployeeMaintenance employee = new BE_EmployeeMaintenance();

        public UI_EmployeeUpdate()
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
            if (textBox.Text != oldEmployeeID)
            {
                for (int i = 0; i < employeeDetails.Count; i++)
                {
                    if (employeeDetails[i][0] == textBox.Text)
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

        private void UI_EditEmployee_Load(object sender, EventArgs e)
        {
            BE_DatabaseCommands commands = new BE_DatabaseCommands();

            employeeDetails = commands.retrieveCustomDB("SELECT * FROM PERSON, CONTACT_DETAILS WHERE PERSON.Person_ID = CONTACT_DETAILS.Person_ID AND PERSON.Person_Is_Employee = True AND PERSON.Person_Is_Removed = False");
            employeeType = commands.retrieveDB("PERSON_TYPE");

            for (int i = 0; i < employeeDetails.Count; i++)
            {
                comboBoxSE.Items.Add((employeeDetails[i][1] + " " + employeeDetails[i][2]));
            }
            for (int i = 0; i < employeeType.Count; i++)
            {
                comboBoxP.Items.Add(employeeType[i][1]);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBoxCN2_Validating(object sender, CancelEventArgs e)
        {
            ValidateComponent((TextBox)sender, e, errorProviderCN2);
        }

        private void comboBoxSE_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < employeeDetails.Count; i++)
            {
                if ((employeeDetails[i][1] + " " + employeeDetails[i][2]) == comboBoxSE.SelectedItem.ToString())
                {
                    textBoxFN.Text = employeeDetails[i][1];
                    textBoxLN.Text = employeeDetails[i][2];
                    textBoxID.Text = employeeDetails[i][0];
                    oldEmployeeID = employeeDetails[i][0];
                    textBoxHN.Text = employeeDetails[i][6];
                    textBoxSN.Text = employeeDetails[i][7];
                    textBoxPC.Text = employeeDetails[i][8];
                    textBoxCN.Text = employeeDetails[i][9];
                    textBoxCN2.Text = employeeDetails[i][10];
                    textBoxS.Text = employeeDetails[i][11];
                    textBoxEA.Text = employeeDetails[i][13];
                    for (int k = 0; k < comboBoxCN.Items.Count; k++)
                    {
                        if (comboBoxCN.Items[k].ToString().Contains(employeeDetails[i][12]))
                        {
                            comboBoxCN.SelectedIndex = k;
                        }
                    }
                    comboBoxP.SelectedIndex = Convert.ToInt32(employeeDetails[i][5])-1;
                }
            }
        }

        private void textBoxID_Validating(object sender, CancelEventArgs e)
        {
            ValidateID((TextBox)sender, e, errorProviderID);
        }

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
                using (OleDbConnection database = new OleDbConnection(Properties.Settings.Default.DatabaseConnectionString))
                {
                    database.Open();
                    OleDbDataAdapter adapterC = new OleDbDataAdapter("SELECT * FROM CONTACT_DETAILS", database);
                    OleDbCommand commandContact = new OleDbCommand("UPDATE CONTACT_DETAILS SET [HOUSE_NUMBER] = '" + textBoxHN.Text + "', [STREET_NAME] = '" + textBoxSN.Text + "', [POSTAL_CODE] = '" + textBoxPC.Text + "', [CELL_NUMBER] = '" + textBoxCN.Text + "', [BACKUP_CELL_NUMBER] = '" + textBoxCN2.Text + "', [SUBURB] = '" + textBoxS.Text + "', [CITY] = '" + comboBoxCN.SelectedItem.ToString() + "', [EMAIL] = '" + textBoxEA.Text + "', [EMPLOYEE_ID] = '" + textBoxID.Text + "' WHERE [EMPLOYEE_ID] = '" + oldEmployeeID + "'", database);
                    adapterC.InsertCommand = commandContact;
                    adapterC.InsertCommand.ExecuteNonQuery();
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
        }
    }
}
