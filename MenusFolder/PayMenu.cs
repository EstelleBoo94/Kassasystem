using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kassasystem.PurchasesFolder;
using Kassasystem.Resources;

namespace Kassasystem.MenusFolder
{
    public class PayMenu
    {
        public void ShowPayMenu()
        {
            Pay pay = new Pay();
            List<string> paymentOptions = new List<string>
            {
            "Kort", "Kontant"
            };

            int selection = 0;
            bool inMenu = true;

            while (inMenu == true)
            {
                Console.Clear();
                Designs.PrintHeader("BETALNING");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Välj alternativ med piltangenterna:");
                Console.ResetColor();

                for (int i = 0; i < paymentOptions.Count; i++)
                {
                    if (i == selection)
                    {
                        Console.BackgroundColor = ConsoleColor.Cyan;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }

                    Console.WriteLine(paymentOptions[i]);

                    Console.ResetColor();
                }

                if (selection == paymentOptions.Count)
                {
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                Console.WriteLine("Avbryt köp");
                Console.ResetColor();


                var keyInput = Console.ReadKey(true);

                if (keyInput.Key == ConsoleKey.UpArrow)
                {
                    selection--;
                    if (selection < 0)
                    {
                        selection = paymentOptions.Count;
                    }
                }

                else if (keyInput.Key == ConsoleKey.DownArrow)
                {
                    selection++;
                    if (selection > paymentOptions.Count)
                    {
                        selection = 0;
                    }
                }

                else if (keyInput.Key == ConsoleKey.Enter)
                {
                    if (selection == paymentOptions.Count)
                    {
                        Console.ForegroundColor= ConsoleColor.Red;
                        Console.WriteLine("Är du säker på att du vill avbryta köpet? Ja/Nej");
                        Console.ResetColor();
                        string input = Console.ReadLine();
                        if (input == "ja")
                        {
                            inMenu = false;
                            break;
                        }

                    }

                    else if (selection == 0)
                    {
                        pay.PayCard();
                        inMenu = false;
                        break;
                    }
                    else if (selection == 1)
                    {

                        pay.PayCash();
                        inMenu = false;
                        break;
                    }
                }


            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Tryck valfri tangent för att återgå till huvudmenyn.");
            Console.ResetColor ();
            Console.ReadKey();
        }
    }
}
