using Entities;
using Services.Repositorys;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    class Services
    {
        private Repository _repository;


        public void SetPlayersCount(int playersCount)
        {
            //_repository = new Repository();
            //CardDeck deck = new CardDeck();
            //foreach (var item in _repository.playingCardsRepository.GetPlayingCards())
            //{
            //    deck.Deck.Add(item);
            //}


           
            for (int i = 0; i < playersCount; i++)
            {
                new PlayerBot { Name = $"Bot{i}" };
            }
        }



    }
}
