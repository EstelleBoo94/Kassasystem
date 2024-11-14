using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kassasystem.ProductFolder;

namespace Kassasystem.PurchasesFolder
{
    public class ReceiptListClass
    {
        public static List<Product> ReceiptList { get; set; } = new List<Product>();


        public static List<Product> GetReceiptList()
        {
            return ReceiptList;
        }

        public static void AddToReceipt(Product product)
        {
            ReceiptList.Add(product);
        }

        public static void ClearReceiptList()
        {
            ReceiptList.Clear();
        }
    }
}
