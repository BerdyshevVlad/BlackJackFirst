using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace BlackJack.Interfaces
{
    public interface IGamePlay
    {
        Task<PlayingCardViewModel> DrawCard();
        Task<GamePlayerViewModel> TakeCard(GamePlayer player, PlayingCard playingCard);
        Task<List<GamePlayerViewModel>> HandOverCards();
        Task Start();
        Task<GamePlayerViewModel> ContinueOrDeny(GamePlayer player, PlayingCard card,string yesOrNo);
        //Task PlayAgain();
        Task<List<GamePlayerViewModel>> PlayAgain(string yesOrNo);
        //Task ShowCards();
        //void ShowTCardsestWithParam(List<GamePlayerViewModel> playerModel);
        //void SHowTestResultWithParam(List<GamePlayerViewModel> playerModel);
        //Task ShowResult();
    }
}
