using Marketplace.Domain.Entities;
using System;

namespace Marketplace.App.Services.Handlers.Options
{
    public class CreateOptionItemResponse
    {
        public string ItemName { get; set; }
        public Guid IdItem { get; set; }
        public string OptionName { get; set; }
        public Guid IdOption { get; set; }

        public CreateOptionItemResponse(Item item, Option option)
        {
            ItemName = item.Name;
            IdItem = item.Id;

            OptionName = option.Name;
            IdOption = option.Id;
        }
    }
}
