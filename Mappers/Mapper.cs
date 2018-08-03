using DataAccessLayer.Entities;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Mappers
{
    public class Mapper:IMapper
    {
        public List<PlayingCardViewModel> MappCards(List<PlayingCard> playingCards)
        {
            var cardsViewModelList = new List<PlayingCardViewModel>();
            for (int i = 0; i < playingCards.Count; i++)
            {
                var card = new PlayingCardViewModel();
                card.Id = playingCards[i].Id;
                card.CardValue = playingCards[i].CardValue;
                cardsViewModelList.Add(card);
            }

            return cardsViewModelList;
        }


        public List<GamePlayerViewModel> MappPlayers(List<GamePlayer> gamePlayers)
        {
            var playersViewModelList = new List<GamePlayerViewModel>();
            for (int i = 0; i < gamePlayers.Count; i++)
            {
                var player = new GamePlayerViewModel();
                player.Name = gamePlayers[i].Name;
                player.Score = gamePlayers[i].Score;
                //player.Status = gamePlayers[i].Status;
                player.WinsNumbers = gamePlayers[i].WinsNumbers;
                playersViewModelList.Add(player);
            }

            return playersViewModelList;
        }

    }
}
