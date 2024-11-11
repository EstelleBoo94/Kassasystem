using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassasystem
{
    public static class InputValidator
    {
        public static string GetNonEmptyString(string prompt)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                {
                    return input;
                }
                Console.Clear();
                Console.WriteLine("Ogiltig inmatning.");
            }
        }

        public static string GetValidYesOrNo(string prompt)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                string input = Console.ReadLine();
                if (input.ToLower() == "ja" || input.ToLower() == "nej")
                {
                    return input;
                }
                Console.Clear();
                Console.WriteLine("Ogiltig inmatning.");
            }
        }

        public static float GetValidFloat(string prompt)
        {
            float result;
            while (true)
            {
                Console.WriteLine(prompt);
                string input = Console.ReadLine();
                if (float.TryParse(input, out result))
                {
                    return result;
                }
                Console.Clear();
                Console.WriteLine("Ogiltig inmatning.");
            }
        }

        public static DateTime GetValidDate(string prompt) 
        { 
            while(true)
            {
                Console.WriteLine(prompt);
                string input = Console.ReadLine();
                if (DateTime.TryParse(input, out DateTime result))
                {
                    return result;
                }
                Console.Clear();
                Console.WriteLine("Ogiltig inmatning. Ange datum yyyy-MM-dd");
            }
        }

        public static int GetValidProductID(string prompt)
        {
            int result;
            while (true)
            {
                Console.WriteLine(prompt);
                string input = Console.ReadLine();

                if (input.Length == 3 && int.TryParse(input, out result))
                {
                    return result;
                }
                Console.WriteLine("Ogiltig inmatning, korrekt produktId har tre siffror.");
            }
        }

        public static string GetValidItemForPurchase(string prompt)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                string input = Console.ReadLine();

                if (input.ToLower() == "pay")
                {
                    return input;
                }
                else
                {
                    string[] parts = input.Split(' ');

                    if (parts.Length == 2 && parts[0].Length == 3
                        && int.TryParse(parts[0], out _) // _ discard operator, I only need to check this value, not save it
                        && float.TryParse(parts[1], out _))
                    {
                        return input;
                    }
                    Console.WriteLine("Ogiltig inmatning, ange tresiffrig produktId " +
                        "mellanslag och antal/vikt i kilo." +
                        "\nTex [123 3], eller [123 0,5], eller [Betala].");
                }
            }
        }

        public static string GetValidInputForEditProduct(string prompt)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                string input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input))
                {
                    string[] parts = input.ToLower().Split(' ');

                    if (parts.Length == 3
                    && float.TryParse(parts[1], out _)
                    && parts[2] == "kilo" || parts[2] == "styck")
                    {
                        return input;
                    }
                }
                Console.WriteLine("Ogiltig inmatning, ange namn " +
                    "mellanslag pris mellanslag och kilo eller styck." +
                    "\nTex [produktnamn 12,3 kilo], eller [produktnamn 12,3 styck].");

            }
        }

    }
}
