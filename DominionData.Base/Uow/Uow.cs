using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace DominionData.Base
{
    public class Uow : IUow
    {
        public DbContext DbContext { get; private set; }
        private bool _doBatchPerformance;
        public Uow(DbContext context, bool doBatchPerformance = false, int connectionTimeout = 120)
        {
            DbContext = context;
            DbContext.Database.CommandTimeout = connectionTimeout;
            _doBatchPerformance = doBatchPerformance;
            if (!doBatchPerformance) return;

            DbContext.Configuration.AutoDetectChangesEnabled = false;
            DbContext.Configuration.ValidateOnSaveEnabled = false;
        }

        public void Commit()
        {
            DbContext.SaveChanges();
        }

        public IRepository<T> GetRepo<T>() where T : class
        {
            return new Repository<T>(DbContext, _doBatchPerformance);
        }
        
        public void Dispose()
       {
            DbContext.Dispose();
        }

        public void CleanCache()
        {
            foreach (DbEntityEntry dbEntityEntry in DbContext.ChangeTracker.Entries())
            {
                if (dbEntityEntry.Entity != null)
                {
                    dbEntityEntry.State = EntityState.Detached;
                }
            }
        }
    }
}
