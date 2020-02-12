using Projeto_Cinema.Domain.Features.MovieTheaters;
using Projeto_Cinema.Domain.Features.Seats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Common.Tests.Features
{
    public static partial class ObjectMother
    {
        public static MovieTheater movieTheaterDefault
        {
            get
            {
                return new MovieTheater
                {
                    Name = "sala 01",
                    Seats = seatListDefault,
                    ValueOfSeats = 10
                };
            }
        }       
    }
}
