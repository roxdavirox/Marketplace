using Marketplace.Domain.Entities.Base;

namespace Marketplace.Domain.Entities
{
    public class Price : EntityBase
    {
        public Price(bool @fixed)
        {
            Fixed = @fixed;
        }

        public bool Fixed { get; private set; }
    }
}
