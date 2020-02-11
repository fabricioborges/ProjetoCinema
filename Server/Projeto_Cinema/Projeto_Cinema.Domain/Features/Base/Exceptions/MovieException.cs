using System;

namespace Projeto_Cinema.Domain.Features.Base.Exceptions
{
    public class MovieException : Exception
    {
        public MovieException(string message) : base(message)
        {
        }
    }
}
