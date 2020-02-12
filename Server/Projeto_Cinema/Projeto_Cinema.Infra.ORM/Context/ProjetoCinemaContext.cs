using Projeto_Cinema.Domain.Features.Movies;
using Projeto_Cinema.Domain.Features.MovieTheaters;
using Projeto_Cinema.Domain.Features.Seats;
using Projeto_Cinema.Domain.Features.Sessions;
using Projeto_Cinema.Domain.Features.Snacks;
using Projeto_Cinema.Domain.Features.Tickets;
using Projeto_Cinema.Domain.Features.Users;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Infra.ORM.Context
{
    public class ProjetoCinemaContext : DbContext
    {
        public ProjetoCinemaContext() : base("Projeto_CinemaDb")
        {
            Configuration.LazyLoadingEnabled = true;
        }

        public ProjetoCinemaContext(DbConnection connection) : base(connection, true) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Snack> Snacks { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieTheater> MovieTheaters { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Seat> Seats { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
