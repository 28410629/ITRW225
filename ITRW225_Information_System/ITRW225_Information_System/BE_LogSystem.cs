using System;
using System.IO;

namespace ITRW225_Information_System
{
    public class BE_LogSystem
    {
        private string source;
        private string message;
        private string stackTrace;
        
        public BE_LogSystem(Exception ex)
        {
            message = ex.Message;
            source = ex.Source;
            stackTrace = ex.StackTrace;
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
                    writer.WriteLine(DateTime.Now.ToString("h:mm:ss tt") + " " + source);
                    writer.WriteLine();
                    writer.WriteLine(message);
                    writer.WriteLine();
                    writer.WriteLine(stackTrace);
                    writer.WriteLine();
                    writer.WriteLine("-------------------------------------------FIN-------------------------------------------");
                    writer.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Log Error: " + ex.Message);
            }
        }
    }
}
