﻿using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Application.Features.Snacks.Commands
{
    public class SnackAddCommand
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }

        public virtual ValidationResult Validation()
        {
            return new SnackAddCommandValidator().Validate(this);
        }

        class SnackAddCommandValidator : AbstractValidator<SnackAddCommand>
        {
            public SnackAddCommandValidator()
            {
                RuleFor(x => x.Name).NotNull();
                RuleFor(x => x.Image).NotNull().NotEmpty();
                RuleFor(x => x.Price).NotNull();
            }
        }
    }
}
