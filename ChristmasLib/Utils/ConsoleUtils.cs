using System;
using ChristmasLib.Internal;

namespace ChristmasLib.Utils
{
    public static class ConsoleUtils
    {
        #region Logging
        public static void Write<T>(T input, string mod = "Christmas")
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
        
        public static void Warning<T>(T input, string mod = "Christmas")
        {
            Console.ResetColor();
            string time = "[" + DateTime.Now.ToString("HH:mm:ss") + "]";
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(time);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" [" + mod + "]: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(input + "\n");
            Console.ResetColor();

        }

        public static void Error<T>(T input, string mod = "Christmas")
        {
            Console.ResetColor();
            string time = "[" + DateTime.Now.ToString("HH:mm:ss") + "]";
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(time);
            Console.Write(" [" + mod + "]: ");
            Console.Write(input + "\n");
            Console.ResetColor();

        }

        public static void Debug<T>(T input, string mod = "Christmas")
        {
            if (PluginSettings.PluginCfg.Debug)
            {
                Console.ResetColor();
                string time = "[" + DateTime.Now.ToString("HH:mm:ss") + "]";
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(time);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(" [" + mod + "]: ");
                Console.ForegroundColor = ConsoleColor.Cyan;

                Console.Write(input + "\n");
                Console.ResetColor();

            }
        }
        #endregion
        
        public static void Clear()
        {
            Console.Clear();    
        }
        
    }
}
