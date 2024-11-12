using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Kassasystem.ReadingFromFile;

namespace Kassasystem
{
    public class AdminProducts
    {
        ProductListClass productList = new ProductListClass(ReadProductListFromFile("../../../ListOfProducts.txt"));

        public void AdminAddNewProduct()
        {
            Console.Clear();
            
            string name = InputValidator.GetNonEmptyString("Ange namn på produkten:");
            decimal price = InputValidator.GetValidDecimal("Ange pris på produkten:");
            string sellingTypeInput = InputValidator.GetValidYesOrNo("Har produkten kilopris? Ja/Nej");
            int productID = productList.GetNextProductID();
            if (sellingTypeInput.ToLower() == "ja")
            {
                Product product = new Product(productID, name, price, SellingType.ByKilo);
                productList.AddNewProduct(product);
                productList.WriteProductListToFile("../../../ListOfProducts.txt");
                Console.WriteLine($"Produkt {product.ProductName} som kostar {product.Price:F2} kr per kilo har lagts till med produktID {product.ProductId}." +
                    $"\n Tryck valfri tangent för att fortsätta.");
                Console.ReadKey();
            }
            else if (sellingTypeInput.ToLower() == "nej")
            {
                Product product = new Product(productID, name, price, SellingType.ByItem);
                productList.AddNewProduct(product);
                productList.WriteProductListToFile("../../../ListOfProducts.txt");
                Console.WriteLine($"Produkt {product.ProductName} som kostar {product.Price:F2} kr styck har lagts till med produktID {product.ProductId}." +
                    $"\n Tryck valfri tangent för att fortsätta.");
                Console.ReadKey();
            }

        }

        public void AdminEditProduct()
        {
            Console.Clear ();

            productList.PrintProductList();

            int productIdInput = InputValidator.GetValidProductID
                ("Ange produktId på produkten du vill ändra:", ReadProductListFromFile("../../../ListOfProducts.txt"));

            Console.Clear();
            productList.FindProductToPrint(productIdInput);

            string update = InputValidator.GetValidInputForEditProduct
                ("\nAnge uppdaterad information enligt mallen:\n[Produktnamn Pris Kilo/Styck]");

            string[] whatProduct = update.Split(" ");
            string newName = whatProduct[0];
            decimal newPrice = Convert.ToDecimal(whatProduct[1]);
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
            Console.Clear();

            productList.PrintProductList();

            int productIdInput = InputValidator.GetValidProductID
                ("Ange produktId på produkten du vill ta bort:", ReadProductListFromFile("../../../ListOfProducts.txt"));

            Console.Clear();
            productList.FindProductToPrint(productIdInput);

            string deleteThis = InputValidator.GetValidYesOrNo("Vill du ta bort den här produkten helt? Ja/Nej");
            if (deleteThis.ToLower() == "ja")
            {
                productList.RemoveProduct(productIdInput);
                productList.WriteProductListToFile("../../../ListOfProducts.txt");
                Console.WriteLine($"Produkten är borttagen." +
                    $"\n Tryck valfri tangent för att fortsätta.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Tryck valfri tangent för att återgå till menyn.");
                Console.ReadKey();
            }
        }

    }

}
