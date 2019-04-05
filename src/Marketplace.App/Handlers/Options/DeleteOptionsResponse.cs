namespace Marketplace.App.Handlers.Options
{
    public class DeleteOptionsResponse
    {
        public int DeletedOptionsCount { get; set; }
        public DeleteOptionsResponse(int deletedOptionsCount)
        {
            this.DeletedOptionsCount = deletedOptionsCount;
        }
    }
}
