using LogsAPI.Entities;
using LogsAPI.Enums;
using LogsAPI.Parsers.Interfaces;
using LogsAPI.ReportGenerators.Interfaces;

namespace LogsAPI.Services.Interfaces
{
    public interface ILogFileService
    {
        LogItem CreateLogItem(string rawStringLog, LogType logType);
        LogReport GenerateLogReport(string rawStringLogs, LogType logType);
        ILogParser GetLogParser(LogType logType);
        IReportGenerator GetReportGenerator(LogType logType);
        IEnumerable<LogItem> CreateLogItems(string rawStringLogs, LogType logType);
    }
}
