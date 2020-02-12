using System;

namespace Projeto_Cinema.Domain.Features.Base.Exceptions
{
    public class MovieTheaterException : Exception
    {
        public MovieTheaterException(string message) : base(message)
        {
        }
    }
}
