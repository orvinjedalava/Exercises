namespace LogsAPI.Entities
{
    public class LogReport
    {
        protected IEnumerable<LogItem>? LogItems { get; private set; }
        public string? RawStringLogs { get; private set; }
    }
}
