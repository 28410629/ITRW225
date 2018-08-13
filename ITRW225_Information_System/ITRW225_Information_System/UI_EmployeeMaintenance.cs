﻿using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace ITRW225_Information_System
{
    public partial class UI_EmployeeMaintenance : Form
    {
        public UI_EmployeeMaintenance(bool addEmployee)
        {
            if (addEmployee)
            {
                buttonSave.Text = "Save";
                Text = "Add Employee";
                
            }
            else
            {
                buttonSave.Text = "Edit";
                Text = "Edit Employee";
            }
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

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                BE_EmployeeMaintenance employee = new BE_EmployeeMaintenance();
                string[] arr = new string[] {textBoxCN.Text, textBoxEA.Text, textBoxFN.Text, textBoxHN.Text,
                                             textBoxID.Text, textBoxLN.Text, textBoxPC.Text, textBoxS.Text,
                                             textBoxSN.Text, textBoxVAT.Text, comboBoxCN.SelectedItem.ToString() };
                string message = employee.saveDB(arr);
                MessageBox.Show(message);
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
    }
}
