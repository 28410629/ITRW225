﻿using System;
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
    public partial class UI_ProductAdd : Form
    {
        private Form mainForm;
        private double amount;

        public UI_ProductAdd(Form form)
        {
            mainForm = form;
            InitializeComponent();
            
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
                    using (OleDbConnection db = new OleDbConnection(Properties.Settings.Default.DatabaseConnectionString))
                    {
                        string query = String.Format("INSERT INTO PRODUCT (Product_Name, Product_Price) VALUES('{0}', @1)", textBoxPN.Text);
                        db.Open();
                        OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM PRODUCT", db);
                        OleDbCommand command = new OleDbCommand(query, db);
                        command.Parameters.Add("@1", OleDbType.Double).Value = amount;
                        adapter.InsertCommand = command;
                        adapter.InsertCommand.ExecuteNonQuery();
                        db.Close();
                    }
                    MessageBox.Show("Successfully updated database!");
                    ClearTextBoxes();
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

        private void ValidateNumber(TextBox textBox, CancelEventArgs e, ErrorProvider error)
        {
            if (String.IsNullOrWhiteSpace(textBox.Text))
            {
                e.Cancel = true;
                error.SetError(textBox, "Required field.");
            }
            else
            {
                bool result = Double.TryParse(textBox.Text, out amount);
                if (result)
                {
                    e.Cancel = false;
                    error.SetError(textBox, null);
                }
                else
                {
                    e.Cancel = true;
                    error.SetError(textBox, "Must be a number! Refer to locale, to determine separator (',' or '.') used with cents.");
                }
            }
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
                if (textBox.Text.Contains("'") || textBox.Text.Contains("\"") || textBox.Text.Contains("||") || textBox.Text.Contains("-") ||
                     textBox.Text.Contains("*") || textBox.Text.Contains("/") || textBox.Text.Contains("<>") || textBox.Text.Contains("<") ||
                     textBox.Text.Contains(">") || textBox.Text.Contains(",") || textBox.Text.Contains("=") || textBox.Text.Contains("<=") ||
                     textBox.Text.Contains(">=") || textBox.Text.Contains("~=") || textBox.Text.Contains("!=") || textBox.Text.Contains("^=") ||
                     textBox.Text.Contains("(") || textBox.Text.Contains(")"))
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

        private void textBoxP_Validating(object sender, CancelEventArgs e)
        {
            ValidateNumber(textBoxP, e, errorProviderP);
        }

        private void textBoxPN_Validating(object sender, CancelEventArgs e)
        {
            ValidateComponent(textBoxPN, e, errorProviderPN);
        }

        private void UI_ProductAdd_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((mainForm.MdiChildren.Length - 1) == 0)
            {
                UI_Dashboard dashboard = new UI_Dashboard();
                dashboard.MdiParent = mainForm;
                dashboard.Show();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            e.Cancel = false;
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
    }
}
