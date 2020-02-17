using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Application.Features.Seats.Commands
{
    public class SeatUpdateCommand
    {
        public long Id { get; set; }
        public int Number { get; set; }

        public virtual ValidationResult Validation()
        {
            return new SessionUpdateCommandValidator().Validate(this);
        }

        class SessionUpdateCommandValidator : AbstractValidator<SeatUpdateCommand>
        {
            public SessionUpdateCommandValidator()
            {
                RuleFor(x => x.Number).NotNull();
            }
        }
    }
}
