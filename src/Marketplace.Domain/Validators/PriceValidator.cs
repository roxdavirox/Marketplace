using FluentValidation;
using Marketplace.Domain.Entities;

namespace Marketplace.Domain.Validators
{
    public class PriceValidator : AbstractValidator<Price>
    {
        public PriceValidator()
        {
            RuleFor(_ => _.Start)
                .NotEmpty().WithMessage("Start nao pode ser vazio")
                .GreaterThan(0).WithMessage("Start não pode ser menor que 1");

            RuleFor(_ => _.End)
                .GreaterThan(0).WithMessage("End não pode ser menor que 1")
                .NotEmpty().WithMessage("End não pode ser vazio");

            RuleFor(_ => _.Value)
                .GreaterThan(0).WithMessage("Value não pode ser menor que 1")
                .NotEmpty().WithMessage("Value não pode ser vazio");
        }
    }
}
