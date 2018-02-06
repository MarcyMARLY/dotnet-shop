using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace ShopLibrary.Models
{
    public class Market
    {
        public Warehouse warehouse;
        private List<User> users;
        
        public Market()
        {
            users = new List<User>();
            warehouse = new Warehouse("temporary");
        }

        public void AddUser(User newUser)
        {
            users.Add(newUser);
        }

        public bool TryLogin(string username, string password)
        {
            return users.Find(x => x.Authenticate(username, password)) != null;
        }

        public User GetUser(string username)
        {
            return users.Find(x => x.Username == username);
        }
    }
}