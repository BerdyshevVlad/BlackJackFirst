using BlackJack.Interfaces;
using Entities;
using Mappers;
using Services;
using Services.Interfaces;
using Services.IRepositorys;
using Services.Repositorys;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModels;

namespace BlackJack.Controllers
{
    public class HomeController : Controller
    {

        IGamePlay _gamePlay;
        ISetGame _gameSet;
        IMapper _mapper;
        GameSetService gameSetService;
        public HomeController()
        {
            gameSetService = new GameSetService(new Mapper());
        }

        public HomeController(IGamePlay gamePlay, ISetGame gameSet, IMapper mapper)
        {
            _gamePlay = gamePlay;
            _gameSet = gameSet;
            _mapper = mapper;
        }



        public ActionResult Index()
        {
            List<PlayingCardViewModel> cards=gameSetService.GetDeck();

            return View(cards);
        }

        public ActionResult SetGame()
        {
            
            gameSetService.InitializePlayers();
            gameSetService.SetBotCount(3);

            return View();
        }

        public ActionResult ShowPlayers()
        {
            List<GamePlayerViewModel> players = gameSetService.GetPlayers();

            return View(players);
        }
    }
}