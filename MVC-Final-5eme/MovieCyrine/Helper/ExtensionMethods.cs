
using Domaine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieCyrine.Helper
{
    public static class ExtensionMethods
    {
        public static IEnumerable<SelectListItem> ToSelectListItems(
           this IEnumerable<Producteur> producteurs)
        {
            return
                producteurs.OrderBy(prod => prod.Nom)
                      .Select(prod =>
                          new SelectListItem
                          {
                              Text = prod.Nom + " " + prod.prenom,
                              Value = prod.ProducteurId.ToString()
                          });
        }

        public static IEnumerable<SelectListItem> ToSelectListItems(
           this IEnumerable<Film> films)
        {
            return
                films.OrderBy(film => film.Titre)
                      .Select(prod =>
                          new SelectListItem
                          {

                              Text = prod.Titre,
                              Value = prod.Titre
                          });
        }
        //	SelectListItem:  Initialise une nouvelle instance de la classe SelectListItem.

        //SelectListItem represente l'element selectionné dans une instancede la classe SelectList.
        public static IEnumerable<SelectListItem> ToSelectListItems(
              this IEnumerable<string> genres)
        {
            return
                     //ou    // genres.OrderBy(genre => genre)
                     genres.Select(genre =>
                          new SelectListItem
                          {
                              Text = genre,
                              Value = genre
                          });
        }
    }
}
