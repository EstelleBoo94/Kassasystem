﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassasystem
{
    internal class Product
    {
        int _productId;
        string _productName;
        float _price;
        bool _soldByKilo;


        public Product(int productId, string productName, float price, bool soldByKilo)
        {
            _productId = productId;
            _productName = productName;
            _price = price;
            _soldByKilo = soldByKilo;
        }

        public int ProductId { get { return _productId; } }
        public string ProductName { get { return _productName; } }
        public float Price { get { return _price; } }
        public bool SoldByKilo { get { return _soldByKilo; } }
    }
}
