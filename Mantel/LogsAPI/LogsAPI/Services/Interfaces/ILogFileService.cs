using LogsAPI.Entities;
using LogsAPI.Enums;

namespace LogsAPI.Services.Interfaces
{
    public interface ILogFileService
    {
        LogItem CreateLogItem(string rawStringLog, LogItemType logItemType);
        LogSummary GenerateLogSummary(string rawStringLogs, LogItemType logItemType);
    }
}
