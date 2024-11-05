using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Kassasystem.ReadingProductList;

namespace Kassasystem
{

    internal class NewCustomer
    {

        ProductList productList = new ProductList
            (ReadProductListFromFile("../../../ListOfProducts.txt"));

        public void StartPurchase()
        {

            Console.Clear();

            Receipt receipt = new Receipt();


            string sellerID = InputValidator.GetNonEmptyString
                ("Ange säljare eller säljarnummer:");

            receipt.SellerId = sellerID;

            
            bool pay = false;
            while (pay == false)
            {
                Console.Clear();

                productList.PrintProductList();

                receipt.GetReceiptList();

                string input = InputValidator.GetValidItemForPurchase
                    ("\nAnge produkt-ID och antal (vikt i kilo om kilopris) med mellanslag emellan:" +
                    "\n*Ange Betala för att slutföra köpet*\n");

                Pay pay1 = new Pay();

                if (input.ToLower() == "betala")
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
