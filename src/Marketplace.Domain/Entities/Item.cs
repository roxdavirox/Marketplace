﻿using Marketplace.Domain.Entities.Base;
using Marketplace.Domain.Validators;

namespace Marketplace.Domain.Entities
{
    public class Item : EntityBase
    {
        public Item(string name)
        {
            Name = name;

            Validate(this, new ItemValidator());
        }

        public Item(string name, Option option)
        {
            Name = name;
            Option = option;

            Validate(this, new ItemValidator());
        }

        public Item(string name, Price price)
        {
            Name = name;
            Price = price;
        }

        public Item(string name, Price price, Option option)
        {
            Name = name;
            Price = price;
            Option = option;

            Validate(this, new ItemValidator());
        }

        public string Name { get; set; }
        public Price Price { get; set; }
        public virtual Option Option { get; set; }

        public void AssociateWith(Option option)
        {
            Option = option;
        }
    }
}
