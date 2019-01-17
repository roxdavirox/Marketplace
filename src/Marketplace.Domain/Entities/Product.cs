using System;
using System.Collections.Generic;
using System.Text;
using Marketplace.Domain.Entities.Base;

namespace Marketplace.Domain.Entities
{
    public class Product : EntityBase
    {
        public string Name { get; set; }
    }
}
