using Projeto_Cinema.Domain.Features.Movies;
using Projeto_Cinema.Domain.Features.MovieTheaters;
using Projeto_Cinema.Domain.Features.Sessions;
using Projeto_Cinema.Domain.Features.Snacks;
using Projeto_Cinema.Domain.Features.Users;
using System;
using System.Collections.Generic;

namespace Projeto_Cinema.Application.Features.Tickets.Commands
{
    public class TicketAddCommand
    {
        public User User { get; set; }
        public Movie Movie { get; set; }
        public MovieTheater MovieTheater { get; set; }
        public Session Session { get; set; }
        public DateTime DateBuy { get; set; }
        public double Value { get; set; }
        public List<Snack> Snacks { get; set; }
        public bool IsConfirmed { get; set; }
    }
}
