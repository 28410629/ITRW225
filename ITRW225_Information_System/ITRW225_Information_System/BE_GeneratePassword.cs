using System;

namespace ITRW225_Information_System
{
    public class BE_GeneratePassword
    {
        public string generate()
        {
            Random random = new Random();
            string allowedChar = "abcdefghijklmnopqrstuvwABCDEFGHIJKLMNOPQRSTUVW12334567890!#$";
            string password = "";
            for (int i = 0; i < 8; i++)
            {
                password += allowedChar[random.Next(allowedChar.Length)];
            }
            return password;
        }
    }
}
