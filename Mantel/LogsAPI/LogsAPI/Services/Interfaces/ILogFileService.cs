using LogsAPI.Entities;
using LogsAPI.Enums;
using LogsAPI.Parsers.Interfaces;

namespace LogsAPI.Services.Interfaces
{
    public interface ILogFileService
    {
        LogItem CreateLogItem(string rawStringLog, LogItemType logItemType);
        LogSummary GenerateLogSummary(string rawStringLogs, LogItemType logItemType);
        ILogParser GetLogParser(LogItemType logItemType);
    }
}
