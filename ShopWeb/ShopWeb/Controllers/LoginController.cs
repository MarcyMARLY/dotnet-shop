using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopLibrary.Models.User;

namespace ShopWeb.Controllers
{
    public class LoginController : Controller
    {
        
        // GET: Login
        public ActionResult Index()
        {
            Console.WriteLine(Containet.NewShopSystem.GetAllUsers().Count());
            return View();
        }
        [HttpPost]
        public ActionResult Index(Containet c)
        {
            var username = Request.Form["Username"].ToString();
            var password = Request.Form["Password"].ToString();
            if (Containet.NewShopSystem.AuthenticateUser(username, password))
            {
                Containet.loggedUser = Containet.NewShopSystem.GetUserByName(username);
                
                ViewData["message"] = "Success";
                
                return RedirectToAction("Index", "Menu");
            }
            else
            {
                ViewData["message"] = "Error";
            }
            return View();
        }

       
    }
}