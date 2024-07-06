using Shared.Entities;
using Shared.ReportGenerators.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.ReportGenerators
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
            List<RankedItem> result = new();
            int rank = 1;
            foreach (var item in logItems.GroupBy(x => $"{x?.IPAddress.ToString()}{x?.Url}")
                                        .Select(group => new { Url = group.Key, Count = group.Count() })
                                        .OrderByDescending(x => x.Count))
            {
                if (rank > 3)
                    break;
                result.Add(new RankedItem(rank, item.Url, item.Count));
                rank++;
            }

            return result;
        }

        private IEnumerable<RankedItem> MostActiveIPAddresses(IEnumerable<HttpRequestLogItem?> logItems)
        {
            List<RankedItem> result = new();
            int rank = 1;
            foreach (var item in logItems.GroupBy(x => x?.IPAddress.ToString())
                                        .Select(group => new { IPAddress = group.Key, Count = group.Count() })
                                        .OrderByDescending(x => x.Count))
            {
                if (rank > 3)
                    break;
                result.Add(new RankedItem(rank, item.IPAddress ?? string.Empty, item.Count));
                rank++;
            }

            return result;
        }
    }
}
