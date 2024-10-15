using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassasystem
{
    public class Receipt
    {
        private List<Product> receiptList = new List<Product>();

        public void AddToReceipt(Product product)
        {
            receiptList.Add(product);
        }

        public string GetReceiptList(Product productItem, float amountItem)
        {
            float amount;
            string getreceiptList = "KVITTO\n";
            foreach (Product product in receiptList)
            {
                amount = product.Price * amountItem;
                if (product.SellingType == SellingType.ByKilo)
                {
                    getreceiptList += $"{product.ProductName} {amountItem}kg {amount}kr\n";
                }
                else if (product.SellingType == SellingType.ByItem)
                {
                    getreceiptList += $"{product.ProductName} {amountItem}st {amount}kr\n";
                }

            }
            return getreceiptList;
        }
    }
}
