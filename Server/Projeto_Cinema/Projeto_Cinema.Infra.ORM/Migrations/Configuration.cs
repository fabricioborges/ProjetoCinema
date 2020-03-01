namespace Projeto_Cinema.Infra.ORM.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Projeto_Cinema.Infra.ORM.Context.ProjetoCinemaContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Projeto_Cinema.Infra.ORM.Context.ProjetoCinemaContext";
        }

        protected override void Seed(Projeto_Cinema.Infra.ORM.Context.ProjetoCinemaContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
