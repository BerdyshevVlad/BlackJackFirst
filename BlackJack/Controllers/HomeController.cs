using BlackJack.Filters;
using BlackJack.Interfaces;
using Mappers;
using Services;
using Services.Interfaces;
using Services.IRepositorys;
using Services.Repositorys;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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



        public async Task<ActionResult> Index()
        {
            await gameSetService.SetDeck();
            List<PlayingCardViewModel> cards = await gameSetService.GetDeck();
            return View(cards);
        }


        [ExceptionLogger]
        public async Task<ActionResult> SetGame()
        {
            try
            {
                await gameSetService.InitializePlayers();
                await gameSetService.SetBotCount(3);
            }
            catch(Exception ex)
            {
                return View("Error", new string[] { ex.Message });
            }
            return View();
        }

        public async Task<ActionResult> ShowPlayers()
        {
            List<GamePlayerViewModel> players = await gameSetService.GetPlayers();

            return View(players);
        }
    }
}