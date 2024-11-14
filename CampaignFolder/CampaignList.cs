using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kassasystem.ProductFolder;
using Kassasystem.Resources;
using static Kassasystem.ReadingAndWritingFolder.ReadingFromFile;

namespace Kassasystem.CampaignFolder
{
    public class CampaignList
    {
        public static List<Campaign> CampaignListProp { get; set; } = new List<Campaign>();


        public void AddNewCampaign(Campaign newCampaign)
        {
            CampaignListProp.Add(newCampaign);
        }


        public bool PrintCampaignList()
        {
            bool emptyCampaignList = false;
            if (CampaignListProp.Count <= 0)
            {
                Console.WriteLine("Inga pågående kampanjer.");
                emptyCampaignList = true;
                return emptyCampaignList;
            }
            else
            {
                foreach (Campaign campaign in CampaignListProp)
                {
                    Console.WriteLine($"Kampanjnamn: {campaign.CampaignName} " +
                        $"Period {campaign.CampaignStartDate.Date} - {campaign.CampaignEndDate.Date}" +
                        $"\n     {campaign.CampaignDiscountPercent}% rabatt.");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(" Produkter som ingår i kampanjen:");
                    foreach (Product product in campaign.ProductsInCampaign)
                    {
                        Designs.PrintWithMargin($"{product}");
                    }
                }
                return emptyCampaignList;
            }
        }

        public void FindCampaignToPrint(string findName, List<Product> prodToCampaign)
        {
            foreach (Campaign campaign in CampaignListProp)
            {
                if (findName == campaign.CampaignName)
                {
                    Console.WriteLine($"Kampanjnamn: {campaign.CampaignName} " +
                        $"Period {campaign.CampaignStartDate.Date} - {campaign.CampaignEndDate.Date}" +
                        $"\n     {campaign.CampaignDiscountPercent}% rabatt.");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(" Produkter som ingår i kampanjen:");
                    foreach (Product product in campaign.ProductsInCampaign)
                    {
                        Designs.PrintWithMargin($"{product}");
                    }
                }

            }
        }

        public void RemoveCampaign(string campaignNameCheck)
        {
            int index = CampaignListProp.FindIndex(item => item.CampaignName == campaignNameCheck);

            if (index != -1)
            {
                CampaignListProp.RemoveAt(index);
            }
        }

        public static bool IsCampaignActive()
        {
            DateTime today = DateTime.Today;
            if (CampaignListProp.Count > 0)
            {
                foreach (Campaign campaign in CampaignListProp)
                {
                    if (today >= campaign.CampaignStartDate && today <= campaign.CampaignEndDate)
                    {
                        return true;
                    }
                    else { return false; }
                }
                return false;
            }
            else
            {
                return false;
            }
        }

        static List<Campaign> currentCampaigns = new List<Campaign>();
        public static List<Campaign> GetActiveCampaignList()
        {
            DateTime today = DateTime.Today;

            currentCampaigns.Clear();

            if (CampaignListProp.Count > 0)
            {
                foreach (Campaign campaign in CampaignListProp)
                {
                    if (today >= campaign.CampaignStartDate && today <= campaign.CampaignEndDate)
                    {
                        currentCampaigns.Add(campaign);
                    }
                }
            }
            return currentCampaigns;
        }

    }
}


