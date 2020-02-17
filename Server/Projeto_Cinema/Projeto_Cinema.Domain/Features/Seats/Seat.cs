using Projeto_Cinema.Domain.Features.MovieTheaters;
using System.Collections.Generic;

namespace Projeto_Cinema.Domain.Features.Seats
{
    public class Seat
    {
        public long Id { get; set; }
        public int Number { get; set; }
        public bool IsAvailable { get; set; }

        public List<Seat> GenerateSeats(int quantity)
        {
            List<Seat> Seats = new List<Seat>();

            for(int i = 0; i < quantity; i++)
            {
                Seats.Add(new Seat { Number = i, IsAvailable = true });
            }

            return Seats;
        }
    }
}
