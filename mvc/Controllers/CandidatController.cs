using Domaine;
using ServiceSpecifiques;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieCyrine.Controllers
{
    public class CandidatController : Controller
    {
        CandiratService serviceCandidat = null;
        FormationService serviceFormation = null;
        public CandidatController()
        {
            serviceCandidat = new CandiratService();
            serviceFormation = new FormationService();
        }
        // GET: Candidat
        public ActionResult Index()
        {
            var getAll=serviceCandidat.GetAll();
            return View(getAll);
        }

        // GET: Candidat/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Candidat/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Candidat/Create
        [HttpPost]
        public ActionResult Create(Candidat Can,HttpPostedFileBase Image)
        {
            Can.Image = Image.FileName;
            serviceCandidat.Add(Can);
            serviceCandidat.Commit();
            var path = Path.Combine(Server.MapPath("~/Content/Upload/"), Image.FileName);
            Image.SaveAs(path);
            return RedirectToAction("Index");
        }

        // GET: Candidat/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Candidat/Edit/5
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

        // GET: Candidat/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Candidat/Delete/5
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
