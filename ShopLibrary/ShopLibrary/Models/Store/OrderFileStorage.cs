using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ShopLibrary.Models.Order;
using ShopLibrary.Models.User;

namespace ShopLibrary.Models.Store
{
    public class OrderFileStorage : IChangeable<Order.Order>
    {
        public string Path { get; set; }
        private List<Order.Order> storeCollection { get; set; }
        
        public List<Order.Order> GetCollection()
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

        public Order.Order ConvertItem(string item)
        {
            Console.WriteLine(item);
            var itemList = item.Split(';');
            var buyerId = int.Parse(itemList[0]);
            var orderId = int.Parse(itemList[1]);
            var statusString = itemList[2];
            var itemsString = itemList[3].Split('@');
            var actualStatus = OrderStatus.CREATED;
            var listItems = new List<OrderItem>();
            
            foreach (var itemEntity in itemsString)
            {
                var splittedItemEntity = itemEntity.Split('*');
                var orderItem = new OrderItem()
                {
                    Amount = int.Parse(splittedItemEntity[0]),
                    ProductId = int.Parse(splittedItemEntity[1]),
                    TotalPrice = double.Parse(splittedItemEntity[2])
                };
                listItems.Add(orderItem);
            }

            switch (statusString.ToLower())
            {
                    case "created":
                        actualStatus = OrderStatus.CREATED;
                        break;
                    case "paid":
                        actualStatus = OrderStatus.PAID;
                        break;
                    case "closed":
                        actualStatus = OrderStatus.CLOSED;
                        break;
                    default:
                        actualStatus = OrderStatus.CREATED;
                        break;                        
            }

            var order = new Order.Order()
            {
                BuyerId = buyerId,
                OrderId = orderId,
                OrderItems = listItems,
                Status = actualStatus
            };

            return order;
        }

        public void WriteToFile(Order.Order o)
        {
            var listItems = "";
            foreach (var orderItem in o.OrderItems)
            {
                listItems += orderItem.Amount + "*" + orderItem.ProductId + "*" + orderItem.TotalPrice + "@";
            }

            listItems = listItems.Substring(0, listItems.Length - 1);
            
            string res = o.BuyerId + ";" + o.OrderId + ";" + o.Status + ";" + listItems;
            
            using (StreamWriter sw = File.AppendText(Path))
            {
                sw.WriteLine(res); 
            }
        }

    }
}