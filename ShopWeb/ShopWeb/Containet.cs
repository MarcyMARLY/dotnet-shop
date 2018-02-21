using ShopLibrary.Models.Order;
using ShopLibrary.Models.Store;
using ShopLibrary.Models.System;
using ShopLibrary.Models.User;

namespace ShopWeb
{
    public class Containet
    {
        public static ShopSystem NewShopSystem = new ShopSystem();
        public static User loggedUser = new Customer("",""); 
            
        static readonly string productPath = "AppData/products.csv";
        static readonly string usersPath = "AppData/users.csv";
        static readonly string ordersPath = "AppData/orders.csv";
        public static  ProductFileStorage productStore = new ProductFileStorage{Path = productPath};
        public static UserFileStorage customerStore = new UserFileStorage(){Path  = usersPath};
        public static OrderFileStorage orderStore = new OrderFileStorage(){Path  = ordersPath};
        
        
        public static void GetProductsFromFile()
        {
            var productCollection = productStore.GetCollection();
            foreach (var item in productCollection)
            {
                NewShopSystem.AddProduct(item);
            }
        }

        public static void GetUsersFromFile()
        {
            var userCollection = customerStore.GetCollection();
            foreach (var item in userCollection)
            {
                Customer customer = new Customer(item.Username,item.password);
                customer.id = item.id;
                NewShopSystem.AddUser(customer);
                //Console.WriteLine("Customer id {0}", customer.id);
            }
        }
        public static void GetOrdersFromFile()
        {
            var orderCollection = orderStore.GetCollection();
            foreach (var item in orderCollection)
            {
                Order o = new Order()
                {
                    BuyerId = item.BuyerId,
                    OrderId = item.OrderId,
                    Status = item.Status,
                    OrderItems = item.OrderItems
                }; 
                NewShopSystem.AddOrder(o);
                //Console.WriteLine("Customer id {0}", customer.id);
            }
        }

        
    }
}