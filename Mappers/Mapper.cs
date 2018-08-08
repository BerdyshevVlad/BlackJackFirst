using DataAccessLayer.Entities;
using Services.Interfaces;
using System;
using System.Collections.Generic;
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


        public PlayingCardViewModel MappCards(PlayingCard playingCards)
        {

                var cardModel = new PlayingCardViewModel();
                cardModel.Id = playingCards.Id;
                cardModel.CardValue = playingCards.CardValue;

            return cardModel;
        }


        public List<PlayingCard> MappCardsViewModel(List<PlayingCardViewModel> playingCardsViewModel)
        {
            var cardsList = new List<PlayingCard>();
            for (int i = 0; i < playingCardsViewModel.Count; i++)
            {
                var card = new PlayingCard();
                card.Id = playingCardsViewModel[i].Id;
                card.CardValue = playingCardsViewModel[i].CardValue;
                cardsList.Add(card);
            }

            return cardsList;
        }


        public PlayingCard MappCardsViewModel(PlayingCardViewModel playingCardViewModel)
        {

            var cardModel = new PlayingCard();
            cardModel.Id = playingCardViewModel.Id;
            cardModel.CardValue = playingCardViewModel.CardValue;

            return cardModel;
        }








        public List<GamePlayerViewModel> MappPlayers(List<GamePlayer> gamePlayers)
        {
            var playersViewModelList = new List<GamePlayerViewModel>();
            for (int i = 0; i < gamePlayers.Count; i++)
            {
                var player = new GamePlayerViewModel();
                player.Id = gamePlayers[i].Id;
                player.Name = gamePlayers[i].Name;
                player.Score = gamePlayers[i].Score;
                player.PlayingCards = gamePlayers[i].PlayerCards;
                //player.PlayingCards = gamePlayers[i].PlayingCards;
                player.Status = gamePlayers[i].Status;
                player.WinsNumbers = gamePlayers[i].WinsNumbers;
                playersViewModelList.Add(player);
            }

            return playersViewModelList;
        }


        public List<GamePlayer> MappPlayers(List<GamePlayerViewModel> gamePlayers)
        {
            var playersViewModelList = new List<GamePlayer>();
            for (int i = 0; i < gamePlayers.Count; i++)
            {
                Type type = gamePlayers.GetType();
                object playerModel = Activator.CreateInstance(type);
                (playerModel as GamePlayer).Id = gamePlayers[i].Id;
                (playerModel as GamePlayer).Name = gamePlayers[i].Name;
                (playerModel as GamePlayer).Score = gamePlayers[i].Score;
                foreach (var item in gamePlayers[i].PlayingCards)
                {
                    (playerModel as GamePlayer).PlayerCards.Add(item);
                }
                //(playerModel as GamePlayer).PlayingCards=gamePlayers[i].PlayingCards as  ICollection<PlayingCard>;
                (playerModel as GamePlayer).Status = gamePlayers[i].Status;
                (playerModel as GamePlayer).WinsNumbers = gamePlayers[i].WinsNumbers;
                playersViewModelList.Add(playerModel as GamePlayer);
            }

            return playersViewModelList;
        }

        public GamePlayerViewModel MappPlayers(GamePlayer gamePlayers)
        {
            var player = new GamePlayerViewModel();
            player.Name = gamePlayers.Name;
            player.Score = gamePlayers.Score;
            player.PlayingCards = gamePlayers.PlayerCards;
            //player.PlayingCards = gamePlayers.PlayingCards;
            player.Status = gamePlayers.Status;
            player.WinsNumbers = gamePlayers.WinsNumbers;

            return player;
        }

        //public GamePlayer MappPlayerViewModel(GamePlayerViewModel gamePlayerModel)
        //{
        //        Type type=gamePlayers.GetType();
        //        object playerModel = Activator.CreateInstance(type);
        //        GamePlayer g=new 
        //        (playerModel as GamePlayer).Name = gamePlayerModel.Name;
        //        (playerModel as GamePlayer).Score = gamePlayerModel.Score;
        //        (playerModel as GamePlayer).PlayingCards = gamePlayerModel.PlayingCards;
        //        (playerModel as GamePlayer).Status = gamePlayerModel.Status;
        //        (playerModel as GamePlayer).WinsNumbers = gamePlayerModel.WinsNumbers;

        //    return playerModel as GamePlayer;
        //}

    }
}
