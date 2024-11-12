using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassasystem
{
    public class Receipt
    {
        public static string SellerId { get; set; }
        public static float Total { get; set; }

        public void PrintReceiptList()
        {
            float priceReset = 0;
            
            Console.WriteLine($"\n**KVITTO**\nSäljare: {SellerId}\n");

            foreach (Product product in ReceiptListClass.GetReceiptList())
            {
                float totalDiscountPercent = 0;
                List<Campaign> activeCampaign = CampaignList.GetActiveCampaignList();
                bool isActive = CampaignList.IsCampaignActive();
                

                if (isActive == true)
                {
                    foreach (Campaign campaign in activeCampaign)
                    {
                        foreach (Product prodInCamp in campaign.ProductsInCampaign)
                        {
                            if (product.ProductId == prodInCamp.ProductId)
                            {
                                totalDiscountPercent += campaign.CampaignDiscountPercent;
                            }
                        }
                    }

                    float campaignPrice = product.Price * (1 - totalDiscountPercent / 100);

                    if (product.SellType == SellingType.ByKilo)
                    {
                        Console.WriteLine($"KAMPANJVARA {product.ProductName} {product.Amount} kg " +
                            $"OriginalPris {product.Price * product.Amount} kr Pris med rabatt {campaignPrice * product.Amount} kr");
                        priceReset = product.Price;
                        product.Price = campaignPrice;
                    }
                    else if (product.SellType == SellingType.ByItem)
                    {
                        Console.WriteLine($"KAMPANJVARA {product.ProductName} {product.Amount} st " +
                            $"OriginalPris {product.Price * product.Amount} kr Pris med rabatt {campaignPrice * product.Amount} kr");
                        priceReset = product.Price;
                        product.Price = campaignPrice;
                    }
                }

                else
                {
                    if (product.SellType == SellingType.ByKilo)
                    {
                        Console.WriteLine($"{product.ProductName} {product.Amount} kg {product.Price * product.Amount} kr");
                        priceReset = product.Price;
                    }
                    else if (product.SellType == SellingType.ByItem)
                    {
                        Console.WriteLine($"{product.ProductName} {product.Amount} st {product.Price * product.Amount} kr");
                        priceReset = product.Price;
                    }
                }
            }

            Total = 0;
            foreach (Product product in ReceiptListClass.GetReceiptList())
            {
                Total = Total + (product.Price * product.Amount);
                product.Price = priceReset;
            }
            Console.WriteLine($"TOTAL {Total}");
            

        }


    }
}
