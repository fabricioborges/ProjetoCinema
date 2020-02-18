using FluentValidation;
using FluentValidation.Results;
using Projeto_Cinema.Domain.Features.Movies;
using Projeto_Cinema.Domain.Features.MovieTheaters;
using Projeto_Cinema.Domain.Features.Sessions;
using Projeto_Cinema.Domain.Features.Snacks;
using Projeto_Cinema.Domain.Features.Users;
using System;
using System.Collections.Generic;

namespace Projeto_Cinema.Application.Features.Tickets.Commands
{
    public class TicketAddCommand
    {
        public long UserId { get; set; }
        public long MovieId { get; set; }
        public long MovieTheaterId { get; set; }
        public long SessionId { get; set; }
        public DateTime DateBuy { get; set; }
        public double Value { get; set; }
        public List<long> SnacksIds { get; set; }
        public bool IsConfirmed { get; set; }

        public virtual ValidationResult Validation()
        {
            return new TicketddCommandValidator().Validate(this);
        }

        class TicketddCommandValidator : AbstractValidator<TicketAddCommand>
        {
            public TicketddCommandValidator()
            {
                RuleFor(x => x.Value).NotNull().NotEmpty();
            }
        }
    }
}
