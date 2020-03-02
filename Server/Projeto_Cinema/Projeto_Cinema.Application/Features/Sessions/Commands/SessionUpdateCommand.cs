using FluentValidation;
using FluentValidation.Results;
using Projeto_Cinema.Domain.Features.Movies;
using Projeto_Cinema.Domain.Features.Movies.Enums;
using Projeto_Cinema.Domain.Features.MovieTheaters;
using System;

namespace Projeto_Cinema.Application.Features.Sessions.Commands
{
    public class SessionUpdateCommand
    {
        public long Id { get; set; }
        public DateTime DateInitial { get; set; }
        public DateTime EndDate { get; private set; }
        public DateTime Hour { get; set; }
        public long MovieId { get; set; }
        public long MovieTheaterId { get; set; }
        public TimeSpan Duration { get; private set; }
        public AnimationTypeEnum AnimationType { get; set; }
        public TypeAudioEnum TypeAudio { get; set; }
        public double ValueOfSeats { get; set; }


        public virtual ValidationResult Validation()
        {
            return new SessionUpdateCommandValidator().Validate(this);
        }

        class SessionUpdateCommandValidator : AbstractValidator<SessionUpdateCommand>
        {
            public SessionUpdateCommandValidator()
            {
                RuleFor(x => x.Id).NotNull();
                RuleFor(x => x.DateInitial).NotNull();
                RuleFor(x => x.Hour).NotNull().NotEmpty();
                RuleFor(x => x.AnimationType).NotNull();
                RuleFor(x => x.TypeAudio).NotNull();
                RuleFor(x => x.ValueOfSeats).NotNull();
            }
        }
    }
}
