using Projeto_Cinema.Domain.Features.Seats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Application.Features.MoviesTheaters.Commands
{
    public class MovieTheaterUpdateCommand
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<Seat> Seats { get; set; }
        public List<int> NumberOfSeats { get; set; }
        public double ValueOfSeats { get; set; }
    }
}
