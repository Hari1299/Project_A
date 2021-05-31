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
    public class ExecutiveController : Controller
    {
        public readonly ILogger<ExecutiveController> _logger;
        public readonly IRepo<DeliveryExecutive> _repo;
        public readonly IRepo<Booking> _repo1;
        //static List<Customer> cust = new List<Customer>();
        public ExecutiveController(ILogger<ExecutiveController> logger, IRepo<DeliveryExecutive> repo,IRepo<Booking>repo1)
        {
            _logger = logger;
            _repo = repo;
            _repo1 = repo1;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<DeliveryExecutive> deliveryExecutives = _repo.GetAll().ToList();
            return View(deliveryExecutives);
        }

        public IActionResult ExecutiveList()
        {
            List<DeliveryExecutive> deliveryExecutives = _repo.GetAll().ToList();
            return View(deliveryExecutives);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(DeliveryExecutive deliveryExecutive)
        {
            deliveryExecutive.IsVerified = "Null";
            _repo.Add(deliveryExecutive);
            return RedirectToAction("Index");
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(DeliveryExecutive deliveryExecutive)
        {
            int id = _repo.Login(deliveryExecutive);
            if (id != 0)
            {
                TempData["ExecutiveId"] = id;
                return RedirectToAction("ExecutiveHome");
            }
            else
            {
                return RedirectToAction("Error");
            }
        }
        public ActionResult Success()
        {
            return View();
        }
        public ActionResult Error()
        {
            return View();
        }

        public ActionResult ExecutiveHome()

        {
            return View();
        }
        //[HttpGet]
        //public IActionResult Edit(int id)
        //{
        //    int idx = cust.FindIndex(p => p.CustomerId == id);
        //    return View(cust[idx]);
        //}
        //[HttpPost]
        //public IActionResult Edit(int id, Customer post)
        //{
        //    int idx = cust.FindIndex(p => p.CustomerId == id);
        //    //posts[idx].PostText = post.PostText;
        //    //posts[idx].Category = post.Category;
        //    return RedirectToAction("Index");

        //}
        public IActionResult Edit(int id)
        {
            DeliveryExecutive delivery = _repo.Get(id);
            return View(delivery);
        }
        [HttpPost]
        public IActionResult Edit(int id, DeliveryExecutive delivery)
        {
            _repo.Update(id, delivery);
            return RedirectToAction("ExecutiveList");
        }

        public IActionResult RequestPending()
        {
            int id = Convert.ToInt32(TempData.Peek("ExecutiveId"));
            List<Booking> d = _repo1.GetAll().Where(a => a.ExecutiveId == id && a.DeliveryStatus=="Requested").ToList();
            if(d.Count()!=0)
            {
                return View(d);
            }
            else if(d.Count()==0)
            {
                return View("NoRequests");
            }
            return View();
        }

        public IActionResult NoRequests()
        {
            return View();
        }
    }
}