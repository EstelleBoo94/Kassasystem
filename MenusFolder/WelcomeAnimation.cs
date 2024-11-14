using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassasystem.MenusFolder
{
    public class WelcomeAnimation
    {
        public static void ShowWelcomeAnimation()
        {
            int consoleWidth = Console.WindowWidth;
            string welcomeMessage = "NET24-MATAFFÄREN";
            int spaces = consoleWidth / 2 - welcomeMessage.Length / 2;
            string leadingSpaces = new string(' ', spaces);
            Console.WriteLine($"\n\n\n{leadingSpaces}  Välkommen till");
            Console.Write($"{leadingSpaces}.");

            foreach (char c in welcomeMessage)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(c);
                Console.ResetColor();
                Thread.Sleep(70);
            }
            Thread.Sleep(500);
            Console.WriteLine($"\n\n\n{leadingSpaces}Tryck valfri knapp\n{leadingSpaces}  för att starta");
        }
    }
}
