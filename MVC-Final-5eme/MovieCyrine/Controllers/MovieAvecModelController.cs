using MovieCyrine.Models;
using ServiceSpecifiques;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;

namespace MovieCyrine.Controllers
{
    public class MovieAvecModelController : Controller
    {
        FilmService serviceFilm = null;
        ProducteurService serviceProducteur = null;
        public MovieAvecModelController()
        {

            serviceProducteur = new ProducteurService();
            serviceFilm = new FilmService();

        }
        // GET: MovieAvecModel
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
            return View( );
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
        // GET: MovieAvecModel/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MovieAvecModel/Create
        public ActionResult Create()
        {
            Film filmModel = new Film();
            // dropdowlist de genre
            List<string> Genres = new List<string> { "Action", "Romance", "Comedy" };
            ViewData["genre"] = new SelectList(Genres);

            // dropdownlist Producteur
            var prod = serviceProducteur.GetAll();
            ViewData["Produc"] = new SelectList(prod, "ProducteurId","Nom");
            // ViewBag.Producteur = new SelectList(prod, "ProducteurId", "Nom");

            var x = serviceProducteur.GetAll().
               Select(w => new SelectListItem
               {
                   Text = w.Nom +" "+ w.prenom,
                   Value = w.ProducteurId.ToString()
               });
            filmModel.Producteurs = x;
            return View(filmModel);
        }

        // POST: MovieAvecModel/Create
        [HttpPost]
        public ActionResult Create(Models.Film filmVM, HttpPostedFileBase Image)
        {

            Domaine.Film film = new Domaine.Film();
            film.Titre = filmVM.Titre;
            film.Price = filmVM.Prix;
            film.DateProd = filmVM.ReleaseDate;
            film.Description = filmVM.Description;
            film.Genre = filmVM.Genre;
            film.ImageUrl = filmVM.ImageUrl;
            film.ProducteurId = filmVM.ProducteurId;
            film.Evaluation = filmVM.Avis;
            film.ImageUrl = Image.FileName;

            serviceFilm.Add(film);
            serviceFilm.Commit();

            var path = Path.Combine(Server.MapPath("~/Content/Upload/"), Image.FileName);
            Image.SaveAs(path);
            return RedirectToAction("Index");
        }


        // GET: MovieAvecModel/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MovieAvecModel/Edit/5
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

        // GET: MovieAvecModel/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MovieAvecModel/Delete/5
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
