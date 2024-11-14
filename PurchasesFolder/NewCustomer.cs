using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kassasystem.MenusFolder;
using Kassasystem.ProductFolder;
using Kassasystem.Resources;
using static Kassasystem.ReadingAndWritingFolder.ReadingFromFile;

namespace Kassasystem.PurchasesFolder
{

    public class NewCustomer
    {

        ProductListClass productList = new ProductListClass
            (ReadProductListFromFile("../../../ListOfProducts.txt"));

        public void StartPurchase()
        {
            Console.Clear();
            Designs.PrintHeader("NY KUND");

            Receipt receipt = new Receipt();

            string sellerID = InputValidator.GetNonEmptyStringSellerId
                ("Ange säljare eller säljarnummer:");

            Receipt.SellerId = sellerID;

            bool productExist = false;
            bool payValid = false;
            while (payValid == false && productExist == false)
            {
                Console.Clear();
                Designs.PrintHeader("NY KUND");
                productList.PrintProductList();

                receipt.PrintReceiptList();

                string input = InputValidator.GetValidItemForPurchase
                        ("\nAnge produkt-ID och antal (vikt i kilo om kilopris) " +
                        "med mellanslag emellan:" +
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
                short amount = Convert.ToInt16(whatProduct[1]);
                bool productInExistance = InputValidator.CheckIfProductExists
                    (findID, ReadProductListFromFile("../../../ListOfProducts.txt"));
                if (productInExistance == false)
                {
                    Console.WriteLine("Ange produktId från listan. " +
                        "Tryck valfri tangent för att fortsätta.");
                    Console.ReadKey();
                    continue;
                }
                else
                {
                    productList.FindProductToReceipt(findID, amount, receipt);
                }

            }




        }

    }
}
