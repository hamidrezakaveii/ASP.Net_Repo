﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jour2_MVC5.Controllers
{
    public class StoreController : Controller
    {
        // GET: Store
        public ActionResult Index(int? id, string name)
        {
            if(!id.HasValue)
            {
                id = 777;
                return RedirectToAction("Details", "Store", new { id = id });
            }
            else
            {
                return Content("nothing");
            }
        }

        // GET: /Store/Browse
        ///Store/Browse?Genre=Disco pour afficher dans navigateur
        public string Browse(string  genre)
        {
            //string message = HttpUtility.HtmlEncode("Store.Browse, Genre = " + genre);
            string message = "Store.Browse, Genre = " + genre;
            return message;
        }


        // GET: /Store/Details
        public string Details(int id)
        {
            return "Details ici pour id : "+id;
        }


        // GET: /Store/Update
        public ViewResult Update(string nom)
        {
            ViewBag.nomModifie = nom.ToUpper();
            return View();
        }

        // GET: /Store/Back
        public ActionResult Back()
        {
            return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" });

        }





    }
}