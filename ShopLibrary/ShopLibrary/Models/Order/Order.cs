using System;
using System.Collections.Generic;
using System.Linq;

namespace ShopLibrary.Models
{
    public class Order
    {
        private Transaction _transaction { get; set; }
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
            var sum = products.Sum(x => x.Price);
            var t = new Transaction() {Charge = sum, Id = new Random(100).Next(), TransactionDateTime = DateTime.Now};
            this._transaction = t;
            return t;
        }
    }
}