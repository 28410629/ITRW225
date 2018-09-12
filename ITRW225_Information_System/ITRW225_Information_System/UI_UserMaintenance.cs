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
            this.commands = new BE_DatabaseCommands();
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

        private void comboBoxEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < listE.Count; i++)
            {
                string some = "";
                for (int j = 0; j < listE[0].Length; j++)
                {
                    some += j + ": " + listE[i][j] + "\n";
                }
                MessageBox.Show(some);
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
            buttonAllow.Enabled = false;
            try
            {
                string query = null;
                if (!String.IsNullOrWhiteSpace(textBoxP1.Text))
                {
                    if (textBoxP1.Text == textBoxP2.Text)
                    {
                        query = String.Format("UPDATE LOGIN SET [A_CLIENT_MAINTENANCE] = @0, [A_EMPLOYEE_MAINTENANCE] = @1, [A_POINTS_OF_SALE] = @2, [A_REPORTS] = @3, [A_USER_MAINTENANCE] = @4, [A_SETTINGS] = @5, [PASSWORD] = '{0}' WHERE [EMPLOYEE_ID] = '{1}'", commands.hashPassword(textBoxP1.Text), employee);
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
                }
            }
            catch (Exception ex)
            {
                BE_LogSystem log = new BE_LogSystem(ex);
                log.saveError();
            }
            buttonAllow.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAllow_Click(object sender, EventArgs e)
        {
            buttonAllow.Enabled = false;
            setAccess("True");
            buttonAllow.Enabled = true;
        }

        private void buttonDeny_Click(object sender, EventArgs e)
        {
            buttonAllow.Enabled = false;
            setAccess("False");
            buttonAllow.Enabled = true;
        }

        private void setAccess(string selection)
        {
            for (int i = 0; i < listE.Count; i++)
            {
                if (listE[i][1] + " " + listE[i][2] == comboBoxEmployee.SelectedItem.ToString())
                {
                    string message = accessSystemDB(selection, listE[i][0]);
                    if (message == "Updated access permission to system!")
                    {
                        MessageBox.Show("Access updated!");
                        labelStatus.Text = "User can access system.";
                    }
                    else
                    {
                        MessageBox.Show("Access not updated!");
                        if (Convert.ToBoolean(listE[i][14]))
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
        }

        public string accessSystemDB(string access, string employeeID)
        {
            try
            {
                using (OleDbConnection database = new OleDbConnection(Properties.Settings.Default.DatabaseConnectionString))
                {
                    BE_DatabaseCommands dbCommands = new BE_DatabaseCommands();
                    database.Open();
                    OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM LOGIN", database);
                    OleDbCommand command = new OleDbCommand(String.Format("UPDATE LOGIN SET [A_TO_SYSTEM] = @0 WHERE [Person_ID] = '{0}'", employeeID), database);
                    command.Parameters.Add("@0", OleDbType.Boolean).Value = access;
                    adapter.InsertCommand = command;
                    adapter.InsertCommand.ExecuteNonQuery();
                    database.Close();
                }
                return "Updated access permission to system!";
            }
            catch (Exception ex)
            {
                BE_LogSystem log = new BE_LogSystem(ex);
                log.saveError();
                return "Failed updating access permission to system!";
            }
        }

        private void enableButtons(bool selection)
        {
            buttonAllow.Enabled = selection;
            buttonDeny.Enabled = selection;
            buttonClose.Enabled = selection;
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
