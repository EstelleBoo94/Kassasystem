using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassasystem
{
    public class Receipt
    {
        public string SellerId { get; set; }

        private List<Product> receiptList = new List<Product>();

        public void AddToReceipt(Product product)
        {
            receiptList.Add(product);
        }

        public void GetReceiptList()
        {
            Console.WriteLine($"\n**KVITTO**\nSäljare: {SellerId}\n");

            foreach (Product product in receiptList)
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

            float total = 0;
            foreach (Product product in receiptList)
            {
                total += (product.Price * product.Amount);
            }
            Console.WriteLine($"TOTAL {total}");
            Pay pay = new Pay();
            pay.Total = total;
        }
    }
}
