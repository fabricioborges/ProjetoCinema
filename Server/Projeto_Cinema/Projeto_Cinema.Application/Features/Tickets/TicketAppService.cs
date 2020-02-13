using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Projeto_Cinema.Application.Features.Tickets.Commands;
using Projeto_Cinema.Domain.Features.Base.Exceptions;
using Projeto_Cinema.Domain.Features.Tickets;

namespace Projeto_Cinema.Application.Features.Tickets
{
    public class TicketAppService : ITicketAppService
    {
        ITicketRepository TicketRepository;

        public TicketAppService(ITicketRepository repository)
        {
            TicketRepository = repository;
        }

        public long Add(TicketAddCommand ticket)
        {
            var ticketAdd = Mapper.Map<TicketAddCommand, Ticket>(ticket);
            var newTicket = TicketRepository.Add(ticketAdd);

            return newTicket.Id;
        }

        public bool Delete(TicketDeleteCommand ticket)
        {
            return TicketRepository.Delete(ticket.Id);
        }

        public IQueryable<Ticket> GetAll()
        {
            return TicketRepository.GetAll();
        }

        public Ticket GetById(long Id)
        {
            return TicketRepository.GetById(Id);
        }

        public bool Update(TicketUpdateCommand ticket)
        {
            var ticketDb = TicketRepository.GetById(ticket.Id);
            if (ticketDb == null)
                throw new NotFoundException("Registro não encontrado!");

            var userEdit = Mapper.Map(ticket, ticketDb);

            return TicketRepository.Update(userEdit);
        }
    }
}
