using Projeto_Cinema.Application.Features.Tickets.Commands;
using Projeto_Cinema.Domain.Features.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Common.Tests.Features
{
    public static partial class ObjectMother
    {
        public static Ticket ticketDefault
        {
            get
            {
                return new Ticket
                {
                    DateBuy = DateTime.Now,
                    IsConfirmed = true,
                    Movie = ObjectMother.movieDefault,
                    MovieTheater = ObjectMother.movieTheaterDefault,
                    Session = ObjectMother.sessionDefault,
                    Value = 100
                };
            }
        }

        public static Ticket ticketToPersist
        {
            get
            {
                return new Ticket
                {
                    DateBuy = DateTime.Now,
                    IsConfirmed = true,
                    Movie = ObjectMother.movieDefault,
                    MovieId = ObjectMother.movieDefault.Id,
                    MovieTheater = ObjectMother.movieTheaterDefault,
                    MovieTheaterId = ObjectMother.movieTheaterDefault.Id,
                    Session = ObjectMother.sessionDefault,
                    SessionId = ObjectMother.seatDefault.Id,
                    User = ObjectMother.userDefault,
                    UserId = ObjectMother.userDefault.Id,
                    Value = 100
                };
            }
        }

        public static TicketAddCommand ticketAddCommand
        {
            get
            {
                return new TicketAddCommand
                {
                    DateBuy = DateTime.Now,
                    IsConfirmed = true,
                    Value = 100
                };
            }
        }

        public static TicketUpdateCommand ticketUpdateCommand
        {
            get
            {
                return new TicketUpdateCommand
                {
                    Id = 1,
                    DateBuy = DateTime.Now,
                    IsConfirmed = true,
                    Movie = ObjectMother.movieDefault,
                    MovieTheater = ObjectMother.movieTheaterDefault,
                    Session = ObjectMother.sessionDefault,
                    Value = 100
                };
            }
        }

        public static TicketDeleteCommand ticketDeleteCommand
        {
            get
            {
                return new TicketDeleteCommand
                {
                    Id = 1,
                };
            }
        }

        public static IQueryable<Ticket> ticketListDefault
        {
            get
            {
                List<Ticket> tickets = new List<Ticket>();

                tickets.Add(ticketDefault);
                tickets.Add(ticketDefault);
                tickets.Add(ticketDefault);

                return tickets.AsQueryable();
            }
        }
    }
}
