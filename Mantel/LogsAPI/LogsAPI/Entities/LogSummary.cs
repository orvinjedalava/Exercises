using System.Text;

namespace LogsAPI.Entities
{
    public abstract class LogSummary
    {
        public LogSummary(IEnumerable<LogItem> logItems)
        {
            //LogItems = logItems;

            //var sb = new StringBuilder();
            //foreach(LogItem item in logItems)
            //{
            //    sb.AppendLine(item.RawStringLog);
            //}
            //RawStringLogs = sb.ToString();
        }

        protected IEnumerable<LogItem>? LogItems { get; private set; }
        public string? RawStringLogs { get; private set; }

        protected abstract void GenerateSummary();
    }
}
