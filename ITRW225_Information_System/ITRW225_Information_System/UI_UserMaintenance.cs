using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Windows.Forms;

namespace ITRW225_Information_System
{
    public partial class UI_UserMaintenance : Form
    {
        private BE_DatabaseCommands commands;
        private string employee;
        private List<string[]> listE;
        Form mainForm;

        public UI_UserMaintenance(Form mainForm)
        {
            commands = new BE_DatabaseCommands();
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void UI_UserMaintenance_Load(object sender, EventArgs e)
        {
            listE = commands.retrieveCustomDB("SELECT * FROM PERSON, LOGIN WHERE PERSON.Person_ID = LOGIN.Person_ID AND PERSON.Person_Is_Employee = True AND PERSON.Person_Is_Removed = False");
            for (int i = 0; i < listE.Count; i++)
            {
                comboBoxEmployee.Items.Add(listE[i][1] + " " + listE[i][2]);
            }
            comboBoxEmployee.SelectedIndex = 0;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            e.Cancel = false;
        }

        private void comboBoxEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < listE.Count; i++)
            {
                if (listE[i][1] + " " + listE[i][2] == comboBoxEmployee.SelectedItem.ToString())
                {
                    employee = listE[i][0];
                    checkBoxCM.Checked = Convert.ToBoolean(listE[i][9]);
                    checkBoxEM.Checked = Convert.ToBoolean(listE[i][10]);
                    checkBoxPOS.Checked = Convert.ToBoolean(listE[i][11]);
                    checkBoxR.Checked = Convert.ToBoolean(listE[i][12]);
                    checkBoxUM.Checked = Convert.ToBoolean(listE[i][13]);
                    checkBoxS.Checked = Convert.ToBoolean(listE[i][14]);
                    if (Convert.ToBoolean(listE[i][15]))
                    {
                        labelStatus.Text = "User can access system.";
                    }
                    else
                    {
                        labelStatus.Text = "User is denied access to system.";
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            enableButtons(false);
            try
            {
                switch (MessageBox.Show(this, "Are you sure you want to update details?", "Update Details", MessageBoxButtons.YesNo))
                {
                    case DialogResult.No:
                        break;
                    case DialogResult.Yes:
                        enableButtons(false);
                        string query = null;
                        if (!String.IsNullOrWhiteSpace(textBoxP1.Text))
                        {
                            if (textBoxP1.Text == textBoxP2.Text)
                            {
                                query = String.Format("UPDATE LOGIN SET [A_CLIENT_MAINTENANCE] = @0, [A_EMPLOYEE_MAINTENANCE] = @1, [A_POINTS_OF_SALE] = @2, [A_REPORTS] = @3, [A_USER_MAINTENANCE] = @4, [A_SETTINGS] = @5, [PASSWORD] = '{0}' WHERE [Person_ID] = '{1}'", commands.hashPassword(textBoxP1.Text), employee);
                            }
                            else
                            {
                                MessageBox.Show("Please ensure passwords are the same, thank you.");
                            }
                        }
                        else
                        {
                            query = String.Format("UPDATE LOGIN SET [A_CLIENT_MAINTENANCE] = @0, [A_EMPLOYEE_MAINTENANCE] = @1, [A_POINTS_OF_SALE] = @2, [A_REPORTS] = @3, [A_USER_MAINTENANCE] = @4, [A_SETTINGS] = @5 WHERE [Person_ID] = '{0}'", employee);
                        }
                        if (!String.IsNullOrWhiteSpace(query))
                        {
                            using (OleDbConnection db = new OleDbConnection(Properties.Settings.Default.DatabaseConnectionString))
                            {
                                db.Open();
                                OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM LOGIN", db);
                                OleDbCommand command = new OleDbCommand(query, db);
                                command.Parameters.Add("@0", OleDbType.Boolean).Value = checkBoxCM.Checked;
                                command.Parameters.Add("@1", OleDbType.Boolean).Value = checkBoxEM.Checked;
                                command.Parameters.Add("@2", OleDbType.Boolean).Value = checkBoxPOS.Checked;
                                command.Parameters.Add("@3", OleDbType.Boolean).Value = checkBoxR.Checked;
                                command.Parameters.Add("@4", OleDbType.Boolean).Value = checkBoxUM.Checked;
                                command.Parameters.Add("@5", OleDbType.Boolean).Value = checkBoxS.Checked;
                                adapter.InsertCommand = command;
                                adapter.InsertCommand.ExecuteNonQuery();
                                db.Close();
                            }
                            MessageBox.Show("Updated Permission!");
                            comboBoxEmployee.Items.Clear();
                            UI_UserMaintenance_Load(sender, e);
                            enableButtons(true);
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
                MessageBox.Show("Failes updating Permission!");
            }
            enableButtons(true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonAllow_Click(object sender, EventArgs e)
        {
            enableButtons(false);
            setAccess(true);
            enableButtons(true);
        }

        private void buttonDeny_Click(object sender, EventArgs e)
        {
            enableButtons(false);
            setAccess(false);
            enableButtons(true);
        }

        private void setAccess(bool permission)
        {
            for (int i = 0; i < listE.Count; i++)
            {
                if (listE[i][1] + " " + listE[i][2] == comboBoxEmployee.SelectedItem.ToString())
                {
                    labelStatus.Text = accessSystemDB(permission, Convert.ToBoolean(listE[i][15]), listE[i][0]);
                }
            }
        }

        public string accessSystemDB(bool newPermission, bool oldPermission, string employeeID)
        {
            try
            {
                using (OleDbConnection database = new OleDbConnection(Properties.Settings.Default.DatabaseConnectionString))
                {
                    BE_DatabaseCommands dbCommands = new BE_DatabaseCommands();
                    database.Open();
                    OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM LOGIN", database);
                    OleDbCommand command = new OleDbCommand(String.Format("UPDATE LOGIN SET [A_TO_SYSTEM] = @0 WHERE [Person_ID] = '{0}'", employeeID), database);
                    command.Parameters.Add("@0", OleDbType.Boolean).Value = newPermission;
                    adapter.InsertCommand = command;
                    adapter.InsertCommand.ExecuteNonQuery();
                    database.Close();
                }
                if (newPermission)
                {
                    return "Updated, user is allowed to access system!";
                }
                else
                {
                    return "Updated, user is deniend access to system!";
                }
            }
            catch (Exception ex)
            {
                BE_LogSystem log = new BE_LogSystem(ex);
                log.saveError();
                if (oldPermission)
                {
                    return "Failed updating, access still granted";
                }
                else
                {
                    return "Failed updating, access still denied";
                }
                
            }
        }

        private void enableButtons(bool selection)
        {
            buttonAllow.Enabled = selection;
            buttonDeny.Enabled = selection;
            buttonSave.Enabled = selection;
        }

        private void UI_UserMaintenance_FormClosing(object sender, FormClosingEventArgs e)
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
