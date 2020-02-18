using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Projeto_Cinema.Application.Features.Tickets.Commands;
using Projeto_Cinema.Domain.Features.Base.Exceptions;
using Projeto_Cinema.Domain.Features.Movies;
using Projeto_Cinema.Domain.Features.MovieTheaters;
using Projeto_Cinema.Domain.Features.Sessions;
using Projeto_Cinema.Domain.Features.Snacks;
using Projeto_Cinema.Domain.Features.Tickets;
using Projeto_Cinema.Domain.Features.Users;

namespace Projeto_Cinema.Application.Features.Tickets
{
    public class TicketAppService : ITicketAppService
    {
        ITicketRepository TicketRepository;
        IMovieRepository MovieRepository;
        ISessionRepository SessionRepository;
        IUserRepository UserRepository;
        IMovieTheaterRepository MovieTheaterRepository;
        ISnackRepository SnackRepository;

        public TicketAppService(ITicketRepository repository, IMovieRepository movieRepository,
            ISessionRepository sessionRepository, IUserRepository userRepository, 
            IMovieTheaterRepository movieTheaterRepository, ISnackRepository snackRepository)
        {
            TicketRepository = repository;
            MovieRepository = movieRepository;
            SessionRepository = sessionRepository;
            UserRepository = userRepository;
            MovieTheaterRepository = movieTheaterRepository;
            SnackRepository = snackRepository;
        }

        public long Add(TicketAddCommand ticket)
        {
            var ticketAdd = Mapper.Map<TicketAddCommand, Ticket>(ticket);
            ticketAdd.DateBuy = DateTime.Now;

            var session = SessionRepository.GetById(ticket.SessionId);

            ticketAdd.Session = session;

            var movie = MovieRepository.GetById(ticket.MovieId);

            ticketAdd.Movie = movie;

            var user = UserRepository.GetById(ticket.UserId);

            ticketAdd.User = user;

            var snacks = SnackRepository.GetById(ticket.SnacksIds);

            ticketAdd.Snacks = snacks;

            var movieTheater = MovieTheaterRepository.GetById(ticket.MovieTheaterId);

            ticketAdd.MovieTheater = movieTheater;

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
