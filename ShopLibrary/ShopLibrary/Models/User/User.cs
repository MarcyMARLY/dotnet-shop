using System;
using System.Collections.Generic;
using System.Linq;
using ShopLibrary.Models.Order;

namespace ShopLibrary.Models.User
{
    public abstract class User
    {
        public int id;
        public string password;
        
        public string Username { get; set; }
        public Basket Basket { get; set; }
        public Random rnd = new Random();  
        protected User(string username, string password)
        {
            id = rnd.Next(100,1000) % 100;
            this.Username = username;
            this.password = password;
            Basket = new Basket();
        }

        public User()
        {
            
        }

        public void AddProductToBasket(int productId)
        {
            Basket.AddProduct(productId);
        }

        public List<BasketItem> GetBasketItems()
        {
            return Basket.GetBasketItems();
        }
        
        public void DisposeBasket()
        {
            Basket.CleanBasket();
        }
        
        public virtual bool Authenticate(string username, string password)
        {
            return this.password == password && this.Username == username;
        }

        public int GetUserId()
        {
            return this.id;
        }
    }
}