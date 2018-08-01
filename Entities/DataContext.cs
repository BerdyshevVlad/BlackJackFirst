using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace Entities
{
    public class BlackJackContext: DbContext
    {

        static BlackJackContext()
        {
            Database.SetInitializer<BlackJackContext>(new BlackJackDbInitializer());
        }

        public BlackJackContext() : base("BlackJackContext")
        { }
        public DbSet<GamePlayers> Players { get; set; }
        public DbSet<PlayingCard> PlayingCards { get; set; }
    }

    public class BlackJackDbInitializer : DropCreateDatabaseAlways<BlackJackContext>
    {
        protected override void Seed(BlackJackContext db)
        {
           

        }

    }
}
