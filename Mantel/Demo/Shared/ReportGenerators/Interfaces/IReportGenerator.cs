using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.ReportGenerators.Interfaces
{
    public interface IReportGenerator
    {
        LogReport GenerateReport(IEnumerable<LogItem> logItems, string rawStringLogs);
    }
}
