using FluentValidation;
using FluentValidation.Results;

namespace Projeto_Cinema.Application.Features.Snacks.Commands
{
    public class SnackDeleteCommand
    {
        public long Id { get; set; }

        public virtual ValidationResult Validation()
        {
            return new SnackDeleteCommandValidator().Validate(this);
        }

        class SnackDeleteCommandValidator : AbstractValidator<SnackDeleteCommand>
        {
            public SnackDeleteCommandValidator()
            {
                RuleFor(x => x.Id).NotNull();
            }
        }
    }
}
