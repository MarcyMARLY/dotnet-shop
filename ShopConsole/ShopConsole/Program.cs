using System;
using ShopLibrary;

using System.Collections.Generic;
using System.ComponentModel;
using ShopLibrary.Models;

namespace ShopConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Market market = new Market();
            Product p1 = new Product() {amount = 20, id = 1, name = "Lalka", origin = "china", price = 30f};
            Product p2 = new Product() {amount = 30, id = 2, name = "salka", origin = "china", price = 30f};
            Product p3 = new Product() {amount = 10, id = 3, name = "Dalka", origin = "china", price = 30f};
            var warehouse = market.warehouse;
            warehouse.AddProduct(p1);
            warehouse.AddProduct(p2);
            warehouse.AddProduct(p3);
            bool check = true;
            while (check){
                Console.WriteLine("Choose the option\n 1) Login\n 2) Registration \n 3) Quit");
                string op1 = Console.ReadLine();
                if (op1 == "1")
                {
                    Console.WriteLine("Hello! Please enter the username");
                    string username = Console.ReadLine();
                    Console.WriteLine("Please, enter the password");
                    string password = Console.ReadLine();
    
                    var temAdministrator = new Administrator("admin1", "123");
                    market.AddUser(temAdministrator);
                    if (market.TryLogin(username, password))
                    {
                        Console.WriteLine("Hello!");
                        User user = market.GetUser(username);
                        if (user is Customer)
                        {
                            
                            foreach (var item in warehouse.GetProducts())
                            {
                                Console.WriteLine("Product:ID {0}, Name {1}, Amount {2}, Price {3}", item.id, item.name, item.amount, item.price);
                            }
    
                            Console.WriteLine(
                                "Choose the action:\n 1) Add items to basket \n 2) Show the basket\n 3) Make payment\n 4) Show priduct list");
                            string n = Console.ReadLine();
                            if (n == "1")
                            {
                                bool entering = true;
                                while (entering)
                                {
                                    Console.WriteLine("To quit enter the 'q' ");
                                    Console.WriteLine("Please,enter the id of product");
                                    var command = Console.ReadLine();
                                    if (command == "q")
                                    {
                                        entering = false;
                                        continue;
                                    }

                                    var productId = int.Parse(command);
                                    Console.WriteLine("Please Enter the desired amount of product");
                                    var productAmount = int.Parse(Console.ReadLine());
                                    if (productAmount <= warehouse.GetProductById(productId).amount)
                                    {
                                        var productIdAndAmount = new Tuple<int, int>(productId, productAmount);
                                        user.Order.AddProduct(productIdAndAmount);
                                    }
                                    else
                                    {
                                        Console.WriteLine("We don't have such an amount of this product, Please enter less or equal to {0}",warehouse.GetProductById(productId).amount);
                                        productAmount = int.Parse(Console.ReadLine());
                                        var productIdAndAmount = new Tuple<int, int>(productId, productAmount);
                                        user.Order.AddProduct(productIdAndAmount);
                                        
                                    }
                                }
    
    
                            }
                            else if (n == "2")
                            {
                                foreach (var item in user.Order.GetProducts() )
                                {
                                    Product current = warehouse.GetProductById(item.Item1);
                                    Console.WriteLine("Product -> id: {0}, name: {1}, warehouse amount: {2}, user desired amount: {3}", current.id, current.name, current.amount, item.Item2);
                                }
                            }else if (n == "3")
                            {
                                List<Product> sendList = new List<Product>();
                                foreach (var item in user.Order.GetProducts())
                                {
                                    var val = warehouse.GetProductById(item.Item1);
                                    sendList.Add(val);
                             
                                }

                                var t = user.Order.PrepareTransaction(sendList);
                                Console.WriteLine("Transaction -> id:{0}, date: {1}, charge:{2}",t.Id,t.TransactionDateTime,t.Charge );
                            }
                        }
                        else
                        {
                        }
                    }
                    else
                    {
    
                    }
    
                }
                else if(op1 == "2")
                {
                    Console.WriteLine("Please, enter the username");
                    string username = Console.ReadLine();
                    Console.WriteLine("Enter the password");
                    string password = Console.ReadLine();
                    var user1 = new Customer(username, password);
                    market.AddUser(user1);
                    Console.WriteLine(market.GetUser(username).Username);
                }
                else
                {
                    check = false;
                }
            }
        }

        public void PrintProducts()
        {
            
        }
    }
}