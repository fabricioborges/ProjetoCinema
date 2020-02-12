using Projeto_Cinema.Domain.Features.Base.Exceptions;
using Projeto_Cinema.Domain.Features.Movies;
using Projeto_Cinema.Infra.ORM.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Infra.ORM.Features.Movies
{
    public class MovieRepository : IMovieRepository
    {
        ProjetoCinemaContext Context;

        public MovieRepository(ProjetoCinemaContext context)
        {
            Context = context;
        }

        public Movie Add(Movie movie)
        {
            Context.Movies.Add(movie);
            return movie;
        }

        public bool Delete(long id)
        {
            var user = Context.Movies.Where(c => c.Id == id).FirstOrDefault();
            if (user == null)
                throw new NotFoundException("Registro não encontrado!");
            Context.Entry(user).State = EntityState.Deleted;
            return Context.SaveChanges() > 0;
        }

        public IQueryable<Movie> GetAll()
        {
            return Context.Movies;
        }

        public Movie GetById(long Id)
        {
            return Context.Movies.FirstOrDefault(m => m.Id == Id);
        }

        public bool Update(Movie movie)
        {
            Context.Entry(movie).State = EntityState.Modified;
            return Context.SaveChanges() > 0;
        }
    }
}
