using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kassasystem.CampaignFolder;
using Kassasystem.ProductFolder;

namespace Kassasystem.PurchasesFolder
{
    public class Receipt
    {
        public static string SellerId { get; set; }
        public static decimal Total { get; set; }

        public void PrintReceiptList()
        {
            Total = 0;
            decimal priceReset = 0;
            List<Product> totalPriceOfProducts = new List<Product>();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n**KVITTO**\n");
            Console.ResetColor();
            Console.WriteLine($"Säljare: {SellerId}\n");

            foreach (Product product in ReceiptListClass.GetReceiptList())
            {
                decimal totalDiscountPercent = 0;
                List<Campaign> activeCampaign = CampaignList.GetActiveCampaignList();
                bool isActive = CampaignList.IsCampaignActive();

                priceReset = 0;
                priceReset = product.Price;

                if (isActive == true)
                {
                    bool isThisProductInCampaign = false;
                    foreach (Campaign campaign in activeCampaign)
                    {
                        foreach (Product prodInCamp in campaign.ProductsInCampaign)
                        {
                            if (product.ProductId == prodInCamp.ProductId)
                            {
                                totalDiscountPercent += campaign.CampaignDiscountPercent;
                                isThisProductInCampaign = true;
                            }
                        }
                    }

                    decimal campaignPrice = product.Price * (1 - totalDiscountPercent / 100);
                    if (isThisProductInCampaign == true)
                    {
                        if (product.SellType == SellingType.ByKilo)
                        {
                            Console.WriteLine($"KAMPANJVARA {product.ProductName} {product.Amount} kg " +
                                $"OriginalPris {product.Price * product.Amount:F2} kr/kg\n   Pris med rabatt {campaignPrice * product.Amount:F2} kr");

                            product.Price = campaignPrice;
                        }
                        else if (product.SellType == SellingType.ByItem)
                        {
                            Console.WriteLine($"KAMPANJVARA {product.ProductName} {product.Amount} st " +
                                $"OriginalPris {product.Price * product.Amount:F2} kr\n   Pris med rabatt {campaignPrice * product.Amount:F2} kr");

                            product.Price = campaignPrice;
                        }
                    }
                    else
                    {
                        if (product.SellType == SellingType.ByKilo)
                        {
                            Console.WriteLine($"{product.ProductName} {product.Amount} kg {product.Price * product.Amount:F2} kr");

                        }
                        else if (product.SellType == SellingType.ByItem)
                        {
                            Console.WriteLine($"{product.ProductName} {product.Amount} st {product.Price * product.Amount:F2} kr");

                        }
                    }
                }

                else
                {
                    if (product.SellType == SellingType.ByKilo)
                    {
                        Console.WriteLine($"{product.ProductName} {product.Amount} kg {product.Price * product.Amount:F2} kr");

                    }
                    else if (product.SellType == SellingType.ByItem)
                    {
                        Console.WriteLine($"{product.ProductName} {product.Amount} st {product.Price * product.Amount:F2} kr");

                    }
                }
                //totalPriceOfProducts.Add(product);
                Total = Total + product.Price * product.Amount;
                product.Price = priceReset;
            }


            //Total = 0;
            //foreach (Product product in totalPriceOfProducts)
            //{
            //    Total = Total + (product.Price * product.Amount);
            //}
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"TOTAL {Total:F2}");
            Console.ResetColor();


        }


    }
}
