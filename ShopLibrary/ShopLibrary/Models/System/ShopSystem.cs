﻿using System.Collections.Generic;
using ShopLibrary.Models.Product;
using ShopLibrary.Models.Store;
using ShopLibrary.Models.Order;

namespace ShopLibrary.Models.System
{
    public class ShopSystem
    {
        private IStore store;
        private OrderManager manager;
        public ShopSystem()
        {
            store = new FileStorage();
            manager = new OrderManager(store);
        }

        public void AddUser(User.User newUser)
        {
            store.AddUser(newUser);
        }

        public void CreateOrderForUser(int userId)
        {
            manager.CreateOrderFromBasket(userId);
        }

        public void PayOrder(int userId, int orderId)
        {
            manager.MakePayment(userId, orderId);
        }
        
        public bool AuthenticateUser(string username, string password)
        {
            return store.GetAllUsers().Find(x => x.Authenticate(username, password)) != null;
        }

        public User.User GetUserByName(string username)
        {
            return store.GetAllUsers().Find(x => x.Username == username);
        }

        public List<User.User> GetAllUsers()
        {
            return store.GetAllUsers();
        }

        public List<Product.Product> GetAllProducts()
        {
            return store.GetAllProducts();
        }
        public List<Product.Product> GetAllProductsOrderesByPrice()
        {
            return store.GetAllProductsOrderedByPrice();
        }
        public List<Product.Product> GetAllProductsOrderesByAmount()
        {
            return store.GetAllProductsOrderedByAmount();
        }

        public Product.Product GetProductById(int id)
        {
            return store.GetProductById(id);
        }

        public void AddProduct(Product.Product product)
        {
            store.AddProduct(product);    
        }
        
        public Order.Order GetOrderById(int id)
        {
            return store.GetOrderById(id);
        }

        public List<Order.Order> GetAllOrders()
        {
            return store.GetAllOrders();
        }
        public List<Order.Order> GetAllOrdersByUser(int userId)
        {
            return store.GetAllOrdersByUser(userId);
        }

        public void AddOrder(Order.Order order)
        {
            store.AddOrder(order);
        }
    }
}