using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Domain.Features.Tickets
{
    public interface ITicketRepository
    {
        Ticket Add(Ticket ticket);

        IQueryable<Ticket> GetAll();

        Ticket GetById(long Id);

        bool Update(Ticket ticket);

        bool Delete(long Id);
    }
}
