using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.interfaces;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace WebshopExamen.Controllers
{
    public class CustomerController : Controller
    {
        ICustomerService service;

        public CustomerController(ICustomerService _service)
        {
            service = _service;
        }

        public IActionResult Index()
        {
            List<Customer> customers = service.GetAllCustomers();
            return View(customers);
        }
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("CustomerId , Firstname , Name")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                service.Add(customer);
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        public IActionResult Edit(int customerId)
        {
            Customer customer = service.FindById(customerId);
            return View(customer);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit ([Bind("CustomerId , Firstname , Name")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                service.Update(customer);
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        public IActionResult Remove (int CustomerId)
        {
            service.Remove(CustomerId);
            return RedirectToAction("Index");
        }

    }
}