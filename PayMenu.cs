using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassasystem
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
                Console.WriteLine("Välj alternativ med piltangenterna:");

                for (int i = 0; i < paymentOptions.Count; i++)
                {
                    if (i == selection)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                    }

                    Console.WriteLine(paymentOptions[i]);

                    Console.ResetColor();
                }

                if (selection == paymentOptions.Count)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
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
                        Console.WriteLine("Är du säker på att du vill avbryta köpet? Ja/Nej");
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

            Console.WriteLine("Tryck valfri tangent för att återgå till huvudmenyn.");
            Console.ReadKey();
        }
    }
}
