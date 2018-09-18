using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jour2_MVC5.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ByReleasedDate(int year, int month)
        {
            return Content("year: "+year+" month: "+month);
        }
    }
}