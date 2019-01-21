using System;

namespace Marketplace.Domain.Entities.Base
{
    public abstract class EntityBase : EntityBaseNotification
    {
        public EntityBase()
        {
            Id = Guid.NewGuid();
        }

        public virtual Guid Id { get; set; }
    }
}
