using FluentValidation;
using FluentValidation.Results;

namespace Projeto_Cinema.Application.Features.Sessions.Commands
{
    public class SessionDeleteCommand
    {
        public long Id { get; set; }

        public virtual ValidationResult Validation()
        {
            return new SessionDeleteCommandValidator().Validate(this);
        }

        class SessionDeleteCommandValidator : AbstractValidator<SessionDeleteCommand>
        {
            public SessionDeleteCommandValidator()
            {
                RuleFor(x => x.Id).NotNull();
            }
        }
    }
}
