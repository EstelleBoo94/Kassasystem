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
        ProductListClass productList = new ProductListClass(ReadProductListFromFile("../../../ListOfProducts.txt"));
        List<Product> productToCampaignList = new List<Product>();

        public void AdminAddNewCampaign()
        {
            Console.Clear();
            Designs.PrintHeader("LÄGG TILL KAMPANJ");

            string name = InputValidator.GetNonEmptyString("Ange namn på kampanjen:");
            DateTime start = InputValidator.GetValidDate("Ange startdatum för kampanjen (yyyy-MM-dd):");
            DateTime end = InputValidator.GetValidDate("Ange slutdatum för kampanjen (yyyy-MM-dd):");
            while (end <= start)
            {
                Console.Clear();
                Console.WriteLine("Slutdatum måste vara minst en dag efter startdatum. Ange start- och slutdatum igen.");
                Console.ReadKey();
                start = InputValidator.GetValidDate("Ange startdatum för kampanjen (yyyy-MM-dd):");
                end = InputValidator.GetValidDate("Ange slutdatum för kampanjen (yyyy-MM-dd):");
            }
            short discount = InputValidator.GetValidShort("Ange den procentuella rabatten (ange endast siffror):");
            while (discount >= 100)
            {
                Console.Clear();
                Console.WriteLine("Rabatten måste vara mindre än 100.");
                Console.ReadKey();
                discount = InputValidator.GetValidShort("Ange den procentuella rabatten (ange endast siffror):");
            }

            productList.PrintProductList();
            productToCampaignList = productList.ProductListToCampaign();

            Campaign campaign = new Campaign(name, start, end, discount, productToCampaignList);
            campaignList.AddNewCampaign(campaign);
            Console.WriteLine($"Kampanjen är tillagd." +
                $"\n Tryck valfri tangent för att fortsätta.");
            Console.ReadKey();

        }

        public void AdminRemoveCampaign()
        {
            Console.Clear();
            Designs.PrintHeader("TA BORT KAMPANJ");

            campaignList.PrintCampaignList();

            string campaignNameInput = InputValidator.GetNonEmptyString
                ("Ange namnet på kampanjen du vill ta bort:");

            Console.Clear();
            campaignList.FindCampaignToPrint(campaignNameInput, productToCampaignList);

            string deleteThis = InputValidator.GetValidYesOrNo("Vill du ta bort den här kampanjen helt? Ja/Nej");
            if (deleteThis.ToLower() == "ja")
            {
                campaignList.RemoveCampaign(campaignNameInput);
                Console.WriteLine($"Kampanjen är borttagen." +
                    $"\n Tryck valfri tangent för att fortsätta.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Tryck valfri tangent för att återgå till menyn.");
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
