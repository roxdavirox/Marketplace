using FluentValidation;
using Marketplace.Domain.Entities;

namespace Marketplace.Domain.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(_ => _.Name)
                .NotEmpty().WithMessage("Nome não pode ser vazio")
                .Length(1, 50).WithMessage("O Nome deve conter entre 1 e 50 caracteres");

            RuleFor(_ => _.Email)
                .NotEmpty().WithMessage("E-mail não pode ser vazio")
                .EmailAddress().WithMessage("E-email invalido");

            RuleFor(_ => _.Password)
                .NotEmpty().WithMessage("A senha não pode ser vazia")
                .Length(3, 36).WithMessage("A senha deve ter entre 3 e 36 caracteres");

        }
    }
}
