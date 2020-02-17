using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Application.Features.Movies.Commands
{
    public class MovieDeleteCommand
    {
        public long Id { get; set; }

        public virtual ValidationResult Validation()
        {
            return new MovieDeleteCommandValidator().Validate(this);
        }
        class MovieDeleteCommandValidator : AbstractValidator<MovieDeleteCommand>
        {
            public MovieDeleteCommandValidator()
            {
                RuleFor(x => x.Id).NotNull();
            }
        }
    }
}
