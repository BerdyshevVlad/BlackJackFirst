using Mappers;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ViewModels;

namespace BlackJack.Controllers
{
    public class GameLogicController : Controller
    {
        GameLogicService _gameLogic;
        public GameLogicController()
        {
            _gameLogic = new GameLogicService(new Mapper());
        }


        [HttpGet]
        public async Task<ActionResult> HandOverCards()
        {
            List <GamePlayerViewModel> playersModel=await _gameLogic.HandOverCards();
            return View(playersModel);
        }


        [HttpPost]
        public async Task<ActionResult> PlayAgain(string yesOrNo)
        {
            List<GamePlayerViewModel> playersModel = await _gameLogic.PlayAgain(yesOrNo);
            return Json(playersModel, JsonRequestBehavior.AllowGet);
        }


        public async Task<ActionResult> Winner()
        {
            List<GamePlayerViewModel> playersModel = await _gameLogic.Winner();
            return View(playersModel);
        }

    }
}