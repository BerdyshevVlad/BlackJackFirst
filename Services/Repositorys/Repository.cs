using Entities;
using Services.IRepositorys;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Repositorys
{
    public class Repository
    {
        public IGamePlayersRepository gamePlayersRepository { get; set; }
        public IPlayingCardsRepository playingCardsRepository { get; set; }


        public Repository()
        {
            playingCardsRepository = new PlayingCardsRepository(new BlackJackContext());
            gamePlayersRepository = new GamePlayersRepository(new BlackJackContext());
        }

    }
}
