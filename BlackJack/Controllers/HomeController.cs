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

        public HomeController()
        {

        }

        public HomeController(IGamePlay gamePlay,ISetGame gameSet,IMapper mapper)
        {
            _gamePlay = gamePlay;
            _gameSet = gameSet;
            _mapper = mapper;
        }



        public ActionResult Index()
        {
            GameSetService gameSetService = new GameSetService(new Mapper());
            List<PlayingCardViewModel> cards=gameSetService.SetDeck();

            return View(cards);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}