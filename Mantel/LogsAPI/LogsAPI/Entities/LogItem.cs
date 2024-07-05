namespace LogsAPI.Entities
{
    public abstract class LogItem
    {
        public LogItem(string rawStringLog)
        {
            RawStringLog = rawStringLog;
        }

        public string RawStringLog { get; private set; }

        //public abstract  GenerateLogSummary();
    }
}
