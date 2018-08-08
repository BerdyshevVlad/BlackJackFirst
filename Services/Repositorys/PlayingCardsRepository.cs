using DataAccessLayer;
using Services.IRepositorys;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Services.Repositorys
{
    public class PlayingCardsRepository<TEntity> : IPlayingCardsRepository<TEntity> where TEntity : class
    {
        private BlackJackContext _blackJackContex;
        DbSet<TEntity> _dbSet;

        public PlayingCardsRepository(BlackJackContext blackJackContex)
        {
            _blackJackContex = blackJackContex;
            _dbSet = blackJackContex.Set<TEntity>();
        }


        public void DeletePlayingCard(TEntity playingCard)
        {
            _dbSet.Remove(playingCard);
            _blackJackContex.SaveChanges();
        }


        public void DeletePlayingCard(int id)
        {
            var result = _dbSet.Find(id);
            _dbSet.Remove(result);
            _blackJackContex.SaveChanges();
        }


        public IEnumerable<TEntity> GetPlayingCards(Func<TEntity, bool> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate).ToList();
        }


        public IEnumerable<TEntity> GetPlayingCards()
        {
            return _dbSet.AsNoTracking().ToList();
        }


        public bool IsExistCards()
        {
            return _blackJackContex.Cards.Any();
        }


        public TEntity GetPlayingCardById(int id)
        {
            return _dbSet.Find(id);
        }


        public void InsertPlayingCard(TEntity playingCard)
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
