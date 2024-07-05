namespace LogsAPI.Entities
{
    public class HttpRequestsLogSummary : LogSummary
    {
        public HttpRequestsLogSummary(IEnumerable<LogItem> logItems)
            : base(logItems)
        {

        }

        public int UniqueIPAddressesCount { get; private set; }
        public List<RankedItem> MostVisitedSites { get; private set; }
        public List<RankedItem> MostActiveIPAddresses { get; private set; }

        protected override void GenerateSummary()
        {
            throw new NotImplementedException();
        }
    }
}
