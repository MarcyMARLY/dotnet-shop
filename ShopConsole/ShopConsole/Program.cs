using System;
using ShopLibrary;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using ShopLibrary.Models;
using ShopLibrary.Models.Order;
using ShopLibrary.Models.Product;
using ShopLibrary.Models.System;
using ShopLibrary.Models.User;

namespace ShopConsole
{
    class Program
    {

        private static  ShopSystem system = new ShopSystem();
        public static User loggedUser; 
        static readonly string productPath = "AppData/products.csv";
        
        static void Main(string[] args)
        {

            GetProductsFromFile();
            
           // user.AddProductToBasket(1);
            //user.AddProductToBasket(2);
            /*Console.WriteLine(user.GetUserId());

            system.CreateOrderForUser(user.id);
            var orders = system.GetAllOrders();
            foreach (var order in orders)
            {
                foreach (var item in order.OrderItems)
                {
                    Console.WriteLine(item.ProductId + " " + item.TotalPrice);
                }
                Console.WriteLine(order.BuyerId);
            }*/

            Access();




        }

        public static void GetProductsFromFile()
        {
            var prosuctStore = new ProductStore(){Path  = productPath};
            var productCollection = prosuctStore.GetCollection();
            foreach (var item in productCollection)
            {
                system.AddProduct(item);
            }

        }

        private static void Access()
        {
           Console.WriteLine("Choose the option:\n 1. Register \n 2. Login\n");
           var option = int.Parse(Console.ReadLine());
            if (option == 1)
            {
                Console.WriteLine("Please, enter the username");
                string username = Console.ReadLine();
                Console.WriteLine("Please, enter the password");
                string password = Console.ReadLine();
                Customer user = new Customer(username, password);
                system.AddUser(user);
                Access();
            }
            else
            {
                Console.WriteLine("Please, enter the username");
                string username = Console.ReadLine();
                Console.WriteLine("Please, enter the password");
                string password = Console.ReadLine();
              
                if (system.AuthenticateUser(username, password))
                {
                    loggedUser = system.GetUserByName(username);
                    Console.WriteLine("Success");
                    Menu();
                }
                else
                {
                    Console.WriteLine("Wrong username or password");
                    Access();
                }

            }
        }

        private static void ShowProducts()
        {
            var productList = system.GetAllProducts();
            foreach (var product in productList)
            {
                Console.WriteLine("Id: {0}, Name: {1}, Price: {2}, Amount: {3}, Origin: {4}",
                    product.Id,
                    product.Name,
                    product.Price,
                    product.Amount,
                    product.Origin);
            }
        }

        private static void ShowBasket()
        {
            var basketCollection = loggedUser.Basket.GetBasketItems();
            foreach (var item in basketCollection)
            {
                Console.WriteLine("Id: {0}, Amount: {1}", item.GetId(), item.GetAmount());
            }
        }

        private static void Menu()
        {
            Console.WriteLine("Choose the option: \n 1. Show list of products \n 2. Add product to basket \n 3. Remove product from basket \n 4. Show basket \n 5. Clear basket\n");
            var option = int.Parse(Console.ReadLine());
            switch (option)
            {
                case 1:
                    ShowProducts();
                    Menu();
                    break;
                case 2:
                    Console.WriteLine("Enter product Id");
                    var IdAdd = int.Parse(Console.ReadLine());
                    loggedUser.AddProductToBasket(IdAdd);
                    Menu();
                    break;
                case 3:
                    Console.WriteLine("Enter product Id");
                    var IdRem = int.Parse(Console.ReadLine());
                    loggedUser.Basket.RemoveProduct(IdRem);
                    Menu();
                    break;
                case 4:
                    ShowBasket();
                    Menu();
                    break;
                case 5:
                    loggedUser.DisposeBasket();
                    Menu();
                    break;
            }
        }
    }
}