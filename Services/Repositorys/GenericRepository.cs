using Entities;
using Services.IRepositorys;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Repositorys
{
    class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private BlackJackContext _blackJackContex;
        DbSet<TEntity> _dbSet;

        public GenericRepository(BlackJackContext blackJackContex)
        {
            _blackJackContex = blackJackContex;
            _dbSet = blackJackContex.Set<TEntity>();
        }


        public void Delete(TEntity item)
        {
            _dbSet.Remove(item);
            _blackJackContex.SaveChanges();
        }


        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate).ToList();
        }


        public IEnumerable<TEntity> Get()
        {
            return _dbSet.AsNoTracking().ToList();
        }



        public  bool IsExist()
        {
            bool existOrNot = _dbSet.Any();
            return existOrNot;
        }


        public bool IsExist(string name)
        {
            bool existOrNot = _blackJackContex.Players.Any(x=>x.Name==name);
            return existOrNot;
        }


        public TEntity GetById(int id)
        {
            return _dbSet.Find(id);
        }


        public void Insert(TEntity playingCard)
        {
            _dbSet.Add(playingCard);
            _blackJackContex.SaveChanges();
        }


        public void Save()
        {
            _blackJackContex.SaveChanges();
        }
    }
}
