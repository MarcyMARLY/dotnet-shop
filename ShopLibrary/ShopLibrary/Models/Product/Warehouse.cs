using System.Collections.Generic;
using System.Linq;

namespace ShopLibrary.Models.Product
{
    public class Warehouse
    {
        public string address;
        private List<Models.Product.Product> products;

        public Warehouse(string address)
        {
            this.address = address;
            products = new List<Models.Product.Product>();
        }
        
        public void AddProduct(Models.Product.Product product)
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

        public Models.Product.Product GetProductById(int id)
        {
            return products.Find(x => x.Id == id);
        }
        
        public List<Models.Product.Product> GetProducts()
        {
            return products;
        }
    }
}