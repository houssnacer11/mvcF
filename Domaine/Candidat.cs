using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine
{
   public class Candidat
    {
        [Key,MaxLength(8)]      
        public string CIN{ get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Image { get; set; }
        public string Email { get; set; }
        public ICollection<Formation> Formations { get; set; }
    }
}
