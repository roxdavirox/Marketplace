using System;
using System.Collections.Generic;
using System.Text;
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

        public string Name { get; private set; }
    }
}
