using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Application.Features.Users.Commands
{
    public class UserDeleteCommand
    {
        public long Id { get; set; }

        public virtual ValidationResult Validation()
        {
            return new UserDeleteCommandValidator().Validate(this);
        }
        class UserDeleteCommandValidator : AbstractValidator<UserDeleteCommand>
        {
            public UserDeleteCommandValidator()
            {
                RuleFor(x => x.Id).NotNull();
            }
        }
    }
}
