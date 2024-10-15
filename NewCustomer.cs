using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassasystem
{

    internal class NewCustomer
    {
        public void StartPurchase()
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

            Console.WriteLine("Ange säljarnummer (tex 123):");
            int sellerID = int.Parse(Console.ReadLine());



            Receipt receipt = new Receipt();
            bool pay = false;
            while (pay == false)
            {
                Console.Clear();

                foreach (Product product in productList)
                {
                    string type;
                    if (product.SellingType == SellingType.ByKilo)
                    {
                        type = "kilopris";
                    }
                    else
                    {
                        type = "styckpris";
                    }
                    Console.WriteLine($"{product.ProductId}, {product.ProductName}, {product.Price}, {type}");
                }



                Console.WriteLine("Ange produkt-ID och antal (vikt i kilo om kilopris) med mellanslag emellan:\n*Ange Betala för att slutföra köpet*");
                string input = Console.ReadLine().ToLower();

                if (input == "betala")
                {
                    pay = true;
                    break;
                }

                string[] whatProduct = input.Split(" ");
                float findID = Convert.ToSingle(whatProduct[0]);
                float amount = Convert.ToSingle(whatProduct[1]);

                foreach (Product product in productList)
                {
                    if (findID == product.ProductId && product.SellingType == SellingType.ByKilo)
                    {
                        //Console.WriteLine($"{product.ProductName} * {amount}kg {product.Price * amount} kr");
                        receipt.AddToReceipt(product);
                        Console.WriteLine($"{receipt.GetReceiptList(product, amount)};");

                    }
                    else if (findID == product.ProductId && product.SellingType == SellingType.ByItem)
                    {
                        //Console.WriteLine($"{product.ProductName} * {amount}st {product.Price * amount} kr");
                        receipt.AddToReceipt(product);
                        Console.WriteLine($"{receipt.GetReceiptList(product, amount)};");
                    }
                }
            }




        }

    }
}
