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
        public FilmManagementContext():base("name=MyDBFilm")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
          
               modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnType("datetime2"));

        }
        public DbSet<Film> Films { get; set; }
        public DbSet<Producteur> Producteurs { get; set; }
    }
}
