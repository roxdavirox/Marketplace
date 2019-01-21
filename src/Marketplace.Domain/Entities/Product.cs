using Marketplace.Domain.Entities.Base;
using Marketplace.Domain.Validators;
using System.Collections.Generic;

namespace Marketplace.Domain.Entities
{
    public class Product : EntityBase
    {
        public Product(string name)
        {
            Name = name;

            Validate(this, new ProductValidator());
        }

        public string Name { get; private set; }
        public IEnumerable<Option> Options { get; set; }
    }
}
