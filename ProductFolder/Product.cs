using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassasystem.ProductFolder
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
        public decimal Price { get; set; }
        public SellingType SellType { get; set; }
        public short Amount { get; set; }


        public Product(int productId, string productName, decimal price, SellingType sellingType)
        {
            ProductId = productId;
            ProductName = productName;
            Price = price;
            SellType = sellingType;
        }

        public override string ToString()
        {
            if (SellType == SellingType.ByItem)
            {
                return $"{ProductId}: {ProductName}: {Price}: styckpris";
            }
            else
            {
                return $"{ProductId}: {ProductName}: {Price}: kilopris";
            }

        }


        public static Product FromString(string reading)
        {
            string[] parts = reading.Split(':');
            if (parts[3].Trim() == "styckpris")
            {
                return new Product
                    (
                    Convert.ToInt32(parts[0]),
                    parts[1].Trim(),
                    Convert.ToDecimal(parts[2]),
                    SellingType.ByItem
                    );
            }
            else
            {
                return new Product
                (
                    Convert.ToInt32(parts[0]),
                    parts[1].Trim(),
                    Convert.ToDecimal(parts[2]),
                    SellingType.ByKilo

                );
            }
        }

    }



}
