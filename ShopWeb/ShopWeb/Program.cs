using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ShopLibrary.Models.Store;
using ShopLibrary.Models.System;
using ShopLibrary.Models.User;

namespace ShopWeb
{
    public class Program
    {
       
        public static void Main(string[] args)
        {
            Containet.GetProductsFromFile();
            Containet.GetUsersFromFile();
            Containet.GetOrdersFromFile();
            
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
