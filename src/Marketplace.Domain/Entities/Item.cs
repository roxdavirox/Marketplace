using Marketplace.Domain.Entities.Base;
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

        public string Name { get; set; }
        public virtual Option Option { get; set; }
    }
}
