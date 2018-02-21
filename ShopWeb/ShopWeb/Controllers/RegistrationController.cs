using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopLibrary.Models;
using ShopLibrary.Models.User;


namespace ShopWeb.Controllers
{
    public class RegistrationController : Controller
    {
        
        // GET: Registration
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public  ActionResult Register()
        {
            var username = Request.Form["Username"].ToString();
            var password = Request.Form["Password"].ToString();
            var customer = new Customer(username,password);
            Containet.NewShopSystem.AddUser(customer);
            Containet.customerStore.WriteToFile(customer);
            
            return View();
        }

    }
}