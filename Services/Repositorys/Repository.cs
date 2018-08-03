using DataAccessLayer;
using DataAccessLayer.Entities;
using Services.IRepositorys;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Repositorys
{
    public class Repository
    {
        public IGamePlayerRepository GamePlayerRepository { get; set; }
        public IPlayingCardsRepository<PlayingCard> playingCardsRepository { get; set; }

        //test
        public IGenericRepository<PlayingCard> genericPlayingCardsRepository { get; set; }
        public IGenericRepository<GamePlayer> genericGamePlayerRepository { get; set; }


        public Repository()
        {
            playingCardsRepository = new PlayingCardsRepository<PlayingCard>(new BlackJackContext());
            GamePlayerRepository = new GamePlayerRepository(new BlackJackContext());

            //test
            genericPlayingCardsRepository = new GenericRepository<PlayingCard>(new BlackJackContext());
            genericGamePlayerRepository = new GenericRepository<GamePlayer>(new BlackJackContext());
        }

    }
}
