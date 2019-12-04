using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SalesOrdersProject.Models;
using System.Web.Security;

namespace SalesOrdersProject.Controllers
{
    public class LoginController : Controller
    {
        private SalesOrdersDatabase2Entities db = new SalesOrdersDatabase2Entities();

        // GET: Login
        [HttpGet]
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Customer customer, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (IsValid(customer.CustomerEmailAddress, customer.CustomerPassword))
                {
                    FormsAuthentication.SetAuthCookie(customer.CustomerID.ToString(), false);

                    if (string.IsNullOrEmpty(returnUrl) || returnUrl.ToLower().Contains("login"))
                    {
                        returnUrl = Url.Action("Index", "Home");
                    }

                    return Redirect(returnUrl);
                }

                else
                {
                    ModelState.AddModelError("", "The username and/or password is incorrect. Try again.");
                }
            }
            return View(customer);
        }

        public bool IsValid(string Email, string Password)
        {
            string passwordHash = SHA256.Encode(Password);
            var data = from c in db.Customers
                       where (c.CustomerEmailAddress == Email && c.CustomerPassword == passwordHash)
                       select new
                       {
                           c.CustomerID,
                           c.CustomerEmailAddress,
                           c.CustomerPassword
                       };

            return (data.Count() > 0);
        }
    }
}