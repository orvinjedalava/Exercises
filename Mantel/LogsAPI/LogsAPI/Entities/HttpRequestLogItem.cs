using System.Net;

namespace LogsAPI.Entities
{
    public class HttpRequestLogItem : LogItem
    {
        public HttpRequestLogItem(
           IPAddress ipAddress,
           DateTime timestamp,
           HttpMethod httpMethod,
           string url,
           string httpProtocol,
           int httpResponseStatusCode,
           int port,
           string userAgent,
           string rawStringLog)
            : base(rawStringLog)
        {
            IPAddress = ipAddress;
            Timestamp = timestamp;
            HttpMethod = httpMethod;
            Url = url;
            HttpProtocol = httpProtocol;
            HttpResponseStatusCode = httpResponseStatusCode;
            Port = port;
            UserAgent = userAgent;
        }

        public IPAddress IPAddress { get; private set; }
        public DateTime Timestamp { get; private set; }
        public HttpMethod HttpMethod { get; private set; }
        public string Url { get; private set; }
        public string HttpProtocol { get; private set; }
        public int HttpResponseStatusCode { get; private set; }
        public int Port { get; private set; }
        public string UserAgent { get; private set; }
    }
}
