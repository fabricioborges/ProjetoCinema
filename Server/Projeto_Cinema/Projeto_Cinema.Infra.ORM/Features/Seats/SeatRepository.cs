using Projeto_Cinema.Domain.Features.Base.Exceptions;
using Projeto_Cinema.Domain.Features.Seats;
using Projeto_Cinema.Infra.ORM.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Infra.ORM.Features.Seats
{
    public class SeatRepository : ISeatRepository
    {
        ProjetoCinemaContext Context;

        public SeatRepository(ProjetoCinemaContext context)
        {
            Context = context;
        }

        public Seat Add(Seat seat)
        {
            Context.Seats.Add(seat);
            Context.SaveChanges();
            return seat;
        }

        public bool Delete(long Id)
        {
            var seat = Context.Seats.Where(c => c.Id == Id).FirstOrDefault();
            if (seat == null)
                throw new NotFoundException("Registro não encontrado!");
            Context.Entry(seat).State = EntityState.Deleted;
            return Context.SaveChanges() > 0;
        }

        public IQueryable<Seat> GetAll()
        {
            return Context.Seats;
        }

        public Seat GetById(long Id)
        {
            return Context.Seats.FirstOrDefault(s => s.Id == Id);
        }

        public bool Update(Seat seat)
        {
            Context.Entry(seat).State = EntityState.Modified;
            return Context.SaveChanges() > 0;
        }
    }
}
