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
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"{leadingSpaces}.");
            Console.ResetColor();

            foreach (char c in welcomeMessage)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(c);
                Console.ResetColor();
                Thread.Sleep(70);
            }
            Thread.Sleep(500);
            Console.WriteLine($"\n\n\n{leadingSpaces}    Öppettider:\n" +
                $"{leadingSpaces}    Alla dagar\n{leadingSpaces}    Alla tider");
            Thread.Sleep(500);
            Console.ForegroundColor= ConsoleColor.Yellow;
            Console.WriteLine($"\n\n\n{leadingSpaces}Tryck valfri knapp\n" +
                $"{leadingSpaces}  för att starta");
            Console.ResetColor();
        }
    }
}
