using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kassasystem.ProductFolder;
using Kassasystem.PurchasesFolder;

namespace Kassasystem.Resources
{
    public static class InputValidator
    {
        public static string GetNonEmptyString(string prompt)
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(prompt);
                Console.ResetColor();
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                {
                    return input;
                }
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ogiltig inmatning.");
                Console.ResetColor();
            }
        }

        public static string GetValidYesOrNo(string prompt)
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(prompt);
                Console.ResetColor();
                string input = Console.ReadLine();
                if (input.ToLower() == "ja" || input.ToLower() == "nej")
                {
                    return input;
                }
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ogiltig inmatning.");
                Console.ResetColor();
            }
        }

        public static short GetValidShort(string prompt)
        {
            short result;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(prompt);
                Console.ResetColor();
                string input = Console.ReadLine();
                if (short.TryParse(input, out result))
                {
                    if (result < 0)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ogiltig inmatning. Ange en siffra över 0.");
                        Console.ResetColor();
                        continue;
                    }
                    return result;
                }
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ogiltig inmatning.");
                Console.ResetColor();
            }
        }

        public static decimal GetValidDecimal(string prompt)
        {
            decimal result;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(prompt);
                Console.ResetColor();
                string input = Console.ReadLine();
                if (decimal.TryParse(input, out result))
                {
                    if (result < 0)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ogiltig inmatning. Ange en siffra över 0.");
                        Console.ResetColor();
                        continue;
                    }
                    return result;
                }
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ogiltig inmatning.");
                Console.ResetColor();
            }
        }

        public static int GetValidInt(string prompt)
        {
            int result;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(prompt);
                Console.ResetColor();
                string input = Console.ReadLine();
                if (int.TryParse(input, out result))
                {
                    if (result < 0)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ogiltig inmatning. Ange en siffra över 0.");
                        Console.ResetColor();
                        continue;
                    }
                    return result;
                }
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ogiltig inmatning.");
                Console.ResetColor();
            }
        }

        public static DateTime GetValidDate(string prompt)
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(prompt);
                Console.ResetColor();
                string input = Console.ReadLine();
                if (DateTime.TryParse(input, out DateTime result))
                {
                    if (result < DateTime.Today)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ogiltig inmatning. Kan ej ange tidigare än dagens datum.");
                        Console.ResetColor();
                        continue;
                    }
                    else
                    {
                        return result;
                    }
                }
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ogiltig inmatning. Ange datum yyyy-MM-dd. " +
                    "Kan ej ange tidigare än dagens datum.");
                Console.ResetColor();
            }

        }

        public static int GetValidProductID(string prompt, List<Product> productList)
        {
            int result = 0;
            bool doesProductExist = false;
            while (doesProductExist == false)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(prompt);
                Console.ResetColor();
                string input = Console.ReadLine();

                if (input.Length == 3 && int.TryParse(input, out result))
                {
                    doesProductExist = false;
                    foreach (Product product in productList)
                    {
                        if (result == product.ProductId)
                        {
                            doesProductExist = true;
                            break;
                        }
                    }
                    if (doesProductExist == false)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ogiltig inmatning, produkten måste finnas i listan.");
                        Console.ResetColor();
                    }

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ogiltig inmatning, korrekt produktId har tre siffror.");
                    Console.ResetColor();
                }
            }
            return result;
        }

        public static bool CheckIfProductExists(int idCheck, List<Product> productList)
        {
            bool doesItExist = false;
            foreach (Product product in productList)
            {
                if (idCheck == product.ProductId)
                {
                    doesItExist = true;
                }
            }
            if (doesItExist == false)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public static string GetValidItemForPurchase(string prompt)
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(prompt);
                Console.ResetColor();
                string input = Console.ReadLine();

                if (input.ToLower() == "pay")
                {
                    if (ReceiptListClass.ReceiptList.Count == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Minst en produkt måste köpas.");
                        Console.ResetColor();
                    }
                    else
                    {
                        return input;
                    }

                }
                else
                {
                    string[] parts = input.Split(' ');

                    if (parts.Length == 2 && parts[0].Length == 3
                        && int.TryParse(parts[0], out _) // _ discard operator, I only need to check this value, not save it
                        && short.TryParse(parts[1], out _)
                        && short.Parse(parts[1]) > 0)
                    {
                        return input;
                    }
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ogiltig inmatning, ange tresiffrig produktId " +
                        "mellanslag och antal/vikt i kilo, över 0." +
                        "\nTex [123 3], eller [123 0,5], eller [Pay].");
                    Console.ResetColor();
                }
            }
        }


        public static string GetValidInputForEditProduct(string prompt)
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(prompt);
                Console.ResetColor();
                string input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input))
                {
                    string[] parts = input.ToLower().Split(' ');

                    if (parts.Length == 3
                    && decimal.TryParse(parts[1], out _)
                    && decimal.Parse(parts[1]) > 0
                    && parts[2] == "kilo" || parts[2] == "styck")
                    {
                        return input;
                    }
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ogiltig inmatning, ange namn " +
                    "mellanslag pris (över 0) mellanslag och kilo eller styck." +
                    "\nTex [produktnamn 12,3 kilo], eller [produktnamn 12,3 styck].");
                Console.ResetColor();

            }
        }

    }
}
