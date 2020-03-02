using FluentValidation;
using FluentValidation.Results;
using Projeto_Cinema.Domain.Features.Users.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Application.Features.Users.Commands
{
    public class UserUpdateCommand
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public AccessLevelEnum AccessLevel { get; set; }


        public virtual ValidationResult Validation()
        {
            return new UserUpdateCommandValidator().Validate(this);
        }

        class UserUpdateCommandValidator : AbstractValidator<UserUpdateCommand>
        {
            public UserUpdateCommandValidator()
            {
                RuleFor(x => x.Name).NotNull().NotEmpty();
                RuleFor(x => x.Password).NotNull();
                RuleFor(x => x.Password).NotNull().NotEmpty();
            }
        }
    }
}
