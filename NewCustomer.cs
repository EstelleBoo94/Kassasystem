using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassasystem
{

    internal class NewCustomer
    {

        ProductList productList;

        public NewCustomer(ProductList _productList)
        {
            productList = _productList;
        }

        public void StartPurchase()
        {

            Console.Clear();

            Receipt receipt = new Receipt();

           
            Console.WriteLine("Ange säljare eller säljarnummer:");
            string sellerID = Console.ReadLine();

            receipt.SellerId = sellerID;

            
            bool pay = false;
            while (pay == false)
            {
                Console.Clear();

                productList.PrintProductList();

                receipt.GetReceiptList();

                Console.WriteLine("\nAnge produkt-ID och antal (vikt i kilo om kilopris) med mellanslag emellan:\n*Ange Betala för att slutföra köpet*\n");
                string input = Console.ReadLine().ToLower();

                Pay pay1 = new Pay();

                if (input == "betala")
                {
                    pay1.ConfirmPayment();
                    pay = true;
                    break;
                }

                string[] whatProduct = input.Split(" ");
                int findID = Convert.ToInt32(whatProduct[0]);
                float amount = Convert.ToSingle(whatProduct[1]);

                productList.FindProductToReceipt(findID, amount, receipt);

            }




        }

    }
}
