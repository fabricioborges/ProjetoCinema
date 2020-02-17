using Projeto_Cinema.Application.Features.MoviesTheaters.Commands;
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
                    Id = 1,
                    Name = "sala 01",
                    Seats = seatListDefault,
                };
            }
        }

        public static IQueryable<MovieTheater> movieTheatersListDefault
        {
            get
            {
                List<MovieTheater> movieTheaters = new List<MovieTheater>();

                movieTheaters.Add(movieTheaterDefault);
                movieTheaters.Add(movieTheaterDefault);
                movieTheaters.Add(movieTheaterDefault);

                return movieTheaters.AsQueryable();
            }
        }


        public static MovieTheaterAddCommand movieTheaterAddCommand
        {
            get
            {
                return new MovieTheaterAddCommand
                {
                    Name = "sala 01",
                };
            }
        }

        public static MovieTheaterUpdateCommand movieTheaterUpdateCommand
        {
            get
            {
                return new MovieTheaterUpdateCommand
                {
                    Id = 1,
                    Name = "sala 01",
                    Seats = seatListDefault,
                    
                };
            }
        }

        public static MovieTheaterDeleteCommand movieTheaterDeleteCommand
        {
            get
            {
                return new MovieTheaterDeleteCommand
                {
                    Id = 1                  
                };
            }
        }
    }
}
