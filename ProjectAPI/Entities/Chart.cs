namespace ProjectAPI.Entities
{
    public class Chart
    {
        public string Symbol { get; set; }
        public string Timeframe { get; set; }
        public IEnumerable<Indicator> Indicators { get; set; }
    }
}