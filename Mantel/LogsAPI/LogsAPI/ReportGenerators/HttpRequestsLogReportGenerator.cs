using LogsAPI.Entities;
using LogsAPI.Enums;
using LogsAPI.ReportGenerators.Interfaces;
using System;

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
            List<RankedItem> result = new();
            //var urlCountMap = new Dictionary<string, int>();

            //foreach (var item in logItems)
            //{
            //    if (item == null)
            //        continue;

            //    string key = $"{item.IPAddress.ToString()}{item.Url}";
            //    if (!urlCountMap.ContainsKey(key))
            //        urlCountMap[key] = 0;

            //    urlCountMap[key]++;
            //}

            //IOrderedEnumerable<KeyValuePair<string, int>> orderedMap = urlCountMap.OrderByDescending(pair => pair.Value);

            //int index = 0;

            //while (index <= 2 && index < orderedMap.Count())
            //{
            //    result.Add(new RankedItem(index+1, orderedMap.ElementAt(index).Key));
            //    index++;
            //}
            int rank = 1;
            foreach(var item  in logItems.GroupBy(x => $"{x?.IPAddress.ToString()}{x?.Url}")
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
            //var apAddressCountMap = new Dictionary<string, int>();

            //foreach (var item in logItems)
            //{
            //    if (item == null)
            //        continue;

            //    string key = item.IPAddress.ToString();
            //    if (!apAddressCountMap.ContainsKey(key))
            //        apAddressCountMap[key] = 0;

            //    apAddressCountMap[key]++;
            //}

            //IOrderedEnumerable<KeyValuePair<string, int>> orderedMap = apAddressCountMap.OrderByDescending(pair => pair.Value);


            //int index = 0;

            //while (index <= 2 && index < orderedMap.Count())
            //{
            //    result.Add(new RankedItem(index+1, orderedMap.ElementAt(index).Key));
            //    index++;
            //}
            int rank = 1;
            foreach (var item in logItems.GroupBy(x => x.IPAddress.ToString())
                                        .Select(group => new { IPAddress = group.Key, Count = group.Count() })
                                        .OrderByDescending(x => x.Count))
            {
                if (rank > 3)
                    break;
                result.Add(new RankedItem(rank, item.IPAddress, item.Count));
                rank++;
            }

            return result;
        }
    }
}
