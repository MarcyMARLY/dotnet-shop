using System.Collections.Generic;

namespace ShopLibrary.Models.Store
{
    public class OrderFileStorage : IChangeable<Order.Order>
    {
        public string Path { get; set; }
        public List<Order.Order> GetCollection()
        {
            throw new global::System.NotImplementedException();
        }

        public Order.Order ConvertItem(string item)
        {
            throw new global::System.NotImplementedException();
        }

        public void WriteToFile(Order.Order t)
        {
            throw new global::System.NotImplementedException();
        }
    }
}