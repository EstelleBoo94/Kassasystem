using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassasystem
{
    public class WriteReceiptToTxt
    {
        //public static string SellerId { get; set; }

        public static void WriteReceiptToFile(List<Product> receiptList, float total)
        {
            ReadReceiptFile readReceiptFile = new ReadReceiptFile();
            int receiptNumber = readReceiptFile.GetReceiptNumber();
            string filePath = $"../../../ReceiptFolder/receipt_{DateTime.Now:yyyy-MM-dd}.txt";

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

                foreach (Product product in receiptList)
                {
                    float priceTotal = product.Price * product.Amount;
                    if (product.SellType == SellingType.ByKilo)
                    {
                        writer.WriteLine($"{product.ProductName.ToString()} {product.Amount.ToString()} kg {priceTotal.ToString()} kr");
                    }
                    else if (product.SellType == SellingType.ByItem)
                    {
                        writer.WriteLine($"{product.ProductName.ToString()} {product.Amount.ToString()} st {priceTotal.ToString()} kr");
                    }
                }

                writer.WriteLine("\n---------------------");
                writer.WriteLine($"SUMMA: {Receipt.Total} SEK\n");
                writer.WriteLine("#####################");
                writer.WriteLine("/////////////////////");
            }

        }
    }
}
