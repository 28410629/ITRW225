using System;
using System.Text;

namespace ITRW225_Information_System
{
    public class BE_DatabaseCommands
    {
        public string hashPassword(string password)
        {
            var bytes = new UTF8Encoding().GetBytes(password);
            var hashBytes = System.Security.Cryptography.MD5.Create().ComputeHash(bytes);
            return Convert.ToBase64String(hashBytes);
        }
    }
}
