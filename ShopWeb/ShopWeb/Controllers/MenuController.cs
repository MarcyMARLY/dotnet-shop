using System;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices.WindowsRuntime;
using Microsoft.AspNetCore.Mvc;
using ShopLibrary.Models.Order;

namespace ShopWeb.Controllers
{
    public class MenuController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View(Containet.NewShopSystem.GetAllProducts());
        }
        public IActionResult IndexA(int parameter)
        {
            switch (parameter)
            {
                    case 1:
                        return View(Containet.NewShopSystem.GetAllProducts().OrderBy(x => x.Id));
                    case 2:
                        return View(Containet.NewShopSystem.GetAllProducts().OrderBy(x => x.Name));
                    case 3:
                        return View(Containet.NewShopSystem.GetAllProducts().OrderBy(x => x.Price));
                    case 4:
                        return View(Containet.NewShopSystem.GetAllProducts().OrderBy(x => x.Amount));
                    case 5:
                        return View(Containet.NewShopSystem.GetAllProducts().OrderBy(x => x.Origin));
                    
            }
            return View(Containet.NewShopSystem.GetAllProducts());
        }

        public IActionResult AddToBasket(int Id, int source)
        {
            Containet.loggedUser.AddProductToBasket(Id);
            switch (source)
            {
                    case 0 :  return RedirectToAction("Index", "Menu");
                    case 1: return RedirectToAction("OrderByAmount", "Menu");
                    case 2: return RedirectToAction("OrderByPrice", "Menu");
                         
            }
            return RedirectToAction("Index", "Menu");
        }

        public IActionResult ShowBasket()
        {
            
            return View(Containet.loggedUser.Basket.GetBasketItems());
        }

        public IActionResult DecreaseAmount(int Id)
        {
            Containet.loggedUser.Basket.RemoveProduct(Id);
            return RedirectToAction("ShowBasket", "Menu");
        }

        public IActionResult Remove(int Id)
        {
           Containet.loggedUser.Basket.RemoveWholeProduct(Id);
            return RedirectToAction("ShowBasket", "Menu");
        }

        public IActionResult OrderByPrice()
        {
            return View(Containet.NewShopSystem.GetAllProductsOrderesByPrice());
        }

        public IActionResult OrderByAmount()
        {
            return View(Containet.NewShopSystem.GetAllProductsOrderesByAmount());
        }

        public IActionResult ClearBasket()
        {
            Containet.loggedUser.Basket.CleanBasket();
            return RedirectToAction("ShowBasket", "Menu");
        }

        public IActionResult ShowOrders()
        {
            
            return View(Containet.NewShopSystem
                .GetAllOrdersByUser(Containet.loggedUser.id)
                .Where(x => x.Status == OrderStatus.CREATED));
        }
        public IActionResult ShowPaidOrders()
        {
            
            return View(Containet.NewShopSystem
                .GetAllOrdersByUser(Containet.loggedUser.id)
                .Where(x => x.Status == OrderStatus.PAID));
        }

        public IActionResult CreateOrder()
        {
            Containet.NewShopSystem.CreateOrderForUser(Containet.loggedUser.id);
            
            //Console.WriteLine(Containet.loggedUser.id);
            return RedirectToAction("ShowOrders", "Menu");
        }

        public IActionResult Pay(int Id)
        {
            
            Containet.NewShopSystem.PayOrder(Containet.loggedUser.id,Id);
            var test = Containet.NewShopSystem.GetAllOrdersByUser(Containet.loggedUser.id).Last();
            Containet.orderStore.WriteToFile(test);
            return RedirectToAction("ShowPaidOrders", "Menu");
        }

    }
}