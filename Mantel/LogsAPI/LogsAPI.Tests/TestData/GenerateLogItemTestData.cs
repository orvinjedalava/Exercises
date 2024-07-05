using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LogsAPI.Tests.TestData
{
    public class GenerateLogItemTestData : IEnumerable<object[]>
    {
        private static IEnumerable<object[]> _data => new List<object[]>
        {
            new object[] {
                "177.71.128.21 - - [10/Jul/2018:22:21:28 +0200] \"GET /intranet-analytics/ HTTP/1.1\" 200 3574 \"-\" \"Mozilla/5.0 (X11; U; Linux x86_64; fr-FR) AppleWebKit/534.7 (KHTML, like Gecko) Epiphany/2.30.6 Safari/534.7\"",
                IPAddress.Parse("177.71.128.21"),
                new DateTime(2018, 7, 11, 6, 21, 28),
                HttpMethod.Get,
                "/intranet-analytics/",
                "HTTP/1.1",
                200,
                3574,
                "Mozilla/5.0 (X11; U; Linux x86_64; fr-FR) AppleWebKit/534.7 (KHTML, like Gecko) Epiphany/2.30.6 Safari/534.7"
            }
        };

        public IEnumerator<object[]> GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
