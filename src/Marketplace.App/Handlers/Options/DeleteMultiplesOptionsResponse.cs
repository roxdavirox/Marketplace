namespace Marketplace.App.Handlers.Options
{
    public class DeleteMultiplesOptionsResponse
    {
        public int DeletedOptionsCount { get; set; }
        public DeleteMultiplesOptionsResponse(int deletedOptionsCount)
        {
            this.DeletedOptionsCount = deletedOptionsCount;
        }
    }
}
