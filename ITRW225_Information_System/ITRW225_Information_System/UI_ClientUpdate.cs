using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;
using System.Windows.Forms;

namespace ITRW225_Information_System
{
    public partial class UI_ClientUpdate : Form
    {
        private List<string[]> clientDetails;
        private List<string[]> idDetails;
        private string oldClientID = "";
        private BE_EmployeeMaintenance employee = new BE_EmployeeMaintenance();
        BE_TextboxValidation validation = new BE_TextboxValidation();
        Form mainForm;

        public UI_ClientUpdate(Form mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
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
            validation.ValidateComponent((TextBox)sender, e, errorProviderEA);
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

        private void buttonSave_Click(object sender, EventArgs e)
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
                                        string query = String.Format("UPDATE PERSON INNER JOIN CONTACT_DETAILS ON PERSON.Person_ID = CONTACT_DETAILS.Person_ID SET PERSON.Person_ID = '" + textBoxID.Text + "', CONTACT_DETAILS.Person_ID = '" + textBoxID.Text + "', PERSON.Person_Name = '" + textBoxFN.Text + "', PERSON.Person_Surname = '" + textBoxLN.Text + "', CONTACT_DETAILS.House_Number = '" + textBoxHN.Text + "', CONTACT_DETAILS.Street_Name = '" + textBoxSN.Text + "', CONTACT_DETAILS.Postal_Code = '" + textBoxPC.Text + "', CONTACT_DETAILS.Cell_Number_1 = '" + textBoxCN.Text + "', CONTACT_DETAILS.Cell_Number_2 = '" + textBoxCN2.Text + "', CONTACT_DETAILS.Suburb = '" + textBoxS.Text + "', CONTACT_DETAILS.City = '" + comboBoxCN.SelectedItem.ToString() + "', CONTACT_DETAILS.Email_Address = '" + textBoxEA.Text + "'  WHERE PERSON.Person_ID = '" + oldClientID + "'");
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
                }
            }
        }

        private void UI_ClientUpdate_Load(object sender, EventArgs e)
        {
            BE_DatabaseCommands commands = new BE_DatabaseCommands();

            clientDetails = commands.retrieveCustomDB("SELECT * FROM PERSON, CONTACT_DETAILS WHERE PERSON.Person_ID = CONTACT_DETAILS.Person_ID AND PERSON.Person_Is_Employee = False AND PERSON.Person_Is_Removed = False");
            idDetails = commands.retrieveCustomDB("SELECT * FROM PERSON, CONTACT_DETAILS WHERE PERSON.Person_ID = CONTACT_DETAILS.Person_ID");

            for (int i = 0; i < clientDetails.Count; i++)
            {
                comboBoxSE.Items.Add((clientDetails[i][1] + " " + clientDetails[i][2]));
            }
            comboBoxSE.SelectedIndex = 0;
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
                    textBoxHN.Text = clientDetails[i][7];
                    textBoxSN.Text = clientDetails[i][8];
                    textBoxPC.Text = clientDetails[i][9];
                    textBoxCN.Text = clientDetails[i][10];
                    textBoxCN2.Text = clientDetails[i][11];
                    textBoxS.Text = clientDetails[i][12];
                    textBoxEA.Text = clientDetails[i][14];
                    for (int k = 0; k < comboBoxCN.Items.Count; k++)
                    {
                        if (comboBoxCN.Items[k].ToString().Contains(clientDetails[i][13]))
                        {
                            comboBoxCN.SelectedIndex = k;
                        }
                    }
                }
            }
        }

        private void UI_ClientUpdate_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((mainForm.MdiChildren.Length - 1) == 0)
            {
                UI_Dashboard dashboard = new UI_Dashboard();
                dashboard.MdiParent = mainForm;
                dashboard.Show();
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
