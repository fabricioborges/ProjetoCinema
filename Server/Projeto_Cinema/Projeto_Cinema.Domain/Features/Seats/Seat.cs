using Projeto_Cinema.Domain.Features.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Domain.Features.Seats
{
    public class Seat : Identity
    {
        public int Number { get; set; }
        public bool IsAvailable { get; set; }
    }
}
