using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Infrastructure
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private FilmManagementContext dataContext;
        public FilmManagementContext DataContext { get { return dataContext; } }

        public DatabaseFactory()
        {
            dataContext = new FilmManagementContext();
        }
        protected override void DisposeCore()
        {
            if (DataContext != null)
                DataContext.Dispose();
        }
    }
}
