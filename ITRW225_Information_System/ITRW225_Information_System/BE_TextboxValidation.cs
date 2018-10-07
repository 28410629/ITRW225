using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ITRW225_Information_System
{
    public class BE_TextboxValidation
    {

        public void ValidateComponent(TextBox textBox, CancelEventArgs e, ErrorProvider error)
        {
            if (String.IsNullOrWhiteSpace(textBox.Text))
            {
                e.Cancel = true;
                error.SetError(textBox, "Provide field, before continuing.");
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
                    error.SetError(textBox, "Invalid Character! Provide correct field, before continuing.");
                }
                else
                {
                    e.Cancel = false;
                    error.SetError(textBox, null);
                }
            }
        }

        bool IsValidEmail(string email)
        {
            var regex = new Regex(@"^[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$", RegexOptions.Compiled);
            return regex.IsMatch(email);
        }

        public void ValidateEmail(TextBox textBox, CancelEventArgs e, ErrorProvider error, List<string[]> recordedEmails, int emailPosition, string oldEmail)
        {
            if (String.IsNullOrWhiteSpace(textBox.Text))
            {
                e.Cancel = true;
                error.SetError(textBox, "Provide field, before continuing.");
            }
            else
            {
                if (checkEmail(textBox.Text, recordedEmails, emailPosition, oldEmail))
                {
                    e.Cancel = true;
                    error.SetError(textBox, "Email exists!");
                }
                else
                {
                    if (IsValidEmail(textBox.Text))
                    {
                        e.Cancel = true;
                        error.SetError(textBox, "Invalid Email, please revise!");
                    }
                    else
                    {
                        e.Cancel = false;
                        error.SetError(textBox, null);
                    }
                }
            }
        }

        // check for existing emails
        private bool checkEmail(string email, List<string[]> idDetails, int emailLocation, string updatedPersonEmail)
        {
            bool exists = false;
            for (int i = 0; i < idDetails.Count; i++)
            {
                if (idDetails[i][emailLocation] == email)
                {
                    if (email != updatedPersonEmail)
                    {
                        exists = true;
                    }
                }
            }
            return exists;
        }

        public void ValidateNumber(TextBox textBox, CancelEventArgs e, ErrorProvider error, BE_Enum.NumberType type, List<string[]> userDetails, int arrPosition, string oldID)
        {
            int length = 0;
            string msg = "";
            switch (type)
            {
                case BE_Enum.NumberType.ID:
                    length = 13;
                    msg = "Must be 13 digit ID.";
                    break;
                case BE_Enum.NumberType.CELL:
                    length = 10;
                    msg = "Must be 10 digit cellphone number.";
                    break;
                case BE_Enum.NumberType.POSTAL:
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
                        if (type == BE_Enum.NumberType.ID)
                        {
                            if (checkID(textBox.Text, userDetails, arrPosition, oldID))
                            {
                                e.Cancel = true;
                                error.SetError(textBox, "ID exists!");
                            }
                            else
                            {
                                e.Cancel = false;
                                error.SetError(textBox, null);
                            }
                        }
                        else
                        {
                            e.Cancel = false;
                            error.SetError(textBox, null);
                        }
                    }
                }
                else
                {
                    e.Cancel = true;
                    error.SetError(textBox, "Must be a number!");
                }
            }
        }

        private bool checkID(string id, List<string[]> idDetails, int position, string updatePersonID) // when adding make -1
        {
            bool exists = false;
            for (int i = 0; i < idDetails.Count; i++)
            {
                if (idDetails[i][position] == id)
                {
                    if(id != updatePersonID)
                    {
                        exists = true;
                    }
                }
            }
            return exists;
        }
    }
}
