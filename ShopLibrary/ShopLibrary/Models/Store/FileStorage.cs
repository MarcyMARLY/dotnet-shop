using System.Collections.Generic;

namespace ShopLibrary.Models.Store
{
    public class FileStorage : IStore
    {
//        private IChangeable userStorage;
//        private IChangeable orderStorage;
//        private IChangeable productStorage;
        List<User.User> users = new List<User.User>();
        List<Product.Product> products = new List<Product.Product>();
        List<Order.Order> orders = new List<Order.Order>();
        
        public FileStorage()
        {
//            userStorage = new UserFileStorage();
//            orderStorage = new OrderFileStorage();
//            productStorage = new ProductFileStorage();
//            
//            userStorage.ReadFromFile();
//            orderStorage.ReadFromFile();
//            productStorage.ReadFromFile();
            
        }
        
        public List<User.User> GetAllUsers()
        {
            return users;
        }

        public User.User GetUserById(int id)
        {
            return users.Find(x => x.GetUserId() == id);
        }

        public void AddUser(User.User user)
        {
            this.users.Add(user);
        }

        public List<Product.Product> GetAllProducts()
        {
            return products;
        }

        public Product.Product GetProductById(int id)
        {
            return products.Find(x => x.Id == id);
        }

        public void AddProduct(Product.Product product)
        {
            products.Add(product);
        }

        public List<Order.Order> GetAllOrders()
        {
            return orders;
        }

        public Order.Order GetOrderById(int id)
        {
            return orders.Find(x => x.OrderId == id);
        }

        public void AddOrder(Order.Order order)
        {
            orders.Add(order);            
        }
    }
}