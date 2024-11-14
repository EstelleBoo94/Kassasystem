using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kassasystem.ProductFolder;
using Kassasystem.Resources;
using static Kassasystem.ReadingAndWritingFolder.ReadingFromFile;

namespace Kassasystem.CampaignFolder
{
    public class AdminCampaign
    {
        CampaignList campaignList = new CampaignList();
        ProductListClass productList = new ProductListClass
            (ReadProductListFromFile("../../../ListOfProducts.txt"));
        List<Product> productToCampaignList = new List<Product>();

        public void AdminAddNewCampaign()
        {
            Console.Clear();
            Designs.PrintHeader("LÄGG TILL KAMPANJ");

            string name = InputValidator.GetNonEmptyStringAddCampaign("Ange namn på kampanjen:\n");
            DateTime start = InputValidator.GetValidDate
                ("\nAnge startdatum för kampanjen (yyyy-MM-dd):\n");
            DateTime end = InputValidator.GetValidDate
                ("\nAnge slutdatum för kampanjen (yyyy-MM-dd):\n");
            while (end <= start)
            {
                Console.Clear();
                Console.WriteLine("\nSlutdatum måste vara minst en dag efter startdatum. " +
                    "Ange start- och slutdatum igen.\n");
                Console.ReadKey();
                start = InputValidator.GetValidDate("\nAnge startdatum för kampanjen (yyyy-MM-dd):\n");
                end = InputValidator.GetValidDate("\nAnge slutdatum för kampanjen (yyyy-MM-dd):\n");
            }
            short discount = InputValidator.GetValidShort
                ("\nAnge den procentuella rabatten (ange endast siffror):\n");
            while (discount >= 100)
            {
                Console.Clear();
                Console.WriteLine("\nRabatten måste vara mindre än 100.\n");
                Console.ReadKey();
                discount = InputValidator.GetValidShort
                    ("\nAnge den procentuella rabatten (ange endast siffror):\n");
            }

            Console.Clear();
            Designs.PrintHeader("LÄGG TILL KAMPANJ");

            productList.PrintProductList();
            productToCampaignList = productList.ProductListToCampaign();

            Console.Clear();
            Designs.PrintHeader("LÄGG TILL KAMPANJ");
            Campaign campaign = new Campaign(name, start, end, discount, productToCampaignList);
            campaignList.AddNewCampaign(campaign);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Kampanjen är tillagd.");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\n Tryck valfri tangent för att fortsätta.");
            Console.ResetColor();
            Console.ReadKey();

        }

        public void AdminRemoveCampaign()
        {
            Console.Clear();
            Designs.PrintHeader("TA BORT KAMPANJ");

            bool emptyCampaignList = campaignList.PrintCampaignList();

            while (emptyCampaignList == false)
            {
                string campaignNameInput = InputValidator.GetNonEmptyStringRemoveCampaign
                    ("Ange namnet på kampanjen du vill ta bort:\n");

                Console.Clear();
                Designs.PrintHeader("TA BORT KAMPANJ");
                campaignList.FindCampaignToPrint(campaignNameInput, productToCampaignList);

                string deleteThis = InputValidator.GetValidYesOrNoRemoveCampaign
                    ("\nVill du ta bort den här kampanjen helt? Ja/Nej\n");
                if (deleteThis.ToLower() == "ja")
                {
                    campaignList.RemoveCampaign(campaignNameInput);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Kampanjen är borttagen.");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"\nTryck valfri tangent för att fortsätta.");
                    Console.ResetColor();
                    Console.ReadKey();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\nTryck valfri tangent för att återgå till menyn.");
                    Console.ResetColor();
                    Console.ReadKey();
                }
                break;
            }
            if (emptyCampaignList == true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\nTryck valfri tangent för att återgå till menyn.");
                Console.ResetColor();
                Console.ReadKey();
            }
        }

        public void PrintCampaignListToMenu()
        {
            Designs.PrintHeader("PÅGÅENDE KAMPANJER");
            campaignList.PrintCampaignList();
        }



    }
}
