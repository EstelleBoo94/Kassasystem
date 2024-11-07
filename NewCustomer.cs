using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Kassasystem.ReadingProductList;

namespace Kassasystem
{

    public class NewCustomer
    {
        //private Receipt _receipt;
        //private Pay _pay;
        //public NewCustomer(/*Receipt receipt*/ Pay pay)
        //{
        //    //_receipt = receipt;
        //    _pay = pay;
        //}
        
        ProductList productList = new ProductList
            (ReadProductListFromFile("../../../ListOfProducts.txt"));

        public void StartPurchase()
        {

            Console.Clear();

            Receipt receipt = new Receipt();


            string sellerID = InputValidator.GetNonEmptyString
                ("Ange säljare eller säljarnummer:");

            Receipt.SellerId = sellerID;


            bool payValid = false;
            while (payValid == false)
            {
                Console.Clear();

                productList.PrintProductList();

                receipt.PrintReceiptList();

                string input = InputValidator.GetValidItemForPurchase
                    ("\nAnge produkt-ID och antal (vikt i kilo om kilopris) med mellanslag emellan:" +
                    "\n*Ange Pay för att slutföra köpet*\n");

                PayMenu payMenu = new PayMenu();

                if (input.ToLower() == "pay")
                {
                    payMenu.ShowPayMenu();
                    payValid = true;
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
