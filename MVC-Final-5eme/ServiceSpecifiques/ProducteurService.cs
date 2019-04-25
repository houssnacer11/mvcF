using Data.Infrastructure;
using Domaine;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceSpecifiques
{
    public class ProducteurService : Service<Producteur>
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);

        public ProducteurService():base(ut)
          
        {
        }
    }
}
