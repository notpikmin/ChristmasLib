using System;

namespace ChristmasLib.Utils
{
    public static class ConsoleUtils
    {
        public static void Write(string input, string mod = "Christmas")
        {
            Console.ResetColor();
            string time = "[" + DateTime.Now.ToString("HH:mm:ss") + "]";
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(time);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" [" + mod + "]: ");
            Console.ResetColor();
            Console.Write(input + "\n");
        }
        
        public static void Warning(string input, string mod = "Christmas")
        {
            Console.ResetColor();
            string time = "[" + DateTime.Now.ToString("HH:mm:ss") + "]";
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(time);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" [" + mod + "]: ");
            Console.ResetColor();
            Console.Write(input + "\n");
        }

        public static void Error(string input, string mod = "Christmas")
        {
            Console.ResetColor();
            string time = "[" + DateTime.Now.ToString("HH:mm:ss") + "]";
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(time);
            Console.Write(" [" + mod + "]: ");
            Console.ResetColor();
            Console.Write(input + "\n");
        }
        
        public static void Clear()
        {
            Console.Clear();    
        }
        
    }
}
