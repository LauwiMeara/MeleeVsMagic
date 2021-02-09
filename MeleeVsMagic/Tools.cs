using System;

namespace MeleeVsMagic
{
    public class Tools
    {
        public static void WriteWhiteText(string str)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(str);
            Console.ResetColor();
        }
        public static void WriteWhiteText(string str, int newLines)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(str);
            Console.ResetColor();

            for (int i = 0; i < newLines; i++)
            {
                Console.WriteLine();
            }
        }

        public static void PrintDashes()
        {
            Console.WriteLine(new string('-', 50));
        }
    }
}
