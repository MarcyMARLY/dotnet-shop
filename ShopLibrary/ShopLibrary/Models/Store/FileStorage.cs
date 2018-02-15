using System.Collections.Generic;
using System.Linq;

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

        public List<Product.Product> GetAllProductsOrderedByPrice()
        {
            return products.OrderBy(x => x.Price).ToList();
        }
        public List<Product.Product> GetAllProductsOrderedByAmount()
        {
            return products.OrderBy(x => x.Amount).ToList();
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
        public List<Order.Order> GetAllOrdersByUser(int userId)
        {
            return orders.FindAll(x => x.BuyerId == userId);
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