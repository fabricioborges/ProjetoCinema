using Projeto_Cinema.Domain.Features.Movies;
using Projeto_Cinema.Domain.Features.MovieTheaters;
using Projeto_Cinema.Domain.Features.Sessions;
using Projeto_Cinema.Domain.Features.Snacks;
using Projeto_Cinema.Domain.Features.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Domain.Features.Tickets
{
    public class Ticket
    {
        public long Id { get; set; }
        public virtual User User { get; set; }
        public long UserId { get; set; }
        public Movie Movie { get; set; }
        public long MovieId { get; set; }
        public MovieTheater MovieTheater { get; set; }
        public long MovieTheaterId { get; set; }
        public Session Session { get; set; }
        public long SessionId { get; set; }
        public DateTime DateBuy { get; set; }
        public double Value { get; set; }
        public List<Snack> Snacks { get; set; }
        public long SnackId { get; set; }
        public bool IsConfirmed { get; set; }

        public double CalculateValueSeats()
        {
            return MovieTheater.Seats.Count * Session.ValueOfSeats;
        }

        public double CalculateValueSnacks()
        {
            var snackPrices = Snacks.Select(x => x.Price).ToList();

            double valueSnacks = 0;

            snackPrices.ForEach(x => valueSnacks += x);

            return valueSnacks;
        }

        public void ConfirmTicket(bool isConfirmed)
        {
            IsConfirmed = isConfirmed;
        }

    }
}
