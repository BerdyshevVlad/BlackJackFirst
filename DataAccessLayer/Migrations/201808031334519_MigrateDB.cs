namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExceptionDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExceptionMessage = c.String(),
                        ControllerName = c.String(),
                        ActionName = c.String(),
                        StackTrace = c.String(),
                        Date = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GamePlayers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Score = c.Int(nullable: false),
                        WinsNumbers = c.Int(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PlayingCards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CardValue = c.Int(nullable: false),
                        GamePlayerId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GamePlayers", t => t.GamePlayerId)
                .Index(t => t.GamePlayerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PlayingCards", "GamePlayerId", "dbo.GamePlayers");
            DropIndex("dbo.PlayingCards", new[] { "GamePlayerId" });
            DropTable("dbo.PlayingCards");
            DropTable("dbo.GamePlayers");
            DropTable("dbo.ExceptionDetails");
        }
    }
}
