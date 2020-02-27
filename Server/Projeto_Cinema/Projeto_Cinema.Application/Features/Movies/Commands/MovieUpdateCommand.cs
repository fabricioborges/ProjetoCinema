
using FluentValidation;
using FluentValidation.Results;
using Projeto_Cinema.Domain.Features.Movies.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Application.Features.Movies.Commands
{
    public class MovieUpdateCommand
    {
        public long Id { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime DebutDate { get; set; }
        public DateTime EndDate { get; set; }
        public AnimationTypeEnum AnimationType { get; set; }
        public TypeAudioEnum TypeAudio { get; set; }

        public virtual ValidationResult Validation()
        {
            return new MovieUpdateCommandValidator().Validate(this);
        }

        class MovieUpdateCommandValidator : AbstractValidator<MovieUpdateCommand>
        {
            public MovieUpdateCommandValidator()
            {
                RuleFor(x => x.Title).NotNull().NotEmpty();
                RuleFor(x => x.Image).NotNull();
                RuleFor(x => x.Description).NotNull().NotEmpty();
                RuleFor(x => x.Duration).NotNull();
                RuleFor(x => x.DebutDate).NotNull();
                RuleFor(x => x.EndDate).NotNull();
                RuleFor(x => x.AnimationType).NotNull();
                RuleFor(x => x.TypeAudio).NotNull();
            }
        }
    }
    
}
