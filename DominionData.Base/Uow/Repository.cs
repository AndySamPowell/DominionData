using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Transactions;

namespace DominionData.Base
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public DbContext DbContext { get; set; }

        protected DbSet<T> DbSet { get; set; }
        private bool _doBatchPerformance;

        public Repository(DbContext dbContext, bool doBatchPerformance = false)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException("DB Context must be defined");
            }
            DbContext = dbContext;
            DbSet = DbContext.Set<T>();
            _doBatchPerformance = doBatchPerformance;
        }

        public void Add(T entity)
        {
            var dbEntityEntry = DbContext.Entry<T>(entity);

            if (dbEntityEntry.State != System.Data.Entity.EntityState.Detached)
            {
                dbEntityEntry.State = System.Data.Entity.EntityState.Added;
            }
            else
            {
                DbSet.Add(entity);
            }
        }

        public void Update(T entity)
        {
            var dbEntityEntry = DbContext.Entry<T>(entity);

            if (dbEntityEntry.State == System.Data.Entity.EntityState.Detached)
            {
                DbSet.Attach(entity);
            }

            DbContext.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }

        public T GetUpdatedItem(T entity)
        {
            var dbEntityEntry = DbContext.Entry<T>(entity);

            if (dbEntityEntry.State == System.Data.Entity.EntityState.Detached)
            {
                DbSet.Attach(entity);
            }

            var result = dbEntityEntry.Entity as T;

            return result;
        }

        public void Delete(T entity)
        {
            if (DbContext.Entry(entity).State == System.Data.Entity.EntityState.Detached)
            {
                DbSet.Attach(entity);
            }

            DbSet.Remove(entity);
        }

        //GetById does not work for unit testing with mock database
        public T GetById(object id)
        {
            using (var transaction = new TransactionScope(TransactionScopeOption.Required,
                new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted }))
            {
                var result = DbSet.Find(id);

                transaction.Complete();

                return result;
            }
        }

        /// <summary>
        /// This method only usefull for large data set, & read-only entities as uses AsNoTracking method.
        /// This means that the EF does not cache its entities.
        /// No Update can be done on these entities automatically without using context attach() method.
        /// We should use this method with queries in which we do not want to save the data back to the database.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> GetAll()
        {
            var cmd = DbContext.Database.Connection.CreateCommand();
            if(cmd.Connection.State != System.Data.ConnectionState.Open)
                cmd.Connection.Open();
            cmd.CommandText = "set arithabort on";
            cmd.ExecuteNonQuery();
            using (var transaction = new TransactionScope(TransactionScopeOption.Required,
                new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted }))
            {
                IEnumerable<T> result = DbSet.AsNoTracking();

                transaction.Complete();
                cmd.Connection.Close();
                cmd.Dispose();
                return result;
            }
        }

        /// <summary>
        /// This implementation of getting by query allow a person to include objects in the results.
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <param name="includeProperties">Split the entity names you want to include with the ',' character</param>
        /// <returns></returns>
        public IEnumerable<T> GetByQuery(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "")
        {
            var cmd = DbContext.Database.Connection.CreateCommand();
            if (cmd.Connection.State != System.Data.ConnectionState.Open)
                cmd.Connection.Open();
            cmd.CommandText = "set arithabort on";
            cmd.ExecuteNonQuery();
            using (var transaction = new TransactionScope(TransactionScopeOption.Required,
                new TransactionOptions {IsolationLevel = IsolationLevel.Snapshot}))
            {
                IQueryable<T> query = DbSet;

                if (filter != null)
                {
                    query = query.Where(filter);
                }

                foreach (var includeProperty in includeProperties.Split
                    (new char[] {','}, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty.Trim());
                }

                var result = orderBy != null ? orderBy(query) : query;

                transaction.Complete();
                cmd.Connection.Close();
                cmd.Dispose();
                return result;
            }
        }

        public IQueryable<T> GetByIQuerable(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "")
        {
            var cmd = DbContext.Database.Connection.CreateCommand();
            if (cmd.Connection.State != System.Data.ConnectionState.Open)
                cmd.Connection.Open();
            cmd.CommandText = "set arithabort on";
            cmd.ExecuteNonQuery();
            using (var transaction = new TransactionScope(TransactionScopeOption.Required,
                new TransactionOptions { IsolationLevel = IsolationLevel.Snapshot }))
            {
                IQueryable<T> query = DbSet;
                if (filter != null)
                {
                    query = query.Where(filter);
                }

                foreach (var includeProperty in includeProperties.Split
                    (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty.Trim());
                }

                var result = orderBy != null ? orderBy(query) : query;

                transaction.Complete();
                cmd.Connection.Close();
                cmd.Dispose();
                return result;
            }
        }

        public IEnumerable<TReturnType> ExecuteStoredProcedure<TReturnType>(string query, params object[] parameters)
        {
            var cmd = DbContext.Database.Connection.CreateCommand();
            if (cmd.Connection.State != System.Data.ConnectionState.Open)
                cmd.Connection.Open();
            cmd.CommandText = "set arithabort on";
            cmd.ExecuteNonQuery();
            using (var transaction = new TransactionScope(TransactionScopeOption.Required,
                new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted }))
            {
                var result = DbContext.Database.SqlQuery<TReturnType>(query, parameters).ToList();

                transaction.Complete();
                cmd.Connection.Close();
                cmd.Dispose();
                return result;
            }
        }

        public void SaveChanges()
        {
            DbContext.SaveChanges();
        }

        public void RejectChanges()
        {
            foreach (var entry in DbContext.ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified; //Revert changes made to deleted entity.
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                }
            }
        }
    }
}