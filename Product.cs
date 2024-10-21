using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassasystem
{
    public enum SellingType
    {
        ByItem,
        ByKilo
    }

    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public float Price { get; set; }
        public SellingType SellType { get; set; }
        public float Amount { get; set; }


        public Product(int productId, string productName, float price, SellingType sellingType)
        {
            ProductId = productId;
            ProductName = productName;
            Price = price;
            SellType = sellingType;
        }



    }



}
