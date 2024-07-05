using System.Net;

namespace LogsAPI.Models
{
    public class LogItem
    {
        public IPAddress IPAddress { get; set; }
        public DateTime Timestamp { get; set; }
        public HttpMethod HttpMethod { get; set; }
        public string Url { get; set; }
        public int StatusCode { get; set; }
        public int Port { get; set; }

        // Can be parsed further if needed

        /// <summary>
        /// Web browser identification information.
        /// Can be parsed further if needed.
        /// (e.g. "Mozilla/5.0 (X11; U; Linux x86_64; fr-FR) AppleWebKit/534.7 (KHTML, like Gecko) Epiphany/2.30.6 Safari/534.7 )"
        /// 
        /// Legacy Token: [ Mozilla/5.0 ]
        /// Operating System and platform information: [ (X11;I;Linux x86_64) ]
        /// Browser Engine: [ AppleWebKit/534.7 (KHTML, like Gecko)]
        /// Browser Name and Version: [ Epiphany/2.30.6 ]
        /// Browser Compatibilities: [ Safari/534/7 ]
        /// 
        /// </summary>
        public string UserAgent { get; set; }
        
        /// <summary>
        /// Represents the original log record
        /// </summary>
        public string RawStringLog { get; set; }
        

    }
}
