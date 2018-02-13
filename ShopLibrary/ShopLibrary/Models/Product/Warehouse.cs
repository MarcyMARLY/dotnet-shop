using System.Collections.Generic;
using System.Linq;

namespace ShopLibrary.Models
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
            var productsCount = products.Where(x => x.Name == product.Name).ToList().Count;
            if (productsCount == 0)
            {
                products.Add(product);
            }
            else
            {
                products.First(x => x.Name == product.Name).Amount++;
            }
        }

        public Product GetProductById(int id)
        {
            return products.Find(x => x.Id == id);
        }
        
        public List<Product> GetProducts()
        {
            return products;
        }
    }
}