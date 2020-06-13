using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using BLL.interfaces;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace WebshopExamen.Controllers
{
    public class HomeController : Controller
    {
        public static int shoppingBadID = 0;

        public IActionResult Index()
        {
            Random r = new Random();
            int nummer = r.Next(1, 5);
            ViewData["PictureNr"] = nummer;
            return View();
        }


        //IUserService service;
        //public HomeController(IUserService _service)
        //{
        //    service = _service;
        //}
        //public IActionResult Index()
        //{
        //    List<User> users = service.GetAllUsers();
        //    //ViewData["users"] = users;
        //    return View(users);


        }
    
}