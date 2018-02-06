﻿using System;

namespace ShopLibrary.Models
{
    public abstract class User
    {
        protected string id;
        public string Username { get; set; }
        public Order Order { get; set; }
        protected string password;
        
        protected User(string username, string password)
        {
            this.Order = new Order();
            this.Username = username;
            this.password = password;
        }
        
        public virtual bool Authenticate(string username, string password)
        {
            return this.password == password && this.Username == username;
        } 
    }
}