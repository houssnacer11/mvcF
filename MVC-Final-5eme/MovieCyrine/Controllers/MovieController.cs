

using MovieCyrine.Helper;
using MovieCyrine.Models;
using ServiceSpecifiques;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieCyrine.Controllers
{
   
    public class MovieController : Controller
    {

        FilmService serviceFilm = null;
        ProducteurService serviceProducteur = null;
        public MovieController()
        {
            
            serviceProducteur = new ProducteurService();
            serviceFilm = new FilmService();

        }
        // GET: Movie
        public ActionResult Index()
        {


            var film = serviceFilm.GetAll();

            List<Film> fVM = new List<Film>();
            foreach (var item in film)
            {

                fVM.Add(
                    new Film
                    {
                        Id = item.Id,
                        Description = item.Description,
                        Titre = item.Titre,
                        Genre = item.Genre,
                        ImageUrl = item.ImageUrl,
                        ReleaseDate = item.DateProd,                     
                        ProducteurId = item.ProducteurId,
                        Avis = item.Evaluation,
                        Prix = item.Price,
                    });
            }
            return View(fVM);
        }
        [HttpPost]
        public ActionResult Index(string searchString)
        {
            var film = serviceFilm.GetAll();
            List<Film> fVM = new List<Film>();
            foreach (var item in film)
            {
                fVM.Add(new Film
                {
                    Genre = item.Genre,
                    Titre = item.Titre,
                    Description = item.Description,
                    ReleaseDate = item.DateProd,
                    Prix = item.Price,
                    Avis = item.Evaluation,
                    ImageUrl = item.ImageUrl,
                    ProducteurId = item.ProducteurId
                });
            }
            if (!String.IsNullOrEmpty(searchString))
            {
                fVM = fVM.Where(m => m.Genre.Contains(searchString)).ToList();
            }


            return View(fVM);
        }

        [HttpPost]
       
        // GET: Movie/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Movie/Create
        public ActionResult Create()
        {
            var film = new Models.Film();
            film.Producteurs = serviceProducteur.GetAll().ToSelectListItems();

            List<string> genres = new List<string> { "Comedy", "Action", "Horror" };
            film.Genres = genres.ToSelectListItems();
            return View(film);
        }
   

        // POST: Movie/Create
        [HttpPost]
        public ActionResult Create(Models.Film filmVM , HttpPostedFileBase Image)
        {
            Producteur p = new Producteur();

            Domaine.Film film = new Domaine.Film();
            film.Titre = filmVM.Titre;
            film.Price = filmVM.Prix;
            film.DateProd = filmVM.ReleaseDate;
            film.Description = filmVM.Description;
            film.Genre = filmVM.Genre;
            film.ImageUrl = filmVM.ImageUrl;
            film.ProducteurId = filmVM.ProducteurId;
            film.Evaluation = filmVM.Avis;
            serviceFilm.Add(film);
            serviceFilm.Commit();
            
            var path = Path.Combine(Server.MapPath("~/Content/Upload/"), Image.FileName);
            Image.SaveAs(path);
            return RedirectToAction("Index");

        }
       

        // GET: Movie/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Movie/Edit/5
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

        // GET: Movie/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Movie/Delete/5
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
