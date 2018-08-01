//using Entities;
//using Services.IRepositorys;
//using System;
//using System.Collections.Generic;
//using System.Data.Entity;
//using System.Linq;
//using System.Text;


//namespace Services.Repositorys
//{
//    class GamePlayersRepository<TEntity> : IGamePlayersRepository<TEntity> where TEntity : class
//    {
//        private BlackJackContext _blackJackContex;
//        DbSet<TEntity> _dbSet;

//        public GamePlayersRepository(BlackJackContext blackJackContext)
//        {
//            _blackJackContex = blackJackContext;
//            _dbSet = blackJackContext.Set<TEntity>();
//        }


//        public IEnumerable<TEntity> GetGamePlayers()
//        {
//            return _dbSet.AsNoTracking().ToList();
//        }


//        public IEnumerable<TEntity> GetGamePlayers(Func<TEntity, bool> predicate)
//        {
//            return _dbSet.AsNoTracking().Where(predicate).ToList();
//        }


//        public TEntity GetGamePlayerById(int id)
//        {
//            return _dbSet.Find(id);
//        }


//        public void InsertGamePlayer(TEntity item)
//        {
//            _dbSet.Add(item);
//            _blackJackContex.SaveChanges();
//        }


//        public void UpdateGamePlayers(TEntity item)
//        {
//            _blackJackContex.Entry(item).State = EntityState.Modified;
//            _blackJackContex.SaveChanges();
//        }


//        public void DeleteGamePlayer(TEntity item)
//        {
//            _dbSet.Remove(item);
//            _blackJackContex.SaveChanges();
//        }


//        public bool IsExistPlayerByName(string name)
//        {
//            return _blackJackContex.Players.Any(x => x.Name == name);
//        }


//        public void Save()
//        {
//            _blackJackContex.SaveChanges();
//        }

//    }
//}
