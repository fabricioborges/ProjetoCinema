using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Domain.Features.Base.Exceptions
{
    public class DomainException : Exception
    {
        private string v;

        public DomainException(ErrorCode errorCode, string message) : base(message)
        {
            ErrorCode = errorCode;
        }

        protected DomainException(string v)
        {
            this.v = v;
        }

        public ErrorCode ErrorCode { get; }
    }
}
