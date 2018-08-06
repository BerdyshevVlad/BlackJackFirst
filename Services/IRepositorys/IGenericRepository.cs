using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.IRepositorys
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        //IEnumerable<TEntity> GetPlayers();
        Task<IEnumerable<TEntity>> Get();
        IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);
        Task<TEntity> GetById(int id);
        bool IsExist();
        bool IsExist(string name);
        Task Insert(TEntity item);
        Task Delete(TEntity item);
        Task Delete(int id);
        Task Update(TEntity item);
        Task Save();
    }
}
