using Marketplace.Domain.Entities.Base;
using Marketplace.Domain.Validators;

namespace Marketplace.Domain.Entities
{
    public class Product : EntityBase
    {
        public Product(string name)
        {
            Name = name;

            Validate(this, new ProductValidator());
        }

        public void HasOne(Option option) => Option = option;

        public string Name { get; private set; }
        public Option Option { get; set; }
    }
}
