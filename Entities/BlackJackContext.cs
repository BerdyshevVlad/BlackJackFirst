using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Text;

namespace Entities
{
    public class BlackJackContext: DbContext
    {

        static BlackJackContext()
        {
            //Database.SetInitializer<BlackJackContext>(new BlackJackDbInitializer());
            Database.SetInitializer<BlackJackContext>(new MigrateDatabaseToLatestVersion<BlackJackContext, Configuration>());
        }

        public BlackJackContext() : base("BlackJackContext")
        { }
        public DbSet<GamePlayers> Players { get; set; }
        public DbSet<PlayingCard> PlayingCards { get; set; }
        public DbSet<ExceptionDetail> ExceptionDetails { get; set; }
    }

    //public class BlackJackDbInitializer : DropCreateDatabaseAlways<BlackJackContext>
    //{
    //    protected override void Seed(BlackJackContext context)
    //    {
    //    }
    //}




    public class BlackJackDbInitializer : MigrateDatabaseToLatestVersion<BlackJackContext, Configuration>
    { }

    public sealed class Configuration : DbMigrationsConfiguration<BlackJackContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(BlackJackContext context)
        {

        }
    }
}
