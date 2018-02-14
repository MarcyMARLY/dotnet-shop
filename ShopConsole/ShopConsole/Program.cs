﻿using System;
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
        public static ProductStore productStore = new ProductStore(){Path  = productPath};
        
        static void Main(string[] args)
        {

            GetProductsFromFile();
            //GetUsersFromFile();
            //GerOrdersFromFile();
            Access();
        }

        public static void GetProductsFromFile()
        {
            var productCollection = productStore.GetCollection();
            foreach (var item in productCollection)
            {
                system.AddProduct(item);
            }
        }

        private static void AddProduct()
        {
            Console.WriteLine("Enter the Id");
            var id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the name");
            var name = Console.ReadLine();
            Console.WriteLine("Enter the price");
            var price = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the amount");
            var amount = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the origin");
            var origin = Console.ReadLine();
            Product product = new Product(){Id= id, Name = name, Price = price, Amount = amount,Origin = origin};
            system.AddProduct(product);
            productStore.WriteToFile(product);
        }

        private static void Access()
        {
           Console.WriteLine("Choose the option:\n " +
                             "1. Register \n " +
                             "2. Login\n " +
                             "3. System methods \n ");
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
            else if (option == 2)
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
            else
            {
                SystemMenu();
                Access();
            }
        }

        private static void SystemMenu()
        {
            Console.WriteLine("Choose the option: \n " +
                              "1. Get all products\n " +
                              "2. Get all users \n " +
                              "3. Get all orders \n " +
                              "4. Add product \n ");
            var option = int.Parse(Console.ReadLine());
            switch (option)
            {
                    case 1:
                        ShowProducts();
                        SystemMenu();
                        break;
                    case 2:
                        ShowUsers();
                        SystemMenu();
                        break;
                    case 3:
                        ShowOrders();
                        SystemMenu();
                        break;
                    case 4:
                        AddProduct();
                        break;
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

        private static void ShowUsers()
        {
            var userList = system.GetAllUsers();
            foreach (var item in userList)
            {
                Console.WriteLine("Id: {0}, username: {1}", item.id, item.Username);
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

        private static void ShowOrders()
        {
            var orderCollection = system.GetAllOrders();
            foreach (var item in orderCollection)
            {
               Console.WriteLine("Status: {0}, Id: {1}, Buyer Id: {2}", item.Status, item.OrderId, item.BuyerId); 
            }
        }

        private static void Menu()
        {
            Console.WriteLine("Choose the option: \n" +
                              " 1. Show list of products \n" +
                              " 2. Add product to basket \n" +
                              " 3. Remove product from basket \n" +
                              " 4. Remove whole product \n" +
                              " 5. Show basket \n" +
                              " 6. Clear basket \n" +
                              " 7.Create Order \n" +
                              " 8.Show orders \n" +
                              " 9. Pay Order \n" +
                              " 10. Quit \n");
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
                    Console.WriteLine("Enter product Id");
                    var IdRemWhole = int.Parse(Console.ReadLine());
                    loggedUser.Basket.RemoveProduct(IdRemWhole);
                    Menu();
                    break;
                case 5:
                    ShowBasket();
                    Menu();
                    break;
                case 6:
                    loggedUser.DisposeBasket();
                    Menu();
                    break;
                case 7:
                    system.CreateOrderForUser(loggedUser.id);
                    Menu();
                    break;
                case 8:
                    ShowOrders();
                    Menu();
                    break;
                case 9:
                    Console.WriteLine("Enter order id");
                    var orderId = int.Parse(Console.ReadLine());
                    system.PayOrder(loggedUser.id, orderId);
                    Menu();
                    break;
                case 10:
                    break;
            }
        }
    }
}