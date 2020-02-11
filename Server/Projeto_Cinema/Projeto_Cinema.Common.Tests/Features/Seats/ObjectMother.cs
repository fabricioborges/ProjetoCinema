using Projeto_Cinema.Domain.Features.Seats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Common.Tests.Features
{
    public static partial class ObjectMother
    {
        public static Seat seatDefault
        {
            get
            {                
                return new Seat
                {
                    IsAvailable = true,
                    Number = 20
                };
            }
        }

        public static List<Seat> seatListDefault = new List<Seat>();

        public static void CreateListOfSeats(int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                seatListDefault.Add(new Seat
                {
                    IsAvailable = true,
                    Number = i
                });
            }
        }
    }
}
