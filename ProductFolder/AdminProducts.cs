using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Xml.Linq;
using Kassasystem.Resources;
using static Kassasystem.ReadingAndWritingFolder.ReadingFromFile;

namespace Kassasystem.ProductFolder
{
    public class AdminProducts
    {
        ProductListClass productList = new ProductListClass
            (ReadProductListFromFile("../../../ListOfProducts.txt"));

        public void AdminAddNewProduct()
        {
            Console.Clear();
            Designs.PrintHeader("LÄGG TILL PRODUKT");

            string name = InputValidator.GetNonEmptyString("Ange namn på produkten:\n");
            decimal price = InputValidator.GetValidDecimal("\nAnge pris på produkten:\n");
            string sellingTypeInput = InputValidator.GetValidYesOrNo
                ("\nHar produkten kilopris? Ja/Nej\n");
            int productID = productList.GetNextProductID();
            if (sellingTypeInput.ToLower() == "ja")
            {
                Console.Clear();
                Designs.PrintHeader("LÄGG TILL PRODUKT");
                Product product = new Product(productID, name, price, SellingType.ByKilo);
                productList.AddNewProduct(product);
                productList.WriteProductListToFile("../../../ListOfProducts.txt");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nProdukt {product.ProductName} som kostar {product.Price:F2}" +
                    $" kr per kilo har lagts till med produktID {product.ProductId}.");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"\n Tryck valfri tangent för att fortsätta.");
                Console.ResetColor();
                Console.ReadKey();
            }
            else if (sellingTypeInput.ToLower() == "nej")
            {
                Console.Clear();
                Designs.PrintHeader("LÄGG TILL PRODUKT");
                Product product = new Product(productID, name, price, SellingType.ByItem);
                productList.AddNewProduct(product);
                productList.WriteProductListToFile("../../../ListOfProducts.txt");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nProdukt {product.ProductName} som kostar {product.Price:F2}" +
                    $" kr styck har lagts till med produktID {product.ProductId}.");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"\n Tryck valfri tangent för att fortsätta.");
                Console.ResetColor();
                Console.ReadKey();
            }

        }

        public void AdminEditProduct()
        {
            Console.Clear();
            Designs.PrintHeader("ÄNDRA PRODUKT");

            productList.PrintProductList();

            int productIdInput = InputValidator.GetValidProductID
                ("Ange produktId på produkten du vill ändra:", 
                ReadProductListFromFile("../../../ListOfProducts.txt"));

            Console.Clear();
            Designs.PrintHeader("ÄNDRA PRODUKT");
            productList.FindProductToPrint(productIdInput);

            string update = InputValidator.GetValidInputForEditProduct
                ("\nAnge uppdaterad information enligt mallen:\n[Produktnamn Pris Kilo/Styck]");

            string[] whatProduct = update.Split(" ");
            string newName = whatProduct[0];
            decimal newPrice = Convert.ToDecimal(whatProduct[1]);
            string newType = whatProduct[2];

            if (newType.ToLower() == "kilo")
            {
                Console.Clear();
                Designs.PrintHeader("ÄNDRA PRODUKT");
                Product product = new Product(productIdInput, newName, newPrice, SellingType.ByKilo);
                productList.ReplaceProduct(productIdInput, product);
                productList.WriteProductListToFile("../../../ListOfProducts.txt");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nProdukten är uppdaterad.");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"\n Tryck valfri tangent för att fortsätta.");
                Console.ResetColor();
                Console.ReadKey();
            }
            else if (newType.ToLower() == "styck")
            {
                Console.Clear();
                Designs.PrintHeader("ÄNDRA PRODUKT");
                Product product = new Product(productIdInput, newName, newPrice, SellingType.ByItem);
                productList.ReplaceProduct(productIdInput, product);
                productList.WriteProductListToFile("../../../ListOfProducts.txt");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nProdukten är uppdaterad.");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"\n Tryck valfri tangent för att fortsätta.");
                Console.ResetColor();
                Console.ReadKey();
            }

        }

        public void AdminRemoveProduct()
        {
            Console.Clear();
            Designs.PrintHeader("TA BORT PRODUKT");

            productList.PrintProductList();

            int productIdInput = InputValidator.GetValidProductID
                ("Ange produktId på produkten du vill ta bort:", 
                ReadProductListFromFile("../../../ListOfProducts.txt"));

            Console.Clear();
            Designs.PrintHeader("TA BORT PRODUKT");
            productList.FindProductToPrint(productIdInput);

            string deleteThis = InputValidator.GetValidYesOrNo
                ("\nVill du ta bort den här produkten helt? Ja/Nej\n");
            if (deleteThis.ToLower() == "ja")
            {
                Console.Clear();
                Designs.PrintHeader("TA BORT PRODUKT");
                productList.RemoveProduct(productIdInput);
                productList.WriteProductListToFile("../../../ListOfProducts.txt");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nProdukten är borttagen.");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"\n Tryck valfri tangent för att fortsätta.");
                Console.ResetColor();
                Console.ReadKey();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\nTryck valfri tangent för att återgå till menyn.");
                Console.ResetColor();
                Console.ReadKey();
            }
        }

    }

}
