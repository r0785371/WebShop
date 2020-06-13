using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.interfaces;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace WebshopExamen.Controllers
{
    public class ShoppingBagController : Controller
    {
        IShoppingBagService service;
        public ShoppingBagController(IShoppingBagService _service)
        {
            service = _service;
        }
        public IActionResult Index()
        {
            List<ShoppingBag> shoppingBags = service.GetAllShoppingBags();
            return View(shoppingBags);
        }
        public IActionResult AddBasket(int customerId ,int ProductId, int quantity)
        {
            //int customerId = 0;
            ShoppingBag bag = service.AddItem2ShoppingBag(HomeController.shoppingBadID, customerId, ProductId, quantity);
            HomeController.shoppingBadID = bag.ShoppingBagId;

            return RedirectToAction("Edit", new { bag.ShoppingBagId });
        }
        public IActionResult Edit(int shoppingBagId)
        {           
            if (shoppingBagId > 0)
            {
                ShoppingBag shoppingBag = service.FindShoppingWithItems(shoppingBagId);               
                return View(shoppingBag);
            }
           
            return RedirectToAction("Index");            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int ShoppingBagId, [Bind("CustomerId, Date")] ShoppingBag shoppingBag)
        {
            if (ModelState.IsValid)
            {
                service.Add(shoppingBag);
                return RedirectToAction("Index");
            }
            return View(shoppingBag);
        }
    }
}