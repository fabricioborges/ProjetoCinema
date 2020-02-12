using Projeto_Cinema.Domain.Features.Movies;
using Projeto_Cinema.Domain.Features.MovieTheaters;
using System;

namespace Projeto_Cinema.Domain.Features.Sessions
{
    public class Session 
    {
        public long Id { get; set; }
        public DateTime DateInitial { get; set; }
        public DateTime DateFinal { get; private set; }
        public DateTime Hour { get; set; }
        public Movie Movie { get; set; }
        public MovieTheater MovieTheater { get; set; }
        public TimeSpan Duration { get; private set; }

        public bool CanRemove()
        {
            var targetDate = DateTime.Now - DateInitial;
            return targetDate.Days >= 10;
        }

        public void SetDuration() => Duration = Movie.Duration;       

        public void CalculateDateFinal() => DateFinal = DateInitial + Duration;
    }
}
