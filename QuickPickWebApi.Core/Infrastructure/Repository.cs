using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace QuickPickWebApi.Core.Infrastructure
{
    public class Repository<T> :   IRepository<T> where T : class
    {
        protected readonly DbContext _dbContext;
        public Repository(DbContext context)
        {
            _dbContext = context ?? throw new ArgumentException(nameof(context));
        }
        public void Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
        }

        public void Add(params T[] entities)
        {
            _dbContext.Set<T>().AddRange(entities);
        }

        public void Add(IEnumerable<T> entities)
        {
            _dbContext.Set<T>().AddRange(entities);
        }

        public void Delete(T entity)
        {
            var existing = _dbContext.Set<T>().Find(entity);
            if (existing != null) _dbContext.Set<T>().Remove(existing);
        }

        public void Delete(object id)
        {
            var typeInfo = typeof(T).GetTypeInfo();
            var key = _dbContext.Model.FindEntityType(typeInfo).FindPrimaryKey().Properties.FirstOrDefault();
            var property = typeInfo.GetProperty(key?.Name);
            if (property != null)
            {
                var entity = Activator.CreateInstance<T>();
                property.SetValue(entity, id);
                var res = _dbContext.Entry(entity).State = EntityState.Deleted;
                _dbContext.Attach(entity);
                _dbContext.Remove(entity);
               
            }
            else
            {
                var entity = _dbContext.Set<T>().Find(id);
                if (entity != null) Delete(entity);
            }
        }

        public void Delete(params T[] entities)
        {
            _dbContext.Set<T>().RemoveRange(entities);
        }

        public void Delete(IEnumerable<T> entities)
        {
            _dbContext.Set<T>().RemoveRange(entities);
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }


        [Obsolete("Method is replaced by GetList")]
        public IEnumerable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return _dbContext.Set<T>().Where(predicate).AsNoTracking().ToList();
        }


        public void Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            _dbContext.Update(entity);
        }

        public void Update(params T[] entities)
        {
            _dbContext.Set<T>().UpdateRange(entities);
        }

        public void Update(IEnumerable<T> entities)
        {
            _dbContext.Set<T>().UpdateRange(entities);
        }

        
    }
}
