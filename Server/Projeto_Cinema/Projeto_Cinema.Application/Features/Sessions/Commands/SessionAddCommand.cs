using Projeto_Cinema.Domain.Features.Movies;
using Projeto_Cinema.Domain.Features.MovieTheaters;
using System;

namespace Projeto_Cinema.Application.Features.Sessions.Commands
{
    public class SessionAddCommand
    {
        public DateTime DateInitial { get; set; }
        public DateTime DateFinal { get; private set; }
        public DateTime Hour { get; set; }
        public Movie Movie { get; set; }
        public MovieTheater MovieTheater { get; set; }
        public TimeSpan Duration { get; private set; }
    }
}
