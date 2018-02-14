using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ShopLibrary.Models.Product;

namespace ShopConsole
{
    public class ProductStore
    {
        private List<Product> storeCollection;
        public string Path { get; set; }

        public List<Product> GetCollection()
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
        public Product ConvertItem(string item)
        {
            var itemList = item.Split(';');
            return new Product {
                Id = Convert.ToInt32(itemList[0]),
                Name = itemList[1],
                Price = Convert.ToSingle(itemList[2]),
                Amount = Convert.ToInt32(itemList[3]),
                Origin = itemList[4]
            };

        }

      
    }
}