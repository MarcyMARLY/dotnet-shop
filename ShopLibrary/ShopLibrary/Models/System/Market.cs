using System.Collections.Generic;
using ShopLibrary.Models.Product;

namespace ShopLibrary.Models.System
{
    public class Market
    {
        public Warehouse Warehouse { get; set; }
        private List<User.User> users;
        
        public Market()
        {
            users = new List<User.User>();
            Warehouse = new Warehouse("temporary");
        }

        public void AddUser(User.User newUser)
        {
            users.Add(newUser);
        }

        public bool TryLogin(string username, string password)
        {
            return users.Find(x => x.Authenticate(username, password)) != null;
        }

        public User.User GetUser(string username)
        {
            return users.Find(x => x.Username == username);
        }
    }
}