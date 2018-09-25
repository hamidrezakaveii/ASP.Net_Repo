using Jour5_Procedure.Dao;
using Jour5_Procedure.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jour5_Procedure.Controllers
{
    public class HomeController : Controller
    {
        //procedure:GetListeFilms
        // GET: Home
        public ActionResult Index()
        {
            //connectionstring.con pour get the chaine de connection

            List<Movie> listAllMovie = Utils.GetInstance().GetListeMovie();




            return View(listAllMovie);
        }



        // GET: Home/Details/5
        public ActionResult Details(int id)
        {


            return View();
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {

            List<Movie> listAllMovie = new List<Movie>();
            listAllMovie = Utils.GetInstance().GetListeMovie();
            //List<Movie> listMovieById = Utils.GetInstance().GetMovieById(listAllMovie, id: id);

            var list = listAllMovie.Where(m => m.Id == id).FirstOrDefault();


            return View(list);
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                /*foreach (var key in collection.AllKeys)
                {
                    var value = collection[key];
                    // etc.
                }

                foreach (var key in collection.Keys)
                {
                    var value = collection[key.ToString()];
                    // etc.
                }*/

                string title = collection["Title"];
                string genre = collection["Genre"];
                int year = Convert.ToInt32(collection["Year"]);

                Utils.GetInstance().UpdateMovie(id, title, genre, year);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
