using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.IRepositorys
{
    public interface IGamePlayersRepository
    {
        IEnumerable<GamePlayers> GetGamePlayers();
        GamePlayers GetGamePlayerById(int id);
        void InsertGamePlayer(GamePlayers gamePlayer);
        void DeleteGamePlayer(int gamePlayerID);
        void Save();
    }
}
