namespace Projeto_Cinema.Infra.ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteOnCascade : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TbSeats", "MovieTheater_Id", "dbo.TbMovieTheaters");
            AddForeignKey("dbo.TbSeats", "MovieTheater_Id", "dbo.TbMovieTheaters", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TbSeats", "MovieTheater_Id", "dbo.TbMovieTheaters");
            AddForeignKey("dbo.TbSeats", "MovieTheater_Id", "dbo.TbMovieTheaters", "Id");
        }
    }
}
