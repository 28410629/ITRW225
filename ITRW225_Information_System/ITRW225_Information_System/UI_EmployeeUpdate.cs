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
        private List<string[]> idDetails;
        private List<string[]> employeeType;
        private string oldEmployeeID = "";
        private string oldEmployeeEmail = "";
        private BE_EmployeeMaintenance employee = new BE_EmployeeMaintenance();
        BE_TextboxValidation validation = new BE_TextboxValidation();
        Form mainForm;

        public UI_EmployeeUpdate(Form mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            e.Cancel = false;
        }

        private void textBoxFN_Validating_1(object sender, CancelEventArgs e)
        {
            validation.ValidateComponent((TextBox)sender, e, errorProviderFN);
        }

        private void textBoxLN_Validating_1(object sender, CancelEventArgs e)
        {
            validation.ValidateComponent((TextBox)sender, e, errorProviderLN);
        }

        private void textBoxCN_Validating_1(object sender, CancelEventArgs e)
        {
            validation.ValidateNumber((TextBox)sender, e, errorProviderCN, BE_Enum.NumberType.CELL, null, -1, null);
        }

        private void textBoxCN2_Validating(object sender, CancelEventArgs e)
        {
            validation.ValidateNumber((TextBox)sender, e, errorProviderVAT, BE_Enum.NumberType.CELL, null, -1, null);
        }

        private void textBoxID_Validating(object sender, CancelEventArgs e)
        {
            validation.ValidateNumber((TextBox)sender, e, errorProviderID, BE_Enum.NumberType.ID, idDetails, 0, oldEmployeeID);    
        }

        private void textBoxHN_Validating_1(object sender, CancelEventArgs e)
        {
            validation.ValidateComponent((TextBox)sender, e, errorProviderHN);
        }

        private void textBoxSN_Validating_1(object sender, CancelEventArgs e)
        {
            validation.ValidateComponent((TextBox)sender, e, errorProviderSN);
        }

        private void textBoxS_Validating_1(object sender, CancelEventArgs e)
        {
            validation.ValidateComponent((TextBox)sender, e, errorProviderS);
        }

        private void textBoxPC_Validating_1(object sender, CancelEventArgs e)
        {
            validation.ValidateNumber((TextBox)sender, e, errorProviderPC, BE_Enum.NumberType.POSTAL, null, -1, "Not ID");
        }

        private void buttonSave_Click_1(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                try
                {
                    switch (MessageBox.Show(this, "Are you sure you want to update details?", "Update Details", MessageBoxButtons.YesNo))
                    {
                        case DialogResult.No:
                            break;
                        case DialogResult.Yes:
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
                                        string query = String.Format("UPDATE PERSON INNER JOIN CONTACT_DETAILS ON PERSON.Person_ID = CONTACT_DETAILS.Person_ID SET PERSON.Person_ID = '" + textBoxID.Text + "', CONTACT_DETAILS.Person_ID = '" + textBoxID.Text + "', PERSON.Person_Name = '" + textBoxFN.Text + "', PERSON.Person_Surname = '" + textBoxLN.Text + "', CONTACT_DETAILS.House_Number = '" + textBoxHN.Text + "', CONTACT_DETAILS.Street_Name = '" + textBoxSN.Text + "', CONTACT_DETAILS.Postal_Code = '" + textBoxPC.Text + "', CONTACT_DETAILS.Cell_Number_1 = '" + textBoxCN.Text + "', CONTACT_DETAILS.Cell_Number_2 = '" + textBoxCN2.Text + "', CONTACT_DETAILS.Suburb = '" + textBoxS.Text + "', CONTACT_DETAILS.City = '" + comboBoxCN.SelectedItem.ToString() + "', CONTACT_DETAILS.Email_Address = '" + textBoxEA.Text + "',PERSON.Person_Type = " + (comboBoxP.SelectedIndex + 1) + "   WHERE PERSON.Person_ID = '" + oldEmployeeID + "'");
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
                            break;
                        default:
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

        private void UI_EditEmployee_Load(object sender, EventArgs e)
        {
            BE_DatabaseCommands commands = new BE_DatabaseCommands();

            employeeDetails = commands.retrieveCustomDB("SELECT * FROM PERSON, CONTACT_DETAILS WHERE PERSON.Person_ID = CONTACT_DETAILS.Person_ID AND PERSON.Person_Is_Employee = True AND PERSON.Person_Is_Removed = False");
            employeeType = commands.retrieveDB("PERSON_TYPE");
            idDetails = commands.retrieveCustomDB("SELECT * FROM PERSON, CONTACT_DETAILS WHERE PERSON.Person_ID = CONTACT_DETAILS.Person_ID");

            for (int i = 0; i < employeeDetails.Count; i++)
            {
                comboBoxSE.Items.Add((employeeDetails[i][1] + " " + employeeDetails[i][2]));
            }
            for (int i = 0; i < employeeType.Count; i++)
            {
                comboBoxP.Items.Add(employeeType[i][1]);
            }
            comboBoxSE.SelectedIndex = 0;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
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
                    textBoxHN.Text = employeeDetails[i][7];
                    textBoxSN.Text = employeeDetails[i][8];
                    textBoxPC.Text = employeeDetails[i][9];
                    textBoxCN.Text = employeeDetails[i][10];
                    textBoxCN2.Text = employeeDetails[i][11];
                    textBoxS.Text = employeeDetails[i][12];
                    textBoxEA.Text = employeeDetails[i][14];
                    oldEmployeeEmail = employeeDetails[i][14];
                    for (int k = 0; k < comboBoxCN.Items.Count; k++)
                    {
                        if (comboBoxCN.Items[k].ToString().Contains(employeeDetails[i][13]))
                        {
                            comboBoxCN.SelectedIndex = k;
                        }
                    }
                    comboBoxP.SelectedIndex = Convert.ToInt32(employeeDetails[i][5])-1;
                }
            }
        }

        private void UI_EmployeeUpdate_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((mainForm.MdiChildren.Length - 1) == 0)
            {
                UI_Dashboard dashboard = new UI_Dashboard();
                dashboard.MdiParent = mainForm;
                dashboard.Show();
            }
        }

        private void textBoxEA_Validating(object sender, CancelEventArgs e)
        {
            validation.ValidateEmail((TextBox)sender, e, errorProviderEA, idDetails, 14, oldEmployeeEmail);
            //validation.ValidateComponent((TextBox)sender, e, errorProviderEA);
        }
    }
}
