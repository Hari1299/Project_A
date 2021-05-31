using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeliveryBookingSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryBookingSystem.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Register(User u)
        {
            if (u.UserType == "Customer")
            {
                return this.RedirectToAction("Create", "Customer");
            }
            else if (u.UserType == "Executive")
            {
                return this.RedirectToAction("Create", "Executive");
            }
            return View();
        }
        public ActionResult Login(User u)
        {
            if (u.UserType == "Customer")
            {
                return this.RedirectToAction("Login", "Customer");
            }
            else if (u.UserType == "Executive")
            {
                return this.RedirectToAction("Login", "Executive");
            }
            return View();
        }

        public ActionResult Home()
        {
            return View();
        }
    }
}
