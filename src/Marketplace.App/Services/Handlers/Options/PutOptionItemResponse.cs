using Marketplace.Domain.Entities;
using System;

namespace Marketplace.App.Services.Handlers.Options
{
    public class PutOptionItemResponse
    {
        public Guid IdItem { get; set; }
        public string ItemName { get; set; }
        public Guid IdOption { get; set; }
        public string OptionName { get; set; }

        public PutOptionItemResponse(Item item, Option option)
        {
            IdItem = item.Id;
            ItemName = item.Name;

            IdOption = option.Id;
            OptionName = option.Name;
        }

    }
}
