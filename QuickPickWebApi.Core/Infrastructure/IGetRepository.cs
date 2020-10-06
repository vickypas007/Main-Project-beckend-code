using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace QuickPickWebApi.Core.Infrastructure
{
    public interface IGetRepository<T> where T : class
    {

        T Single(Expression<Func<T, bool>> predicate = null,
           Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
           Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
           bool disableTracking = true);


        List<T> GetAll(Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            bool disableTracking = true);


       

        void Update<T>(T entity, Func<LocalView<T>, T> locatorMap) where T : class;

        List<T> GetAllList(Expression<Func<T, bool>> predicate = null,
            bool disableTracking = true);

       

        List<T> FromSql(string query, params object[] parameters);

        IQueryable<T> Get(Expression<Func<T, bool>> predicate = null,
          Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
           Func<IQueryable<T>, IOrderedQueryable<T>> orderByDescending = null,
          Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
          bool disableTracking = true);


    }
}
