using Domaine;
using MovieCyrine.Helper;
using ServiceSpecifiques;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieCyrine.Controllers
{
    public class MovieAvecDomaineController : Controller
    {
        FilmService serviceFilm = null;
        ProducteurService serviceProducteur = null;
        public MovieAvecDomaineController()
        {

            serviceProducteur = new ProducteurService();
            serviceFilm = new FilmService();

        }
        // GET: MovieAvecDomaine
        public ActionResult Index()
        {
            ViewBag.total = serviceFilm.GetAll().Count();

            return View(serviceFilm.GetAll());
        }

        // GET: MovieAvecDomaine/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MovieAvecDomaine/Create
        public ActionResult Create()
        {
            // var film = new Film(); 


            var x = serviceProducteur.GetAll();
              
            ViewBag.Product = new SelectList(x, "ProducteurId", "Nom");

            List<string> genres = new List<string> { "Comedy", "Action", "Horror" };
           
            ViewData["Genre"] = new SelectList(genres);

             return View();
        }

        // POST: MovieAvecDomaine/Create
        [HttpPost]
        public ActionResult Create(Film f, HttpPostedFileBase Image)
        {
            f.ImageUrl = Image.FileName;
            serviceFilm.Add(f);
            serviceFilm.Commit();
            var path = Path.Combine(Server.MapPath("~/Content/Upload/"), Image.FileName);
            Image.SaveAs(path);
         return   RedirectToAction("Index");

        }

        // GET: MovieAvecDomaine/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MovieAvecDomaine/Edit/5
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

        // GET: MovieAvecDomaine/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MovieAvecDomaine/Delete/5
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
