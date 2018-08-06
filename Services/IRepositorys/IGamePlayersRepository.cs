using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.IRepositorys
{
    public interface IGamePlayerRepository
    {
        IEnumerable<GamePlayer> GetGamePlayer();
        IEnumerable<GamePlayer> GetGamePlayer(Func<GamePlayer, bool> predicate);
        GamePlayer GetGamePlayerById(int id);
        bool IsExistPlayerByName(string name);
        void InsertGamePlayer(GamePlayer gamePlayer);
        void DeleteGamePlayer(GamePlayer gamePlayer);
        void Update(GamePlayer item);
        void Save();
    }
}
