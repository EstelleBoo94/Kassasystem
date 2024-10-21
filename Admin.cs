using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassasystem
{
    public class Admin
    {

        ProductList productList;

        public void MoveProductList(ProductList productListIn)
        {
            productList = productListIn;
        }



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
            }
            else if (sellingTypeInput.ToLower() == "nej")
            {
                Product product = new Product(productID, name, price, SellingType.ByItem);
                productList.AddNewProduct(product);
            }

        }

    }
}
