namespace ProjectAPI.Contracts.Responses
{
    public class GetMostUsedIndicatorNamesResponse
    {
        public IEnumerable<IndicatorUsage> Indicators { get; set; }
    }

    public class IndicatorUsage
    {
        public string Name { get; set; }
        public int Used { get; set; }

    }
}
