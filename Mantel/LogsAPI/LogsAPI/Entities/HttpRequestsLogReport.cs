namespace LogsAPI.Entities
{
    public class HttpRequestsLogReport : LogReport
    {
        public int UniqueIPAddressCount { get; private set; }
        public List<RankedItem> MostVisitedURLs { get; private set; } = new List<RankedItem>();
        public List<RankedItem> MostActiveIPAddresses { get; private set; } = new List<RankedItem>();
    }
}
