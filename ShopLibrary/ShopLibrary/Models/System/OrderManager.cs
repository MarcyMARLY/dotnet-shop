using System;
using System.Collections.Generic;
using System.Linq;
using ShopLibrary.Models.Order;
using ShopLibrary.Models.Store;

namespace ShopLibrary.Models.System
{
    public class OrderManager
    {
        private IStore _storage;
        public static OrderManager manager; 
        public List<Order.Order> ActiveOrders { get; set; }

        public OrderManager(IStore storage)
        {
            if (manager == null)
            {
                manager = new OrderManager(storage);
            }
        }
        
        public void CreateOrderFromBasket(int userId)
        {
            var user = _storage.GetAllUsers().Find(x => x.GetUserId() == userId);
            if (user != null)
            {
                var order = new Order.Order() { OrderId = new Random(1000).Next(), Status = OrderStatus.CREATED};
                user.Basket.GetBasketItems().ForEach(x => order.OrderItems.Add(new OrderItem()
                {
                    Amount = x.GetAmount(), 
                    ProductId = x.GetId(), 
                    TotalPrice = x.GetAmount() * _storage.GetProductById(x.GetId()).Price
                }));
                ActiveOrders.Add(order);
                user.DisposeBasket();
            }
        } 
    }
}