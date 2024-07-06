using Shared.Entities;
using Shared.Enums;
using Shared.Parsers;
using Shared.Parsers.Interfaces;
using Shared.ReportGenerators;
using Shared.ReportGenerators.Interfaces;
using Shared.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Services
{
    public class LogService : ILogService
    {
        public ILogParser GetLogParser(LogType logType)
        {
            switch (logType)
            {
                case LogType.HttpRequest:
                    return new HttpRequestLogParser();
                default:
                    throw new NotImplementedException($"No parser implemented for {logType}");
            }
        }

        public IReportGenerator GetReportGenerator(LogType logType)
        {
            switch (logType)
            {
                case LogType.HttpRequest:
                    return new HttpRequestsLogReportGenerator();
                default:
                    throw new NotImplementedException($"No report generator implemented for {logType}");
            }
        }

        public LogItem CreateLogItem(string rawStringLog, LogType logType)
        {
            ILogParser parser = GetLogParser(logType);

            return parser.Parse(rawStringLog);

        }

        public IEnumerable<LogItem> CreateLogItems(string rawStringLogs, LogType logType)
        {
            List<string> rawStringLogList = rawStringLogs.Split(new string[] { Environment.NewLine, "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();

            return rawStringLogList.Select(log => CreateLogItem(log, logType));
        }

        public LogReport GenerateLogReport(string rawStringLogs, LogType logType)
        {
            IEnumerable<LogItem> logItems = CreateLogItems(rawStringLogs, logType);

            IReportGenerator reportGenerator = GetReportGenerator(logType);

            return reportGenerator.GenerateReport(logItems, rawStringLogs);

        }
    }
}
