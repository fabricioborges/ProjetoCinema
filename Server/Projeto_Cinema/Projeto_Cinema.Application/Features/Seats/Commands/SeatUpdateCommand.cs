using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Application.Features.Seats.Commands
{
    public class SeatUpdateCommand
    {
        public long Id { get; set; }
        public int Number { get; set; }
        public bool IsAvailable { get; set; }
    }
}
