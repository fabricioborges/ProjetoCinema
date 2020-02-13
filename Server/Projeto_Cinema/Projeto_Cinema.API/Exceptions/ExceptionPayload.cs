using Projeto_Cinema.Domain.Features.Base.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto_Cinema.API.Exceptions
{
    public class ExceptionPayload
    {
        public int ErrorCode { get; set; }

        public string ErrorMessage { get; set; }

        public static ExceptionPayload New<T>(T exception) where T : Exception
        {
            int errorCode;
            if (exception is DomainException)
                errorCode = (exception as DomainException).ErrorCode.GetHashCode();
            else
                errorCode = Domain.Features.Base.Exceptions.ErrorCode.Unhandled.GetHashCode();
            return new ExceptionPayload
            {
                ErrorCode = errorCode,
                ErrorMessage = exception.Message,
            };
        }
    }
}