using Microsoft.AspNetCore.Http;
using System;
using System.Net;

namespace LogsAPI.Models
{
    public class LogItem
    {
        public LogItem(
            IPAddress ipAddress,
            DateTime timestamp,
            HttpMethod httpMethod,
            string url,
            string httpProtocol,
            int httpResponseStatusCode,
            int port,
            string userAgent,
            string rawStringLog)
        {
            IPAddress = ipAddress;
            Timestamp = timestamp;
            HttpMethod = httpMethod;
            Url = url;
            HttpProtocol = httpProtocol;
            HttpResponseStatusCode = httpResponseStatusCode;
            Port = port;
            UserAgent = userAgent;
            RawStringLog = rawStringLog;
        }

        public IPAddress IPAddress { get; private set; }
        public DateTime Timestamp { get; private set; }
        public HttpMethod HttpMethod { get; private set; }
        public string Url { get; private set; }
        public string HttpProtocol { get; private set; }
        public int HttpResponseStatusCode { get; private set; }
        public int Port { get; private set; }
        public string UserAgent { get; private set; }
        
        /// <summary>
        /// Represents the original log record
        /// </summary>
        public string RawStringLog { get; private set; }
        

    }
}
