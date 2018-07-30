using Entities;
using Services.Repositorys;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;

namespace BlackJackServices
{
    public class Services
    {
        private Repository _repository = new Repository();
        private List<GamePlayers> _gamePlayers = new List<GamePlayers>();
        private ArrayList playingCards = new ArrayList();
        //private CardDeck playingCards = new CardDeck();


        public Services()
        {
            InitializePlayers();
            SetDeck();
        }


        public void SetBotCount(int playersCount)
        {           
            for (int i = 0; i < playersCount; i++)
            {
                _repository.gamePlayersRepository.InsertGamePlayer(new PlayerBot { Name = $"Bot{i}" });
                _repository.gamePlayersRepository.Save();
            }
        }


        public void StartGame()
        {

            GetPlayers();

            for (int i = 0; i <_gamePlayers.Count; i++)
            {
                for (int j = 0; j < 2; j++)
                {

                    int card = (playingCards[new Random().Next(0, playingCards.Count)] as PlayingCard).CardValue;
                    _gamePlayers[i].Score += card;
                    playingCards.RemoveAt(i);
                    //int card = (playingCards.Deck[new Random().Next(0, playingCards.Deck.Count)] as PlayingCard).CardValue;
                    //_gamePlayers[i].Score += card;
                    //playingCards.Deck.RemoveAt(i);


                    if (_gamePlayers[i].Score == 11) {
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

            PlayAgain();
            Winner();

        }



        public int OneMoreCard()
        {
            int card = (playingCards[new Random().Next(0, playingCards.Count)] as PlayingCard).CardValue;
            //int card = (playingCards.Deck[new Random().Next(0, playingCards.Deck.Count)] as PlayingCard).CardValue;
            return card;
        }


        public void PlayAgain()
        {
            int tmp = 0;
            for (int i = 0; tmp < _gamePlayers.Count-1; i++)
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
                    else if(item.Status!="Stop" && item.Score >= 17 && item.Name != "You")
                    {
                        item.Status = "Stop";
                        tmp++;
                    }
                    else if(item.Name=="You" && item.Score < 21)
                    {
                        Console.WriteLine("Take or no? y/n");
                        string yesOrNo=Console.ReadLine();
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


        public void Winner()
        {
            int max=_gamePlayers.Where(x=>x.Score<=21).Max(x=>x.Score);
            Console.WriteLine("Winners: ");
            foreach (var item in _gamePlayers)
            {
                if (item.Score == max)
                {
                    Console.WriteLine($"Player: { item.Name} has won!");
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

        
        private List<GamePlayers> GetPlayers()
        {
            foreach (var item in _repository.gamePlayersRepository.GetGamePlayers())
            {
                _gamePlayers.Add(item);
            }
            return _gamePlayers;
        }

        private void InitializePlayers()
        {
            var dealer = new Dealer();
            dealer.Name = "Dealer";
            var playerPerson = new PlayerPerson();
            playerPerson.Name = "You";

            _repository.gamePlayersRepository.InsertGamePlayer(dealer);
            _repository.gamePlayersRepository.InsertGamePlayer(playerPerson);
        }


        private void SetDeck()
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


                _repository.playingCardsRepository.InsertPlayingCard(new PlayingCard { CardValue = cardValue });
                Thread.Sleep(100);
            }
            _repository.playingCardsRepository.Save();

            foreach (var item in _repository.playingCardsRepository.GetPlayingCards())
            {

                playingCards.Add(item);
                if (playingCards.Count > 54)
                    break;
            }
        }

        public void Clear()
        {
            foreach (var item in _repository.playingCardsRepository.GetPlayingCards())
            {
                _repository.playingCardsRepository.DeletePlayingCard(item.Id);
            }

            foreach (var item in _repository.gamePlayersRepository.GetGamePlayers())
            {
                _repository.gamePlayersRepository.DeleteGamePlayer(item.Id);
            }
        }

    }
}
