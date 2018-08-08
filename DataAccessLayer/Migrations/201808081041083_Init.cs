namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PlayingCards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CardValue = c.Int(nullable: false),
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
                        Status = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
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
                "dbo.GamePlayerPlayingCards",
                c => new
                    {
                        GamePlayer_Id = c.Int(nullable: false),
                        PlayingCard_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.GamePlayer_Id, t.PlayingCard_Id })
                .ForeignKey("dbo.GamePlayers", t => t.GamePlayer_Id, cascadeDelete: true)
                .ForeignKey("dbo.PlayingCards", t => t.PlayingCard_Id, cascadeDelete: true)
                .Index(t => t.GamePlayer_Id)
                .Index(t => t.PlayingCard_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GamePlayerPlayingCards", "PlayingCard_Id", "dbo.PlayingCards");
            DropForeignKey("dbo.GamePlayerPlayingCards", "GamePlayer_Id", "dbo.GamePlayers");
            DropIndex("dbo.GamePlayerPlayingCards", new[] { "PlayingCard_Id" });
            DropIndex("dbo.GamePlayerPlayingCards", new[] { "GamePlayer_Id" });
            DropTable("dbo.GamePlayerPlayingCards");
            DropTable("dbo.ExceptionDetails");
            DropTable("dbo.GamePlayers");
            DropTable("dbo.PlayingCards");
        }
    }
}
