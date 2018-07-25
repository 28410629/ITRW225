using System;
using System.IO;

namespace ITRW225_Information_System
{
    public class BE_LogSystem
    {
        private string source;
        private string message;
        
        public BE_LogSystem(Exception ex)
        {
            message = ex.Message;
            source = ex.Source;
        }

        public void saveError()
        {
            try
            {
                string path = Directory.GetCurrentDirectory() + "//Logs";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                path += "//" + DateTime.Now.ToLongDateString() + ".txt";
                using (StreamWriter writer = new StreamWriter(path))
                {
                    if (!File.Exists(path))
                    {
                        writer.WriteLine(source);
                        writer.WriteLine();
                        writer.WriteLine(message);
                        writer.WriteLine();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Log Error: " + ex.Message);
            }
        }
    }
}
