using FluentValidation;
using Marketplace.Domain.Entities;

namespace Marketplace.Domain.Validators
{
    public class OptionValidator : AbstractValidator<Option>
    {
        public OptionValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("O nome da opção não pode ser vazio")
                .Length(1, 50).WithMessage("O nome deve conter entre 1 e 50 caracteres");
        }
    }
}
