using System.Collections.Generic;
using System.Linq;

namespace ShoppingLibrary.Models
{
    public class Warehouse
    {
        public string address;
        private List<Product> products;

        public Warehouse(string address)
        {
            this.address = address;
            products = new List<Product>();
        }
        
        public void AddProduct(Product product)
        {
            int productsCount = products.Where(x => x.name == product.name).ToList().Count;
            if (productsCount == 0)
            {
                products.Add(product);
            }
            else
            {
                products.First(x => x.name == product.name).amount++;
            }
        }

        public List<Product> GetProducts()
        {
            return products;
        }
    }
}