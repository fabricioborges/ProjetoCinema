using Projeto_Cinema.Application.Features.Seats.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Application.Features.MoviesTheaters.ViewModels
{
    public class MovieTheaterViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<SeatViewModel> Seats { get; set; }
    }
}
