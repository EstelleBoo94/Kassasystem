using Kassasystem.CampaignFolder;
using Kassasystem.ProductFolder;
using Kassasystem.PurchasesFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Kassasystem.ReadingAndWritingFolder.ReadingFromFile;

namespace Kassasystem.ReadingAndWritingFolder
{
    public class WriteReceiptToTxt
    {

        public static void WriteReceiptToFile(List<Product> receiptList, 
            bool wasPaymentMethodCash, int payment, int moneyBack)
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
                writer.WriteLine("#################################################################");
                writer.WriteLine("\n.NET24-MATAFFÄREN\n");
                writer.WriteLine($"**KVITTO**\n");
                writer.WriteLine($"Säljare: {Receipt.SellerId}");
                writer.WriteLine($"Datum: {DateTime.Now:yyyy-MM-dd}");
                writer.WriteLine($"Kvittonummer: {receiptNumber}");
                writer.WriteLine("-----------------------------------------------------------------\n");


                foreach (Product product in receiptList)
                {
                    decimal totalDiscountPercent = 0;
                    List<Campaign> activeCampaign = CampaignList.GetActiveCampaignList();
                    bool isActive = CampaignList.IsCampaignActive();

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
                        decimal campaignPriceTotal = campaignPrice * product.Amount;
                        decimal priceTotal = product.Price * product.Amount;

                        if (isThisProductInCampaign == true)
                        {
                            if (product.SellType == SellingType.ByKilo)
                            {
                                writer.WriteLine($"KAMPANJVARA {product.ProductName.ToString()} " +
                                    $"{product.Amount.ToString()} kg " +
                                    $"OriginalPris {priceTotal.ToString("F2")} kr\n  " +
                                    $"Pris med {totalDiscountPercent}% rabatt " +
                                    $"{campaignPriceTotal.ToString("F2")} kr");
                            }
                            else if (product.SellType == SellingType.ByItem)
                            {
                                writer.WriteLine($"KAMPANJVARA {product.ProductName.ToString()} " +
                                    $"{product.Amount.ToString()} st " +
                                    $"OriginalPris {priceTotal.ToString("F2")} kr\n  " +
                                    $"Pris med {totalDiscountPercent}% rabatt " +
                                    $"{campaignPriceTotal.ToString("F2")} kr");
                            }
                        }
                        else
                        {
                            if (product.SellType == SellingType.ByKilo)
                            {
                                writer.WriteLine($"{product.ProductName.ToString()} " +
                                    $"{product.Amount.ToString()} kg {priceTotal.ToString("F2")} kr");
                            }
                            else if (product.SellType == SellingType.ByItem)
                            {
                                writer.WriteLine($"{product.ProductName.ToString()} " +
                                    $"{product.Amount.ToString()} st {priceTotal.ToString("F2")} kr");
                            }
                        }

                    }

                    else
                    {

                        decimal priceTotal = product.Price * product.Amount;
                        if (product.SellType == SellingType.ByKilo)
                        {
                            writer.WriteLine($"{product.ProductName.ToString()} " +
                                $"{product.Amount.ToString()} kg {priceTotal.ToString("F2")} kr");
                        }
                        else if (product.SellType == SellingType.ByItem)
                        {
                            writer.WriteLine($"{product.ProductName.ToString()} " +
                                $"{product.Amount.ToString()} st {priceTotal.ToString("F2")} kr");
                        }
                    }
                }
                writer.WriteLine("\n-----------------------------------------------------------------");
                writer.WriteLine($"SUMMA: {Receipt.Total:F2} SEK\n");

                if (wasPaymentMethodCash == false)
                {
                    writer.WriteLine("Betalat med kort\n");
                }
                else
                {
                    writer.WriteLine($"Betalat kontant {payment} SEK\n     Åter {moneyBack} SEK\n");
                }

                writer.WriteLine("VÄLKOMMEN ÅTER!");
                writer.WriteLine("\nVi tar inget ansvar för felaktiga varor.");
                writer.WriteLine("Klagomål kan du ta upp med någon annan.\n");
                writer.WriteLine("#################################################################");
                writer.WriteLine("/////////////////////////////////////////////////////////////////\n");
            }

        }
    }
}







