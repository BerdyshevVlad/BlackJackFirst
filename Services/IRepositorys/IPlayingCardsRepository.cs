using System;
using System.Collections.Generic;
using System.Text;

namespace Services.IRepositorys
{
    public interface IPlayingCardsRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetPlayingCards();
        void DeletePlayingCard(int id);
        IEnumerable<TEntity> GetPlayingCards(Func<TEntity, bool> predicate);
        TEntity GetPlayingCardById(int id);
        bool IsExistCards();
        void InsertPlayingCard(TEntity playingCard);
        void DeletePlayingCard(TEntity playingCard);
        void Save();
    }
}
