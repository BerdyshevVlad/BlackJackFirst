using Services.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            BlackJackServices.Services services = new BlackJackServices.Services();

            services.SetBotCount(3);
            services.Start();
            //services.ShowCards();
        }
    }
}


