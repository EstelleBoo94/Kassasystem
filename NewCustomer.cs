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
                new Product(001, "äpple", 34.95f, true),
                new Product(002, "banan", 28.95f, true),
                new Product(003, "mjölk 1l", 13.50f, false),
                new Product(004, "snabbkaffe", 78.95f, false),
                new Product(005, "nötfärs 1kg", 120.00f, false),
                new Product(006, "varmkorv", 37.95f, false),
                new Product(007, "bröd", 29.95f, false),
                new Product(008, "korvbröd", 20.95f, false),
                new Product(009, "kakor", 21.95f, false),
                new Product(010, "läsk", 15.95f, false),

            };

            Console.WriteLine("Ange säljarnummer (tex 123):");
            int sellerID = int.Parse(Console.ReadLine());

            foreach (Product product in productList)
            {
                string kilo;
                if (product.SoldByKilo == true)
                {
                    kilo = "kilopris";
                }
                else
                {
                    kilo = "styckpris";
                }
                Console.WriteLine($"{product.ProductId}, {product.ProductName}, {product.Price}, {kilo}");
            }

            bool pay = false;
            while (pay == false)
            {
                Console.WriteLine("Ange produkt-ID och antal (vikt i kilo om kilopris) med mellanslag emellan:\n*Ange Betala för att slutföra köpet*");
                string input = Console.ReadLine();

                string[] whatProduct = input.Split(" ");
                float findID = Convert.ToSingle(whatProduct[0]);
                float amount = Convert.ToSingle(whatProduct[1]);

                foreach (Product product in productList)
                {
                    if (findID == product.ProductId)
                    {
                        Console.WriteLine($"{product.ProductName} * {amount} {product.Price * amount} kr");
                    }
                }
            }


        }

    }
}
