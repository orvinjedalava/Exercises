using LogsAPI.Entities;
using LogsAPI.Enums;
using LogsAPI.ReportGenerators.Interfaces;

namespace LogsAPI.ReportGenerators
{
    public class HttpRequestsLogReportGenerator : IReportGenerator
    {
        public LogReport GenerateReport(IEnumerable<LogItem> logItems, string rawStringLogs)
        {
            IEnumerable<HttpRequestLogItem?> items = logItems.Select(item => item as HttpRequestLogItem);

            return new HttpRequestsLogReport(
                uniqueIPAddressCount: GetUniqueIPAddressCount(items),
                mostVisitedURLs: GetMostVisitedURLs(items),
                mostActiveIPAddresses: MostActiveIPAddresses(items),
                rawStringLogs: rawStringLogs
                );
        }

        private int GetUniqueIPAddressCount(IEnumerable<HttpRequestLogItem?> logItems)
        {
            return logItems.DistinctBy(item => item?.IPAddress.ToString()).Count();
        }

        private IEnumerable<RankedItem> GetMostVisitedURLs(IEnumerable<HttpRequestLogItem?> logItems)
        {
            throw new NotImplementedException();
        }

        private IEnumerable<RankedItem> MostActiveIPAddresses(IEnumerable<HttpRequestLogItem?> logItems)
        {
            throw new NotImplementedException();
        }
    }
}
