using System;
using System.Collections.Generic;

namespace ShoppingLibrary.Models
{
    public class Order
    {
        private List<Tuple<int, int>> products;

        public void AddProduct(Tuple<int, int> tuple)
        {
            products.Add(tuple);
        }
    
        public List<Tuple<int, int>> GetProducts()
        {
            return products;
        }
    }
}