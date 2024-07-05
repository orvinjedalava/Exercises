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
            DateTime timestamp = DateTime.ParseExact($"{logElements[3]} {logElements[4]}" , "[dd/MMM/yyyy:HH:mm:ss zzzz]", null);
            HttpMethod httpMethod = HttpMethod.Parse(logElements[5].Substring(1));
            string url = logElements[6];
            string httpProtocol = logElements[7].Substring(0, logElements[7].Length - 1);

            return new LogItem()
            {
                IPAddress = ipAddress,
                Timestamp = timestamp,
                HttpMethod = httpMethod,
                Url = url,
                HttpProtocol = httpProtocol
            };
        }
    }
}
