using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Projeto_Cinema.Application.Features.MoviesTheaters.Commands;
using Projeto_Cinema.Domain.Features.Base.Exceptions;
using Projeto_Cinema.Domain.Features.MovieTheaters;
using Projeto_Cinema.Domain.Features.Seats;

namespace Projeto_Cinema.Application.Features.MoviesTheaters
{
    public class MovieTheatersAppService : IMovieTheatersAppService
    {
        IMovieTheaterRepository MovieTheaterRepository;
        ISeatRepository SeatRepository;

        public MovieTheatersAppService(IMovieTheaterRepository repository, ISeatRepository seatRepository)
        {
            MovieTheaterRepository = repository;
            SeatRepository = seatRepository;
        }

        public long Add(MovieTheaterAddCommand movieTheater)
        {
            var movieTheaterAdd = Mapper.Map<MovieTheaterAddCommand, MovieTheater>(movieTheater);

            var quantity = movieTheater.QuantityOfSeats;
            Seat Seat = new Seat();
            var seats = Seat.GenerateSeats(quantity);

            SeatRepository.Add(seats);

            movieTheaterAdd.Seats = seats;

            var newMovieTheater = MovieTheaterRepository.Add(movieTheaterAdd);

            return newMovieTheater.Id;
        }

        public bool Delete(MovieTheaterDeleteCommand movieTheater)
        {
            return MovieTheaterRepository.Delete(movieTheater.Id);
        }

        public IQueryable<MovieTheater> GetAll()
        {
            return MovieTheaterRepository.GetAll();
        }

        public MovieTheater GetById(long Id)
        {
            return MovieTheaterRepository.GetById(Id);
        }

        public bool Update(MovieTheaterUpdateCommand movieTheater)
        {
            var movieTheaterDb = MovieTheaterRepository.GetById(movieTheater.Id);
            if (movieTheaterDb == null)
                throw new NotFoundException("Registro não encontrado!");

            var movieTheaterEdit = Mapper.Map(movieTheater, movieTheaterDb);
            
            MovieTheaterRepository.Update(movieTheaterEdit);
            
            return MovieTheaterRepository.Update(movieTheaterEdit);
        }
    }
}
