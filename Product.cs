using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassasystem
{
    public enum SellingType
    {
        ByItem,
        ByKilo
    }

    public class Product
    {
        int _productId;
        string _productName;
        float _price;
        SellingType _sellingType;


        public Product(int productId, string productName, float price, SellingType sellingType)
        {
            _productId = productId;
            _productName = productName;
            _price = price;
            _sellingType = sellingType;
        }

        public int ProductId { get { return _productId; } }
        public string ProductName { get { return _productName; } }
        public float Price { get { return _price; } }
        public SellingType SellingType { get { return _sellingType; } }
    }
}
