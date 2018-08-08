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
    public class GameSetController : Controller
    {

        IGamePlay _gamePlay;
        ISetGame _gameSet;
        IMapper _mapper;
        GameSetService _gameSetService;
        public GameSetController()
        {
            _gameSetService = new GameSetService(new Mapper());
        }

        public GameSetController(IGamePlay gamePlay, ISetGame gameSet, IMapper mapper)
        {
            _gamePlay = gamePlay;
            _gameSet = gameSet;
            _mapper = mapper;
        }


        public async Task<ActionResult> SetDeck()
        {
            await _gameSetService.SetDeck();
            List<PlayingCardViewModel> cards = await _gameSetService.GetDeck();
            return View(cards);
        }


        public async Task<ActionResult> ReSetDeck()
        {
            await _gameSetService.ReSetDeck();
            List<PlayingCardViewModel> cards = await _gameSetService.GetDeck();
            return View("SetDeck", cards);
        }


        [ExceptionLogger]
        public async Task<ActionResult> SetBotCount()
        {
            try
            {
                await _gameSetService.InitializePlayers();
                await _gameSetService.SetBotCount(3);
            }
            catch(Exception ex)
            {
                return View("Error", new string[] { ex.Message });
            }
            return View();
        }


        public async Task<ActionResult> ShowPlayers()
        {
            List<GamePlayerViewModel> players = await _gameSetService.GetPlayers();

            return View(players);
        }


        public async Task<ActionResult> StartNewGame()
        {
            await _gameSetService.StartNewGame();
            List<PlayingCardViewModel> cards = await _gameSetService.GetDeck();
            return View("SetDeck", cards);
        }
    }
}