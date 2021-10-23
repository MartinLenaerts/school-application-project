using System;
using System.Drawing.Printing;

namespace Projet_applications
{
    public class CustomConsole
    {
        public static void PrintSuccess(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(msg);
            Console.ResetColor();
        }
        
        public static void PrintError(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg);
            Console.ResetColor();
        }
        
        
        public static void PrintChoice(int number,string msg)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(number);
            Console.ResetColor();
            Console.WriteLine(" : "+msg);
        }
    }
}