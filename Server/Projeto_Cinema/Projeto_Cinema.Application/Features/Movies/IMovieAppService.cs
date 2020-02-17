using Projeto_Cinema.Application.Features.Movies.Commands;
using Projeto_Cinema.Application.Features.Movies.ViewModels;
using Projeto_Cinema.Domain.Features.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Application.Features.Movies
{
    public interface IMovieAppService
    {
        long Add(MovieAddCommand user);

        IQueryable<Movie> GetAll();

        Movie GetById(long Id);

        bool Update(MovieUpdateCommand user);

        bool Delete(MovieDeleteCommand user);
    }
}
