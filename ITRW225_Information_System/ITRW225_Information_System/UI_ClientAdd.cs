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
        public UI_ClientAdd()
        {
            InitializeComponent();
            comboBoxCN.SelectedIndex = 0;
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

        private void textBoxID_Validating(object sender, CancelEventArgs e)
        {
            ValidateComponent((TextBox)sender, e, errorProviderID);
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
            ValidateComponent((TextBox)sender, e, errorProviderPC);
        }

        private void textBoxCN2_Validating(object sender, CancelEventArgs e)
        {
            ValidateComponent((TextBox)sender, e, errorProviderCN2);
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (OleDbConnection db = new OleDbConnection(Properties.Settings.Default.DatabaseConnectionString))
                {
                    string query = String.Format("INSERT INTO PERSON (Person_ID,Person_Name,Person_Surname,Person_Is_Removed,Person_Is_Employee,Person_Type) VALUES('{0}', '{1}', '{2}', @3, @4, 5)", textBoxID.Text, textBoxFN.Text, textBoxLN.Text);
                    db.Open();
                    OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM PERSON", db);
                    OleDbCommand command = new OleDbCommand(query, db);
                    command.Parameters.Add("@3", OleDbType.Boolean).Value = false;
                    command.Parameters.Add("@4", OleDbType.Boolean).Value = false;
                    adapter.InsertCommand = command;
                    adapter.InsertCommand.ExecuteNonQuery();
                    db.Close();
                }
            }
            catch (Exception ex)
            {
                BE_LogSystem log = new BE_LogSystem(ex);
                log.saveError();
            }
        }
    }
}
