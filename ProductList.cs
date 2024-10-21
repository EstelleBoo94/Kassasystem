using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassasystem
{
    public class ProductList
    {

        List<Product> productList = new List<Product>
        {
          new Product(101, "äpple", 34.95f, SellingType.ByKilo),
          new Product(102, "banan", 28.95f, SellingType.ByKilo),
          new Product(103, "mjölk 1l", 13.50f, SellingType.ByItem),
          new Product(104, "snabbkaffe", 78.95f, SellingType.ByItem),
          new Product(105, "nötfärs 1kg", 120.00f, SellingType.ByItem),
          new Product(106, "varmkorv", 37.95f, SellingType.ByItem),
          new Product(107, "bröd", 29.95f, SellingType.ByItem),
          new Product(108, "korvbröd", 20.95f, SellingType.ByItem),
          new Product(109, "kakor", 21.95f, SellingType.ByItem),
          new Product(110, "läsk", 15.95f, SellingType.ByItem),
        };


        public int GetNextProductID()
        {
            if (productList.Count == 0)
            {
                return 100;
            }

            return productList.Max(p => p.ProductId) + 1;
        }

        public void AddNewProduct(Product newProduct)
        {
            productList.Add(newProduct);
        }

        public void PrintProductList()
        {
            foreach (Product product in productList)
            {
                string type;
                if (product.SellType == SellingType.ByKilo)
                {
                    type = "kilopris";
                }
                else
                {
                    type = "styckpris";
                }
                Console.WriteLine($"{product.ProductId}, {product.ProductName}, {product.Price}, {type}");
            }
        }

        Receipt receipt;

        public void MoveReceipt(Receipt receiptIn)
        {
            receipt = receiptIn;
        }

        public void FindProduct(int findID, float amount)
        {
            foreach (Product product in productList)
            {
                if (findID == product.ProductId)
                {
                    product.Amount = amount;
                    receipt.AddToReceipt(product);
                }

            }
        }

    }
}
