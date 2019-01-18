using System;
using System.Collections.Generic;
using System.Text;
using Marketplace.Domain.Entities.Base;

namespace Marketplace.Domain.Entities
{
    public class Product : EntityBase
    {
        public Product(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}
