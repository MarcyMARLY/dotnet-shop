using System.Collections.Generic;
using ShopLibrary.Models.Product;
using ShopLibrary.Models.Store;

namespace ShopLibrary.Models.System
{
    public class ShopSystem
    {
        private IStore store;
        private List<User.User> users;
        
        public ShopSystem()
        {
            store = new FileStorage();
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