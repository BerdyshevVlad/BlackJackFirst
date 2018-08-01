using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.IRepositorys
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Get();
        IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);
        TEntity GetById(int id);
        bool IsExist();
        bool IsExist(string name);
        void Insert(TEntity item);
        void Delete(TEntity item);
        void Save();
    }
}
