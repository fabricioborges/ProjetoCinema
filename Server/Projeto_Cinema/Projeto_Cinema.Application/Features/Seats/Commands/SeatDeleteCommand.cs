using FluentValidation;
using FluentValidation.Results;

namespace Projeto_Cinema.Application.Features.Seats.Commands
{
    public class SeatDeleteCommand
    {
        public long Id { get; set; }

        public virtual ValidationResult Validation()
        {
            return new SeatDeleteCommandValidator().Validate(this);
        }

        class SeatDeleteCommandValidator : AbstractValidator<SeatDeleteCommand>
        {
            public SeatDeleteCommandValidator()
            {
                RuleFor(x => x.Id).NotNull();
            }
        }
    }
}
