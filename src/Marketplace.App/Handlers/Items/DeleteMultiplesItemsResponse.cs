namespace Marketplace.App.Handlers.Items {
  public class DeleteMultiplesItemsResponse {
    public int DeletedItemsCount { get; set; }

    public DeleteMultiplesItemsResponse(int deletedItemsCount)
    {
        DeletedItemsCount = deletedItemsCount;
    }
  }
}