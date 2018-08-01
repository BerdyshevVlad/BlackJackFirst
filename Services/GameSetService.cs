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
            SetDeck();
        }


        public GameSetService(IMapper mapper)
        {
            _mapper = mapper;
            SetDeck();
        }

        public void SetBotCount(int playersCount)
        {
            for (int i = 0; i < playersCount; i++)
            {
                
                if (_repository.genericGamePlayersRepository.IsExist($"Bot{i}")==false)
                {
                    _repository.genericGamePlayersRepository.Insert(new PlayerBot { Name = $"Bot{i}" });
                    _repository.genericGamePlayersRepository.Save();
                }
            }
        }


        public List<GamePlayerViewModel> GetPlayers()
        {
            List<GamePlayers> _gamePlayers = new List<GamePlayers>();
            foreach (var item in _repository.genericGamePlayersRepository.Get())
            {
                _gamePlayers.Add(item);
            }

            List<GamePlayerViewModel> gamePlayersViewModelList = _mapper.MappPlayers(_gamePlayers);

            return gamePlayersViewModelList;
        }


        public void InitializePlayers()
        {
            var dealer = new Dealer();
            dealer.Name = "Dealer";
            var playerPerson = new PlayerPerson();
            playerPerson.Name = "You";

            if (_repository.genericGamePlayersRepository.IsExist(dealer.Name) == false && _repository.genericGamePlayersRepository.IsExist(playerPerson.Name) == false)
            {
                _repository.genericGamePlayersRepository.Insert(dealer);
                _repository.genericGamePlayersRepository.Insert(playerPerson);
                _repository.genericGamePlayersRepository.Save();
            }
        }


        public void SetDeck()
        {
            if (_repository.genericPlayingCardsRepository.IsExist() == false)
            {
                var countOfDeckCards = 54;
                for (int i = 0; i < countOfDeckCards; i++)
                {
                    var cardValue = new Random().Next(1, 13);
                    if (cardValue == 11)
                    {
                        cardValue = 1;
                    }
                    if (cardValue == 12)
                    {
                        cardValue = 2;
                    }
                    if (cardValue == 13)
                    {
                        cardValue = 3;
                    }


                    _repository.genericPlayingCardsRepository.Insert(new PlayingCard { CardValue = cardValue });
                    Thread.Sleep(100);
                }
                _repository.genericPlayingCardsRepository.Save();
            }


                //List<PlayingCard> playingCards = new List<PlayingCard>();
                //foreach (var item in _repository.playingCardsRepository.GetPlayingCards())
                //{

                //    playingCards.Add(item);
                //    if (playingCards.Count < 54)
                //        continue;
                //}
                //List<PlayingCardViewModel> playingCardsViewModel = _mapper.MappCards((playingCards as List<PlayingCard>));
                //return playingCardsViewModel;
        }


        public List<PlayingCardViewModel> GetDeck()
        {
            List<PlayingCard> playingCards = new List<PlayingCard>();
            foreach (var item in _repository.genericPlayingCardsRepository.Get())
            {

                playingCards.Add(item);
                if (playingCards.Count < 54)
                    continue;
            }
            List<PlayingCardViewModel> playingCardsViewModel = _mapper.MappCards((playingCards as List<PlayingCard>));
            return playingCardsViewModel;
        }


        public List<PlayingCardViewModel> ReSetDeck()
        {
            foreach (var item in _repository.genericPlayingCardsRepository.Get())
            {
                _repository.genericPlayingCardsRepository.Delete(item);
            }
            SetDeck();
            List<PlayingCardViewModel> playingCardsViewModel = GetDeck();
            return playingCardsViewModel;
        }
    }
}
