using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace Entities
{
    public class BlackJackContext: DbContext
    {
        public BlackJackContext() : base("BlackJackContext")
        { }
        public DbSet<GamePlayers> Players { get; set; }
        public DbSet<PlayingCard> PlayingCards { get; set; }
    }
}
