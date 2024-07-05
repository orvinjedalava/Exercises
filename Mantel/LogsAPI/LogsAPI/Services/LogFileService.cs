using LogsAPI.Entities;
using LogsAPI.Enums;
using LogsAPI.Parsers;
using LogsAPI.Parsers.Interfaces;
using LogsAPI.Services.Interfaces;
using System;
using System.Net;

namespace LogsAPI.Services
{
    public class LogFileService : ILogFileService
    {
        public LogItem CreateLogItem(string rawStringLog, LogItemType logItemType)
        {
            string[] logElements = rawStringLog.Split(' ');

            IPAddress ipAddress = IPAddress.Parse(logElements[0]);
            DateTime timestamp = DateTime.ParseExact($"{logElements[3]} {logElements[4]}", "[dd/MMM/yyyy:HH:mm:ss zzzz]", null);
            HttpMethod httpMethod = HttpMethod.Parse(logElements[5].Substring(1));
            string url = logElements[6];
            string httpProtocol = logElements[7].Substring(0, logElements[7].Length - 1);
            int httpResponseStatusCode = int.Parse(logElements[8]);
            int port = int.Parse(logElements[9]);
            string userAgentTemp = string.Join(' ', logElements.Skip(11));
            string userAgent = userAgentTemp.Substring(1, userAgentTemp.Length - 2);

            return new HttpRequestLogItem(
                ipAddress: ipAddress,
                timestamp: timestamp,
                httpMethod: httpMethod,
                url: url,
                httpProtocol: httpProtocol,
                httpResponseStatusCode: httpResponseStatusCode,
                port: port,
                userAgent: userAgent,
                rawStringLog: rawStringLog);

        }

        public ILogParser GetLogParser(LogItemType logItemType)
        {
            switch(logItemType)
            {
                case LogItemType.HttpRequest:
                    return new HttpRequestLogParser();
                default:
                    throw new NotImplementedException($"No parser implemented for {logItemType}");
            }

            return null;
        }

        public LogSummary GenerateLogSummary(string rawStringLogs, LogItemType logItemType)
        {
            throw new NotImplementedException();
        }
    }
}
