using Entities;
using Services.Interfaces;
using Services.Repositorys;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using ViewModels;

namespace Services
{
    public class GameSetService
    {
        private Repository _repository = new Repository();
        IMapper _mapper;


        public GameSetService()
        {

        }


        public GameSetService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public void SetBotCount(int playersCount)
        {
            for (int i = 0; i < playersCount; i++)
            {
                _repository.gamePlayersRepository.InsertGamePlayer(new PlayerBot { Name = $"Bot{i}" });
                _repository.gamePlayersRepository.Save();
            }
        }


        public List<GamePlayers> GetPlayers()
        {
            List<GamePlayers> _gamePlayers = new List<GamePlayers>();
            foreach (var item in _repository.gamePlayersRepository.GetGamePlayers())
            {
                _gamePlayers.Add(item);
            }
            return _gamePlayers;
        }


        public void InitializePlayers()
        {
            var dealer = new Dealer();
            dealer.Name = "Dealer";
            var playerPerson = new PlayerPerson();
            playerPerson.Name = "You";

            _repository.gamePlayersRepository.InsertGamePlayer(dealer);
            _repository.gamePlayersRepository.InsertGamePlayer(playerPerson);
            _repository.gamePlayersRepository.Save();

        }


        public List<PlayingCardViewModel> SetDeck()
        {
            var countOfDeckCards = 54;
            for (int i = 0; i < countOfDeckCards; i++)
            {
                var cardValue = new Random().Next(1, 13);
                switch (cardValue)
                {
                    case 11:
                        cardValue = 1;
                        break;
                    case 12:
                        cardValue = 2;
                        break;
                    case 3:
                        cardValue = 3;
                        break;
                    default:
                        break;
                }


                _repository.playingCardsRepository.InsertPlayingCard(new PlayingCard { CardValue = cardValue });
                Thread.Sleep(100);
            }
            _repository.playingCardsRepository.Save();

            List<PlayingCard> playingCards = new List<PlayingCard>();
            //List<PlayingCardViewModel> playingCardsViewModel = new List<PlayingCardViewModel>();
            foreach (var item in _repository.playingCardsRepository.GetPlayingCards())
            {

                playingCards.Add(item);
                if (playingCards.Count < 54)
                    continue;
            }
            List<PlayingCardViewModel> tmp= _mapper.MappCards((playingCards as List<PlayingCard>));
            return _mapper.MappCards((playingCards as List<PlayingCard>));
        }
    }
}
