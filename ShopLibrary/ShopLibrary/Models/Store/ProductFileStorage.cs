using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ShopLibrary.Models.Product;

namespace ShopLibrary.Models.Store
{
    public class ProductFileStorage : IChangeable<Product.Product>
    {
        private List<Product.Product> storeCollection;
        public string Path { get; set; }

        public List<Product.Product> GetCollection()
        {
            if (storeCollection == null)
            {
                var data = File.ReadAllLines(Path);
                storeCollection = data
                    .Skip(1)
                    .Select(x => ConvertItem(x))
                    .ToList();
            }

            return storeCollection;
        }
        public Product.Product ConvertItem(string item)
        {
            var itemList = item.Split(';');
            return new Product.Product {
                Id = Convert.ToInt32(itemList[0]),
                Name = itemList[1],
                Price = Convert.ToSingle(itemList[2]),
                Amount = Convert.ToInt32(itemList[3]),
                Origin = itemList[4]
            };

        }

        public void WriteToFile(Product.Product product)
        {
            string res = product.Id.ToString() + ";" + product.Name + ";" + product.Price.ToString() + ";" +
                         product.Amount.ToString() + ";" + product.Origin;
            
            using (StreamWriter sw = File.AppendText(Path))
            {
                sw.WriteLine(res); 
            }

        }
    }
}