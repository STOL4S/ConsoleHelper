using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleHelper
{
    public static class ExceptionHandler
    {
        public static void Handle(Exception Ex, bool PromptUser)
        {
            ConsoleManager.WriteLine(Ex.Message, ConsoleMessageTag.ERROR);

            DateTime DT = DateTime.Now;
            string LogGenName = DT.Month.ToString() + DT.Day.ToString() + DT.Year.ToString()
                + "_" + DT.Hour.ToString() + DT.Minute.ToString() + DT.Second.ToString() + ".txt";
            ConsoleManager.WriteLine("WRITING ERROR TO FILE: LOGS/" + LogGenName.ToUpper(), ConsoleMessageTag.ERROR);
            if (!Directory.Exists(Environment.CurrentDirectory + "/Logs"))
            {
                Directory.CreateDirectory(Environment.CurrentDirectory + "/Logs");
            }
            using (StreamWriter Writer = new StreamWriter("Logs/" + LogGenName))
            {
                string BuildString = Ex.Message;
                if (Ex.InnerException != null)
                {
                    BuildString += "\n\n" + Ex.InnerException.Message;
                }
                Writer.Write(BuildString);
            }

            if (PromptUser)
            {
                ConsoleManager.WriteLine("AN EXCEPTION WAS THROWN THAT COULD PREVENT THE PROGRAM FROM OPERATING CORRECTLY.", ConsoleMessageTag.WARNING);
                ConsoleManager.WriteLine("WOULD YOU LIKE TO CONTINUE OPERATION? Y/N?", ConsoleMessageTag.INFO);
                ConsoleKeyInfo KeyInfo;
                do
                {
                    KeyInfo = Console.ReadKey(true);
                }
                while (KeyInfo.Key != ConsoleKey.Y &&
                KeyInfo.Key != ConsoleKey.N);

                if (KeyInfo.Key == ConsoleKey.N)
                {
                    Environment.Exit(0);
                }
            }
            else
            {
                Thread.Sleep(5000);
                Environment.Exit(0);
            }
        }
    }
}
