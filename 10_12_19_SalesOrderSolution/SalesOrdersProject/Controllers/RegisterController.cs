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
            //customer.CustomerPassword = SHA256.Encode(customer.CustomerPassword);

            db.Customers.Add(customer);
            db.SaveChanges();

            //try
            //{
            //    db.SaveChanges();
            //}

            //catch (DbEntityValidationException dbEx)
            //{
            //    foreach (var validationErrors in dbEx.EntityValidationErrors)
            //    {
            //        foreach (var validationError in validationErrors.ValidationErrors)
            //        {
            //            Trace.TraceInformation("Property: {0} Error: {1}",
            //                                    validationError.PropertyName,
            //                                    validationError.ErrorMessage);
            //        }
            //    }
            //}

            return RedirectToAction("Index", "Home");
        }
    }
}