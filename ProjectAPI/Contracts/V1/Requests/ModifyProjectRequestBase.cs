using ProjectAPI.Contracts.Shared;

namespace ProjectAPI.Contracts.Requests
{
    public abstract class ModifyProjectRequestBase
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public IEnumerable<ChartModel> Charts { get; set; }
    }
}
