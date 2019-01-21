using FluentValidation;
using Marketplace.Domain.Entities;

namespace Marketplace.Domain.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("O nome do produto não pode ser vazio")
                .Length(3, 100).WithMessage("O Nome do produto deve estar entre 3 e 100 letras");
        }
    }
}
