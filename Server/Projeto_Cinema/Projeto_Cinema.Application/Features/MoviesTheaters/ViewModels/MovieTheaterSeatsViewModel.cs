using Projeto_Cinema.Application.Features.Seats.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Application.Features.MoviesTheaters.ViewModels
{
    public class MovieTheaterSeatsViewModel
    {
        public long Id { get; set; }
        public virtual MovieTheaterViewModel MovieTheater { get; set; }
        public virtual SeatViewModel Seat { get; set; }
        public bool IsAvailable { get; set; }
    }
}
