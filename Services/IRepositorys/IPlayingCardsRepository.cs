using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.IRepositorys
{
    public interface IPlayingCardsRepository    {
        IEnumerable<PlayingCard> GetPlayingCards();
        PlayingCard GetPlayingCardById(int id);
        void InsertPlayingCard(PlayingCard playingCard);
        void DeletePlayingCard(int playingCardID);
        void Save();
    }
}
