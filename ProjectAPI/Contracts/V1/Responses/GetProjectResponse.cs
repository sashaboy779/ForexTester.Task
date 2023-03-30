using ProjectAPI.Contracts.Shared;

namespace ProjectAPI.Contracts.Responses
{
    public class GetProjectResponse
    {
        public string Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public IEnumerable<ChartModel> Charts { get; set; }
    }
}
