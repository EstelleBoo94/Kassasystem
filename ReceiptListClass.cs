using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassasystem
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
    }
}
