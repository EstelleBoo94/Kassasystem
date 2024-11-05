using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassasystem
{
    public static class ReadingProductList
    {
        public static List<Product> ReadProductListFromFile(string filePath)
        {
            List<Product> readProductList = new List<Product>();
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        readProductList.Add(Product.FromString(line));
                    }
                }
            }
            //productList = readProductList;
            return readProductList;
        }
    }
}
