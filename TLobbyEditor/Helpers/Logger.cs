using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPlugins.TLobbyEditor
{
    public class Logger
    {
        public static void Log(string message, ConsoleColor color = ConsoleColor.Green, string prefix = "[INFO] >")
        {
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(prefix + " " + message);
            Console.ForegroundColor = oldColor;
        }

        public static void LogWarning(string message, ConsoleColor color = ConsoleColor.Yellow, string prefix = "[WARNING] >")
        {
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(prefix + " " + message);
            Console.ForegroundColor = oldColor;
        }

        public static void LogError(string message, ConsoleColor color = ConsoleColor.Red, string prefix = "[ERROR] >")
        {
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(prefix + " " + message);
            Console.ForegroundColor = oldColor;
        }
    }
}
