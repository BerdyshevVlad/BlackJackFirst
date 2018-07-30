using Entities;
using Services.IRepositorys;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Repositorys
{
    class GamePlayersRepository : IGamePlayersRepository
    {
        private BlackJackContext _blackJackContex;

        public GamePlayersRepository(BlackJackContext blackJackContext)
        {
            this._blackJackContex = blackJackContext;
        }


        public void DeleteGamePlayer(int gamePlayerID)
        {
            GamePlayers gamePlayers = _blackJackContex.Players.Find(gamePlayerID);
            _blackJackContex.Players.Remove(gamePlayers);
        }


        public GamePlayers GetGamePlayerById(int id)
        {
            return _blackJackContex.Players.Find(id);
        }


        public IEnumerable<GamePlayers> GetGamePlayers()
        {
            return _blackJackContex.Players;
        }


        public void InsertGamePlayer(GamePlayers gamePlayer)
        {
            _blackJackContex.Players.Add(gamePlayer);
        }


        public void Save()
        {
            _blackJackContex.SaveChanges();
        }
    }
}
