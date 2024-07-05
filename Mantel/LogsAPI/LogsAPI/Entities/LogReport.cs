namespace LogsAPI.Entities
{
    public class LogReport
    {
        public LogReport(string rawStringLogs)
        {
            RawStringLogs = rawStringLogs;
        }
        public string? RawStringLogs { get; private set; }
    }
}
