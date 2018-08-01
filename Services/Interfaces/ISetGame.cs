using Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Interfaces
{
    public interface ISetGame 
    {

        void SetBotCount(int playersCount);
        List<GamePlayers> GetPlayers();
        void InitializePlayers();
        ArrayList SetDeck();
    }
}
