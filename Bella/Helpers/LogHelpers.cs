using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bela.Helpers
{
    public class LogHelpers
    {
        
      static string path = Application.ExecutablePath.Replace(Application.ExecutablePath.Split('\\')[Application.ExecutablePath.Split('\\').Length - 1], "Log.txt");
      static string fileName;
      static string timeAudit = DateTime.Now.ToString();
      static TextWriter wAudit = File.AppendText(path);

      //Write in the log
        public static void WriteLog(string message, Helpers.Enumerations.LevelAudit level)
        {
            if (message == null || message.Length == 0)
            {
                return;
            }
            //Write in file 
            WriteFile(message, level);
            //Write in console
            WriteConsole(message, level);
            //Write in DB

        }

        private static void WriteFile(string message, Helpers.Enumerations.LevelAudit level)
        {
            if (wAudit != null)
            {

                if (((int)level) == 3)
                {
                    wAudit.WriteLine(timeAudit + " : " + message);
                    Console.ForegroundColor = ConsoleColor.Red;

                }
                else if (((int)level) == 2)
                {
                    wAudit.WriteLine(timeAudit + " : " + message);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else if (((int)level) == 1)
                {
                    wAudit.WriteLine(timeAudit + " : " + message);
                    Console.ForegroundColor = ConsoleColor.White;
                }

                wAudit.Flush();
            }
         
        }

        private static void WriteConsole(string message, Helpers.Enumerations.LevelAudit level)
        {
          
                if (((int)level) == 3)
                {
                    Console.WriteLine(DateTime.Now.ToShortDateString() + " : " + message);
                    Console.ForegroundColor = ConsoleColor.Red;

                }
                else if (((int)level) == 2)
                {
                    Console.WriteLine(DateTime.Now.ToShortDateString() + " : " + message);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else if (((int)level) == 1)
                {
                    Console.WriteLine(DateTime.Now.ToShortDateString() + " : " + message);
                    Console.ForegroundColor = ConsoleColor.White;
                }

        }
      
        //Check the size of the log if large creates a new file write what is in the current log and then truncate the main log
        public static void CheckSize()
        {

            wAudit.Close();
            string[] dividedPath = Application.ExecutablePath.Split('\\');
            fileName = "";
            foreach (var item in dividedPath)
            {
                if (!item.ToUpper().Contains("exe".ToUpper()))
                    fileName += item + @"\";
            }
            fileName += "Log.txt";
            if (!File.Exists(fileName))
            {
                wAudit = File.AppendText(fileName);
            }
            else
            {
                FileStream file = File.Open(fileName, FileMode.Append);
                wAudit = new StreamWriter(file);
            }
            FileInfo f = new FileInfo(fileName);
            if (f.Length > 2 * 1024 * 1024)
            {
                string newFileName = fileName.Replace(".txt", string.Format("-{0:yyyyMMdd}.txt", DateTime.Now));
                wAudit.Close();

                File.Copy(fileName, newFileName);
                File.WriteAllText(fileName, fileName);

                FileStream file = File.Open(fileName, FileMode.Truncate);
                wAudit = new StreamWriter(file);
                wAudit.Flush();
                wAudit.Close();
            }
        }
    }
}
