namespace Projeto_Cinema.Infra.ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteoncascadesession : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TbTickets", "SessionId", "dbo.TbSessions");
            AddForeignKey("dbo.TbTickets", "SessionId", "dbo.TbSessions", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TbTickets", "SessionId", "dbo.TbSessions");
            AddForeignKey("dbo.TbTickets", "SessionId", "dbo.TbSessions", "Id");
        }
    }
}
