using System.Collections.Generic;

namespace ShoppingLibrary.Models
{
    public class Order
    {
        private List<Product> products;

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public List<Product> GetProducts()
        {
            return products;
        }
    }
}