using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using BLL.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model;


namespace WebshopExamen.Controllers
{
    public class ProductController : Controller
    {
        IProductService service;
        public ProductController(IProductService _service)
        {
            service = _service;
        }

        public IActionResult Index(int? shoppingBagId)
        {
            List<Product> products = service.GetAllProducts();
            //ViewData["products"] = products;
            return View(products);
        }
        public IActionResult Remove(int productId)
        {

            service.Remove(productId);
            return RedirectToAction("Index");
        }

        //GET
        public IActionResult Edit(int productId)
        {
            Product product = service.FindById(productId);
            return View(product);
        }
        //POST
        [HttpPost]
        public IActionResult Edit(int ProductID ,[Bind("ProductId, Name, Price")] Product product)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    service.Update(product);
                }
                catch (DbUpdateConcurrencyException)
                {

                    throw ;
                     
                }return RedirectToAction("Index");

            }
            return View(product);
        }

        public IActionResult BuyProduct(int productID, int? shoppingBagId)
        {
           //if (productID == 0)
             //   productID= 1;
            Product product = service.FindById(productID);
            ViewData["shoppingBagId"] = shoppingBagId;
            ViewData["productQuantity"]= 0;
            return View(product);
        }
        //POST
        [HttpPost]
        public IActionResult BuyProduct(int ProductID, int qty, [Bind("ProductId, Name, Price")] Product product)
        {
            int customerId = 1;
            if (ModelState.IsValid)
            {
                try
                {

                }
                catch (DbUpdateConcurrencyException)
                {

                    throw;
                }
                return RedirectToAction("Create", "ShoppingBag", new { customerId, ProductID, qty });

            }
            return View(product);

        }
    }
}