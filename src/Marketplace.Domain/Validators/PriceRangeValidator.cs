﻿using FluentValidation;
using Marketplace.Domain.Entities;

namespace Marketplace.Domain.Validators
{
    public class PriceRangeValidator : AbstractValidator<PriceRange>
    {
        public PriceRangeValidator()
        {
            RuleFor(_ => _.Name)
                .NotEmpty().WithMessage("O Nome não pode ser vazio")
                .Length(1, 50).WithMessage("O nome deve conter entre 1 e 50 caracteres");
        }
    }
}
