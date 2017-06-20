using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace DominionData.Base
{
    public interface IRepository<T> where T : class
    {
        DbContext DbContext { get; set; }

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        [Obsolete("Make use of GetByIQuerable")]
        T GetUpdatedItem(T entity);

        [Obsolete("Please do not use the method.  Was only added to replace the old UOW")]
        T GetById(object id);

        [Obsolete("Do not use get all, try and only use get by query.  Was added to replace the old UOW")]
        IEnumerable<T> GetAll();

        IEnumerable<TReturnType> ExecuteStoredProcedure<TReturnType>(string query, params object[] parameters);

        void SaveChanges();

        [Obsolete("Make use of GetByIQuerable")]
        IEnumerable<T> GetByQuery(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "");

        IQueryable<T> GetByIQuerable(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "");

        void RejectChanges();
    }
}
