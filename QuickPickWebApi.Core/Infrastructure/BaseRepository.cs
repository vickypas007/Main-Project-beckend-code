using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace QuickPickWebApi.Core.Infrastructure
{
    public abstract class BaseRepository<T> : IGetRepository<T> where T : class
    {
        protected readonly DbContext _dbContext;

        public BaseRepository(DbContext context)
        {
            _dbContext = context ?? throw new ArgumentException(nameof(context));
        }

        public T Single(Expression<Func<T, bool>> predicate = null,
          Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
          Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
          bool disableTracking = true)
        {
            IQueryable<T> query = _dbContext.Set<T>();
            if (disableTracking) query = query.AsNoTracking();

            if (include != null) query = include(query);

            if (predicate != null) query = query.Where(predicate);

            if (orderBy != null)
                return orderBy(query).FirstOrDefault();
            return query.FirstOrDefault();
        }

        public List<T> GetAll(Expression<Func<T, bool>> predicate = null,
         Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
         Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
         bool disableTracking = true)
        {
            IQueryable<T> query = _dbContext.Set<T>();
            if (disableTracking) query = query.AsNoTracking();

            if (include != null) query = include(query);

            if (predicate != null) query = query.Where(predicate);

            if (orderBy != null)
                return orderBy(query).ToList();
            return query.ToList();
        }

   

        public List<T> GetAllList(Expression<Func<T, bool>> predicate = null,
            bool disableTracking = true)
        {
            IQueryable<T> query = _dbContext.Set<T>();

            if (disableTracking) query = query.AsQueryable();

            foreach (var property in _dbContext.Model.FindEntityType(typeof(T)).GetNavigations())
                query = query.Include(property.Name);

            if (predicate != null) query = query.Where(predicate);

            return query.ToList();
        }

        public void Update<T>(T entity, Func<LocalView<T>, T> locatorMap) where T : class
        {
            var entry = _dbContext.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                var set = _dbContext.Set<T>();
                T attachedEntity = locatorMap(set.Local);

                if (attachedEntity != null)
                {
                    var attachedEntry = _dbContext.Entry(attachedEntity);
                    attachedEntry.CurrentValues.SetValues(entity);
                }
                else
                {
                    entry.State = EntityState.Modified; // This should attach entity
                }
            }
        }

        //Execute Stored Procedure/DML Statement/Views
        public List<T> FromSql(string query, params object[] parameters)
        {
            return _dbContext.Set<T>()
                    .FromSqlRaw(query, parameters).AsNoTracking().ToList();
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> predicate = null,
          Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
           Func<IQueryable<T>, IOrderedQueryable<T>> orderByDescending = null,
          Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
          bool disableTracking = true)
        {
            var query = _dbContext.Set<T>().AsQueryable();

            if (disableTracking) query = query.AsNoTracking();

            if (include != null) query = include(query);

            if (predicate != null) query = query.Where(predicate);

            if (orderBy != null)
                query = orderBy(query);

            if (orderByDescending != null)
                query = orderByDescending(query);

            return query;
        }

    }
}
