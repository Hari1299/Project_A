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
    public class CustomerController : Controller
    {

        private readonly CustomerContext _context;
        public readonly ILogger<CustomerController> _logger;
        public readonly IRepo<Customer> _repo;
        public readonly IRepo<Booking> _repo2;
        static List<Customer> cust = new List<Customer>();
        public CustomerController(ILogger<CustomerController> logger, IRepo<Customer> repo,IRepo<Booking> repo2)
        {
            _logger = logger;
            _repo = repo;
            _repo2 =repo2;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<Customer> customer = _repo.GetAll().ToList();
            return View(customer);
        }

        public IActionResult CustomerList()
        {
            List<Customer> customer = _repo.GetAll().ToList();
            return View(customer);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Customer c)
        {
            c.IsVerified = "Null";
            _repo.Add(c);
            return RedirectToAction("Index");
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Customer c)
        {

            int id = _repo.Login(c);
            if (id != 0)
            {
                TempData["CustomerId"] = id;

                return RedirectToAction("CustomerHome");
            }
            else
            {
                return View("Error");
            }

        }
        public IActionResult TotalList()
        {
            int id = Convert.ToInt32(TempData.Peek("CustomerId"));
            List<Booking> d = _repo2.GetAll().Where(a => a.CustomerId == id).ToList();
            if (d.Count() != 0)
            {
                return View(d);
            }
            else if (d.Count() == 0)
            {
                return View("Empty");
            }
            return View();
        }

        //public ActionResult AcceptList()
        //{
        //    int id = Convert.ToInt32(TempData.Peek("ExecutiveId"));
        //    List<Booking> b = _repo2.GetAll().Where(a => a.ExecutiveId == id && a.DeliveryStatus == "Accepted").ToList();
        //}
        public ActionResult Success()
        {
            return View();
        }
        public ActionResult Error()
        {
            return View();
        }

        public ActionResult CustomerHome()
        {
            return View();
        }
        public IActionResult Edit(int id)
        {
            Customer customer = _repo.Get(id);
            return View(customer);
        }
        [HttpPost]
        public IActionResult Edit(int id, Customer customer)
        {
            _repo.Update(id, customer);
            return RedirectToAction("Index");
        }

        public IActionResult Empty()
        {
            return View();
        }
        
    }
}