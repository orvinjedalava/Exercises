using LogsAPI.Entities;

namespace LogsAPI.Parsers.Interfaces
{
    public interface ILogParser
    {
        LogItem Parse(string rawStringLog);
    }
}
