using Projeto_Cinema.Application.Features.Seats.Commands;
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

        public static SeatAddCommand seatAddCommand
        {
            get
            {
                return new SeatAddCommand
                {
                    IsAvailable = true,
                    Number = 20
                };
            }
        }

        public static SeatDeleteCommand seatDeleteCommand
        {
            get
            {
                return new SeatDeleteCommand
                {
                    Id = 1
                };
            }
        }

        public static SeatUpdateCommand seatUpdateCommand
        {
            get
            {
                return new SeatUpdateCommand
                {
                    Id = 1,
                    IsAvailable = true,
                    Number = 20
                };
            }
        }
    }
}
