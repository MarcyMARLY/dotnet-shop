using System;
using System.Collections.Generic;
using System.Linq;
using ShopLibrary.Models.Order;

namespace ShopLibrary.Models.User
{
    public abstract class User
    {
        protected int id;
        protected string password;
        
        public string Username { get; set; }
        public Basket Basket { get; set; }
            
        protected User(string username, string password)
        {
            id = new Random(100000).Next();
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