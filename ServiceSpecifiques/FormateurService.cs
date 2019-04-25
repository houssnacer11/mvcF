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
    public class FormateurService : Service<Formateur>
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);
        public FormateurService() : base(ut)
        {
        }
        public IEnumerable<Formateur> top3formateur()
        {
            var linq = (from i in ut.getRepository<Formation>().GetAll()
                        join j in ut.getRepository<Formateur>().GetAll() on i.Formateur.CodeFormateur equals j.CodeFormateur
                        where i.typeFormation == TypeFormation.Enligne
                        orderby i.Candidats.Count()
                        select j).Take(3);
            return linq;






            //return ut.getRepository<Formation>().GetAll()
            //  return ut.getRepository<Formateur>().GetAll().Take(5).Select(t => t.Formations.Where(y => y.typeFormation == TypeFormation.Enligne).OrderBy(r => r.NombreParticipant));
        }
    }
}

