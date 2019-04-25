using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine
{
   public class Formateur
    {
        [Key]
        public string CodeFormateur{ get; set; }
        public int Niveau { get; set; }
        public string NomFormateur { get; set; }
        public ICollection<Formation> Formations { get; set; }

    }
}
