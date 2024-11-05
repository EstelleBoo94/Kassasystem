using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Kassasystem.ReadingProductList;

namespace Kassasystem
{
    public class AdminMenu
    {
        ProductList productList = new ProductList(ReadProductListFromFile("../../../ListOfProducts.txt"));

        public void ShowAdminMenu()
        {
            AdminProducts adminProd = new AdminProducts();

            List<string> menuOptions = new List<string>
            {
            "Lägg till ny produkt", "Ta bort produkt", "Ändra produkt", "Visa produktlista", "Lägg till ny kampanj", "Ta bort kampanj", "Visa pågående kampanjer"
            };

            int selection = 0;
            bool inMenu = true;

            while (inMenu == true)
            {
                Console.Clear();
                Console.WriteLine("Välj alternativ med piltangenterna:");

                for (int i = 0; i < menuOptions.Count; i++)
                {
                    if (i == selection)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }

                    Console.WriteLine(menuOptions[i]);

                    Console.ResetColor();
                }

                if (selection == menuOptions.Count)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                Console.WriteLine("Tillbaka till huvudmeny");
                Console.ResetColor();


                var keyInput = Console.ReadKey(true);

                if (keyInput.Key == ConsoleKey.UpArrow)
                {
                    selection--;
                    if (selection < 0)
                    {
                        selection = menuOptions.Count;
                    }
                }

                else if (keyInput.Key == ConsoleKey.DownArrow)
                {
                    selection++;
                    if (selection > menuOptions.Count)
                    {
                        selection = 0;
                    }
                }


                else if (keyInput.Key == ConsoleKey.Enter)
                {
                    if (selection == menuOptions.Count)
                    {
                        inMenu = false;
                    }
                    else if (selection == 0)
                    {
                        adminProd.AdminAddNewProduct();
                    }
                    else if (selection == 1)
                    {
                        adminProd.AdminRemoveProduct();
                    }
                    else if (selection == 2)
                    {
                        adminProd.AdminEditProduct();
                    }
                    else if (selection == 3)
                    {
                        Console.Clear();
                        productList.PrintProductList();
                        Console.WriteLine("\nTryck valfri tangent för att återgå till menyn.");
                        Console.ReadKey();
                    }
                    else if (selection == 4)
                    {
                        Console.WriteLine("Här finns lägg till kampanj");
                    }
                    else if (selection == 5)
                    {
                        Console.WriteLine("Här finns ta bort kampanj");
                    }
                    else if (selection == 6)
                    {
                        Console.WriteLine("Här visas kampanjer");
                    }
                }


            }

            Console.WriteLine("Tryck valfri tangent för att återgå till startmenyn.");
            Console.ReadKey();
            StartMenu startMenu = new StartMenu();
            startMenu.ShowMenu();

        }
    }
}
