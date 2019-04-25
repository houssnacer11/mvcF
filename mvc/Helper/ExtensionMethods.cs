
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
           this IEnumerable<Candidat> Candidats)
        {
            return
                Candidats.OrderBy(c => c.Nom)
                      .Select(c =>
                          new SelectListItem
                          {
                              //Selected = (prod.ProducteurId == selectedId),
                              Text = c.Nom + " " + c.Prenom,
                              Value = c.CIN.ToString()
                          });
        }

        public static IEnumerable<SelectListItem> ToSelectListItems(
           this IEnumerable<Formation> Formations)
        {
            return
                Formations.OrderBy(Formation => Formation.NomFormation)
                      .Select(prod =>
                          new SelectListItem
                          {

                              Text = prod.NomFormation,
                              Value = prod.NomFormation
                          });
        }
        //	SelectListItem:  Initialise une nouvelle instance de la classe SelectListItem.

        //SelectListItem represente l'element selectionné dans une instancede la classe SelectList.
        public static IEnumerable<SelectListItem> ToSelectListItems(
              this IEnumerable<string> typeFormation)
        {
            return
                     //ou    // genres.OrderBy(genre => genre)
                     typeFormation.Select(typeformation =>
                          new SelectListItem
                          {
                              Text = typeformation,
                              Value = typeformation
                          });
        }
    }
}
