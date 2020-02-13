using Projeto_Cinema.Application.Features.MoviesTheaters.Commands;
using Projeto_Cinema.Domain.Features.MovieTheaters;
using System.Linq;

namespace Projeto_Cinema.Application.Features.MoviesTheaters
{
    public interface IMovieTheatersAppService
    {
        long Add(MovieTheaterAddCommand movieTheater);

        IQueryable<MovieTheater> GetAll();

        MovieTheater GetById(long Id);

        bool Update(MovieTheaterUpdateCommand movieTheater);

        bool Delete(MovieTheaterDeleteCommand movieTheater);
    }
}
