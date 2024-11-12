using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using static Kassasystem.ReadingFromFile;

namespace Kassasystem
{
    public class ProductListClass
    {
        public List<Product> ProductListProp { get; set; }

        public ProductListClass(List<Product> productList)
        {
            ProductListProp = productList;
        }

        public void InitiateProductList()
        {
            ReadProductListFromFile("../../../ListOfProducts.txt");
            if (ProductListProp.Count == 0)
            {
                ProductListProp.Add(new Product(101, "äpple", 34.95m, SellingType.ByKilo));
                ProductListProp.Add(new Product(102, "banan", 28.95m, SellingType.ByKilo));
                ProductListProp.Add(new Product(103, "mjölk 1l", 13.50m, SellingType.ByItem));
                ProductListProp.Add(new Product(104, "snabbkaffe", 78.95m, SellingType.ByItem));
                ProductListProp.Add(new Product(105, "nötfärs 1kg", 120.00m, SellingType.ByItem));
                ProductListProp.Add(new Product(106, "varmkorv", 37.95m, SellingType.ByItem));
                ProductListProp.Add(new Product(107, "bröd", 29.95m, SellingType.ByItem));
                ProductListProp.Add(new Product(108, "korvbröd", 20.95m, SellingType.ByItem));
                ProductListProp.Add(new Product(109, "kakor", 21.95m, SellingType.ByItem));
                ProductListProp.Add(new Product(110, "läsk", 15.95m, SellingType.ByItem));

                WriteProductListToFile("../../../ListOfProducts.txt");
            }
        }


        public void WriteProductListToFile(string filePath)
        {

            if (!File.Exists(filePath))
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                }
            }

            using (StreamWriter writer = new StreamWriter(filePath)) 
            {
                foreach (Product product in ProductListProp) 
                {
                    writer.WriteLine(product.ToString());
                }
            }
        }


        public int GetNextProductID()
        {
            if (ProductListProp.Count == 0)
            {
                return 100;
            }

            return ProductListProp.Max(p => p.ProductId) + 1;
        }

        public void AddNewProduct(Product newProduct)
        {
            ProductListProp.Add(newProduct);
        }

        public void RemoveProduct(int productIdCheck)
        {
            int index = ProductListProp.FindIndex(item => item.ProductId == productIdCheck);

            if (index != -1)
            {
                ProductListProp.RemoveAt(index);
            }
        }

        public void ReplaceProduct(int productIdCheck, Product updatedProduct)
        {
            int index = ProductListProp.FindIndex(item => item.ProductId == productIdCheck);

            if (index != -1)
            {
                ProductListProp[index] = updatedProduct;
            }
        }

        public void PrintProductList()
        {
            ProductListProp = ReadProductListFromFile("../../../ListOfProducts.txt");
            foreach (Product product in ProductListProp)
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


        public void FindProductToReceipt(int findID, short amount, Receipt receipt)
        {
            foreach (Product product in ProductListProp)
            {
                if (findID == product.ProductId)
                {
                    product.Amount = amount;
                    ReceiptListClass.AddToReceipt(product);
                }

            }
        }

        public void FindProductToPrint(int findID)
        {
            foreach (Product product in ProductListProp)
            {
                if (findID == product.ProductId)
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
        }

        public List<Product> ProductListToCampaign()
        {
            List<Product> productsToCampaign = new List<Product>();

            bool addMore = true;
            while (addMore == true)
            {
                int findProductId = InputValidator.GetValidProductID("Ange produktId på produkten som ska ingå i kampanjen:", ProductListProp);
                foreach (Product product in ProductListProp)
                {
                    if (product.ProductId == findProductId)
                    {
                        productsToCampaign.Add(product);
                        break;
                    }
                }

                string confirm = InputValidator.GetValidYesOrNo("Vill du lägga till fler produkter till kampanjen? Ja/Nej");
                if (confirm == "ja")
                {
                    continue;
                }
                else
                {
                    break;
                }
            }
            return productsToCampaign;
        }

    }
}
