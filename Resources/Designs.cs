using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassasystem.Resources
{
    public class Designs
    {
        public static void PrintHeader(string headerText)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n" + new string('=', headerText.Length + 4));
            Console.WriteLine($"| {headerText} |");
            Console.WriteLine(new string('=', headerText.Length + 4) + "\n");
            Console.ResetColor();
        }

        public static void PrintWithMargin(string text, int marginSize = 4)
        {
            string margin = new string(' ', marginSize);
            Console.WriteLine(margin + text);
        }
    }
}
