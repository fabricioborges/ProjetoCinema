using Projeto_Cinema.Domain.Features.Base;
using Projeto_Cinema.Domain.Features.Base.Exceptions;
using Projeto_Cinema.Domain.Features.Seats;
using Projeto_Cinema.Domain.Features.Sessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Domain.Features.MovieTheaters
{
    public class MovieTheater : Identity
    {
        public string Name { get; set; }
        public List<Seat> Seats { get; set; }
        public List<Session> Sessions { get; set; }

        public void ValidateNumberOfSeats()
        {
            if (Seats.Count < 20)
                throw new MovieTheaterException("Uma sala deve conter pelo menos 20 assentos");

            if (Seats.Count > 100)
                throw new MovieTheaterException("Uma sala deve conter no máximo 100 assentos");
        }
    }
}
