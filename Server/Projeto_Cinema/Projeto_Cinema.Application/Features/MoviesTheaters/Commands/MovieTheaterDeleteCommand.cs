using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Application.Features.MoviesTheaters.Commands
{
    public class MovieTheaterDeleteCommand
    {
        public long Id { get; set; }

        public virtual ValidationResult Validation()
        {
            return new MovieTheaterDeleteCommandValidator().Validate(this);
        }

        class MovieTheaterDeleteCommandValidator : AbstractValidator<MovieTheaterDeleteCommand>
        {
            public MovieTheaterDeleteCommandValidator()
            {
                RuleFor(x => x.Id).NotNull();
            }
        }
    }
}
