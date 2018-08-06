using Mappers;

namespace BlackJackConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            BlackJackServices.Services services = new BlackJackServices.Services(new Mapper());

            services.SetBotCount(3);
            services.Start();
        }
    }
}


