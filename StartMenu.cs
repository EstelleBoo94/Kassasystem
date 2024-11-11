using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Kassasystem.ReadingFromFile;

namespace Kassasystem
{
    public class StartMenu
    {
        //private Receipt _receipt;
        //private Pay _pay;
        //public StartMenu(/*Receipt receipt,*/ Pay pay)
        //{
        //    //_receipt = receipt;
        //    _pay = pay;
        //}

        public void ShowMenu()
        {
            ProductList productList = new ProductList(ReadProductListFromFile("../../../ListOfProducts.txt"));
            productList.InitiateProductList();

            List<string> menuOptions = new List<string>
            {
            "Ny kund", "Admin"
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
                Console.WriteLine("Avsluta");
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
                        NewCustomer customer = new NewCustomer();
                        customer.StartPurchase();
                    }
                    else if (selection == 1)
                    {
                        AdminMenu adminMenu = new AdminMenu();
                        adminMenu.ShowAdminMenu();
                    }
                }


            }

            Console.WriteLine("Kassan stängs ner... Tryck valfri tangent för att avsluta helt.");
            Console.ReadKey();

        }

    }
}
