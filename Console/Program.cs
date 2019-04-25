using Domaine;
using ServiceSpecifiques;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            FormationService ps = new FormationService();
            Producteur p = new Producteur { Nom = "test", prenom = "test", DateNaissance = DateTime.Now };
            ps.Add(p);
            ps.Commit();
            CandiratService fs = new CandiratService();
            Film f = new Film
            { Titre = "film1",
                Description = "Test",
               // DateProd = DateTime.Now,
               DateProd= new DateTime(2016, 1, 1, 12, 00, 00),
            Price =15,
                Genre ="Action",
                Evaluation="Super",
             //avec validation
                // Genre = "ok",
                //Evaluation = "suoer",
                ImageUrl ="image",
                ProducteurId =1
            };
            fs.Add(f);
            fs.Commit();

           
           
        }
    }
}
