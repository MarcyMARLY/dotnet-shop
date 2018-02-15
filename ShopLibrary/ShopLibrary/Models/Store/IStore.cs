using System.Collections.Generic;

namespace ShopLibrary.Models.Store
{
    public interface IStore
    {
        List<User.User> GetAllUsers();
        User.User GetUserById(int id);
        void AddUser(User.User user);
        
        List<Product.Product> GetAllProducts();
        List<Product.Product> GetAllProductsOrderedByPrice();
        List<Product.Product> GetAllProductsOrderedByAmount();
        Product.Product GetProductById(int id);
        void AddProduct(Product.Product product);

        List<Order.Order> GetAllOrders();
        List<Order.Order> GetAllOrdersByUser(int userId);
        Order.Order GetOrderById(int id);
        void AddOrder(Order.Order order);
    }
}