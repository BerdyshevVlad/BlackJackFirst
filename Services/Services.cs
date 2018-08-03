using Services.Repositorys;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;
using DataAccessLayer.Entities;

namespace BlackJackServices
{
    public class Services
    {
        private Repository _repository = new Repository();
        private List<GamePlayer> _gamePlayers = new List<GamePlayer>();
        private List<PlayingCard> playingCards = new List<PlayingCard>();
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
                _repository.GamePlayerRepository.InsertGamePlayer(new PlayerBot { Name = $"Bot{i}",PlayingCards=new List<PlayingCard>()});
                _repository.GamePlayerRepository.Save();
            }
        }


        //public void StartGame()
        //{

        //    GetPlayers();



        //    //for (int i = 0; i < _GamePlayer.Count; i++)
        //    //{
        //    //    for (int j = 0; j < 2; j++)
        //    //    {

        //    //        int card =OneMoreCard();
        //    //        _GamePlayer[i].Score += card;
        //    //        playingCards.RemoveAt(i);


        //    //        if (_GamePlayer[i].Score == 11)
        //    //        {
        //    //            Console.WriteLine($"Player: { _GamePlayer[i].Name}, Score: Jack");
        //    //        }
        //    //        else if (_GamePlayer[i].Score == 12)
        //    //        {
        //    //            Console.WriteLine($"Player: { _GamePlayer[i].Name}, Score: Queen");
        //    //        }
        //    //        else if (_GamePlayer[i].Score == 13)
        //    //        {
        //    //            Console.WriteLine($"Player: { _GamePlayer[i].Name}, Score: King");
        //    //        }
        //    //        else
        //    //            Console.WriteLine($"Player: { _GamePlayer[i].Name}, Score: { card}");
        //    //    }
        //    //    Console.WriteLine();
        //    //}




        //    PlayAgain();
        //    Winner();

        //}



        //public int TakeCard()
        //{
        //    int card = (playingCards[new Random().Next(0, playingCards.Count)] as PlayingCard).CardValue;
        //    return card;
        //}


        
        public PlayingCard DrawCard()
        {
            PlayingCard card = (playingCards[GetCards().Count-1] as PlayingCard);
            _repository.playingCardsRepository.DeletePlayingCard(card.Id);
            _repository.playingCardsRepository.Save();
            Thread.Sleep(200);
            return card;
        }


        public void TakeCard(GamePlayer player,PlayingCard playingCard)
        {
            var playerModel = _repository.GamePlayerRepository.GetGamePlayerById(player.Id);
            playerModel.Score += playingCard.CardValue;
            (_repository.GamePlayerRepository.GetGamePlayerById(player.Id).PlayingCards as List<PlayingCard>).Add(playingCard);
            _repository.GamePlayerRepository.Save();
        }


        public void Start()
        {
            for (int i = 0; i < 2; i++)
            {
                foreach (var item in _repository.GamePlayerRepository.GetGamePlayer())
                {
                    if (item.Score < 17)
                    {
                        PlayingCard card = DrawCard();
                        TakeCard(item,card);
                        Thread.Sleep(200);
                    }
                    //if (item.Name == "You" && item.Score < 21)
                    //{
                    //    Console.WriteLine("Take or no? y/n");
                    //    string yesOrNo = Console.ReadLine();
                    //    if (yesOrNo == "y")
                    //    {
                    //        PlayingCard card = DrawCard();
                    //        TakeCard(item,card);
                    //        item.Status = "Stop";
                    //    }
                    //}
                }
            }
            ShowCards();
            ShowResult();
        }


        //public void ContinueOrDeny(GamePlayer player, PlayingCard card)
        //{
        //    Console.WriteLine("Take or no? y/n");
        //    string yesOrNo = Console.ReadLine();
        //    if (yesOrNo == "y")
        //    {
        //        TakeCard(player,);
        //    }
        //}


        //public void PlayAgain()
        //{
        //    int tmp = 0;
        //    for (int i = 0; tmp < _GamePlayer.Count - 1; i++)
        //    {
        //        ShowCards();
        //        foreach (var item in _GamePlayer)
        //        {
        //            if (item.Score < 17 && item.Name != "You")
        //            {
        //                item.Score += TakeCard();
        //                Console.WriteLine($"Player:{item.Name}, score: {item.Score}");
        //                Thread.Sleep(100);
        //            }
        //            else if (item.Status != "Stop" && item.Score >= 17 && item.Name != "You")
        //            {
        //                item.Status = "Stop";
        //                tmp++;
        //            }
        //            else if (item.Name == "You" && item.Score < 21)
        //            {
        //                Console.WriteLine("Take or no? y/n");
        //                string yesOrNo = Console.ReadLine();
        //                if (yesOrNo == "y")
        //                {
        //                    item.Score += TakeCard();
        //                    item.Status = "Stop";
        //                }
        //                else
        //                {
        //                    continue;
        //                }
        //            }
        //        }

        //    }
        //}


        public void Winner()
        {
            int max = _gamePlayers.Where(x => x.Score <= 21).Max(x => x.Score);
            Console.WriteLine("Winners: ");
            foreach (var item in _gamePlayers)
            {
                if (item.Score == max)
                {
                    Console.WriteLine($"Player: { item.Name} have won!");
                }
            }
        }


        public void ShowCards()
        {
            Console.WriteLine();
            Console.WriteLine();
            foreach (var item in _repository.GamePlayerRepository.GetGamePlayer())
            {
                Console.Write($"Player: {item.Name}: ");
                foreach (var i in item.PlayingCards)
                {
                    Console.Write($"Card: {i.CardValue}, ");
                    
                }
                Console.WriteLine();
            }
        }


        public void ShowResult()
        {
            Console.WriteLine();
            Console.WriteLine();
            foreach (var item in _repository.GamePlayerRepository.GetGamePlayer())
            {
                Console.WriteLine($"Player: {item.Name}, Sum: {item.Score}");
            }
        }


        private List<GamePlayer> GetPlayers()
        {
            foreach (var item in _repository.GamePlayerRepository.GetGamePlayer())
            {
                _gamePlayers.Add(item);
            }
            return _gamePlayers;
        }


        private List<PlayingCard> GetCards()
        {
            foreach (var item in _repository.playingCardsRepository.GetPlayingCards())
            {
                playingCards.Add(item);
            }
            return playingCards;
        }


        private void InitializePlayers()
        {
            var dealer = new Dealer();
            dealer.Name = "Dealer";
            var playerPerson = new PlayerPerson();
            playerPerson.Name = "You";
            dealer.PlayingCards = new List<PlayingCard>();
            playerPerson.PlayingCards = new List<PlayingCard>();
            _repository.GamePlayerRepository.InsertGamePlayer(dealer);
            _repository.GamePlayerRepository.InsertGamePlayer(playerPerson);
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

        //public void Clear()
        //{
        //    foreach (var item in _repository.playingCardsRepository.GetPlayingCards())
        //    {
        //        _repository.playingCardsRepository.DeletePlayingCard(item.Id);
        //    }

        //    foreach (var item in _repository.GamePlayerRepository.GetGamePlayer())
        //    {
        //        _repository.GamePlayerRepository.DeleteGamePlayer(item.Id);
        //    }
        //}

    }
}
