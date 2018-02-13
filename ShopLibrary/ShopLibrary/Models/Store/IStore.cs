using System.Collections.Generic;

namespace ShopLibrary.Models.Store
{
    public interface IStore
    {
        List<User.User> GetAllUsers();
        Product.Product GetProductById(int id);
    }
}