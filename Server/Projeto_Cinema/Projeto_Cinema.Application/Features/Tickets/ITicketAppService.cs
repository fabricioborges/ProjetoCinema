using Projeto_Cinema.Application.Features.Tickets.Commands;
using Projeto_Cinema.Domain.Features.Tickets;
using System.Linq;

namespace Projeto_Cinema.Application.Features.Tickets
{
    public interface ITicketAppService
    {
        long Add(TicketAddCommand ticket);

        IQueryable<Ticket> GetAll();

        Ticket GetById(long Id);

        bool Update(TicketUpdateCommand ticket);

        bool Delete(TicketDeleteCommand ticket);
    }
}
