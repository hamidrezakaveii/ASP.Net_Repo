using Jour3_View.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jour3_View.Views.Albums
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart
        public ActionResult Index()
        {
            var products = new List<Product>();

            for(int i =0; i<10; i++)
            {
                products.Add(new Product { Title = "Title" + i, Price = 1.13M * i });
            }

            var model = new ShoppingCartViewModel
            {
                Products = products,
                CartTotal = products.Sum(p => p.Price),
                Message = "Thanks for your bussiness!"


            };

            return View(model);
        }
    }
}