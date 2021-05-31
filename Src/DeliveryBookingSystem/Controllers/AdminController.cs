using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeliveryBookingSystem.Models;
using DeliveryBookingSystem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DeliveryBookingSystem.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            if (user.UserName == "Admin" && user.Password == "1234")
            {
                return RedirectToAction("AdminHomePage");
            }
            else
            {
                return View("Error");
            }
 
        }
        public IActionResult AdminHomePage(User u)
        {

            return View();
        }
    }

}