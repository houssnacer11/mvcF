using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine
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
        [Display(Name = "Nom")]
        public string Nom { get; set; }

        /// <summary>
        /// Last Name
        /// </summary>
        [Display(Name = "Prénom")]
        public string prenom { get; set; }

        /// <summary>
        /// Date Of Birth
        /// </summary>
        [Display(Name = "Date de naissance")]
        public DateTime DateNaissance { get; set; }
        // public virtual Film Film { get; set; }
        virtual public ICollection<Film> Films { get; set; }
    }
}
