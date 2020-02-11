using Projeto_Cinema.Domain.Features.Base;
using Projeto_Cinema.Domain.Features.Customers;
using Projeto_Cinema.Domain.Features.Movies;
using Projeto_Cinema.Domain.Features.MovieTheaters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Domain.Features.Sessions
{
    public class Session : Identity
    {
        public DateTime Date { get; set; }
        public DateTime Hour { get; set; }
        public Movie Movie { get; set; }
        public List<Customer> Customers { get; set; }
        public MovieTheater MovieTheater { get; set; }
        public DateTime Duration { get; set; }

        public bool CanRemove()
        {
            var targetDate = DateTime.Now - Date;
            return targetDate.Days >= 10;
        }

        public void CalculateDuration()
        {
            var durationHours = Date.Hour + Movie.Duration.Hour;
            var durationMinutes = Date.Minute + Movie.Duration.Minute;
            var durationSeconds = Date.Second + Movie.Duration.Second;
            
        }
    }
}
