using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleHelper
{
    public enum ConsoleMessageTag
    {
        INFO,
        REQUEST,
        DEBUG,
        WARNING,
        ERROR,
        SUCCESS
    }

    public static class ConsoleManager
    {
        private static bool FORCE_DEBUG_MESSSAGES = true;

        public static void WriteLine(string _Line, ConsoleMessageTag _Tag)
        {
            string Tag = "";
            ConsoleColor TagColor = ConsoleColor.DarkGray;
            switch (_Tag)
            {
                case ConsoleMessageTag.INFO:
                    Tag = "INFO";
                    TagColor = ConsoleColor.White;
                    break;

                case ConsoleMessageTag.REQUEST:
                    Tag = "REQUEST";
                    TagColor = ConsoleColor.Magenta;
                    break;

                case ConsoleMessageTag.DEBUG:
                    Tag = "DEBUG";
                    TagColor = ConsoleColor.DarkYellow;
                    break;

                case ConsoleMessageTag.WARNING:
                    Tag = "WARNING";
                    TagColor = ConsoleColor.Yellow;
                    break;

                case ConsoleMessageTag.ERROR:
                    Tag = "ERROR";
                    TagColor = ConsoleColor.Red;
                    break;

                case ConsoleMessageTag.SUCCESS:
                    Tag = "SUCCESS";
                    TagColor = ConsoleColor.Green;
                    break;
            }

            //IF NOT FORCING DEBUG MESSAGES
            if (!FORCE_DEBUG_MESSSAGES)
            {
                //DO NOT PRINT DEBUG MESSAGE
                if (Tag != "DEBUG")
                {
                    PostMessage(_Line, Tag, TagColor);
                }

                //IF THE PPROGRAM IS IN DEBUG MODE
                //POST THE DEBUG MESSAGES ANYWAY
#if DEBUG
                if (Tag == "DEBUG")
                {
                    PostMessage(_Line, Tag, TagColor);
                }
#endif
            }

            //ELSE WRITE EVERY MESSAGE
            else
            {
                PostMessage(_Line, Tag, TagColor);
            }
        }

        public static void ForceDebugMessages(bool Force)
        {
            FORCE_DEBUG_MESSSAGES = Force;  
        }

        private static void PostMessage(string _Line, string Tag, ConsoleColor TagColor)
        {
            DateTime DT = DateTime.Now;
            string Date = "[" + DT.ToShortDateString() + " " + DT.ToShortTimeString() + "] ";

            Console.Write(Date);

            Console.ForegroundColor = TagColor;
            Console.Write("[" + Tag + "] ");
            Console.ForegroundColor = ConsoleColor.White;

            if (Tag != "DEBUG")
            {
                Console.WriteLine(_Line);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine(_Line);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
