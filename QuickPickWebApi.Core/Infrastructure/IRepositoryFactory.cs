using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QuickPickWebApi.Core.Infrastructure
{
   public interface IRepositoryFactory
    {
        IRepository<T> GetRepository<T>() where T : class;
        Task ExecuteQuery(string query, params object[] values);
    }
}
