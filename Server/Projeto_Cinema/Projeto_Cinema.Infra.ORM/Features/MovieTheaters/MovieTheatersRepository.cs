using Projeto_Cinema.Domain.Features.Base.Exceptions;
using Projeto_Cinema.Domain.Features.MovieTheaters;
using Projeto_Cinema.Infra.ORM.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Infra.ORM.Features.MovieTheaters
{
    public class MovieTheatersRepository : IMovieTheaterRepository
    {
        ProjetoCinemaContext Context;

        public MovieTheatersRepository(ProjetoCinemaContext context)
        {
            Context = context;
        }

        public MovieTheater Add(MovieTheater movieTheater)
        {
            Context.MovieTheaters.Add(movieTheater);
            Context.SaveChanges();
            return movieTheater;
        }

        public bool Delete(long Id)
        {
            var movieTheater = Context.MovieTheaters.Where(c => c.Id == Id).FirstOrDefault();
            if (movieTheater == null)
                throw new NotFoundException("Registro não encontrado!");
            Context.Entry(movieTheater).State = EntityState.Deleted;
            return Context.SaveChanges() > 0;
        }

        public IQueryable<MovieTheater> GetAll()
        {
            return Context.MovieTheaters.Include("Seats");
        }

        public MovieTheater GetById(long Id)
        {
            return Context.MovieTheaters.FirstOrDefault(m => m.Id == Id);
        }

        public bool Update(MovieTheater movieTheater)
        {
            Context.Entry(movieTheater).State = EntityState.Modified;
            return Context.SaveChanges() > 0;
        }
    }
}
