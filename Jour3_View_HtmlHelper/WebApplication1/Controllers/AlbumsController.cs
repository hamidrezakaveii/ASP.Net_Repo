using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AlbumsController : Controller
    {
        // GET: Albums
        public ActionResult Index()
        {
            return View();
        }

        // Get:Albims/ListWeeklyTyped
        public ActionResult ListWeeklyTyped()
        {
            var albums = new List<Album>();

            for(int i = 0; i < 10; i++)
            {
                albums.Add(new Models.Album { Title = "Album" + i });
            }

            ViewBag.Albums = albums;

            return View();
        }



        // Get:Albims/ListWeeklyTyped
        public ActionResult ListStronlyTyped()
        {
            var albums = new List<Album>();

            for (int i = 0; i < 10; i++)
            {
                albums.Add(new Models.Album { Title = "Album" + i });
            }

            //ViewBag.Albums = albums;

            return View(albums);
        }
    }
}