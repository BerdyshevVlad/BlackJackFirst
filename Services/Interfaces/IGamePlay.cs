﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Interfaces
{
    public interface IGamePlay
    {
        Task StartGame();
        int OneMoreCard();
        void PlayAgain();
        void ShowCards();
        void Winner();
    }
}
