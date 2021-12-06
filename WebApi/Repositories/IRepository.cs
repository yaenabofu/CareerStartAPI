using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WebApi.Repository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> Get();
        T Get(int id);
        void Create(T obj);
        void Update(T оbj);
        bool Delete(int id);
        void Save();
    }
}
