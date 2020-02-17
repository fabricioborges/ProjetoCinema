using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Application.Features.Seats.Commands
{
    public class SeatAddCommand
    {
        public int Number { get; set; }
        public bool IsAvailable { get; set; }

        public virtual ValidationResult Validation()
        {
            return new SessionAddCommandValidator().Validate(this);
        }

        class SessionAddCommandValidator : AbstractValidator<SeatAddCommand>
        {
            public SessionAddCommandValidator()
            {
                RuleFor(x => x.Number).NotNull();
                RuleFor(x => x.IsAvailable).NotNull().NotEmpty();               
            }
        }
    }
}
