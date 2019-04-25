using Domaine;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
   public class FilmManagementContext : DbContext
    {
        public FilmManagementContext():base("name=FormationDB")
        {

        }

        public DbSet<Formation> Formation { get; set; }
        public DbSet<Formateur> Formateur { get; set; }
        public DbSet<Candidat> Candidats { get; set; }
    }
}
