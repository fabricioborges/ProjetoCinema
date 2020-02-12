using System;

namespace Projeto_Cinema.Domain.Features.Base.Exceptions
{
    public class UserException : Exception
    {
        public UserException(string message) : base(message)
        {
        }
    }
}
