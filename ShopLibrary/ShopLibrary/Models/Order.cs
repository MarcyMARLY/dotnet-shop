using System;
using System.Collections.Generic;
using System.Linq;

namespace ShopLibrary.Models
{
    public class Order
    {
        public Transaction Transaction { get; set; }
        private List<Tuple<int, int>> products;

        public Order()
        {
            products = new List<Tuple<int, int>>();
        }
        
        public void AddProduct(Tuple<int, int> tuple)
        {
            products.Add(tuple);
        }
    
        public List<Tuple<int, int>> GetProducts()
        {
            return products;
        }

        public Transaction PrepareTransaction(List<Product> products)
        {
            var sum = products.Sum(x => x.price);
            var t = new Transaction(new Random(1000).Next(), sum);
            this.Transaction = t;
            return t;
        }
    }
}