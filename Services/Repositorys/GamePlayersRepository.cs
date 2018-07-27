using Entities;
using Services.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Repositorys
{
    class GamePlayersRepository : IGamePlayersRepository
    {
        private BlackJackContext blackJackContex;

        public GamePlayersRepository(BlackJackContext blackJackContext)
        {
            this.blackJackContex = blackJackContext;
        }


        public void DeleteGamePlayer(int gamePlayerID)
        {
            GamePlayers gamePlayers = blackJackContex.Players.Find(gamePlayerID);
            blackJackContex.Players.Remove(gamePlayers);
        }


        public GamePlayers GetGamePlayerById(int id)
        {
            return blackJackContex.Players.Find(id);
        }


        public IEnumerable<GamePlayers> GetGamePlayers()
        {
            return blackJackContex.Players;
        }


        public void InsertGamePlayer(GamePlayers gamePlayer)
        {
            blackJackContex.Players.Add(gamePlayer);
        }


        public void Save()
        {
            blackJackContex.SaveChanges();
        }
    }
}
