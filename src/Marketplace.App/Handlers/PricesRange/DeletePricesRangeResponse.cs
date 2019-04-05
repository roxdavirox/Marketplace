namespace Marketplace.App.Handlers.PricesRange
{
    public class DeletePricesRangeResponse
    {
        public DeletePricesRangeResponse(int deletedCount)
        {
            DeletedCount = deletedCount;
        }

        public int DeletedCount { get; set; }
    }
}
