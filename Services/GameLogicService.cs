using BlackJack.Interfaces;
using Services.Interfaces;
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
        private List<GamePlayerViewModel> _GamePlayer = new List<GamePlayerViewModel>();
        private GameSetService _gameSet = new GameSetService();
        private Repository _repository = new Repository();
        private IMapper _mapper;


        public GameLogicService()
        {
            //_gameSet.InitializePlayers();
            //_playingCards=_gameSet.SetDeck();
            //_GamePlayer = _gameSet.GetPlayers();
        }


        public GameLogicService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task StartGame()
        {

            _GamePlayer = await _gameSet.GetPlayers();

            for (int i = 0; i < _GamePlayer.Count; i++)
            {
                for (int j = 0; j < 2; j++)
                {

                    //int card = (_playingCards[new Random().Next(0, _playingCards.Count)] as PlayingCardViewModel).CardValue;
                    int card = OneMoreCard();
                    _GamePlayer[i].Score += card;
                    _playingCards.RemoveAt(i);


                    if (_GamePlayer[i].Score == 11)
                    {
                        Console.WriteLine($"Player: { _GamePlayer[i].Name}, Score: Jack");
                    }
                    else if (_GamePlayer[i].Score == 12)
                    {
                        Console.WriteLine($"Player: { _GamePlayer[i].Name}, Score: Queen");
                    }
                    else if (_GamePlayer[i].Score == 13)
                    {
                        Console.WriteLine($"Player: { _GamePlayer[i].Name}, Score: King");
                    }
                    else
                        Console.WriteLine($"Player: { _GamePlayer[i].Name}, Score: { card}");
                }
                Console.WriteLine();
            }

            foreach (var item in await _repository.genericGamePlayerRepository.Get())
            {
                await _repository.genericGamePlayerRepository.Delete(item.Id);

            }

            //foreach (var item in _GamePlayer)
            //{
            //    _repository.GamePlayerRepository.InsertGamePlayer(item);
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
            //int tmp = 0;
            //for (int i = 0; tmp < _GamePlayer.Count - 1; i++)
            //{
            //    ShowCards();
            //    foreach (var item in _GamePlayer)
            //    {
            //        if (item.Score < 17 && item.Name != "You")
            //        {
            //            item.Score += OneMoreCard();
            //            Console.WriteLine($"Player:{item.Name}, score: {item.Score}");
            //            Thread.Sleep(100);
            //        }
            //        else if (item.Status != "Stop" && item.Score >= 17 && item.Name != "You")
            //        {
            //            item.Status = "Stop";
            //            tmp++;
            //        }
            //        else if (item.Name == "You" && item.Score < 21)
            //        {
            //            Console.WriteLine("Take or no? y/n");
            //            string yesOrNo = Console.ReadLine();
            //            if (yesOrNo == "y")
            //            {
            //                item.Score += OneMoreCard();
            //                item.Status = "Stop";
            //            }
            //            else
            //            {
            //                continue;
            //            }
            //        }
            //    }
            //}
        }


        public void ShowCards()
        {
            Console.WriteLine();
            Console.WriteLine();
            foreach (var item in _GamePlayer)
            {
                Console.WriteLine($"Player: {item.Name}, Sum: {item.Score}");
            }
        }


        public void Winner()
        {
            int max = _GamePlayer.Where(x => x.Score <= 21).Max(x => x.Score);
            Console.WriteLine("Winners: ");
            foreach (var item in _GamePlayer)
            {
                if (item.Score == max)
                {
                    Console.WriteLine($"Player: { item.Name} has won!");
                }
            }
        }
    }
}
