using System;

namespace Projeto_Cinema.Domain.Features.Base.Exceptions
{
    public class AttendantException : Exception
    {
        public AttendantException(string message) : base(message)
        {
        }
    }
}
