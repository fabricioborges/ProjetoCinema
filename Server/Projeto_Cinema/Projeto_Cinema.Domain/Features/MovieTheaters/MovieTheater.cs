using Projeto_Cinema.Domain.Features.Base.Exceptions;
using Projeto_Cinema.Domain.Features.Seats;
using Projeto_Cinema.Domain.Features.Sessions;
using System.Collections.Generic;

namespace Projeto_Cinema.Domain.Features.MovieTheaters
{
    public class MovieTheater 
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public virtual List<Seat> Seats { get; set; }

        public void ValidateNumberOfSeats()
        {
            if (Seats.Count < 20)
                throw new MovieTheaterException("Uma sala deve conter pelo menos 20 assentos");

            if (Seats.Count > 100)
                throw new MovieTheaterException("Uma sala deve conter no máximo 100 assentos");
        }
    }
}
