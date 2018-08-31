using System;
using System.IO;
using System.Threading;

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
            Thread thread = new Thread(new ThreadStart(runSaveError));
            thread.Start();
        }

        private void runSaveError()
        {
            try
            {
                string path = Directory.GetCurrentDirectory() + "//Logs";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                path += String.Format("//{0} {1} {2}.txt", DateTime.Now.Year, DateTime.Now.ToString("MMMM"), DateTime.Now.Day);
                using (StreamWriter writer = new StreamWriter(path, append: true))
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
