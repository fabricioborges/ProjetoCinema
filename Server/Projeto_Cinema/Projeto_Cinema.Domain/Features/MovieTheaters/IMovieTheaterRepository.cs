using Projeto_Cinema.Domain.Features.Movies;
using Projeto_Cinema.Domain.Features.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Domain.Features.MovieTheaters
{
    public interface IMovieTheaterRepository
    {
        MovieTheater Add(MovieTheater movieTheater);

       IQueryable<MovieTheater> GetAll();

        MovieTheater GetById(long Id);

        bool Update(MovieTheater movieTheater);

        bool Delete(long Id);
    }
}
