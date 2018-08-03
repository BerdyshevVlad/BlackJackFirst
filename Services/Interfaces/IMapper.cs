using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModels;

namespace Services.Interfaces
{
    public interface IMapper
    {
        List<PlayingCardViewModel> MappCards(List<PlayingCard> playingCards);
        List<GamePlayerViewModel> MappPlayers(List<GamePlayer> gamePlayers);
    }
}
