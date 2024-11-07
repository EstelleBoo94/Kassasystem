using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassasystem
{
    public class Receipt
    {
        //private Pay _pay;
        //public Receipt(Pay pay)
        //{
        //    _pay = pay;
        //}
        public static string SellerId { get; set; }
        public static float Total { get; set; }

        //private List<Product> receiptList = new List<Product>();


        //public List<Product> GetReceiptList()
        //{
        //    return receiptList;
        //}

        //public void AddToReceipt(Product product)
        //{
        //    receiptList.Add(product);
        //}


        public void PrintReceiptList()
        {
            Console.WriteLine($"\n**KVITTO**\nSäljare: {SellerId}\n");

            foreach (Product product in ReceiptListClass.GetReceiptList())
            {
                if (product.SellType == SellingType.ByKilo)
                {
                    Console.WriteLine($"{product.ProductName} {product.Amount} kg {product.Price * product.Amount} kr");
                }
                else if (product.SellType == SellingType.ByItem)
                {
                    Console.WriteLine($"{product.ProductName} {product.Amount} st {product.Price * product.Amount} kr");
                }
                
            }

            //Pay pay = new Pay();
            Total = 0;
            foreach (Product product in ReceiptListClass.GetReceiptList())
            {
                Total = Total + (product.Price * product.Amount);
            }
            Console.WriteLine($"TOTAL {Total}");
            
            //pay.Total = total;
        }

        //public void WriteReceiptToFile(int receiptNumber, List<Product> receiptList, float total)
        //{
        //    string filePath = $"../../../ReceiptFolder/receipt_{DateTime.Now:yyyy-MM-dd}.txt";

        //    if (!File.Exists(filePath))
        //    {
        //        using (StreamWriter writer = new StreamWriter(filePath)) 
        //        {
        //            writer.WriteLine($"KVITTON FÖR {DateTime.Now:yyyy-MM-dd}\n");
        //        }
        //    }

        //    using (StreamWriter writer = new StreamWriter(filePath, append: true))
        //    {
        //        writer.WriteLine("#####################");
        //        writer.WriteLine($"Säljare: {SellerId}");
        //        writer.WriteLine($"Datum: {DateTime.Now:yyyy-MM-dd}");
        //        writer.WriteLine($"Kvittonummer: {receiptNumber}");
        //        writer.WriteLine("---------------------");

        //        foreach (Product product in receiptList)
        //        {
        //            float priceTotal = product.Price * product.Amount;
        //            if (product.SellType == SellingType.ByKilo)
        //            {
        //                writer.WriteLine($"{product.ProductName.ToString()} {product.Amount.ToString()} kg {priceTotal.ToString()} kr");
        //            }
        //            else if (product.SellType == SellingType.ByItem)
        //            {
        //                writer.WriteLine($"{product.ProductName.ToString()} {product.Amount.ToString()} st {priceTotal.ToString()} kr");
        //            }
        //        }

        //        writer.WriteLine("---------------------");
        //        writer.WriteLine($"SUMMA: {total} KR\n");
        //        writer.WriteLine("#####################");
        //    }

        //}
    }
}
