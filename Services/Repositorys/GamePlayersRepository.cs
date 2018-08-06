using DataAccessLayer;
using DataAccessLayer.Entities;
using Services.IRepositorys;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace Services.Repositorys
{
    class GamePlayerRepository:IGamePlayerRepository
    {
        private BlackJackContext _blackJackContex;

        public GamePlayerRepository(BlackJackContext blackJackContext)
        {
            _blackJackContex = blackJackContext;
        }


        public IEnumerable<GamePlayer> GetGamePlayer()
        {
            return _blackJackContex.Players.ToList();
        }


        public IEnumerable<GamePlayer> GetGamePlayer(Func<GamePlayer, bool> predicate)
        {
            return _blackJackContex.Players.Where(predicate).ToList();
        }


        public GamePlayer GetGamePlayerById(int id)
        {
            return _blackJackContex.Players.FirstOrDefault(x=>x.Id==id);
        }


        public void InsertGamePlayer(GamePlayer item)
        {
            _blackJackContex.Players.Add(item);
            _blackJackContex.SaveChanges();
        }


        public void UpdateGamePlayer(GamePlayer item)
        {
            _blackJackContex.Entry(item).State = EntityState.Modified;
            _blackJackContex.SaveChanges();
        }


        public void DeleteGamePlayer(GamePlayer item)
        {
            _blackJackContex.Players.Remove(item);
            _blackJackContex.SaveChanges();
        }


        public bool IsExistPlayerByName(string name)
        {
            return _blackJackContex.Players.Any(x => x.Name == name);
        }


        public void Update(GamePlayer item)
        {
            _blackJackContex.Entry(item).State = EntityState.Modified;
            _blackJackContex.SaveChanges();
        }


        public void Save()
        {
            _blackJackContex.SaveChanges();
        }

    }
}
