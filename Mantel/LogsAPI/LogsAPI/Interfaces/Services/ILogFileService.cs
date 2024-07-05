using LogsAPI.Models;

namespace LogsAPI.Interfaces.Services
{
    public interface ILogFileService
    {
        LogItem GenerateLogItem(string rawStringLog);
    }
}
