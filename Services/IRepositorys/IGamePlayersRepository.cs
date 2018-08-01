//using Entities;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Services.IRepositorys
//{
//    public interface IGamePlayersRepository<TEntity> where TEntity : class
//    {
//        IEnumerable<TEntity> GetGamePlayers();
//        IEnumerable<TEntity> GetGamePlayers(Func<TEntity, bool> predicate);
//        TEntity GetGamePlayerById(int id);
//        bool IsExistPlayerByName(string name);
//        void InsertGamePlayer(TEntity gamePlayer);
//        void DeleteGamePlayer(TEntity gamePlayer);
//        void Save();
//    }
//}
