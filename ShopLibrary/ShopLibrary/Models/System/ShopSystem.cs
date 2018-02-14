﻿using System.Collections.Generic;
using ShopLibrary.Models.Product;
using ShopLibrary.Models.Store;
using ShopLibrary.Models.Order;

namespace ShopLibrary.Models.System
{
    public class ShopSystem
    {
        private IStore store;
        
        public ShopSystem()
        {
            store = new FileStorage();
        }

        public void AddUser(User.User newUser)
        {
            store.AddUser(newUser);
        }

        public bool AuthenticateUser(string username, string password)
        {
            return store.GetAllUsers().Find(x => x.Authenticate(username, password)) != null;
        }

        public User.User GetUserByName(string username)
        {
            return store.GetAllUsers().Find(x => x.Username == username);
        }

        public List<Product.Product> GetAllProducts()
        {
            return store.GetAllProducts();
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

        public void AddOrder(Order.Order order)
        {
            store.AddOrder(order);
        }
    }
}