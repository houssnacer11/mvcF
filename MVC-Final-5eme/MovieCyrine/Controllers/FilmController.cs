using MovieCyrine.Helper;
using MovieCyrine.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieCyrine.Controllers
{
    public class FilmController : Controller
    {
        // GET: Film
        public ActionResult Index()
        {
            //filtre par genre
            List<string> genres = new List<string> {"Comedy", "Action", "Horror" };           
            ViewData["filtre"] = new SelectList(genres);
            ViewBag.Totalgenre = genres.Count();

List < Film> Filmsss = (List<Film>)Session["Films"];
            return View(Filmsss); 

        }

        //dans la vue index , la methode de recherche s'invoque à travers le submit 
        [HttpPost]
        public ActionResult Index(string searchString, decimal? x, string filtre)
        {
             //création d'une liste de genre pour le filtrage (filtrer par genre)
            List<string> genres = new List<string> { "Comedy", "Action", "Horror" };
        
            // viewdata pour stocker le filtre 
            ViewData["filtre"] = new SelectList(genres);

             List<Film> Films = (List<Film>)Session["Films"];

            // recherche par le 1er parametre searchString
            if (!String.IsNullOrEmpty(searchString))
            {
                Films = Films.Where(m => m.Genre.Contains(searchString)).ToList();
             }

            // recherche par le 2eme parametre x
            if (!String.IsNullOrEmpty(x.ToString()))
            {
                Films = Films.Where(m => m.Prix==x).ToList();
}

            // filtrage 
           if (!String.IsNullOrEmpty(filtre.ToString()))
            {
               Films = Films.Where(m => m.Genre.Contains(filtre)).ToList();
            }
            return View(Films);

        }

//ambiguité entre les vues et actions
            /*
            [HttpPost]
        public ActionResult Index(string searchString)
        {
            List<Film> Films = (List<Film>)Session["Films"];
            if (!String.IsNullOrEmpty(searchString))
            {
                Films = Films.Where(m => m.Genre.Contains(searchString)).ToList();
            }
            return View(Films);
        }

        [HttpPost]
        public ActionResult Index(decimal x)
        {
            List<Film> Films = (List<Film>)Session["Films"];
            if (!String.IsNullOrEmpty(x.ToString()))
            {
                Films = Films.Where(m => m.Prix == x).ToList();
            }
            return View(Films);
        }

        */

        // GET: Film/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Film/Create
        public ActionResult Create()
        {
            List<string> genres = new List<string> { "Comedy", "Action", "Horror" };
            ViewData["Genre"] = new SelectList(genres);         
            return View();
        }

        // POST: Film/Create
        [HttpPost]
        public ActionResult Create(Film film, HttpPostedFileBase Image1) // Le meme parametre dans le textbox proprre à l'image de la vue create
        {
            if (!ModelState.IsValid || Image1 == null || Image1.ContentLength == 0)
            {
                RedirectToAction("Create");
            }

            //  List<Film> Films = Session["Films"] as List<Film>; 
            List<Film> Films = (List<Film>)Session["Films"];
            if (Films == null)
            {
                Films = new List<Film>();
            }
            var path = Path.Combine(Server.MapPath("~/Content/Upload/"), Image1.FileName);
            Image1.SaveAs(path);
           film.ImageUrl = Image1.FileName;
            Films.Add(film);
            Session["Films"] = Films;
            return RedirectToAction("Index");
      

        }

        // GET: Film/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Film/Edit/5
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

        // GET: Film/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Film/Delete/5
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
