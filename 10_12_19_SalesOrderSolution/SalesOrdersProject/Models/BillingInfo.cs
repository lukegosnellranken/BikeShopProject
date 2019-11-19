using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SalesOrdersProject.Models
{
    public class BillingInfo
    {
        [Required(ErrorMessage = "Billing First Name is Mandatory")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Billing Last Name is Mandatory")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Billing Credit Card Number is Mandatory")]
        public string CreditCardNumber { get; set; }

        [Required(ErrorMessage = "Billing Address is Mandatory")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Billing City is Mandatory")]
        public string City { get; set; }

        [Required(ErrorMessage = "Billing State is Mandatory")]
        public string State { get; set; }

        [Required(ErrorMessage = "Billing Postal Code is Mandatory")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Billing Expire Month is Mandatory")]
        public string ExpireMonth { get; set; }

        public SelectList Months()
        {
            return new SelectList(new string[]
            {
                "01", "02", "03", "04",
                "05", "06", "07", "08",
                "09", "10", "11", "12"
            });
        }

        [Required(ErrorMessage = "Billing Expire Year is Mandatory")]
        public string ExpireYear { get; set; }

        public SelectList Years()
        {
            return new SelectList(new String[]
            {
               //"2019", "2020", "2021", "2022","2023", "2024", "2025", "2026", "2027", "2028", "2029", "2030"
                DateTime.Today.ToString("dd-MM-yyyy"),
                DateTime.Today.AddYears(2).ToString("dd-MM-yyyy"), DateTime.Today.AddYears(3).ToString("dd-MM-yyyy"), DateTime.Today.AddYears(4).ToString("dd-MM-yyyy"),
                DateTime.Today.AddYears(5).ToString("dd-MM-yyyy"), DateTime.Today.AddYears(6).ToString("dd-MM-yyyy"), DateTime.Today.AddYears(7).ToString("dd-MM-yyyy"),
                DateTime.Today.AddYears(8).ToString("dd-MM-yyyy"), DateTime.Today.AddYears(9).ToString("dd-MM-yyyy"), DateTime.Today.AddYears(10).ToString("dd-MM-yyyy")
            });
        }
    }
}