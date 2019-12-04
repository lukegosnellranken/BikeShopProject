using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SalesOrdersProject.Models;
using System.Data.Entity.Validation;
using System.Diagnostics;


namespace SalesOrdersProject.Controllers
{
    public class RegisterController : Controller
    {
        private SalesOrdersDatabase2Entities db = new SalesOrdersDatabase2Entities();

        [HttpGet]
        // GET: Register
        public ActionResult Index()
        {
            return View(new Customer());
        }

        [HttpPost]
        public RedirectToRouteResult Register(Customer customer)
        {
            customer.CustomerPassword = SHA256.Encode(customer.CustomerPassword);

            db.Customers.Add(customer);
            db.SaveChanges();

            return RedirectToAction("Index", "Home");

        }
    }
}
