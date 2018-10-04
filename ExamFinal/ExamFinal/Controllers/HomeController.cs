using ExamFinal.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamFinal.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: List
        public ActionResult List()
        {

            var listFrais = Utils.GetInstance().GetListFrais();
            return View(listFrais);

        }

        // GET: Home/Create
        public ActionResult Create()
        {
            ViewBag.list = Utils.GetInstance().GetListeVille().Select(m => m.Nom);

            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {


                string nom = collection["Nom"];
                string prenom = collection["Prenom"];
                string date = collection["Date"];
                int kilometre = int.Parse(collection["Kilometre"]);
                string  ville = collection["listVille"];
                double fraisresturant = double.Parse(collection["FraisDeResturant"]);
                string codepostal = collection["CodePostal"];
                string courriel = collection["Courriel"];



                Utils.GetInstance().InsertFrais(nom, prenom, date, kilometre, ville, fraisresturant, codepostal, courriel);

                //return RedirectToAction("Result");

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
            return View();
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

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
