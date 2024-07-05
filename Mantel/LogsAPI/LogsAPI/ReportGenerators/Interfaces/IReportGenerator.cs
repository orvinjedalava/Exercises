using LogsAPI.Entities;

namespace LogsAPI.ReportGenerators.Interfaces
{
    public interface IReportGenerator
    {
        LogReport GenerateReport(string rawStringLogs);
    }
}
