using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Kassasystem.ReadingProductList;

namespace Kassasystem
{
    public class AdminProducts
    {
        //List<Product> productList = ReadProductListFromFile("../../../ListOfProducts.txt");
        //ProductList productList;

        //public void ReferToProductList(ProductList productListIn)
        //{
        //    productList = productListIn;
        //}
        ProductList productList = new ProductList(ReadProductListFromFile("../../../ListOfProducts.txt"));

        public void AdminAddNewProduct()
        {
            Console.WriteLine("Ange namn på produkten:");
            string name = Console.ReadLine();
            Console.WriteLine("Ange pris på produkten:");
            float price = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine("Har produkten kilopris? Ja/Nej");
            string sellingTypeInput = Console.ReadLine();
            int productID = productList.GetNextProductID();
            if (sellingTypeInput.ToLower() == "ja")
            {
                Product product = new Product(productID, name, price, SellingType.ByKilo);
                productList.AddNewProduct(product);
                productList.WriteProductListToFile("../../../ListOfProducts.txt");
                Console.WriteLine($"Produkt {product.ProductName} som kostar {product.Price} kr per kilo har lagts till med produktID {product.ProductId}." +
                    $"\n Tryck valfri tangent för att fortsätta.");
                Console.ReadKey();
            }
            else if (sellingTypeInput.ToLower() == "nej")
            {
                Product product = new Product(productID, name, price, SellingType.ByItem);
                productList.AddNewProduct(product);
                productList.WriteProductListToFile("../../../ListOfProducts.txt");
                Console.WriteLine($"Produkt {product.ProductName} som kostar {product.Price} kr styck har lagts till med produktID {product.ProductId}." +
                    $"\n Tryck valfri tangent för att fortsätta.");
                Console.ReadKey();
            }

        }

        public void AdminChangeProduct()
        {
            productList.PrintProductList();

            Console.WriteLine("Ange produktId på produkten du vill ändra:");
            int productIdInput = Convert.ToInt32(Console.ReadLine());

            productList.FindProductToPrint(productIdInput);

            Console.WriteLine("\nAnge uppdaterad information enligt mallen:\n[Produktnamn Pris Kilo/Styck]");
            string update = Console.ReadLine();

            string[] whatProduct = update.Split(" ");
            string newName = whatProduct[0];
            float newPrice = Convert.ToSingle(whatProduct[1]);
            string newType = whatProduct[2];

            if (newType.ToLower() == "kilo")
            {
                Product product = new Product(productIdInput, newName, newPrice, SellingType.ByKilo);
                productList.ReplaceProduct(productIdInput, product);
                productList.WriteProductListToFile("../../../ListOfProducts.txt");
                Console.WriteLine($"Produkten är uppdaterad." +
                    $"\n Tryck valfri tangent för att fortsätta.");
                Console.ReadKey();
            }
            else if (newType.ToLower() == "styck")
            {
                Product product = new Product(productIdInput, newName, newPrice, SellingType.ByItem);
                productList.ReplaceProduct(productIdInput, product);
                productList.WriteProductListToFile("../../../ListOfProducts.txt");
                Console.WriteLine($"Produkten är uppdaterad." +
                    $"\n Tryck valfri tangent för att fortsätta.");
                Console.ReadKey();
            }

        }

        public void AdminRemoveProduct()
        {

        }


    }
}
