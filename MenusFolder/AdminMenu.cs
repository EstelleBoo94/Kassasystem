using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kassasystem.CampaignFolder;
using Kassasystem.ProductFolder;
using Kassasystem.Resources;
using static Kassasystem.ReadingAndWritingFolder.ReadingFromFile;

namespace Kassasystem.MenusFolder
{

    public class AdminMenu
    {
        ProductListClass productList = new ProductListClass
            (ReadProductListFromFile("../../../ListOfProducts.txt"));

        public void ShowAdminMenu()
        {
            AdminProducts adminProd = new AdminProducts();
            AdminCampaign adminCampaign = new AdminCampaign();

            List<string> menuOptions = new List<string>
            {
            "Lägg till ny produkt", "Ta bort produkt", "Ändra produkt", 
                "Visa produktlista", "Lägg till ny kampanj", "Ta bort kampanj", 
                "Visa pågående kampanjer"
            };

            int selection = 0;
            bool inMenu = true;

            while (inMenu == true)
            {
                Console.Clear();
                Designs.PrintHeader("ADMIN MENY");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Välj alternativ med piltangenterna:\n");
                Console.ResetColor();

                for (int i = 0; i < menuOptions.Count; i++)
                {
                    if (i == selection)
                    {
                        Console.BackgroundColor = ConsoleColor.Cyan;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }

                    Console.WriteLine(menuOptions[i]);

                    Console.ResetColor();
                }

                if (selection == menuOptions.Count)
                {
                    Console.BackgroundColor = ConsoleColor.Cyan;
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
                        Designs.PrintHeader("VISA PRODUKTLISTA");
                        productList.PrintProductList();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("\nTryck valfri tangent för att återgå till menyn.");
                        Console.ResetColor();
                        Console.ReadKey();
                    }
                    else if (selection == 4)
                    {
                        adminCampaign.AdminAddNewCampaign();
                    }
                    else if (selection == 5)
                    {
                        adminCampaign.AdminRemoveCampaign();
                    }
                    else if (selection == 6)
                    {
                        Console.Clear();
                        adminCampaign.PrintCampaignListToMenu();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("\nTryck valfri tangent för att återgå till menyn.");
                        Console.ResetColor();
                        Console.ReadKey();
                    }
                }


            }

            StartMenu startMenu = new StartMenu();
            startMenu.ShowMenu();

        }
    }
}
