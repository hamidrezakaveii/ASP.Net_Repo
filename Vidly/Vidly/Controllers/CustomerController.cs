using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {

            var customers = new List<Customer>
            {
                new Customer { Name = "Mathiue Puma"},
                new Customer {Name = "Hami Kaveii" }
            };




            return View(customers);
        }
    }
}