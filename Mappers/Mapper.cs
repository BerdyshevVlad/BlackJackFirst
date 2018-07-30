using Entities;
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
                card.CardValue = playingCards[i].CardValue;
                cardsViewModelList.Add(card);
            }

            return cardsViewModelList;
        }

    }
}
