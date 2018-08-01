using Entities;
using Services.IRepositorys;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Repositorys
{
    public class Repository
    {
        //public IGamePlayersRepository<GamePlayers> gamePlayersRepository { get; set; }
        //public IPlayingCardsRepository<PlayingCard> playingCardsRepository { get; set; }
        
        //test
        public IGenericRepository<PlayingCard> genericPlayingCardsRepository { get; set; }
        public IGenericRepository<GamePlayers> genericGamePlayersRepository { get; set; }


        public Repository()
        {
            //playingCardsRepository = new PlayingCardsRepository<PlayingCard>(new BlackJackContext());
            //gamePlayersRepository = new GamePlayersRepository<GamePlayers>(new BlackJackContext());

            //test
            genericPlayingCardsRepository = new GenericRepository<PlayingCard>(new BlackJackContext());
            genericGamePlayersRepository = new GenericRepository<GamePlayers>(new BlackJackContext());
        }

    }
}
