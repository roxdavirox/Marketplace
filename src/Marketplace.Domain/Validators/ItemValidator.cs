using FluentValidation;
using Marketplace.Domain.Entities;

namespace Marketplace.Domain.Validators
{
    public class ItemValidator : AbstractValidator<Item>
    {
        public ItemValidator()
        {
            RuleFor(_ => _.Name)
                .NotEmpty().WithMessage("O Nome não pode ser vazio")
                .Length(3, 50).WithMessage("O nome deve conter entre 3 e 50 caracteres");
        }
    }
}
