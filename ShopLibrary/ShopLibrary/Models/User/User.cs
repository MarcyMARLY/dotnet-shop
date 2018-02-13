using System;
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
            Basket = new Basket();
            id = new Random(100000).Next();
            this.Username = username;
            this.password = password;
        }
        
        public virtual bool Authenticate(string username, string password)
        {
            return this.password == password && this.Username == username;
        } 
    }
}