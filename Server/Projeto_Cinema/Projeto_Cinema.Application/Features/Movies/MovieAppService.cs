using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Projeto_Cinema.Application.Features.Movies.Commands;
using Projeto_Cinema.Domain.Features.Base.Exceptions;
using Projeto_Cinema.Domain.Features.Movies;

namespace Projeto_Cinema.Application.Features.Movies
{
    public class MovieAppService : IMovieAppService
    {
        IMovieRepository MovieRepository;

        public MovieAppService(IMovieRepository repository)
        {
            MovieRepository = repository;
        }

        public long Add(MovieAddCommand movie)
        {
            var movieAdd = Mapper.Map<MovieAddCommand, Movie>(movie);
            var newMovie = MovieRepository.Add(movieAdd);

            return newMovie.Id;
        }

        public bool Delete(MovieDeleteCommand movie)
        {
            return MovieRepository.Delete(movie.Id);
        }

        public IQueryable<Movie> GetAll()
        {
            return MovieRepository.GetAll();
        }

        public Movie GetById(long Id)
        {
            return MovieRepository.GetById(Id);
        }

        public bool Update(MovieUpdateCommand movie)
        {
            var movieDb = MovieRepository.GetById(movie.Id);
            if (movieDb == null)
                throw new NotFoundException("Registro não encontrado!");

            var movieEdit = Mapper.Map(movie, movieDb);

            return MovieRepository.Update(movieEdit);
        }
    }
}
