using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Domain.Features.Base.Exceptions
{
    public class MovieTheaterException : Exception
    {
        public MovieTheaterException(string message) : base(message)
        {
        }
    }
}
