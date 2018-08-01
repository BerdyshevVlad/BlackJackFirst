using BlackJack.Interfaces;
using Entities;
using Services.Repositorys;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ViewModels;

namespace Services
{
    public class GameLogicService: IGamePlay
    {

        private List<PlayingCardViewModel> _playingCards = new List<PlayingCardViewModel>();
        private List<GamePlayerViewModel> _gamePlayers = new List<GamePlayerViewModel>();
        private GameSetService _gameSet = new GameSetService();
        private Repository _repository = new Repository();


        public GameLogicService()
        {
            //_gameSet.InitializePlayers();
            //_playingCards=_gameSet.SetDeck();
            //_gamePlayers = _gameSet.GetPlayers();
        }

        public async Task StartGame()
        {

            _gamePlayers = await _gameSet.GetPlayers();

            for (int i = 0; i < _gamePlayers.Count; i++)
            {
                for (int j = 0; j < 2; j++)
                {

                    int card = (_playingCards[new Random().Next(0, _playingCards.Count)] as PlayingCardViewModel).CardValue;
                    _gamePlayers[i].Score += card;
                    _playingCards.RemoveAt(i);


                    if (_gamePlayers[i].Score == 11)
                    {
                        Console.WriteLine($"Player: { _gamePlayers[i].Name}, Score: Jack");
                    }
                    else if (_gamePlayers[i].Score == 12)
                    {
                        Console.WriteLine($"Player: { _gamePlayers[i].Name}, Score: Queen");
                    }
                    else if (_gamePlayers[i].Score == 13)
                    {
                        Console.WriteLine($"Player: { _gamePlayers[i].Name}, Score: King");
                    }
                    else
                        Console.WriteLine($"Player: { _gamePlayers[i].Name}, Score: { card}");
                }
                Console.WriteLine();
            }

            foreach (var item in _repository.genericGamePlayersRepository.Get().Result)///////////////////////////////////////////
            {
                _repository.genericGamePlayersRepository.Delete(item);

            }

            //foreach (var item in _gamePlayers)
            //{
            //    _repository.gamePlayersRepository.InsertGamePlayer(item);
            //    Thread.Sleep(100);
            //}

            PlayAgain();
            Winner();

        }


        public int OneMoreCard()
        {
            int card = (_playingCards[new Random().Next(0, _playingCards.Count)] as PlayingCardViewModel).CardValue;
            return card;
        }


        public void PlayAgain()
        {
            int tmp = 0;
            for (int i = 0; tmp < _gamePlayers.Count - 1; i++)
            {
                ShowCards();
                foreach (var item in _gamePlayers)
                {
                    if (item.Score < 17 && item.Name != "You")
                    {
                        item.Score += OneMoreCard();
                        Console.WriteLine($"Player:{item.Name}, score: {item.Score}");
                        Thread.Sleep(100);
                    }
                    else if (item.Status != "Stop" && item.Score >= 17 && item.Name != "You")
                    {
                        item.Status = "Stop";
                        tmp++;
                    }
                    else if (item.Name == "You" && item.Score < 21)
                    {
                        Console.WriteLine("Take or no? y/n");
                        string yesOrNo = Console.ReadLine();
                        if (yesOrNo == "y")
                        {
                            item.Score += OneMoreCard();
                            item.Status = "Stop";
                        }
                        else
                        {
                            continue;
                        }
                    }
                }

            }
        }


        public void ShowCards()
        {
            Console.WriteLine();
            Console.WriteLine();
            foreach (var item in _gamePlayers)
            {
                Console.WriteLine($"Player: {item.Name}, Sum: {item.Score}");
            }
        }


        public void Winner()
        {

            int max = _gamePlayers.Where(x => x.Score <= 21).Max(x => x.Score);
            Console.WriteLine("Winners: ");
            foreach (var item in _gamePlayers)
            {
                if (item.Score == max)
                {
                    Console.WriteLine($"Player: { item.Name} has won!");
                }
            }
        }
    }
}
