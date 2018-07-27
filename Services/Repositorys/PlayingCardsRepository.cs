using Entities;
using Services.IRepositorys;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Repositorys
{
    public class PlayingCardsRepository : IPlayingCardsRepository
    {
        private BlackJackContext blackJackContex;

        public PlayingCardsRepository(BlackJackContext blackJackContex)
        {
            this.blackJackContex = blackJackContex;
        }


        public void DeletePlayingCard(int playingCardID)
        {
            PlayingCard playingCard = blackJackContex.PlayingCards.Find(playingCardID);
            blackJackContex.PlayingCards.Remove(playingCard);
        }


        public IEnumerable<PlayingCard> GetPlayingCards()
        {
            return blackJackContex.PlayingCards;
        }


        public PlayingCard GetPlayingCardById(int id)
        {
            return blackJackContex.PlayingCards.Find(id);
        }


        public void InsertPlayingCard(PlayingCard playingCard)
        {
            blackJackContex.PlayingCards.Add(playingCard);
        }


        public void Save()
        {
            blackJackContex.SaveChanges();
        }
    }
}
