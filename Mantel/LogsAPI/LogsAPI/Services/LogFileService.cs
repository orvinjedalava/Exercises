using LogsAPI.Entities;
using LogsAPI.Enums;
using LogsAPI.Parsers;
using LogsAPI.Parsers.Interfaces;
using LogsAPI.ReportGenerators;
using LogsAPI.ReportGenerators.Interfaces;
using LogsAPI.Services.Interfaces;
using System;
using System.Net;

namespace LogsAPI.Services
{
    public class LogFileService : ILogFileService
    {
        public ILogParser GetLogParser(LogType logType)
        {
            switch(logType)
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

        IEnumerable<LogItem> ILogFileService.CreateLogItems(string rawStringLogs, LogType logType)
        {
            List<string> rawStringLogList = rawStringLogs.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).ToList();

            return rawStringLogList.Select(log => CreateLogItem(log, logType));
        }

        public LogReport GenerateLogReport(string rawStringLogs, LogType logType)
        {
            IReportGenerator reportGenerator = GetReportGenerator(logType);

            throw new NotImplementedException();
            
        }
    }
}
