using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Domain.Features.Movies
{
    public interface IMovieRepository
    {
        Movie Add(Movie movie);

        IQueryable<Movie> GetAll();

        Movie GetById(long Id);

        bool Update(Movie movie);

        bool Delete(long Id);
    }
}
