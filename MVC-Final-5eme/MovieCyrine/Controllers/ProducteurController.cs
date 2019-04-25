using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieCyrine.Controllers
{
    public class ProducteurController : Controller
    {
        // GET: Producteur
        public ActionResult Index()
        {
            return View();
        }

        // GET: Producteur/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Producteur/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Producteur/Create
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

        // GET: Producteur/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Producteur/Edit/5
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

        // GET: Producteur/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Producteur/Delete/5
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
