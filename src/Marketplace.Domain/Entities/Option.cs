using Marketplace.Domain.Entities.Base;
using Marketplace.Domain.Validators;

namespace Marketplace.Domain.Entities
{
    public class Option : EntityBase
    {
        public Option(string name)
        {
            Name = name;

            Validate(this, new OptionValidator());
        }

        public Option(string name, Product product)
        {
            Name = name;
            Product = product;

            Validate(this, new OptionValidator());
        }

        public string Name { get; set; }
        public virtual Product Product { get; set; }
    }
}
