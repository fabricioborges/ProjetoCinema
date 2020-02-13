using Projeto_Cinema.Domain.Features.Base.Exceptions;
using Projeto_Cinema.Domain.Features.Tickets;
using Projeto_Cinema.Infra.ORM.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Infra.ORM.Features.Tickets
{
    public class TicketRepository : ITicketRepository
    {
        ProjetoCinemaContext Context;

        public TicketRepository(ProjetoCinemaContext context)
        {
            Context = context;
        }

        public Ticket Add(Ticket ticket)
        {
            Context.Tickets.Add(ticket);
            Context.SaveChanges();
            return ticket;
        }

        public bool Delete(long Id)
        {
            var ticket = Context.Tickets.Where(c => c.Id == Id).FirstOrDefault();
            if (ticket == null)
                throw new NotFoundException("Registro não encontrado!");
            Context.Entry(ticket).State = EntityState.Deleted;
            return Context.SaveChanges() > 0;
        }

        public IQueryable<Ticket> GetAll()
        {
            return Context.Tickets;
        }

        public Ticket GetById(long Id)
        {
            return Context.Tickets.FirstOrDefault(t => t.Id == Id);
        }

        public bool Update(Ticket ticket)
        {
            Context.Entry(ticket).State = EntityState.Modified;
            return Context.SaveChanges() > 0;
        }
    }
}
