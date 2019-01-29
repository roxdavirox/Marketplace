using FluentValidation;
using Marketplace.Domain.Entities;

namespace Marketplace.Domain.Validators
{
    public class PriceValidator : AbstractValidator<Price>
    {
        public PriceValidator()
        {
            RuleFor(_ => _.Start).NotEmpty().WithMessage("Start nao pode ser vazio");
        }
    }
}
