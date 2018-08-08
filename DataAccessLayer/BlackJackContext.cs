using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class BlackJackContext : DbContext
    {

        static BlackJackContext()
        {
            Database.SetInitializer<BlackJackContext>(new BlackJackDbInitializer());
            //Database.SetInitializer<BlackJackContext>(new MigrateDatabaseToLatestVersion<BlackJackContext, Configuration>());
        }

        public BlackJackContext() : base("BlackJackContext")
        { }
        public DbSet<GamePlayer> Players { get; set; }
        public DbSet<PlayingCard> Cards { get; set; }
        public DbSet<ExceptionDetail> ExceptionDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

    public class BlackJackDbInitializer : DropCreateDatabaseAlways<BlackJackContext>
    {
        protected override void Seed(BlackJackContext context)
        {
        }
    }




    //public class BlackJackDbInitializer : MigrateDatabaseToLatestVersion<BlackJackContext, Configuration>
    //{ }

    //public sealed class Configuration : DbMigrationsConfiguration<BlackJackContext>
    //{
    //    public Configuration()
    //    {
    //        AutomaticMigrationsEnabled = true;
    //    }

    //    protected override void Seed(BlackJackContext context)
    //    {

    //    }
    //}
}
