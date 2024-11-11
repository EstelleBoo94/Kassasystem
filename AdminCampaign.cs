using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Kassasystem.ReadingFromFile;

namespace Kassasystem
{
    public class AdminCampaign
    {
        CampaignList campaignList = new CampaignList(/*ReadCampaignListFromFile("../../../ListOfCampaigns.txt"*/);
        ProductList productList = new ProductList(ReadProductListFromFile("../../../ListOfProducts.txt"));
        List<Product> productToCampaignList = new List<Product>();

        public void AdminAddNewCampaign()
        {
            Console.Clear();

            string name = InputValidator.GetNonEmptyString("Ange namn på kampanjen:");
            DateTime start = InputValidator.GetValidDate("Ange startdatum för kampanjen (yyyy-MM-dd):");
            DateTime end = InputValidator.GetValidDate("Ange slutdatum för kampanjen (yyyy-MM-dd):");
            float discount = InputValidator.GetValidFloat("Ange den procentuella rabatten (ange endast siffror):");

            productList.PrintProductList();
            productToCampaignList = productList.ProductListToCampaign();

            Campaign campaign = new Campaign(name, start, end, discount, productToCampaignList);
            campaignList.AddNewCampaign(campaign);
            //campaignList.WriteCampaignListToFile("../../../ListOfCampaigns.txt");
            Console.WriteLine($"Kampanjen är tillagd." +
                $"\n Tryck valfri tangent för att fortsätta.");
            Console.ReadKey();

        }

        public void AdminRemoveCampaign()
        {
            Console.Clear();

            campaignList.PrintCampaignList();

            string campaignNameInput = InputValidator.GetNonEmptyString
                ("Ange namnet på kampanjen du vill ta bort:");

            Console.Clear();
            campaignList.FindCampaignToPrint(campaignNameInput, productToCampaignList);

            string deleteThis = InputValidator.GetValidYesOrNo("Vill du ta bort den här kampanjen helt? Ja/Nej");
            if (deleteThis.ToLower() == "ja")
            {
                campaignList.RemoveCampaign(campaignNameInput);
                //productList.WriteProductListToFile("../../../ListOfProducts.txt");
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
            campaignList.PrintCampaignList();
        }

        

    }
}
