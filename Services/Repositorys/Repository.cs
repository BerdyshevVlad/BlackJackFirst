using Entities;
using Services.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Repositorys
{
    public class Repository
    {
        public IGamePlayersRepository gamePlayersRepository;
        public IPlayingCardsRepository playingCardsRepository;


        public Repository()
        {
            this.playingCardsRepository = new PlayingCardsRepository(new BlackJackContext());
            this.gamePlayersRepository = new GamePlayersRepository(new BlackJackContext());
        }

    }
}
