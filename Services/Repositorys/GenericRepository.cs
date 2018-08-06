using Dapper;
using DataAccessLayer;
using Services.IRepositorys;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Repositorys
{
    class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private BlackJackContext _blackJackContex;
        private DbSet<TEntity> _dbSet;
        //private string connectionString;

        public GenericRepository(BlackJackContext blackJackContex)
        {
            _blackJackContex = blackJackContex;
            _dbSet = blackJackContex.Set<TEntity>();
            //connectionString = ConfigurationManager.ConnectionStrings["BlackJackContex"].ConnectionString;
        }


        //private string connectionString = ConfigurationManager.ConnectionStrings["BlackJackContex"].ConnectionString;
        //public IEnumerable<TEntity> GetPlayers()
        //{
        //    List<TEntity> players = new List<TEntity>();
        //    using (SqlConnection db = new SqlConnection(connectionString))
        //    {
        //        players= db.Query<TEntity>("SELECT * FROM GamePlayer").ToList();
        //    }
        //    return players;
        //}

        public async Task Delete(TEntity item)
        {
             var result=_dbSet.Find(item);
            _dbSet.Remove(result);
            //await _blackJackContex.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var result = _dbSet.Find(id);
            _dbSet.Remove(result);
            await _blackJackContex.SaveChangesAsync();
        }

        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate);
        }


        public async Task<IEnumerable<TEntity>> Get()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }


        public bool IsExist()
        {
            bool existOrNot = _dbSet.Any();
            return existOrNot;
        }


        public bool IsExist(string name)
        {
            bool existOrNot = _blackJackContex.Players.Any(x=>x.Name==name);
            return existOrNot;
        }


        public async Task<TEntity> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }


        public async Task Insert(TEntity playingCard)
        {
             _dbSet.Add(playingCard);
            await _blackJackContex.SaveChangesAsync();
        }


        public async Task Update(TEntity item)
        {
            _blackJackContex.Entry(item).State = EntityState.Modified;
            await _blackJackContex.SaveChangesAsync();
        }

        public async Task Save()
        {
            await _blackJackContex.SaveChangesAsync();
        }
    }
}
