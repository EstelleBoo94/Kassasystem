using Kassasystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Kassasystem.ReadingFromFile;

namespace Kassasystem
{
    public class WriteReceiptToTxt
    {

        public static void WriteReceiptToFile(List<Product> receiptList)
        {
            int receiptNumber = GetReceiptNumber();
            string filePath = $"../../../ReceiptFolder/receipt_{DateTime.Now:yyyy-MM-dd}.txt";
            decimal total = 0;

            string directoryPath = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            if (!File.Exists(filePath))
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine($"KVITTON FÖR {DateTime.Now:yyyy-MM-dd}\n");
                }
            }

            using (StreamWriter writer = new StreamWriter(filePath, append: true))
            {
                writer.WriteLine("#####################");
                writer.WriteLine($"**KVITTO**\n");
                writer.WriteLine($"Säljare: {Receipt.SellerId}");
                writer.WriteLine($"Datum: {DateTime.Now:yyyy-MM-dd}");
                writer.WriteLine($"Kvittonummer: {receiptNumber}");
                writer.WriteLine("---------------------\n");

                decimal priceReset = 0;
                foreach (Product product in receiptList)
                {
                    decimal totalDiscountPercent = 0;
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

                        decimal campaignPrice = product.Price * (1 - totalDiscountPercent / 100);
                        decimal campaignPriceTotal = campaignPrice * product.Amount;
                        decimal priceTotal = product.Price * product.Amount;

                        if (product.SellType == SellingType.ByKilo)
                        {
                            writer.WriteLine($"KAMPANJVARA {product.ProductName.ToString()} {product.Amount.ToString()} kg " +
                                $"OriginalPris {priceTotal.ToString("F2")} kr Pris med rabatt {campaignPriceTotal.ToString("F2")} kr");
                            priceReset = product.Price;
                            product.Price = campaignPrice;
                        }
                        else if (product.SellType == SellingType.ByItem)
                        {
                            writer.WriteLine($"KAMPANJVARA {product.ProductName.ToString()} {product.Amount.ToString()} st " +
                                $"OriginalPris {priceTotal.ToString("F2")} kr Pris med rabatt {campaignPriceTotal.ToString("F2")} kr");
                            priceReset = product.Price;
                            product.Price = campaignPrice;
                        }
                    }

                    else
                    {

                        decimal priceTotal = product.Price * product.Amount;
                        if (product.SellType == SellingType.ByKilo)
                        {
                            writer.WriteLine($"{product.ProductName.ToString()} {product.Amount.ToString()} kg {priceTotal.ToString("F2")} kr");
                            priceReset = product.Price;
                        }
                        else if (product.SellType == SellingType.ByItem)
                        {
                            writer.WriteLine($"{product.ProductName.ToString()} {product.Amount.ToString()} st {priceTotal.ToString("F2")} kr");
                            priceReset = product.Price;
                        }
                    }
                }
                total = 0;
                foreach (Product product in ReceiptListClass.GetReceiptList())
                {
                    total += (product.Price * product.Amount);
                    product.Price = priceReset;
                }
                writer.WriteLine("\n---------------------");
                writer.WriteLine($"SUMMA: {total:F2} SEK\n");
                writer.WriteLine("#####################");
                writer.WriteLine("/////////////////////");
            }

        }
    }
}

        
            
        
            
        

