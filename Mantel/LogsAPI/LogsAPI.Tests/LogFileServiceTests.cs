using FluentAssertions;
using FluentAssertions.Execution;
using LogsAPI.Entities;
using LogsAPI.Services;
using LogsAPI.Services.Interfaces;
using LogsAPI.Tests.TestData;
using System.Net;

namespace LogsAPI.Tests
{
    public class LogFileServiceTests
    {
        private readonly ILogFileService _service;

        public LogFileServiceTests()
        {
            _service = new LogFileService();
        }

        [Theory, ClassData(typeof(GenerateLogItemTestData))]
        public void GenerateLogItem_Test(
            string input,
            IPAddress expectedIPAddress,
            DateTime expectedTimestamp,
            HttpMethod expectedHttpMethod,
            string expectedUrl,
            string expectedHttpProtocol,
            int expectedHttpResponseStatusCode,
            int expectedPort,
            string expectedUserAgent,
            string expectedRawStringLog
            )
        {
            HttpRequestLogItem? result = _service.CreateLogItem(input, Enums.LogItemType.HttpRequest) as HttpRequestLogItem;

            if (result == null)
            {
                Assert.Fail($"Result came back null or result is not of type {typeof(HttpRequestLogItem)}");
            }
            else
            {
                using (new AssertionScope())
                {
                    result.IPAddress.Should().Be(expectedIPAddress);
                    result.Timestamp.Should().Be(expectedTimestamp);
                    result.HttpMethod.Should().Be(expectedHttpMethod);
                    result.Url.Should().Be(expectedUrl);
                    result.HttpProtocol.Should().Be(expectedHttpProtocol);
                    result.HttpResponseStatusCode.Should().Be(expectedHttpResponseStatusCode);
                    result.Port.Should().Be(expectedPort);
                    result.UserAgent.Should().Be(expectedUserAgent);
                    result.RawStringLog.Should().Be(expectedRawStringLog);
                }
            }
        }
    }
}