using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movie
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            //return View(movie);
            //ViewData["Movie"] = movie;
            //ViewBag.Movie = movie;
            //return RedirectToAction("Index", "Home",  new { page = 1, sortBy = "name" });

            var costomers = new List<Customer>
            {
                new Customer {Name = "Customer1" },
                new Customer {Name = "Customer2" }


            };

            var viewModel = new RandomMovieViewModel()
            {
                Movie = movie,
                Customers = costomers

            };


            return View(viewModel);


    }

        public ActionResult Edit(int movieId)
        {
            return Content("id="+ movieId);
        }

        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleasedDate(int year, int month)
        {




            return Content(year+"/"+month);
        }



        //movies
        public ActionResult Index(int? pageIndex, string sortBy)
        {

            if (!pageIndex.HasValue)
            {
                pageIndex = 1;
            }

            if (String.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "Name";
            }


            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }
    }
}