using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieCyrine.Models
{
    public class Producteur
    {
        /// <summary>
        /// Id
        /// </summary>
        public int ProducteurId { get; set; }

        /// <summary>
        /// First Name
        /// </summary>
        public string Nom { get; set; }

        /// <summary>
        /// Last Name
        /// </summary>
      [Display(Name ="Prénom")  ]
        public string Prenom { get; set; }

        /// <summary>
        /// Date Of Birth
        /// </summary>
        [Display(Name = "Date de naissance")]
        public DateTime DateOfBirth { get; set; }
      //  public IEnumerable<SelectListItem> Film { get; set; }
    }
}