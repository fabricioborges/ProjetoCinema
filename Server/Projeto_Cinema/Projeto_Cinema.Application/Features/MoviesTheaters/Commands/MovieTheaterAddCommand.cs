using FluentValidation;
using FluentValidation.Results;
using Projeto_Cinema.Domain.Features.Seats;
using Projeto_Cinema.Domain.Features.Snacks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Application.Features.MoviesTheaters.Commands
{
    public class MovieTheaterAddCommand
    {
        public string Name { get; set; }
        public int QuantityOfSeats { get; set; }

        public virtual ValidationResult Validation()
        {
            return new MovieTheaterAddCommandValidator().Validate(this);
        }

        class MovieTheaterAddCommandValidator : AbstractValidator<MovieTheaterAddCommand>
        {
            public MovieTheaterAddCommandValidator()
            {
                RuleFor(x => x.Name).NotNull();
            }
        }
    }
}
