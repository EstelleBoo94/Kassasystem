using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassasystem
{
    public class AdminMenu
    {

        Admin admin;

        public void MoveAdmin(Admin adminIn)
        {
            admin = adminIn;
        }

        public void ShowAdminMenu()
        {

            List<string> menuOptions = new List<string>
            {
            "Lägg till ny produkt", "Ta bort produkt", "Lägg till ny kampanj", "Ta bort kampanj"
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
                        admin.AdminAddNewProduct();
                    }
                    else if (selection == 1)
                    {
                        Console.WriteLine("Här finns ta bort produkt");
                    }
                    else if (selection == 2)
                    {
                        Console.WriteLine("Här finns lägg till kampanj");
                    }
                    else if (selection == 3)
                    {
                        Console.WriteLine("Här finns ta bort kampanj");
                    }
                }


            }

            Console.WriteLine("Kassan stängs ner... Tryck valfri tangent för att avsluta helt.");
            Console.ReadKey();

        }
    }
}
