namespace ProjectAPI.Contracts.Shared
{
    public class ChartModel
    {
        public string Symbol { get; set; }
        public string Timeframe { get; set; }
        public IEnumerable<IndicatorModel> Indicators { get; set; }
    }
}
