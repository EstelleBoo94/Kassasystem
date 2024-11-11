using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Kassasystem.ReadingFromFile;

namespace Kassasystem
{
    public class CampaignList
    {
        public static List<Campaign> CampaignListProp { get; set; } = new List<Campaign>();

        //public CampaignList(List<Campaign> campaignList)
        //{
        //    CampaignListProp = campaignList;
        //}

        public void AddNewCampaign(Campaign newCampaign)
        {
            CampaignListProp.Add(newCampaign);
        }

        //public void WriteCampaignListToFile(string filePath)
        //{

        //    if (!File.Exists(filePath))
        //    {
        //        using (StreamWriter writer = new StreamWriter(filePath))
        //        {
        //            writer.WriteLine("**LISTA ÖVER KAMPANJER**");
        //        }
        //    }

        //    using (StreamWriter writer = new StreamWriter(filePath))
        //    {
        //        foreach (Campaign campaign in CampaignListProp)
        //        {
        //            writer.Write(value: campaign.CampaignName.ToString());
        //            writer.Write("-");
        //            writer.Write(value: campaign.CampaignStartDate.ToString());
        //            writer.Write("-");
        //            writer.Write(value: campaign.CampaignEndDate.ToString());
        //            writer.Write("-");
        //            writer.Write(value: campaign.CampaignDiscountPercent.ToString());
        //            writer.Write("-");
        //            writer.WriteLine("Produkter som ingår i kampanjen;");
        //            foreach (Product product in campaign.ProductsInCampaign)
        //            {
        //                writer.WriteLine(product.ToString());
        //            }
        //            writer.WriteLine("##########################\n");
        //        }
        //    }
        //}

        //public static Campaign FromString(string reading)
        //{
        //    string[] parts = reading.Split("-");
        //    string[] prodParts = reading.Split(":");

        //    return new Campaign
        //            (
        //            parts[0],
        //            DateTime.Parse(parts[1]),
        //            DateTime.Parse(parts[2]),
        //            Convert.ToSingle(parts[3])
        //            );
        //}

        public void PrintCampaignList()
        {
            //CampaignListProp = ReadCampaignListFromFile("../../../ListOfCampaigns.txt");
            foreach (Campaign campaign in CampaignListProp)
            {
                Console.WriteLine($"{campaign.CampaignName} {campaign.CampaignStartDate} - {campaign.CampaignEndDate} {campaign.CampaignDiscountPercent}% rea.");
                Console.WriteLine("Produkter som ingår i kampanjen:");
                foreach (Product product in campaign.ProductsInCampaign)
                {
                    Console.WriteLine(product);
                }
            }
        }

        public void FindCampaignToPrint(string findName, List<Product> prodToCampaign)
        {
            foreach (Campaign campaign in CampaignListProp)
            {
                if (findName == campaign.CampaignName)
                {
                    Console.WriteLine($"{campaign.CampaignName} {campaign.CampaignStartDate} - {campaign.CampaignEndDate} {campaign.CampaignDiscountPercent}% rea.");
                    Console.WriteLine("Produkter som ingår i kampanjen:");
                    foreach (Product product in prodToCampaign)
                    {
                        Console.WriteLine(product);
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


