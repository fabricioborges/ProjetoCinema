using FluentValidation;
using FluentValidation.Results;
using Projeto_Cinema.Domain.Features.Seats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Application.Features.MoviesTheaters.Commands
{
    public class MovieTheaterUpdateCommand
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<Seat> Seats { get; set; }

        public virtual ValidationResult Validation()
        {
            return new MovieTheaterUpdateCommandValidator().Validate(this);
        }

        class MovieTheaterUpdateCommandValidator : AbstractValidator<MovieTheaterUpdateCommand>
        {
            public MovieTheaterUpdateCommandValidator()
            {
                RuleFor(x => x.Name).NotNull();
            }
        }
    }
}
