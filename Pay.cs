using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassasystem
{
    class Pay
    {
        public float Total { get; set; }
        public void ConfirmPayment() 
        {
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
                        Console.WriteLine("\nBetalningen genomfördes.\n");
                        inMenu = false;
                        break;
                    }
                    else if (selection == 1)
                    {
                        PayCash();
                        inMenu = false;
                        break;
                    }
                }


            }

            Console.WriteLine("Tryck valfri tangent för att återgå till huvudmenyn.");
            Console.ReadKey();
        }

        public void PayCash()
        {
            Console.WriteLine($"Hur mycket betalar kunden? Summa att betala: {Total}");
            float payment = Convert.ToInt32(Console.ReadLine());

            float money = payment - Total;

            float Fivehundred = money / 500;
            float RestFivehundred = money % 500;
            float Hundred = RestFivehundred / 100;
            float RestHundred = RestFivehundred % 100;
            float Fifty = RestHundred / 50;
            float RestFifty = RestHundred % 50;
            float Twenty = RestFifty / 20;
            float RestTwenty = RestFifty % 20;
            float Ten = RestTwenty / 10;
            float RestTen = RestTwenty % 10;
            float one = RestTen / 1;
            Console.WriteLine($"Kunden ska få tillbaka {Fivehundred} femhundringar, {Hundred} hundralappar, {Fifty} femtiolappar, {Twenty} tjugolappar, {Ten} tiokronor och {one} enkronor.");

        }

    }
}
