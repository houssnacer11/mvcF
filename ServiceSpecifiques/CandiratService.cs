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
    public class CandiratService : Service<Candidat>
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);

        public CandiratService() : base(ut)

        {
        }
        public int nbrparticipations(string cin)
        {

            return ut.getRepository<Candidat>().GetAll().Where(t => t.CIN == cin).Select(d => d.Formations).Count();

        }
    }
}
