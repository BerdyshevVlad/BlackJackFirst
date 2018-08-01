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
        public ITestRepository<PlayingCard> testPlayingCardsRepository { get; set; }
        public ITestRepository<GamePlayers> testGamePlayersRepository { get; set; }


        public Repository()
        {
            //playingCardsRepository = new PlayingCardsRepository<PlayingCard>(new BlackJackContext());
            //gamePlayersRepository = new GamePlayersRepository<GamePlayers>(new BlackJackContext());

            //test
            testPlayingCardsRepository = new TestRepository<PlayingCard>(new BlackJackContext());
            testGamePlayersRepository = new TestRepository<GamePlayers>(new BlackJackContext());
        }

    }
}
