using Marketplace.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Marketplace.App.Handlers.Options
{
    public class _AllOptions
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public class GetAllOptionsResponse 
    {
        public List<_AllOptions> Options;

        public GetAllOptionsResponse(IEnumerable<Option> options)
        {
            Options = new List<_AllOptions>();

            if (options == null) return;

            foreach (var option in options)
            {
                Options.Add(new _AllOptions {
                    Id = option.Id,
                    Name = option.Name
                });
            }
        }
        
    }
}
