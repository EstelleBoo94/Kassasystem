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
            float total = 0;

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

                float priceReset = 0;
                foreach (Product product in receiptList)
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
                        float campaignPriceTotal = campaignPrice * product.Amount;
                        float priceTotal = product.Price * product.Amount;

                        if (product.SellType == SellingType.ByKilo)
                        {
                            writer.WriteLine($"KAMPANJVARA {product.ProductName.ToString()} {product.Amount.ToString()} kg " +
                                $"OriginalPris {priceTotal.ToString()} kr Pris med rabatt {campaignPriceTotal.ToString()} kr");
                            priceReset = product.Price;
                            product.Price = campaignPrice;
                        }
                        else if (product.SellType == SellingType.ByItem)
                        {
                            writer.WriteLine($"KAMPANJVARA {product.ProductName.ToString()} {product.Amount.ToString()} st " +
                                $"OriginalPris {priceTotal.ToString()} kr Pris med rabatt {campaignPriceTotal.ToString()} kr");
                            priceReset = product.Price;
                            product.Price = campaignPrice;
                        }
                    }

                    else
                    {

                        float priceTotal = product.Price * product.Amount;
                        if (product.SellType == SellingType.ByKilo)
                        {
                            writer.WriteLine($"{product.ProductName.ToString()} {product.Amount.ToString()} kg {priceTotal.ToString()} kr");
                            priceReset = product.Price;
                        }
                        else if (product.SellType == SellingType.ByItem)
                        {
                            writer.WriteLine($"{product.ProductName.ToString()} {product.Amount.ToString()} st {priceTotal.ToString()} kr");
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
                writer.WriteLine($"SUMMA: {total} SEK\n");
                writer.WriteLine("#####################");
                writer.WriteLine("/////////////////////");
            }

        }
    }
}

        
            
        
            
        

