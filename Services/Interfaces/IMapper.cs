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
        PlayingCardViewModel MappCards(PlayingCard playingCards);
        List<PlayingCard> MappCardsViewModel(List<PlayingCardViewModel> playingCardsViewModel);
        PlayingCard MappCardsViewModel(PlayingCardViewModel playingCardViewModel);
        //GamePlayer MappPlayerViewModel(GamePlayerViewModel gamePlayers);
        List<GamePlayerViewModel> MappPlayers(List<GamePlayer> gamePlayers);
        GamePlayerViewModel MappPlayers(GamePlayer gamePlayers);
    }
}
