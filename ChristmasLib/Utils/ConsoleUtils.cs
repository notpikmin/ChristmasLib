using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChristmasLib.Utils
{
    public static class ConsoleUtils
    {
        public static void Write(string Input, string mod = "Christmas")
        {
            Console.ResetColor();
            string time = "[" + DateTime.Now.ToString("HH:mm:ss") + "]";
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(time);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" [" + mod + "]: ");
            Console.ResetColor();
            Console.Write(Input + "\n");
        }

        public static void Error(string Input, string mod = "Christmas")
        {
            Console.ResetColor();
            string time = "[" + DateTime.Now.ToString("HH:mm:ss") + "]";
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(time);
            Console.Write(" [" + mod + "]: ");
            Console.ResetColor();
            Console.Write(Input + "\n");
        }
    }
}
