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
    public class UserAddCommand
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public AccessLevelEnum AccessLevel { get; set; }

        public virtual ValidationResult Validation()
        {
            return new UserAddCommandValidator().Validate(this);
        }

        class UserAddCommandValidator : AbstractValidator<UserAddCommand>
        {
            public UserAddCommandValidator()
            {
                RuleFor(x => x.Name).NotNull().NotEmpty();
                RuleFor(x => x.Password).NotNull();
                RuleFor(x => x.Password).NotNull().NotEmpty();                
            }
        }
    }
}
