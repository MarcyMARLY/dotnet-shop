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

        public OrderManager(IStore storage)
        {
            if (manager == null)
            {
                manager = new OrderManager(storage);
            }
        }

        public void MakePayment(int userId, int orderId)
        {
            var order = _storage.GetAllOrders().Find(x => x.OrderId == orderId && x.BuyerId == userId);
            if (order != null) order.Status = OrderStatus.PAID;
        }
        
        public void CreateOrderFromBasket(int userId)
        {
            var user = _storage.GetAllUsers().Find(x => x.GetUserId() == userId);
            if (user != null)
            {
                var order = new Order.Order() { BuyerId = userId, OrderId = new Random(1000).Next(), Status = OrderStatus.CREATED};
                user.Basket.GetBasketItems().ForEach(x => order.OrderItems.Add(new OrderItem()
                {
                    Amount = x.GetAmount(), 
                    ProductId = x.GetId(), 
                    TotalPrice = x.GetAmount() * _storage.GetProductById(x.GetId()).Price
                }));
                if (order.OrderItems.Count != 0)
                {
                    _storage.AddOrder(order);
                    user.DisposeBasket();
                }
            }
        } 
    }
}