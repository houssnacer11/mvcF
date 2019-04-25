using MovieCyrine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieCyrine.Controllers
{
    public class test1Controller : Controller
    {
        // GET: test1
        public ActionResult Index()
        {
            List<Film> movies = Session["films"] as List<Film>;
            return View(movies);
        }
        [HttpPost]
        public ActionResult Index(string searchString, decimal? x)
        {
            List<Film> movies = Session["films"] as List<Film>;

            // recherche par le 1er parametre searchString
            if (!String.IsNullOrEmpty(searchString))
            { 
                //n'a pas marché avec contains
                movies = movies.Where(m => m.Genre.Equals(searchString)).ToList();
            }

            // recherche par le 2eme parametre x
            if (!String.IsNullOrEmpty(x.ToString()))
            {
                movies = movies.Where(m => m.Prix == x).ToList();
            }
            return View(movies);
        }
        // GET: test1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: test1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: test1/Create
        [HttpPost]
        public ActionResult Create(Film film)
        {

            List<Film> movies = Session["films"] as List<Film>;
            if (movies == null)
            {
                movies = new List<Film>();
            }

            movies.Add(film);
            Session["films"] = movies;
            return RedirectToAction("Index");
        }

        // GET: test1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: test1/Edit/5
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

        // GET: test1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: test1/Delete/5
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
