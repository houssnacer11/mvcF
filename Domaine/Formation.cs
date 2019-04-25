using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine
{
    public enum TypeFormation { Locale, Enligne}
    public class Formation
    {
        [Key]
        public int IdFormation { get; set; }
        public string Description { get; set; }
        public TimeSpan Duree { get; set; }
        public string NomFormation { get; set; }
        public int Nbparticipants { get; set; }
        public TypeFormation typeFormation {get;set;}
        public DateTime Date { get; set; }
    public Formateur Formateur { get; set; }
        public ICollection<Candidat> Candidats { get; set; }
        public float Prix { get; set; }
       
    }
}
