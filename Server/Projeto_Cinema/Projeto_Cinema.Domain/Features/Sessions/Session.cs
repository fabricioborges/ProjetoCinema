using Projeto_Cinema.Domain.Features.Base;
using Projeto_Cinema.Domain.Features.Customers;
using Projeto_Cinema.Domain.Features.Movies;
using Projeto_Cinema.Domain.Features.MovieTheaters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Domain.Features.Sessions
{
    public class Session : Identity
    {
        public DateTime Date { get; set; }
        public DateTime Hour { get; set; }
        public Movie Movie { get; set; }
        public List<Customer> Customers { get; set; }
        public MovieTheater MovieTheater { get; set; }
        public DateTime Duration { get; set; }
        public bool Remove { get; private set; }

        public void CanRemove()
        {
        }

    }
}
