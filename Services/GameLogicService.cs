using BlackJack.Interfaces;
using DataAccessLayer.Entities;
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
        private List<GamePlayerViewModel> _gamePlayer = new List<GamePlayerViewModel>();
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


        private static int lastCard=0;
        public async Task<PlayingCardViewModel> DrawCard()
        {
            if (lastCard >= 54)
            {
                lastCard = 0;
            }
            var cardsList = await _repository.genericPlayingCardsRepository.Get();
            PlayingCard card = ((cardsList as List<PlayingCard>)[(cardsList as List<PlayingCard>).ToList().Count - ++lastCard] as PlayingCard);
            PlayingCardViewModel cardModel = new PlayingCardViewModel();
            cardModel = _mapper.MappCards(card);
            _repository.playingCardsRepository.DeletePlayingCard(card.Id);
            _repository.playingCardsRepository.Save();
            Thread.Sleep(100);
            return cardModel;
        }


        public async Task<GamePlayerViewModel> TakeCard(GamePlayer player, PlayingCard playingCard)
        {
            GamePlayer gamePlayer = await _repository.genericGamePlayerRepository.GetById(player.Id);
            gamePlayer.Score += playingCard.CardValue;
            gamePlayer.PlayingCards.Add(playingCard);

            GamePlayerViewModel playerModel = _mapper.MappPlayers(gamePlayer);
            await _repository.genericGamePlayerRepository.Save();
            return playerModel;
        }


        public async Task<List<GamePlayerViewModel>> HandOverCards()
        {
            List<GamePlayerViewModel> playerModelList = null;
            int handOutCardsFirstTime = 2;
            for (int i = 0; i < handOutCardsFirstTime; i++)
            {
                GamePlayerViewModel playerModel = null;
                playerModelList = new List<GamePlayerViewModel>();
                foreach (var item in await _repository.genericGamePlayerRepository.Get())
                {
                    if (item.Score < 17)
                    {
                        PlayingCard card = _mapper.MappCardsViewModel(await DrawCard());
                        playerModel = await TakeCard(item, card);
                        playerModelList.Add(playerModel);
                        Thread.Sleep(200);
                    }
                }
            }
            return playerModelList;
        }


        public async Task Start()
        {

            var t = await HandOverCards();

            //ShowCards();

            ShowTCardsestWithParam(t);
            SHowTestResultWithParam(t);

            //ShowResult();

            //PlayAgain();

            //Winner();
        }


        public async Task<GamePlayerViewModel> ContinueOrDeny(GamePlayer player, PlayingCard card,string yesNo)
        {
            GamePlayerViewModel playerModel = new GamePlayerViewModel();
            if (player.Name == "You" && player.Score < 21 && player.Status != "Stop")
            {
                //Console.WriteLine("Take or no? y/n");
                //string yesOrNo = Console.ReadLine();
                
                string yesOrNo =yesNo;
                if (yesOrNo == "y")
                {
                    playerModel = await TakeCard(player, card);
                }
                if (yesOrNo == "n")
                {
                    player.Status = "Stop";
                    await _repository.genericGamePlayerRepository.Update(player);
                }
            }
            if (player.Name == "You" && player.Score >= 21)
            {
                var playerTmp = await _repository.genericGamePlayerRepository.GetById(player.Id);
                playerTmp.Status = "Stop";
                await _repository.genericGamePlayerRepository.Save();
            }
            if (player.Name != "You" && player.Score < 17)
            {
                playerModel = await TakeCard(player, card);

            }
            if (player.Name != "You" && player.Score >= 17)
            {
                var playerTmp= await _repository.genericGamePlayerRepository.GetById(player.Id);
                playerTmp.Status = "Stop";

                await _repository.genericGamePlayerRepository.Save();
            }

            return playerModel;
        }





        //public async Task PlayAgain()
        //{
        //    for (; ; )
        //    {
        //        var playersList = (await _repository.genericGamePlayerRepository.Get() as List<GamePlayer>).ToList().Where(x => x.Status != "Stop").ToList();
        //        if (playersList.Count <= 0)
        //        {
        //            break;
        //        }

        //        for (int j = 0; j < playersList.Count; j++)
        //        {
        //            PlayingCard card = _mapper.MappCardsViewModel(await DrawCard());
        //            GamePlayerViewModel playerModel = await ContinueOrDeny((playersList)[j], card);
        //        }


        //        ShowCards();
        //        ShowResult();
        //    }
        //}

        public async Task<List<GamePlayerViewModel>> PlayAgain(string yesOrNo)
        {
            List<GamePlayerViewModel> playerModelList= new List<GamePlayerViewModel>();
            if (yesOrNo == "n")
            {
                for (; ; )
                {
                    var playersList = (await _repository.genericGamePlayerRepository.Get() as List<GamePlayer>).ToList().Where(x => x.Status != "Stop").ToList();
                    if (playersList.Count <= 0)
                    {
                        break;
                    }
                    for (int j = 0; j < playersList.Count; j++)
                    {
                        PlayingCard card = _mapper.MappCardsViewModel(await DrawCard());
                        GamePlayerViewModel playerModel = await ContinueOrDeny((playersList)[j], card, yesOrNo);
                    }
                }
            }
            if (yesOrNo == "y")
            {
                var playersList = (await _repository.genericGamePlayerRepository.Get() as List<GamePlayer>).ToList().Where(x => x.Status != "Stop").ToList();
                for (int j = 0; j < playersList.Count; j++)
                {
                    PlayingCard card = _mapper.MappCardsViewModel(await DrawCard());
                    GamePlayerViewModel playerModel = await ContinueOrDeny((playersList)[j], card, yesOrNo);
                }
            }

            playerModelList =_mapper.MappPlayers((await _repository.genericGamePlayerRepository.Get() as List<GamePlayer>));

            return playerModelList;
        }


        public async Task ShowCards()
        {
            Console.WriteLine();
            Console.WriteLine();
            foreach (var item in await _repository.genericGamePlayerRepository.Get())
            {
                Console.Write($"Player: {item.Name}: ");
                foreach (var i in item.PlayingCards)
                {
                    Console.Write($"Card: {i.CardValue}, ");

                }
                Console.WriteLine();
            }
        }

        public void ShowTCardsestWithParam(List<GamePlayerViewModel> playerModel)
        {
            Console.WriteLine();
            Console.WriteLine();
            foreach (var item in playerModel)
            {
                Console.Write($"Player: {item.Name}: ");
                foreach (var i in item.PlayingCards)
                {
                    Console.Write($"Card: {i.CardValue}, ");

                }
                Console.WriteLine();
            }
        }


        public void SHowTestResultWithParam(List<GamePlayerViewModel> playerModel)
        {
            Console.WriteLine();
            Console.WriteLine();
            foreach (var item in playerModel)
            {
                Console.WriteLine($"Player: {item.Name}, Sum: {item.Score}");
            }
        }


        public async Task ShowResult()
        {
            Console.WriteLine();
            Console.WriteLine();
            foreach (var item in await _repository.genericGamePlayerRepository.Get())
            {
                Console.WriteLine($"Player: {item.Name}, Sum: {item.Score}");
            }
        }
    }
}
