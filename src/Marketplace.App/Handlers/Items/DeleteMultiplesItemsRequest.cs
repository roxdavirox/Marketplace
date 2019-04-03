
using System;
using System.Collections.Generic;
using MediatR;

namespace Marketplace.App.Handlers.Items {
  public class DeleteMultiplesItemsRequest : IRequest<DeleteMultiplesItemsResponse> {
    public IEnumerable<Guid> ItemsIds { get; set; }
  }
}