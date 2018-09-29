using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jour4_JSON_Filtre.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        // GET: Home
        public ActionResult Index2()
        {
            return View();
        }

        
        public ActionResult List()
        {
            var movies = new List<Object>();

            movies.Add(new { Title = "GhostBusters", Genre = "Comedy", Year = 1984 });
            movies.Add(new { Title = "Gone with Wind", Genre = "Drama", Year = 1939 });
            movies.Add(new { Title = "Star Wars", Genre = "Science Fiction", Year = 1977 });

      

            return Json(movies, JsonRequestBehavior.AllowGet);
        }

    }
}