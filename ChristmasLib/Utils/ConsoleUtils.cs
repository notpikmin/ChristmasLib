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
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(time);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" [" + mod + "]: ");
            Console.ResetColor();
            Console.Write(Input + "\n");
            //Console.WriteLine(time + " [" + mod +"]: "+ Input);
        }
    }
}
