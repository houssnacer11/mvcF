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
    public class FormationService : Service<Formation>
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);
        CandiratService cs = null;
        public FormationService() : base(ut)

        {

            cs = new CandiratService();
        }
        public IEnumerable<Formation> ListFormations(DateTime date)
        {
            return ut.getRepository<Formation>().GetAll().Where(x => x.Date == date);
        }
        //methode3
        public double montantReduction(string cin)
        {
            double tot = 0;
            foreach (var item in GetAll())
            {
                if (cs.nbrparticipations(cin) > 5)
                {
                    tot = item.Prix - (item.Prix * 0.2);
                }
            }
            return tot;
        }

        public IEnumerable<Formation>ListeFormationUlterieures()
            {
            return ut.getRepository<Formation>().GetAll().Where(f => f.Date >= DateTime.Now);
            }
    }
}
