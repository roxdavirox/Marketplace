using FluentValidation;
using Marketplace.Domain.Entities;

namespace Marketplace.Domain.Validators
{
    public class PriceRangeValidator : AbstractValidator<PriceRange>
    {
        public PriceRangeValidator()
        {
        }
    }
}
