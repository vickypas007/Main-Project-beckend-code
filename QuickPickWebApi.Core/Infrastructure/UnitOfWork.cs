using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QuickPickWebApi.Core.Infrastructure
{
    public class UnitOfWork<TContext> : IRepositoryFactory, IUnitOfWork<TContext>, IUnitOfWork
      where TContext : DbContext, IDisposable
    {
        private Dictionary<Type, object> _repositories;
        private IDbContextTransaction _transaction;

        public UnitOfWork(TContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void BeginTransaction()
        {
            _transaction = Context.Database.BeginTransaction();
        }

        public void Commit()
        {
            _transaction.Commit();
        }

        public void RollBack()
        {
            if (_transaction != null)
                _transaction.Rollback();
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            if (_repositories == null) _repositories = new Dictionary<Type, object>();

            var type = typeof(TEntity);
            if (!_repositories.ContainsKey(type)) _repositories[type] = new Repository<TEntity>(Context);
            return (IRepository<TEntity>)_repositories[type];
        }


        public async Task ExecuteQuery(string query, params object[] values)
        {
            await Context.Database.ExecuteSqlCommandAsync(query, values);
        }

        public TContext Context { get; }

        public int SaveChanges()
        {
            DisplayTrackedEntities(Context.ChangeTracker);

            return Context.SaveChanges();


        }

        public void Dispose()
        {
            Context?.Dispose();
            _transaction.Dispose();
        }

        void DisplayTrackedEntities(ChangeTracker changeTracker)
        {
            Console.WriteLine("");

            var entries = changeTracker.Entries();
            foreach (var entry in entries)
            {
                if (entry.State != EntityState.Added)
                {
                    System.Diagnostics.Debug.WriteLine("GoHire - Entity Name: {0}", entry.Entity.GetType().FullName);
                    System.Diagnostics.Debug.WriteLine("GoHire - Status: {0}", entry.State);
                }
            }
            Console.WriteLine("");
            Console.WriteLine("---------------------------------------");
        }

        public int IntFromSQL(string sql, params object[] parameters)
        {
            int count;
            var connection = Context.Database.GetDbConnection();

            //if(connection.State == System.Data.ConnectionState.Closed)
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = string.Format(sql, parameters);
            var res = command.ExecuteScalar();
            string result = "0";
            if (res != null)
                result = res.ToString();

            int.TryParse(result, out count);
            //connection.Close();
            return count;
        }

        public string FromSQL(string sql, params object[] parameters)
        {
            var connection = Context.Database.GetDbConnection();
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = string.Format(sql, parameters);
            var res = command.ExecuteScalar();
            string result = "";
            if (res != null)
                result = res.ToString();
            return result;
        }
    }
}
