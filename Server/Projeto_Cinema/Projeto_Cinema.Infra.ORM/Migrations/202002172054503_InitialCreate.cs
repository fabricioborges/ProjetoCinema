namespace Projeto_Cinema.Infra.ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TbMovies",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Image = c.String(nullable: false),
                        Title = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        DebutDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Duration = c.Time(nullable: false, precision: 7),
                        AnimationType = c.Int(nullable: false),
                        TypeAudio = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TbMovieTheaters",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TbSeats",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        IsAvailable = c.Boolean(nullable: false),
                        MovieTheater_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TbMovieTheaters", t => t.MovieTheater_Id)
                .Index(t => t.MovieTheater_Id);
            
            CreateTable(
                "dbo.TbSessions",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        DateInitial = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Hour = c.DateTime(nullable: false),
                        MovieId = c.Long(nullable: false),
                        MovieTheaterId = c.Long(nullable: false),
                        Duration = c.Time(nullable: false, precision: 7),
                        AnimationType = c.Int(nullable: false),
                        TypeAudio = c.Int(nullable: false),
                        ValueOfSeats = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TbMovies", t => t.MovieId, cascadeDelete: true)
                .ForeignKey("dbo.TbMovieTheaters", t => t.MovieTheaterId, cascadeDelete: true)
                .Index(t => t.MovieId)
                .Index(t => t.MovieTheaterId);
            
            CreateTable(
                "dbo.TbSnacks",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Image = c.String(nullable: false),
                        Price = c.Double(nullable: false),
                        Quantity = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TbTickets",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        UserId = c.Long(),
                        MovieId = c.Long(),
                        MovieTheaterId = c.Long(),
                        SessionId = c.Long(),
                        DateBuy = c.DateTime(nullable: false),
                        Value = c.Double(nullable: false),
                        IsConfirmed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TbMovies", t => t.MovieId)
                .ForeignKey("dbo.TbMovieTheaters", t => t.MovieTheaterId)
                .ForeignKey("dbo.TbSessions", t => t.SessionId)
                .ForeignKey("dbo.TbUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.MovieId)
                .Index(t => t.MovieTheaterId)
                .Index(t => t.SessionId);
            
            CreateTable(
                "dbo.TbUsers",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        AccessLevel = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TicketSnacks",
                c => new
                    {
                        TickeId = c.Long(nullable: false),
                        SnackId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.TickeId, t.SnackId })
                .ForeignKey("dbo.TbTickets", t => t.TickeId, cascadeDelete: true)
                .ForeignKey("dbo.TbSnacks", t => t.SnackId, cascadeDelete: true)
                .Index(t => t.TickeId)
                .Index(t => t.SnackId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TbTickets", "UserId", "dbo.TbUsers");
            DropForeignKey("dbo.TicketSnacks", "SnackId", "dbo.TbSnacks");
            DropForeignKey("dbo.TicketSnacks", "TickeId", "dbo.TbTickets");
            DropForeignKey("dbo.TbTickets", "SessionId", "dbo.TbSessions");
            DropForeignKey("dbo.TbTickets", "MovieTheaterId", "dbo.TbMovieTheaters");
            DropForeignKey("dbo.TbTickets", "MovieId", "dbo.TbMovies");
            DropForeignKey("dbo.TbSessions", "MovieTheaterId", "dbo.TbMovieTheaters");
            DropForeignKey("dbo.TbSessions", "MovieId", "dbo.TbMovies");
            DropForeignKey("dbo.TbSeats", "MovieTheater_Id", "dbo.TbMovieTheaters");
            DropIndex("dbo.TicketSnacks", new[] { "SnackId" });
            DropIndex("dbo.TicketSnacks", new[] { "TickeId" });
            DropIndex("dbo.TbTickets", new[] { "SessionId" });
            DropIndex("dbo.TbTickets", new[] { "MovieTheaterId" });
            DropIndex("dbo.TbTickets", new[] { "MovieId" });
            DropIndex("dbo.TbTickets", new[] { "UserId" });
            DropIndex("dbo.TbSessions", new[] { "MovieTheaterId" });
            DropIndex("dbo.TbSessions", new[] { "MovieId" });
            DropIndex("dbo.TbSeats", new[] { "MovieTheater_Id" });
            DropTable("dbo.TicketSnacks");
            DropTable("dbo.TbUsers");
            DropTable("dbo.TbTickets");
            DropTable("dbo.TbSnacks");
            DropTable("dbo.TbSessions");
            DropTable("dbo.TbSeats");
            DropTable("dbo.TbMovieTheaters");
            DropTable("dbo.TbMovies");
        }
    }
}
