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
    }
}
