using Services.Interfaces;
using Services.Repositorys;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using ViewModels;
using System.IO;
using System.Threading.Tasks;
using DataAccessLayer.Entities;

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


        public async Task SetBotCount(int playersCount)
        {
            //throw new Exception("MY");
            try
            {
                for (int i = 0; i < playersCount; i++)
                {

                    if (_repository.genericGamePlayerRepository.IsExist($"Bot{i}") == false)
                    {
                        await _repository.genericGamePlayerRepository.Insert(new PlayerBot { Name = $"Bot{i}" });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<List<GamePlayerViewModel>> GetPlayers()
        {
            List<GamePlayerViewModel> GamePlayerViewModelList;
            List<GamePlayer> _GamePlayer = new List<GamePlayer>();
            try
            {
                foreach (var item in await _repository.genericGamePlayerRepository.Get())
                //foreach (var item in _repository.genericGamePlayerRepository.GetPlayers())
                {
                    _GamePlayer.Add(item);
                }

                GamePlayerViewModelList = _mapper.MappPlayers(_GamePlayer);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return GamePlayerViewModelList;
        }


        public async Task InitializePlayers()
        {
            var dealer = new Dealer();
            dealer.Name = "Dealer";
            var playerPerson = new PlayerPerson();
            playerPerson.Name = "You";

            try
            {
                if (_repository.genericGamePlayerRepository.IsExist(dealer.Name) == false && _repository.genericGamePlayerRepository.IsExist(playerPerson.Name) == false)
                {
                    await _repository.genericGamePlayerRepository.Insert(dealer);
                    await _repository.genericGamePlayerRepository.Insert(playerPerson);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task SetDeck()
        {
            try
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

                        await _repository.genericPlayingCardsRepository.Insert(new PlayingCard { CardValue = cardValue });
                        Thread.Sleep(100);
                    }
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<List<PlayingCardViewModel>> GetDeck()
        {
            List<PlayingCard> playingCards = new List<PlayingCard>();
            List<PlayingCardViewModel> playingCardsViewModel;
            try
            {
                foreach (var item in await _repository.genericPlayingCardsRepository.Get())
                {

                    playingCards.Add(item);
                    if (playingCards.Count < 54)
                        continue;
                }
                playingCardsViewModel = _mapper.MappCards((playingCards as List<PlayingCard>));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return playingCardsViewModel;
        }


        public async Task<List<PlayingCardViewModel>> ReSetDeck()
        {
            List<PlayingCardViewModel> playingCardsViewModel;
            try
            {
                //var tmp = await Task.WhenAll(_repository.genericPlayingCardsRepository.Get());
                var playingCardList = await _repository.genericPlayingCardsRepository.Get();

                foreach (var item in playingCardList)
                {
                    await _repository.genericPlayingCardsRepository.Delete(item.Id);
                }

                await SetDeck();
                playingCardsViewModel = await GetDeck();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return playingCardsViewModel;
        }
    }
}
