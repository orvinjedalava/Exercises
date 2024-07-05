using LogsAPI.Interfaces.Services;
using LogsAPI.Models;
using System.Net;

namespace LogsAPI.Services
{
    public class LogFileService : ILogFileService
    {
        public LogItem GenerateLogItem(string rawStringLog)
        {
            string[] logElements = rawStringLog.Split(' ');

            IPAddress ipAddress = IPAddress.Parse(logElements[0]);

            return new LogItem()
            {
                IPAddress = ipAddress
            };
        }
    }
}
