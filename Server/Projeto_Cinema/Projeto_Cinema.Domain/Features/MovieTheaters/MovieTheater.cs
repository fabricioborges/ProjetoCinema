using Projeto_Cinema.Domain.Features.Base;
using Projeto_Cinema.Domain.Features.Sessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Domain.Features.MovieTheaters
{
    public class MovieTheater : Identity
    {       
        public string Name { get; set; }
        public int NumberOfSeats { get; set; }
        public List<Session> Sessions { get; set; }
    }
}
